using System;
using Steezy.Utility;
using UnityEngine;

namespace Socotra.IO
{
	// Token: 0x02000120 RID: 288
	public class Connector
	{
		// Token: 0x060015EB RID: 5611 RVA: 0x0012C82C File Offset: 0x0012AA2C
		public static HttpConnection Open(string name)
		{
			return null;
		}

		// Token: 0x060015EC RID: 5612 RVA: 0x0012C82F File Offset: 0x0012AA2F
		public static HttpConnection Open(string name, int mode)
		{
			return null;
		}

		// Token: 0x060015ED RID: 5613 RVA: 0x0012C832 File Offset: 0x0012AA32
		public static HttpConnection Open(string name, int mode, bool timeouts)
		{
			return null;
		}

		// Token: 0x060015EE RID: 5614 RVA: 0x0012C838 File Offset: 0x0012AA38
		public static DataOutputStream OpenDataOutputStream(string url)
		{
			LogUtils.LogTrace("<color='orange'>OpenDataOutputStream : </color>" + url);
			ScratchPadData scratchPadData = SingletonBehaviour<ScratchPadManager>.Instance.GetScratchPadData(url);
			if (scratchPadData != null)
			{
				return scratchPadData.GetDataOutputStream();
			}
			return null;
		}

		// Token: 0x060015EF RID: 5615 RVA: 0x0012C874 File Offset: 0x0012AA74
		public static DataInputStream OpenDataInputStream(string url)
		{
			LogUtils.LogTrace("<color='orange'>OpenDataInputStream : </color>" + url);
			if (url.StartsWith("scratchpad:///"))
			{
				ScratchPadData scratchPadData = SingletonBehaviour<ScratchPadManager>.Instance.GetScratchPadData(url);
				if (scratchPadData != null)
				{
					return scratchPadData.GetDataInputStream();
				}
			}
			else if (url.StartsWith("resource:///"))
			{
				Resources resources = SingletonBehaviour<ResourcesManager>.Instance.GetResources(url.Substring(12));
				if (resources != null)
				{
					return new DataInputStream(new ByteArrayInputStream(((TextAsset)resources.GetResource(0)).bytes));
				}
			}
			return null;
		}

		// Token: 0x060015F0 RID: 5616 RVA: 0x0012C900 File Offset: 0x0012AB00
		public static OutputStream OpenOutputStream(string url)
		{
			LogUtils.LogTrace("<color='orange'>OpenOutputStream : </color>" + url);
			return SingletonBehaviour<ScratchPadManager>.Instance.GetScratchPadData(url).GetOutputStream();
		}

		// Token: 0x060015F1 RID: 5617 RVA: 0x0012C924 File Offset: 0x0012AB24
		public static InputStream OpenInputStream(string url)
		{
			LogUtils.LogTrace("<color='orange'>OpenInputStream : </color>" + url);
			if (url.StartsWith("scratchpad:///"))
			{
				ScratchPadData scratchPadData = SingletonBehaviour<ScratchPadManager>.Instance.GetScratchPadData(url);
				if (scratchPadData != null)
				{
					return scratchPadData.GetDataInputStream();
				}
			}
			else if (url.StartsWith("resource:///"))
			{
				Resources resources = SingletonBehaviour<ResourcesManager>.Instance.GetResources(url.Substring(12));
				if (resources != null)
				{
					return new DataInputStream(new ByteArrayInputStream(((TextAsset)resources.GetResource(0)).bytes));
				}
			}
			return null;
		}

		// Token: 0x04000C96 RID: 3222
		public static int READ = 1;

		// Token: 0x04000C97 RID: 3223
		public static int READ_WRITE = 4;

		// Token: 0x04000C98 RID: 3224
		public static int WRITE = 2;
	}
}
