using System;
using System.Collections.Generic;
using System.Linq;
using Socotra.IO;
using Steezy.Utility;
using UnityEngine;

namespace Socotra.UI
{
	// Token: 0x020000FE RID: 254
	public class PalettedImage : Image
	{
		// Token: 0x060013A9 RID: 5033 RVA: 0x0012121C File Offset: 0x0011F41C
		public static PalettedImage CreatePalettedImage(InputStream inputStream)
		{
			sbyte[] array = new sbyte[inputStream.Available()];
			inputStream.Read(ref array);
			return PalettedImage.CreatePalettedImage(array);
		}

		// Token: 0x060013AA RID: 5034 RVA: 0x00121244 File Offset: 0x0011F444
		public static PalettedImage CreatePalettedImage(byte[] data)
		{
			return PalettedImage.CreatePalettedImageImpl(data);
		}

		// Token: 0x060013AB RID: 5035 RVA: 0x0012124C File Offset: 0x0011F44C
		public static PalettedImage CreatePalettedImage(sbyte[] data)
		{
			return PalettedImage.CreatePalettedImageImpl(data.Select((sbyte x) => (byte)x).ToArray<byte>());
		}

		// Token: 0x060013AC RID: 5036 RVA: 0x00121280 File Offset: 0x0011F480
		public static PalettedImage CreatePalettedImageImpl(byte[] data)
		{
			List<UniGif.GifTexture> textureList = UniGif.GetTextureList(data, 1, 1, false);
			if (textureList != null)
			{
				Sprite sprite = Sprite.Create(textureList[0].m_texture2d, new Rect(0f, 0f, (float)textureList[0].m_texture2d.width, (float)textureList[0].m_texture2d.height), new Vector2(0f, 0f));
				PalettedImage palettedImage = SingletonBehaviour<StScreenManager>.Instance.AddPalettedImage(sprite.texture.width, sprite.texture.height);
				palettedImage.baseSprite = sprite;
				palettedImage.Texture = sprite.texture;
				palettedImage.baseData = data;
				palettedImage.palette = palettedImage.CreatePalette(data);
				palettedImage.gameObject.name = "OriginalPalette:" + palettedImage.baseSprite.texture.width.ToString() + ":" + palettedImage.baseSprite.texture.height.ToString();
				return palettedImage;
			}
			return null;
		}

		// Token: 0x060013AD RID: 5037 RVA: 0x00121388 File Offset: 0x0011F588
		public void SetPalette(Palette newPalette)
		{
			if (newPalette.GetEntryCount() < this.palette.GetEntryCount())
			{
				return;
			}
			if (!this.palette.Equals(newPalette))
			{
				if (newPalette.GetEntryCount() > this.palette.GetEntryCount())
				{
					Array.Resize<int>(ref newPalette.colors, this.palette.GetEntryCount());
				}
				this.palette = newPalette.Clone();
				this.ApplyPalette();
			}
		}

		// Token: 0x060013AE RID: 5038 RVA: 0x001213F4 File Offset: 0x0011F5F4
		protected Palette CreatePalette(byte[] data)
		{
			int num = (int)Math.Pow(2.0, (double)((data[10] & 7) + 1));
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				int num2 = 13 + i * 3;
				array[i] = ((int)data[num2] << 16) | ((int)data[num2 + 1] << 8) | (int)data[num2 + 2];
			}
			return new Palette(array);
		}

		// Token: 0x060013AF RID: 5039 RVA: 0x00121454 File Offset: 0x0011F654
		public void ApplyPalette()
		{
			for (int i = 0; i < this.palette.GetEntryCount(); i++)
			{
				int num = 13 + i * 3;
				this.baseData[num] = (byte)((16711680 & this.palette.GetEntry(i)) >> 16);
				this.baseData[num + 1] = (byte)((65280 & this.palette.GetEntry(i)) >> 8);
				this.baseData[num + 2] = (byte)(255 & this.palette.GetEntry(i));
			}
			List<UniGif.GifTexture> textureList = UniGif.GetTextureList(this.baseData, 1, 1, false);
			if (textureList != null)
			{
				if (this.baseSprite != null)
				{
					Object.Destroy(this.texture);
					Object.Destroy(this.baseSprite);
				}
				this.baseSprite = Sprite.Create(textureList[0].m_texture2d, new Rect(0f, 0f, (float)textureList[0].m_texture2d.width, (float)textureList[0].m_texture2d.height), new Vector2(0f, 0f));
				base.Texture = this.baseSprite.texture;
				base.gameObject.name = "ApplyPalette:" + this.baseSprite.texture.width.ToString() + ":" + this.baseSprite.texture.height.ToString();
			}
		}

		// Token: 0x060013B0 RID: 5040 RVA: 0x001215C5 File Offset: 0x0011F7C5
		public Palette GetPalette()
		{
			return this.palette;
		}

		// Token: 0x060013B1 RID: 5041 RVA: 0x001215CD File Offset: 0x0011F7CD
		public override void Dispose()
		{
			if (this.texture != null)
			{
				Object.Destroy(this.texture);
			}
			Object.Destroy(this.baseSprite);
			Object.Destroy(this);
			base.Dispose();
		}

		// Token: 0x04000AF7 RID: 2807
		private const int GifFormatGlobalColorTableIdx = 13;

		// Token: 0x04000AF8 RID: 2808
		[SerializeField]
		private Sprite baseSprite;

		// Token: 0x04000AF9 RID: 2809
		private byte[] baseData;

		// Token: 0x04000AFA RID: 2810
		private Palette palette;
	}
}
