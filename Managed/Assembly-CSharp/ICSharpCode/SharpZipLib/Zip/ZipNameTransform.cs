using System;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x0200015F RID: 351
	public class ZipNameTransform : INameTransform
	{
		// Token: 0x0600186E RID: 6254 RVA: 0x00134C3B File Offset: 0x00132E3B
		public ZipNameTransform()
		{
		}

		// Token: 0x0600186F RID: 6255 RVA: 0x00134C43 File Offset: 0x00132E43
		public ZipNameTransform(string trimPrefix)
		{
			this.TrimPrefix = trimPrefix;
		}

		// Token: 0x06001870 RID: 6256 RVA: 0x00134C54 File Offset: 0x00132E54
		static ZipNameTransform()
		{
			char[] invalidPathChars = Path.GetInvalidPathChars();
			int num = invalidPathChars.Length + 2;
			ZipNameTransform.InvalidEntryCharsRelaxed = new char[num];
			Array.Copy(invalidPathChars, 0, ZipNameTransform.InvalidEntryCharsRelaxed, 0, invalidPathChars.Length);
			ZipNameTransform.InvalidEntryCharsRelaxed[num - 1] = '*';
			ZipNameTransform.InvalidEntryCharsRelaxed[num - 2] = '?';
			num = invalidPathChars.Length + 4;
			ZipNameTransform.InvalidEntryChars = new char[num];
			Array.Copy(invalidPathChars, 0, ZipNameTransform.InvalidEntryChars, 0, invalidPathChars.Length);
			ZipNameTransform.InvalidEntryChars[num - 1] = ':';
			ZipNameTransform.InvalidEntryChars[num - 2] = '\\';
			ZipNameTransform.InvalidEntryChars[num - 3] = '*';
			ZipNameTransform.InvalidEntryChars[num - 4] = '?';
		}

		// Token: 0x06001871 RID: 6257 RVA: 0x00134CEB File Offset: 0x00132EEB
		public string TransformDirectory(string name)
		{
			name = this.TransformFile(name);
			if (name.Length > 0)
			{
				if (!name.EndsWith("/", StringComparison.Ordinal))
				{
					name += "/";
				}
				return name;
			}
			throw new ZipException("Cannot have an empty directory name");
		}

		// Token: 0x06001872 RID: 6258 RVA: 0x00134D28 File Offset: 0x00132F28
		public string TransformFile(string name)
		{
			if (name != null)
			{
				string text = name.ToLower();
				if (this.trimPrefix_ != null && text.IndexOf(this.trimPrefix_, StringComparison.Ordinal) == 0)
				{
					name = name.Substring(this.trimPrefix_.Length);
				}
				name = name.Replace("\\", "/");
				name = WindowsPathUtils.DropPathRoot(name);
				while (name.Length > 0)
				{
					if (name[0] != '/')
					{
						break;
					}
					name = name.Remove(0, 1);
				}
				while (name.Length > 0 && name[name.Length - 1] == '/')
				{
					name = name.Remove(name.Length - 1, 1);
				}
				for (int i = name.IndexOf("//", StringComparison.Ordinal); i >= 0; i = name.IndexOf("//", StringComparison.Ordinal))
				{
					name = name.Remove(i, 1);
				}
				name = ZipNameTransform.MakeValidName(name, '_');
			}
			else
			{
				name = string.Empty;
			}
			return name;
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06001873 RID: 6259 RVA: 0x00134E12 File Offset: 0x00133012
		// (set) Token: 0x06001874 RID: 6260 RVA: 0x00134E1A File Offset: 0x0013301A
		public string TrimPrefix
		{
			get
			{
				return this.trimPrefix_;
			}
			set
			{
				this.trimPrefix_ = value;
				if (this.trimPrefix_ != null)
				{
					this.trimPrefix_ = this.trimPrefix_.ToLower();
				}
			}
		}

		// Token: 0x06001875 RID: 6261 RVA: 0x00134E3C File Offset: 0x0013303C
		private static string MakeValidName(string name, char replacement)
		{
			int i = name.IndexOfAny(ZipNameTransform.InvalidEntryChars);
			if (i >= 0)
			{
				StringBuilder stringBuilder = new StringBuilder(name);
				while (i >= 0)
				{
					stringBuilder[i] = replacement;
					if (i >= name.Length)
					{
						i = -1;
					}
					else
					{
						i = name.IndexOfAny(ZipNameTransform.InvalidEntryChars, i + 1);
					}
				}
				name = stringBuilder.ToString();
			}
			if (name.Length > 65535)
			{
				throw new PathTooLongException();
			}
			return name;
		}

		// Token: 0x06001876 RID: 6262 RVA: 0x00134EA8 File Offset: 0x001330A8
		public static bool IsValidName(string name, bool relaxed)
		{
			bool flag = name != null;
			if (flag)
			{
				if (relaxed)
				{
					flag = name.IndexOfAny(ZipNameTransform.InvalidEntryCharsRelaxed) < 0;
				}
				else
				{
					flag = name.IndexOfAny(ZipNameTransform.InvalidEntryChars) < 0 && name.IndexOf('/') != 0;
				}
			}
			return flag;
		}

		// Token: 0x06001877 RID: 6263 RVA: 0x00134EEF File Offset: 0x001330EF
		public static bool IsValidName(string name)
		{
			return name != null && name.IndexOfAny(ZipNameTransform.InvalidEntryChars) < 0 && name.IndexOf('/') != 0;
		}

		// Token: 0x04000DE0 RID: 3552
		private string trimPrefix_;

		// Token: 0x04000DE1 RID: 3553
		private static readonly char[] InvalidEntryChars;

		// Token: 0x04000DE2 RID: 3554
		private static readonly char[] InvalidEntryCharsRelaxed;
	}
}
