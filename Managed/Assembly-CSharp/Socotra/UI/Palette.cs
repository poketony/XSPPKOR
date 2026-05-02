using System;

namespace Socotra.UI
{
	// Token: 0x020000FD RID: 253
	public class Palette : ICloneable
	{
		// Token: 0x060013A1 RID: 5025 RVA: 0x0012111C File Offset: 0x0011F31C
		public override bool Equals(object obj)
		{
			if (!(obj is Palette))
			{
				return false;
			}
			Palette palette = obj as Palette;
			if (palette.GetEntryCount() != this.GetEntryCount())
			{
				return false;
			}
			for (int i = 0; i < palette.GetEntryCount(); i++)
			{
				if (palette.GetEntry(i) != this.GetEntry(i))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060013A2 RID: 5026 RVA: 0x00121170 File Offset: 0x0011F370
		public Palette Clone()
		{
			Palette palette = (Palette)base.MemberwiseClone();
			if (this.colors != null)
			{
				palette.colors = (int[])this.colors.Clone();
			}
			return palette;
		}

		// Token: 0x060013A3 RID: 5027 RVA: 0x001211A8 File Offset: 0x0011F3A8
		object ICloneable.Clone()
		{
			return this.Clone();
		}

		// Token: 0x060013A4 RID: 5028 RVA: 0x001211B0 File Offset: 0x0011F3B0
		public Palette(int size)
		{
			this.colors = new int[size];
		}

		// Token: 0x060013A5 RID: 5029 RVA: 0x001211C4 File Offset: 0x0011F3C4
		public Palette(int[] colors)
		{
			this.colors = colors;
		}

		// Token: 0x060013A6 RID: 5030 RVA: 0x001211D3 File Offset: 0x0011F3D3
		public int GetEntry(int index)
		{
			if (index < 0 || index >= this.colors.Length)
			{
				return -1;
			}
			return this.colors[index];
		}

		// Token: 0x060013A7 RID: 5031 RVA: 0x001211EE File Offset: 0x0011F3EE
		public int GetEntryCount()
		{
			return this.colors.Length;
		}

		// Token: 0x060013A8 RID: 5032 RVA: 0x001211F8 File Offset: 0x0011F3F8
		public void SetEntry(int index, int color)
		{
			if (index < 0 || index >= this.colors.Length)
			{
				return;
			}
			this.colors[index] = color;
			this.isDirtySetEntryColors = true;
		}

		// Token: 0x04000AF5 RID: 2805
		public bool isDirtySetEntryColors;

		// Token: 0x04000AF6 RID: 2806
		public int[] colors;
	}
}
