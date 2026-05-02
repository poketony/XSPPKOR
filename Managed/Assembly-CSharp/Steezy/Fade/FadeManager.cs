using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Steezy.Fade
{
	// Token: 0x020000D3 RID: 211
	public class FadeManager : MonoBehaviour
	{
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600126E RID: 4718 RVA: 0x0011E238 File Offset: 0x0011C438
		public static FadeManager Instance
		{
			get
			{
				if (FadeManager.instance == null)
				{
					FadeManager.instance = (FadeManager)Object.FindObjectOfType(typeof(FadeManager));
				}
				return FadeManager.instance;
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600126F RID: 4719 RVA: 0x0011E268 File Offset: 0x0011C468
		// (remove) Token: 0x06001270 RID: 4720 RVA: 0x0011E2A0 File Offset: 0x0011C4A0
		public event FadeManager.FadeCallback FadeOutAfter;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06001271 RID: 4721 RVA: 0x0011E2D8 File Offset: 0x0011C4D8
		// (remove) Token: 0x06001272 RID: 4722 RVA: 0x0011E310 File Offset: 0x0011C510
		public event FadeManager.FadeCallback FadeInAfter;

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06001273 RID: 4723 RVA: 0x0011E345 File Offset: 0x0011C545
		// (set) Token: 0x06001274 RID: 4724 RVA: 0x0011E34D File Offset: 0x0011C54D
		public Color FadeColor
		{
			get
			{
				return this.fadeColor;
			}
			set
			{
				this.fadeColor = value;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06001275 RID: 4725 RVA: 0x0011E356 File Offset: 0x0011C556
		// (set) Token: 0x06001276 RID: 4726 RVA: 0x0011E35E File Offset: 0x0011C55E
		public Sprite FadeImage
		{
			get
			{
				return this.fadeImage;
			}
			set
			{
				this.fadeImage = value;
			}
		}

		// Token: 0x06001277 RID: 4727 RVA: 0x0011E367 File Offset: 0x0011C567
		private void Awake()
		{
			if (this.dontDestroyOnLoad)
			{
				Object.DontDestroyOnLoad(base.gameObject);
			}
		}

		// Token: 0x06001278 RID: 4728 RVA: 0x0011E37C File Offset: 0x0011C57C
		public bool IsFade()
		{
			return this.status == FadeManager.FadeStatus.FadeInPlaying || this.status == FadeManager.FadeStatus.FadeOutPlaying;
		}

		// Token: 0x06001279 RID: 4729 RVA: 0x0011E392 File Offset: 0x0011C592
		public void PlayAll(FadeManager.FadeType type, float fadeTime = 0.5f)
		{
			this.Play(type, this.fadeFrontObj, fadeTime);
		}

		// Token: 0x0600127A RID: 4730 RVA: 0x0011E3A2 File Offset: 0x0011C5A2
		public void PlayMenu(FadeManager.FadeType type, float fadeTime = 0.5f)
		{
			this.Play(type, this.fadeBackObj, fadeTime);
		}

		// Token: 0x0600127B RID: 4731 RVA: 0x0011E3B4 File Offset: 0x0011C5B4
		public void Play(FadeManager.FadeType type, Image fadeObj, float fadeTime = 0.5f)
		{
			if (fadeObj == null)
			{
				Debug.LogError("fadeObj is null.");
				return;
			}
			this.fadeTexture = fadeObj;
			this.fadeTexture.enabled = true;
			this.fadeTexture.sprite = this.fadeImage;
			this.PlayFade(type, fadeTime);
		}

		// Token: 0x0600127C RID: 4732 RVA: 0x0011E401 File Offset: 0x0011C601
		private void PlayFade(FadeManager.FadeType type, float fadeTime)
		{
			this.PlayFade(type, fadeTime, float.MaxValue, float.MaxValue);
		}

		// Token: 0x0600127D RID: 4733 RVA: 0x0011E418 File Offset: 0x0011C618
		private void PlayFade(FadeManager.FadeType type, float fadeTime, float startAlpha, float endAlpha)
		{
			if (type == FadeManager.FadeType.In)
			{
				this.fadeTime = fadeTime;
				if (startAlpha == 3.4028235E+38f)
				{
					this.alpha = 1f;
				}
				else
				{
					this.alpha = startAlpha;
				}
				if (endAlpha == 3.4028235E+38f)
				{
					this.fadeEndAlpha = 0f;
				}
				else
				{
					this.fadeEndAlpha = endAlpha;
				}
				this.fadeAlphaRange = Math.Abs(this.fadeEndAlpha - this.alpha);
				this.status = FadeManager.FadeStatus.FadeInPlaying;
				base.StartCoroutine(this.FadeInStart());
			}
			else if (type == FadeManager.FadeType.Out)
			{
				this.fadeTime = fadeTime;
				if (startAlpha == 3.4028235E+38f)
				{
					this.alpha = 0f;
				}
				else
				{
					this.alpha = startAlpha;
				}
				if (endAlpha == 3.4028235E+38f)
				{
					this.fadeEndAlpha = 1f;
				}
				else
				{
					this.fadeEndAlpha = endAlpha;
				}
				this.fadeAlphaRange = Math.Abs(this.fadeEndAlpha - this.alpha);
				this.status = FadeManager.FadeStatus.FadeOutPlaying;
				base.StartCoroutine(this.FadeOutStart());
			}
			else if (type == FadeManager.FadeType.OutIn)
			{
				this.fadeTime = fadeTime;
				base.StartCoroutine(this.FadeOutInStart());
			}
			this.fadeTexture.color = this.SetAndGetTempColor(this.fadeColor.r, this.fadeColor.g, this.fadeColor.b, this.alpha);
		}

		// Token: 0x0600127E RID: 4734 RVA: 0x0011E55D File Offset: 0x0011C75D
		private IEnumerator FadeOutInStart()
		{
			Debug.Log("FadeOutInStart");
			this.PlayFade(FadeManager.FadeType.Out, this.fadeTime);
			yield return new WaitForSecondsRealtime(this.fadeTime);
			if (this.FadeOutAfter != null)
			{
				this.FadeOutAfter();
				this.FadeOutAfter = null;
			}
			this.PlayFade(FadeManager.FadeType.In, this.fadeTime);
			yield return new WaitForSecondsRealtime(this.fadeTime);
			if (this.FadeInAfter != null)
			{
				this.FadeInAfter();
				this.FadeInAfter = null;
			}
			yield break;
		}

		// Token: 0x0600127F RID: 4735 RVA: 0x0011E56C File Offset: 0x0011C76C
		private IEnumerator FadeOutStart()
		{
			Debug.Log("FadeOutStart");
			yield return new WaitForSecondsRealtime(this.fadeTime);
			if (this.FadeOutAfter != null)
			{
				this.FadeOutAfter();
				this.FadeOutAfter = null;
			}
			yield break;
		}

		// Token: 0x06001280 RID: 4736 RVA: 0x0011E57B File Offset: 0x0011C77B
		private IEnumerator FadeInStart()
		{
			Debug.Log("FadeInStart");
			yield return new WaitForSecondsRealtime(this.fadeTime);
			if (this.FadeInAfter != null)
			{
				this.FadeInAfter();
				this.FadeInAfter = null;
			}
			yield break;
		}

		// Token: 0x06001281 RID: 4737 RVA: 0x0011E58A File Offset: 0x0011C78A
		public void Stop()
		{
			this.status = FadeManager.FadeStatus.FadeStop;
		}

		// Token: 0x06001282 RID: 4738 RVA: 0x0011E594 File Offset: 0x0011C794
		private void Update()
		{
			if (this.status == FadeManager.FadeStatus.FadeStop)
			{
				return;
			}
			if (this.status == FadeManager.FadeStatus.FadeInFinish)
			{
				return;
			}
			if (this.status == FadeManager.FadeStatus.FadeOutFinish)
			{
				return;
			}
			if (this.status == FadeManager.FadeStatus.FadeInPlaying)
			{
				this.alpha -= Time.unscaledDeltaTime * this.fadeAlphaRange / this.fadeTime;
				if (this.alpha < this.fadeEndAlpha)
				{
					this.alpha = this.fadeEndAlpha;
					this.status = FadeManager.FadeStatus.FadeInFinish;
					this.fadeTexture.enabled = false;
				}
			}
			if (this.status == FadeManager.FadeStatus.FadeOutPlaying)
			{
				this.alpha += Time.unscaledDeltaTime * this.fadeAlphaRange / this.fadeTime;
				if (this.alpha > this.fadeEndAlpha)
				{
					this.alpha = this.fadeEndAlpha;
					this.status = FadeManager.FadeStatus.FadeOutFinish;
				}
			}
			this.fadeTexture.color = this.SetAndGetTempColor(this.fadeColor.r, this.fadeColor.g, this.fadeColor.b, this.alpha);
		}

		// Token: 0x06001283 RID: 4739 RVA: 0x0011E698 File Offset: 0x0011C898
		public void ImmidiateFade(FadeManager.FadeType type)
		{
			switch (type)
			{
			case FadeManager.FadeType.In:
			case FadeManager.FadeType.OutIn:
				this.fadeTexture.enabled = false;
				return;
			case FadeManager.FadeType.Out:
				this.fadeTexture = this.fadeFrontObj;
				this.fadeTexture.enabled = true;
				this.fadeTexture.sprite = this.fadeImage;
				this.fadeTexture.color = this.SetAndGetTempColor(this.fadeColor.r, this.fadeColor.g, this.fadeColor.b, 1f);
				return;
			default:
				return;
			}
		}

		// Token: 0x06001284 RID: 4740 RVA: 0x0011E725 File Offset: 0x0011C925
		private Color SetAndGetTempColor(float r, float g, float b, float a)
		{
			this.fadeColor.r = r;
			this.fadeColor.g = g;
			this.fadeColor.b = b;
			this.fadeColor.a = a;
			return this.fadeColor;
		}

		// Token: 0x04000A41 RID: 2625
		private static FadeManager instance;

		// Token: 0x04000A42 RID: 2626
		[SerializeField]
		private bool dontDestroyOnLoad = true;

		// Token: 0x04000A43 RID: 2627
		private FadeManager.FadeStatus status;

		// Token: 0x04000A46 RID: 2630
		private const float DefaultFadeTime = 0.5f;

		// Token: 0x04000A47 RID: 2631
		private const float DefaultAlpha = 3.4028235E+38f;

		// Token: 0x04000A48 RID: 2632
		private float alpha;

		// Token: 0x04000A49 RID: 2633
		private float fadeEndAlpha;

		// Token: 0x04000A4A RID: 2634
		private float fadeAlphaRange;

		// Token: 0x04000A4B RID: 2635
		private float fadeTime = 0.5f;

		// Token: 0x04000A4C RID: 2636
		private Color fadeColor = Color.black;

		// Token: 0x04000A4D RID: 2637
		private Sprite fadeImage;

		// Token: 0x04000A4E RID: 2638
		private Image fadeTexture;

		// Token: 0x04000A4F RID: 2639
		[SerializeField]
		private Image fadeFrontObj;

		// Token: 0x04000A50 RID: 2640
		[SerializeField]
		private Image fadeBackObj;

		// Token: 0x0200022E RID: 558
		public enum FadeStatus
		{
			// Token: 0x040014A4 RID: 5284
			FadeStop,
			// Token: 0x040014A5 RID: 5285
			FadeInPlaying,
			// Token: 0x040014A6 RID: 5286
			FadeInFinish,
			// Token: 0x040014A7 RID: 5287
			FadeOutPlaying,
			// Token: 0x040014A8 RID: 5288
			FadeOutFinish
		}

		// Token: 0x0200022F RID: 559
		public enum FadeType
		{
			// Token: 0x040014AA RID: 5290
			In,
			// Token: 0x040014AB RID: 5291
			Out,
			// Token: 0x040014AC RID: 5292
			OutIn
		}

		// Token: 0x02000230 RID: 560
		// (Invoke) Token: 0x06001D75 RID: 7541
		public delegate void FadeCallback();
	}
}
