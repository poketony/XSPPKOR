using System;
using System.Collections.Generic;
using Steezy.Utility;
using UnityEngine;

namespace Socotra.Device
{
	// Token: 0x02000133 RID: 307
	public class PhoneSystem : MonoBehaviour
	{
		// Token: 0x06001697 RID: 5783 RVA: 0x0012DA5D File Offset: 0x0012BC5D
		private void Start()
		{
		}

		// Token: 0x06001698 RID: 5784 RVA: 0x0012DA5F File Offset: 0x0012BC5F
		private void Update()
		{
		}

		// Token: 0x06001699 RID: 5785 RVA: 0x0012DA61 File Offset: 0x0012BC61
		public static void StaticInitializer()
		{
			PhoneSystem.attributes = new Dictionary<int, int>();
		}

		// Token: 0x0600169A RID: 5786 RVA: 0x0012DA70 File Offset: 0x0012BC70
		public static void SetAttribute(int device, int attr)
		{
			PhoneSystem.attributes[device] = attr;
			if (device == 1)
			{
				switch (attr)
				{
				case 0:
					SingletonBehaviour<StVibrationManager>.Instance.StopVibration();
					return;
				case 1:
					SingletonBehaviour<StVibrationManager>.Instance.StartVibration(StVibrationManager.Type.High, -1);
					return;
				case 10:
					SingletonBehaviour<StVibrationManager>.Instance.StartVibration(StVibrationManager.Type.Data, 0);
					return;
				case 11:
					SingletonBehaviour<StVibrationManager>.Instance.StartVibration(StVibrationManager.Type.Data, 1);
					return;
				case 12:
					SingletonBehaviour<StVibrationManager>.Instance.StartVibration(StVibrationManager.Type.Data, 2);
					return;
				case 13:
					SingletonBehaviour<StVibrationManager>.Instance.StartVibration(StVibrationManager.Type.Data, 3);
					return;
				case 14:
					SingletonBehaviour<StVibrationManager>.Instance.StartVibration(StVibrationManager.Type.Data, 4);
					return;
				case 15:
					SingletonBehaviour<StVibrationManager>.Instance.StartVibration(StVibrationManager.Type.Data, 5);
					return;
				case 16:
					SingletonBehaviour<StVibrationManager>.Instance.StartVibration(StVibrationManager.Type.Data, 6);
					return;
				case 17:
					SingletonBehaviour<StVibrationManager>.Instance.StartVibration(StVibrationManager.Type.Data, 7);
					return;
				}
				SingletonBehaviour<StVibrationManager>.Instance.StopVibration();
			}
		}

		// Token: 0x0600169B RID: 5787 RVA: 0x0012DB6D File Offset: 0x0012BD6D
		public static int GetAttribute(int device)
		{
			if (PhoneSystem.attributes.ContainsKey(device))
			{
				return PhoneSystem.attributes[device];
			}
			if (device == 1)
			{
				return 0;
			}
			return -1;
		}

		// Token: 0x0600169C RID: 5788 RVA: 0x0012DB90 File Offset: 0x0012BD90
		public static bool IsAvailable(int device)
		{
			bool flag = false;
			if (device == 1)
			{
				flag = true;
			}
			return flag;
		}

		// Token: 0x04000CDF RID: 3295
		public const int DEV_VIBRATOR = 1;

		// Token: 0x04000CE0 RID: 3296
		public const int ATTR_VIBRATOR_ON = 1;

		// Token: 0x04000CE1 RID: 3297
		public const int ATTR_VIBRATOR_OFF = 0;

		// Token: 0x04000CE2 RID: 3298
		public const int ATTR_VIBRATOR_TYPE_1 = 2;

		// Token: 0x04000CE3 RID: 3299
		public const int ATTR_VIBRATOR_TYPE_2 = 3;

		// Token: 0x04000CE4 RID: 3300
		public const int ATTR_VIBRATOR_OPT_1 = 10;

		// Token: 0x04000CE5 RID: 3301
		public const int ATTR_VIBRATOR_OPT_2 = 11;

		// Token: 0x04000CE6 RID: 3302
		public const int ATTR_VIBRATOR_OPT_3 = 12;

		// Token: 0x04000CE7 RID: 3303
		public const int ATTR_VIBRATOR_OPT_4 = 13;

		// Token: 0x04000CE8 RID: 3304
		public const int ATTR_VIBRATOR_OPT_5 = 14;

		// Token: 0x04000CE9 RID: 3305
		public const int ATTR_VIBRATOR_OPT_6 = 15;

		// Token: 0x04000CEA RID: 3306
		public const int ATTR_VIBRATOR_OPT_7 = 16;

		// Token: 0x04000CEB RID: 3307
		public const int ATTR_VIBRATOR_OPT_8 = 17;

		// Token: 0x04000CEC RID: 3308
		public const int DEV_BACKLIGHT = 0;

		// Token: 0x04000CED RID: 3309
		public const int ATTR_BACKLIGHT_ON = 1;

		// Token: 0x04000CEE RID: 3310
		public const int ATTR_BACKLIGHT_OFF = 0;

		// Token: 0x04000CEF RID: 3311
		private static Dictionary<int, int> attributes;
	}
}
