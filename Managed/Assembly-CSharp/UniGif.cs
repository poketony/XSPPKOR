using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x02000064 RID: 100
public static class UniGif
{
	// Token: 0x06000E4E RID: 3662 RVA: 0x0010F9C8 File Offset: 0x0010DBC8
	public static List<UniGif.GifTexture> GetTextureList(byte[] bytes, FilterMode filterMode = 1, TextureWrapMode wrapMode = 1, bool debugLog = false)
	{
		UniGif.GifData gifData = default(UniGif.GifData);
		if (!UniGif.SetGifData(bytes, ref gifData, debugLog))
		{
			Debug.LogError("GIF file data set error.");
			return null;
		}
		List<UniGif.GifTexture> gifTexList = UniGif.DecodeTextureCoroutine(gifData, delegate(List<UniGif.GifTexture> result)
		{
			gifTexList = result;
		}, filterMode, wrapMode);
		if (gifTexList == null || gifTexList.Count <= 0)
		{
			Debug.LogError("GIF texture decode error.");
			return null;
		}
		int loopCount = gifData.m_appEx.loopCount;
		return gifTexList;
	}

	// Token: 0x06000E4F RID: 3663 RVA: 0x0010FA4C File Offset: 0x0010DC4C
	private static List<UniGif.GifTexture> DecodeTextureCoroutine(UniGif.GifData gifData, Action<List<UniGif.GifTexture>> callback, FilterMode filterMode, TextureWrapMode wrapMode)
	{
		if (gifData.m_imageBlockList == null || gifData.m_imageBlockList.Count < 1)
		{
			return null;
		}
		List<UniGif.GifTexture> list = new List<UniGif.GifTexture>(gifData.m_imageBlockList.Count);
		List<ushort> list2 = new List<ushort>(gifData.m_imageBlockList.Count);
		int num = 0;
		for (int i = 0; i < gifData.m_imageBlockList.Count; i++)
		{
			byte[] decodedData = UniGif.GetDecodedData(gifData.m_imageBlockList[i]);
			UniGif.GraphicControlExtension? graphicCtrlExt = UniGif.GetGraphicCtrlExt(gifData, num);
			int transparentIndex = UniGif.GetTransparentIndex(graphicCtrlExt);
			list2.Add(UniGif.GetDisposalMethod(graphicCtrlExt));
			Color32 color;
			List<byte[]> colorTableAndSetBgColor = UniGif.GetColorTableAndSetBgColor(gifData, gifData.m_imageBlockList[i], transparentIndex, out color);
			bool flag;
			Texture2D texture2D = UniGif.CreateTexture2D(gifData, list, num, list2, color, filterMode, wrapMode, out flag);
			int width = texture2D.width;
			int height = texture2D.height;
			int num2 = 0;
			Color32[] array = new Color32[width * height];
			for (int j = height - 1; j >= 0; j--)
			{
				UniGif.SetArrayPixelRow(array, texture2D, j, gifData.m_imageBlockList[i], decodedData, ref num2, colorTableAndSetBgColor, color, transparentIndex, false);
			}
			texture2D.SetPixels32(array);
			texture2D.Apply(false, true);
			float delaySec = UniGif.GetDelaySec(graphicCtrlExt);
			list.Add(new UniGif.GifTexture(texture2D, delaySec));
			num++;
		}
		return list;
	}

	// Token: 0x06000E50 RID: 3664 RVA: 0x0010FB90 File Offset: 0x0010DD90
	private static byte[] GetDecodedData(UniGif.ImageBlock imgBlock)
	{
		List<byte> list = new List<byte>();
		for (int i = 0; i < imgBlock.m_imageDataList.Count; i++)
		{
			for (int j = 0; j < imgBlock.m_imageDataList[i].m_imageData.Length; j++)
			{
				list.Add(imgBlock.m_imageDataList[i].m_imageData[j]);
			}
		}
		int num = (int)(imgBlock.m_imageHeight * imgBlock.m_imageWidth);
		byte[] array = UniGif.DecodeGifLZW(list, (int)imgBlock.m_lzwMinimumCodeSize, num);
		if (imgBlock.m_interlaceFlag)
		{
			array = UniGif.SortInterlaceGifData(array, (int)imgBlock.m_imageWidth);
		}
		return array;
	}

	// Token: 0x06000E51 RID: 3665 RVA: 0x0010FC28 File Offset: 0x0010DE28
	private static List<byte[]> GetColorTableAndSetBgColor(UniGif.GifData gifData, UniGif.ImageBlock imgBlock, int transparentIndex, out Color32 bgColor)
	{
		List<byte[]> list = (imgBlock.m_localColorTableFlag ? imgBlock.m_localColorTable : (gifData.m_globalColorTableFlag ? gifData.m_globalColorTable : null));
		if (list != null && list.Count > (int)gifData.m_bgColorIndex)
		{
			byte[] array = list[(int)gifData.m_bgColorIndex];
			bgColor = new Color32(array[0], array[1], array[2], (transparentIndex == (int)gifData.m_bgColorIndex) ? 0 : byte.MaxValue);
		}
		else
		{
			bgColor = Color.black;
		}
		return list;
	}

	// Token: 0x06000E52 RID: 3666 RVA: 0x0010FCB0 File Offset: 0x0010DEB0
	private static UniGif.GraphicControlExtension? GetGraphicCtrlExt(UniGif.GifData gifData, int imgBlockIndex)
	{
		if (gifData.m_graphicCtrlExList != null && gifData.m_graphicCtrlExList.Count > imgBlockIndex)
		{
			return new UniGif.GraphicControlExtension?(gifData.m_graphicCtrlExList[imgBlockIndex]);
		}
		return null;
	}

