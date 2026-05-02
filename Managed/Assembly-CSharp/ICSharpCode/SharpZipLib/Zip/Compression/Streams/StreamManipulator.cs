using System;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams
{
	// Token: 0x02000170 RID: 368
	public class StreamManipulator
	{
		// Token: 0x0600194F RID: 6479 RVA: 0x00139BA4 File Offset: 0x00137DA4
		public int PeekBits(int bitCount)
		{
			if (this.bitsInBuffer_ < bitCount)
			{
				if (this.windowStart_ == this.windowEnd_)
				{
					return -1;
				}
				uint num = this.buffer_;
				byte[] array = this.window_;
				int num2 = this.windowStart_;
				this.windowStart_ = num2 + 1;
				uint num3 = array[num2] & 255U;
				byte[] array2 = this.window_;
				num2 = this.windowStart_;
				this.windowStart_ = num2 + 1;
				this.buffer_ = num | ((num3 | ((array2[num2] & 255U) << 8)) << this.bitsInBuffer_);
				this.bitsInBuffer_ += 16;
			}
			return (int)((ulong)this.buffer_ & (ulong)((long)((1 << bitCount) - 1)));
		}

		// Token: 0x06001950 RID: 6480 RVA: 0x00139C44 File Offset: 0x00137E44
		public bool TryGetBits(int bitCount, ref int output, int outputOffset = 0)
		{
			int num = this.PeekBits(bitCount);
			if (num < 0)
			{
				return false;
			}
			output = num + outputOffset;
			this.DropBits(bitCount);
			return true;
		}

		// Token: 0x06001951 RID: 6481 RVA: 0x00139C6C File Offset: 0x00137E6C
		public bool TryGetBits(int bitCount, ref byte[] array, int index)
		{
			int num = this.PeekBits(bitCount);
			if (num < 0)
			{
				return false;
			}
			array[index] = (byte)num;
			this.DropBits(bitCount);
			return true;
		}

		// Token: 0x06001952 RID: 6482 RVA: 0x00139C95 File Offset: 0x00137E95
		public void DropBits(int bitCount)
		{
			this.buffer_ >>= bitCount;
			this.bitsInBuffer_ -= bitCount;
		}

		// Token: 0x06001953 RID: 6483 RVA: 0x00139CB6 File Offset: 0x00137EB6
		public int GetBits(int bitCount)
		{
			int num = this.PeekBits(bitCount);
			if (num >= 0)
			{
				this.DropBits(bitCount);
			}
			return num;
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06001954 RID: 6484 RVA: 0x00139CCA File Offset: 0x00137ECA
		public int AvailableBits
		{
			get
			{
				return this.bitsInBuffer_;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06001955 RID: 6485 RVA: 0x00139CD2 File Offset: 0x00137ED2
		public int AvailableBytes
		{
			get
			{
				return this.windowEnd_ - this.windowStart_ + (this.bitsInBuffer_ >> 3);
			}
		}

		// Token: 0x06001956 RID: 6486 RVA: 0x00139CEA File Offset: 0x00137EEA
		public void SkipToByteBoundary()
		{
			this.buffer_ >>= this.bitsInBuffer_ & 7;
			this.bitsInBuffer_ &= -8;
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06001957 RID: 6487 RVA: 0x00139D13 File Offset: 0x00137F13
		public bool IsNeedingInput
		{
			get
			{
				return this.windowStart_ == this.windowEnd_;
			}
		}

		// Token: 0x06001958 RID: 6488 RVA: 0x00139D24 File Offset: 0x00137F24
		public int CopyBytes(byte[] output, int offset, int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			if ((this.bitsInBuffer_ & 7) != 0)
			{
				throw new InvalidOperationException("Bit buffer is not byte aligned!");
			}
			int num = 0;
			while (this.bitsInBuffer_ > 0 && length > 0)
			{
				output[offset++] = (byte)this.buffer_;
				this.buffer_ >>= 8;
				this.bitsInBuffer_ -= 8;
				length--;
				num++;
			}
			if (length == 0)
			{
				return num;
			}
			int num2 = this.windowEnd_ - this.windowStart_;
			if (length > num2)
			{
				length = num2;
			}
			Array.Copy(this.window_, this.windowStart_, output, offset, length);
			this.windowStart_ += length;
			if (((this.windowStart_ - this.windowEnd_) & 1) != 0)
			{
				byte[] array = this.window_;
				int num3 = this.windowStart_;
				this.windowStart_ = num3 + 1;
				this.buffer_ = array[num3] & 255U;
				this.bitsInBuffer_ = 8;
			}
			return num + length;
		}

		// Token: 0x06001959 RID: 6489 RVA: 0x00139E18 File Offset: 0x00138018
		public void Reset()
		{
			this.buffer_ = 0U;
			this.windowStart_ = (this.windowEnd_ = (this.bitsInBuffer_ = 0));
		}

		// Token: 0x0600195A RID: 6490 RVA: 0x00139E48 File Offset: 0x00138048
		public void SetInput(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Cannot be negative");
			}
			if (this.windowStart_ < this.windowEnd_)
			{
				throw new InvalidOperationException("Old input was not completely processed");
			}
			int num = offset + count;
			if (offset > num || num > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if ((count & 1) != 0)
			{
				this.buffer_ |= (uint)((uint)(buffer[offset++] & byte.MaxValue) << this.bitsInBuffer_);
				this.bitsInBuffer_ += 8;
			}
			this.window_ = buffer;
			this.windowStart_ = offset;
			this.windowEnd_ = num;
		}

		// Token: 0x04000EA9 RID: 3753
		private byte[] window_;

		// Token: 0x04000EAA RID: 3754
		private int windowStart_;

		// Token: 0x04000EAB RID: 3755
		private int windowEnd_;

		// Token: 0x04000EAC RID: 3756
		private uint buffer_;

		// Token: 0x04000EAD RID: 3757
		private int bitsInBuffer_;
	}
}
