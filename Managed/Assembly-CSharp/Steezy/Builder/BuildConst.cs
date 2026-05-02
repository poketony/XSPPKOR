using System;

namespace Steezy.Builder
{
	// Token: 0x020000D4 RID: 212
	public class BuildConst
	{
		// Token: 0x04000A51 RID: 2641
		public const string STEEZY_BUILD_PATH = "/Assets/Steezy/Builder";

		// Token: 0x04000A52 RID: 2642
		public const string STEEZY_RESOURCES_PATH = "/Assets/Steezy/Builder/Resources";

		// Token: 0x04000A53 RID: 2643
		public const string STEEZY_ENVIROMENTASSETS_PATH = "/EnvironmentAssets";

		// Token: 0x04000A54 RID: 2644
		public const string PLAYER_SETTING_FILE_NAME = "/PlayerSettings.json";

		// Token: 0x04000A55 RID: 2645
		public const string PLAYER_SETTING_FILE_PATH = "/Assets/Steezy/Builder/Resources/PlayerSettings.json";

		// Token: 0x04000A56 RID: 2646
		public const string BUILD_VERSION_NAME = "BuildVersion";

		// Token: 0x04000A57 RID: 2647
		public const string CURRENTENVIROMENT_EDITORPREFS_NAME = "com.gmodecorp.steezybuild.currentEnvironment";

		// Token: 0x04000A58 RID: 2648
		public static string[] SteezyEnvironmentCopyAssets = new string[] { "Icons", "Resources" };

		// Token: 0x04000A59 RID: 2649
		public const string BUILD_BATCH_ARGS_NAME = "BuildBatchArgs";

		// Token: 0x04000A5A RID: 2650
		public const string BUILD_BATCH_ARGS_PLATFORM_NAME = "platform";

		// Token: 0x04000A5B RID: 2651
		public const string BUILD_BATCH_ARGS_ENVIRONMENT_NAME = "environment";

		// Token: 0x04000A5C RID: 2652
		public const string BUILD_BATCH_ARGS_VERSIONUP_NAME = "versionup";

		// Token: 0x04000A5D RID: 2653
		public const string UPDATE_BUILD_VERSIONS_BATICH_FILE_NAME_WINDOWS = "update_build_versions.vbs";

		// Token: 0x04000A5E RID: 2654
		public const string UPDATE_BUILD_VERSIONS_BATICH_FILE_NAME_OSX = "update_build_versions.sh";
	}
}
