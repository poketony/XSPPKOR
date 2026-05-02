using System;
using System.IO;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.GZip
{
	// Token: 0x02000182 RID: 386
	public class GZipOutputStream : DeflaterOutputStream
	{
		// Token: 0x06001A62 RID: 6754 RVA: 0x0013DAF6 File Offset: 0x0013BCF6
		public GZipOutputStream(Stream baseOutputStream)
			: this(baseOutputStream, 4096)
		{
		}

		// Token: 0x06001A63 RID: 6755 RVA: 0x0013DB04 File Offset: 0x0013BD04
		public GZipOutputStream(Stream baseOutputStream, int size)
			: base(baseOutputStream, new Deflater(-1, true), size)
		{
		}

		// Token: 0x06001A64 RID: 6756 RVA: 0x0013DB20 File Offset: 0x0013BD20
		public void SetLevel(int level)
		{
			if (level < 0 || level > 9)
			{
				throw new ArgumentOutOfRangeException("level", "Compression level must be 0-9");
			}
			this.deflater_.SetLevel(level);
		}

		// Token: 0x06001A65 RID: 6757 RVA: 0x0013DB47 File Offset: 0x0013BD47
		public int GetLevel()
		{
			return this.deflater_.GetLevel();
		}

		// Token: 0x06001A66 RID: 6758 RVA: 0x0013DB54 File Offset: 0x0013BD54
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (this.state_ == GZipOutputStream.OutputState.Header)
			{
				this.WriteHeader();
			}
			if (this.state_ != GZipOutputStream.OutputState.Footer)
			{
				throw new InvalidOperationException("Write not permitted in current state");
			}
			this.crc.Update(new ArraySegment<byte>(buffer, offset, count));
			base.Write(buffer, offset, count);
		}

		// Token: 0x06001A67 RID: 6759 RVA: 0x0013DB94 File Offset: 0x0013BD94
		protected override void Dispose(bool disposing)
		{
			try
			{
				this.Finish();
			}
			finally
			{
				if (this.state_ != GZipOutputStream.OutputState.Closed)
				{
					this.state_ = GZipOutputStream.OutputState.Closed;
					if (base.IsStreamOwner)
					{
						this.baseOutputStream_.Dispose();
					}
				}
			}
		}

		// Token: 0x06001A68 RID: 6760 RVA: 0x0013DBE0 File Offset: 0x0013BDE0
		public override void Finish()
		{
			if (this.state_ == GZipOutputStream.OutputState.Header)
			{
				this.WriteHeader();
			}
			if (this.state_ == GZipOutputStream.OutputState.Footer)
			{
				this.state_ = GZipOutputStream.OutputState.Finished;
				base.Finish();
				uint num = (uint)(this.deflater_.TotalIn & (long)((ulong)(-1)));
				uint num2 = (uint)(this.crc.Value & (long)((ulong)(-1)));
				byte[] array = new byte[]
				{
					(byte)num2,
					(byte)(num2 >> 8),
					(byte)(num2 >> 16),
					(byte)(num2 >> 24),
					(byte)num,
					(byte)(num >> 8),
					(byte)(num >> 16),
					(byte)(num >> 24)
				};
				this.baseOutputStream_.Write(array, 0, array.Length);
			}
		}

		// Token: 0x06001A69 RID: 6761 RVA: 0x0013DC80 File Offset: 0x0013BE80
		private void WriteHeader()
		{
			if (this.state_ == GZipOutputStream.OutputState.Header)
			{
				this.state_ = GZipOutputStream.OutputState.Footer;
				int num = (int)((DateTime.Now.Ticks - new DateTime(1970, 1, 1).Ticks) / 10000000L);
				byte[] array = new byte[] { 31, 139, 8, 0, 0, 0, 0, 0, 0, byte.MaxValue };
				array[4] = (byte)num;
				array[5] = (byte)(num >> 8);
				array[6] = (byte)(num >> 16);
				array[7] = (byte)(num >> 24);
				byte[] array2 = array;
				this.baseOutputStream_.Write(array2, 0, array2.Length);
			}
		}

		// Token: 0x04000F50 RID: 3920
		protected Crc32 crc = new Crc32();

		// Token: 0x04000F51 RID: 3921
		private GZipOutputStream.OutputState state_;

		// Token: 0x0200025B RID: 603
		private enum OutputState
		{
			// Token: 0x04001564 RID: 5476
			Header,
			// Token: 0x04001565 RID: 5477
			Footer,
			// Token: 0x04001566 RID: 5478
			Finished,
			// Token: 0x04001567 RID: 5479
			Closed
		}
	}
}
