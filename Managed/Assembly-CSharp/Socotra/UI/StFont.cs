using System;
using System.Collections.Generic;
using System.Text;
using Steezy.Utility;
using UnityEngine;

namespace Socotra.UI
{
	// Token: 0x02000103 RID: 259
	public class StFont
	{
		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060013E5 RID: 5093 RVA: 0x00121CD9 File Offset: 0x0011FED9
		public Font Font
		{
			get
			{
				return this.font;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060013E6 RID: 5094 RVA: 0x00121CE1 File Offset: 0x0011FEE1
		public float Size
		{
			get
			{
				return this.fontSize;
			}
		}

		// Token: 0x060013E7 RID: 5095 RVA: 0x00121CE9 File Offset: 0x0011FEE9
		public StFont()
		{
		}

		// Token: 0x060013E8 RID: 5096 RVA: 0x00121CF1 File Offset: 0x0011FEF1
		public StFont(Font font, float size)
		{
			this.font = font;
			this.fontSize = size;
		}

		// Token: 0x060013E9 RID: 5097 RVA: 0x00121D08 File Offset: 0x0011FF08
		public static StFont GetFont(int type)
		{
			int num = 12;
			if ((type & 32) == 32)
			{
				num = 12;
			}
			else if ((type & 64) == 64)
			{
				num = 16;
			}
			else if ((type & 128) == 128)
			{
				num = 24;
			}
			else if ((type & 256) == 256)
			{
				num = 30;
			}
			return SingletonBehaviour<StFontManager>.Instance.GetFont(num);
		}

		// Token: 0x060013EA RID: 5098 RVA: 0x00121D61 File Offset: 0x0011FF61
		public static StFont GetFont(int type, int size)
		{
			return SingletonBehaviour<StFontManager>.Instance.GetFont(size);
		}

		// Token: 0x060013EB RID: 5099 RVA: 0x00121D6E File Offset: 0x0011FF6E
		public static StFont GetDefaultFont()
		{
			return SingletonBehaviour<StFontManager>.Instance.GetFont(12);
		}

		// Token: 0x060013EC RID: 5100 RVA: 0x00121D7C File Offset: 0x0011FF7C
		public int GetAscent()
		{
			return Mathf.CeilToInt((float)this.font.ascent * (this.fontSize / (float)this.font.fontSize));
		}

		// Token: 0x060013ED RID: 5101 RVA: 0x00121DA3 File Offset: 0x0011FFA3
		public int GetWidth()
		{
			return (int)this.fontSize;
		}

		// Token: 0x060013EE RID: 5102 RVA: 0x00121DAC File Offset: 0x0011FFAC
		public int GetHeight()
		{
			return (int)this.fontSize;
		}

		// Token: 0x060013EF RID: 5103 RVA: 0x00121DB5 File Offset: 0x0011FFB5
		public int GetDescent()
		{
			return this.GetHeight() - this.GetAscent();
		}

		// Token: 0x060013F0 RID: 5104 RVA: 0x00121DC4 File Offset: 0x0011FFC4
		public int StringWidth(string str)
		{
			float num = 0f;
			for (int i = 0; i < str.Length; i++)
			{
				if (StFont.IsZenkaku(str[i].ToString()))
				{
					num += (float)this.GetWidth();
				}
				else
				{
					num += (float)this.GetWidth() / 2f;
				}
			}
			return Mathf.CeilToInt(num);
		}

		// Token: 0x060013F1 RID: 5105 RVA: 0x00121E24 File Offset: 0x00120024
		public Mesh GenerateTextMesh(char[] str)
		{
			List<char> list = new List<char>();
			foreach (char c in str)
			{
				if (c == '\0')
				{
					break;
				}
				if (c < ' ')
				{
					c = ' ';
				}
				list.Add(c);
			}
			int count = list.Count;
			Mesh mesh = new Mesh();
			Vector3[] array = new Vector3[count * 4];
			int[] array2 = new int[count * 6];
			Vector2[] array3 = new Vector2[count * 4];
			Vector3 vector = Vector3.zero;
			this.font.RequestCharactersInTexture(new string(list.ToArray()), (int)this.fontSize);
			for (int j = 0; j < count; j++)
			{
				char c2 = list[j];
				CharacterInfo characterInfo = default(CharacterInfo);
				if (!this.font.GetCharacterInfo(c2, ref characterInfo, (int)this.fontSize))
				{
					this.font.RequestCharactersInTexture(' '.ToString(), (int)this.fontSize);
					this.font.GetCharacterInfo(' ', ref characterInfo, (int)this.fontSize);
					string[] array4 = new string[6];
					array4[0] = "<color=\"yellow\">StFontで描画できない文字が渡されました。必要に応じて置き換えをして下さい。</color> パラメータ文字列=[";
					array4[1] = new string(str);
					array4[2] = "], 対象文字=[";
					array4[3] = c2.ToString();
					array4[4] = "], 文字コード=";
					int num = 5;
					int num2 = (int)c2;
					array4[num] = num2.ToString();
					Debug.LogWarning(string.Concat(array4));
				}
				int num3 = (characterInfo.maxY - characterInfo.minY) / 2;
				array[4 * j] = vector + new Vector3((float)characterInfo.minX, (float)characterInfo.minY, 0f);
				array[4 * j + 1] = vector + new Vector3((float)characterInfo.maxX, (float)characterInfo.minY, 0f);
				array[4 * j + 2] = vector + new Vector3((float)characterInfo.maxX, (float)characterInfo.maxY, 0f);
				array[4 * j + 3] = vector + new Vector3((float)characterInfo.minX, (float)characterInfo.maxY, 0f);
				array3[4 * j + 3] = characterInfo.uvTopLeft;
				array3[4 * j + 2] = characterInfo.uvTopRight;
				array3[4 * j + 1] = characterInfo.uvBottomRight;
				array3[4 * j] = characterInfo.uvBottomLeft;
				array2[6 * j] = 4 * j;
				array2[6 * j + 1] = 4 * j + 1;
				array2[6 * j + 2] = 4 * j + 2;
				array2[6 * j + 3] = 4 * j;
				array2[6 * j + 4] = 4 * j + 2;
				array2[6 * j + 5] = 4 * j + 3;
				vector += new Vector3((float)characterInfo.advance, 0f, 0f);
			}
			mesh.vertices = array;
			mesh.triangles = array2;
			mesh.uv = array3;
			return mesh;
		}

		// Token: 0x060013F2 RID: 5106 RVA: 0x00122110 File Offset: 0x00120310
		public StFont.FontMeshData GenerateFontMesh(float x, float y, char[] str)
		{
			List<char> list = new List<char>();
			foreach (char c in str)
			{
				if (c == '\0')
				{
					break;
				}
				if (c < ' ')
				{
					c = ' ';
				}
				list.Add(c);
			}
			int count = list.Count;
			StFont.FontMeshData fontMeshData = new StFont.FontMeshData();
			Vector3[] array = new Vector3[count * 4];
			Vector2[] array2 = new Vector2[count * 4];
			Vector3 vector;
			vector..ctor(x, y);
			this.font.RequestCharactersInTexture(new string(list.ToArray()), (int)this.fontSize);
			for (int j = 0; j < count; j++)
			{
				char c2 = list[j];
				CharacterInfo characterInfo = default(CharacterInfo);
				if (!this.font.GetCharacterInfo(c2, ref characterInfo, (int)this.fontSize))
				{
					this.font.RequestCharactersInTexture(' '.ToString(), (int)this.fontSize);
					this.font.GetCharacterInfo(' ', ref characterInfo, (int)this.fontSize);
					string[] array3 = new string[6];
					array3[0] = "<color=\"yellow\">StFontで描画できない文字が渡されました。必要に応じて置き換えをして下さい。</color> パラメータ文字列=[";
					array3[1] = new string(str);
					array3[2] = "], 対象文字=[";
					array3[3] = c2.ToString();
					array3[4] = "], 文字コード=";
					int num = 5;
					int num2 = (int)c2;
					array3[num] = num2.ToString();
					Debug.LogWarning(string.Concat(array3));
				}
				int num3 = (characterInfo.maxY - characterInfo.minY) / 2;
				array[4 * j] = vector + new Vector3((float)characterInfo.minX, (float)characterInfo.minY, 0f);
				array[4 * j + 1] = vector + new Vector3((float)characterInfo.maxX, (float)characterInfo.minY, 0f);
				array[4 * j + 2] = vector + new Vector3((float)characterInfo.maxX, (float)characterInfo.maxY, 0f);
				array[4 * j + 3] = vector + new Vector3((float)characterInfo.minX, (float)characterInfo.maxY, 0f);
				array2[4 * j + 3] = characterInfo.uvTopLeft;
				array2[4 * j + 2] = characterInfo.uvTopRight;
				array2[4 * j + 1] = characterInfo.uvBottomRight;
				array2[4 * j] = characterInfo.uvBottomLeft;
				vector += new Vector3((float)characterInfo.advance, 0f, 0f);
			}
			fontMeshData.vertices = array;
			fontMeshData.uvs = array2;
			return fontMeshData;
		}

		// Token: 0x060013F3 RID: 5107 RVA: 0x00122396 File Offset: 0x00120596
		public int GetBBoxWidth(string str)
		{
			return str.Length * this.GetWidth();
		}

		// Token: 0x060013F4 RID: 5108 RVA: 0x001223A8 File Offset: 0x001205A8
		public int GetBBoxWidth(string str, int off, int len)
		{
			string text = str.Substring(off, len);
			return this.GetBBoxWidth(text);
		}

		// Token: 0x060013F5 RID: 5109 RVA: 0x001223C8 File Offset: 0x001205C8
		public int GetLineBreak(string str, int off, int len, int width)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str is null");
			}
			if (off < 0)
			{
				throw new ArgumentOutOfRangeException("off is negative value");
			}
			if (len < 0)
			{
				throw new ArgumentOutOfRangeException("len is negative value");
			}
			if (off + len > str.Length)
			{
				throw new ArgumentOutOfRangeException("Specified argument was out of the range of valid values");
			}
			if (width < 0)
			{
				throw new ArgumentOutOfRangeException("width is negative value");
			}
			int num = 0;
			for (int i = len; i > 0; i--)
			{
				string text = str.Substring(off, i);
				if (this.StringWidth(text) <= width)
				{
					num = off + i;
					break;
				}
			}
			return num;
		}

