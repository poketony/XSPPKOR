using System;
using System.Text;

namespace Steezy.Sound
{
	// Token: 0x020000BE RID: 190
	public class WavInfo
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060010F5 RID: 4341 RVA: 0x0011A773 File Offset: 0x00118973
		// (set) Token: 0x060010F6 RID: 4342 RVA: 0x0011A77B File Offset: 0x0011897B
		public int FileSize
		{
			get
			{
				return this.fileSize;
			}
			set
			{
				this.fileSize = value;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060010F7 RID: 4343 RVA: 0x0011A784 File Offset: 0x00118984
		// (set) Token: 0x060010F8 RID: 4344 RVA: 0x0011A78C File Offset: 0x0011898C
		public string RiffID
		{
			get
			{
				return this.riffID;
			}
			set
			{
				this.riffID = value;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060010F9 RID: 4345 RVA: 0x0011A795 File Offset: 0x00118995
		// (set) Token: 0x060010FA RID: 4346 RVA: 0x0011A79D File Offset: 0x0011899D
		public int DataSize
		{
			get
			{
				return this.dataSize;
			}
			set
			{
				this.dataSize = value;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060010FB RID: 4347 RVA: 0x0011A7A6 File Offset: 0x001189A6
		// (set) Token: 0x060010FC RID: 4348 RVA: 0x0011A7AE File Offset: 0x001189AE
		public string WaveID
		{
			get
			{
				return this.waveID;
			}
			set
			{
				this.waveID = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060010FD RID: 4349 RVA: 0x0011A7B7 File Offset: 0x001189B7
		// (set) Token: 0x060010FE RID: 4350 RVA: 0x0011A7BF File Offset: 0x001189BF
		public string FmtID
		{
			get
			{
				return this.fmtID;
			}
			set
			{
				this.fmtID = value;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060010FF RID: 4351 RVA: 0x0011A7C8 File Offset: 0x001189C8
		// (set) Token: 0x06001100 RID: 4352 RVA: 0x0011A7D0 File Offset: 0x001189D0
		public int FormatDataSize
		{
			get
			{
				return this.formatDataSize;
			}
			set
			{
				this.formatDataSize = value;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06001101 RID: 4353 RVA: 0x0011A7D9 File Offset: 0x001189D9
		// (set) Token: 0x06001102 RID: 4354 RVA: 0x0011A7E1 File Offset: 0x001189E1
		public int FormatCode
		{
			get
			{
				return this.formatCode;
			}
			set
			{
				this.formatCode = value;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06001103 RID: 4355 RVA: 0x0011A7EA File Offset: 0x001189EA
		// (set) Token: 0x06001104 RID: 4356 RVA: 0x0011A7F2 File Offset: 0x001189F2
		public int ChannelNum
		{
			get
			{
				return this.channelNum;
			}
			set
			{
				this.channelNum = value;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06001105 RID: 4357 RVA: 0x0011A7FB File Offset: 0x001189FB
		// (set) Token: 0x06001106 RID: 4358 RVA: 0x0011A803 File Offset: 0x00118A03
		public int SamplingRate
		{
			get
			{
				return this.samplingRate;
			}
			set
			{
				this.samplingRate = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06001107 RID: 4359 RVA: 0x0011A80C File Offset: 0x00118A0C
		// (set) Token: 0x06001108 RID: 4360 RVA: 0x0011A814 File Offset: 0x00118A14
		public int BytePerSec
		{
			get
			{
				return this.bytePerSec;
			}
			set
			{
				this.bytePerSec = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06001109 RID: 4361 RVA: 0x0011A81D File Offset: 0x00118A1D
		// (set) Token: 0x0600110A RID: 4362 RVA: 0x0011A825 File Offset: 0x00118A25
		public int BlockSize
		{
			get
			{
				return this.blockSize;
			}
			set
			{
				this.blockSize = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600110B RID: 4363 RVA: 0x0011A82E File Offset: 0x00118A2E
		// (set) Token: 0x0600110C RID: 4364 RVA: 0x0011A836 File Offset: 0x00118A36
		public int BitPerSample
		{
			get
			{
				return this.bitPerSample;
			}
			set
			{
				this.bitPerSample = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600110D RID: 4365 RVA: 0x0011A83F File Offset: 0x00118A3F
		// (set) Token: 0x0600110E RID: 4366 RVA: 0x0011A847 File Offset: 0x00118A47
		public int ExParamSize
		{
			get
			{
				return this.exParamSize;
			}
			set
			{
				this.fileSize = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600110F RID: 4367 RVA: 0x0011A850 File Offset: 0x00118A50
		// (set) Token: 0x06001110 RID: 4368 RVA: 0x0011A858 File Offset: 0x00118A58
		public byte[] ExParam
		{
			get
			{
				return this.exParam;
			}
			set
			{
				this.exParam = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06001111 RID: 4369 RVA: 0x0011A861 File Offset: 0x00118A61
		// (set) Token: 0x06001112 RID: 4370 RVA: 0x0011A869 File Offset: 0x00118A69
		public string DataID
		{
			get
			{
				return this.dataID;
			}
			set
			{
				this.dataID = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06001113 RID: 4371 RVA: 0x0011A872 File Offset: 0x00118A72
		// (set) Token: 0x06001114 RID: 4372 RVA: 0x0011A87A File Offset: 0x00118A7A
		public int FrequencyDataSize
		{
			get
			{
				return this.frequencyDataSize;
			}
			set
			{
				this.frequencyDataSize = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06001115 RID: 4373 RVA: 0x0011A883 File Offset: 0x00118A83
		// (set) Token: 0x06001116 RID: 4374 RVA: 0x0011A88B File Offset: 0x00118A8B
		public byte[] FrequencyData
		{
			get
			{
				return this.frequencyData;
			}
			set
			{
				this.frequencyData = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06001117 RID: 4375 RVA: 0x0011A894 File Offset: 0x00118A94
		// (set) Token: 0x06001118 RID: 4376 RVA: 0x0011A89C File Offset: 0x00118A9C
		public int FrequencyDataOffset
		{
			get
			{
				return this.frequencyDataOffset;
			}
			set
			{
				this.frequencyDataOffset = value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06001119 RID: 4377 RVA: 0x0011A8A5 File Offset: 0x00118AA5
		// (set) Token: 0x0600111A RID: 4378 RVA: 0x0011A8AD File Offset: 0x00118AAD
		public int SampleValue
		{
			get
			{
				return this.sampleValue;
			}
			set
			{
				this.sampleValue = value;
			}
		}

		// Token: 0x0600111B RID: 4379 RVA: 0x0011A8B6 File Offset: 0x00118AB6
		public bool Create()
		{
			return true;
		}

		// Token: 0x0600111C RID: 4380 RVA: 0x0011A8B9 File Offset: 0x00118AB9
		public void Delete()
		{
		}

		// Token: 0x0600111D RID: 4381 RVA: 0x0011A8BC File Offset: 0x00118ABC
		public bool Analyze(byte[] dat)
		{
			bool flag = false;
			int num = 0;
			this.fileSize = dat.Length;
			this.riffID = Encoding.ASCII.GetString(dat, num, 4);
			if (!this.riffID.Equals("RIFF"))
			{
				return flag;
			}
			num += 4;
			this.dataSize = BitConverter.ToInt32(dat, num);
			num += 4;
			this.waveID = Encoding.ASCII.GetString(dat, num, 4);
			if (!this.waveID.Equals("WAVE"))
			{
				return flag;
			}
			num += 4;
			this.fmtID = Encoding.ASCII.GetString(dat, num, 4);
			if (!this.fmtID.Equals("fmt "))
			{
				return flag;
			}
			num += 4;
			this.formatDataSize = BitConverter.ToInt32(dat, num);
			num += 4;
			this.formatCode = (int)BitConverter.ToInt16(dat, num);
			num += 2;
			this.channelNum = (int)BitConverter.ToInt16(dat, num);
			num += 2;
			this.samplingRate = BitConverter.ToInt32(dat, num);
			num += 4;
			this.bytePerSec = BitConverter.ToInt32(dat, num);
			num += 4;
			this.blockSize = (int)BitConverter.ToInt16(dat, num);
			num += 2;
			this.bitPerSample = (int)BitConverter.ToInt16(dat, num);
			num += 2;
			if (this.formatCode != 1)
			{
				this.exParamSize = (int)BitConverter.ToInt16(dat, num);
				num += 2;
				this.exParam = null;
				this.exParam = new byte[this.exParamSize];
				for (int i = 0; i < this.exParamSize; i++)
				{
					this.exParam[i] = dat[num + i];
				}
				num += this.exParamSize;
			}
			this.dataID = Encoding.ASCII.GetString(dat, num, 4);
			if (!this.dataID.Equals("data"))
			{
				return flag;
			}
			num += 4;
			this.frequencyDataSize = BitConverter.ToInt32(dat, num);
			num += 4;
			this.sampleValue = this.frequencyDataSize / (this.bitPerSample / 8) / this.channelNum;
			this.frequencyDataOffset = num;
			this.frequencyData = null;
			if (this.frequencyDataSize > 0)
			{
				this.frequencyData = new byte[this.frequencyDataSize];
				for (int j = 0; j < this.frequencyDataSize; j++)
				{
					this.frequencyData[j] = dat[num + j];
				}
				num += this.frequencyDataSize;
				flag = true;
			}
			return flag;
		}

		// Token: 0x040009E4 RID: 2532
		public const int FAILED = -1;

		// Token: 0x040009E5 RID: 2533
		public const int SUCCESS = 0;

		// Token: 0x040009E6 RID: 2534
		public const int QUANTUM_BIT_8 = 8;

		// Token: 0x040009E7 RID: 2535
		public const int QUANTUM_BIT_16 = 16;

		// Token: 0x040009E8 RID: 2536
		private string clsPath;

		// Token: 0x040009E9 RID: 2537
		private int fileSize;

		// Token: 0x040009EA RID: 2538
		private string riffID;

		// Token: 0x040009EB RID: 2539
		private int dataSize;

		// Token: 0x040009EC RID: 2540
		private string waveID;

		// Token: 0x040009ED RID: 2541
		private string fmtID;

		// Token: 0x040009EE RID: 2542
		private int formatDataSize;

		// Token: 0x040009EF RID: 2543
		private int formatCode;

		// Token: 0x040009F0 RID: 2544
		private int channelNum;

		// Token: 0x040009F1 RID: 2545
		private int samplingRate;

		// Token: 0x040009F2 RID: 2546
		private int bytePerSec;

		// Token: 0x040009F3 RID: 2547
		private int blockSize;

		// Token: 0x040009F4 RID: 2548
		private int bitPerSample;

		// Token: 0x040009F5 RID: 2549
		private int exParamSize;

		// Token: 0x040009F6 RID: 2550
		private byte[] exParam;

		// Token: 0x040009F7 RID: 2551
		private string dataID;

		// Token: 0x040009F8 RID: 2552
		private int frequencyDataSize;

		// Token: 0x040009F9 RID: 2553
		private byte[] frequencyData;

		// Token: 0x040009FA RID: 2554
		private int frequencyDataOffset;

		// Token: 0x040009FB RID: 2555
		private int sampleValue;
	}
}
