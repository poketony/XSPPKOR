using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Socotra.IO;

namespace Socotra.Util
{
	// Token: 0x0200011B RID: 283
	public class JarInflater
	{
		// Token: 0x060015C5 RID: 5573 RVA: 0x0012C176 File Offset: 0x0012A376
		public JarInflater()
		{
		}

		// Token: 0x060015C6 RID: 5574 RVA: 0x0012C180 File Offset: 0x0012A380
		public JarInflater(sbyte[] data)
		{
			this.baseData = new byte[data.Length];
			this.baseJar = null;
			for (int i = 0; i < data.Length; i++)
			{
				this.baseData[i] = (byte)data[i];
			}
		}

		// Token: 0x060015C7 RID: 5575 RVA: 0x0012C1C4 File Offset: 0x0012A3C4
		public JarInflater(InputStream input)
		{
			if (input is JarInputStream)
			{
				this.baseJar = (input as JarInputStream).Jar;
				return;
			}
			if (input is JarDataInputStream)
			{
				this.baseJar = (input as JarDataInputStream).Jar;
				return;
			}
			sbyte[] array = new sbyte[input.Available()];
			input.Read(ref array);
			this.baseData = new byte[array.Length];
			this.baseJar = null;
			for (int i = 0; i < array.Length; i++)
			{
				this.baseData[i] = (byte)array[i];
			}
		}

		// Token: 0x060015C8 RID: 5576 RVA: 0x0012C250 File Offset: 0x0012A450
		public InputStream GetInputStream(string file)
		{
			if (this.baseJar != null)
			{
				ScratchPadData data = this.baseJar.GetData(file);
				if (data is ScratchPadDataSound)
				{
					return new SoundInputStream(data as ScratchPadDataSound);
				}
				if (data is ScratchPadDataImage)
				{
					return new ImageInputStream(data as ScratchPadDataImage);
				}
				if (data is ScratchPadDataBinary)
				{
					return data.GetInputStream();
				}
			}
			else if (this.baseData != null)
			{
				ZipInputStream zipInputStream = new ZipInputStream(new MemoryStream(this.baseData));
				ZipEntry nextEntry;
				while ((nextEntry = zipInputStream.GetNextEntry()) != null)
				{
					if (nextEntry.Name.Equals(file))
					{
						ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
						byte[] array = new byte[2048];
						for (;;)
						{
							int num = zipInputStream.Read(array, 0, array.Length);
							if (num <= 0)
							{
								break;
							}
							byteArrayOutputStream.Write(array, 0, num);
						}
						return new ByteArrayInputStream(byteArrayOutputStream.ToSByteArray());
					}
				}
			}
			return null;
		}

		// Token: 0x060015C9 RID: 5577 RVA: 0x0012C32C File Offset: 0x0012A52C
		public void Close()
		{
		}

		// Token: 0x060015CA RID: 5578 RVA: 0x0012C330 File Offset: 0x0012A530
		public int GetSize(string name)
		{
			if (!(this.baseJar != null))
			{
				if (this.baseData != null)
				{
					ZipInputStream zipInputStream = new ZipInputStream(new MemoryStream(this.baseData));
					ZipEntry nextEntry;
					while ((nextEntry = zipInputStream.GetNextEntry()) != null)
					{
						if (nextEntry.Name.Equals(name))
						{
							int num = 0;
							byte[] array = new byte[2048];
							for (;;)
							{
								int num2 = zipInputStream.Read(array, 0, array.Length);
								if (num2 <= 0)
								{
									break;
								}
								num += num2;
							}
							return num;
						}
					}
				}
				return 0;
			}
			ScratchPadData data = this.baseJar.GetData(name);
			if (data != null)
			{
				return data.Length;
			}
			return 0;
		}

		// Token: 0x04000C8D RID: 3213
		private ScratchPadDataJar baseJar;

		// Token: 0x04000C8E RID: 3214
		private byte[] baseData;
	}
}
