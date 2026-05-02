using System;
using UnityEngine;

namespace uTools
{
	// Token: 0x0200007A RID: 122
	public abstract class Tween<T> : Tweener
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000ED6 RID: 3798 RVA: 0x001134B7 File Offset: 0x001116B7
		// (set) Token: 0x06000ED7 RID: 3799 RVA: 0x001134BF File Offset: 0x001116BF
		public virtual T value { get; set; }

		// Token: 0x06000ED8 RID: 3800 RVA: 0x001134C8 File Offset: 0x001116C8
		[ContextMenu("Set 'From' to current value")]
		public override void SetStartToCurrentValue()
		{
			this.from = this.value;
		}

		// Token: 0x06000ED9 RID: 3801 RVA: 0x001134D6 File Offset: 0x001116D6
		[ContextMenu("Set 'To' to current value")]
		public override void SetEndToCurrentValue()
		{
			this.to = this.value;
		}

		// Token: 0x06000EDA RID: 3802 RVA: 0x001134E4 File Offset: 0x001116E4
		[ContextMenu("Assume value of 'From'")]
		public override void SetCurrentValueToStart()
		{
			this.value = this.from;
		}

		// Token: 0x06000EDB RID: 3803 RVA: 0x001134F2 File Offset: 0x001116F2
		[ContextMenu("Assume value of 'To'")]
		public override void SetCurrentValueToEnd()
		{
			this.value = this.to;
		}

		// Token: 0x04000905 RID: 2309
		public T from;

		// Token: 0x04000906 RID: 2310
		public T to;
	}
}
