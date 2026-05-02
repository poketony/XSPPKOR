using System;
using Steezy.Utility;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000008 RID: 8
public class CharacterInputKeyButton : Button
{
	// Token: 0x06000027 RID: 39 RVA: 0x00002B7C File Offset: 0x00000D7C
	public override void OnMove(AxisEventData eventData)
	{
		base.OnMove(eventData);
		CharacterInputKeyItem.Direction direction = CharacterInputKeyItem.Direction.None;
		switch (eventData.moveDir)
		{
		case 0:
			direction = CharacterInputKeyItem.Direction.Left;
			break;
		case 1:
			direction = CharacterInputKeyItem.Direction.Upper;
			break;
		case 2:
			direction = CharacterInputKeyItem.Direction.Right;
			break;
		case 3:
			direction = CharacterInputKeyItem.Direction.Lower;
			break;
		}
		SingletonBehaviour<CharacterInputKeyManager>.Instance.LoopNavigation(direction);
	}
}
