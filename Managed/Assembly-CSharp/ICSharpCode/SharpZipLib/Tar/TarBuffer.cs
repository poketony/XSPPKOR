using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Tar
{
	// Token: 0x02000174 RID: 372
	public class TarBuffer
	{
		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600198B RID: 6539 RVA: 0x0013A9B8 File Offset: 0x00138BB8
		public int RecordSize
		{
			get
			{
				return this.recordSize;
			}
		}

		// Token: 0x0600198C RID: 6540 RVA: 0x0013A9C0 File Offset: 0x00138BC0
		[Obsolete("Use RecordSize property instead")]
		public int GetRecordSize()
		{
			return this.recordSize;
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x0600198D RID: 6541 RVA: 0x0013A9C8 File Offset: 0x00138BC8
		public int BlockFactor
		{
			get
			{
				return this.blockFactor;
			}
		}

		// Token: 0x0600198E RID: 6542 RVA: 0x0013A9D0 File Offset: 0x00138BD0
		[Obsolete("Use BlockFactor property instead")]
		public int GetBlockFactor()
		{
			return this.blockFactor;
		}

		// Token: 0x0600198F RID: 6543 RVA: 0x0013A9D8 File Offset: 0x00138BD8
		protected TarBuffer()
		{
		}

		// Token: 0x06001990 RID: 6544 RVA: 0x0013A9FA File Offset: 0x00138BFA
		public static TarBuffer CreateInputTarBuffer(Stream inputStream)
		{
			if (inputStream == null)
			{
				throw new ArgumentNullException("inputStream");
			}
			return TarBuffer.CreateInputTarBuffer(inputStream, 20);
		}

		// Token: 0x06001991 RID: 6545 RVA: 0x0013AA12 File Offset: 0x00138C12
		public static TarBuffer CreateInputTarBuffer(Stream inputStream, int blockFactor)
		{
			if (inputStream == null)
			{
				throw new ArgumentNullException("inputStream");
			}
			if (blockFactor <= 0)
			{
				throw new ArgumentOutOfRangeException("blockFactor", "Factor cannot be negative");
			}
			TarBuffer tarBuffer = new TarBuffer();
			tarBuffer.inputStream = inputStream;
			tarBuffer.outputStream = null;
			tarBuffer.Initialize(blockFactor);
			return tarBuffer;
		}

		// Token: 0x06001992 RID: 6546 RVA: 0x0013AA50 File Offset: 0x00138C50
		public static TarBuffer CreateOutputTarBuffer(Stream outputStream)
		{
			if (outputStream == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			return TarBuffer.CreateOutputTarBuffer(outputStream, 20);
		}

		// Token: 0x06001993 RID: 6547 RVA: 0x0013AA68 File Offset: 0x00138C68
		public static TarBuffer CreateOutputTarBuffer(Stream outputStream, int blockFactor)
		{
			if (outputStream == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			if (blockFactor <= 0)
			{
				throw new ArgumentOutOfRangeException("blockFactor", "Factor cannot be negative");
			}
			TarBuffer tarBuffer = new TarBuffer();
			tarBuffer.inputStream = null;
			tarBuffer.outputStream = outputStream;
			tarBuffer.Initialize(blockFactor);
			return tarBuffer;
		}

		// Token: 0x06001994 RID: 6548 RVA: 0x0013AAA8 File Offset: 0x00138CA8
		private void Initialize(int archiveBlockFactor)
		{
			this.blockFactor = archiveBlockFactor;
			this.recordSize = archiveBlockFactor * 512;
			this.recordBuffer = new byte[this.RecordSize];
			if (this.inputStream != null)
			{
				this.currentRecordIndex = -1;
				this.currentBlockIndex = this.BlockFactor;
				return;
			}
			this.currentRecordIndex = 0;
			this.currentBlockIndex = 0;
		}

		// Token: 0x06001995 RID: 6549 RVA: 0x0013AB04 File Offset: 0x00138D04
		[Obsolete("Use IsEndOfArchiveBlock instead")]
		public bool IsEOFBlock(byte[] block)
		{
			if (block == null)
			{
				throw new ArgumentNullException("block");
			}
			if (block.Length != 512)
			{
				throw new ArgumentException("block length is invalid");
			}
			for (int i = 0; i < 512; i++)
			{
				if (block[i] != 0)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06001996 RID: 6550 RVA: 0x0013AB4C File Offset: 0x00138D4C
		public static bool IsEndOfArchiveBlock(byte[] block)
		{
			if (block == null)
			{
				throw new ArgumentNullException("block");
			}
			if (block.Length != 512)
			{
				throw new ArgumentException("block length is invalid");
			}
			for (int i = 0; i < 512; i++)
			{
				if (block[i] != 0)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06001997 RID: 6551 RVA: 0x0013AB94 File Offset: 0x00138D94
		public void SkipBlock()
		{
			if (this.inputStream == null)
			{
				throw new TarException("no input stream defined");
			}
			if (this.currentBlockIndex >= this.BlockFactor && !this.ReadRecord())
			{
				throw new TarException("Failed to read a record");
			}
			this.currentBlockIndex++;
		}

		// Token: 0x06001998 RID: 6552 RVA: 0x0013ABE4 File Offset: 0x00138DE4
		public byte[] ReadBlock()
		{
			if (this.inputStream == null)
			{
				throw new TarException("TarBuffer.ReadBlock - no input stream defined");
			}
			if (this.currentBlockIndex >= this.BlockFactor && !this.ReadRecord())
			{
				throw new TarException("Failed to read a record");
			}
			byte[] array = new byte[512];
			Array.Copy(this.recordBuffer, this.currentBlockIndex * 512, array, 0, 512);
			this.currentBlockIndex++;
			return array;
		}

		// Token: 0x06001999 RID: 6553 RVA: 0x0013AC60 File Offset: 0x00138E60
		private bool ReadRecord()
		{
			if (this.inputStream == null)
			{
				throw new TarException("no input stream stream defined");
			}
			this.currentBlockIndex = 0;
			int num = 0;
			long num2;
			for (int i = this.RecordSize; i > 0; i -= (int)num2)
			{
				num2 = (long)this.inputStream.Read(this.recordBuffer, num, i);
				if (num2 <= 0L)
				{
					break;
				}
				num += (int)num2;
			}
			this.currentRecordIndex++;
			return true;
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x0600199A RID: 6554 RVA: 0x0013ACC9 File Offset: 0x00138EC9
		public int CurrentBlock
		{
			get
			{
				return this.currentBlockIndex;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x0600199B RID: 6555 RVA: 0x0013ACD1 File Offset: 0x00138ED1
		// (set) Token: 0x0600199C RID: 6556 RVA: 0x0013ACD9 File Offset: 0x00138ED9
		public bool IsStreamOwner { get; set; } = true;

		// Token: 0x0600199D RID: 6557 RVA: 0x0013ACE2 File Offset: 0x00138EE2
		[Obsolete("Use CurrentBlock property instead")]
		public int GetCurrentBlockNum()
		{
			return this.currentBlockIndex;
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x0600199E RID: 6558 RVA: 0x0013ACEA File Offset: 0x00138EEA
		public int CurrentRecord
		{
			get
			{
				return this.currentRecordIndex;
			}
		}

		// Token: 0x0600199F RID: 6559 RVA: 0x0013ACF2 File Offset: 0x00138EF2
		[Obsolete("Use CurrentRecord property instead")]
		public int GetCurrentRecordNum()
		{
			return this.currentRecordIndex;
		}

		// Token: 0x060019A0 RID: 6560 RVA: 0x0013ACFC File Offset: 0x00138EFC
		public void WriteBlock(byte[] block)
		{
			if (block == null)
			{
				throw new ArgumentNullException("block");
			}
			if (this.outputStream == null)
			{
				throw new TarException("TarBuffer.WriteBlock - no output stream defined");
			}
			if (block.Length != 512)
			{
				throw new TarException(string.Format("TarBuffer.WriteBlock - block to write has length '{0}' which is not the block size of '{1}'", block.Length, 512));
			}
			if (this.currentBlockIndex >= this.BlockFactor)
			{
				this.WriteRecord();
			}
			Array.Copy(block, 0, this.recordBuffer, this.currentBlockIndex * 512, 512);
			this.currentBlockIndex++;
		}

		// Token: 0x060019A1 RID: 6561 RVA: 0x0013AD98 File Offset: 0x00138F98
		public void WriteBlock(byte[] buffer, int offset)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (this.outputStream == null)
			{
				throw new TarException("TarBuffer.WriteBlock - no output stream stream defined");
			}
			if (offset < 0 || offset >= buffer.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (offset + 512 > buffer.Length)
			{
				throw new TarException(string.Format("TarBuffer.WriteBlock - record has length '{0}' with offset '{1}' which is less than the record size of '{2}'", buffer.Length, offset, this.recordSize));
			}
			if (this.currentBlockIndex >= this.BlockFactor)
			{
				this.WriteRecord();
			}
			Array.Copy(buffer, offset, this.recordBuffer, this.currentBlockIndex * 512, 512);
			this.currentBlockIndex++;
		}

		// Token: 0x060019A2 RID: 6562 RVA: 0x0013AE50 File Offset: 0x00139050
		private void WriteRecord()
		{
			if (this.outputStream == null)
			{
				throw new TarException("TarBuffer.WriteRecord no output stream defined");
			}
			this.outputStream.Write(this.recordBuffer, 0, this.RecordSize);
			this.outputStream.Flush();
			this.currentBlockIndex = 0;
			this.currentRecordIndex++;
		}

		// Token: 0x060019A3 RID: 6563 RVA: 0x0013AEA8 File Offset: 0x001390A8
		private void WriteFinalRecord()
		{
			if (this.outputStream == null)
			{
				throw new TarException("TarBuffer.WriteFinalRecord no output stream defined");
			}
			if (this.currentBlockIndex > 0)
			{
				int num = this.currentBlockIndex * 512;
				Array.Clear(this.recordBuffer, num, this.RecordSize - num);
				this.WriteRecord();
			}
			this.outputStream.Flush();
		}

		// Token: 0x060019A4 RID: 6564 RVA: 0x0013AF04 File Offset: 0x00139104
		public void Close()
		{
			if (this.outputStream != null)
			{
				this.WriteFinalRecord();
				if (this.IsStreamOwner)
				{
					this.outputStream.Dispose();
				}
				this.outputStream = null;
				return;
			}
			if (this.inputStream != null)
			{
				if (this.IsStreamOwner)
				{
					this.inputStream.Dispose();
				}
				this.inputStream = null;
			}
		}

		// Token: 0x04000EBB RID: 3771
		public const int BlockSize = 512;

		// Token: 0x04000EBC RID: 3772
		public const int DefaultBlockFactor = 20;

		// Token: 0x04000EBD RID: 3773
		public const int DefaultRecordSize = 10240;

		// Token: 0x04000EBF RID: 3775
		private Stream inputStream;

		// Token: 0x04000EC0 RID: 3776
		private Stream outputStream;

		// Token: 0x04000EC1 RID: 3777
		private byte[] recordBuffer;

		// Token: 0x04000EC2 RID: 3778
		private int currentBlockIndex;

		// Token: 0x04000EC3 RID: 3779
		private int currentRecordIndex;

		// Token: 0x04000EC4 RID: 3780
		private int recordSize = 10240;

		// Token: 0x04000EC5 RID: 3781
		private int blockFactor = 20;
	}
}
