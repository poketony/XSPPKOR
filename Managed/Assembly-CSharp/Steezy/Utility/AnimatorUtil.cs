using System;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x020000AF RID: 175
	public class AnimatorUtil
	{
		// Token: 0x06001069 RID: 4201 RVA: 0x00118419 File Offset: 0x00116619
		public static void Play(Animator animator, string stateName)
		{
			if (animator == null)
			{
				return;
			}
			animator.Play(stateName);
			animator.speed = 1f;
		}

		// Token: 0x0600106A RID: 4202 RVA: 0x00118437 File Offset: 0x00116637
		public static void Play(Animator animator, string stateName, float nomalizedTime)
		{
			if (animator == null)
			{
				return;
			}
			animator.Play(stateName, animator.GetLayerIndex("Base Layer"), nomalizedTime);
			animator.speed = 1f;
		}

		// Token: 0x0600106B RID: 4203 RVA: 0x00118461 File Offset: 0x00116661
		public static void Play(Animator animator, string stateName, string layerName, float nomalizedTime)
		{
			if (animator == null)
			{
				return;
			}
			animator.Play(stateName, animator.GetLayerIndex(layerName), nomalizedTime);
			animator.speed = 1f;
		}

		// Token: 0x0600106C RID: 4204 RVA: 0x00118487 File Offset: 0x00116687
		public static void Stop(Animator animator)
		{
			if (animator == null)
			{
				return;
			}
			animator.speed = 0f;
		}

		// Token: 0x0600106D RID: 4205 RVA: 0x001184A0 File Offset: 0x001166A0
		public static float GetPlayTime(Animator animator)
		{
			if (animator != null)
			{
				return animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("Base Layer")).normalizedTime;
			}
			return 0f;
		}

		// Token: 0x0600106E RID: 4206 RVA: 0x001184D5 File Offset: 0x001166D5
		public static void SetBool(Animator animator, string paramName, bool value)
		{
			if (animator == null)
			{
				return;
			}
			animator.SetBool(paramName, value);
		}

		// Token: 0x0600106F RID: 4207 RVA: 0x001184E9 File Offset: 0x001166E9
		public static void SetInt(Animator animator, string paramName, int value)
		{
			if (animator == null)
			{
				return;
			}
			animator.SetInteger(paramName, value);
		}

		// Token: 0x06001070 RID: 4208 RVA: 0x001184FD File Offset: 0x001166FD
		public static void SetFloat(Animator animator, string paramName, float value)
		{
			if (animator == null)
			{
				return;
			}
			animator.SetFloat(paramName, value);
		}

		// Token: 0x06001071 RID: 4209 RVA: 0x00118514 File Offset: 0x00116714
		public static bool IsPlayOnce(Animator animator, float playProgress = 1f)
		{
			return animator == null || animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("Base Layer")).normalizedTime >= playProgress;
		}

		// Token: 0x06001072 RID: 4210 RVA: 0x0011854C File Offset: 0x0011674C
		public static bool IsPlayOnce(Animator animator, string layerName, float playProgress = 1f)
		{
			return animator == null || string.IsNullOrEmpty(layerName) || animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex(layerName)).normalizedTime >= playProgress;
		}

		// Token: 0x06001073 RID: 4211 RVA: 0x00118588 File Offset: 0x00116788
		public static bool IsPlayOnce(Animator animator, int index, float playProgress = 1f)
		{
			return !(animator == null) && animator.GetCurrentAnimatorStateInfo(index).normalizedTime >= playProgress;
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x001185B5 File Offset: 0x001167B5
		public static bool IsEnd(Animator animator)
		{
			return AnimatorUtil.IsCurrentState(animator, "Base Layer", "Exit");
		}

		// Token: 0x06001075 RID: 4213 RVA: 0x001185C8 File Offset: 0x001167C8
		public static bool IsCurrentState(Animator animator, string stateName)
		{
			return !(animator == null) && !string.IsNullOrEmpty(stateName) && animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("Base Layer")).IsName(stateName);
		}

		// Token: 0x06001076 RID: 4214 RVA: 0x00118604 File Offset: 0x00116804
		public static bool IsCurrentState(Animator animator, string layerName, string stateName)
		{
			return !(animator == null) && !string.IsNullOrEmpty(layerName) && !string.IsNullOrEmpty(stateName) && animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex(layerName)).IsName(stateName);
		}
	}
}
