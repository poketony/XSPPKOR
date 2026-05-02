using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Steezy.Utility;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000E5 RID: 229
	public class ScratchPadManager : SingletonBehaviour<ScratchPadManager>
	{
		// Token: 0x060012E1 RID: 4833 RVA: 0x0011F1AF File Offset: 0x0011D3AF
		private void Awake()
		{
			this.scratchPads = this.scratchPadRoot.GetComponentsInChildren<ScratchPad>();
		}

		// Token: 0x060012E2 RID: 4834 RVA: 0x0011F1C2 File Offset: 0x0011D3C2
		private void Start()
		{
		}

		// Token: 0x060012E3 RID: 4835 RVA: 0x0011F1C4 File Offset: 0x0011D3C4
		private void Update()
		{
		}

		// Token: 0x060012E4 RID: 4836 RVA: 0x0011F1C8 File Offset: 0x0011D3C8
		public ScratchPad GetScratchPad(int number)
		{
			foreach (ScratchPad scratchPad in this.scratchPads)
			{
				if (scratchPad.Number == number)
				{
					return scratchPad;
				}
			}
			return null;
		}

		// Token: 0x060012E5 RID: 4837 RVA: 0x0011F1FC File Offset: 0x0011D3FC
		public ScratchPadData GetScratchPadData(string url)
		{
			if (url.StartsWith("scratchpad:///"))
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				Regex regex = new Regex("scratchpad:///(?<index>[0-9]+)");
				Regex regex2 = new Regex(";pos=(?<pos>[0-9]+)");
				Regex regex3 = new Regex("length=(?<length>[0-9]+)");
				Match match = regex.Match(url);
				Match match2 = regex2.Match(url);
				Match match3 = regex3.Match(url);
				string text = match.Groups["index"].Value;
				if (text != null && text.Length > 0)
				{
					num = int.Parse(text);
				}
				text = match2.Groups["pos"].Value;
				if (text != null && text.Length > 0)
				{
					num2 = int.Parse(text);
				}
				text = match3.Groups["length"].Value;
				if (text != null && text.Length > 0)
				{
					num3 = int.Parse(text);
				}
				ScratchPad scratchPad = this.GetScratchPad(num);
				if (scratchPad != null)
				{
					if (scratchPad.Table.Count == 1 && num2 == 0)
					{
						scratchPad.Table[num2].Offset = num2;
						scratchPad.Table[num2].Length = num3;
						return scratchPad.Table[num2];
					}
					try
					{
						ScratchPadData scratchPadData = scratchPad.Table[num2];
						if (scratchPadData != null)
						{
							scratchPadData.Offset = 0;
							scratchPadData.Length = num3;
							return scratchPadData;
						}
					}
					catch (KeyNotFoundException)
					{
						int num4 = 0;
						int[] array = new int[scratchPad.Table.Keys.Count];
						scratchPad.Table.Keys.CopyTo(array, 0);
						Array.Sort<int>(array);
						foreach (int num5 in scratchPad.Table.Keys)
						{
							if (num5 > num2)
							{
								break;
							}
							num4 = num5;
						}
						ScratchPadData scratchPadData2 = scratchPad.Table[num4];
						if (scratchPadData2 != null)
						{
							scratchPadData2.Offset = num2 - num4;
							scratchPadData2.Length = num3;
							return scratchPadData2;
						}
					}
					catch (Exception ex)
					{
						string text2 = "Exception:";
						Exception ex2 = ex;
						Debug.LogError(text2 + ((ex2 != null) ? ex2.ToString() : null));
						return null;
					}
				}
			}
			return null;
		}

		// Token: 0x04000A81 RID: 2689
		[SerializeField]
		private ScratchPad[] scratchPads;

		// Token: 0x04000A82 RID: 2690
		[SerializeField]
		private GameObject scratchPadRoot;
	}
}
