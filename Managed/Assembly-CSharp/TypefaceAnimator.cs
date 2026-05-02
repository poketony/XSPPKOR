using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000063 RID: 99
[RequireComponent(typeof(Text))]
[AddComponentMenu("UI/Effects/TypefaceAnimator")]
public class TypefaceAnimator : BaseMeshEffect
{
	// Token: 0x17000019 RID: 25
	// (get) Token: 0x06000E3F RID: 3647 RVA: 0x0010ECC2 File Offset: 0x0010CEC2
	// (set) Token: 0x06000E40 RID: 3648 RVA: 0x0010ECCA File Offset: 0x0010CECA
	public float progress
	{
		get
		{
			return this.m_progress;
		}
		set
		{
			this.m_progress = value;
			if (base.graphic != null)
			{
				base.graphic.SetVerticesDirty();
			}
		}
	}

	// Token: 0x1700001A RID: 26
	// (get) Token: 0x06000E41 RID: 3649 RVA: 0x0010ECEC File Offset: 0x0010CEEC
	public bool isPlaying
	{
		get
		{
			return this.m_isPlaying;
		}
	}

	// Token: 0x06000E42 RID: 3650 RVA: 0x0010ECF4 File Offset: 0x0010CEF4
	protected override void OnEnable()
	{
		if (this.playOnAwake)
		{
			this.Play();
		}
		base.OnEnable();
	}

	// Token: 0x06000E43 RID: 3651 RVA: 0x0010ED0A File Offset: 0x0010CF0A
	protected override void OnDisable()
	{
		this.Stop();
		base.OnDisable();
	}

	// Token: 0x06000E44 RID: 3652 RVA: 0x0010ED18 File Offset: 0x0010CF18
	public void Play()
	{
		this.progress = 0f;
		TypefaceAnimator.TimeMode timeMode = this.timeMode;
		if (timeMode != TypefaceAnimator.TimeMode.Time)
		{
			if (timeMode == TypefaceAnimator.TimeMode.Speed)
			{
				this.animationTime = (float)this.characterNumber / 10f / this.speed;
			}
		}
		else
		{
			this.animationTime = this.duration;
		}
		switch (this.style)
		{
		case TypefaceAnimator.Style.Once:
			this.playCoroutine = base.StartCoroutine(this.PlayOnceCoroutine());
			return;
		case TypefaceAnimator.Style.Loop:
			this.playCoroutine = base.StartCoroutine(this.PlayLoopCoroutine());
			return;
		case TypefaceAnimator.Style.PingPong:
			this.playCoroutine = base.StartCoroutine(this.PlayPingPongCoroutine());
			return;
		default:
			return;
		}
	}

	// Token: 0x06000E45 RID: 3653 RVA: 0x0010EDBA File Offset: 0x0010CFBA
	public void Stop()
	{
		if (this.playCoroutine != null)
		{
			base.StopCoroutine(this.playCoroutine);
		}
		this.m_isPlaying = false;
		this.playCoroutine = null;
	}

	// Token: 0x06000E46 RID: 3654 RVA: 0x0010EDDE File Offset: 0x0010CFDE
	private IEnumerator PlayOnceCoroutine()
	{
		if (this.delay > 0f)
		{
			if (this.ignoreTimeScale)
			{
				yield return new WaitForSecondsRealtime(this.delay);
			}
			else
			{
				yield return new WaitForSeconds(this.delay);
			}
		}
		float delta = (this.ignoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime);
		if (this.m_isPlaying)
		{
			yield break;
		}
		this.m_isPlaying = true;
		if (this.onStart != null)
		{
			this.onStart.Invoke();
		}
		while (this.progress < 1f)
		{
			this.progress += delta / this.animationTime;
			yield return null;
		}
		this.m_isPlaying = false;
		this.progress = 1f;
		if (this.onComplete != null)
		{
			this.onComplete.Invoke();
		}
		yield break;
	}

	// Token: 0x06000E47 RID: 3655 RVA: 0x0010EDED File Offset: 0x0010CFED
	private IEnumerator PlayLoopCoroutine()
	{
		if (this.delay > 0f)
		{
			if (this.ignoreTimeScale)
			{
				yield return new WaitForSecondsRealtime(this.delay);
			}
			else
			{
				yield return new WaitForSeconds(this.delay);
			}
		}
		float delta = (this.ignoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime);
		if (this.m_isPlaying)
		{
			yield break;
		}
		this.m_isPlaying = true;
		if (this.onStart != null)
		{
			this.onStart.Invoke();
		}
		for (;;)
		{
			this.progress += delta / this.animationTime;
			if (this.progress > 1f)
			{
				this.progress -= 1f;
			}
			yield return null;
		}
		yield break;
	}