	// Token: 0x06000E53 RID: 3667 RVA: 0x0010FCF0 File Offset: 0x0010DEF0
	private static int GetTransparentIndex(UniGif.GraphicControlExtension? graphicCtrlEx)
	{
		int num = -1;
		if (graphicCtrlEx != null && graphicCtrlEx.Value.m_transparentColorFlag)
		{
			num = (int)graphicCtrlEx.Value.m_transparentColorIndex;
		}
		return num;
	}

	// Token: 0x06000E54 RID: 3668 RVA: 0x0010FD24 File Offset: 0x0010DF24
	private static float GetDelaySec(UniGif.GraphicControlExtension? graphicCtrlEx)
	{
		float num = ((graphicCtrlEx != null) ? ((float)graphicCtrlEx.Value.m_delayTime / 100f) : 0.016666668f);
		if (num <= 0f)
		{
			num = 0.1f;
		}
		return num;
	}

	// Token: 0x06000E55 RID: 3669 RVA: 0x0010FD64 File Offset: 0x0010DF64
	private static ushort GetDisposalMethod(UniGif.GraphicControlExtension? graphicCtrlEx)
	{
		if (graphicCtrlEx == null)
		{
			return 2;
		}
		return graphicCtrlEx.Value.m_disposalMethod;
	}

