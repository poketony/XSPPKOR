using System;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

// Token: 0x02000025 RID: 37
public class VideoScreenManager : SingletonBehaviour<VideoScreenManager>
{
	// Token: 0x17000007 RID: 7
	// (get) Token: 0x060000AD RID: 173 RVA: 0x0000B96E File Offset: 0x00009B6E
	public VideoPlayer VideoPlayer
	{
		get
		{
			return this.videoPlayer;
		}
	}

	// Token: 0x060000AE RID: 174 RVA: 0x0000B976 File Offset: 0x00009B76
	private void Awake()
	{
		this.videoPlayerTr = this.videoPlayer.GetComponent<RectTransform>();
		this.videoPlayerRawImage = this.videoPlayer.GetComponent<RawImage>();
		this.SetActiveScreen(false);
	}

	// Token: 0x060000AF RID: 175 RVA: 0x0000B9A1 File Offset: 0x00009BA1
	public void SetActiveScreen(bool isActive)
	{
		this.videoPlayerRawImage.enabled = false;
		this.videoScreenParent.SetActive(isActive);
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x0000B9BB File Offset: 0x00009BBB
	public void SetVideoTexture()
	{
		this.ChangeVideoScreenSize(this.isVideoScreenFull);
		this.videoPlayerRawImage.texture = this.videoPlayer.texture;
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x0000B9DF File Offset: 0x00009BDF
	public void EnableRawImage()
	{
		this.videoPlayerRawImage.enabled = true;
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x0000B9F0 File Offset: 0x00009BF0
	public void ChangeVideoScreenSize(bool isFull)
	{
		this.isVideoScreenFull = isFull;
		RectTransform rectTransform;
		if (isFull)
		{
			this.videoScreenPhoneSize.gameObject.SetActive(false);
			this.videoScreenFullSize.gameObject.SetActive(true);
			rectTransform = this.videoScreenFullSize;
		}
		else
		{
			this.videoScreenPhoneSize.gameObject.SetActive(true);
			this.videoScreenFullSize.gameObject.SetActive(false);
			rectTransform = this.videoScreenPhoneSize;
		}
		this.videoPlayerTr.anchoredPosition = rectTransform.anchoredPosition;
		this.videoPlayerTr.sizeDelta = rectTransform.sizeDelta;
		this.SetVideoPlayerSize();
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x0000BA84 File Offset: 0x00009C84
	private void SetVideoPlayerSize()
	{
		if (this.videoPlayer.texture != null)
		{
			Vector2 sizeDelta = this.videoPlayerTr.sizeDelta;
			if (this.videoPlayer.texture.width > this.videoPlayer.texture.height)
			{
				sizeDelta.y *= (float)this.videoPlayer.texture.height / (float)this.videoPlayer.texture.width;
			}
			else if (this.videoPlayer.texture.width > this.videoPlayer.texture.height)
			{
				sizeDelta.x *= (float)this.videoPlayer.texture.width / (float)this.videoPlayer.texture.height;
			}
			this.videoPlayerTr.sizeDelta = sizeDelta;
		}
	}

	// Token: 0x040000E8 RID: 232
	[SerializeField]
	private GameObject videoScreenParent;

	// Token: 0x040000E9 RID: 233
	[SerializeField]
	private VideoPlayer videoPlayer;

	// Token: 0x040000EA RID: 234
	[SerializeField]
	private RectTransform videoScreenPhoneSize;

	// Token: 0x040000EB RID: 235
	[SerializeField]
	private RectTransform videoScreenFullSize;

	// Token: 0x040000EC RID: 236
	private RawImage videoPlayerRawImage;

	// Token: 0x040000ED RID: 237
	private RectTransform videoPlayerTr;

	// Token: 0x040000EE RID: 238
	private RenderTexture renderTexture;

	// Token: 0x040000EF RID: 239
	private bool isVideoScreenFull;
}
