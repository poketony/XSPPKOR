using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams
{
	// Token: 0x0200016F RID: 367
	public class OutputWindow
	{
		// Token: 0x06001945 RID: 6469 RVA: 0x00139850 File Offset: 0x00137A50
		public void Write(int value)
		{
			int num = this.windowFilled;
			this.windowFilled = num + 1;
			if (num == 32768)
			{
				throw new InvalidOperationException("Window full");
			}
			byte[] array = this.window;
			num = this.windowEnd;
			this.windowEnd = num + 1;
			array[num] = (byte)value;
			this.windowEnd &= 32767;
		}

		// Token: 0x06001946 RID: 6470 RVA: 0x001398AC File Offset: 0x00137AAC
		private void SlowRepeat(int repStart, int length, int distance)
		{
			while (length-- > 0)
			{
				byte[] array = this.window;
				int num = this.windowEnd;
				this.windowEnd = num + 1;
				array[num] = this.window[repStart++];
				this.windowEnd &= 32767;
				repStart &= 32767;
			}
		}

		// Token: 0x06001947 RID: 6471 RVA: 0x00139904 File Offset: 0x00137B04
		public void Repeat(int length, int distance)
		{
			if ((this.windowFilled += length) > 32768)
			{
				throw new InvalidOperationException("Window full");
			}
			int num = (this.windowEnd - distance) & 32767;
			int num2 = 32768 - length;
			if (num > num2 || this.windowEnd >= num2)
			{
				this.SlowRepeat(num, length, distance);
				return;
			}
			if (length <= distance)
			{
				Array.Copy(this.window, num, this.window, this.windowEnd, length);
				this.windowEnd += length;
				return;
			}
			while (length-- > 0)
			{
				byte[] array = this.window;
				int num3 = this.windowEnd;
				this.windowEnd = num3 + 1;
				array[num3] = this.window[num++];
			}
		}

		// Token: 0x06001948 RID: 6472 RVA: 0x001399BC File Offset: 0x00137BBC
		public int CopyStored(StreamManipulator input, int length)
		{
			length = Math.Min(Math.Min(length, 32768 - this.windowFilled), input.AvailableBytes);
			int num = 32768 - this.windowEnd;
			int num2;
			if (length > num)
			{
				num2 = input.CopyBytes(this.window, this.windowEnd, num);
				if (num2 == num)
				{
					num2 += input.CopyBytes(this.window, 0, length - num);
				}
			}
			else
			{
				num2 = input.CopyBytes(this.window, this.windowEnd, length);
			}
			this.windowEnd = (this.windowEnd + num2) & 32767;
			this.windowFilled += num2;
			return num2;
		}

		// Token: 0x06001949 RID: 6473 RVA: 0x00139A60 File Offset: 0x00137C60
		public void CopyDict(byte[] dictionary, int offset, int length)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			if (this.windowFilled > 0)
			{
				throw new InvalidOperationException();
			}
			if (length > 32768)
			{
				offset += length - 32768;
				length = 32768;
			}
			Array.Copy(dictionary, offset, this.window, 0, length);
			this.windowEnd = length & 32767;
		}

		// Token: 0x0600194A RID: 6474 RVA: 0x00139AC0 File Offset: 0x00137CC0
		public int GetFreeSpace()
		{
			return 32768 - this.windowFilled;
		}

		// Token: 0x0600194B RID: 6475 RVA: 0x00139ACE File Offset: 0x00137CCE
		public int GetAvailable()
		{
			return this.windowFilled;
		}

		// Token: 0x0600194C RID: 6476 RVA: 0x00139AD8 File Offset: 0x00137CD8
		public int CopyOutput(byte[] output, int offset, int len)
		{
			int num = this.windowEnd;
			if (len > this.windowFilled)
			{
				len = this.windowFilled;
			}
			else
			{
				num = (this.windowEnd - this.windowFilled + len) & 32767;
			}
			int num2 = len;
			int num3 = len - num;
			if (num3 > 0)
			{
				Array.Copy(this.window, 32768 - num3, output, offset, num3);
				offset += num3;
				len = num;
			}
			Array.Copy(this.window, num - len, output, offset, len);
			this.windowFilled -= num2;
			if (this.windowFilled < 0)
			{
				throw new InvalidOperationException();
			}
			return num2;
		}

		// Token: 0x0600194D RID: 6477 RVA: 0x00139B6C File Offset: 0x00137D6C
		public void Reset()
		{
			this.windowFilled = (this.windowEnd = 0);
		}

		// Token: 0x04000EA4 RID: 3748
		private const int WindowSize = 32768;

		// Token: 0x04000EA5 RID: 3749
		private const int WindowMask = 32767;

		// Token: 0x04000EA6 RID: 3750
		private byte[] window = new byte[32768];

		// Token: 0x04000EA7 RID: 3751
		private int windowEnd;

		// Token: 0x04000EA8 RID: 3752
		private int windowFilled;
	}
}
