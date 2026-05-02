using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Core
{
	// Token: 0x02000198 RID: 408
	public class PathFilter : IScanFilter
	{
		// Token: 0x06001AE0 RID: 6880 RVA: 0x0013EE94 File Offset: 0x0013D094
		public PathFilter(string filter)
		{
			this.nameFilter_ = new NameFilter(filter);
		}

		// Token: 0x06001AE1 RID: 6881 RVA: 0x0013EEA8 File Offset: 0x0013D0A8
		public virtual bool IsMatch(string name)
		{
			bool flag = false;
			if (name != null)
			{
				string text = ((name.Length > 0) ? Path.GetFullPath(name) : "");
				flag = this.nameFilter_.IsMatch(text);
			}
			return flag;
		}

		// Token: 0x04000F80 RID: 3968
		private readonly NameFilter nameFilter_;
	}
}
