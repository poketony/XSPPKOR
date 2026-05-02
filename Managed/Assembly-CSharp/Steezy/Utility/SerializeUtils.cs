using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Steezy.Utility
{
	// Token: 0x020000B4 RID: 180
	public static class SerializeUtils
	{
		// Token: 0x060010A7 RID: 4263 RVA: 0x00119360 File Offset: 0x00117560
		public static string Serialize<T>(T obj)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream();
			binaryFormatter.Serialize(memoryStream, obj);
			return Convert.ToBase64String(memoryStream.GetBuffer());
		}

		// Token: 0x060010A8 RID: 4264 RVA: 0x00119390 File Offset: 0x00117590
		public static T Deserialize<T>(string str)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(str));
			return (T)((object)binaryFormatter.Deserialize(memoryStream));
		}
	}
}
