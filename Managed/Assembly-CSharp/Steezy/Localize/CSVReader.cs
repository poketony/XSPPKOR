using System;
using System.Collections.Generic;
using Steezy.PageFlow;
using UnityEngine;

namespace Steezy.Localize
{
	// Token: 0x020000CF RID: 207
	public class CSVReader
	{
		// Token: 0x0600124F RID: 4687 RVA: 0x0011DA04 File Offset: 0x0011BC04
		public static List<List<string>> ReadCsv(string pathStr)
		{
			List<List<string>> list = new List<List<string>>();
			List<string> list2 = new List<string>();
			Object @object = AssetLoadUtil.LoadAsset<TextAsset>(pathStr, null);
			TextAsset textAsset;
			try
			{
				textAsset = (TextAsset)Object.Instantiate(@object);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				return list;
			}
			string text = textAsset.text;
			text = text.Trim(new char[] { '\r', '\n' });
			int length = text.Length;
			int num = 0;
			for (;;)
			{
				if (num >= length || (text[num] != ' ' && text[num] != '\t'))
				{
					int num2;
					string text2;
					if (num < length && text[num] == '"')
					{
						num2 = num;
						for (;;)
						{
							num2 = text.IndexOf('"', num2 + 1);
							if (num2 < 0)
							{
								goto Block_6;
							}
							if (num2 + 1 == length || text[num2 + 1] != '"')
							{
								break;
							}
							num2++;
						}
						text2 = text.Substring(num, num2 - num + 1);
						text2 = text2.Substring(1, text2.Length - 2).Replace("\"\"", "\"");
						num2++;
						while (num2 < length && text[num2] != ',')
						{
							if (text[num2] == '\n')
							{
								break;
							}
							num2++;
						}
					}
					else
					{
						num2 = num;
						while (num2 < length && text[num2] != ',' && text[num2] != '\n')
						{
							num2++;
						}
						text2 = text.Substring(num, num2 - num);
						text2 = text2.TrimEnd();
					}
					list2.Add(text2);
					if (num2 >= length || text[num2] == '\n')
					{
						list.Add(list2);
						list2 = new List<string>(list2.Count);
						if (num2 >= length)
						{
							return list;
						}
					}
					num = num2 + 1;
				}
				else
				{
					num++;
				}
			}
			Block_6:
			throw new UnityException("\"が不正");
		}
	}
}
