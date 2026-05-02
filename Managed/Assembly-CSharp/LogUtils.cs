using System;
using UnityEngine;

// Token: 0x02000055 RID: 85
public static class LogUtils
{
	// Token: 0x06000DE1 RID: 3553 RVA: 0x0010D724 File Offset: 0x0010B924
	public static void LogTrace(object message)
	{
		Debug.Log(message);
	}

	// Token: 0x06000DE2 RID: 3554 RVA: 0x0010D72C File Offset: 0x0010B92C
	public static void LogFatal(object message)
	{
		Debug.LogError(message);
	}

	// Token: 0x06000DE3 RID: 3555 RVA: 0x0010D734 File Offset: 0x0010B934
	public static void LogFatal(Exception exception, Object context = null)
	{
		Debug.LogException(exception, context);
	}
}
