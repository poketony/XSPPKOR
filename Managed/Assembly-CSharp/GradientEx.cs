using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000057 RID: 87
[AddComponentMenu("UI/Plus/GradientEx")]
public class GradientEx : BaseMeshEffect
{
	// Token: 0x06000DEA RID: 3562 RVA: 0x0010D840 File Offset: 0x0010BA40
	public override void ModifyMesh(VertexHelper vh)
	{
		if (!this.IsActive())
		{
			return;
		}
		float num = float.MaxValue;
		float num2 = float.MinValue;
		UIVertex simpleVert = UIVertex.simpleVert;
		int i = 0;
		int currentVertCount = vh.currentVertCount;
		while (i < currentVertCount)
		{
			vh.PopulateUIVertex(ref simpleVert, i);
			float num3 = (this.horizontal ? (-simpleVert.position.x) : simpleVert.position.y);
			if (num > num3)
			{
				num = num3;
			}
			if (num2 < num3)
			{
				num2 = num3;
			}
			i++;
		}
		float num4 = num2 - num;
		int j = 0;
		int currentVertCount2 = vh.currentVertCount;
		while (j < currentVertCount2)
		{
			vh.PopulateUIVertex(ref simpleVert, j);
			simpleVert.color *= Color.Lerp(this.colorTo, this.colorFrom, this.curve.Evaluate(((this.horizontal ? (-simpleVert.position.x) : simpleVert.position.y) - num) / num4));
			vh.SetUIVertex(simpleVert, j);
			j++;
		}
	}

	// Token: 0x04000834 RID: 2100
	public bool horizontal;

	// Token: 0x04000835 RID: 2101
	public Color colorFrom = Color.white;

	// Token: 0x04000836 RID: 2102
	public Color colorTo = Color.black;

	// Token: 0x04000837 RID: 2103
	public AnimationCurve curve = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0f, 1f, 1f),
		new Keyframe(1f, 1f, 1f, 1f)
	});
}
