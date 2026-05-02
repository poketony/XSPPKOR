using System;

namespace ICSharpCode.SharpZipLib.Core
{
	// Token: 0x0200019C RID: 412
	public abstract class WindowsPathUtils
	{
		// Token: 0x06001AFB RID: 6907 RVA: 0x0013F445 File Offset: 0x0013D645
		internal WindowsPathUtils()
		{
		}

		// Token: 0x06001AFC RID: 6908 RVA: 0x0013F450 File Offset: 0x0013D650
		public static string DropPathRoot(string path)
		{
			string text = path;
			if (!string.IsNullOrEmpty(path))
			{
				if (path[0] == '\\' || path[0] == '/')
				{
					if (path.Length > 1 && (path[1] == '\\' || path[1] == '/'))
					{
						int num = 2;
						int num2 = 2;
						while (num <= path.Length && ((path[num] != '\\' && path[num] != '/') || --num2 > 0))
						{
							num++;
						}
						num++;
						if (num < path.Length)
						{
							text = path.Substring(num);
						}
						else
						{
							text = "";
						}
					}
				}
				else if (path.Length > 1 && path[1] == ':')
				{
					int num3 = 2;
					if (path.Length > 2 && (path[2] == '\\' || path[2] == '/'))
					{
						num3 = 3;
					}
					text = text.Remove(0, num3);
				}
			}
			return text;
		}
	}
}
