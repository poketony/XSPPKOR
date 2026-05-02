using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Socotra.IO;
using Socotra.UI;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Video;

namespace Socotra.Media
{
	// Token: 0x02000114 RID: 276
	public class MediaImage : MediaResource
	{
		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06001591 RID: 5521 RVA: 0x0012B846 File Offset: 0x00129A46
		public VideoClip VideoClip
		{
			get
			{
				return this.videoClip;
			}
		}

		// Token: 0x06001592 RID: 5522 RVA: 0x0012B84E File Offset: 0x00129A4E
		public MediaImage(Sprite sprite, bool isDisposable = true)
		{
			this.SetSprite(sprite, isDisposable);
		}

		// Token: 0x06001593 RID: 5523 RVA: 0x0012B85E File Offset: 0x00129A5E
		public MediaImage(Texture2D texture, bool isDisposable = true)
		{
			this.SetTexture(texture, isDisposable);
		}

		// Token: 0x06001594 RID: 5524 RVA: 0x0012B86E File Offset: 0x00129A6E
		public MediaImage(VideoClip videoClip, bool isDisposable = true)
		{
			this.SetVideoClip(videoClip, isDisposable);
		}

		// Token: 0x06001595 RID: 5525 RVA: 0x0012B880 File Offset: 0x00129A80
		public MediaImage(byte[] data, bool isDisposable = true)
		{
			if (this.IsJpegBinary(data))
			{
				Texture2D texture2D = new Texture2D(1, 1, 4, false);
				ImageConversion.LoadImage(texture2D, data);
				this.SetTexture(texture2D, isDisposable);
				return;
			}
			this.isDisposable = isDisposable;
			this.baseData = data;
			this.SetSize(data);
		}

		// Token: 0x06001596 RID: 5526 RVA: 0x0012B8CC File Offset: 0x00129ACC
		~MediaImage()
		{
			this.baseSprite = null;
		}

		// Token: 0x06001597 RID: 5527 RVA: 0x0012B8FC File Offset: 0x00129AFC
		public void Use()
		{
			if (this.baseData != null)
			{
				List<UniGif.GifTexture> textureList = UniGif.GetTextureList(this.baseData, 1, 1, false);
				if (textureList != null)
				{
					this.baseSprite = Sprite.Create(textureList[0].m_texture2d, new Rect(0f, 0f, (float)this.width, (float)this.height), new Vector2(0f, 0f));
				}
			}
		}

		// Token: 0x06001598 RID: 5528 RVA: 0x0012B968 File Offset: 0x00129B68
		public Image GetImage()
		{
			if (this.image == null)
			{
				if (this.baseSprite == null)
				{
					this.image = SingletonBehaviour<StScreenManager>.Instance.AddImage(this.width, this.height);
				}
				else
				{
					this.image = SingletonBehaviour<StScreenManager>.Instance.AddImage(this.baseSprite.texture);
					this.baseSprite = null;
				}
				if (this.isDisposable)
				{
					this.image.IsDisposable = true;
				}
			}
			return this.image;
		}

		// Token: 0x06001599 RID: 5529 RVA: 0x0012B9EB File Offset: 0x00129BEB
		public override void Dispose()
		{
			base.Dispose();
			if (this.image != null)
			{
				this.image.Dispose();
			}
		}

		// Token: 0x0600159A RID: 5530 RVA: 0x0012BA0C File Offset: 0x00129C0C
		public void GifCallBack(List<UniGif.GifTexture> gifTexList, int loopCount, int w, int h)
		{
			this.baseSprite = Sprite.Create(gifTexList[0].m_texture2d, new Rect(0f, 0f, (float)w, (float)h), new Vector2(0f, 0f));
			this.image.Texture = this.baseSprite.texture;
		}

		// Token: 0x0600159B RID: 5531 RVA: 0x0012BA69 File Offset: 0x00129C69
		private void SetSprite(Sprite sprite, bool isDisposable = true)
		{
			this.isDisposable = isDisposable;
			this.baseSprite = sprite;
			this.tex2d = sprite.texture;
			this.width = this.tex2d.width;
			this.height = this.tex2d.height;
		}

		// Token: 0x0600159C RID: 5532 RVA: 0x0012BAA8 File Offset: 0x00129CA8
		private void SetTexture(Texture2D texture, bool isDisposable = true)
		{
			Sprite sprite = Sprite.Create(texture, new Rect(0f, 0f, (float)texture.width, (float)texture.height), new Vector2(0f, 0f));
			this.SetSprite(sprite, isDisposable);
		}

		// Token: 0x0600159D RID: 5533 RVA: 0x0012BAF0 File Offset: 0x00129CF0
		private void SetVideoClip(VideoClip videoClip, bool isDisposable = true)
		{
			this.isDisposable = isDisposable;
			this.videoClip = videoClip;
		}

		// Token: 0x0600159E RID: 5534 RVA: 0x0012BB00 File Offset: 0x00129D00
		private void SetSize(byte[] data)
		{
			ByteArrayInputStream byteArrayInputStream = new ByteArrayInputStream(data);
			sbyte[] array = new sbyte[6];
			RuntimeHelpers.InitializeArray(new sbyte[3], fieldof(<PrivateImplementationDetails>.76C664EF152E065922FED4727315D065B8FB1AED61015CDAEF7BCFEA3C58D5AB).FieldHandle);
			byteArrayInputStream.Read(ref array);
			Convert.ToString(array);
			this.width = (int)((byte)byteArrayInputStream.ReadByte()) + ((int)((byte)byteArrayInputStream.ReadByte()) << 8);
			this.height = (int)((byte)byteArrayInputStream.ReadByte()) + ((int)((byte)byteArrayInputStream.ReadByte()) << 8);
			byteArrayInputStream.Close();
		}

		// Token: 0x0600159F RID: 5535 RVA: 0x0012BB74 File Offset: 0x00129D74
		private bool IsJpegBinary(byte[] data)
		{
			bool flag = false;
			if (data != null && data.Length >= 2)
			{
				flag = data[0] == byte.MaxValue && data[1] == 216;
			}
			return flag;
		}

		// Token: 0x04000C6E RID: 3182
		[SerializeField]
		private Sprite baseSprite;

		// Token: 0x04000C6F RID: 3183
		[SerializeField]
		private Image image;

		// Token: 0x04000C70 RID: 3184
		private Texture2D tex2d;

		// Token: 0x04000C71 RID: 3185
		private VideoClip videoClip;

		// Token: 0x04000C72 RID: 3186
		private int width;

		// Token: 0x04000C73 RID: 3187
		private int height;

		// Token: 0x04000C74 RID: 3188
		private byte[] baseData;

		// Token: 0x04000C75 RID: 3189
		private bool isDisposable;
	}
}