	// Token: 0x06000E48 RID: 3656 RVA: 0x0010EDFC File Offset: 0x0010CFFC
	private IEnumerator PlayPingPongCoroutine()
	{
		if (this.delay > 0f)
		{
			if (this.ignoreTimeScale)
			{
				yield return new WaitForSecondsRealtime(this.delay);
			}
			else
			{
				yield return new WaitForSeconds(this.delay);
			}
		}
		float delta = (this.ignoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime);
		if (this.m_isPlaying)
		{
			yield break;
		}
		this.m_isPlaying = true;
		if (this.onStart != null)
		{
			this.onStart.Invoke();
		}
		bool isPositive = true;
		for (;;)
		{
			float num = delta / this.animationTime;
			if (isPositive)
			{
				this.progress += num;
				if (this.progress > 1f)
				{
					isPositive = false;
					this.progress -= num;
				}
			}
			else
			{
				this.progress -= num;
				if (this.progress < 0f)
				{
					isPositive = true;
					this.progress += num;
				}
			}
			yield return null;
		}
		yield break;
	}

	// Token: 0x06000E49 RID: 3657 RVA: 0x0010EE0C File Offset: 0x0010D00C
	public override void ModifyMesh(VertexHelper vertexHelper)
	{
		if (!this.IsActive() || vertexHelper.currentVertCount == 0)
		{
			return;
		}
		List<UIVertex> list = new List<UIVertex>();
		vertexHelper.GetUIVertexStream(list);
		List<UIVertex> list2 = new List<UIVertex>();
		for (int i = 0; i < list.Count; i++)
		{
			int num = i % 6;
			if (num == 0 || num == 1 || num == 2 || num == 4)
			{
				list2.Add(list[i]);
			}
		}
		this.ModifyVertices(list2);
		List<UIVertex> list3 = new List<UIVertex>(list.Count);
		for (int j = 0; j < list.Count / 6; j++)
		{
			int num2 = j * 4;
			list3.Add(list2[num2]);
			list3.Add(list2[num2 + 1]);
			list3.Add(list2[num2 + 2]);
			list3.Add(list2[num2 + 2]);
			list3.Add(list2[num2 + 3]);
			list3.Add(list2[num2]);
		}
		vertexHelper.Clear();
		vertexHelper.AddUIVertexTriangleStream(list3);
	}

	// Token: 0x06000E4A RID: 3658 RVA: 0x0010EF0C File Offset: 0x0010D10C
	public void ModifyVertices(List<UIVertex> verts)
	{
		if (!this.IsActive())
		{
			return;
		}
		this.Modify(verts);
	}

