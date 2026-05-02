using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ICSharpCode.SharpZipLib.Core
{
	// Token: 0x02000197 RID: 407
	public class NameFilter : IScanFilter
	{
		// Token: 0x06001AD7 RID: 6871 RVA: 0x0013EAE6 File Offset: 0x0013CCE6
		public NameFilter(string filter)
		{
			this.filter_ = filter;
			this.inclusions_ = new List<Regex>();
			this.exclusions_ = new List<Regex>();
			this.Compile();
		}

		// Token: 0x06001AD8 RID: 6872 RVA: 0x0013EB14 File Offset: 0x0013CD14
		public static bool IsValidExpression(string expression)
		{
			bool flag = true;
			try
			{
				new Regex(expression, RegexOptions.IgnoreCase | RegexOptions.Singleline);
			}
			catch (ArgumentException)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x06001AD9 RID: 6873 RVA: 0x0013EB44 File Offset: 0x0013CD44
		public static bool IsValidFilterExpression(string toTest)
		{
			bool flag = true;
			try
			{
				if (toTest != null)
				{
					string[] array = NameFilter.SplitQuoted(toTest);
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i] != null && array[i].Length > 0)
						{
							string text;
							if (array[i][0] == '+')
							{
								text = array[i].Substring(1, array[i].Length - 1);
							}
							else if (array[i][0] == '-')
							{
								text = array[i].Substring(1, array[i].Length - 1);
							}
							else
							{
								text = array[i];
							}
							new Regex(text, RegexOptions.IgnoreCase | RegexOptions.Singleline);
						}
					}
				}
			}
			catch (ArgumentException)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x06001ADA RID: 6874 RVA: 0x0013EBE8 File Offset: 0x0013CDE8
		public static string[] SplitQuoted(string original)
		{
			char c = '\\';
			char[] array = new char[] { ';' };
			List<string> list = new List<string>();
			if (!string.IsNullOrEmpty(original))
			{
				int i = -1;
				StringBuilder stringBuilder = new StringBuilder();
				while (i < original.Length)
				{
					i++;
					if (i >= original.Length)
					{
						list.Add(stringBuilder.ToString());
					}
					else if (original[i] == c)
					{
						i++;
						if (i >= original.Length)
						{
							throw new ArgumentException("Missing terminating escape character", "original");
						}
						if (Array.IndexOf<char>(array, original[i]) < 0)
						{
							stringBuilder.Append(c);
						}
						stringBuilder.Append(original[i]);
					}
					else if (Array.IndexOf<char>(array, original[i]) >= 0)
					{
						list.Add(stringBuilder.ToString());
						stringBuilder.Length = 0;
					}
					else
					{
						stringBuilder.Append(original[i]);
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x06001ADB RID: 6875 RVA: 0x0013ECDB File Offset: 0x0013CEDB
		public override string ToString()
		{
			return this.filter_;
		}

		// Token: 0x06001ADC RID: 6876 RVA: 0x0013ECE4 File Offset: 0x0013CEE4
		public bool IsIncluded(string name)
		{
			bool flag = false;
			if (this.inclusions_.Count == 0)
			{
				flag = true;
			}
			else
			{
				using (List<Regex>.Enumerator enumerator = this.inclusions_.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.IsMatch(name))
						{
							flag = true;
							break;
						}
					}
				}
			}
			return flag;
		}

		// Token: 0x06001ADD RID: 6877 RVA: 0x0013ED50 File Offset: 0x0013CF50
		public bool IsExcluded(string name)
		{
			bool flag = false;
			using (List<Regex>.Enumerator enumerator = this.exclusions_.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsMatch(name))
					{
						flag = true;
						break;
					}
				}
			}
			return flag;
		}

		// Token: 0x06001ADE RID: 6878 RVA: 0x0013EDAC File Offset: 0x0013CFAC
		public bool IsMatch(string name)
		{
			return this.IsIncluded(name) && !this.IsExcluded(name);
		}

		// Token: 0x06001ADF RID: 6879 RVA: 0x0013EDC4 File Offset: 0x0013CFC4
		private void Compile()
		{
			if (this.filter_ == null)
			{
				return;
			}
			string[] array = NameFilter.SplitQuoted(this.filter_);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null && array[i].Length > 0)
				{
					bool flag = array[i][0] != '-';
					string text;
					if (array[i][0] == '+')
					{
						text = array[i].Substring(1, array[i].Length - 1);
					}
					else if (array[i][0] == '-')
					{
						text = array[i].Substring(1, array[i].Length - 1);
					}
					else
					{
						text = array[i];
					}
					if (flag)
					{
						this.inclusions_.Add(new Regex(text, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline));
					}
					else
					{
						this.exclusions_.Add(new Regex(text, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline));
					}
				}
			}
		}

		// Token: 0x04000F7D RID: 3965
		private string filter_;

		// Token: 0x04000F7E RID: 3966
		private List<Regex> inclusions_;

		// Token: 0x04000F7F RID: 3967
		private List<Regex> exclusions_;
	}
}
