using System;
using System.Collections.Generic;
using UnityEngine;

namespace Steezy.Builder
{
	// Token: 0x020000D6 RID: 214
	public class EnvironmentPlayerSettings
	{
		// Token: 0x06001291 RID: 4753 RVA: 0x0011E82D File Offset: 0x0011CA2D
		public static EnvironmentPlayerSettings Load()
		{
			EnvironmentPlayerSettings environmentPlayerSettings = null;
			string text = (Resources.Load("PlayerSettings") as TextAsset).text;
			return environmentPlayerSettings;
		}

		// Token: 0x04000A60 RID: 2656
		public string productName;

		// Token: 0x04000A61 RID: 2657
		public Dictionary<string, string> displayName;

		// Token: 0x04000A62 RID: 2658
		public string companyName;

		// Token: 0x04000A63 RID: 2659
		public string bundleVersion;

		// Token: 0x04000A64 RID: 2660
		public int bundleVersionCode;

		// Token: 0x04000A65 RID: 2661
		public string scriptingDefineSymbols;

		// Token: 0x04000A66 RID: 2662
		public bool debuggable;

		// Token: 0x04000A67 RID: 2663
		public EnvironmentPlayerSettings.AndroidSetting androidSetting;

		// Token: 0x04000A68 RID: 2664
		public EnvironmentPlayerSettings.IOSSetting iosSetting;

		// Token: 0x04000A69 RID: 2665
		public EnvironmentPlayerSettings.SwitchSetting switchSetting;

		// Token: 0x04000A6A RID: 2666
		public Dictionary<string, string> option;

		// Token: 0x02000234 RID: 564
		public class AndroidSetting
		{
			// Token: 0x040014B6 RID: 5302
			public string bundleIdentifier;

			// Token: 0x040014B7 RID: 5303
			public string outputName;

			// Token: 0x040014B8 RID: 5304
			public string keystoreName;

			// Token: 0x040014B9 RID: 5305
			public string keystorePass;

			// Token: 0x040014BA RID: 5306
			public string keyaliasName;

			// Token: 0x040014BB RID: 5307
			public string keyaliasPass;
		}

		// Token: 0x02000235 RID: 565
		public class IOSSetting
		{
			// Token: 0x040014BC RID: 5308
			public List<string> requiredFrameworkNameList;

			// Token: 0x040014BD RID: 5309
			public List<string> optionalFrameworkNameList;

			// Token: 0x040014BE RID: 5310
			public string bundleIdentifier;

			// Token: 0x040014BF RID: 5311
			public string outputName;

			// Token: 0x040014C0 RID: 5312
			public bool automaticSign;

			// Token: 0x040014C1 RID: 5313
			public string automaticSigningTeamId;

			// Token: 0x040014C2 RID: 5314
			public string provisioningProfileGuid;

			// Token: 0x040014C3 RID: 5315
			public string codeSignIdentity;

			// Token: 0x040014C4 RID: 5316
			public string URLScheme;

			// Token: 0x040014C5 RID: 5317
			public string copyDirectoryPath;

			// Token: 0x040014C6 RID: 5318
			public List<string> tbdList = new List<string>();

			// Token: 0x040014C7 RID: 5319
			public string[] linkerFlagArray;

			// Token: 0x040014C8 RID: 5320
			public string[] frameworkSearchPathArray = new string[] { "$(inherited)", "$(PROJECT_DIR)/Frameworks" };

			// Token: 0x040014C9 RID: 5321
			public bool enableBitCode;

			// Token: 0x040014CA RID: 5322
			public bool clangEnableKey;

			// Token: 0x040014CB RID: 5323
			public bool enableATS;

			// Token: 0x040014CC RID: 5324
			public bool enableModules;

			// Token: 0x040014CD RID: 5325
			public bool needToDeleteLaunchiImagesKey = true;

			// Token: 0x040014CE RID: 5326
			public Dictionary<string, string> usageDescriptions = new Dictionary<string, string>();

			// Token: 0x02000284 RID: 644
			[Serializable]
			public struct UsageDescriptionData
			{
				// Token: 0x04001577 RID: 5495
				public string key;

				// Token: 0x04001578 RID: 5496
				public string value;
			}
		}

		// Token: 0x02000236 RID: 566
		public class SwitchSetting
		{
			// Token: 0x040014CF RID: 5327
			public string outputName;

			// Token: 0x040014D0 RID: 5328
			public string applicationId;

			// Token: 0x040014D1 RID: 5329
			public string[] switchTitleNameArray;

			// Token: 0x040014D2 RID: 5330
			public string legalInfomationPath;
		}
	}
}
