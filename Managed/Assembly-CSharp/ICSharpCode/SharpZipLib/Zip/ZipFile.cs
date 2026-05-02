using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Encryption;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000152 RID: 338
	public class ZipFile : IEnumerable, IDisposable
	{
		// Token: 0x060017A7 RID: 6055 RVA: 0x0013069C File Offset: 0x0012E89C
		private void OnKeysRequired(string fileName)
		{
			if (this.KeysRequired != null)
			{
				KeysRequiredEventArgs keysRequiredEventArgs = new KeysRequiredEventArgs(fileName, this.key);
				this.KeysRequired(this, keysRequiredEventArgs);
				this.key = keysRequiredEventArgs.Key;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060017A8 RID: 6056 RVA: 0x001306D7 File Offset: 0x0012E8D7
		// (set) Token: 0x060017A9 RID: 6057 RVA: 0x001306DF File Offset: 0x0012E8DF
		private byte[] Key
		{
			get
			{
				return this.key;
			}
			set
			{
				this.key = value;
			}
		}

		// Token: 0x1700010E RID: 270
		// (set) Token: 0x060017AA RID: 6058 RVA: 0x001306E8 File Offset: 0x0012E8E8
		public string Password
		{
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this.key = null;
					return;
				}
				this.rawPassword_ = value;
				this.key = PkzipClassic.GenerateKeys(ZipStrings.ConvertToArray(value));
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060017AB RID: 6059 RVA: 0x00130712 File Offset: 0x0012E912
		private bool HaveKeys
		{
			get
			{
				return this.key != null;
			}
		}

		// Token: 0x060017AC RID: 6060 RVA: 0x00130720 File Offset: 0x0012E920
		public ZipFile(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.name_ = name;
			this.baseStream_ = File.Open(name, FileMode.Open, FileAccess.Read, FileShare.Read);
			this.isStreamOwner = true;
			try
			{
				this.ReadEntries();
			}
			catch
			{
				this.DisposeInternal(true);
				throw;
			}
		}

		// Token: 0x060017AD RID: 6061 RVA: 0x001307A0 File Offset: 0x0012E9A0
		public ZipFile(FileStream file)
			: this(file, false)
		{
		}

		// Token: 0x060017AE RID: 6062 RVA: 0x001307AC File Offset: 0x0012E9AC
		public ZipFile(FileStream file, bool leaveOpen)
		{
			if (file == null)
			{
				throw new ArgumentNullException("file");
			}
			if (!file.CanSeek)
			{
				throw new ArgumentException("Stream is not seekable", "file");
			}
			this.baseStream_ = file;
			this.name_ = file.Name;
			this.isStreamOwner = !leaveOpen;
			try
			{
				this.ReadEntries();
			}
			catch
			{
				this.DisposeInternal(true);
				throw;
			}
		}

		// Token: 0x060017AF RID: 6063 RVA: 0x00130844 File Offset: 0x0012EA44
		public ZipFile(Stream stream)
			: this(stream, false)
		{
		}

		// Token: 0x060017B0 RID: 6064 RVA: 0x00130850 File Offset: 0x0012EA50
		public ZipFile(Stream stream, bool leaveOpen)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream.CanSeek)
			{
				throw new ArgumentException("Stream is not seekable", "stream");
			}
			this.baseStream_ = stream;
			this.isStreamOwner = !leaveOpen;
			if (this.baseStream_.Length > 0L)
			{
				try
				{
					this.ReadEntries();
					return;
				}
				catch
				{
					this.DisposeInternal(true);
					throw;
				}
			}
			this.entries_ = new ZipEntry[0];
			this.isNewArchive_ = true;
		}

		// Token: 0x060017B1 RID: 6065 RVA: 0x001308FC File Offset: 0x0012EAFC
		internal ZipFile()
		{
			this.entries_ = new ZipEntry[0];
			this.isNewArchive_ = true;
		}

		// Token: 0x060017B2 RID: 6066 RVA: 0x00130934 File Offset: 0x0012EB34
		~ZipFile()
		{
			this.Dispose(false);
		}

		// Token: 0x060017B3 RID: 6067 RVA: 0x00130964 File Offset: 0x0012EB64
		public void Close()
		{
			this.DisposeInternal(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060017B4 RID: 6068 RVA: 0x00130974 File Offset: 0x0012EB74
		public static ZipFile Create(string fileName)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			FileStream fileStream = File.Create(fileName);
			return new ZipFile
			{
				name_ = fileName,
				baseStream_ = fileStream,
				isStreamOwner = true
			};
		}

		// Token: 0x060017B5 RID: 6069 RVA: 0x001309B0 File Offset: 0x0012EBB0
		public static ZipFile Create(Stream outStream)
		{
			if (outStream == null)
			{
				throw new ArgumentNullException("outStream");
			}
			if (!outStream.CanWrite)
			{
				throw new ArgumentException("Stream is not writeable", "outStream");
			}
			if (!outStream.CanSeek)
			{
				throw new ArgumentException("Stream is not seekable", "outStream");
			}
			return new ZipFile
			{
				baseStream_ = outStream
			};
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060017B6 RID: 6070 RVA: 0x00130A07 File Offset: 0x0012EC07
		// (set) Token: 0x060017B7 RID: 6071 RVA: 0x00130A0F File Offset: 0x0012EC0F
		public bool IsStreamOwner
		{
			get
			{
				return this.isStreamOwner;
			}
			set
			{
				this.isStreamOwner = value;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060017B8 RID: 6072 RVA: 0x00130A18 File Offset: 0x0012EC18
		public bool IsEmbeddedArchive
		{
			get
			{
				return this.offsetOfFirstEntry > 0L;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060017B9 RID: 6073 RVA: 0x00130A24 File Offset: 0x0012EC24
		public bool IsNewArchive
		{
			get
			{
				return this.isNewArchive_;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060017BA RID: 6074 RVA: 0x00130A2C File Offset: 0x0012EC2C
		public string ZipFileComment
		{
			get
			{
				return this.comment_;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060017BB RID: 6075 RVA: 0x00130A34 File Offset: 0x0012EC34
		public string Name
		{
			get
			{
				return this.name_;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060017BC RID: 6076 RVA: 0x00130A3C File Offset: 0x0012EC3C
		[Obsolete("Use the Count property instead")]
		public int Size
		{
			get
			{
				return this.entries_.Length;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060017BD RID: 6077 RVA: 0x00130A46 File Offset: 0x0012EC46
		public long Count
		{
			get
			{
				return (long)this.entries_.Length;
			}
		}

		// Token: 0x17000117 RID: 279
		[IndexerName("EntryByIndex")]
		public ZipEntry this[int index]
		{
			get
			{
				return (ZipEntry)this.entries_[index].Clone();
			}
		}

		// Token: 0x060017BF RID: 6079 RVA: 0x00130A65 File Offset: 0x0012EC65
		public IEnumerator GetEnumerator()
		{
			if (this.isDisposed_)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			return new ZipFile.ZipEntryEnumerator(this.entries_);
		}

		// Token: 0x060017C0 RID: 6080 RVA: 0x00130A88 File Offset: 0x0012EC88
		public int FindEntry(string name, bool ignoreCase)
		{
			if (this.isDisposed_)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			for (int i = 0; i < this.entries_.Length; i++)
			{
				if (string.Compare(name, this.entries_[i].Name, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) == 0)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x060017C1 RID: 6081 RVA: 0x00130ADC File Offset: 0x0012ECDC
		public ZipEntry GetEntry(string name)
		{
			if (this.isDisposed_)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			int num = this.FindEntry(name, true);
			if (num < 0)
			{
				return null;
			}
			return (ZipEntry)this.entries_[num].Clone();
		}

		// Token: 0x060017C2 RID: 6082 RVA: 0x00130B20 File Offset: 0x0012ED20
		public Stream GetInputStream(ZipEntry entry)
		{
			if (entry == null)
			{
				throw new ArgumentNullException("entry");
			}
			if (this.isDisposed_)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			long num = entry.ZipFileIndex;
			if (num < 0L || num >= (long)this.entries_.Length || this.entries_[(int)(checked((IntPtr)num))].Name != entry.Name)
			{
				num = (long)this.FindEntry(entry.Name, true);
				if (num < 0L)
				{
					throw new ZipException("Entry cannot be found");
				}
			}
			return this.GetInputStream(num);
		}

		// Token: 0x060017C3 RID: 6083 RVA: 0x00130BA8 File Offset: 0x0012EDA8
		public Stream GetInputStream(long entryIndex)
		{
			if (this.isDisposed_)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			checked
			{
				long num = this.LocateEntry(this.entries_[(int)((IntPtr)entryIndex)]);
				CompressionMethod compressionMethod = this.entries_[(int)((IntPtr)entryIndex)].CompressionMethod;
				Stream stream = new ZipFile.PartialInputStream(this, num, this.entries_[(int)((IntPtr)entryIndex)].CompressedSize);
				if (this.entries_[(int)((IntPtr)entryIndex)].IsCrypted)
				{
					stream = this.CreateAndInitDecryptionStream(stream, this.entries_[(int)((IntPtr)entryIndex)]);
					if (stream == null)
					{
						throw new ZipException("Unable to decrypt this entry");
					}
				}
				if (compressionMethod != CompressionMethod.Stored)
				{
					if (compressionMethod != CompressionMethod.Deflated)
					{
						throw new ZipException("Unsupported compression method " + compressionMethod.ToString());
					}
					stream = new InflaterInputStream(stream, new Inflater(true));
				}
				return stream;
			}
		}

		// Token: 0x060017C4 RID: 6084 RVA: 0x00130C60 File Offset: 0x0012EE60
		public bool TestArchive(bool testData)
		{
			return this.TestArchive(testData, TestStrategy.FindFirstError, null);
		}

		// Token: 0x060017C5 RID: 6085 RVA: 0x00130C6C File Offset: 0x0012EE6C
		public bool TestArchive(bool testData, TestStrategy strategy, ZipTestResultHandler resultHandler)
		{
			if (this.isDisposed_)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			TestStatus testStatus = new TestStatus(this);
			if (resultHandler != null)
			{
				resultHandler(testStatus, null);
			}
			ZipFile.HeaderTest headerTest = (testData ? (ZipFile.HeaderTest.Extract | ZipFile.HeaderTest.Header) : ZipFile.HeaderTest.Header);
			bool flag = true;
			try
			{
				int num = 0;
				while (flag && (long)num < this.Count)
				{
					if (resultHandler != null)
					{
						testStatus.SetEntry(this[num]);
						testStatus.SetOperation(TestOperation.EntryHeader);
						resultHandler(testStatus, null);
					}
					try
					{
						this.TestLocalHeader(this[num], headerTest);
					}
					catch (ZipException ex)
					{
						testStatus.AddError();
						if (resultHandler != null)
						{
							resultHandler(testStatus, "Exception during test - '" + ex.Message + "'");
						}
						flag &= strategy > TestStrategy.FindFirstError;
					}
					if (flag && testData && this[num].IsFile)
					{
						if (resultHandler != null)
						{
							testStatus.SetOperation(TestOperation.EntryData);
							resultHandler(testStatus, null);
						}
						Crc32 crc = new Crc32();
						using (Stream inputStream = this.GetInputStream(this[num]))
						{
							byte[] array = new byte[4096];
							long num2 = 0L;
							int num3;
							while ((num3 = inputStream.Read(array, 0, array.Length)) > 0)
							{
								crc.Update(new ArraySegment<byte>(array, 0, num3));
								if (resultHandler != null)
								{
									num2 += (long)num3;
									testStatus.SetBytesTested(num2);
									resultHandler(testStatus, null);
								}
							}
						}
						if (this[num].Crc != crc.Value)
						{
							testStatus.AddError();
							if (resultHandler != null)
							{
								resultHandler(testStatus, "CRC mismatch");
							}
							flag &= strategy > TestStrategy.FindFirstError;
						}
						if ((this[num].Flags & 8) != 0)
						{
							ZipHelperStream zipHelperStream = new ZipHelperStream(this.baseStream_);
							DescriptorData descriptorData = new DescriptorData();
							zipHelperStream.ReadDataDescriptor(this[num].LocalHeaderRequiresZip64, descriptorData);
							if (this[num].Crc != descriptorData.Crc)
							{
								testStatus.AddError();
							}
							if (this[num].CompressedSize != descriptorData.CompressedSize)
							{
								testStatus.AddError();
							}
							if (this[num].Size != descriptorData.Size)
							{
								testStatus.AddError();
							}
						}
					}
					if (resultHandler != null)
					{
						testStatus.SetOperation(TestOperation.EntryComplete);
						resultHandler(testStatus, null);
					}
					num++;
				}
				if (resultHandler != null)
				{
					testStatus.SetOperation(TestOperation.MiscellaneousTests);
					resultHandler(testStatus, null);
				}
			}
			catch (Exception ex2)
			{
				testStatus.AddError();
				if (resultHandler != null)
				{
					resultHandler(testStatus, "Exception during test - '" + ex2.Message + "'");
				}
			}
			if (resultHandler != null)
			{
				testStatus.SetOperation(TestOperation.Complete);
				testStatus.SetEntry(null);
				resultHandler(testStatus, null);
			}
			return testStatus.ErrorCount == 0;
		}

		// Token: 0x060017C6 RID: 6086 RVA: 0x00130F3C File Offset: 0x0012F13C
		private long TestLocalHeader(ZipEntry entry, ZipFile.HeaderTest tests)
		{
			Stream stream = this.baseStream_;
			long num14;
			lock (stream)
			{
				bool flag2 = (tests & ZipFile.HeaderTest.Header) > (ZipFile.HeaderTest)0;
				bool flag3 = (tests & ZipFile.HeaderTest.Extract) > (ZipFile.HeaderTest)0;
				long num = this.offsetOfFirstEntry + entry.Offset;
				this.baseStream_.Seek(num, SeekOrigin.Begin);
				int num2 = (int)this.ReadLEUint();
				if (num2 != 67324752)
				{
					throw new ZipException(string.Format("Wrong local header signature at 0x{0:x}, expected 0x{1:x8}, actual 0x{2:x8}", num, 67324752, num2));
				}
				short num3 = (short)(this.ReadLEUshort() & 255);
				short num4 = (short)this.ReadLEUshort();
				short num5 = (short)this.ReadLEUshort();
				short num6 = (short)this.ReadLEUshort();
				short num7 = (short)this.ReadLEUshort();
				uint num8 = this.ReadLEUint();
				long num9 = (long)((ulong)this.ReadLEUint());
				long num10 = (long)((ulong)this.ReadLEUint());
				int num11 = (int)this.ReadLEUshort();
				int num12 = (int)this.ReadLEUshort();
				byte[] array = new byte[num11];
				StreamUtils.ReadFully(this.baseStream_, array);
				byte[] array2 = new byte[num12];
				StreamUtils.ReadFully(this.baseStream_, array2);
				ZipExtraData zipExtraData = new ZipExtraData(array2);
				if (zipExtraData.Find(1))
				{
					num10 = zipExtraData.ReadLong();
					num9 = zipExtraData.ReadLong();
					if ((num4 & 8) != 0)
					{
						if (num10 != -1L && num10 != entry.Size)
						{
							throw new ZipException("Size invalid for descriptor");
						}
						if (num9 != -1L && num9 != entry.CompressedSize)
						{
							throw new ZipException("Compressed size invalid for descriptor");
						}
					}
				}
				else if (num3 >= 45 && ((uint)num10 == 4294967295U || (uint)num9 == 4294967295U))
				{
					throw new ZipException("Required Zip64 extended information missing");
				}
				if (flag3 && entry.IsFile)
				{
					if (!entry.IsCompressionMethodSupported())
					{
						throw new ZipException("Compression method not supported");
					}
					if (num3 > 51 || (num3 > 20 && num3 < 45))
					{
						throw new ZipException(string.Format("Version required to extract this entry not supported ({0})", num3));
					}
					if ((num4 & 12384) != 0)
					{
						throw new ZipException("The library does not support the zip version required to extract this entry");
					}
				}
				if (flag2)
				{
					if (num3 <= 63 && num3 != 10 && num3 != 11 && num3 != 20 && num3 != 21 && num3 != 25 && num3 != 27 && num3 != 45 && num3 != 46 && num3 != 50 && num3 != 51 && num3 != 52 && num3 != 61 && num3 != 62 && num3 != 63)
					{
						throw new ZipException(string.Format("Version required to extract this entry is invalid ({0})", num3));
					}
					if (((int)num4 & 49168) != 0)
					{
						throw new ZipException("Reserved bit flags cannot be set.");
					}
					if ((num4 & 1) != 0 && num3 < 20)
					{
						throw new ZipException(string.Format("Version required to extract this entry is too low for encryption ({0})", num3));
					}
					if ((num4 & 64) != 0)
					{
						if ((num4 & 1) == 0)
						{
							throw new ZipException("Strong encryption flag set but encryption flag is not set");
						}
						if (num3 < 50)
						{
							throw new ZipException(string.Format("Version required to extract this entry is too low for encryption ({0})", num3));
						}
					}
					if ((num4 & 32) != 0 && num3 < 27)
					{
						throw new ZipException(string.Format("Patched data requires higher version than ({0})", num3));
					}
					if ((int)num4 != entry.Flags)
					{
						throw new ZipException("Central header/local header flags mismatch");
					}
					if (entry.CompressionMethod != (CompressionMethod)num5)
					{
						throw new ZipException("Central header/local header compression method mismatch");
					}
					if (entry.Version != (int)num3)
					{
						throw new ZipException("Extract version mismatch");
					}
					if ((num4 & 64) != 0 && num3 < 62)
					{
						throw new ZipException("Strong encryption flag set but version not high enough");
					}
					if ((num4 & 8192) != 0 && (num6 != 0 || num7 != 0))
					{
						throw new ZipException("Header masked set but date/time values non-zero");
					}
					if ((num4 & 8) == 0 && num8 != (uint)entry.Crc)
					{
						throw new ZipException("Central header/local header crc mismatch");
					}
					if (num10 == 0L && num9 == 0L && num8 != 0U)
					{
						throw new ZipException("Invalid CRC for empty entry");
					}
					if (entry.Name.Length > num11)
					{
						throw new ZipException("File name length mismatch");
					}
					string text = ZipStrings.ConvertToStringExt((int)num4, array);
					if (text != entry.Name)
					{
						throw new ZipException("Central header and local header file name mismatch");
					}
					if (entry.IsDirectory)
					{
						if (num10 > 0L)
						{
							throw new ZipException("Directory cannot have size");
						}
						if (entry.IsCrypted)
						{
							if (num9 > 14L)
							{
								throw new ZipException("Directory compressed size invalid");
							}
						}
						else if (num9 > 2L)
						{
							throw new ZipException("Directory compressed size invalid");
						}
					}
					if (!ZipNameTransform.IsValidName(text, true))
					{
						throw new ZipException("Name is invalid");
					}
				}
				if ((num4 & 8) == 0 || ((num10 > 0L || num9 > 0L) && entry.Size > 0L))
				{
					if (num10 != 0L && num10 != entry.Size)
					{
						throw new ZipException(string.Format("Size mismatch between central header({0}) and local header({1})", entry.Size, num10));
					}
					if (num9 != 0L && num9 != entry.CompressedSize && num9 != (long)((ulong)(-1)) && num9 != -1L)
					{
						throw new ZipException(string.Format("Compressed size mismatch between central header({0}) and local header({1})", entry.CompressedSize, num9));
					}
				}
				int num13 = num11 + num12;
				num14 = this.offsetOfFirstEntry + entry.Offset + 30L + (long)num13;
			}
			return num14;
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060017C7 RID: 6087 RVA: 0x0013142C File Offset: 0x0012F62C
		// (set) Token: 0x060017C8 RID: 6088 RVA: 0x00131439 File Offset: 0x0012F639
		public INameTransform NameTransform
		{
			get
			{
				return this.updateEntryFactory_.NameTransform;
			}
			set
			{
				this.updateEntryFactory_.NameTransform = value;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060017C9 RID: 6089 RVA: 0x00131447 File Offset: 0x0012F647
		// (set) Token: 0x060017CA RID: 6090 RVA: 0x0013144F File Offset: 0x0012F64F
		public IEntryFactory EntryFactory
		{
			get
			{
				return this.updateEntryFactory_;
			}
			set
			{
				if (value == null)
				{
					this.updateEntryFactory_ = new ZipEntryFactory();
					return;
				}
				this.updateEntryFactory_ = value;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060017CB RID: 6091 RVA: 0x00131467 File Offset: 0x0012F667
		// (set) Token: 0x060017CC RID: 6092 RVA: 0x0013146F File Offset: 0x0012F66F
		public int BufferSize
		{
			get
			{
				return this.bufferSize_;
			}
			set
			{
				if (value < 1024)
				{
					throw new ArgumentOutOfRangeException("value", "cannot be below 1024");
				}
				if (this.bufferSize_ != value)
				{
					this.bufferSize_ = value;
					this.copyBuffer_ = null;
				}
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060017CD RID: 6093 RVA: 0x001314A0 File Offset: 0x0012F6A0
		public bool IsUpdating
		{
			get
			{
				return this.updates_ != null;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060017CE RID: 6094 RVA: 0x001314AB File Offset: 0x0012F6AB
		// (set) Token: 0x060017CF RID: 6095 RVA: 0x001314B3 File Offset: 0x0012F6B3
		public UseZip64 UseZip64
		{
			get
			{
				return this.useZip64_;
			}
			set
			{
				this.useZip64_ = value;
			}
		}

		// Token: 0x060017D0 RID: 6096 RVA: 0x001314BC File Offset: 0x0012F6BC
		public void BeginUpdate(IArchiveStorage archiveStorage, IDynamicDataSource dataSource)
		{
			if (this.isDisposed_)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			if (this.IsEmbeddedArchive)
			{
				throw new ZipException("Cannot update embedded/SFX archives");
			}
			if (archiveStorage == null)
			{
				throw new ArgumentNullException("archiveStorage");
			}
			this.archiveStorage_ = archiveStorage;
			if (dataSource == null)
			{
				throw new ArgumentNullException("dataSource");
			}
			this.updateDataSource_ = dataSource;
			this.updateIndex_ = new Dictionary<string, int>();
			this.updates_ = new List<ZipFile.ZipUpdate>(this.entries_.Length);
			foreach (ZipEntry zipEntry in this.entries_)
			{
				int count = this.updates_.Count;
				this.updates_.Add(new ZipFile.ZipUpdate(zipEntry));
				this.updateIndex_.Add(zipEntry.Name, count);
			}
			this.updates_.Sort(new ZipFile.UpdateComparer());
			int num = 0;
			foreach (ZipFile.ZipUpdate zipUpdate in this.updates_)
			{
				if (num == this.updates_.Count - 1)
				{
					break;
				}
				zipUpdate.OffsetBasedSize = this.updates_[num + 1].Entry.Offset - zipUpdate.Entry.Offset;
				num++;
			}
			this.updateCount_ = (long)this.updates_.Count;
			this.contentsEdited_ = false;
			this.commentEdited_ = false;
			this.newComment_ = null;
		}

		// Token: 0x060017D1 RID: 6097 RVA: 0x00131640 File Offset: 0x0012F840
		public void BeginUpdate(IArchiveStorage archiveStorage)
		{
			this.BeginUpdate(archiveStorage, new DynamicDiskDataSource());
		}

		// Token: 0x060017D2 RID: 6098 RVA: 0x0013164E File Offset: 0x0012F84E
		public void BeginUpdate()
		{
			if (this.Name == null)
			{
				this.BeginUpdate(new MemoryArchiveStorage(), new DynamicDiskDataSource());
				return;
			}
			this.BeginUpdate(new DiskArchiveStorage(this), new DynamicDiskDataSource());
		}

		// Token: 0x060017D3 RID: 6099 RVA: 0x0013167C File Offset: 0x0012F87C
		public void CommitUpdate()
		{
			if (this.isDisposed_)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			this.CheckUpdating();
			try
			{
				this.updateIndex_.Clear();
				this.updateIndex_ = null;
				if (this.contentsEdited_)
				{
					this.RunUpdates();
				}
				else if (this.commentEdited_)
				{
					this.UpdateCommentOnly();
				}
				else if (this.entries_.Length == 0)
				{
					byte[] array = ((this.newComment_ != null) ? this.newComment_.RawComment : ZipStrings.ConvertToArray(this.comment_));
					using (ZipHelperStream zipHelperStream = new ZipHelperStream(this.baseStream_))
					{
						zipHelperStream.WriteEndOfCentralDirectory(0L, 0L, 0L, array);
					}
				}
			}
			finally
			{
				this.PostUpdateCleanup();
			}
		}

		// Token: 0x060017D4 RID: 6100 RVA: 0x00131748 File Offset: 0x0012F948
		public void AbortUpdate()
		{
			this.PostUpdateCleanup();
		}

		// Token: 0x060017D5 RID: 6101 RVA: 0x00131750 File Offset: 0x0012F950
		public void SetComment(string comment)
		{
			if (this.isDisposed_)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			this.CheckUpdating();
			this.newComment_ = new ZipFile.ZipString(comment);
			if (this.newComment_.RawLength > 65535)
			{
				this.newComment_ = null;
				throw new ZipException("Comment length exceeds maximum - 65535");
			}
			this.commentEdited_ = true;
		}

		// Token: 0x060017D6 RID: 6102 RVA: 0x001317B0 File Offset: 0x0012F9B0
		private void AddUpdate(ZipFile.ZipUpdate update)
		{
			this.contentsEdited_ = true;
			int num = this.FindExistingUpdate(update.Entry.Name);
			if (num >= 0)
			{
				if (this.updates_[num] == null)
				{
					this.updateCount_ += 1L;
				}
				this.updates_[num] = update;
				return;
			}
			num = this.updates_.Count;
			this.updates_.Add(update);
			this.updateCount_ += 1L;
			this.updateIndex_.Add(update.Entry.Name, num);
		}

		// Token: 0x060017D7 RID: 6103 RVA: 0x00131844 File Offset: 0x0012FA44
		public void Add(string fileName, CompressionMethod compressionMethod, bool useUnicodeText)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			if (this.isDisposed_)
			{
				throw new ObjectDisposedException("ZipFile");
			}
			if (!ZipEntry.IsCompressionMethodSupported(compressionMethod))
			{
				throw new ArgumentOutOfRangeException("compressionMethod");
			}
			this.CheckUpdating();
			this.contentsEdited_ = true;
			ZipEntry zipEntry = this.EntryFactory.MakeFileEntry(fileName);
			zipEntry.IsUnicodeText = useUnicodeText;
			zipEntry.CompressionMethod = compressionMethod;
			this.AddUpdate(new ZipFile.ZipUpdate(fileName, zipEntry));
		}

		// Token: 0x060017D8 RID: 6104 RVA: 0x001318BC File Offset: 0x0012FABC
		public void Add(string fileName, CompressionMethod compressionMethod)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			if (!ZipEntry.IsCompressionMethodSupported(compressionMethod))
			{
				throw new ArgumentOutOfRangeException("compressionMethod");
			}
			this.CheckUpdating();
			this.contentsEdited_ = true;
			ZipEntry zipEntry = this.EntryFactory.MakeFileEntry(fileName);
			zipEntry.CompressionMethod = compressionMethod;
			this.AddUpdate(new ZipFile.ZipUpdate(fileName, zipEntry));
		}

		// Token: 0x060017D9 RID: 6105 RVA: 0x00131918 File Offset: 0x0012FB18
		public void Add(string fileName)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			this.CheckUpdating();
			this.AddUpdate(new ZipFile.ZipUpdate(fileName, this.EntryFactory.MakeFileEntry(fileName)));
		}

		// Token: 0x060017DA RID: 6106 RVA: 0x00131946 File Offset: 0x0012FB46
		public void Add(string fileName, string entryName)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			if (entryName == null)
			{
				throw new ArgumentNullException("entryName");
			}
			this.CheckUpdating();
			this.AddUpdate(new ZipFile.ZipUpdate(fileName, this.EntryFactory.MakeFileEntry(fileName, entryName, true)));
		}

		// Token: 0x060017DB RID: 6107 RVA: 0x00131984 File Offset: 0x0012FB84
		public void Add(IStaticDataSource dataSource, string entryName)
		{
			if (dataSource == null)
			{
				throw new ArgumentNullException("dataSource");
			}
			if (entryName == null)
			{
				throw new ArgumentNullException("entryName");
			}
			this.CheckUpdating();
			this.AddUpdate(new ZipFile.ZipUpdate(dataSource, this.EntryFactory.MakeFileEntry(entryName, false)));
		}

		// Token: 0x060017DC RID: 6108 RVA: 0x001319C4 File Offset: 0x0012FBC4
		public void Add(IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod)
		{
			if (dataSource == null)
			{
				throw new ArgumentNullException("dataSource");
			}
			if (entryName == null)
			{
				throw new ArgumentNullException("entryName");
			}
			this.CheckUpdating();
			ZipEntry zipEntry = this.EntryFactory.MakeFileEntry(entryName, false);
			zipEntry.CompressionMethod = compressionMethod;
			this.AddUpdate(new ZipFile.ZipUpdate(dataSource, zipEntry));
		}

		// Token: 0x060017DD RID: 6109 RVA: 0x00131A18 File Offset: 0x0012FC18
		public void Add(IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod, bool useUnicodeText)
		{
			if (dataSource == null)
			{
				throw new ArgumentNullException("dataSource");
			}
			if (entryName == null)
			{
				throw new ArgumentNullException("entryName");
			}
			this.CheckUpdating();
			ZipEntry zipEntry = this.EntryFactory.MakeFileEntry(entryName, false);
			zipEntry.IsUnicodeText = useUnicodeText;
			zipEntry.CompressionMethod = compressionMethod;
			this.AddUpdate(new ZipFile.ZipUpdate(dataSource, zipEntry));
		}

		// Token: 0x060017DE RID: 6110 RVA: 0x00131A71 File Offset: 0x0012FC71
		public void Add(ZipEntry entry)
		{
			if (entry == null)
			{
				throw new ArgumentNullException("entry");
			}
			this.CheckUpdating();
			if (entry.Size != 0L || entry.CompressedSize != 0L)
			{
				throw new ZipException("Entry cannot have any data");
			}
			this.AddUpdate(new ZipFile.ZipUpdate(ZipFile.UpdateCommand.Add, entry));
		}

		// Token: 0x060017DF RID: 6111 RVA: 0x00131AAF File Offset: 0x0012FCAF
		public void Add(IStaticDataSource dataSource, ZipEntry entry)
		{
			if (entry == null)
			{
				throw new ArgumentNullException("entry");
			}
			if (dataSource == null)
			{
				throw new ArgumentNullException("dataSource");
			}
			this.CheckUpdating();
			this.AddUpdate(new ZipFile.ZipUpdate(dataSource, entry));
		}

		// Token: 0x060017E0 RID: 6112 RVA: 0x00131AE0 File Offset: 0x0012FCE0
		public void AddDirectory(string directoryName)
		{
			if (directoryName == null)
			{
				throw new ArgumentNullException("directoryName");
			}
			this.CheckUpdating();
			ZipEntry zipEntry = this.EntryFactory.MakeDirectoryEntry(directoryName);
			this.AddUpdate(new ZipFile.ZipUpdate(ZipFile.UpdateCommand.Add, zipEntry));
		}

		// Token: 0x060017E1 RID: 6113 RVA: 0x00131B1C File Offset: 0x0012FD1C
		public bool Delete(string fileName)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			this.CheckUpdating();
			int num = this.FindExistingUpdate(fileName);
			if (num >= 0 && this.updates_[num] != null)
			{
				bool flag = true;
				this.contentsEdited_ = true;
				this.updates_[num] = null;
				this.updateCount_ -= 1L;
				return flag;
			}
			throw new ZipException("Cannot find entry to delete");
		}

		// Token: 0x060017E2 RID: 6114 RVA: 0x00131B8C File Offset: 0x0012FD8C
		public void Delete(ZipEntry entry)
		{
			if (entry == null)
			{
				throw new ArgumentNullException("entry");
			}
			this.CheckUpdating();
			int num = this.FindExistingUpdate(entry);
			if (num >= 0)
			{
				this.contentsEdited_ = true;
				this.updates_[num] = null;
				this.updateCount_ -= 1L;
				return;
			}
			throw new ZipException("Cannot find entry to delete");
		}

		// Token: 0x060017E3 RID: 6115 RVA: 0x00131BE7 File Offset: 0x0012FDE7
		private void WriteLEShort(int value)
		{
			this.baseStream_.WriteByte((byte)(value & 255));
			this.baseStream_.WriteByte((byte)((value >> 8) & 255));
		}

		// Token: 0x060017E4 RID: 6116 RVA: 0x00131C11 File Offset: 0x0012FE11
		private void WriteLEUshort(ushort value)
		{
			this.baseStream_.WriteByte((byte)(value & 255));
			this.baseStream_.WriteByte((byte)(value >> 8));
		}

		// Token: 0x060017E5 RID: 6117 RVA: 0x00131C35 File Offset: 0x0012FE35
		private void WriteLEInt(int value)
		{
			this.WriteLEShort(value & 65535);
			this.WriteLEShort(value >> 16);
		}

		// Token: 0x060017E6 RID: 6118 RVA: 0x00131C4E File Offset: 0x0012FE4E
		private void WriteLEUint(uint value)
		{
			this.WriteLEUshort((ushort)(value & 65535U));
			this.WriteLEUshort((ushort)(value >> 16));
		}

		// Token: 0x060017E7 RID: 6119 RVA: 0x00131C69 File Offset: 0x0012FE69
		private void WriteLeLong(long value)
		{
			this.WriteLEInt((int)(value & (long)((ulong)(-1))));
			this.WriteLEInt((int)(value >> 32));
		}

		// Token: 0x060017E8 RID: 6120 RVA: 0x00131C81 File Offset: 0x0012FE81
		private void WriteLEUlong(ulong value)
		{
			this.WriteLEUint((uint)(value & (ulong)(-1)));
			this.WriteLEUint((uint)(value >> 32));
		}

		// Token: 0x060017E9 RID: 6121 RVA: 0x00131C9C File Offset: 0x0012FE9C
		private void WriteLocalEntryHeader(ZipFile.ZipUpdate update)
		{
			ZipEntry outEntry = update.OutEntry;
			outEntry.Offset = this.baseStream_.Position;
			if (update.Command != ZipFile.UpdateCommand.Copy)
			{
				if (outEntry.CompressionMethod == CompressionMethod.Deflated)
				{
					if (outEntry.Size == 0L)
					{
						outEntry.CompressedSize = outEntry.Size;
						outEntry.Crc = 0L;
						outEntry.CompressionMethod = CompressionMethod.Stored;
					}
				}
				else if (outEntry.CompressionMethod == CompressionMethod.Stored)
				{
					outEntry.Flags &= -9;
				}
				if (this.HaveKeys)
				{
					outEntry.IsCrypted = true;
					if (outEntry.Crc < 0L)
					{
						outEntry.Flags |= 8;
					}
				}
				else
				{
					outEntry.IsCrypted = false;
				}
				switch (this.useZip64_)
				{
				case UseZip64.On:
					outEntry.ForceZip64();
					break;
				case UseZip64.Dynamic:
					if (outEntry.Size < 0L)
					{
						outEntry.ForceZip64();
					}
					break;
				}
			}
			this.WriteLEInt(67324752);
			this.WriteLEShort(outEntry.Version);
			this.WriteLEShort(outEntry.Flags);
			this.WriteLEShort((int)((byte)outEntry.CompressionMethod));
			this.WriteLEInt((int)outEntry.DosTime);
			if (!outEntry.HasCrc)
			{
				update.CrcPatchOffset = this.baseStream_.Position;
				this.WriteLEInt(0);
			}
			else
			{
				this.WriteLEInt((int)outEntry.Crc);
			}
			if (outEntry.LocalHeaderRequiresZip64)
			{
				this.WriteLEInt(-1);
				this.WriteLEInt(-1);
			}
			else
			{
				if (outEntry.CompressedSize < 0L || outEntry.Size < 0L)
				{
					update.SizePatchOffset = this.baseStream_.Position;
				}
				this.WriteLEInt((int)outEntry.CompressedSize);
				this.WriteLEInt((int)outEntry.Size);
			}
			byte[] array = ZipStrings.ConvertToArray(outEntry.Flags, outEntry.Name);
			if (array.Length > 65535)
			{
				throw new ZipException("Entry name too long.");
			}
			ZipExtraData zipExtraData = new ZipExtraData(outEntry.ExtraData);
			if (outEntry.LocalHeaderRequiresZip64)
			{
				zipExtraData.StartNewEntry();
				zipExtraData.AddLeLong(outEntry.Size);
				zipExtraData.AddLeLong(outEntry.CompressedSize);
				zipExtraData.AddNewEntry(1);
			}
			else
			{
				zipExtraData.Delete(1);
			}
			outEntry.ExtraData = zipExtraData.GetEntryData();
			this.WriteLEShort(array.Length);
			this.WriteLEShort(outEntry.ExtraData.Length);
			if (array.Length != 0)
			{
				this.baseStream_.Write(array, 0, array.Length);
			}
			if (outEntry.LocalHeaderRequiresZip64)
			{
				if (!zipExtraData.Find(1))
				{
					throw new ZipException("Internal error cannot find extra data");
				}
				update.SizePatchOffset = this.baseStream_.Position + (long)zipExtraData.CurrentReadIndex;
			}
			if (outEntry.ExtraData.Length != 0)
			{
				this.baseStream_.Write(outEntry.ExtraData, 0, outEntry.ExtraData.Length);
			}
		}

		// Token: 0x060017EA RID: 6122 RVA: 0x00131F30 File Offset: 0x00130130
		private int WriteCentralDirectoryHeader(ZipEntry entry)
		{
			if (entry.CompressedSize < 0L)
			{
				throw new ZipException("Attempt to write central directory entry with unknown csize");
			}
			if (entry.Size < 0L)
			{
				throw new ZipException("Attempt to write central directory entry with unknown size");
			}
			if (entry.Crc < 0L)
			{
				throw new ZipException("Attempt to write central directory entry with unknown crc");
			}
			this.WriteLEInt(33639248);
			this.WriteLEShort((entry.HostSystem << 8) | entry.VersionMadeBy);
			this.WriteLEShort(entry.Version);
			this.WriteLEShort(entry.Flags);
			this.WriteLEShort((int)((byte)entry.CompressionMethod));
			this.WriteLEInt((int)entry.DosTime);
			this.WriteLEInt((int)entry.Crc);
			bool flag = false;
			if (entry.IsZip64Forced() || entry.CompressedSize >= (long)((ulong)(-1)))
			{
				flag = true;
				this.WriteLEInt(-1);
			}
			else
			{
				this.WriteLEInt((int)(entry.CompressedSize & (long)((ulong)(-1))));
			}
			bool flag2 = false;
			if (entry.IsZip64Forced() || entry.Size >= (long)((ulong)(-1)))
			{
				flag2 = true;
				this.WriteLEInt(-1);
			}
			else
			{
				this.WriteLEInt((int)entry.Size);
			}
			byte[] array = ZipStrings.ConvertToArray(entry.Flags, entry.Name);
			if (array.Length > 65535)
			{
				throw new ZipException("Entry name is too long.");
			}
			this.WriteLEShort(array.Length);
			ZipExtraData zipExtraData = new ZipExtraData(entry.ExtraData);
			if (entry.CentralHeaderRequiresZip64)
			{
				zipExtraData.StartNewEntry();
				if (flag2)
				{
					zipExtraData.AddLeLong(entry.Size);
				}
				if (flag)
				{
					zipExtraData.AddLeLong(entry.CompressedSize);
				}
				if (entry.Offset >= (long)((ulong)(-1)))
				{
					zipExtraData.AddLeLong(entry.Offset);
				}
				zipExtraData.AddNewEntry(1);
			}
			else
			{
				zipExtraData.Delete(1);
			}
			byte[] entryData = zipExtraData.GetEntryData();
			this.WriteLEShort(entryData.Length);
			this.WriteLEShort((entry.Comment != null) ? entry.Comment.Length : 0);
			this.WriteLEShort(0);
			this.WriteLEShort(0);
			if (entry.ExternalFileAttributes != -1)
			{
				this.WriteLEInt(entry.ExternalFileAttributes);
			}
			else if (entry.IsDirectory)
			{
				this.WriteLEUint(16U);
			}
			else
			{
				this.WriteLEUint(0U);
			}
			if (entry.Offset >= (long)((ulong)(-1)))
			{
				this.WriteLEUint(uint.MaxValue);
			}
			else
			{
				this.WriteLEUint((uint)((int)entry.Offset));
			}
			if (array.Length != 0)
			{
				this.baseStream_.Write(array, 0, array.Length);
			}
			if (entryData.Length != 0)
			{
				this.baseStream_.Write(entryData, 0, entryData.Length);
			}
			byte[] array2 = ((entry.Comment != null) ? Encoding.ASCII.GetBytes(entry.Comment) : new byte[0]);
			if (array2.Length != 0)
			{
				this.baseStream_.Write(array2, 0, array2.Length);
			}
			return 46 + array.Length + entryData.Length + array2.Length;
		}

		// Token: 0x060017EB RID: 6123 RVA: 0x001321C5 File Offset: 0x001303C5
		private void PostUpdateCleanup()
		{
			this.updateDataSource_ = null;
			this.updates_ = null;
			this.updateIndex_ = null;
			if (this.archiveStorage_ != null)
			{
				this.archiveStorage_.Dispose();
				this.archiveStorage_ = null;
			}
		}

		// Token: 0x060017EC RID: 6124 RVA: 0x001321F8 File Offset: 0x001303F8
		private string GetTransformedFileName(string name)
		{
			INameTransform nameTransform = this.NameTransform;
			if (nameTransform == null)
			{
				return name;
			}
			return nameTransform.TransformFile(name);
		}

		// Token: 0x060017ED RID: 6125 RVA: 0x00132218 File Offset: 0x00130418
		private string GetTransformedDirectoryName(string name)
		{
			INameTransform nameTransform = this.NameTransform;
			if (nameTransform == null)
			{
				return name;
			}
			return nameTransform.TransformDirectory(name);
		}

		// Token: 0x060017EE RID: 6126 RVA: 0x00132238 File Offset: 0x00130438
		private byte[] GetBuffer()
		{
			if (this.copyBuffer_ == null)
			{
				this.copyBuffer_ = new byte[this.bufferSize_];
			}
			return this.copyBuffer_;
		}

		// Token: 0x060017EF RID: 6127 RVA: 0x0013225C File Offset: 0x0013045C
		private void CopyDescriptorBytes(ZipFile.ZipUpdate update, Stream dest, Stream source)
		{
			int i = this.GetDescriptorSize(update);
			if (i > 0)
			{
				byte[] buffer = this.GetBuffer();
				while (i > 0)
				{
					int num = Math.Min(buffer.Length, i);
					int num2 = source.Read(buffer, 0, num);
					if (num2 <= 0)
					{
						throw new ZipException("Unxpected end of stream");
					}
					dest.Write(buffer, 0, num2);
					i -= num2;
				}
			}
		}

		// Token: 0x060017F0 RID: 6128 RVA: 0x001322B4 File Offset: 0x001304B4
		private void CopyBytes(ZipFile.ZipUpdate update, Stream destination, Stream source, long bytesToCopy, bool updateCrc)
		{
			if (destination == source)
			{
				throw new InvalidOperationException("Destination and source are the same");
			}
			Crc32 crc = new Crc32();
			byte[] buffer = this.GetBuffer();
			long num = bytesToCopy;
			long num2 = 0L;
			int num4;
			do
			{
				int num3 = buffer.Length;
				if (bytesToCopy < (long)num3)
				{
					num3 = (int)bytesToCopy;
				}
				num4 = source.Read(buffer, 0, num3);
				if (num4 > 0)
				{
					if (updateCrc)
					{
						crc.Update(new ArraySegment<byte>(buffer, 0, num4));
					}
					destination.Write(buffer, 0, num4);
					bytesToCopy -= (long)num4;
					num2 += (long)num4;
				}
			}
			while (num4 > 0 && bytesToCopy > 0L);
			if (num2 != num)
			{
				throw new ZipException(string.Format("Failed to copy bytes expected {0} read {1}", num, num2));
			}
			if (updateCrc)
			{
				update.OutEntry.Crc = crc.Value;
			}
		}

		// Token: 0x060017F1 RID: 6129 RVA: 0x00132370 File Offset: 0x00130570
		private int GetDescriptorSize(ZipFile.ZipUpdate update)
		{
			int num = 0;
			if ((update.Entry.Flags & 8) != 0)
			{
				num = 12;
				if (update.Entry.LocalHeaderRequiresZip64)
				{
					num = 20;
				}
			}
			return num;
		}

		// Token: 0x060017F2 RID: 6130 RVA: 0x001323A4 File Offset: 0x001305A4
		private void CopyDescriptorBytesDirect(ZipFile.ZipUpdate update, Stream stream, ref long destinationPosition, long sourcePosition)
		{
			int i = this.GetDescriptorSize(update);
			while (i > 0)
			{
				int num = i;
				byte[] buffer = this.GetBuffer();
				stream.Position = sourcePosition;
				int num2 = stream.Read(buffer, 0, num);
				if (num2 <= 0)
				{
					throw new ZipException("Unxpected end of stream");
				}
				stream.Position = destinationPosition;
				stream.Write(buffer, 0, num2);
				i -= num2;
				destinationPosition += (long)num2;
				sourcePosition += (long)num2;
			}
		}

		// Token: 0x060017F3 RID: 6131 RVA: 0x00132410 File Offset: 0x00130610
		private void CopyEntryDataDirect(ZipFile.ZipUpdate update, Stream stream, bool updateCrc, ref long destinationPosition, ref long sourcePosition)
		{
			long num = update.Entry.CompressedSize;
			Crc32 crc = new Crc32();
			byte[] buffer = this.GetBuffer();
			long num2 = num;
			long num3 = 0L;
			int num5;
			do
			{
				int num4 = buffer.Length;
				if (num < (long)num4)
				{
					num4 = (int)num;
				}
				stream.Position = sourcePosition;
				num5 = stream.Read(buffer, 0, num4);
				if (num5 > 0)
				{
					if (updateCrc)
					{
						crc.Update(new ArraySegment<byte>(buffer, 0, num5));
					}
					stream.Position = destinationPosition;
					stream.Write(buffer, 0, num5);
					destinationPosition += (long)num5;
					sourcePosition += (long)num5;
					num -= (long)num5;
					num3 += (long)num5;
				}
			}
			while (num5 > 0 && num > 0L);
			if (num3 != num2)
			{
				throw new ZipException(string.Format("Failed to copy bytes expected {0} read {1}", num2, num3));
			}
			if (updateCrc)
			{
				update.OutEntry.Crc = crc.Value;
			}
		}

		// Token: 0x060017F4 RID: 6132 RVA: 0x001324EC File Offset: 0x001306EC
		private int FindExistingUpdate(ZipEntry entry)
		{
			int num = -1;
			string text = (entry.IsDirectory ? this.GetTransformedDirectoryName(entry.Name) : this.GetTransformedFileName(entry.Name));
			if (this.updateIndex_.ContainsKey(text))
			{
				num = this.updateIndex_[text];
			}
			return num;
		}

		// Token: 0x060017F5 RID: 6133 RVA: 0x0013253C File Offset: 0x0013073C
		private int FindExistingUpdate(string fileName)
		{
			int num = -1;
			string transformedFileName = this.GetTransformedFileName(fileName);
			if (this.updateIndex_.ContainsKey(transformedFileName))
			{
				num = this.updateIndex_[transformedFileName];
			}
			return num;
		}

		// Token: 0x060017F6 RID: 6134 RVA: 0x00132570 File Offset: 0x00130770
		private Stream GetOutputStream(ZipEntry entry)
		{
			Stream stream = this.baseStream_;
			if (entry.IsCrypted)
			{
				stream = this.CreateAndInitEncryptionStream(stream, entry);
			}
			CompressionMethod compressionMethod = entry.CompressionMethod;
			if (compressionMethod != CompressionMethod.Stored)
			{
				if (compressionMethod != CompressionMethod.Deflated)
				{
					throw new ZipException("Unknown compression method " + entry.CompressionMethod.ToString());
				}
				stream = new DeflaterOutputStream(stream, new Deflater(9, true))
				{
					IsStreamOwner = false
				};
			}
			else
			{
				stream = new ZipFile.UncompressedStream(stream);
			}
			return stream;
		}

		// Token: 0x060017F7 RID: 6135 RVA: 0x001325EC File Offset: 0x001307EC
		private void AddEntry(ZipFile workFile, ZipFile.ZipUpdate update)
		{
			Stream stream = null;
			if (update.Entry.IsFile)
			{
				stream = update.GetSource();
				if (stream == null)
				{
					stream = this.updateDataSource_.GetSource(update.Entry, update.Filename);
				}
			}
			if (stream != null)
			{
				using (stream)
				{
					long length = stream.Length;
					if (update.OutEntry.Size < 0L)
					{
						update.OutEntry.Size = length;
					}
					else if (update.OutEntry.Size != length)
					{
						throw new ZipException("Entry size/stream size mismatch");
					}
					workFile.WriteLocalEntryHeader(update);
					long position = workFile.baseStream_.Position;
					using (Stream outputStream = workFile.GetOutputStream(update.OutEntry))
					{
						this.CopyBytes(update, outputStream, stream, length, true);
					}
					long position2 = workFile.baseStream_.Position;
					update.OutEntry.CompressedSize = position2 - position;
					if ((update.OutEntry.Flags & 8) == 8)
					{
						new ZipHelperStream(workFile.baseStream_).WriteDataDescriptor(update.OutEntry);
					}
					return;
				}
			}
			workFile.WriteLocalEntryHeader(update);
			update.OutEntry.CompressedSize = 0L;
		}

		// Token: 0x060017F8 RID: 6136 RVA: 0x0013272C File Offset: 0x0013092C
		private void ModifyEntry(ZipFile workFile, ZipFile.ZipUpdate update)
		{
			workFile.WriteLocalEntryHeader(update);
			long position = workFile.baseStream_.Position;
			if (update.Entry.IsFile && update.Filename != null)
			{
				using (Stream outputStream = workFile.GetOutputStream(update.OutEntry))
				{
					using (Stream inputStream = this.GetInputStream(update.Entry))
					{
						this.CopyBytes(update, outputStream, inputStream, inputStream.Length, true);
					}
				}
			}
			long position2 = workFile.baseStream_.Position;
			update.Entry.CompressedSize = position2 - position;
		}

		// Token: 0x060017F9 RID: 6137 RVA: 0x001327D8 File Offset: 0x001309D8
		private void CopyEntryDirect(ZipFile workFile, ZipFile.ZipUpdate update, ref long destinationPosition)
		{
			bool flag = update.Entry.Offset == destinationPosition;
			if (!flag)
			{
				this.baseStream_.Position = destinationPosition;
				workFile.WriteLocalEntryHeader(update);
				destinationPosition = this.baseStream_.Position;
			}
			long num = 0L;
			long num2 = update.Entry.Offset + 26L;
			this.baseStream_.Seek(num2, SeekOrigin.Begin);
			uint num3 = (uint)this.ReadLEUshort();
			uint num4 = (uint)this.ReadLEUshort();
			num = this.baseStream_.Position + (long)((ulong)num3) + (long)((ulong)num4);
			if (!flag)
			{
				if (update.Entry.CompressedSize > 0L)
				{
					this.CopyEntryDataDirect(update, this.baseStream_, false, ref destinationPosition, ref num);
				}
				this.CopyDescriptorBytesDirect(update, this.baseStream_, ref destinationPosition, num);
				return;
			}
			if (update.OffsetBasedSize != -1L)
			{
				destinationPosition += update.OffsetBasedSize;
				return;
			}
			destinationPosition += num - num2 + 26L + update.Entry.CompressedSize + (long)this.GetDescriptorSize(update);
		}

		// Token: 0x060017FA RID: 6138 RVA: 0x001328C4 File Offset: 0x00130AC4
		private void CopyEntry(ZipFile workFile, ZipFile.ZipUpdate update)
		{
			workFile.WriteLocalEntryHeader(update);
			if (update.Entry.CompressedSize > 0L)
			{
				long num = update.Entry.Offset + 26L;
				this.baseStream_.Seek(num, SeekOrigin.Begin);
				uint num2 = (uint)this.ReadLEUshort();
				uint num3 = (uint)this.ReadLEUshort();
				this.baseStream_.Seek((long)((ulong)(num2 + num3)), SeekOrigin.Current);
				this.CopyBytes(update, workFile.baseStream_, this.baseStream_, update.Entry.CompressedSize, false);
			}
			this.CopyDescriptorBytes(update, workFile.baseStream_, this.baseStream_);
		}

		// Token: 0x060017FB RID: 6139 RVA: 0x00132956 File Offset: 0x00130B56
		private void Reopen(Stream source)
		{
			this.isNewArchive_ = false;
			if (source == null)
			{
				throw new ZipException("Failed to reopen archive - no source");
			}
			this.baseStream_ = source;
			this.ReadEntries();
		}

		// Token: 0x060017FC RID: 6140 RVA: 0x0013297B File Offset: 0x00130B7B
		private void Reopen()
		{
			if (this.Name == null)
			{
				throw new InvalidOperationException("Name is not known cannot Reopen");
			}
			this.Reopen(File.Open(this.Name, FileMode.Open, FileAccess.Read, FileShare.Read));
		}

		// Token: 0x060017FD RID: 6141 RVA: 0x001329A4 File Offset: 0x00130BA4
		private void UpdateCommentOnly()
		{
			long length = this.baseStream_.Length;
			ZipHelperStream zipHelperStream;
			if (this.archiveStorage_.UpdateMode == FileUpdateMode.Safe)
			{
				zipHelperStream = new ZipHelperStream(this.archiveStorage_.MakeTemporaryCopy(this.baseStream_))
				{
					IsStreamOwner = true
				};
				this.baseStream_.Dispose();
				this.baseStream_ = null;
			}
			else if (this.archiveStorage_.UpdateMode == FileUpdateMode.Direct)
			{
				this.baseStream_ = this.archiveStorage_.OpenForDirectUpdate(this.baseStream_);
				zipHelperStream = new ZipHelperStream(this.baseStream_);
			}
			else
			{
				this.baseStream_.Dispose();
				this.baseStream_ = null;
				zipHelperStream = new ZipHelperStream(this.Name);
			}
			using (zipHelperStream)
			{
				if (zipHelperStream.LocateBlockWithSignature(101010256, length, 22, 65535) < 0L)
				{
					throw new ZipException("Cannot find central directory");
				}
				zipHelperStream.Position += 16L;
				byte[] rawComment = this.newComment_.RawComment;
				zipHelperStream.WriteLEShort(rawComment.Length);
				zipHelperStream.Write(rawComment, 0, rawComment.Length);
				zipHelperStream.SetLength(zipHelperStream.Position);
			}
			if (this.archiveStorage_.UpdateMode == FileUpdateMode.Safe)
			{
				this.Reopen(this.archiveStorage_.ConvertTemporaryToFinal());
				return;
			}
			this.ReadEntries();
		}

		// Token: 0x060017FE RID: 6142 RVA: 0x00132AF0 File Offset: 0x00130CF0
		private void RunUpdates()
		{
			long num = 0L;
			long num2 = 0L;
			bool flag = false;
			long num3 = 0L;
			ZipFile zipFile;
			if (this.IsNewArchive)
			{
				zipFile = this;
				zipFile.baseStream_.Position = 0L;
				flag = true;
			}
			else if (this.archiveStorage_.UpdateMode == FileUpdateMode.Direct)
			{
				zipFile = this;
				zipFile.baseStream_.Position = 0L;
				flag = true;
				this.updates_.Sort(new ZipFile.UpdateComparer());
			}
			else
			{
				zipFile = ZipFile.Create(this.archiveStorage_.GetTemporaryOutput());
				zipFile.UseZip64 = this.UseZip64;
				if (this.key != null)
				{
					zipFile.key = (byte[])this.key.Clone();
				}
			}
			try
			{
				foreach (ZipFile.ZipUpdate zipUpdate in this.updates_)
				{
					if (zipUpdate != null)
					{
						switch (zipUpdate.Command)
						{
						case ZipFile.UpdateCommand.Copy:
							if (flag)
							{
								this.CopyEntryDirect(zipFile, zipUpdate, ref num3);
							}
							else
							{
								this.CopyEntry(zipFile, zipUpdate);
							}
							break;
						case ZipFile.UpdateCommand.Modify:
							this.ModifyEntry(zipFile, zipUpdate);
							break;
						case ZipFile.UpdateCommand.Add:
							if (!this.IsNewArchive && flag)
							{
								zipFile.baseStream_.Position = num3;
							}
							this.AddEntry(zipFile, zipUpdate);
							if (flag)
							{
								num3 = zipFile.baseStream_.Position;
							}
							break;
						}
					}
				}
				if (!this.IsNewArchive && flag)
				{
					zipFile.baseStream_.Position = num3;
				}
				long position = zipFile.baseStream_.Position;
				foreach (ZipFile.ZipUpdate zipUpdate2 in this.updates_)
				{
					if (zipUpdate2 != null)
					{
						num += (long)zipFile.WriteCentralDirectoryHeader(zipUpdate2.OutEntry);
					}
				}
				byte[] array = ((this.newComment_ != null) ? this.newComment_.RawComment : ZipStrings.ConvertToArray(this.comment_));
				using (ZipHelperStream zipHelperStream = new ZipHelperStream(zipFile.baseStream_))
				{
					zipHelperStream.WriteEndOfCentralDirectory(this.updateCount_, num, position, array);
				}
				num2 = zipFile.baseStream_.Position;
				foreach (ZipFile.ZipUpdate zipUpdate3 in this.updates_)
				{
					if (zipUpdate3 != null)
					{
						if (zipUpdate3.CrcPatchOffset > 0L && zipUpdate3.OutEntry.CompressedSize > 0L)
						{
							zipFile.baseStream_.Position = zipUpdate3.CrcPatchOffset;
							zipFile.WriteLEInt((int)zipUpdate3.OutEntry.Crc);
						}
						if (zipUpdate3.SizePatchOffset > 0L)
						{
							zipFile.baseStream_.Position = zipUpdate3.SizePatchOffset;
							if (zipUpdate3.OutEntry.LocalHeaderRequiresZip64)
							{
								zipFile.WriteLeLong(zipUpdate3.OutEntry.Size);
								zipFile.WriteLeLong(zipUpdate3.OutEntry.CompressedSize);
							}
							else
							{
								zipFile.WriteLEInt((int)zipUpdate3.OutEntry.CompressedSize);
								zipFile.WriteLEInt((int)zipUpdate3.OutEntry.Size);
							}
						}
					}
				}
			}
			catch
			{
				zipFile.Close();
				if (!flag && zipFile.Name != null)
				{
					File.Delete(zipFile.Name);
				}
				throw;
			}
			if (flag)
			{
				zipFile.baseStream_.SetLength(num2);
				zipFile.baseStream_.Flush();
				this.isNewArchive_ = false;
				this.ReadEntries();
				return;
			}
			this.baseStream_.Dispose();
			this.Reopen(this.archiveStorage_.ConvertTemporaryToFinal());
		}

		// Token: 0x060017FF RID: 6143 RVA: 0x00132EFC File Offset: 0x001310FC
		private void CheckUpdating()
		{
			if (this.updates_ == null)
			{
				throw new InvalidOperationException("BeginUpdate has not been called");
			}
		}

		// Token: 0x06001800 RID: 6144 RVA: 0x00132F11 File Offset: 0x00131111
		void IDisposable.Dispose()
		{
			this.Close();
		}

		// Token: 0x06001801 RID: 6145 RVA: 0x00132F1C File Offset: 0x0013111C
		private void DisposeInternal(bool disposing)
		{
			if (!this.isDisposed_)
			{
				this.isDisposed_ = true;
				this.entries_ = new ZipEntry[0];
				if (this.IsStreamOwner && this.baseStream_ != null)
				{
					Stream stream = this.baseStream_;
					lock (stream)
					{
						this.baseStream_.Dispose();
					}
				}
				this.PostUpdateCleanup();
			}
		}

		// Token: 0x06001802 RID: 6146 RVA: 0x00132F94 File Offset: 0x00131194
		protected virtual void Dispose(bool disposing)
		{
			this.DisposeInternal(disposing);
		}

		// Token: 0x06001803 RID: 6147 RVA: 0x00132FA0 File Offset: 0x001311A0
		private ushort ReadLEUshort()
		{
			int num = this.baseStream_.ReadByte();
			if (num < 0)
			{
				throw new EndOfStreamException("End of stream");
			}
			int num2 = this.baseStream_.ReadByte();
			if (num2 < 0)
			{
				throw new EndOfStreamException("End of stream");
			}
			return (ushort)num | (ushort)(num2 << 8);
		}

		// Token: 0x06001804 RID: 6148 RVA: 0x00132FE9 File Offset: 0x001311E9
		private uint ReadLEUint()
		{
			return (uint)((int)this.ReadLEUshort() | ((int)this.ReadLEUshort() << 16));
		}

		// Token: 0x06001805 RID: 6149 RVA: 0x00132FFB File Offset: 0x001311FB
		private ulong ReadLEUlong()
		{
			return (ulong)this.ReadLEUint() | ((ulong)this.ReadLEUint() << 32);
		}

		// Token: 0x06001806 RID: 6150 RVA: 0x00133010 File Offset: 0x00131210
		private long LocateBlockWithSignature(int signature, long endLocation, int minimumBlockSize, int maximumVariableData)
		{
			long num;
			using (ZipHelperStream zipHelperStream = new ZipHelperStream(this.baseStream_))
			{
				num = zipHelperStream.LocateBlockWithSignature(signature, endLocation, minimumBlockSize, maximumVariableData);
			}
			return num;
		}

		// Token: 0x06001807 RID: 6151 RVA: 0x00133054 File Offset: 0x00131254
		private void ReadEntries()
		{
			if (!this.baseStream_.CanSeek)
			{
				throw new ZipException("ZipFile stream must be seekable");
			}
			long num = this.LocateBlockWithSignature(101010256, this.baseStream_.Length, 22, 65535);
			if (num < 0L)
			{
				throw new ZipException("Cannot find central directory");
			}
			int num2 = (int)this.ReadLEUshort();
			ushort num3 = this.ReadLEUshort();
			ulong num4 = (ulong)this.ReadLEUshort();
			ulong num5 = (ulong)this.ReadLEUshort();
			ulong num6 = (ulong)this.ReadLEUint();
			long num7 = (long)((ulong)this.ReadLEUint());
			uint num8 = (uint)this.ReadLEUshort();
			if (num8 > 0U)
			{
				byte[] array = new byte[num8];
				StreamUtils.ReadFully(this.baseStream_, array);
				this.comment_ = ZipStrings.ConvertToString(array);
			}
			else
			{
				this.comment_ = string.Empty;
			}
			bool flag = false;
			bool flag2 = false;
			if (num2 == 65535 || num3 == 65535 || num4 == 65535UL || num5 == 65535UL || num6 == (ulong)(-1) || num7 == (long)((ulong)(-1)))
			{
				flag2 = true;
			}
			if (this.LocateBlockWithSignature(117853008, num - 4L, 20, 0) < 0L)
			{
				if (flag2)
				{
					throw new ZipException("Cannot find Zip64 locator");
				}
			}
			else
			{
				flag = true;
				this.ReadLEUint();
				ulong num9 = this.ReadLEUlong();
				this.ReadLEUint();
				this.baseStream_.Position = (long)num9;
				if ((ulong)this.ReadLEUint() != 101075792UL)
				{
					throw new ZipException(string.Format("Invalid Zip64 Central directory signature at {0:X}", num9));
				}
				this.ReadLEUlong();
				this.ReadLEUshort();
				this.ReadLEUshort();
				this.ReadLEUint();
				this.ReadLEUint();
				num4 = this.ReadLEUlong();
				num5 = this.ReadLEUlong();
				num6 = this.ReadLEUlong();
				num7 = (long)this.ReadLEUlong();
			}
			this.entries_ = new ZipEntry[num4];
			if (!flag && num7 < num - (long)(4UL + num6))
			{
				this.offsetOfFirstEntry = num - (long)(4UL + num6 + (ulong)num7);
				if (this.offsetOfFirstEntry <= 0L)
				{
					throw new ZipException("Invalid embedded zip archive");
				}
			}
			this.baseStream_.Seek(this.offsetOfFirstEntry + num7, SeekOrigin.Begin);
			for (ulong num10 = 0UL; num10 < num4; num10 += 1UL)
			{
				if (this.ReadLEUint() != 33639248U)
				{
					throw new ZipException("Wrong Central Directory signature");
				}
				int num11 = (int)this.ReadLEUshort();
				int num12 = (int)this.ReadLEUshort();
				int num13 = (int)this.ReadLEUshort();
				int num14 = (int)this.ReadLEUshort();
				uint num15 = this.ReadLEUint();
				uint num16 = this.ReadLEUint();
				long num17 = (long)((ulong)this.ReadLEUint());
				long num18 = (long)((ulong)this.ReadLEUint());
				int num19 = (int)this.ReadLEUshort();
				int num20 = (int)this.ReadLEUshort();
				int num21 = (int)this.ReadLEUshort();
				this.ReadLEUshort();
				this.ReadLEUshort();
				uint num22 = this.ReadLEUint();
				long num23 = (long)((ulong)this.ReadLEUint());
				byte[] array2 = new byte[Math.Max(num19, num21)];
				StreamUtils.ReadFully(this.baseStream_, array2, 0, num19);
				ZipEntry zipEntry = new ZipEntry(ZipStrings.ConvertToStringExt(num13, array2, num19), num12, num11, (CompressionMethod)num14)
				{
					Crc = (long)((ulong)num16 & (ulong)(-1)),
					Size = (num18 & (long)((ulong)(-1))),
					CompressedSize = (num17 & (long)((ulong)(-1))),
					Flags = num13,
					DosTime = (long)((ulong)num15),
					ZipFileIndex = (long)num10,
					Offset = num23,
					ExternalFileAttributes = (int)num22
				};
				if ((num13 & 8) == 0)
				{
					zipEntry.CryptoCheckValue = (byte)(num16 >> 24);
				}
				else
				{
					zipEntry.CryptoCheckValue = (byte)((num15 >> 8) & 255U);
				}
				if (num20 > 0)
				{
					byte[] array3 = new byte[num20];
					StreamUtils.ReadFully(this.baseStream_, array3);
					zipEntry.ExtraData = array3;
				}
				zipEntry.ProcessExtraData(false);
				if (num21 > 0)
				{
					StreamUtils.ReadFully(this.baseStream_, array2, 0, num21);
					zipEntry.Comment = ZipStrings.ConvertToStringExt(num13, array2, num21);
				}
				this.entries_[(int)(checked((IntPtr)num10))] = zipEntry;
			}
		}

		// Token: 0x06001808 RID: 6152 RVA: 0x00133407 File Offset: 0x00131607
		private long LocateEntry(ZipEntry entry)
		{
			return this.TestLocalHeader(entry, ZipFile.HeaderTest.Extract);
		}

		// Token: 0x06001809 RID: 6153 RVA: 0x00133414 File Offset: 0x00131614
		private Stream CreateAndInitDecryptionStream(Stream baseStream, ZipEntry entry)
		{
			CryptoStream cryptoStream;
			if (entry.CompressionMethodForHeader == CompressionMethod.WinZipAES)
			{
				if (entry.Version < 51)
				{
					throw new ZipException("Decryption method not supported");
				}
				this.OnKeysRequired(entry.Name);
				if (!this.HaveKeys)
				{
					throw new ZipException("No password available for AES encrypted stream");
				}
				int aessaltLen = entry.AESSaltLen;
				byte[] array = new byte[aessaltLen];
				int num = StreamUtils.ReadRequestedBytes(baseStream, array, 0, aessaltLen);
				if (num != aessaltLen)
				{
					throw new ZipException("AES Salt expected " + aessaltLen.ToString() + " got " + num.ToString());
				}
				byte[] array2 = new byte[2];
				StreamUtils.ReadFully(baseStream, array2);
				int num2 = entry.AESKeySize / 8;
				ZipAESTransform zipAESTransform = new ZipAESTransform(this.rawPassword_, array, num2, false);
				byte[] pwdVerifier = zipAESTransform.PwdVerifier;
				if (pwdVerifier[0] != array2[0] || pwdVerifier[1] != array2[1])
				{
					throw new ZipException("Invalid password for AES");
				}
				cryptoStream = new ZipAESStream(baseStream, zipAESTransform, CryptoStreamMode.Read);
			}
			else
			{
				if (entry.Version >= 50 && (entry.Flags & 64) != 0)
				{
					throw new ZipException("Decryption method not supported");
				}
				PkzipClassicManaged pkzipClassicManaged = new PkzipClassicManaged();
				this.OnKeysRequired(entry.Name);
				if (!this.HaveKeys)
				{
					throw new ZipException("No password available for encrypted stream");
				}
				cryptoStream = new CryptoStream(baseStream, pkzipClassicManaged.CreateDecryptor(this.key, null), CryptoStreamMode.Read);
				ZipFile.CheckClassicPassword(cryptoStream, entry);
			}
			return cryptoStream;
		}

		// Token: 0x0600180A RID: 6154 RVA: 0x0013356C File Offset: 0x0013176C
		private Stream CreateAndInitEncryptionStream(Stream baseStream, ZipEntry entry)
		{
			CryptoStream cryptoStream = null;
			if (entry.Version < 50 || (entry.Flags & 64) == 0)
			{
				PkzipClassicManaged pkzipClassicManaged = new PkzipClassicManaged();
				this.OnKeysRequired(entry.Name);
				if (!this.HaveKeys)
				{
					throw new ZipException("No password available for encrypted stream");
				}
				cryptoStream = new CryptoStream(new ZipFile.UncompressedStream(baseStream), pkzipClassicManaged.CreateEncryptor(this.key, null), CryptoStreamMode.Write);
				if (entry.Crc < 0L || (entry.Flags & 8) != 0)
				{
					ZipFile.WriteEncryptionHeader(cryptoStream, entry.DosTime << 16);
				}
				else
				{
					ZipFile.WriteEncryptionHeader(cryptoStream, entry.Crc);
				}
			}
			return cryptoStream;
		}

		// Token: 0x0600180B RID: 6155 RVA: 0x00133604 File Offset: 0x00131804
		private static void CheckClassicPassword(CryptoStream classicCryptoStream, ZipEntry entry)
		{
			byte[] array = new byte[12];
			StreamUtils.ReadFully(classicCryptoStream, array);
			if (array[11] != entry.CryptoCheckValue)
			{
				throw new ZipException("Invalid password");
			}
		}

		// Token: 0x0600180C RID: 6156 RVA: 0x00133638 File Offset: 0x00131838
		private static void WriteEncryptionHeader(Stream stream, long crcValue)
		{
			byte[] array = new byte[12];
			new Random().NextBytes(array);
			array[11] = (byte)(crcValue >> 24);
			stream.Write(array, 0, array.Length);
		}

		// Token: 0x04000DB3 RID: 3507
		public ZipFile.KeysRequiredEventHandler KeysRequired;

		// Token: 0x04000DB4 RID: 3508
		private const int DefaultBufferSize = 4096;

		// Token: 0x04000DB5 RID: 3509
		private bool isDisposed_;

		// Token: 0x04000DB6 RID: 3510
		private string name_;

		// Token: 0x04000DB7 RID: 3511
		private string comment_;

		// Token: 0x04000DB8 RID: 3512
		private string rawPassword_;

		// Token: 0x04000DB9 RID: 3513
		private Stream baseStream_;

		// Token: 0x04000DBA RID: 3514
		private bool isStreamOwner;

		// Token: 0x04000DBB RID: 3515
		private long offsetOfFirstEntry;

		// Token: 0x04000DBC RID: 3516
		private ZipEntry[] entries_;

		// Token: 0x04000DBD RID: 3517
		private byte[] key;

		// Token: 0x04000DBE RID: 3518
		private bool isNewArchive_;

		// Token: 0x04000DBF RID: 3519
		private UseZip64 useZip64_ = UseZip64.Dynamic;

		// Token: 0x04000DC0 RID: 3520
		private List<ZipFile.ZipUpdate> updates_;

		// Token: 0x04000DC1 RID: 3521
		private long updateCount_;

		// Token: 0x04000DC2 RID: 3522
		private Dictionary<string, int> updateIndex_;

		// Token: 0x04000DC3 RID: 3523
		private IArchiveStorage archiveStorage_;

		// Token: 0x04000DC4 RID: 3524
		private IDynamicDataSource updateDataSource_;

		// Token: 0x04000DC5 RID: 3525
		private bool contentsEdited_;

		// Token: 0x04000DC6 RID: 3526
		private int bufferSize_ = 4096;

		// Token: 0x04000DC7 RID: 3527
		private byte[] copyBuffer_;

		// Token: 0x04000DC8 RID: 3528
		private ZipFile.ZipString newComment_;

		// Token: 0x04000DC9 RID: 3529
		private bool commentEdited_;

		// Token: 0x04000DCA RID: 3530
		private IEntryFactory updateEntryFactory_ = new ZipEntryFactory();

		// Token: 0x0200024C RID: 588
		// (Invoke) Token: 0x06001DB3 RID: 7603
		public delegate void KeysRequiredEventHandler(object sender, KeysRequiredEventArgs e);

		// Token: 0x0200024D RID: 589
		[Flags]
		private enum HeaderTest
		{
			// Token: 0x04001532 RID: 5426
			Extract = 1,
			// Token: 0x04001533 RID: 5427
			Header = 2
		}

		// Token: 0x0200024E RID: 590
		private enum UpdateCommand
		{
			// Token: 0x04001535 RID: 5429
			Copy,
			// Token: 0x04001536 RID: 5430
			Modify,
			// Token: 0x04001537 RID: 5431
			Add
		}

		// Token: 0x0200024F RID: 591
		private class UpdateComparer : IComparer<ZipFile.ZipUpdate>
		{
			// Token: 0x06001DB6 RID: 7606 RVA: 0x00147868 File Offset: 0x00145A68
			public int Compare(ZipFile.ZipUpdate x, ZipFile.ZipUpdate y)
			{
				int num;
				if (x == null)
				{
					if (y == null)
					{
						num = 0;
					}
					else
					{
						num = -1;
					}
				}
				else if (y == null)
				{
					num = 1;
				}
				else
				{
					int num2 = ((x.Command == ZipFile.UpdateCommand.Copy || x.Command == ZipFile.UpdateCommand.Modify) ? 0 : 1);
					int num3 = ((y.Command == ZipFile.UpdateCommand.Copy || y.Command == ZipFile.UpdateCommand.Modify) ? 0 : 1);
					num = num2 - num3;
					if (num == 0)
					{
						long num4 = x.Entry.Offset - y.Entry.Offset;
						if (num4 < 0L)
						{
							num = -1;
						}
						else if (num4 == 0L)
						{
							num = 0;
						}
						else
						{
							num = 1;
						}
					}
				}
				return num;
			}
		}

		// Token: 0x02000250 RID: 592
		private class ZipUpdate
		{
			// Token: 0x06001DB8 RID: 7608 RVA: 0x001478EE File Offset: 0x00145AEE
			public ZipUpdate(string fileName, ZipEntry entry)
			{
				this.command_ = ZipFile.UpdateCommand.Add;
				this.entry_ = entry;
				this.filename_ = fileName;
			}

			// Token: 0x06001DB9 RID: 7609 RVA: 0x00147924 File Offset: 0x00145B24
			[Obsolete]
			public ZipUpdate(string fileName, string entryName, CompressionMethod compressionMethod)
			{
				this.command_ = ZipFile.UpdateCommand.Add;
				this.entry_ = new ZipEntry(entryName)
				{
					CompressionMethod = compressionMethod
				};
				this.filename_ = fileName;
			}

			// Token: 0x06001DBA RID: 7610 RVA: 0x00147970 File Offset: 0x00145B70
			[Obsolete]
			public ZipUpdate(string fileName, string entryName)
				: this(fileName, entryName, CompressionMethod.Deflated)
			{
			}

			// Token: 0x06001DBB RID: 7611 RVA: 0x0014797C File Offset: 0x00145B7C
			[Obsolete]
			public ZipUpdate(IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod)
			{
				this.command_ = ZipFile.UpdateCommand.Add;
				this.entry_ = new ZipEntry(entryName)
				{
					CompressionMethod = compressionMethod
				};
				this.dataSource_ = dataSource;
			}

			// Token: 0x06001DBC RID: 7612 RVA: 0x001479C8 File Offset: 0x00145BC8
			public ZipUpdate(IStaticDataSource dataSource, ZipEntry entry)
			{
				this.command_ = ZipFile.UpdateCommand.Add;
				this.entry_ = entry;
				this.dataSource_ = dataSource;
			}

			// Token: 0x06001DBD RID: 7613 RVA: 0x001479FD File Offset: 0x00145BFD
			public ZipUpdate(ZipEntry original, ZipEntry updated)
			{
				throw new ZipException("Modify not currently supported");
			}

			// Token: 0x06001DBE RID: 7614 RVA: 0x00147A27 File Offset: 0x00145C27
			public ZipUpdate(ZipFile.UpdateCommand command, ZipEntry entry)
			{
				this.command_ = command;
				this.entry_ = (ZipEntry)entry.Clone();
			}

			// Token: 0x06001DBF RID: 7615 RVA: 0x00147A5F File Offset: 0x00145C5F
			public ZipUpdate(ZipEntry entry)
				: this(ZipFile.UpdateCommand.Copy, entry)
			{
			}

			// Token: 0x17000248 RID: 584
			// (get) Token: 0x06001DC0 RID: 7616 RVA: 0x00147A69 File Offset: 0x00145C69
			public ZipEntry Entry
			{
				get
				{
					return this.entry_;
				}
			}

			// Token: 0x17000249 RID: 585
			// (get) Token: 0x06001DC1 RID: 7617 RVA: 0x00147A71 File Offset: 0x00145C71
			public ZipEntry OutEntry
			{
				get
				{
					if (this.outEntry_ == null)
					{
						this.outEntry_ = (ZipEntry)this.entry_.Clone();
					}
					return this.outEntry_;
				}
			}

			// Token: 0x1700024A RID: 586
			// (get) Token: 0x06001DC2 RID: 7618 RVA: 0x00147A97 File Offset: 0x00145C97
			public ZipFile.UpdateCommand Command
			{
				get
				{
					return this.command_;
				}
			}

			// Token: 0x1700024B RID: 587
			// (get) Token: 0x06001DC3 RID: 7619 RVA: 0x00147A9F File Offset: 0x00145C9F
			public string Filename
			{
				get
				{
					return this.filename_;
				}
			}

			// Token: 0x1700024C RID: 588
			// (get) Token: 0x06001DC4 RID: 7620 RVA: 0x00147AA7 File Offset: 0x00145CA7
			// (set) Token: 0x06001DC5 RID: 7621 RVA: 0x00147AAF File Offset: 0x00145CAF
			public long SizePatchOffset
			{
				get
				{
					return this.sizePatchOffset_;
				}
				set
				{
					this.sizePatchOffset_ = value;
				}
			}

			// Token: 0x1700024D RID: 589
			// (get) Token: 0x06001DC6 RID: 7622 RVA: 0x00147AB8 File Offset: 0x00145CB8
			// (set) Token: 0x06001DC7 RID: 7623 RVA: 0x00147AC0 File Offset: 0x00145CC0
			public long CrcPatchOffset
			{
				get
				{
					return this.crcPatchOffset_;
				}
				set
				{
					this.crcPatchOffset_ = value;
				}
			}

			// Token: 0x1700024E RID: 590
			// (get) Token: 0x06001DC8 RID: 7624 RVA: 0x00147AC9 File Offset: 0x00145CC9
			// (set) Token: 0x06001DC9 RID: 7625 RVA: 0x00147AD1 File Offset: 0x00145CD1
			public long OffsetBasedSize
			{
				get
				{
					return this._offsetBasedSize;
				}
				set
				{
					this._offsetBasedSize = value;
				}
			}

			// Token: 0x06001DCA RID: 7626 RVA: 0x00147ADC File Offset: 0x00145CDC
			public Stream GetSource()
			{
				Stream stream = null;
				if (this.dataSource_ != null)
				{
					stream = this.dataSource_.GetSource();
				}
				return stream;
			}

			// Token: 0x04001538 RID: 5432
			private ZipEntry entry_;

			// Token: 0x04001539 RID: 5433
			private ZipEntry outEntry_;

			// Token: 0x0400153A RID: 5434
			private readonly ZipFile.UpdateCommand command_;

			// Token: 0x0400153B RID: 5435
			private IStaticDataSource dataSource_;

			// Token: 0x0400153C RID: 5436
			private readonly string filename_;

			// Token: 0x0400153D RID: 5437
			private long sizePatchOffset_ = -1L;

			// Token: 0x0400153E RID: 5438
			private long crcPatchOffset_ = -1L;

			// Token: 0x0400153F RID: 5439
			private long _offsetBasedSize = -1L;
		}

		// Token: 0x02000251 RID: 593
		private class ZipString
		{
			// Token: 0x06001DCB RID: 7627 RVA: 0x00147B00 File Offset: 0x00145D00
			public ZipString(string comment)
			{
				this.comment_ = comment;
				this.isSourceString_ = true;
			}

			// Token: 0x06001DCC RID: 7628 RVA: 0x00147B16 File Offset: 0x00145D16
			public ZipString(byte[] rawString)
			{
				this.rawComment_ = rawString;
			}

			// Token: 0x1700024F RID: 591
			// (get) Token: 0x06001DCD RID: 7629 RVA: 0x00147B25 File Offset: 0x00145D25
			public bool IsSourceString
			{
				get
				{
					return this.isSourceString_;
				}
			}

			// Token: 0x17000250 RID: 592
			// (get) Token: 0x06001DCE RID: 7630 RVA: 0x00147B2D File Offset: 0x00145D2D
			public int RawLength
			{
				get
				{
					this.MakeBytesAvailable();
					return this.rawComment_.Length;
				}
			}

			// Token: 0x17000251 RID: 593
			// (get) Token: 0x06001DCF RID: 7631 RVA: 0x00147B3D File Offset: 0x00145D3D
			public byte[] RawComment
			{
				get
				{
					this.MakeBytesAvailable();
					return (byte[])this.rawComment_.Clone();
				}
			}

			// Token: 0x06001DD0 RID: 7632 RVA: 0x00147B55 File Offset: 0x00145D55
			public void Reset()
			{
				if (this.isSourceString_)
				{
					this.rawComment_ = null;
					return;
				}
				this.comment_ = null;
			}

			// Token: 0x06001DD1 RID: 7633 RVA: 0x00147B6E File Offset: 0x00145D6E
			private void MakeTextAvailable()
			{
				if (this.comment_ == null)
				{
					this.comment_ = ZipStrings.ConvertToString(this.rawComment_);
				}
			}

			// Token: 0x06001DD2 RID: 7634 RVA: 0x00147B89 File Offset: 0x00145D89
			private void MakeBytesAvailable()
			{
				if (this.rawComment_ == null)
				{
					this.rawComment_ = ZipStrings.ConvertToArray(this.comment_);
				}
			}

			// Token: 0x06001DD3 RID: 7635 RVA: 0x00147BA4 File Offset: 0x00145DA4
			public static implicit operator string(ZipFile.ZipString zipString)
			{
				zipString.MakeTextAvailable();
				return zipString.comment_;
			}

			// Token: 0x04001540 RID: 5440
			private string comment_;

			// Token: 0x04001541 RID: 5441
			private byte[] rawComment_;

			// Token: 0x04001542 RID: 5442
			private readonly bool isSourceString_;
		}

		// Token: 0x02000252 RID: 594
		private class ZipEntryEnumerator : IEnumerator
		{
			// Token: 0x06001DD4 RID: 7636 RVA: 0x00147BB2 File Offset: 0x00145DB2
			public ZipEntryEnumerator(ZipEntry[] entries)
			{
				this.array = entries;
			}

			// Token: 0x17000252 RID: 594
			// (get) Token: 0x06001DD5 RID: 7637 RVA: 0x00147BC8 File Offset: 0x00145DC8
			public object Current
			{
				get
				{
					return this.array[this.index];
				}
			}

			// Token: 0x06001DD6 RID: 7638 RVA: 0x00147BD7 File Offset: 0x00145DD7
			public void Reset()
			{
				this.index = -1;
			}

			// Token: 0x06001DD7 RID: 7639 RVA: 0x00147BE0 File Offset: 0x00145DE0
			public bool MoveNext()
			{
				int num = this.index + 1;
				this.index = num;
				return num < this.array.Length;
			}

			// Token: 0x04001543 RID: 5443
			private ZipEntry[] array;

			// Token: 0x04001544 RID: 5444
			private int index = -1;
		}

		// Token: 0x02000253 RID: 595
		private class UncompressedStream : Stream
		{
			// Token: 0x06001DD8 RID: 7640 RVA: 0x00147C08 File Offset: 0x00145E08
			public UncompressedStream(Stream baseStream)
			{
				this.baseStream_ = baseStream;
			}

			// Token: 0x17000253 RID: 595
			// (get) Token: 0x06001DD9 RID: 7641 RVA: 0x00147C17 File Offset: 0x00145E17
			public override bool CanRead
			{
				get
				{
					return false;
				}
			}

			// Token: 0x06001DDA RID: 7642 RVA: 0x00147C1A File Offset: 0x00145E1A
			public override void Flush()
			{
				this.baseStream_.Flush();
			}

			// Token: 0x17000254 RID: 596
			// (get) Token: 0x06001DDB RID: 7643 RVA: 0x00147C27 File Offset: 0x00145E27
			public override bool CanWrite
			{
				get
				{
					return this.baseStream_.CanWrite;
				}
			}

			// Token: 0x17000255 RID: 597
			// (get) Token: 0x06001DDC RID: 7644 RVA: 0x00147C34 File Offset: 0x00145E34
			public override bool CanSeek
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000256 RID: 598
			// (get) Token: 0x06001DDD RID: 7645 RVA: 0x00147C37 File Offset: 0x00145E37
			public override long Length
			{
				get
				{
					return 0L;
				}
			}

			// Token: 0x17000257 RID: 599
			// (get) Token: 0x06001DDE RID: 7646 RVA: 0x00147C3B File Offset: 0x00145E3B
			// (set) Token: 0x06001DDF RID: 7647 RVA: 0x00147C48 File Offset: 0x00145E48
			public override long Position
			{
				get
				{
					return this.baseStream_.Position;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x06001DE0 RID: 7648 RVA: 0x00147C4F File Offset: 0x00145E4F
			public override int Read(byte[] buffer, int offset, int count)
			{
				return 0;
			}

			// Token: 0x06001DE1 RID: 7649 RVA: 0x00147C52 File Offset: 0x00145E52
			public override long Seek(long offset, SeekOrigin origin)
			{
				return 0L;
			}

			// Token: 0x06001DE2 RID: 7650 RVA: 0x00147C56 File Offset: 0x00145E56
			public override void SetLength(long value)
			{
			}

			// Token: 0x06001DE3 RID: 7651 RVA: 0x00147C58 File Offset: 0x00145E58
			public override void Write(byte[] buffer, int offset, int count)
			{
				this.baseStream_.Write(buffer, offset, count);
			}

			// Token: 0x04001545 RID: 5445
			private readonly Stream baseStream_;
		}

		// Token: 0x02000254 RID: 596
		private class PartialInputStream : Stream
		{
			// Token: 0x06001DE4 RID: 7652 RVA: 0x00147C68 File Offset: 0x00145E68
			public PartialInputStream(ZipFile zipFile, long start, long length)
			{
				this.start_ = start;
				this.length_ = length;
				this.zipFile_ = zipFile;
				this.baseStream_ = this.zipFile_.baseStream_;
				this.readPos_ = start;
				this.end_ = start + length;
			}

			// Token: 0x06001DE5 RID: 7653 RVA: 0x00147CA8 File Offset: 0x00145EA8
			public override int ReadByte()
			{
				if (this.readPos_ >= this.end_)
				{
					return -1;
				}
				Stream stream = this.baseStream_;
				int num2;
				lock (stream)
				{
					Stream stream2 = this.baseStream_;
					long num = this.readPos_;
					this.readPos_ = num + 1L;
					stream2.Seek(num, SeekOrigin.Begin);
					num2 = this.baseStream_.ReadByte();
				}
				return num2;
			}

			// Token: 0x06001DE6 RID: 7654 RVA: 0x00147D20 File Offset: 0x00145F20
			public override int Read(byte[] buffer, int offset, int count)
			{
				Stream stream = this.baseStream_;
				int num2;
				lock (stream)
				{
					if ((long)count > this.end_ - this.readPos_)
					{
						count = (int)(this.end_ - this.readPos_);
						if (count == 0)
						{
							return 0;
						}
					}
					if (this.baseStream_.Position != this.readPos_)
					{
						this.baseStream_.Seek(this.readPos_, SeekOrigin.Begin);
					}
					int num = this.baseStream_.Read(buffer, offset, count);
					if (num > 0)
					{
						this.readPos_ += (long)num;
					}
					num2 = num;
				}
				return num2;
			}

			// Token: 0x06001DE7 RID: 7655 RVA: 0x00147DD0 File Offset: 0x00145FD0
			public override void Write(byte[] buffer, int offset, int count)
			{
				throw new NotSupportedException();
			}

			// Token: 0x06001DE8 RID: 7656 RVA: 0x00147DD7 File Offset: 0x00145FD7
			public override void SetLength(long value)
			{
				throw new NotSupportedException();
			}

			// Token: 0x06001DE9 RID: 7657 RVA: 0x00147DE0 File Offset: 0x00145FE0
			public override long Seek(long offset, SeekOrigin origin)
			{
				long num = this.readPos_;
				switch (origin)
				{
				case SeekOrigin.Begin:
					num = this.start_ + offset;
					break;
				case SeekOrigin.Current:
					num = this.readPos_ + offset;
					break;
				case SeekOrigin.End:
					num = this.end_ + offset;
					break;
				}
				if (num < this.start_)
				{
					throw new ArgumentException("Negative position is invalid");
				}
				if (num >= this.end_)
				{
					throw new IOException("Cannot seek past end");
				}
				this.readPos_ = num;
				return this.readPos_;
			}

			// Token: 0x06001DEA RID: 7658 RVA: 0x00147E5C File Offset: 0x0014605C
			public override void Flush()
			{
			}

			// Token: 0x17000258 RID: 600
			// (get) Token: 0x06001DEB RID: 7659 RVA: 0x00147E5E File Offset: 0x0014605E
			// (set) Token: 0x06001DEC RID: 7660 RVA: 0x00147E70 File Offset: 0x00146070
			public override long Position
			{
				get
				{
					return this.readPos_ - this.start_;
				}
				set
				{
					long num = this.start_ + value;
					if (num < this.start_)
					{
						throw new ArgumentException("Negative position is invalid");
					}
					if (num >= this.end_)
					{
						throw new InvalidOperationException("Cannot seek past end");
					}
					this.readPos_ = num;
				}
			}

			// Token: 0x17000259 RID: 601
			// (get) Token: 0x06001DED RID: 7661 RVA: 0x00147EB5 File Offset: 0x001460B5
			public override long Length
			{
				get
				{
					return this.length_;
				}
			}

			// Token: 0x1700025A RID: 602
			// (get) Token: 0x06001DEE RID: 7662 RVA: 0x00147EBD File Offset: 0x001460BD
			public override bool CanWrite
			{
				get
				{
					return false;
				}
			}

			// Token: 0x1700025B RID: 603
			// (get) Token: 0x06001DEF RID: 7663 RVA: 0x00147EC0 File Offset: 0x001460C0
			public override bool CanSeek
			{
				get
				{
					return true;
				}
			}

			// Token: 0x1700025C RID: 604
			// (get) Token: 0x06001DF0 RID: 7664 RVA: 0x00147EC3 File Offset: 0x001460C3
			public override bool CanRead
			{
				get
				{
					return true;
				}
			}

			// Token: 0x1700025D RID: 605
			// (get) Token: 0x06001DF1 RID: 7665 RVA: 0x00147EC6 File Offset: 0x001460C6
			public override bool CanTimeout
			{
				get
				{
					return this.baseStream_.CanTimeout;
				}
			}

			// Token: 0x04001546 RID: 5446
			private ZipFile zipFile_;

			// Token: 0x04001547 RID: 5447
			private Stream baseStream_;

			// Token: 0x04001548 RID: 5448
			private readonly long start_;

			// Token: 0x04001549 RID: 5449
			private readonly long length_;

			// Token: 0x0400154A RID: 5450
			private long readPos_;

			// Token: 0x0400154B RID: 5451
			private readonly long end_;
		}
	}
}
