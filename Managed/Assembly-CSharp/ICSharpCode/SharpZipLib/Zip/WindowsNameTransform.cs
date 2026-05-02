using System;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip
{
	// Token: 0x0200013C RID: 316
	public class WindowsNameTransform : INameTransform
	{
		// Token: 0x060016E4 RID: 5860 RVA: 0x0012E70E File Offset: 0x0012C90E
		public WindowsNameTransform(string baseDirectory, bool allowParentTraversal = false)
		{
			if (baseDirectory == null)
			{
				throw new ArgumentNullException("baseDirectory", "Directory name is invalid");
			}
			this.BaseDirectory = baseDirectory;
			this.AllowParentTraversal = allowParentTraversal;
		}

		// Token: 0x060016E5 RID: 5861 RVA: 0x0012E740 File Offset: 0x0012C940
		public WindowsNameTransform()
		{
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060016E6 RID: 5862 RVA: 0x0012E750 File Offset: 0x0012C950
		// (set) Token: 0x060016E7 RID: 5863 RVA: 0x0012E758 File Offset: 0x0012C958
		public string BaseDirectory
		{
			get
			{
				return this._baseDirectory;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this._baseDirectory = Path.GetFullPath(value);
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060016E8 RID: 5864 RVA: 0x0012E774 File Offset: 0x0012C974
		// (set) Token: 0x060016E9 RID: 5865 RVA: 0x0012E77C File Offset: 0x0012C97C
		public bool AllowParentTraversal
		{
			get
			{
				return this._allowParentTraversal;
			}
			set
			{
				this._allowParentTraversal = value;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060016EA RID: 5866 RVA: 0x0012E785 File Offset: 0x0012C985
		// (set) Token: 0x060016EB RID: 5867 RVA: 0x0012E78D File Offset: 0x0012C98D
		public bool TrimIncomingPaths
		{
			get
			{
				return this._trimIncomingPaths;
			}
			set
			{
				this._trimIncomingPaths = value;
			}
		}

		// Token: 0x060016EC RID: 5868 RVA: 0x0012E798 File Offset: 0x0012C998
		public string TransformDirectory(string name)
		{
			name = this.TransformFile(name);
			if (name.Length > 0)
			{
				while (name.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
				{
					name = name.Remove(name.Length - 1, 1);
				}
				return name;
			}
			throw new InvalidNameException("Cannot have an empty directory name");
		}

		// Token: 0x060016ED RID: 5869 RVA: 0x0012E7EC File Offset: 0x0012C9EC
		public string TransformFile(string name)
		{
			if (name != null)
			{
				name = WindowsNameTransform.MakeValidName(name, this._replacementChar);
				if (this._trimIncomingPaths)
				{
					name = Path.GetFileName(name);
				}
				if (this._baseDirectory != null)
				{
					name = Path.Combine(this._baseDirectory, name);
					if (!this._allowParentTraversal && !Path.GetFullPath(name).StartsWith(this._baseDirectory, StringComparison.InvariantCultureIgnoreCase))
					{
						throw new InvalidNameException("Parent traversal in paths is not allowed");
					}
				}
			}
			else
			{
				name = string.Empty;
			}
			return name;
		}

		// Token: 0x060016EE RID: 5870 RVA: 0x0012E85F File Offset: 0x0012CA5F
		public static bool IsValidName(string name)
		{
			return name != null && name.Length <= 260 && string.Compare(name, WindowsNameTransform.MakeValidName(name, '_'), StringComparison.Ordinal) == 0;
		}

		// Token: 0x060016EF RID: 5871 RVA: 0x0012E888 File Offset: 0x0012CA88
		public static string MakeValidName(string name, char replacement)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			name = WindowsPathUtils.DropPathRoot(name.Replace("/", Path.DirectorySeparatorChar.ToString()));
			while (name.Length > 0)
			{
				if (name[0] != Path.DirectorySeparatorChar)
				{
					break;
				}
				name = name.Remove(0, 1);
			}
			while (name.Length > 0 && name[name.Length - 1] == Path.DirectorySeparatorChar)
			{
				name = name.Remove(name.Length - 1, 1);
			}
			int i;
			for (i = name.IndexOf(string.Format("{0}{0}", Path.DirectorySeparatorChar), StringComparison.Ordinal); i >= 0; i = name.IndexOf(string.Format("{0}{0}", Path.DirectorySeparatorChar), StringComparison.Ordinal))
			{
				name = name.Remove(i, 1);
			}
			i = name.IndexOfAny(WindowsNameTransform.InvalidEntryChars);
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
						i = name.IndexOfAny(WindowsNameTransform.InvalidEntryChars, i + 1);
					}
				}
				name = stringBuilder.ToString();
			}
			if (name.Length > 260)
			{
				throw new PathTooLongException();
			}
			return name;
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060016F0 RID: 5872 RVA: 0x0012E9B8 File Offset: 0x0012CBB8
		// (set) Token: 0x060016F1 RID: 5873 RVA: 0x0012E9C0 File Offset: 0x0012CBC0
		public char Replacement
		{
			get
			{
				return this._replacementChar;
			}
			set
			{
				for (int i = 0; i < WindowsNameTransform.InvalidEntryChars.Length; i++)
				{
					if (WindowsNameTransform.InvalidEntryChars[i] == value)
					{
						throw new ArgumentException("invalid path character");
					}
				}
				if (value == Path.DirectorySeparatorChar || value == Path.AltDirectorySeparatorChar)
				{
					throw new ArgumentException("invalid replacement character");
				}
				this._replacementChar = value;
			}
		}

		// Token: 0x04000D0C RID: 3340
		private const int MaxPath = 260;

		// Token: 0x04000D0D RID: 3341
		private string _baseDirectory;

		// Token: 0x04000D0E RID: 3342
		private bool _trimIncomingPaths;

		// Token: 0x04000D0F RID: 3343
		private char _replacementChar = '_';

		// Token: 0x04000D10 RID: 3344
		private bool _allowParentTraversal;

		// Token: 0x04000D11 RID: 3345
		private static readonly char[] InvalidEntryChars = new char[]
		{
			'"', '<', '>', '|', '\0', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005',
			'\u0006', '\a', '\b', '\t', '\n', '\v', '\f', '\r', '\u000e', '\u000f',
			'\u0010', '\u0011', '\u0012', '\u0013', '\u0014', '\u0015', '\u0016', '\u0017', '\u0018', '\u0019',
			'\u001a', '\u001b', '\u001c', '\u001d', '\u001e', '\u001f', '*', '?', ':'
		};
	}
}
