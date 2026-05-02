using System;
using UnityEngine;

// Token: 0x02000029 RID: 41
[RequireComponent(typeof(Animator))]
public class AnimatorUnscaledTime : MonoBehaviour
{
	// Token: 0x060000C4 RID: 196 RVA: 0x0000BE6C File Offset: 0x0000A06C
	private void Awake()
	{
		base.GetComponent<Animator>().updateMode = 2;
	}
}