	// Token: 0x06000E56 RID: 3670 RVA: 0x0010FD80 File Offset: 0x0010DF80
	private static Texture2D CreateTexture2D(UniGif.GifData gifData, List<UniGif.GifTexture> gifTexList, int imgIndex, List<ushort> disposalMethodList, Color32 bgColor, FilterMode filterMode, TextureWrapMode wrapMode, out bool filledTexture)
	{
		filledTexture = false;
		Texture2D texture2D = new Texture2D((int)gifData.m_logicalScreenWidth, (int)gifData.m_logicalScreenHeight, 5, false);
		texture2D.filterMode = filterMode;
		texture2D.wrapMode = wrapMode;
		ushort num = ((imgIndex > 0) ? disposalMethodList[imgIndex - 1] : 2);
		int num2 = -1;
		if (num != 0)
		{
			if (num == 1)
			{
				num2 = imgIndex - 1;
			}
			else if (num == 2)
			{
				filledTexture = true;
				Color32[] array = new Color32[texture2D.width * texture2D.height];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = bgColor;
				}
				texture2D.SetPixels32(array);
				texture2D.Apply();
			}
			else if (num == 3)
			{
				for (int j = imgIndex - 1; j >= 0; j--)
				{
					if (disposalMethodList[j] == 0 || disposalMethodList[j] == 1)
					{
						num2 = j;
						break;
					}
				}
			}
		}
		if (num2 >= 0)
		{
			filledTexture = true;
			Color32[] pixels = gifTexList[num2].m_texture2d.GetPixels32();
			texture2D.SetPixels32(pixels);
			texture2D.Apply();
		}
		return texture2D;
	}

	// Token: 0x06000E57 RID: 3671 RVA: 0x0010FE78 File Offset: 0x0010E078
	private static void SetTexturePixelRow(Texture2D tex, int y, UniGif.ImageBlock imgBlock, byte[] decodedData, ref int dataIndex, List<byte[]> colorTable, Color32 bgColor, int transparentIndex, bool filledTexture)
	{
		int width = tex.width;
		int num = tex.height - 1 - y;
		for (int i = 0; i < width; i++)
		{
			int num2 = i;
			if (num < (int)imgBlock.m_imageTopPosition || num >= (int)(imgBlock.m_imageTopPosition + imgBlock.m_imageHeight) || num2 < (int)imgBlock.m_imageLeftPosition || num2 >= (int)(imgBlock.m_imageLeftPosition + imgBlock.m_imageWidth))
			{
				if (!filledTexture)
				{
					tex.SetPixel(i, y, bgColor);
				}
			}
			else if (dataIndex >= decodedData.Length)
			{
				if (!filledTexture)
				{
					tex.SetPixel(i, y, bgColor);
					if (dataIndex == decodedData.Length)
					{
						Debug.LogError(string.Concat(new string[]
						{
							"dataIndex exceeded the size of decodedData. dataIndex:",
							dataIndex.ToString(),
							" decodedData.Length:",
							decodedData.Length.ToString(),
							" y:",
							y.ToString(),
							" x:",
							i.ToString()
						}));
					}
				}
				dataIndex++;
			}
			else
			{
				byte b = decodedData[dataIndex];
				if (colorTable == null || colorTable.Count <= (int)b)
				{
					if (!filledTexture)
					{
						tex.SetPixel(i, y, bgColor);
						if (colorTable == null)
						{
							Debug.LogError("colorIndex exceeded the size of colorTable. colorTable is null. colorIndex:" + b.ToString());
						}
						else
						{
							Debug.LogError("colorIndex exceeded the size of colorTable. colorTable.Count:" + colorTable.Count.ToString() + " colorIndex:" + b.ToString());
						}
					}
					dataIndex++;
				}
				else
				{
					byte[] array = colorTable[(int)b];
					byte b2 = ((transparentIndex >= 0 && transparentIndex == (int)b) ? 0 : byte.MaxValue);
					if (!filledTexture || b2 != 0)
					{
						Color32 color;
						color..ctor(array[0], array[1], array[2], b2);
						tex.SetPixel(i, y, color);
					}
					dataIndex++;
				}
			}
		}
	}

	// Token: 0x06000E58 RID: 3672 RVA: 0x00110058 File Offset: 0x0010E258
	private static void SetArrayPixelRow(Color32[] pixels, Texture2D tex, int y, UniGif.ImageBlock imgBlock, byte[] decodedData, ref int dataIndex, List<byte[]> colorTable, Color32 bgColor, int transparentIndex, bool filledTexture)
	{
		int width = tex.width;
		int num = tex.height - 1 - y;
		for (int i = 0; i < width; i++)
		{
			int num2 = i;
			if (num < (int)imgBlock.m_imageTopPosition || num >= (int)(imgBlock.m_imageTopPosition + imgBlock.m_imageHeight) || num2 < (int)imgBlock.m_imageLeftPosition || num2 >= (int)(imgBlock.m_imageLeftPosition + imgBlock.m_imageWidth))
			{
				if (!filledTexture)
				{
					pixels[width * y + i] = bgColor;
				}
			}
			else if (dataIndex >= decodedData.Length)
			{
				if (!filledTexture)
				{
					pixels[width * y + i] = bgColor;
					if (dataIndex == decodedData.Length)
					{
						Debug.LogError(string.Concat(new string[]
						{
							"dataIndex exceeded the size of decodedData. dataIndex:",
							dataIndex.ToString(),
							" decodedData.Length:",
							decodedData.Length.ToString(),
							" y:",
							y.ToString(),
							" x:",
							i.ToString()
						}));
					}
				}
				dataIndex++;
			}
			else
			{
				byte b = decodedData[dataIndex];
				if (colorTable == null || colorTable.Count <= (int)b)
				{
					if (!filledTexture)
					{
						pixels[width * y + i] = bgColor;
						if (colorTable == null)
						{
							Debug.LogError("colorIndex exceeded the size of colorTable. colorTable is null. colorIndex:" + b.ToString());
						}
						else
						{
							Debug.LogError("colorIndex exceeded the size of colorTable. colorTable.Count:" + colorTable.Count.ToString() + " colorIndex:" + b.ToString());
						}
					}
					dataIndex++;
				}
				else
				{
					byte[] array = colorTable[(int)b];
					byte b2 = ((transparentIndex >= 0 && transparentIndex == (int)b) ? 0 : byte.MaxValue);
					if (!filledTexture || b2 != 0)
					{
						Color32 color;
						color..ctor(array[0], array[1], array[2], b2);
						pixels[width * y + i] = color;
					}
					dataIndex++;
				}
			}
		}
	}

	// Token: 0x06000E59 RID: 3673 RVA: 0x00110234 File Offset: 0x0010E434
	private static byte[] DecodeGifLZW(List<byte> compData, int lzwMinimumCodeSize, int needDataSize)
	{
		int num = 0;
		int num2 = 0;
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		int num3 = 0;
		UniGif.InitDictionary(dictionary, lzwMinimumCodeSize, out num3, out num, out num2);
		BitArray bitArray = new BitArray(compData.ToArray());
		byte[] array = new byte[needDataSize];
		int num4 = 0;
		string text = null;
		bool flag = false;
		int i = 0;
		while (i < bitArray.Length)
		{
			if (flag)
			{
				UniGif.InitDictionary(dictionary, lzwMinimumCodeSize, out num3, out num, out num2);
				flag = false;
			}
			int numeral = bitArray.GetNumeral(i, num3);
			if (numeral == num)
			{
				flag = true;
				i += num3;
				text = null;
			}
			else
			{
				if (numeral == num2)
				{
					Debug.LogWarning(string.Concat(new string[]
					{
						"early stop code. bitDataIndex:",
						i.ToString(),
						" lzwCodeSize:",
						num3.ToString(),
						" key:",
						numeral.ToString(),
						" dic.Count:",
						dictionary.Count.ToString()
					}));
					break;
				}
				string text2;
				if (dictionary.ContainsKey(numeral))
				{
					text2 = dictionary[numeral];
				}
				else
				{
					if (numeral < dictionary.Count)
					{
						Debug.LogWarning(string.Concat(new string[]
						{
							"It is strange that come here. bitDataIndex:",
							i.ToString(),
							" lzwCodeSize:",
							num3.ToString(),
							" key:",
							numeral.ToString(),
							" dic.Count:",
							dictionary.Count.ToString()
						}));
						i += num3;
						continue;
					}
					if (text == null)
					{
						Debug.LogWarning(string.Concat(new string[]
						{
							"It is strange that come here. bitDataIndex:",
							i.ToString(),
							" lzwCodeSize:",
							num3.ToString(),
							" key:",
							numeral.ToString(),
							" dic.Count:",
							dictionary.Count.ToString()
						}));
						i += num3;
						continue;
					}
					text2 = text + text[0].ToString();
				}
				byte[] bytes = Encoding.Unicode.GetBytes(text2);
				for (int j = 0; j < bytes.Length; j++)
				{
					if (j % 2 == 0)
					{
						array[num4] = bytes[j];
						num4++;
					}
				}
				if (num4 >= needDataSize)
				{
					break;
				}
				if (text != null)
				{
					dictionary.Add(dictionary.Count, text + text2[0].ToString());
				}
				text = text2;
				i += num3;
				if (num3 == 3 && dictionary.Count >= 8)
				{
					num3 = 4;
				}
				else if (num3 == 4 && dictionary.Count >= 16)
				{
					num3 = 5;
				}
				else if (num3 == 5 && dictionary.Count >= 32)
				{
					num3 = 6;
				}
				else if (num3 == 6 && dictionary.Count >= 64)
				{
					num3 = 7;
				}
				else if (num3 == 7 && dictionary.Count >= 128)
				{
					num3 = 8;
				}
				else if (num3 == 8 && dictionary.Count >= 256)
				{
					num3 = 9;
				}
				else if (num3 == 9 && dictionary.Count >= 512)
				{
					num3 = 10;
				}
				else if (num3 == 10 && dictionary.Count >= 1024)
				{
					num3 = 11;
				}
				else if (num3 == 11 && dictionary.Count >= 2048)
				{
					num3 = 12;
				}
				else if (num3 == 12 && dictionary.Count >= 4096 && bitArray.GetNumeral(i, num3) != num)
				{
					flag = true;
				}
			}
		}
		return array;
	}

	// Token: 0x06000E5A RID: 3674 RVA: 0x001105A8 File Offset: 0x0010E7A8
	private static void InitDictionary(Dictionary<int, string> dic, int lzwMinimumCodeSize, out int lzwCodeSize, out int clearCode, out int finishCode)
	{
		int num = (int)Math.Pow(2.0, (double)lzwMinimumCodeSize);
		clearCode = num;
		finishCode = clearCode + 1;
		dic.Clear();
		for (int i = 0; i < num + 2; i++)
		{
			dic.Add(i, ((char)i).ToString());
		}
		lzwCodeSize = lzwMinimumCodeSize + 1;
	}

	// Token: 0x06000E5B RID: 3675 RVA: 0x001105FC File Offset: 0x0010E7FC
	private static byte[] SortInterlaceGifData(byte[] decodedData, int xNum)
	{
		int num = 0;
		int num2 = 0;
		byte[] array = new byte[decodedData.Length];
		for (int i = 0; i < array.Length; i++)
		{
			if (num % 8 == 0)
			{
				array[i] = decodedData[num2];
				num2++;
			}
			if (i != 0 && i % xNum == 0)
			{
				num++;
			}
		}
		num = 0;
		for (int j = 0; j < array.Length; j++)
		{
			if (num % 8 == 4)
			{
				array[j] = decodedData[num2];
				num2++;
			}
			if (j != 0 && j % xNum == 0)
			{
				num++;
			}
		}
		num = 0;
		for (int k = 0; k < array.Length; k++)
		{
			if (num % 4 == 2)
			{
				array[k] = decodedData[num2];
				num2++;
			}
			if (k != 0 && k % xNum == 0)
			{
				num++;
			}
		}
		num = 0;
		for (int l = 0; l < array.Length; l++)
		{
			if (num % 8 != 0 && num % 8 != 4 && num % 4 != 2)
			{
				array[l] = decodedData[num2];
				num2++;
			}
			if (l != 0 && l % xNum == 0)
			{
				num++;
			}
		}
		return array;
	}

	// Token: 0x06000E5C RID: 3676 RVA: 0x001106E4 File Offset: 0x0010E8E4
	private static bool SetGifData(byte[] gifBytes, ref UniGif.GifData gifData, bool debugLog)
	{
		if (debugLog)
		{
			Debug.Log("SetGifData Start.");
		}
		if (gifBytes == null || gifBytes.Length == 0)
		{
			Debug.LogError("bytes is nothing.");
			return false;
		}
		int num = 0;
		if (!UniGif.SetGifHeader(gifBytes, ref num, ref gifData))
		{
			Debug.LogError("GIF header set error.");
			return false;
		}
		if (!UniGif.SetGifBlock(gifBytes, ref num, ref gifData))
		{
			Debug.LogError("GIF block set error.");
			return false;
		}
		if (debugLog)
		{
			gifData.Dump();
			Debug.Log("SetGifData Finish.");
		}
		return true;
	}

	// Token: 0x06000E5D RID: 3677 RVA: 0x00110758 File Offset: 0x0010E958
	private static bool SetGifHeader(byte[] gifBytes, ref int byteIndex, ref UniGif.GifData gifData)
	{
		if (gifBytes[0] != 71 || gifBytes[1] != 73 || gifBytes[2] != 70)
		{
			Debug.LogError("This is not GIF image.");
			return false;
		}
		gifData.m_sig0 = gifBytes[0];
		gifData.m_sig1 = gifBytes[1];
		gifData.m_sig2 = gifBytes[2];
		if ((gifBytes[3] != 56 || gifBytes[4] != 55 || gifBytes[5] != 97) && (gifBytes[3] != 56 || gifBytes[4] != 57 || gifBytes[5] != 97))
		{
			Debug.LogError("GIF version error.\nSupported only GIF87a or GIF89a.");
			return false;
		}
		gifData.m_ver0 = gifBytes[3];
		gifData.m_ver1 = gifBytes[4];
		gifData.m_ver2 = gifBytes[5];
		gifData.m_logicalScreenWidth = BitConverter.ToUInt16(gifBytes, 6);
		gifData.m_logicalScreenHeight = BitConverter.ToUInt16(gifBytes, 8);
		gifData.m_globalColorTableFlag = (gifBytes[10] & 128) == 128;
		int num = (int)(gifBytes[10] & 112);
		if (num <= 48)
		{
			if (num == 16)
			{
				gifData.m_colorResolution = 2;
				goto IL_013D;
			}
			if (num == 32)
			{
				gifData.m_colorResolution = 3;
				goto IL_013D;
			}
			if (num == 48)
			{
				gifData.m_colorResolution = 4;
				goto IL_013D;
			}
		}
		else if (num <= 80)
		{
			if (num == 64)
			{
				gifData.m_colorResolution = 5;
				goto IL_013D;
			}
			if (num == 80)
			{
				gifData.m_colorResolution = 6;
				goto IL_013D;
			}
		}
		else
		{
			if (num == 96)
			{
				gifData.m_colorResolution = 7;
				goto IL_013D;
			}
			if (num == 112)
			{
				gifData.m_colorResolution = 8;
				goto IL_013D;
			}
		}
		gifData.m_colorResolution = 1;
		IL_013D:
		gifData.m_sortFlag = (gifBytes[10] & 8) == 8;
		int num2 = (int)((gifBytes[10] & 7) + 1);
		gifData.m_sizeOfGlobalColorTable = (int)Math.Pow(2.0, (double)num2);
		gifData.m_bgColorIndex = gifBytes[11];
		gifData.m_pixelAspectRatio = gifBytes[12];
		byteIndex = 13;
		if (gifData.m_globalColorTableFlag)
		{
			gifData.m_globalColorTable = new List<byte[]>();
			for (int i = byteIndex; i < byteIndex + gifData.m_sizeOfGlobalColorTable * 3; i += 3)
			{
				gifData.m_globalColorTable.Add(new byte[]
				{
					gifBytes[i],
					gifBytes[i + 1],
					gifBytes[i + 2]
				});
			}
			byteIndex += gifData.m_sizeOfGlobalColorTable * 3;
		}
		return true;
	}

	// Token: 0x06000E5E RID: 3678 RVA: 0x00110948 File Offset: 0x0010EB48
	private static bool SetGifBlock(byte[] gifBytes, ref int byteIndex, ref UniGif.GifData gifData)
	{
		try
		{
			int num = 0;
			for (;;)
			{
				int num2 = byteIndex;
				if (gifBytes[num2] == 44)
				{
					UniGif.SetImageBlock(gifBytes, ref byteIndex, ref gifData);
				}
				else if (gifBytes[num2] == 33)
				{
					byte b = gifBytes[num2 + 1];
					if (b <= 249)
					{
						if (b != 1)
						{
							if (b == 249)
							{
								UniGif.SetGraphicControlExtension(gifBytes, ref byteIndex, ref gifData);
							}
						}
						else
						{
							UniGif.SetPlainTextExtension(gifBytes, ref byteIndex, ref gifData);
						}
					}
					else if (b != 254)
					{
						if (b == 255)
						{
							UniGif.SetApplicationExtension(gifBytes, ref byteIndex, ref gifData);
						}
					}
					else
					{
						UniGif.SetCommentExtension(gifBytes, ref byteIndex, ref gifData);
					}
				}
				else if (gifBytes[num2] == 59)
				{
					break;
				}
				if (num == num2)
				{
					goto Block_10;
				}
				num = num2;
			}
			gifData.m_trailer = gifBytes[byteIndex];
			byteIndex++;
			return true;
			Block_10:
			Debug.LogError("Infinite loop error.");
			return false;
		}
		catch (Exception ex)
		{
			Debug.LogError(ex.Message);
			return false;
		}
		return true;
	}

	// Token: 0x06000E5F RID: 3679 RVA: 0x00110A20 File Offset: 0x0010EC20
	private static void SetImageBlock(byte[] gifBytes, ref int byteIndex, ref UniGif.GifData gifData)
	{
		UniGif.ImageBlock imageBlock = default(UniGif.ImageBlock);
		imageBlock.m_imageSeparator = gifBytes[byteIndex];
		byteIndex++;
		imageBlock.m_imageLeftPosition = BitConverter.ToUInt16(gifBytes, byteIndex);
		byteIndex += 2;
		imageBlock.m_imageTopPosition = BitConverter.ToUInt16(gifBytes, byteIndex);
		byteIndex += 2;
		imageBlock.m_imageWidth = BitConverter.ToUInt16(gifBytes, byteIndex);
		byteIndex += 2;
		imageBlock.m_imageHeight = BitConverter.ToUInt16(gifBytes, byteIndex);
		byteIndex += 2;
		imageBlock.m_localColorTableFlag = (gifBytes[byteIndex] & 128) == 128;
		imageBlock.m_interlaceFlag = (gifBytes[byteIndex] & 64) == 64;
		imageBlock.m_sortFlag = (gifBytes[byteIndex] & 32) == 32;
		int num = (int)((gifBytes[byteIndex] & 7) + 1);
		imageBlock.m_sizeOfLocalColorTable = (int)Math.Pow(2.0, (double)num);
		byteIndex++;
		if (imageBlock.m_localColorTableFlag)
		{
			imageBlock.m_localColorTable = new List<byte[]>();
			for (int i = byteIndex; i < byteIndex + imageBlock.m_sizeOfLocalColorTable * 3; i += 3)
			{
				imageBlock.m_localColorTable.Add(new byte[]
				{
					gifBytes[i],
					gifBytes[i + 1],
					gifBytes[i + 2]
				});
			}
			byteIndex += imageBlock.m_sizeOfLocalColorTable * 3;
		}
		imageBlock.m_lzwMinimumCodeSize = gifBytes[byteIndex];
		byteIndex++;
		for (;;)
		{
			byte b = gifBytes[byteIndex];
			byteIndex++;
			if (b == 0)
			{
				break;
			}
			UniGif.ImageBlock.ImageDataBlock imageDataBlock = default(UniGif.ImageBlock.ImageDataBlock);
			imageDataBlock.m_blockSize = b;
			imageDataBlock.m_imageData = new byte[(int)imageDataBlock.m_blockSize];
			for (int j = 0; j < imageDataBlock.m_imageData.Length; j++)
			{
				imageDataBlock.m_imageData[j] = gifBytes[byteIndex];
				byteIndex++;
			}
			if (imageBlock.m_imageDataList == null)
			{
				imageBlock.m_imageDataList = new List<UniGif.ImageBlock.ImageDataBlock>();
			}
			imageBlock.m_imageDataList.Add(imageDataBlock);
		}
		if (gifData.m_imageBlockList == null)
		{
			gifData.m_imageBlockList = new List<UniGif.ImageBlock>();
		}
		gifData.m_imageBlockList.Add(imageBlock);
	}

	// Token: 0x06000E60 RID: 3680 RVA: 0x00110C0C File Offset: 0x0010EE0C
	private static void SetGraphicControlExtension(byte[] gifBytes, ref int byteIndex, ref UniGif.GifData gifData)
	{
		UniGif.GraphicControlExtension graphicControlExtension = default(UniGif.GraphicControlExtension);
		graphicControlExtension.m_extensionIntroducer = gifBytes[byteIndex];
		byteIndex++;
		graphicControlExtension.m_graphicControlLabel = gifBytes[byteIndex];
		byteIndex++;
		graphicControlExtension.m_blockSize = gifBytes[byteIndex];
		byteIndex++;
		int num = (int)(gifBytes[byteIndex] & 28);
		if (num != 4)
		{
			if (num != 8)
			{
				if (num != 12)
				{
					graphicControlExtension.m_disposalMethod = 0;
				}
				else
				{
					graphicControlExtension.m_disposalMethod = 3;
				}
			}
			else
			{
				graphicControlExtension.m_disposalMethod = 2;
			}
		}
		else
		{
			graphicControlExtension.m_disposalMethod = 1;
		}
		graphicControlExtension.m_transparentColorFlag = (gifBytes[byteIndex] & 1) == 1;
		byteIndex++;
		graphicControlExtension.m_delayTime = BitConverter.ToUInt16(gifBytes, byteIndex);
		byteIndex += 2;
		graphicControlExtension.m_transparentColorIndex = gifBytes[byteIndex];
		byteIndex++;
		graphicControlExtension.m_blockTerminator = gifBytes[byteIndex];
		byteIndex++;
		if (gifData.m_graphicCtrlExList == null)
		{
			gifData.m_graphicCtrlExList = new List<UniGif.GraphicControlExtension>();
		}
		gifData.m_graphicCtrlExList.Add(graphicControlExtension);
	}

	// Token: 0x06000E61 RID: 3681 RVA: 0x00110D00 File Offset: 0x0010EF00
	private static void SetCommentExtension(byte[] gifBytes, ref int byteIndex, ref UniGif.GifData gifData)
	{
		UniGif.CommentExtension commentExtension = default(UniGif.CommentExtension);
		commentExtension.m_extensionIntroducer = gifBytes[byteIndex];
		byteIndex++;
		commentExtension.m_commentLabel = gifBytes[byteIndex];
		byteIndex++;
		for (;;)
		{
			byte b = gifBytes[byteIndex];
			byteIndex++;
			if (b == 0)
			{
				break;
			}
			UniGif.CommentExtension.CommentDataBlock commentDataBlock = default(UniGif.CommentExtension.CommentDataBlock);
			commentDataBlock.m_blockSize = b;
			commentDataBlock.m_commentData = new byte[(int)commentDataBlock.m_blockSize];
			for (int i = 0; i < commentDataBlock.m_commentData.Length; i++)
			{
				commentDataBlock.m_commentData[i] = gifBytes[byteIndex];
				byteIndex++;
			}
			if (commentExtension.m_commentDataList == null)
			{
				commentExtension.m_commentDataList = new List<UniGif.CommentExtension.CommentDataBlock>();
			}
			commentExtension.m_commentDataList.Add(commentDataBlock);
		}
		if (gifData.m_commentExList == null)
		{
			gifData.m_commentExList = new List<UniGif.CommentExtension>();
		}
		gifData.m_commentExList.Add(commentExtension);
	}

	// Token: 0x06000E62 RID: 3682 RVA: 0x00110DD0 File Offset: 0x0010EFD0
	private static void SetPlainTextExtension(byte[] gifBytes, ref int byteIndex, ref UniGif.GifData gifData)
	{
		UniGif.PlainTextExtension plainTextExtension = default(UniGif.PlainTextExtension);
		plainTextExtension.m_extensionIntroducer = gifBytes[byteIndex];
		byteIndex++;
		plainTextExtension.m_plainTextLabel = gifBytes[byteIndex];
		byteIndex++;
		plainTextExtension.m_blockSize = gifBytes[byteIndex];
		byteIndex++;
		byteIndex += 2;
		byteIndex += 2;
		byteIndex += 2;
		byteIndex += 2;
		byteIndex++;
		byteIndex++;
		byteIndex++;
		byteIndex++;
		for (;;)
		{
			byte b = gifBytes[byteIndex];
			byteIndex++;
			if (b == 0)
			{
				break;
			}
			UniGif.PlainTextExtension.PlainTextDataBlock plainTextDataBlock = default(UniGif.PlainTextExtension.PlainTextDataBlock);
			plainTextDataBlock.m_blockSize = b;
			plainTextDataBlock.m_plainTextData = new byte[(int)plainTextDataBlock.m_blockSize];
			for (int i = 0; i < plainTextDataBlock.m_plainTextData.Length; i++)
			{
				plainTextDataBlock.m_plainTextData[i] = gifBytes[byteIndex];
				byteIndex++;
			}
			if (plainTextExtension.m_plainTextDataList == null)
			{
				plainTextExtension.m_plainTextDataList = new List<UniGif.PlainTextExtension.PlainTextDataBlock>();
			}
			plainTextExtension.m_plainTextDataList.Add(plainTextDataBlock);
		}
		if (gifData.m_plainTextExList == null)
		{
			gifData.m_plainTextExList = new List<UniGif.PlainTextExtension>();
		}
		gifData.m_plainTextExList.Add(plainTextExtension);
	}

	// Token: 0x06000E63 RID: 3683 RVA: 0x00110EE0 File Offset: 0x0010F0E0
	private static void SetApplicationExtension(byte[] gifBytes, ref int byteIndex, ref UniGif.GifData gifData)
	{
		gifData.m_appEx.m_extensionIntroducer = gifBytes[byteIndex];
		byteIndex++;
		gifData.m_appEx.m_extensionLabel = gifBytes[byteIndex];
		byteIndex++;
		gifData.m_appEx.m_blockSize = gifBytes[byteIndex];
		byteIndex++;
		gifData.m_appEx.m_appId1 = gifBytes[byteIndex];
		byteIndex++;
		gifData.m_appEx.m_appId2 = gifBytes[byteIndex];
		byteIndex++;
		gifData.m_appEx.m_appId3 = gifBytes[byteIndex];
		byteIndex++;
		gifData.m_appEx.m_appId4 = gifBytes[byteIndex];
		byteIndex++;
		gifData.m_appEx.m_appId5 = gifBytes[byteIndex];
		byteIndex++;
		gifData.m_appEx.m_appId6 = gifBytes[byteIndex];
		byteIndex++;
		gifData.m_appEx.m_appId7 = gifBytes[byteIndex];
		byteIndex++;
		gifData.m_appEx.m_appId8 = gifBytes[byteIndex];
		byteIndex++;
		gifData.m_appEx.m_appAuthCode1 = gifBytes[byteIndex];
		byteIndex++;
		gifData.m_appEx.m_appAuthCode2 = gifBytes[byteIndex];
		byteIndex++;
		gifData.m_appEx.m_appAuthCode3 = gifBytes[byteIndex];
		byteIndex++;
		for (;;)
		{
			byte b = gifBytes[byteIndex];
			byteIndex++;
			if (b == 0)
			{
				break;
			}
			UniGif.ApplicationExtension.ApplicationDataBlock applicationDataBlock = default(UniGif.ApplicationExtension.ApplicationDataBlock);
			applicationDataBlock.m_blockSize = b;
			applicationDataBlock.m_applicationData = new byte[(int)applicationDataBlock.m_blockSize];
			for (int i = 0; i < applicationDataBlock.m_applicationData.Length; i++)
			{
				applicationDataBlock.m_applicationData[i] = gifBytes[byteIndex];
				byteIndex++;
			}
			if (gifData.m_appEx.m_appDataList == null)
			{
				gifData.m_appEx.m_appDataList = new List<UniGif.ApplicationExtension.ApplicationDataBlock>();
			}
			gifData.m_appEx.m_appDataList.Add(applicationDataBlock);
		}
	}

	// Token: 0x020001E8 RID: 488
	public class GifTexture
	{
		// Token: 0x06001C80 RID: 7296 RVA: 0x00145AC2 File Offset: 0x00143CC2
		public GifTexture(Texture2D texture2d, float delaySec)
		{
			this.m_texture2d = texture2d;
			this.m_delaySec = delaySec;
		}

		// Token: 0x04001371 RID: 4977
		public Texture2D m_texture2d;

		// Token: 0x04001372 RID: 4978
		public float m_delaySec;
	}

	// Token: 0x020001E9 RID: 489
	private struct GifData
	{
		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06001C81 RID: 7297 RVA: 0x00145AD8 File Offset: 0x00143CD8
		public string signature
		{
			get
			{
				return new string(new char[]
				{
					(char)this.m_sig0,
					(char)this.m_sig1,
					(char)this.m_sig2
				});
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06001C82 RID: 7298 RVA: 0x00145B00 File Offset: 0x00143D00
		public string version
		{
			get
			{
				return new string(new char[]
				{
					(char)this.m_ver0,
					(char)this.m_ver1,
					(char)this.m_ver2
				});
			}
		}

		// Token: 0x06001C83 RID: 7299 RVA: 0x00145B28 File Offset: 0x00143D28
		public void Dump()
		{
			Debug.Log("GIF Type: " + this.signature + "-" + this.version);
			Debug.Log("Image Size: " + this.m_logicalScreenWidth.ToString() + "x" + this.m_logicalScreenHeight.ToString());
			Debug.Log("Animation Image Count: " + this.m_imageBlockList.Count.ToString());
			Debug.Log("Animation Loop Count (0 is infinite): " + this.m_appEx.loopCount.ToString());
			if (this.m_graphicCtrlExList != null && this.m_graphicCtrlExList.Count > 0)
			{
				StringBuilder stringBuilder = new StringBuilder("Animation Delay Time (1/100sec)");
				for (int i = 0; i < this.m_graphicCtrlExList.Count; i++)
				{
					stringBuilder.Append(", ");
					stringBuilder.Append(this.m_graphicCtrlExList[i].m_delayTime);
				}
				Debug.Log(stringBuilder.ToString());
			}
			Debug.Log("Application Identifier: " + this.m_appEx.applicationIdentifier);
			Debug.Log("Application Authentication Code: " + this.m_appEx.applicationAuthenticationCode);
		}

		// Token: 0x04001373 RID: 4979
		public byte m_sig0;

		// Token: 0x04001374 RID: 4980
		public byte m_sig1;

		// Token: 0x04001375 RID: 4981
		public byte m_sig2;

		// Token: 0x04001376 RID: 4982
		public byte m_ver0;

		// Token: 0x04001377 RID: 4983
		public byte m_ver1;

		// Token: 0x04001378 RID: 4984
		public byte m_ver2;

		// Token: 0x04001379 RID: 4985
		public ushort m_logicalScreenWidth;

		// Token: 0x0400137A RID: 4986
		public ushort m_logicalScreenHeight;

		// Token: 0x0400137B RID: 4987
		public bool m_globalColorTableFlag;

		// Token: 0x0400137C RID: 4988
		public int m_colorResolution;

		// Token: 0x0400137D RID: 4989
		public bool m_sortFlag;

		// Token: 0x0400137E RID: 4990
		public int m_sizeOfGlobalColorTable;

		// Token: 0x0400137F RID: 4991
		public byte m_bgColorIndex;

		// Token: 0x04001380 RID: 4992
		public byte m_pixelAspectRatio;

		// Token: 0x04001381 RID: 4993
		public List<byte[]> m_globalColorTable;

		// Token: 0x04001382 RID: 4994
		public List<UniGif.ImageBlock> m_imageBlockList;

		// Token: 0x04001383 RID: 4995
		public List<UniGif.GraphicControlExtension> m_graphicCtrlExList;

		// Token: 0x04001384 RID: 4996
		public List<UniGif.CommentExtension> m_commentExList;

		// Token: 0x04001385 RID: 4997
		public List<UniGif.PlainTextExtension> m_plainTextExList;

		// Token: 0x04001386 RID: 4998
		public UniGif.ApplicationExtension m_appEx;

		// Token: 0x04001387 RID: 4999
		public byte m_trailer;
	}

	// Token: 0x020001EA RID: 490
	private struct ImageBlock
	{
		// Token: 0x04001388 RID: 5000
		public byte m_imageSeparator;

		// Token: 0x04001389 RID: 5001
		public ushort m_imageLeftPosition;

		// Token: 0x0400138A RID: 5002
		public ushort m_imageTopPosition;

		// Token: 0x0400138B RID: 5003
		public ushort m_imageWidth;

		// Token: 0x0400138C RID: 5004
		public ushort m_imageHeight;

		// Token: 0x0400138D RID: 5005
		public bool m_localColorTableFlag;

		// Token: 0x0400138E RID: 5006
		public bool m_interlaceFlag;

		// Token: 0x0400138F RID: 5007
		public bool m_sortFlag;

		// Token: 0x04001390 RID: 5008
		public int m_sizeOfLocalColorTable;

		// Token: 0x04001391 RID: 5009
		public List<byte[]> m_localColorTable;

		// Token: 0x04001392 RID: 5010
		public byte m_lzwMinimumCodeSize;

		// Token: 0x04001393 RID: 5011
		public List<UniGif.ImageBlock.ImageDataBlock> m_imageDataList;

		// Token: 0x0200027F RID: 639
		public struct ImageDataBlock
		{
			// Token: 0x0400156B RID: 5483
			public byte m_blockSize;

			// Token: 0x0400156C RID: 5484
			public byte[] m_imageData;
		}
	}

	// Token: 0x020001EB RID: 491
	private struct GraphicControlExtension
	{
		// Token: 0x04001394 RID: 5012
		public byte m_extensionIntroducer;

		// Token: 0x04001395 RID: 5013
		public byte m_graphicControlLabel;

		// Token: 0x04001396 RID: 5014
		public byte m_blockSize;

		// Token: 0x04001397 RID: 5015
		public ushort m_disposalMethod;

		// Token: 0x04001398 RID: 5016
		public bool m_transparentColorFlag;

		// Token: 0x04001399 RID: 5017
		public ushort m_delayTime;

		// Token: 0x0400139A RID: 5018
		public byte m_transparentColorIndex;

		// Token: 0x0400139B RID: 5019
		public byte m_blockTerminator;
	}

	// Token: 0x020001EC RID: 492
	private struct CommentExtension
	{
		// Token: 0x0400139C RID: 5020
		public byte m_extensionIntroducer;

		// Token: 0x0400139D RID: 5021
		public byte m_commentLabel;

		// Token: 0x0400139E RID: 5022
		public List<UniGif.CommentExtension.CommentDataBlock> m_commentDataList;

		// Token: 0x02000280 RID: 640
		public struct CommentDataBlock
		{
			// Token: 0x0400156D RID: 5485
			public byte m_blockSize;

			// Token: 0x0400156E RID: 5486
			public byte[] m_commentData;
		}
	}

	// Token: 0x020001ED RID: 493
	private struct PlainTextExtension
	{
		// Token: 0x0400139F RID: 5023
		public byte m_extensionIntroducer;

		// Token: 0x040013A0 RID: 5024
		public byte m_plainTextLabel;

		// Token: 0x040013A1 RID: 5025
		public byte m_blockSize;

		// Token: 0x040013A2 RID: 5026
		public List<UniGif.PlainTextExtension.PlainTextDataBlock> m_plainTextDataList;

		// Token: 0x02000281 RID: 641
		public struct PlainTextDataBlock
		{
			// Token: 0x0400156F RID: 5487
			public byte m_blockSize;

			// Token: 0x04001570 RID: 5488
			public byte[] m_plainTextData;
		}
	}

	// Token: 0x020001EE RID: 494
	private struct ApplicationExtension
	{
		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06001C84 RID: 7300 RVA: 0x00145C60 File Offset: 0x00143E60
		public string applicationIdentifier
		{
			get
			{
				return new string(new char[]
				{
					(char)this.m_appId1,
					(char)this.m_appId2,
					(char)this.m_appId3,
					(char)this.m_appId4,
					(char)this.m_appId5,
					(char)this.m_appId6,
					(char)this.m_appId7,
					(char)this.m_appId8
				});
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06001C85 RID: 7301 RVA: 0x00145CC0 File Offset: 0x00143EC0
		public string applicationAuthenticationCode
		{
			get
			{
				return new string(new char[]
				{
					(char)this.m_appAuthCode1,
					(char)this.m_appAuthCode2,
					(char)this.m_appAuthCode3
				});
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06001C86 RID: 7302 RVA: 0x00145CE8 File Offset: 0x00143EE8
		public int loopCount
		{
			get
			{
				if (this.m_appDataList == null || this.m_appDataList.Count < 1 || this.m_appDataList[0].m_applicationData.Length < 3 || this.m_appDataList[0].m_applicationData[0] != 1)
				{
					return 0;
				}
				return (int)BitConverter.ToUInt16(this.m_appDataList[0].m_applicationData, 1);
			}
		}

		// Token: 0x040013A3 RID: 5027
		public byte m_extensionIntroducer;

		// Token: 0x040013A4 RID: 5028
		public byte m_extensionLabel;

		// Token: 0x040013A5 RID: 5029
		public byte m_blockSize;

		// Token: 0x040013A6 RID: 5030
		public byte m_appId1;

		// Token: 0x040013A7 RID: 5031
		public byte m_appId2;

		// Token: 0x040013A8 RID: 5032
		public byte m_appId3;

		// Token: 0x040013A9 RID: 5033
		public byte m_appId4;

		// Token: 0x040013AA RID: 5034
		public byte m_appId5;

		// Token: 0x040013AB RID: 5035
		public byte m_appId6;

		// Token: 0x040013AC RID: 5036
		public byte m_appId7;

		// Token: 0x040013AD RID: 5037
		public byte m_appId8;

		// Token: 0x040013AE RID: 5038
		public byte m_appAuthCode1;

		// Token: 0x040013AF RID: 5039
		public byte m_appAuthCode2;

		// Token: 0x040013B0 RID: 5040
		public byte m_appAuthCode3;

		// Token: 0x040013B1 RID: 5041
		public List<UniGif.ApplicationExtension.ApplicationDataBlock> m_appDataList;

		// Token: 0x02000282 RID: 642
		public struct ApplicationDataBlock
		{
			// Token: 0x04001571 RID: 5489
			public byte m_blockSize;

			// Token: 0x04001572 RID: 5490
			public byte[] m_applicationData;
		}
	}
}