		// Token: 0x060013F6 RID: 5110 RVA: 0x00122452 File Offset: 0x00120652
		private static bool IsZenkaku(string str)
		{
			return StFont.sjisEnc.GetByteCount(str) == str.Length * 2;
		}

		// Token: 0x04000B54 RID: 2900
		public const int TYPE_DEFAULT = 1;

		// Token: 0x04000B55 RID: 2901
		public const int TYPE_HEADING = 2;

		// Token: 0x04000B56 RID: 2902
		public const int FACE_MONOSPACE = 4;

		// Token: 0x04000B57 RID: 2903
		public const int FACE_PROPORTIONAL = 8;

		// Token: 0x04000B58 RID: 2904
		public const int FACE_SYSTEM = 16;

		// Token: 0x04000B59 RID: 2905
		public const int SIZE_TINY = 32;

		// Token: 0x04000B5A RID: 2906
		public const int SIZE_SMALL = 64;

		// Token: 0x04000B5B RID: 2907
		public const int SIZE_MEDIUM = 128;

		// Token: 0x04000B5C RID: 2908
		public const int SIZE_LARGE = 256;

		// Token: 0x04000B5D RID: 2909
		public const int STYLE_PLAIN = 512;

		// Token: 0x04000B5E RID: 2910
		private const int FONT_SIZE_DEFAULT = 12;

		// Token: 0x04000B5F RID: 2911
		private const int FONT_SIZE_TINY = 12;

		// Token: 0x04000B60 RID: 2912
		private const int FONT_SIZE_SMALL = 16;

		// Token: 0x04000B61 RID: 2913
		private const int FONT_SIZE_MEDIUM = 24;

		// Token: 0x04000B62 RID: 2914
		private const int FONT_SIZE_LARGE = 30;

		// Token: 0x04000B63 RID: 2915
		private const char ERROR_CHAR = ' ';

		// Token: 0x04000B64 RID: 2916
		[SerializeField]
		private Font font;

		// Token: 0x04000B65 RID: 2917
		[SerializeField]
		private float fontSize;

		// Token: 0x04000B66 RID: 2918
		private static Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

		// Token: 0x02000241 RID: 577
		public class FontMeshData
		{
			// Token: 0x04001507 RID: 5383
			public Vector2[] uvs;

			// Token: 0x04001508 RID: 5384
			public Vector3[] vertices;
		}
	}
}
