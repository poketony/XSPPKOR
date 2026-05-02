using System;
using System.Collections.Generic;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200000A RID: 10
public class CharacterInputKeyManager : SingletonBehaviour<CharacterInputKeyManager>
{
	// Token: 0x06000032 RID: 50 RVA: 0x00002D80 File Offset: 0x00000F80
	public void Init()
	{
		this.keyItemObjs = new List<GameObject>();
		this.CreateKanjiKeyMapPagingList();
		List<string> targetKeyPattern = CharacterInputKeySettings.GetTargetKeyPattern();
		if (targetKeyPattern.Count > 0)
		{
			this.ChangeKey(targetKeyPattern[0], true);
		}
		GameObject gameObject;
		if (targetKeyPattern.Count > 1)
		{
			foreach (string text in targetKeyPattern)
			{
				gameObject = InstantiateUtil.Instantiate(this.commonKeysGridLayoutGroup.gameObject, this.commonKeyItem.gameObject);
				gameObject.GetComponent<CharacterInputKeyItem>().Init(text, new UnityAction<string>(this.ChangeKey), false, true, "se_decision");
			}
		}
		gameObject = InstantiateUtil.Instantiate(this.commonKeysGridLayoutGroup.gameObject, this.commonKeyItem.gameObject);
		gameObject.GetComponent<CharacterInputKeyItem>().Init("削除", new UnityAction<string>(this.BackSpaceKey), false, true, "se_cancel");
		gameObject = InstantiateUtil.Instantiate(this.commonKeysGridLayoutGroup.gameObject, this.commonKeyItem.gameObject);
		this.decisionKey = gameObject.GetComponent<CharacterInputKeyItem>();
		this.decisionKey.Init("決定", new UnityAction<string>(this.DecisionKey), false, true, "se_decision");
		this.commonKeyItem.gameObject.SetActive(false);
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00002ED4 File Offset: 0x000010D4
	private void ChangeKey(string targetLabel)
	{
		this.ChangeKey(targetLabel, false);
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00002EE0 File Offset: 0x000010E0
	private void ChangeKey(string targetLabel, bool isInit)
	{
		this.nowViewKey = targetLabel;
		this.keyItem.gameObject.SetActive(false);
		if (targetLabel != "漢字")
		{
			SingletonBehaviour<CharacterInputDialog>.Instance.SetVisiblePageArrowPrev(false);
			SingletonBehaviour<CharacterInputDialog>.Instance.SetVisiblePageArrowNext(false);
			string[,] array = CharacterInputKeySettings.KeyMapping[targetLabel];
			this.keysGridLayoutGroup.constraintCount = array.GetLength(1);
			this.keyItemListRow = array.GetLength(0);
			this.keyItemListCol = array.GetLength(1);
			int num = 0;
			for (int i = 0; i < this.keyItemListRow; i++)
			{
				for (int j = 0; j < this.keyItemListCol; j++)
				{
					num++;
					GameObject gameObject;
					if (num > this.keyItemObjs.Count)
					{
						gameObject = InstantiateUtil.Instantiate(this.keysGridLayoutGroup.gameObject, this.keyItem.gameObject);
						this.keyItemObjs.Add(gameObject);
					}
					else
					{
						gameObject = this.keyItemObjs[num - 1];
					}
					gameObject.SetActive(true);
					string text = array[i, j];
					gameObject.GetComponent<CharacterInputKeyItem>().Init(text, new UnityAction<string>(SingletonBehaviour<CharacterInputDialog>.Instance.InputKey), false, true, "se_decision");
				}
				bool flag = false;
				for (int k = 0; k < this.keyItemListCol; k++)
				{
					GameObject gameObject = this.keyItemObjs[i * this.keyItemListCol + k];
					CharacterInputKeyItem component = gameObject.GetComponent<CharacterInputKeyItem>();
					CharacterInputKeyItem.Direction direction = CharacterInputKeyItem.Direction.None;
					if (i == 0)
					{
						direction |= CharacterInputKeyItem.Direction.Upper;
					}
					if (i == this.keyItemListRow - 1)
					{
						direction |= CharacterInputKeyItem.Direction.Lower;
					}
					if (!flag && component.GetSelectable().navigation.mode != null)
					{
						direction |= CharacterInputKeyItem.Direction.Left;
						flag = true;
					}
					component.SetSelectablePosition(direction);
				}
			}
			if (isInit)
			{
				foreach (GameObject gameObject2 in this.keyItemObjs)
				{
					Selectable selectable = gameObject2.GetComponent<CharacterInputKeyItem>().GetSelectable();
					if (selectable.navigation.mode != null)
					{
						this.CallWaitForOneFrame(delegate
						{
							selectable.Select();
						});
						break;
					}
				}
			}
			for (int l = num; l < this.keyItemObjs.Count; l++)
			{
				this.keyItemObjs[l].SetActive(false);
			}
			return;
		}
		this.ChangeKanjiPage(1, isInit);
	}

	// Token: 0x06000035 RID: 53 RVA: 0x0000315C File Offset: 0x0000135C
	private void BackSpaceKey(string keyString)
	{
		SingletonBehaviour<CharacterInputDialog>.Instance.BackSpaceText(true);
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00003169 File Offset: 0x00001369
	private void DecisionKey(string keyString)
	{
		SingletonBehaviour<CharacterInputDialog>.Instance.InputConfirm();
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00003175 File Offset: 0x00001375
	public void DecisionKey()
	{
		this.decisionKey.GetSelectable().Select();
		this.CallWaitForOneFrame(delegate
		{
			this.DecisionKey("");
		});
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00003199 File Offset: 0x00001399
	public bool ChangeKanjiPageNext()
	{
		return this.nowViewKey == "漢字" && this.ChangeKanjiPage(this.kanjiPageNow + 1, false);
	}

	// Token: 0x06000039 RID: 57 RVA: 0x000031BE File Offset: 0x000013BE
	public bool ChangeKanjiPagePrev()
	{
		return this.nowViewKey == "漢字" && this.ChangeKanjiPage(this.kanjiPageNow - 1, false);
	}

	// Token: 0x0600003A RID: 58 RVA: 0x000031E4 File Offset: 0x000013E4
	private bool ChangeKanjiPage(int page, bool isInit = false)
	{
		int num = page - 1;
		if (num < 0 || num >= this.kanjiKeyPagingList.Count)
		{
			return false;
		}
		if (num > 0)
		{
			SingletonBehaviour<CharacterInputDialog>.Instance.SetVisiblePageArrowPrev(true);
		}
		else
		{
			SingletonBehaviour<CharacterInputDialog>.Instance.SetVisiblePageArrowPrev(false);
		}
		if (num < this.kanjiKeyPagingList.Count - 1)
		{
			SingletonBehaviour<CharacterInputDialog>.Instance.SetVisiblePageArrowNext(true);
		}
		else
		{
			SingletonBehaviour<CharacterInputDialog>.Instance.SetVisiblePageArrowNext(false);
		}
		this.kanjiPageNow = page;
		this.keysGridLayoutGroup.constraintCount = 17;
		this.keyItemListRow = 6;
		this.keyItemListCol = 17;
		int num2 = 0;
		Dictionary<string, List<string[]>> dictionary = this.kanjiKeyPagingList[num];
		List<string> list = new List<string>(dictionary.Keys);
		int num3 = 0;
		string text = list[num3];
		string text2 = text;
		int num4 = 0;
		int num5 = 0;
		for (int i = 0; i < this.keyItemListRow; i++)
		{
			for (int j = 0; j < this.keyItemListCol; j++)
			{
				num2++;
				GameObject gameObject;
				if (num2 > this.keyItemObjs.Count)
				{
					gameObject = InstantiateUtil.Instantiate(this.keysGridLayoutGroup.gameObject, this.keyItem.gameObject);
					this.keyItemObjs.Add(gameObject);
				}
				else
				{
					gameObject = this.keyItemObjs[num2 - 1];
				}
				gameObject.SetActive(true);
				string text3;
				bool flag;
				if (j == 0)
				{
					text3 = text2;
					text2 = "";
					flag = false;
				}
				else if (j == 1)
				{
					text3 = "";
					flag = false;
				}
				else if (num4 >= dictionary[text].Count || num5 >= dictionary[text][num4].Length)
				{
					text3 = "";
					flag = false;
				}
				else
				{
					text3 = dictionary[text][num4][num5];
					num5++;
					flag = true;
				}
				CharacterInputKeyItem component = gameObject.GetComponent<CharacterInputKeyItem>();
				component.Init(text3, new UnityAction<string>(SingletonBehaviour<CharacterInputDialog>.Instance.InputKey), false, flag, "se_decision");
				if (!isInit && component.IsSelect && component.GetSelectable().navigation.mode == null)
				{
					for (int k = 0; k < num2; k++)
					{
						Selectable selectable2 = this.keyItemObjs[num2 - 1 - (k + 1)].GetComponent<CharacterInputKeyItem>().GetSelectable();
						if (selectable2.navigation.mode != null)
						{
							selectable2.Select();
							break;
						}
					}
				}
			}
			bool flag2 = false;
			for (int l = 0; l < this.keyItemListCol; l++)
			{
				GameObject gameObject = this.keyItemObjs[i * this.keyItemListCol + l];
				CharacterInputKeyItem component2 = gameObject.GetComponent<CharacterInputKeyItem>();
				CharacterInputKeyItem.Direction direction = CharacterInputKeyItem.Direction.None;
				if (i == 0)
				{
					direction |= CharacterInputKeyItem.Direction.Upper;
				}
				if (i == this.keyItemListRow - 1)
				{
					direction |= CharacterInputKeyItem.Direction.Lower;
				}
				if (!flag2 && component2.GetSelectable().navigation.mode != null)
				{
					direction |= CharacterInputKeyItem.Direction.Left;
					flag2 = true;
				}
				component2.SetSelectablePosition(direction);
			}
			num4++;
			num5 = 0;
			if (num4 >= dictionary[text].Count && num3 < list.Count - 1)
			{
				num3++;
				text = list[num3];
				text2 = text;
				num4 = 0;
			}
		}
		if (isInit)
		{
			foreach (GameObject gameObject2 in this.keyItemObjs)
			{
				Selectable selectable = gameObject2.GetComponent<CharacterInputKeyItem>().GetSelectable();
				if (selectable.navigation.mode != null)
				{
					this.CallWaitForOneFrame(delegate
					{
						selectable.Select();
					});
					break;
				}
			}
		}
		for (int m = num2; m < this.keyItemObjs.Count; m++)
		{
			this.keyItemObjs[m].SetActive(false);
		}
		return true;
	}

	// Token: 0x0600003B RID: 59 RVA: 0x000035B4 File Offset: 0x000017B4
	public void LoopNavigation(CharacterInputKeyItem.Direction inputDirection)
	{
		for (int i = 0; i < this.keyItemObjs.Count; i++)
		{
			CharacterInputKeyItem component = this.keyItemObjs[i].GetComponent<CharacterInputKeyItem>();
			if (component.IsSelect)
			{
				int num = i / this.keyItemListCol + 1;
				int num2 = i % this.keyItemListCol + 1;
				int num3 = 0;
				int num4 = 0;
				if (inputDirection <= CharacterInputKeyItem.Direction.Lower)
				{
					if (inputDirection != CharacterInputKeyItem.Direction.Upper)
					{
						if (inputDirection != CharacterInputKeyItem.Direction.Lower)
						{
							return;
						}
						num = 1;
						num3 = 1;
					}
					else
					{
						num = this.keyItemListRow;
						num3 = -1;
					}
				}
				else if (inputDirection != CharacterInputKeyItem.Direction.Left)
				{
					if (inputDirection != CharacterInputKeyItem.Direction.Right)
					{
						return;
					}
					num2 = 1;
					num4 = 1;
				}
				else
				{
					num2 = this.keyItemListCol;
					num4 = -1;
				}
				if (component.IsLoopNavigation(inputDirection))
				{
					if (this.nowViewKey == "漢字")
					{
						if (inputDirection == CharacterInputKeyItem.Direction.Upper)
						{
							this.ChangeKanjiPagePrev();
						}
						if (inputDirection == CharacterInputKeyItem.Direction.Lower)
						{
							this.ChangeKanjiPageNext();
						}
					}
					if (inputDirection != CharacterInputKeyItem.Direction.Left)
					{
						Selectable selectable;
						do
						{
							selectable = this.keyItemObjs[(num - 1) * this.keyItemListCol + num2 - 1].GetComponent<CharacterInputKeyItem>().GetSelectable();
							if (selectable.navigation.mode != null)
							{
								goto IL_01E1;
							}
							num += num3;
							num2 += num4;
							if (num < 1 || num > this.keyItemListRow || num2 < 1)
							{
								break;
							}
						}
						while (num2 <= this.keyItemListCol);
						break;
						IL_01E1:
						selectable.Select();
						break;
					}
					Selectable selectable2 = null;
					CharacterInputKeyItem[] array = this.commonKeysGridLayoutGroup.gameObject.GetComponentsInChildren<CharacterInputKeyItem>();
					for (int j = 0; j < array.Length; j++)
					{
						Selectable selectable3 = array[j].GetSelectable();
						if (selectable3.navigation.mode != null)
						{
							if (selectable2 == null)
							{
								selectable2 = selectable3;
							}
							else
							{
								float num5 = Mathf.Abs(component.transform.position.y - selectable2.transform.position.y);
								float num6 = Mathf.Abs(component.transform.position.y - selectable3.transform.position.y);
								if (num5 > num6)
								{
									selectable2 = selectable3;
								}
							}
						}
					}
					if (selectable2 != null)
					{
						selectable2.Select();
						break;
					}
					break;
				}
			}
		}
		CharacterInputKeyItem characterInputKeyItem = null;
		foreach (CharacterInputKeyItem characterInputKeyItem2 in this.commonKeysGridLayoutGroup.gameObject.GetComponentsInChildren<CharacterInputKeyItem>())
		{
			if (characterInputKeyItem2.IsSelect)
			{
				characterInputKeyItem = characterInputKeyItem2;
			}
		}
		if (characterInputKeyItem == null)
		{
			return;
		}
		if (inputDirection == CharacterInputKeyItem.Direction.Right)
		{
			Selectable selectable4 = null;
			int num7 = 1;
			int num8 = 1;
			for (int k = 0; k < this.keyItemListRow; k++)
			{
				Selectable selectable5 = this.keyItemObjs[k * this.keyItemListCol].GetComponent<CharacterInputKeyItem>().GetSelectable();
				if (selectable4 == null)
				{
					selectable4 = selectable5;
					num7 = k + 1;
				}
				else
				{
					float num9 = Mathf.Abs(characterInputKeyItem.transform.position.y - selectable4.transform.position.y);
					float num10 = Mathf.Abs(characterInputKeyItem.transform.position.y - selectable5.transform.position.y);
					if (num9 > num10)
					{
						selectable4 = selectable5;
						num7 = k + 1;
					}
				}
			}
			Selectable selectable6;
			do
			{
				selectable6 = this.keyItemObjs[(num7 - 1) * this.keyItemListCol + num8 - 1].GetComponent<CharacterInputKeyItem>().GetSelectable();
				if (selectable6.navigation.mode != null)
				{
					goto IL_036A;
				}
				num8++;
				if (num7 < 1 || num7 > this.keyItemListRow || num8 < 1)
				{
					return;
				}
			}
			while (num8 <= this.keyItemListCol);
			return;
			IL_036A:
			selectable6.Select();
			return;
		}
		if (inputDirection == CharacterInputKeyItem.Direction.Upper)
		{
			CharacterInputKeyItem[] componentsInChildren = this.commonKeysGridLayoutGroup.gameObject.GetComponentsInChildren<CharacterInputKeyItem>();
			componentsInChildren[componentsInChildren.Length - 1].GetSelectable().Select();
			return;
		}
		if (inputDirection == CharacterInputKeyItem.Direction.Lower)
		{
			this.commonKeysGridLayoutGroup.gameObject.GetComponentsInChildren<CharacterInputKeyItem>()[0].GetSelectable().Select();
		}
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00003978 File Offset: 0x00001B78
	private void CreateKanjiKeyMapPagingList()
	{
		this.kanjiKeyPagingList = new List<Dictionary<string, List<string[]>>>();
		int num = 1;
		Dictionary<string, List<string[]>> dictionary = new Dictionary<string, List<string[]>>();
		List<string[]> list = new List<string[]>();
		List<string> list2 = new List<string>(CharacterInputKeySettings.KanjiKeyMap.Keys);
		for (int i = 0; i < list2.Count; i++)
		{
			string text = list2[i];
			string text2 = text;
			string[] array = CharacterInputKeySettings.KanjiKeyMap[text];
			List<string> list3 = new List<string>();
			for (int j = 0; j < array.Length; j++)
			{
				list3.Add(array[j]);
				if (list3.Count >= 15 || j == array.Length - 1)
				{
					list.Add(list3.ToArray());
					list3 = new List<string>();
					num++;
					if (num > 6 || i == list2.Count - 1)
					{
						dictionary[text2] = list;
						list = new List<string[]>();
						num = 1;
						this.kanjiKeyPagingList.Add(dictionary);
						dictionary = new Dictionary<string, List<string[]>>();
						text2 = "";
					}
					else if (j == array.Length - 1)
					{
						dictionary[text2] = list;
						list = new List<string[]>();
					}
				}
			}
		}
	}

	// Token: 0x04000037 RID: 55
	[SerializeField]
	private CharacterInputKeyItem keyItem;

	// Token: 0x04000038 RID: 56
	[SerializeField]
	private GridLayoutGroup keysGridLayoutGroup;

	// Token: 0x04000039 RID: 57
	[SerializeField]
	private CharacterInputKeyItem commonKeyItem;

	// Token: 0x0400003A RID: 58
	[SerializeField]
	private GridLayoutGroup commonKeysGridLayoutGroup;

	// Token: 0x0400003B RID: 59
	private CharacterInputKeyItem decisionKey;

	// Token: 0x0400003C RID: 60
	private List<GameObject> keyItemObjs;

	// Token: 0x0400003D RID: 61
	private List<Dictionary<string, List<string[]>>> kanjiKeyPagingList;

	// Token: 0x0400003E RID: 62
	private int kanjiPageNow;

	// Token: 0x0400003F RID: 63
	private string nowViewKey;

	// Token: 0x04000040 RID: 64
	private int keyItemListRow;

	// Token: 0x04000041 RID: 65
	private int keyItemListCol;
}
