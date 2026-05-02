using System;
using System.Text;

namespace USEncoder
{
	// Token: 0x0200006D RID: 109
	internal class Program
	{
		// Token: 0x06000E81 RID: 3713 RVA: 0x0011219C File Offset: 0x0011039C
		private static void Main(string[] args)
		{
			byte[] array = ToEncoding.ToSJIS("こんにちは日本チルドレンchildren");
			byte[] array2 = Encoding.Convert(Encoding.GetEncoding(932), Encoding.Unicode, array);
			Console.WriteLine(Encoding.Unicode.GetString(array2));
			for (int i = 0; i < array.Length; i++)
			{
				Console.WriteLine("{0:x}", array[i]);
			}
			Console.WriteLine(ToEncoding.ToUnicode(ToEncoding.ToSJIS("こんにちは日本チルドレンchildren")));
		}

		// Token: 0x040008C5 RID: 2245
		private const string str = "こんにちは日本チルドレンchildren";
	}
}
