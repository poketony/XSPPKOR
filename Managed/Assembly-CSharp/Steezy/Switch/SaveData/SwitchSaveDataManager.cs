using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Steezy.Switch.SaveData
{
	// Token: 0x020000B8 RID: 184
	public static class SwitchSaveDataManager
	{
		// Token: 0x060010BE RID: 4286 RVA: 0x00119AF1 File Offset: 0x00117CF1
		public static void Init(string mountName)
		{
		}

		// Token: 0x060010BF RID: 4287 RVA: 0x00119AF3 File Offset: 0x00117CF3
		public static void DeleteSave()
		{
			Debug.Log("--- delete save. ---");
		}

		// Token: 0x060010C0 RID: 4288 RVA: 0x00119AFF File Offset: 0x00117CFF
		public static void Save<T>(T saveData)
		{
			Debug.Log("--- save start. ---");
			Debug.Log("--- save end. ---");
		}

		// Token: 0x060010C1 RID: 4289 RVA: 0x00119B18 File Offset: 0x00117D18
		public static T Load<T>()
		{
			Debug.Log("--- load start. ---");
			T t = default(T);
			Debug.Log("--- load end. ---");
			return t;
		}

		// Token: 0x060010C2 RID: 4290 RVA: 0x00119B44 File Offset: 0x00117D44
		private static string Serialize<T>(T obj)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream();
			binaryFormatter.Serialize(memoryStream, obj);
			return Convert.ToBase64String(memoryStream.GetBuffer());
		}

		// Token: 0x060010C3 RID: 4291 RVA: 0x00119B74 File Offset: 0x00117D74
		private static T Deserialize<T>(string str)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(str));
			return (T)((object)binaryFormatter.Deserialize(memoryStream));
		}

		// Token: 0x040009B7 RID: 2487
		private const string fileName = "AppBaseSaveData";
	}
}