	// Token: 0x06000E4B RID: 3659 RVA: 0x0010EF20 File Offset: 0x0010D120
	private void Modify(List<UIVertex> verts)
	{
		this.characterNumber = verts.Count / 4;
		for (int i = 0; i < verts.Count; i++)
		{
			if (i % 4 == 0)
			{
				int num = i / 4;
				UIVertex uivertex = verts[i];
				UIVertex uivertex2 = verts[i + 1];
				UIVertex uivertex3 = verts[i + 2];
				UIVertex uivertex4 = verts[i + 3];
				if (this.usePosition)
				{
					float num2 = this.positionAnimationCurve.Evaluate(TypefaceAnimator.SeparationRate(this.progress, num, this.characterNumber, this.positionSeparation));
					Vector3 vector = (this.positionTo - this.positionFrom) * num2 + this.positionFrom;
					uivertex.position += vector;
					uivertex2.position += vector;
					uivertex3.position += vector;
					uivertex4.position += vector;
				}
				if (this.useScale)
				{
					if (this.scaleSyncXY)
					{
						float num3 = this.scaleAnimationCurve.Evaluate(TypefaceAnimator.SeparationRate(this.progress, num, this.characterNumber, this.scaleSeparation));
						float num4 = (this.scaleTo - this.scaleFrom) * num3 + this.scaleFrom;
						float num5 = (uivertex2.position.x - uivertex4.position.x) * this.scalePivot.x + uivertex4.position.x;
						float num6 = (uivertex2.position.y - uivertex4.position.y) * this.scalePivot.y + uivertex4.position.y;
						Vector3 vector2;
						vector2..ctor(num5, num6, 0f);
						uivertex.position = (uivertex.position - vector2) * num4 + vector2;
						uivertex2.position = (uivertex2.position - vector2) * num4 + vector2;
						uivertex3.position = (uivertex3.position - vector2) * num4 + vector2;
						uivertex4.position = (uivertex4.position - vector2) * num4 + vector2;
					}
					else
					{
						float num7 = this.scaleAnimationCurve.Evaluate(TypefaceAnimator.SeparationRate(this.progress, num, this.characterNumber, this.scaleSeparation));
						float num8 = (this.scaleTo - this.scaleFrom) * num7 + this.scaleFrom;
						float num9 = (uivertex2.position.x - uivertex4.position.x) * this.scalePivot.x + uivertex4.position.x;
						float num10 = (uivertex2.position.y - uivertex4.position.y) * this.scalePivot.y + uivertex4.position.y;
						Vector3 vector3;
						vector3..ctor(num9, num10, 0f);
						uivertex.position = new Vector3(((uivertex.position - vector3) * num8 + vector3).x, uivertex.position.y, uivertex.position.z);
						uivertex2.position = new Vector3(((uivertex2.position - vector3) * num8 + vector3).x, uivertex2.position.y, uivertex2.position.z);
						uivertex3.position = new Vector3(((uivertex3.position - vector3) * num8 + vector3).x, uivertex3.position.y, uivertex3.position.z);
						uivertex4.position = new Vector3(((uivertex4.position - vector3) * num8 + vector3).x, uivertex4.position.y, uivertex4.position.z);
						num7 = this.scaleAnimationCurveY.Evaluate(TypefaceAnimator.SeparationRate(this.progress, num, this.characterNumber, this.scaleSeparation));
						num8 = (this.scaleToY - this.scaleFromY) * num7 + this.scaleFromY;
						num9 = (uivertex2.position.x - uivertex4.position.x) * this.scalePivotY.x + uivertex4.position.x;
						num10 = (uivertex2.position.y - uivertex4.position.y) * this.scalePivotY.y + uivertex4.position.y;
						vector3..ctor(num9, num10, 0f);
						uivertex.position = new Vector3(uivertex.position.x, ((uivertex.position - vector3) * num8 + vector3).y, uivertex.position.z);
						uivertex2.position = new Vector3(uivertex2.position.x, ((uivertex2.position - vector3) * num8 + vector3).y, uivertex2.position.z);
						uivertex3.position = new Vector3(uivertex3.position.x, ((uivertex3.position - vector3) * num8 + vector3).y, uivertex3.position.z);
						uivertex4.position = new Vector3(uivertex4.position.x, ((uivertex4.position - vector3) * num8 + vector3).y, uivertex4.position.z);
					}
				}
				if (this.useRotation)
				{
					float num11 = this.rotationAnimationCurve.Evaluate(TypefaceAnimator.SeparationRate(this.progress, num, this.characterNumber, this.rotationSeparation));
					float num12 = (this.rotationTo - this.rotationFrom) * num11 + this.rotationFrom;
					float num13 = (uivertex2.position.x - uivertex4.position.x) * this.rotationPivot.x + uivertex4.position.x;
					float num14 = (uivertex2.position.y - uivertex4.position.y) * this.rotationPivot.y + uivertex4.position.y;
					Vector3 vector4;
					vector4..ctor(num13, num14, 0f);
					uivertex.position = Quaternion.AngleAxis(num12, Vector3.forward) * (uivertex.position - vector4) + vector4;
					uivertex2.position = Quaternion.AngleAxis(num12, Vector3.forward) * (uivertex2.position - vector4) + vector4;
					uivertex3.position = Quaternion.AngleAxis(num12, Vector3.forward) * (uivertex3.position - vector4) + vector4;
					uivertex4.position = Quaternion.AngleAxis(num12, Vector3.forward) * (uivertex4.position - vector4) + vector4;
				}
				Color color = uivertex.color;
				if (this.useColor)
				{
					float num15 = this.colorAnimationCurve.Evaluate(TypefaceAnimator.SeparationRate(this.progress, num, this.characterNumber, this.colorSeparation));
					color = (this.colorTo - this.colorFrom) * num15 + this.colorFrom;
					uivertex.color = (uivertex2.color = (uivertex3.color = (uivertex4.color = color)));
				}
				if (this.useAlpha)
				{
					float num16 = this.alphaAnimationCurve.Evaluate(TypefaceAnimator.SeparationRate(this.progress, num, this.characterNumber, this.alphaSeparation));
					float num17 = (this.alphaTo - this.alphaFrom) * num16 + this.alphaFrom;
					color..ctor(color.r, color.g, color.b, color.a * num17);
					uivertex.color = (uivertex2.color = (uivertex3.color = (uivertex4.color = color)));
				}
				verts[i] = uivertex;
				verts[i + 1] = uivertex2;
				verts[i + 2] = uivertex3;
				verts[i + 3] = uivertex4;
			}
		}
	}

