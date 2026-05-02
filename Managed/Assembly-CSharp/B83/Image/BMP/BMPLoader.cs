using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace B83.Image.BMP
{
	// Token: 0x0200006B RID: 107
	public class BMPLoader
	{
		// Token: 0x06000E6C RID: 3692 RVA: 0x00111218 File Offset: 0x0010F418
		public BMPImage LoadBMP(string aFileName)
		{
			BMPImage bmpimage;
			using (FileStream fileStream = File.OpenRead(aFileName))
			{
				bmpimage = this.LoadBMP(fileStream);
			}
			return bmpimage;
		}

		// Token: 0x06000E6D RID: 3693 RVA: 0x00111254 File Offset: 0x0010F454
		public BMPImage LoadBMP(byte[] aData)
		{
			BMPImage bmpimage;
			using (MemoryStream memoryStream = new MemoryStream(aData))
			{
				bmpimage = this.LoadBMP(memoryStream);
			}
			return bmpimage;
		}

		// Token: 0x06000E6E RID: 3694 RVA: 0x00111290 File Offset: 0x0010F490
		public BMPImage LoadBMP(Stream aData)
		{
			BMPImage bmpimage;
			using (BinaryReader binaryReader = new BinaryReader(aData))
			{
				bmpimage = this.LoadBMP(binaryReader);
			}
			return bmpimage;
		}

		// Token: 0x06000E6F RID: 3695 RVA: 0x001112CC File Offset: 0x0010F4CC
		public BMPImage LoadBMP(BinaryReader aReader)
		{
			BMPImage bmpimage = new BMPImage();
			if (!BMPLoader.ReadFileHeader(aReader, ref bmpimage.header))
			{
				Debug.LogError("Not a BMP file");
				return null;
			}
			if (!BMPLoader.ReadInfoHeader(aReader, ref bmpimage.info))
			{
				Debug.LogError("Unsupported header format");
				return null;
			}
			if (bmpimage.info.compressionMethod != BMPComressionMode.BI_RGB && bmpimage.info.compressionMethod != BMPComressionMode.BI_BITFIELDS && bmpimage.info.compressionMethod != BMPComressionMode.BI_ALPHABITFIELDS && bmpimage.info.compressionMethod != BMPComressionMode.BI_RLE4 && bmpimage.info.compressionMethod != BMPComressionMode.BI_RLE8)
			{
				Debug.LogError("Unsupported image format: " + bmpimage.info.compressionMethod.ToString());
				return null;
			}
			long num = (long)((ulong)(14U + bmpimage.info.size));
			aReader.BaseStream.Seek(num, SeekOrigin.Begin);
			if (bmpimage.info.nBitsPerPixel < 24)
			{
				bmpimage.rMask = 31744U;
				bmpimage.gMask = 992U;
				bmpimage.bMask = 31U;
			}
			if (bmpimage.info.compressionMethod == BMPComressionMode.BI_BITFIELDS || bmpimage.info.compressionMethod == BMPComressionMode.BI_ALPHABITFIELDS)
			{
				bmpimage.rMask = aReader.ReadUInt32();
				bmpimage.gMask = aReader.ReadUInt32();
				bmpimage.bMask = aReader.ReadUInt32();
			}
			if (this.ForceAlphaReadWhenPossible)
			{
				bmpimage.aMask = BMPLoader.GetMask((int)bmpimage.info.nBitsPerPixel) ^ (bmpimage.rMask | bmpimage.gMask | bmpimage.bMask);
			}
			if (bmpimage.info.compressionMethod == BMPComressionMode.BI_ALPHABITFIELDS)
			{
				bmpimage.aMask = aReader.ReadUInt32();
			}
			if (bmpimage.info.nPaletteColors > 0U || bmpimage.info.nBitsPerPixel <= 8)
			{
				bmpimage.palette = BMPLoader.ReadPalette(aReader, bmpimage, this.ReadPaletteAlpha || this.ForceAlphaReadWhenPossible);
			}
			aReader.BaseStream.Seek((long)((ulong)bmpimage.header.offset), SeekOrigin.Begin);
			bool flag = bmpimage.info.compressionMethod == BMPComressionMode.BI_RGB || bmpimage.info.compressionMethod == BMPComressionMode.BI_BITFIELDS || bmpimage.info.compressionMethod == BMPComressionMode.BI_ALPHABITFIELDS;
			if (bmpimage.info.nBitsPerPixel == 32 && flag)
			{
				BMPLoader.Read32BitImage(aReader, bmpimage);
			}
			else if (bmpimage.info.nBitsPerPixel == 24 && flag)
			{
				BMPLoader.Read24BitImage(aReader, bmpimage);
			}
			else if (bmpimage.info.nBitsPerPixel == 16 && flag)
			{
				BMPLoader.Read16BitImage(aReader, bmpimage);
			}
			else if (bmpimage.info.compressionMethod == BMPComressionMode.BI_RLE4 && bmpimage.info.nBitsPerPixel == 4 && bmpimage.palette != null)
			{
				BMPLoader.ReadIndexedImageRLE4(aReader, bmpimage);
			}
			else if (bmpimage.info.compressionMethod == BMPComressionMode.BI_RLE8 && bmpimage.info.nBitsPerPixel == 8 && bmpimage.palette != null)
			{
				BMPLoader.ReadIndexedImageRLE8(aReader, bmpimage);
			}
			else
			{
				if (!flag || bmpimage.info.nBitsPerPixel > 8 || bmpimage.palette == null)
				{
					Debug.LogError("Unsupported file format: " + bmpimage.info.compressionMethod.ToString() + " BPP: " + bmpimage.info.nBitsPerPixel.ToString());
					return null;
				}
				BMPLoader.ReadIndexedImage(aReader, bmpimage);
			}
			return bmpimage;
		}

		// Token: 0x06000E70 RID: 3696 RVA: 0x001115F0 File Offset: 0x0010F7F0
		private static void Read32BitImage(BinaryReader aReader, BMPImage bmp)
		{
			int num = Mathf.Abs(bmp.info.width);
			int num2 = Mathf.Abs(bmp.info.height);
			Color32[] array = (bmp.imageData = new Color32[num * num2]);
			if (aReader.BaseStream.Position + (long)(num * num2 * 4) > aReader.BaseStream.Length)
			{
				Debug.LogError("Unexpected end of file.");
				return;
			}
			int shiftCount = BMPLoader.GetShiftCount(bmp.rMask);
			int shiftCount2 = BMPLoader.GetShiftCount(bmp.gMask);
			int shiftCount3 = BMPLoader.GetShiftCount(bmp.bMask);
			int shiftCount4 = BMPLoader.GetShiftCount(bmp.aMask);
			byte b = byte.MaxValue;
			for (int i = 0; i < array.Length; i++)
			{
				uint num3 = aReader.ReadUInt32();
				byte b2 = (byte)((num3 & bmp.rMask) >> shiftCount);
				byte b3 = (byte)((num3 & bmp.gMask) >> shiftCount2);
				byte b4 = (byte)((num3 & bmp.bMask) >> shiftCount3);
				if (bmp.bMask != 0U)
				{
					b = (byte)((num3 & bmp.aMask) >> shiftCount4);
				}
				array[i] = new Color32(b2, b3, b4, b);
			}
		}

		// Token: 0x06000E71 RID: 3697 RVA: 0x00111718 File Offset: 0x0010F918
		private static void Read24BitImage(BinaryReader aReader, BMPImage bmp)
		{
			int num = Mathf.Abs(bmp.info.width);
			int num2 = Mathf.Abs(bmp.info.height);
			int num3 = (24 * num + 31) / 32 * 4;
			int num4 = num3 * num2;
			int num5 = num3 - num * 3;
			Color32[] array = (bmp.imageData = new Color32[num * num2]);
			if (aReader.BaseStream.Position + (long)num4 > aReader.BaseStream.Length)
			{
				Debug.LogError(string.Concat(new string[]
				{
					"Unexpected end of file. (Have ",
					(aReader.BaseStream.Position + (long)num4).ToString(),
					" bytes, expected ",
					aReader.BaseStream.Length.ToString(),
					" bytes)"
				}));
				return;
			}
			int shiftCount = BMPLoader.GetShiftCount(bmp.rMask);
			int shiftCount2 = BMPLoader.GetShiftCount(bmp.gMask);
			int shiftCount3 = BMPLoader.GetShiftCount(bmp.bMask);
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					int num6 = (int)aReader.ReadByte() | ((int)aReader.ReadByte() << 8) | ((int)aReader.ReadByte() << 16);
					byte b = (byte)((uint)(num6 & (int)bmp.rMask) >> shiftCount);
					byte b2 = (byte)((uint)(num6 & (int)bmp.gMask) >> shiftCount2);
					byte b3 = (byte)((uint)(num6 & (int)bmp.bMask) >> shiftCount3);
					array[j + i * num] = new Color32(b, b2, b3, byte.MaxValue);
				}
				for (int k = 0; k < num5; k++)
				{
					aReader.ReadByte();
				}
			}
		}

		// Token: 0x06000E72 RID: 3698 RVA: 0x001118B4 File Offset: 0x0010FAB4
		private static void Read16BitImage(BinaryReader aReader, BMPImage bmp)
		{
			int num = Mathf.Abs(bmp.info.width);
			int num2 = Mathf.Abs(bmp.info.height);
			int num3 = (16 * num + 31) / 32 * 4;
			int num4 = num3 * num2;
			int num5 = num3 - num * 2;
			Color32[] array = (bmp.imageData = new Color32[num * num2]);
			if (aReader.BaseStream.Position + (long)num4 > aReader.BaseStream.Length)
			{
				Debug.LogError(string.Concat(new string[]
				{
					"Unexpected end of file. (Have ",
					(aReader.BaseStream.Position + (long)num4).ToString(),
					" bytes, expected ",
					aReader.BaseStream.Length.ToString(),
					" bytes)"
				}));
				return;
			}
			int shiftCount = BMPLoader.GetShiftCount(bmp.rMask);
			int shiftCount2 = BMPLoader.GetShiftCount(bmp.gMask);
			int shiftCount3 = BMPLoader.GetShiftCount(bmp.bMask);
			int shiftCount4 = BMPLoader.GetShiftCount(bmp.aMask);
			byte b = byte.MaxValue;
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					uint num6 = (uint)((int)aReader.ReadByte() | ((int)aReader.ReadByte() << 8));
					byte b2 = (byte)((num6 & bmp.rMask) >> shiftCount);
					byte b3 = (byte)((num6 & bmp.gMask) >> shiftCount2);
					byte b4 = (byte)((num6 & bmp.bMask) >> shiftCount3);
					if (bmp.aMask != 0U)
					{
						b = (byte)((num6 & bmp.aMask) >> shiftCount4);
					}
					array[j + i * num] = new Color32(b2, b3, b4, b);
				}
				for (int k = 0; k < num5; k++)
				{
					aReader.ReadByte();
				}
			}
		}

		// Token: 0x06000E73 RID: 3699 RVA: 0x00111A7C File Offset: 0x0010FC7C
		private static void ReadIndexedImage(BinaryReader aReader, BMPImage bmp)
		{
			int num = Mathf.Abs(bmp.info.width);
			int num2 = Mathf.Abs(bmp.info.height);
			int nBitsPerPixel = (int)bmp.info.nBitsPerPixel;
			int num3 = (nBitsPerPixel * num + 31) / 32 * 4;
			int num4 = num3 * num2;
			int num5 = num3 - (num * nBitsPerPixel + 7) / 8;
			Color32[] array = (bmp.imageData = new Color32[num * num2]);
			if (aReader.BaseStream.Position + (long)num4 > aReader.BaseStream.Length)
			{
				Debug.LogError(string.Concat(new string[]
				{
					"Unexpected end of file. (Have ",
					(aReader.BaseStream.Position + (long)num4).ToString(),
					" bytes, expected ",
					aReader.BaseStream.Length.ToString(),
					" bytes)"
				}));
				return;
			}
			BitStreamReader bitStreamReader = new BitStreamReader(aReader);
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					int num6 = (int)bitStreamReader.ReadBits(nBitsPerPixel);
					if (num6 >= bmp.palette.Count)
					{
						Debug.LogError("Indexed bitmap has indices greater than it's color palette");
						return;
					}
					array[j + i * num] = bmp.palette[num6];
				}
				bitStreamReader.Flush();
				for (int k = 0; k < num5; k++)
				{
					aReader.ReadByte();
				}
			}
		}

		// Token: 0x06000E74 RID: 3700 RVA: 0x00111BE4 File Offset: 0x0010FDE4
		private static void ReadIndexedImageRLE4(BinaryReader aReader, BMPImage bmp)
		{
			int num = Mathf.Abs(bmp.info.width);
			int num2 = Mathf.Abs(bmp.info.height);
			Color32[] array = (bmp.imageData = new Color32[num * num2]);
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			while (aReader.BaseStream.Position < aReader.BaseStream.Length - 1L)
			{
				int num6 = (int)aReader.ReadByte();
				byte b = aReader.ReadByte();
				if (num6 > 0)
				{
					for (int i = num6 / 2; i > 0; i--)
					{
						array[num3++ + num5] = bmp.palette[(b >> 4) & 15];
						array[num3++ + num5] = bmp.palette[(int)(b & 15)];
					}
					if ((num6 & 1) > 0)
					{
						array[num3++ + num5] = bmp.palette[(b >> 4) & 15];
					}
				}
				else if (b == 0)
				{
					num3 = 0;
					num4++;
					num5 = num4 * num;
				}
				else
				{
					if (b == 1)
					{
						break;
					}
					if (b == 2)
					{
						num3 += (int)aReader.ReadByte();
						num4 += (int)aReader.ReadByte();
						num5 = num4 * num;
					}
					else
					{
						for (int j = (int)(b / 2); j > 0; j--)
						{
							byte b2 = aReader.ReadByte();
							array[num3++ + num5] = bmp.palette[(b2 >> 4) & 15];
							array[num3++ + num5] = bmp.palette[(int)(b2 & 15)];
						}
						if ((b & 1) > 0)
						{
							array[num3++ + num5] = bmp.palette[(aReader.ReadByte() >> 4) & 15];
						}
						if ((((b - 1) / 2) & 1) == 0)
						{
							aReader.ReadByte();
						}
					}
				}
			}
		}

		// Token: 0x06000E75 RID: 3701 RVA: 0x00111DC4 File Offset: 0x0010FFC4
		private static void ReadIndexedImageRLE8(BinaryReader aReader, BMPImage bmp)
		{
			int num = Mathf.Abs(bmp.info.width);
			int num2 = Mathf.Abs(bmp.info.height);
			Color32[] array = (bmp.imageData = new Color32[num * num2]);
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			while (aReader.BaseStream.Position < aReader.BaseStream.Length - 1L)
			{
				int num6 = (int)aReader.ReadByte();
				byte b = aReader.ReadByte();
				if (num6 > 0)
				{
					for (int i = num6; i > 0; i--)
					{
						array[num3++ + num5] = bmp.palette[(int)b];
					}
				}
				else if (b == 0)
				{
					num3 = 0;
					num4++;
					num5 = num4 * num;
				}
				else
				{
					if (b == 1)
					{
						break;
					}
					if (b == 2)
					{
						num3 += (int)aReader.ReadByte();
						num4 += (int)aReader.ReadByte();
						num5 = num4 * num;
					}
					else
					{
						for (int j = (int)b; j > 0; j--)
						{
							array[num3++ + num5] = bmp.palette[(int)aReader.ReadByte()];
						}
						if ((b & 1) > 0)
						{
							aReader.ReadByte();
						}
					}
				}
			}
		}

		// Token: 0x06000E76 RID: 3702 RVA: 0x00111EF0 File Offset: 0x001100F0
		private static int GetShiftCount(uint mask)
		{
			for (int i = 0; i < 32; i++)
			{
				if ((mask & 1U) > 0U)
				{
					return i;
				}
				mask >>= 1;
			}
			return -1;
		}

		// Token: 0x06000E77 RID: 3703 RVA: 0x00111F18 File Offset: 0x00110118
		private static uint GetMask(int bitCount)
		{
			uint num = 0U;
			for (int i = 0; i < bitCount; i++)
			{
				num <<= 1;
				num |= 1U;
			}
			return num;
		}

		// Token: 0x06000E78 RID: 3704 RVA: 0x00111F3C File Offset: 0x0011013C
		private static bool ReadFileHeader(BinaryReader aReader, ref BMPFileHeader aFileHeader)
		{
			aFileHeader.magic = aReader.ReadUInt16();
			if (aFileHeader.magic != 19778)
			{
				return false;
			}
			aFileHeader.filesize = aReader.ReadUInt32();
			aFileHeader.reserved = aReader.ReadUInt32();
			aFileHeader.offset = aReader.ReadUInt32();
			return true;
		}

		// Token: 0x06000E79 RID: 3705 RVA: 0x00111F8C File Offset: 0x0011018C
		private static bool ReadInfoHeader(BinaryReader aReader, ref BitmapInfoHeader aHeader)
		{
			aHeader.size = aReader.ReadUInt32();
			if (aHeader.size < 40U)
			{
				return false;
			}
			aHeader.width = aReader.ReadInt32();
			aHeader.height = aReader.ReadInt32();
			aHeader.nColorPlanes = aReader.ReadUInt16();
			aHeader.nBitsPerPixel = aReader.ReadUInt16();
			aHeader.compressionMethod = (BMPComressionMode)aReader.ReadInt32();
			aHeader.rawImageSize = aReader.ReadUInt32();
			aHeader.xPPM = aReader.ReadInt32();
			aHeader.yPPM = aReader.ReadInt32();
			aHeader.nPaletteColors = aReader.ReadUInt32();
			aHeader.nImportantColors = aReader.ReadUInt32();
			int num = (int)(aHeader.size - 40U);
			if (num > 0)
			{
				aReader.ReadBytes(num);
			}
			return true;
		}

		// Token: 0x06000E7A RID: 3706 RVA: 0x00112040 File Offset: 0x00110240
		public static List<Color32> ReadPalette(BinaryReader aReader, BMPImage aBmp, bool aReadAlpha)
		{
			uint num = aBmp.info.nPaletteColors;
			if (num == 0U)
			{
				num = 1U << (int)aBmp.info.nBitsPerPixel;
			}
			List<Color32> list = new List<Color32>((int)num);
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				byte b = aReader.ReadByte();
				byte b2 = aReader.ReadByte();
				byte b3 = aReader.ReadByte();
				byte b4 = aReader.ReadByte();
				if (!aReadAlpha)
				{
					b4 = byte.MaxValue;
				}
				if (b == 0 && b3 == 0 && b2 == 255)
				{
					b4 = 0;
				}
				list.Add(new Color32(b3, b2, b, b4));
				num2++;
			}
			return list;
		}

		// Token: 0x040008BF RID: 2239
		private const ushort MAGIC = 19778;

		// Token: 0x040008C0 RID: 2240
		public bool ReadPaletteAlpha;

		// Token: 0x040008C1 RID: 2241
		public bool ForceAlphaReadWhenPossible;
	}
}
