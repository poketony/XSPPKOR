using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200000C RID: 12
[RequireComponent(typeof(Text))]
public class CharacterInputTextCaret : MonoBehaviour
{
	// Token: 0x06000042 RID: 66 RVA: 0x0000A267 File Offset: 0x00008467
	private void Awake()
	{
		this.text = base.GetComponent<Text>();
	}

	// Token: 0x06000043 RID: 67 RVA: 0x0000A275 File Offset: 0x00008475
	public void SetVisibleCaret(bool visible)
	{
		this.caretObj.gameObject.SetActive(visible);
	}

	// Token: 0x06000044 RID: 68 RVA: 0x0000A288 File Offset: 0x00008488
	public void UpdateCaretPosition()
	{
		this.caretObj.localPosition = this.CalcCaretPosition();
	}

	// Token: 0x06000045 RID: 69 RVA: 0x0000A2A0 File Offset: 0x000084A0
	private Vector2 CalcCaretPosition()
	{
		int widthOfMessage = this.GetWidthOfMessage(this.text.text);
		float num = 0f;
		switch (this.text.alignment)
		{
		case 0:
		case 3:
		case 6:
			num = this.text.rectTransform.rect.x + (float)widthOfMessage;
			break;
		case 1:
		case 4:
		case 7:
			num = this.text.rectTransform.rect.x + this.text.rectTransform.rect.width / 2f + (float)widthOfMessage / 2f;
			break;
		case 2:
		case 5:
		case 8:
			num = this.text.rectTransform.rect.x + this.text.rectTransform.rect.width;
			break;
		}
		Vector2 vector = default(Vector2);
		vector.x = num + 2f;
		vector.y = this.caretObj.localPosition.y;
		return vector;
	}

	// Token: 0x06000046 RID: 70 RVA: 0x0000A3C8 File Offset: 0x000085C8
	private int GetWidthOfMessage(string message)
	{
		int num = 0;
		Font font = this.text.font;
		CharacterInfo characterInfo = default(CharacterInfo);
		char[] array = message.ToCharArray();
		font.RequestCharactersInTexture(message, this.text.fontSize);
		foreach (char c in array)
		{
			font.GetCharacterInfo(c, ref characterInfo, this.text.fontSize);
			num += characterInfo.advance;
		}
		return num;
	}

	// Token: 0x04000057 RID: 87
	private const float CaretMerginX = 2f;

	// Token: 0x04000058 RID: 88
	[SerializeField]
	private Transform caretObj;

	// Token: 0x04000059 RID: 89
	private Text text;
}
