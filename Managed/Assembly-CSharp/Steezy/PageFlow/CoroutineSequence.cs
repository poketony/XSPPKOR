using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Steezy.PageFlow
{
	// Token: 0x020000C9 RID: 201
	public class CoroutineSequence
	{
		// Token: 0x0600121C RID: 4636 RVA: 0x0011D096 File Offset: 0x0011B296
		public CoroutineSequence(MonoBehaviour owner)
		{
			this._owner = owner;
			this._insertedEnumerators = new List<CoroutineSequence.InsertedEnumerator>();
			this._appendedEnumerators = new List<IEnumerator>();
			this._coroutines = new List<Coroutine>();
			this._sequences = new List<CoroutineSequence>();
		}

		// Token: 0x0600121D RID: 4637 RVA: 0x0011D0D1 File Offset: 0x0011B2D1
		public CoroutineSequence Insert(float atPosition, IEnumerator enumerator)
		{
			this._insertedEnumerators.Add(new CoroutineSequence.InsertedEnumerator(atPosition, enumerator));
			return this;
		}

		// Token: 0x0600121E RID: 4638 RVA: 0x0011D0E6 File Offset: 0x0011B2E6
		public CoroutineSequence Insert(float atPosition, CoroutineSequence sequence)
		{
			this._insertedEnumerators.Add(new CoroutineSequence.InsertedEnumerator(atPosition, sequence.GetEnumerator()));
			this._sequences.Add(sequence);
			return this;
		}

		// Token: 0x0600121F RID: 4639 RVA: 0x0011D10C File Offset: 0x0011B30C
		public CoroutineSequence InsertCallback(float atPosition, Action callback)
		{
			this._insertedEnumerators.Add(new CoroutineSequence.InsertedEnumerator(atPosition, this.GetCallbackEnumerator(callback)));
			return this;
		}

		// Token: 0x06001220 RID: 4640 RVA: 0x0011D127 File Offset: 0x0011B327
		public CoroutineSequence Append(IEnumerator enumerator)
		{
			this._appendedEnumerators.Add(enumerator);
			return this;
		}

		// Token: 0x06001221 RID: 4641 RVA: 0x0011D136 File Offset: 0x0011B336
		public CoroutineSequence Append(CoroutineSequence sequence)
		{
			this._appendedEnumerators.Add(sequence.GetEnumerator());
			this._sequences.Add(sequence);
			return this;
		}

		// Token: 0x06001222 RID: 4642 RVA: 0x0011D156 File Offset: 0x0011B356
		public CoroutineSequence AppendCallback(Action callback)
		{
			this._appendedEnumerators.Add(this.GetCallbackEnumerator(callback));
			return this;
		}

		// Token: 0x06001223 RID: 4643 RVA: 0x0011D16B File Offset: 0x0011B36B
		public CoroutineSequence AppendInterval(float seconds)
		{
			this._appendedEnumerators.Add(this.GetWaitForSecondsEnumerator(seconds));
			return this;
		}

		// Token: 0x06001224 RID: 4644 RVA: 0x0011D180 File Offset: 0x0011B380
		public CoroutineSequence OnCompleted(Action action)
		{
			this._onCompleted = (Action)Delegate.Combine(this._onCompleted, action);
			return this;
		}

		// Token: 0x06001225 RID: 4645 RVA: 0x0011D19C File Offset: 0x0011B39C
		public Coroutine Play()
		{
			Coroutine coroutine = this._owner.StartCoroutine(this.GetEnumerator());
			this._coroutines.Add(coroutine);
			return coroutine;
		}

		// Token: 0x06001226 RID: 4646 RVA: 0x0011D1C8 File Offset: 0x0011B3C8
		public void Stop()
		{
			foreach (Coroutine coroutine in this._coroutines)
			{
				this._owner.StopCoroutine(coroutine);
			}
			foreach (CoroutineSequence.InsertedEnumerator insertedEnumerator in this._insertedEnumerators)
			{
				this._owner.StopCoroutine(insertedEnumerator.InternalEnumerator);
			}
			foreach (IEnumerator enumerator4 in this._appendedEnumerators)
			{
				this._owner.StopCoroutine(enumerator4);
			}
			foreach (CoroutineSequence coroutineSequence in this._sequences)
			{
				coroutineSequence.Stop();
			}
			this._coroutines.Clear();
			this._insertedEnumerators.Clear();
			this._appendedEnumerators.Clear();
			this._sequences.Clear();
		}

		// Token: 0x06001227 RID: 4647 RVA: 0x0011D324 File Offset: 0x0011B524
		private IEnumerator GetCallbackEnumerator(Action callback)
		{
			callback();
			yield break;
		}

		// Token: 0x06001228 RID: 4648 RVA: 0x0011D333 File Offset: 0x0011B533
		private IEnumerator GetWaitForSecondsEnumerator(float seconds)
		{
			yield return new WaitForSeconds(seconds);
			yield break;
		}

		// Token: 0x06001229 RID: 4649 RVA: 0x0011D342 File Offset: 0x0011B542
		private IEnumerator GetEnumerator()
		{
			int counter = this._insertedEnumerators.Count;
			using (List<CoroutineSequence.InsertedEnumerator>.Enumerator enumerator = this._insertedEnumerators.GetEnumerator())
			{
				Action <>9__0;
				while (enumerator.MoveNext())
				{
					CoroutineSequence.InsertedEnumerator insertedEnumerator = enumerator.Current;
					MonoBehaviour owner = this._owner;
					CoroutineSequence.InsertedEnumerator insertedEnumerator2 = insertedEnumerator;
					Action action;
					if ((action = <>9__0) == null)
					{
						action = (<>9__0 = delegate
						{
							int counter2 = counter;
							counter = counter2 - 1;
						});
					}
					Coroutine coroutine = owner.StartCoroutine(insertedEnumerator2.GetEnumerator(action));
					this._coroutines.Add(coroutine);
				}
				goto IL_00EC;
			}
			IL_00D0:
			yield return null;
			IL_00EC:
			if (counter <= 0)
			{
				foreach (IEnumerator enumerator3 in this._appendedEnumerators)
				{
					yield return enumerator3;
				}
				List<IEnumerator>.Enumerator enumerator2 = default(List<IEnumerator>.Enumerator);
				if (this._onCompleted != null)
				{
					this._onCompleted();
				}
				yield break;
			}
			goto IL_00D0;
			yield break;
		}

		// Token: 0x04000A26 RID: 2598
		private List<CoroutineSequence.InsertedEnumerator> _insertedEnumerators;

		// Token: 0x04000A27 RID: 2599
		private List<IEnumerator> _appendedEnumerators;

		// Token: 0x04000A28 RID: 2600
		private Action _onCompleted;

		// Token: 0x04000A29 RID: 2601
		private MonoBehaviour _owner;

		// Token: 0x04000A2A RID: 2602
		private List<Coroutine> _coroutines;

		// Token: 0x04000A2B RID: 2603
		private List<CoroutineSequence> _sequences;

		// Token: 0x02000221 RID: 545
		private class InsertedEnumerator
		{
			// Token: 0x1700022F RID: 559
			// (get) Token: 0x06001D36 RID: 7478 RVA: 0x00146E91 File Offset: 0x00145091
			// (set) Token: 0x06001D37 RID: 7479 RVA: 0x00146E99 File Offset: 0x00145099
			public IEnumerator InternalEnumerator { get; private set; }

			// Token: 0x06001D38 RID: 7480 RVA: 0x00146EA2 File Offset: 0x001450A2
			public InsertedEnumerator(float atPosition, IEnumerator enumerator)
			{
				this._atPosition = atPosition;
				this.InternalEnumerator = enumerator;
			}

			// Token: 0x06001D39 RID: 7481 RVA: 0x00146EB8 File Offset: 0x001450B8
			public IEnumerator GetEnumerator(Action callback)
			{
				if (this._atPosition > 0f)
				{
					yield return new WaitForSeconds(this._atPosition);
				}
				yield return this.InternalEnumerator;
				if (callback != null)
				{
					callback();
				}
				yield break;
			}

			// Token: 0x0400147E RID: 5246
			private float _atPosition;
		}
	}
}
