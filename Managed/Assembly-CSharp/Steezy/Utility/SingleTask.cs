using System;
using System.Collections.Generic;

namespace Steezy.Utility
{
	// Token: 0x0200009D RID: 157
	public class SingleTask
	{
		// Token: 0x06001010 RID: 4112 RVA: 0x00116D6C File Offset: 0x00114F6C
		public void Add(Action<Action> task)
		{
			if (task == null || this.mIsPlaying)
			{
				return;
			}
			this.mList.Add(task);
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x00116D88 File Offset: 0x00114F88
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
			int count = 0;
			Action task = null;
			task = delegate
			{
				if (this.mList.Count <= count)
				{
					onCompleted();
					this.mIsPlaying = false;
					return;
				}
				Action nextTask = task;
				List<Action<Action>> list = this.mList;
				int count2 = count;
				count = count2 + 1;
				list[count2](delegate
				{
					if (nextTask == null)
					{
						return;
					}
					nextTask();
					nextTask = null;
				});
			};
			this.mIsPlaying = true;
			task();
		}

		// Token: 0x04000985 RID: 2437
		private readonly List<Action<Action>> mList = new List<Action<Action>>();

		// Token: 0x04000986 RID: 2438
		private bool mIsPlaying;
	}
}
