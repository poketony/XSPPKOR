using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Core
{
	// Token: 0x0200019B RID: 411
	public sealed class StreamUtils
	{
		// Token: 0x06001AF4 RID: 6900 RVA: 0x0013F17E File Offset: 0x0013D37E
		public static void ReadFully(Stream stream, byte[] buffer)
		{
			StreamUtils.ReadFully(stream, buffer, 0, buffer.Length);
		}

		// Token: 0x06001AF5 RID: 6901 RVA: 0x0013F18C File Offset: 0x0013D38C
		public static void ReadFully(Stream stream, byte[] buffer, int offset, int count)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0 || offset > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0 || offset + count > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			while (count > 0)
			{
				int num = stream.Read(buffer, offset, count);
				if (num <= 0)
				{
					throw new EndOfStreamException();
				}
				offset += num;
				count -= num;
			}
		}

		// Token: 0x06001AF6 RID: 6902 RVA: 0x0013F204 File Offset: 0x0013D404
		public static int ReadRequestedBytes(Stream stream, byte[] buffer, int offset, int count)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0 || offset > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0 || offset + count > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			int num = 0;
			while (count > 0)
			{
				int num2 = stream.Read(buffer, offset, count);
				if (num2 <= 0)
				{
					break;
				}
				offset += num2;
				count -= num2;
				num += num2;
			}
			return num;
		}

		// Token: 0x06001AF7 RID: 6903 RVA: 0x0013F280 File Offset: 0x0013D480
		public static void Copy(Stream source, Stream destination, byte[] buffer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (buffer.Length < 128)
			{
				throw new ArgumentException("Buffer is too small", "buffer");
			}
			bool flag = true;
			while (flag)
			{
				int num = source.Read(buffer, 0, buffer.Length);
				if (num > 0)
				{
					destination.Write(buffer, 0, num);
				}
				else
				{
					destination.Flush();
					flag = false;
				}
			}
		}

		// Token: 0x06001AF8 RID: 6904 RVA: 0x0013F2FB File Offset: 0x0013D4FB
		public static void Copy(Stream source, Stream destination, byte[] buffer, ProgressHandler progressHandler, TimeSpan updateInterval, object sender, string name)
		{
			StreamUtils.Copy(source, destination, buffer, progressHandler, updateInterval, sender, name, -1L);
		}

		// Token: 0x06001AF9 RID: 6905 RVA: 0x0013F310 File Offset: 0x0013D510
		public static void Copy(Stream source, Stream destination, byte[] buffer, ProgressHandler progressHandler, TimeSpan updateInterval, object sender, string name, long fixedTarget)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (buffer.Length < 128)
			{
				throw new ArgumentException("Buffer is too small", "buffer");
			}
			if (progressHandler == null)
			{
				throw new ArgumentNullException("progressHandler");
			}
			bool flag = true;
			DateTime dateTime = DateTime.Now;
			long num = 0L;
			long num2 = 0L;
			if (fixedTarget >= 0L)
			{
				num2 = fixedTarget;
			}
			else if (source.CanSeek)
			{
				num2 = source.Length - source.Position;
			}
			ProgressEventArgs progressEventArgs = new ProgressEventArgs(name, num, num2);
			progressHandler(sender, progressEventArgs);
			bool flag2 = true;
			while (flag)
			{
				int num3 = source.Read(buffer, 0, buffer.Length);
				if (num3 > 0)
				{
					num += (long)num3;
					flag2 = false;
					destination.Write(buffer, 0, num3);
				}
				else
				{
					destination.Flush();
					flag = false;
				}
				if (DateTime.Now - dateTime > updateInterval)
				{
					flag2 = true;
					dateTime = DateTime.Now;
					progressEventArgs = new ProgressEventArgs(name, num, num2);
					progressHandler(sender, progressEventArgs);
					flag = progressEventArgs.ContinueRunning;
				}
			}
			if (!flag2)
			{
				progressEventArgs = new ProgressEventArgs(name, num, num2);
				progressHandler(sender, progressEventArgs);
			}
		}

		// Token: 0x06001AFA RID: 6906 RVA: 0x0013F43D File Offset: 0x0013D63D
		private StreamUtils()
		{
		}
	}
}