	// Token: 0x06000E4C RID: 3660 RVA: 0x0010F7E9 File Offset: 0x0010D9E9
	private static float SeparationRate(float progress, int currentCharacterNumber, int characterNumber, float separation)
	{
		return Mathf.Clamp01((progress - (float)currentCharacterNumber * separation / (float)characterNumber) / (separation / (float)characterNumber + 1f - separation));
	}

	// Token: 0x0400086F RID: 2159
	public TypefaceAnimator.TimeMode timeMode;

	// Token: 0x04000870 RID: 2160
	public float duration = 1f;

	// Token: 0x04000871 RID: 2161
	public float speed = 5f;

	// Token: 0x04000872 RID: 2162
	public float delay;

	// Token: 0x04000873 RID: 2163
	public TypefaceAnimator.Style style;

	// Token: 0x04000874 RID: 2164
	public bool playOnAwake = true;

	// Token: 0x04000875 RID: 2165
	public bool ignoreTimeScale;

	// Token: 0x04000876 RID: 2166
	[SerializeField]
	private float m_progress = 1f;

	// Token: 0x04000877 RID: 2167
	public bool usePosition;

	// Token: 0x04000878 RID: 2168
	public bool useRotation;

	// Token: 0x04000879 RID: 2169
	public bool useScale;

	// Token: 0x0400087A RID: 2170
	public bool useAlpha;

	// Token: 0x0400087B RID: 2171
	public bool useColor;

	// Token: 0x0400087C RID: 2172
	public UnityEvent onStart;

	// Token: 0x0400087D RID: 2173
	public UnityEvent onComplete;

	// Token: 0x0400087E RID: 2174
	[SerializeField]
	private int characterNumber;

	// Token: 0x0400087F RID: 2175
	private float animationTime;

	// Token: 0x04000880 RID: 2176
	private Coroutine playCoroutine;

	// Token: 0x04000881 RID: 2177
	private bool m_isPlaying;

	// Token: 0x04000882 RID: 2178
	public Vector3 positionFrom = Vector3.zero;

	// Token: 0x04000883 RID: 2179
	public Vector3 positionTo = Vector3.zero;

	// Token: 0x04000884 RID: 2180
	public AnimationCurve positionAnimationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	// Token: 0x04000885 RID: 2181
	public float positionSeparation = 0.5f;

	// Token: 0x04000886 RID: 2182
	public float rotationFrom;

	// Token: 0x04000887 RID: 2183
	public float rotationTo;

	// Token: 0x04000888 RID: 2184
	public Vector2 rotationPivot = new Vector2(0.5f, 0.5f);

	// Token: 0x04000889 RID: 2185
	public AnimationCurve rotationAnimationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	// Token: 0x0400088A RID: 2186
	public float rotationSeparation = 0.5f;

	// Token: 0x0400088B RID: 2187
	public bool scaleSyncXY = true;

	// Token: 0x0400088C RID: 2188
	public float scaleFrom;

	// Token: 0x0400088D RID: 2189
	public float scaleTo = 1f;

	// Token: 0x0400088E RID: 2190
	public Vector2 scalePivot = new Vector2(0.5f, 0.5f);

	// Token: 0x0400088F RID: 2191
	public AnimationCurve scaleAnimationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	// Token: 0x04000890 RID: 2192
	public float scaleFromY;

	// Token: 0x04000891 RID: 2193
	public float scaleToY = 1f;

	// Token: 0x04000892 RID: 2194
	public Vector2 scalePivotY = new Vector2(0.5f, 0.5f);

	// Token: 0x04000893 RID: 2195
	public AnimationCurve scaleAnimationCurveY = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	// Token: 0x04000894 RID: 2196
	public float scaleSeparation = 0.5f;

	// Token: 0x04000895 RID: 2197
	public float alphaFrom;

	// Token: 0x04000896 RID: 2198
	public float alphaTo = 1f;

	// Token: 0x04000897 RID: 2199
	public AnimationCurve alphaAnimationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	// Token: 0x04000898 RID: 2200
	public float alphaSeparation = 0.5f;

	// Token: 0x04000899 RID: 2201
	public Color colorFrom = Color.white;

	// Token: 0x0400089A RID: 2202
	public Color colorTo = Color.white;

	// Token: 0x0400089B RID: 2203
	public AnimationCurve colorAnimationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	// Token: 0x0400089C RID: 2204
	public float colorSeparation = 0.5f;

	// Token: 0x020001E3 RID: 483
	public enum TimeMode
	{
		// Token: 0x0400135E RID: 4958
		Time,
		// Token: 0x0400135F RID: 4959
		Speed
	}

	// Token: 0x020001E4 RID: 484
	public enum Style
	{
		// Token: 0x04001361 RID: 4961
		Once,
		// Token: 0x04001362 RID: 4962
		Loop,
		// Token: 0x04001363 RID: 4963
		PingPong
	}
}
