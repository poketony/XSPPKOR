using System;
using System.Text;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x02000161 RID: 353
	public static class ZipStrings
	{
		// Token: 0x0600188C RID: 6284 RVA: 0x00135E18 File Offset: 0x00134018
		static ZipStrings()
		{
			try
			{
				int num = Encoding.GetEncoding(0).CodePage;
				ZipStrings.SystemDefaultCodePage = ((num == 1 || num == 2 || num == 3 || num == 42) ? 437 : num);
			}
			catch
			{
				ZipStrings.SystemDefaultCodePage = 437;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600188D RID: 6285 RVA: 0x00135E74 File Offset: 0x00134074
		// (set) Token: 0x0600188E RID: 6286 RVA: 0x00135E8E File Offset: 0x0013408E
		public static int CodePage
		{
			get
			{
				if (ZipStrings.codePage != -1)
				{
					return ZipStrings.codePage;
				}
				return Encoding.UTF8.CodePage;
			}
			set
			{
				if (value < 0 || value > 65535 || value == 1 || value == 2 || value == 3 || value == 42)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				ZipStrings.codePage = value;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x0600188F RID: 6287 RVA: 0x00135EBE File Offset: 0x001340BE
		public static int SystemDefaultCodePage { get; }

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06001890 RID: 6288 RVA: 0x00135EC5 File Offset: 0x001340C5
		// (set) Token: 0x06001891 RID: 6289 RVA: 0x00135ED8 File Offset: 0x001340D8
		public static bool UseUnicode
		{
			get
			{
				return ZipStrings.codePage == Encoding.UTF8.CodePage;
			}
			set
			{
				if (value)
				{
					ZipStrings.codePage = Encoding.UTF8.CodePage;
					return;
				}
				ZipStrings.codePage = ZipStrings.SystemDefaultCodePage;
			}
		}

		// Token: 0x06001892 RID: 6290 RVA: 0x00135EF7 File Offset: 0x001340F7
		public static string ConvertToString(byte[] data, int count)
		{
			if (data != null)
			{
				return Encoding.GetEncoding(ZipStrings.CodePage).GetString(data, 0, count);
			}
			return string.Empty;
		}

		// Token: 0x06001893 RID: 6291 RVA: 0x00135F14 File Offset: 0x00134114
		public static string ConvertToString(byte[] data)
		{
			return ZipStrings.ConvertToString(data, data.Length);
		}

		// Token: 0x06001894 RID: 6292 RVA: 0x00135F1F File Offset: 0x0013411F
		private static Encoding EncodingFromFlag(int flags)
		{
			if ((flags & 2048) == 0)
			{
				return Encoding.GetEncoding((ZipStrings.codePage == -1) ? ZipStrings.SystemDefaultCodePage : ZipStrings.codePage);
			}
			return Encoding.UTF8;
		}

		// Token: 0x06001895 RID: 6293 RVA: 0x00135F49 File Offset: 0x00134149
		public static string ConvertToStringExt(int flags, byte[] data, int count)
		{
			if (data != null)
			{
				return ZipStrings.EncodingFromFlag(flags).GetString(data, 0, count);
			}
			return string.Empty;
		}

		// Token: 0x06001896 RID: 6294 RVA: 0x00135F62 File Offset: 0x00134162
		public static string ConvertToStringExt(int flags, byte[] data)
		{
			return ZipStrings.ConvertToStringExt(flags, data, data.Length);
		}

		// Token: 0x06001897 RID: 6295 RVA: 0x00135F6E File Offset: 0x0013416E
		public static byte[] ConvertToArray(string str)
		{
			if (str != null)
			{
				return Encoding.GetEncoding(ZipStrings.CodePage).GetBytes(str);
			}
			return new byte[0];
		}

		// Token: 0x06001898 RID: 6296 RVA: 0x00135F8A File Offset: 0x0013418A
		public static byte[] ConvertToArray(int flags, string str)
		{
			if (!string.IsNullOrEmpty(str))
			{
				return ZipStrings.EncodingFromFlag(flags).GetBytes(str);
			}
			return new byte[0];
		}

		// Token: 0x04000DEF RID: 3567
		private static int codePage = -1;

		// Token: 0x04000DF0 RID: 3568
		private const int AutomaticCodePage = -1;

		// Token: 0x04000DF1 RID: 3569
		private const int FallbackCodePage = 437;
	}
}
