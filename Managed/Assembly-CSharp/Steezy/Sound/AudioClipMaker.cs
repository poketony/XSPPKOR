using System;
using UnityEngine;

namespace Steezy.Sound
{
	// Token: 0x020000B9 RID: 185
	public class AudioClipMaker
	{
		// Token: 0x060010C4 RID: 4292 RVA: 0x00119BA0 File Offset: 0x00117DA0
		public AudioClip Create(string name, byte[] raw_data, int wav_buf_idx, int bit_per_sample, int samples, int channels, int frequency, bool isStream)
		{
			float[] array = this.CreateRangedRawData(raw_data, wav_buf_idx, samples, channels, bit_per_sample);
			return this.Create(name, array, samples, channels, frequency, isStream);
		}

		// Token: 0x060010C5 RID: 4293 RVA: 0x00119BCC File Offset: 0x00117DCC
		public AudioClip Create(string name, float[] ranged_data, int samples, int channels, int frequency, bool isStream)
		{
			AudioClip audioClip = AudioClip.Create(name, samples, channels, frequency, isStream);
			audioClip.SetData(ranged_data, 0);
			return audioClip;
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x00119BE4 File Offset: 0x00117DE4
		public AudioClip CreateStream(string name, int samples, int channels, int frequency, bool isStream, AudioClip.PCMReaderCallback readerCallBack, AudioClip.PCMSetPositionCallback setPositionCallback)
		{
			return AudioClip.Create(name, samples, channels, frequency, isStream, readerCallBack, setPositionCallback);
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x00119BF8 File Offset: 0x00117DF8
		public float[] CreateRangedRawData(byte[] byte_data, int wav_buf_idx, int samples, int channels, int bit_per_sample)
		{
			float[] array = new float[samples * channels];
			int num = bit_per_sample / 8;
			int num2 = wav_buf_idx;
			for (int i = 0; i < samples * channels; i++)
			{
				array[i] = this.convertByteToFloatData(byte_data, num2, bit_per_sample);
				num2 += num;
			}
			return array;
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x00119C38 File Offset: 0x00117E38
		public float convertByteToFloatData(byte[] byte_data, int idx, int bit_per_sample)
		{
			float num = 0f;
			if (idx >= byte_data.Length)
			{
				return num;
			}
			if (bit_per_sample != 8)
			{
				if (bit_per_sample == 16)
				{
					num = (float)BitConverter.ToInt16(byte_data, idx) * this.RANGE_VALUE_BIT_16;
				}
			}
			else
			{
				num = (float)(byte_data[idx] - 128) * this.RANGE_VALUE_BIT_8;
			}
			return num;
		}

		// Token: 0x040009B8 RID: 2488
		public readonly float RANGE_VALUE_BIT_8 = 1f / Mathf.Pow(2f, 7f);

		// Token: 0x040009B9 RID: 2489
		public readonly float RANGE_VALUE_BIT_16 = 1f / Mathf.Pow(2f, 15f);

		// Token: 0x040009BA RID: 2490
		public const int BASE_CONVERT_SAMPLES = 20480;

		// Token: 0x040009BB RID: 2491
		public const int BIT_8 = 8;

		// Token: 0x040009BC RID: 2492
		public const int BIT_16 = 16;
	}
}
