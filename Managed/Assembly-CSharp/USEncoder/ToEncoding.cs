using System;
using System.Collections.Generic;
using System.Text;

namespace USEncoder
{
	// Token: 0x0200006E RID: 110
	public class ToEncoding
	{
		// Token: 0x06000E83 RID: 3715 RVA: 0x00112218 File Offset: 0x00110418
		public static byte[] ToSJIS(string unicode_str)
		{
			byte[] bytes = Encoding.BigEndianUnicode.GetBytes(unicode_str);
			List<byte> list = new List<byte>();
			int num = 0;
			while (num < bytes.Length && bytes.Length > num + 1)
			{
				ushort code = USEncoder.ToSJIS.GetCode((ushort)(bytes[num] << 8) + (ushort)bytes[++num]);
				byte b = (byte)(code >> 8);
				byte b2 = (byte)(code & 255);
				if ((b >= 129 && b <= 159) || (b >= 224 && b <= 234))
				{
					list.Add(b);
					list.Add(b2);
				}
				else
				{
					list.Add(b2);
				}
				num++;
			}
			return list.ToArray();
		}

		// Token: 0x06000E84 RID: 3716 RVA: 0x001122B0 File Offset: 0x001104B0
		public static string ToUnicode(byte[] sjis_bytes)
		{
			List<byte> list = new List<byte>();
			for (int i = 0; i < sjis_bytes.Length; i++)
			{
				ushort num;
				if ((sjis_bytes[i] >= 129 && sjis_bytes[i] <= 159) || (sjis_bytes[i] >= 224 && sjis_bytes[i] <= 234))
				{
					if (sjis_bytes.Length <= i + 1)
					{
						break;
					}
					num = (ushort)(sjis_bytes[i] << 8);
					num += (ushort)sjis_bytes[++i];
				}
				else
				{
					num = (ushort)sjis_bytes[i];
				}
				ushort code = USEncoder.ToUnicode.GetCode(num);
				byte b = (byte)(code >> 8);
				byte b2 = (byte)(code & 255);
				list.Add(b2);
				list.Add(b);
			}
			return Encoding.Unicode.GetString(list.ToArray());
		}
	}
}
