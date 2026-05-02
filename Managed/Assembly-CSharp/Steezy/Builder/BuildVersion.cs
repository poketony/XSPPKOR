using System;
using UnityEngine;

namespace Steezy.Builder
{
	// Token: 0x020000D5 RID: 213
	public class BuildVersion
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06001288 RID: 4744 RVA: 0x0011E7A8 File Offset: 0x0011C9A8
		// (set) Token: 0x06001289 RID: 4745 RVA: 0x0011E7C1 File Offset: 0x0011C9C1
		public static int VersionNumber
		{
			get
			{
				if (BuildVersion.versionNumber < 0)
				{
					BuildVersion.versionNumber = BuildVersion.ReadVersionNumber();
				}
				return BuildVersion.versionNumber;
			}
			private set
			{
				if (BuildVersion.versionNumber != value)
				{
					BuildVersion.versionNumber = value;
					BuildVersion.WriteVersionNumber();
				}
			}
		}

		// Token: 0x0600128A RID: 4746 RVA: 0x0011E7D6 File Offset: 0x0011C9D6
		private static int ReadVersionNumber()
		{
			return BuildVersion.Read("BuildVersion");
		}

		// Token: 0x0600128B RID: 4747 RVA: 0x0011E7E2 File Offset: 0x0011C9E2
		private static int Read(string fileName)
		{
			return int.Parse(Resources.Load<TextAsset>(fileName).text);
		}

		// Token: 0x0600128C RID: 4748 RVA: 0x0011E7F4 File Offset: 0x0011C9F4
		private static void WriteVersionNumber()
		{
			BuildVersion.Write("BuildVersion", BuildVersion.versionNumber);
		}

		// Token: 0x0600128D RID: 4749 RVA: 0x0011E805 File Offset: 0x0011CA05
		private static void Write(string fileName, int version)
		{
			Debug.Log("BuildVersion.Write() is <clor='red'>Editor Only</color>");
		}

		// Token: 0x0600128E RID: 4750 RVA: 0x0011E811 File Offset: 0x0011CA11
		public static void IncreaseVersion()
		{
			Debug.Log("BuildVersion.IncreaseAndroidVersion() is <clor='red'>Editor Only</color>");
		}

		// Token: 0x04000A5F RID: 2655
		private static int versionNumber = -1;
	}
}
