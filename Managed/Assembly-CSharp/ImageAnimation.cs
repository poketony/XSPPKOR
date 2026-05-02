using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000058 RID: 88
[RequireComponent(typeof(Image))]
public class ImageAnimation : MonoBehaviour
{
	// Token: 0x1700000D RID: 13
	// (get) Token: 0x06000DEC RID: 3564 RVA: 0x0010D9CE File Offset: 0x0010BBCE
	// (set) Token: 0x06000DED RID: 3565 RVA: 0x0010D9D6 File Offset: 0x0010BBD6
	public Image image { get; private set; }

	// Token: 0x06000DEE RID: 3566 RVA: 0x0010D9DF File Offset: 0x0010BBDF
	private void Awake()
	{
		this.image = base.GetComponent<Image>();
		this.CheckSpriteCount(this.m_sprites);
		if (this.m_spriteCount > 0)
		{
			this.image.sprite = this.m_sprites[0];
		}
	}

	// Token: 0x06000DEF RID: 3567 RVA: 0x0010DA18 File Offset: 0x0010BC18
	private void Update()
	{
		if (this.m_spriteCount <= 0)
		{
			return;
		}
		if (Time.realtimeSinceStartup - this.m_lastTime > this.m_frameGap)
		{
			this.m_lastTime = Time.realtimeSinceStartup;
			this.m_curFrame++;
			if (this.m_curFrame >= this.m_spriteCount)
			{
				this.m_curFrame = 0;
			}
			this.image.sprite = this.m_sprites[this.m_curFrame];
			if (this.m_autoNativeSize)
			{
				this.image.SetNativeSize();
			}
		}
	}

	// Token: 0x06000DF0 RID: 3568 RVA: 0x0010DA9C File Offset: 0x0010BC9C
	private void CheckSpriteCount(Sprite[] sprites)
	{
		this.m_spriteCount = 0;
		if (sprites != null)
		{
			int num = 0;
			while (num < sprites.Length && !(sprites[num] == null))
			{
				this.m_spriteCount++;
				num++;
			}
		}
	}

	// Token: 0x06000DF1 RID: 3569 RVA: 0x0010DADC File Offset: 0x0010BCDC
	public void SetSprites(Sprite[] sprites, float frameGap = 0.25f, bool nativeSize = false)
	{
		if (this.m_sprites == null || sprites.Length > this.m_sprites.Length)
		{
			this.m_sprites = new Sprite[sprites.Length];
		}
		for (int i = 0; i < this.m_sprites.Length; i++)
		{
			if (i < sprites.Length)
			{
				this.m_sprites[i] = sprites[i];
			}
			else
			{
				this.m_sprites[i] = null;
			}
		}
		this.m_frameGap = frameGap;
		this.m_autoNativeSize = nativeSize;
		this.CheckSpriteCount(this.m_sprites);
		if (this.m_spriteCount > 0)
		{
			this.image.sprite = this.m_sprites[0];
		}
		if (this.m_autoNativeSize)
		{
			this.image.SetNativeSize();
		}
	}

	// Token: 0x06000DF2 RID: 3570 RVA: 0x0010DB84 File Offset: 0x0010BD84
	public static ImageAnimation Begin(Image image, Sprite[] sprites, float frameGap = 0.25f, bool nativeSize = false)
	{
		ImageAnimation imageAnimation = image.GetComponent<ImageAnimation>();
		if (imageAnimation == null)
		{
			imageAnimation = image.gameObject.AddComponent<ImageAnimation>();
		}
		imageAnimation.SetSprites(sprites, frameGap, nativeSize);
		return imageAnimation;
	}

	// Token: 0x04000838 RID: 2104
	[SerializeField]
	private float m_frameGap = 0.25f;

	// Token: 0x04000839 RID: 2105
	[SerializeField]
	private bool m_autoNativeSize;

	// Token: 0x0400083A RID: 2106
	[SerializeField]
	private Sprite[] m_sprites;

	// Token: 0x0400083C RID: 2108
	private int m_curFrame;

	// Token: 0x0400083D RID: 2109
	private int m_spriteCount;

	// Token: 0x0400083E RID: 2110
	private float m_lastTime;
}
