using System;
using System.Diagnostics;
using UnityEngine;

// Token: 0x02000042 RID: 66
public static class Assert
{
	// Token: 0x06000D49 RID: 3401 RVA: 0x0010AE8F File Offset: 0x0010908F
	[Conditional("UNITY_EDITOR")]
	public static void AssertTrue(bool condition, string message)
	{
	}

	// Token: 0x06000D4A RID: 3402 RVA: 0x0010AE91 File Offset: 0x00109091
	[Conditional("UNITY_EDITOR")]
	public static void AssertTrue(bool condition)
	{
	}

	// Token: 0x06000D4B RID: 3403 RVA: 0x0010AE93 File Offset: 0x00109093
	[Conditional("UNITY_EDITOR")]
	public static void AssertNotNull(Object obj, string message)
	{
	}

	// Token: 0x06000D4C RID: 3404 RVA: 0x0010AE95 File Offset: 0x00109095
	[Conditional("UNITY_EDITOR")]
	public static void AssertNotNull(Object obj)
	{
	}

	// Token: 0x06000D4D RID: 3405 RVA: 0x0010AE97 File Offset: 0x00109097
	[Conditional("UNITY_EDITOR")]
	private static void AssertCore(bool condition, string message, int depth)
	{
	}
}
