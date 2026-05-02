using System;
using System.Collections;
using System.Collections.Generic;

namespace Steezy.Utility
{
	// Token: 0x0200009C RID: 156
	public class MultiTask
	{
		// Token: 0x0600100B RID: 4107 RVA: 0x00116C14 File Offset: 0x00114E14
		public void Add(Action<Action> task)
		{
			if (task == null || this.mIsPlaying)
			{
				return;
			}
			this.mList.Add(task);
		}

		// Token: 0x0600100C RID: 4108 RVA: 0x00116C30 File Offset: 0x00114E30
		public void Play(Action onCompleted = null)
		{
			if (onCompleted == null)
			{
				onCompleted = delegate
				{
				};
			}
			if (this.mList.Count <= 0)
			{
				onCompleted();
				return;
			}
			this.mIsPlaying = true;
			Action action = MultiTask.CallOfCountsFromDelegate(this.mList.Count, delegate
			{
				onCompleted();
				this.mIsPlaying = false;
			}, null);
			foreach (Action<Action> action2 in this.mList)
			{
				Action nextTask = action;
				action2(delegate
				{
					if (nextTask == null)
					{
						return;
					}
					nextTask();
					nextTask = null;
				});
			}
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x00116D1C File Offset: 0x00114F1C
		private static IEnumerator CallOfCounts(int count, Action onCompleted, Action onUpdated = null)
		{
			if (onUpdated == null)
			{
				onUpdated = delegate
				{
				};
			}
			onUpdated();
			for (;;)
			{
				int num = 0;
				int num2 = count - 1;
				count = num2;
				if (num >= num2)
				{
					break;
				}
				yield return count;
				onUpdated();
			}
			onCompleted();
			onCompleted = null;
			onUpdated = null;
			yield break;
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x00116D39 File Offset: 0x00114F39
		private static Action CallOfCountsFromDelegate(int count, Action onCompleted, Action onUpdated = null)
		{
			IEnumerator coroutine = MultiTask.CallOfCounts(count, onCompleted, onUpdated);
			return delegate
			{
				coroutine.MoveNext();
			};
		}

		// Token: 0x04000983 RID: 2435
		private readonly List<Action<Action>> mList = new List<Action<Action>>();

		// Token: 0x04000984 RID: 2436
		private bool mIsPlaying;
	}
}
