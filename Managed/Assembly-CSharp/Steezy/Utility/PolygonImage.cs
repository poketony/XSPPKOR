using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Steezy.Utility
{
	// Token: 0x020000AA RID: 170
	public class PolygonImage : Graphic
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06001049 RID: 4169 RVA: 0x00117CB2 File Offset: 0x00115EB2
		public override Texture mainTexture
		{
			get
			{
				return this.texture;
			}
		}

		// Token: 0x0600104A RID: 4170 RVA: 0x00117CBC File Offset: 0x00115EBC
		protected override void OnPopulateMesh(VertexHelper vh)
		{
			this.vertexNum = Mathf.Max(this.vertexNum, 3);
			Vector3[] array = new Vector3[this.vertexNum + 1 + 1];
			int[] array2 = new int[(this.vertexNum + 1) * 3];
			Vector2[] array3 = new Vector2[array.Length];
			this.SetVertices(array, array2, array3);
			List<UIVertex> list = new List<UIVertex>();
			for (int i = 0; i < array.Length; i++)
			{
				UIVertex uivertex = default(UIVertex);
				uivertex.position = array[i];
				uivertex.color = this.color;
				uivertex.uv0 = array3[i];
				list.Add(uivertex);
			}
			vh.Clear();
			vh.AddUIVertexStream(list, new List<int>(array2));
		}

		// Token: 0x0600104B RID: 4171 RVA: 0x00117D80 File Offset: 0x00115F80
		private void SetVertices(Vector3[] vertices, int[] triangles, Vector2[] uvs)
		{
			int num = vertices.Length - 1;
			Vector2 vector = Vector2.one / 2f;
			vertices[num] = Vector2.zero;
			vertices[num].z = base.transform.position.z;
			uvs[num] = vector;
			float num2 = 360f * this.circumferenceAmount / (float)this.vertexNum;
			for (int i = 0; i < num; i++)
			{
				float num3 = (float)i * num2;
				int num4 = i * 3;
				vertices[i] = PolygonImage.GetNormalizeVector(num3) * this.radius;
				vertices[i].z = base.transform.position.z;
				triangles[num4] = i % vertices.Length;
				triangles[num4 + 1] = num % vertices.Length;
				triangles[num4 + 2] = (i + 1) % vertices.Length;
				uvs[i] = vector + PolygonImage.GetNormalizeVector(num3) * 0.5f;
			}
		}

		// Token: 0x0600104C RID: 4172 RVA: 0x00117E83 File Offset: 0x00116083
		private static Vector2 GetNormalizeVector(float degree)
		{
			return new Vector2(Mathf.Cos(degree * 0.017453292f), Mathf.Sin(degree * 0.017453292f));
		}

		// Token: 0x040009A5 RID: 2469
		[SerializeField]
		private Texture texture;

		// Token: 0x040009A6 RID: 2470
		[Header("頂点数")]
		[SerializeField]
		private int vertexNum = 3;

		// Token: 0x040009A7 RID: 2471
		[SerializeField]
		private float radius = 1f;

		// Token: 0x040009A8 RID: 2472
		[Range(0f, 1f)]
		[SerializeField]
		private float circumferenceAmount = 1f;
	}
}
