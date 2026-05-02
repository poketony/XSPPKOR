using System;
using Socotra.IO;
using Steezy.Utility;
using UnityEngine;

namespace Socotra
{
	// Token: 0x020000E6 RID: 230
	public class ScratchPadSaveData : ScratchPadData
	{
		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060012E7 RID: 4839 RVA: 0x0011F47C File Offset: 0x0011D67C
		public override int Length
		{
			get
			{
				return this.data.Length;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060012E8 RID: 4840 RVA: 0x0011F486 File Offset: 0x0011D686
		// (set) Token: 0x060012E9 RID: 4841 RVA: 0x0011F48E File Offset: 0x0011D68E
		public byte[] Data
		{
			get
			{
				return this.data;
			}
			set
			{
				this.data = new byte[value.Length];
				value.CopyTo(this.data, 0);
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060012EA RID: 4842 RVA: 0x0011F4AB File Offset: 0x0011D6AB
		public string FilePath
		{
			get
			{
				return this.filePath;
			}
		}

		// Token: 0x060012EB RID: 4843 RVA: 0x0011F4B3 File Offset: 0x0011D6B3
		public override DataInputStream GetDataInputStream()
		{
			return new DataInputStream(this.GetInputStream());
		}

		// Token: 0x060012EC RID: 4844 RVA: 0x0011F4C0 File Offset: 0x0011D6C0
		public override DataOutputStream GetDataOutputStream()
		{
			return new DataOutputStream(this.GetOutputStream());
		}

		// Token: 0x060012ED RID: 4845 RVA: 0x0011F4CD File Offset: 0x0011D6CD
		public override InputStream GetInputStream()
		{
			SaveInputStream saveInputStream = new SaveInputStream(this.fileName, this.saveDataSize);
			saveInputStream.Skip((long)this.offset);
			return saveInputStream;
		}

		// Token: 0x060012EE RID: 4846 RVA: 0x0011F4EE File Offset: 0x0011D6EE
		public override OutputStream GetOutputStream()
		{
			SaveOutputStream saveOutputStream = new SaveOutputStream(this.fileName, this.saveDataSize);
			saveOutputStream.Skip((long)this.offset);
			return saveOutputStream;
		}

		// Token: 0x060012EF RID: 4847 RVA: 0x0011F510 File Offset: 0x0011D710
		private void Awake()
		{
			this.data = new byte[this.saveDataSize];
			this.filePath = string.Format("{0}:/{1}", SingletonBehaviour<SaveDataManager>.Instance.MountName, this.fileName);
			this.mReserveTime = -1f;
			this.delaySaveTime = 0;
		}

		// Token: 0x060012F0 RID: 4848 RVA: 0x0011F560 File Offset: 0x0011D760
		private void Start()
		{
		}

		// Token: 0x060012F1 RID: 4849 RVA: 0x0011F562 File Offset: 0x0011D762
		private void Update()
		{
		}

		// Token: 0x060012F2 RID: 4850 RVA: 0x0011F564 File Offset: 0x0011D764
		private void FixedUpdate()
		{
			if (this.mReserveTime > 0f)
			{
				this.mReserveTime -= Time.fixedDeltaTime;
				if (this.mReserveTime <= 0f)
				{
					this.SaveNow();
				}
			}
		}

		// Token: 0x060012F3 RID: 4851 RVA: 0x0011F598 File Offset: 0x0011D798
		public void ReserveSaveData()
		{
			if (this.delaySaveTime <= 0)
			{
				this.SaveData();
				return;
			}
			if (!this.IsSaveReserve())
			{
				this.mReserveTime = (float)this.delaySaveTime;
				Debug.Log("ReserveSave:" + this.mReserveTime.ToString());
			}
		}

		// Token: 0x060012F4 RID: 4852 RVA: 0x0011F5E4 File Offset: 0x0011D7E4
		public void SaveDirectIfNeed()
		{
			if (this.IsSaveReserve())
			{
				this.SaveNow();
			}
		}

		// Token: 0x060012F5 RID: 4853 RVA: 0x0011F5F4 File Offset: 0x0011D7F4
		private void SaveNow()
		{
			Debug.Log("SaveData:" + this.filePath);
			this.mReserveTime = -1f;
		}

		// Token: 0x060012F6 RID: 4854 RVA: 0x0011F616 File Offset: 0x0011D816
		public void SaveData()
		{
			Debug.Log("SaveData:" + this.filePath);
		}

		// Token: 0x060012F7 RID: 4855 RVA: 0x0011F62D File Offset: 0x0011D82D
		public void LoadData()
		{
			if (this.IsSaveReserve())
			{
				return;
			}
			Debug.Log("LoadData:" + this.filePath);
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x0011F64D File Offset: 0x0011D84D
		public bool IsSaveReserve()
		{
			return this.mReserveTime > 0f;
		}

		// Token: 0x04000A83 RID: 2691
		[SerializeField]
		private string fileName;

		// Token: 0x04000A84 RID: 2692
		[SerializeField]
		private int saveDataSize;

		// Token: 0x04000A85 RID: 2693
		[SerializeField]
		private int delaySaveTime;

		// Token: 0x04000A86 RID: 2694
		private string filePath;

		// Token: 0x04000A87 RID: 2695
		private float mReserveTime = -1f;

		// Token: 0x04000A88 RID: 2696
		private bool isLoaded;

		// Token: 0x04000A89 RID: 2697
		private byte[] data;
	}
}
