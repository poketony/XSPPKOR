using System;
using System.Text;
using Steezy.Utility;
using UnityEngine;
using USEncoder;

// Token: 0x02000050 RID: 80
public class SocotraRuntime : SingletonBehaviour<SocotraRuntime>
{
	// Token: 0x06000DB7 RID: 3511 RVA: 0x0010D1E4 File Offset: 0x0010B3E4
	private void Start()
	{
	}

	// Token: 0x06000DB8 RID: 3512 RVA: 0x0010D1E6 File Offset: 0x0010B3E6
	private void Update()
	{
	}

	// Token: 0x06000DB9 RID: 3513 RVA: 0x0010D1E8 File Offset: 0x0010B3E8
	public long CurrentTimeMillis()
	{
		return (long)DateTime.UtcNow.Subtract(SocotraRuntime.UnixEpoch).TotalMilliseconds;
	}

	// Token: 0x06000DBA RID: 3514 RVA: 0x0010D210 File Offset: 0x0010B410
	public static string GetProperty(string property)
	{
		if (property == "microedition.platform")
		{
			return "F903";
		}
		return "";
	}

	// Token: 0x06000DBB RID: 3515 RVA: 0x0010D22A File Offset: 0x0010B42A
	public string GetSourceURL()
	{
		return "dummy://dummy.com";
	}

	// Token: 0x06000DBC RID: 3516 RVA: 0x0010D231 File Offset: 0x0010B431
	public string[] GetArgs()
	{
		return this.Args;
	}

	// Token: 0x06000DBD RID: 3517 RVA: 0x0010D239 File Offset: 0x0010B439
	public static string GetStringForBytes(sbyte[] chars)
	{
		return SocotraRuntime.GetStringForBytesFromSjis(chars, 0, chars.Length);
	}

	// Token: 0x06000DBE RID: 3518 RVA: 0x0010D245 File Offset: 0x0010B445
	public static string GetStringForBytes(sbyte[] chars, string encoding)
	{
		return SocotraRuntime.GetStringForBytes(chars, 0, chars.Length, encoding);
	}

	// Token: 0x06000DBF RID: 3519 RVA: 0x0010D252 File Offset: 0x0010B452
	public static string GetStringForBytes(sbyte[] chars, int start, int len)
	{
		return SocotraRuntime.GetStringForBytesFromSjis(chars, start, len);
	}

	// Token: 0x06000DC0 RID: 3520 RVA: 0x0010D25C File Offset: 0x0010B45C
	public static string GetStringForBytes(sbyte[] chars, int start, int len, string encoding)
	{
		if (encoding == "SJIS" || encoding == "JISAutoDetect")
		{
			return SocotraRuntime.GetStringForBytesFromSjis(chars, start, len);
		}
		byte[] array = SocotraRuntime.SByteArrayToByteArray(chars);
		return SocotraRuntime.GetEncoding(encoding).GetString(array, start, len);
	}

	// Token: 0x06000DC1 RID: 3521 RVA: 0x0010D2A4 File Offset: 0x0010B4A4
	public static string GetStringForBytes(sbyte[] chars, int start, int len, Encoding encoding)
	{
		if (encoding.WebName == "shift_jis")
		{
			return SocotraRuntime.GetStringForBytesFromSjis(chars, start, len);
		}
		byte[] array = SocotraRuntime.SByteArrayToByteArray(chars);
		return encoding.GetString(array, start, len);
	}

	// Token: 0x06000DC2 RID: 3522 RVA: 0x0010D2DC File Offset: 0x0010B4DC
	public static string GetStringForBytesFromUtf8(sbyte[] chars)
	{
		return SocotraRuntime.GetStringForBytesFromUtf8(chars, 0, chars.Length);
	}

	// Token: 0x06000DC3 RID: 3523 RVA: 0x0010D2E8 File Offset: 0x0010B4E8
	public static string GetStringForBytesFromUtf8(sbyte[] chars, int start, int len)
	{
		byte[] array = SocotraRuntime.SByteArrayToByteArray(chars);
		return Encoding.UTF8.GetString(array, start, len);
	}

	// Token: 0x06000DC4 RID: 3524 RVA: 0x0010D309 File Offset: 0x0010B509
	public static string GetStringForBytesFromSjis(sbyte[] chars)
	{
		return SocotraRuntime.GetStringForBytesFromSjis(chars, 0, chars.Length);
	}

	// Token: 0x06000DC5 RID: 3525 RVA: 0x0010D318 File Offset: 0x0010B518
	public static string GetStringForBytesFromSjis(sbyte[] chars, int start, int len)
	{
		byte[] array = new byte[len];
		for (int i = 0; i < len; i++)
		{
			array[i] = (byte)chars[i + start];
		}
		return ToEncoding.ToUnicode(array);
	}

	// Token: 0x06000DC6 RID: 3526 RVA: 0x0010D348 File Offset: 0x0010B548
	private static byte[] SByteArrayToByteArray(sbyte[] array)
	{
		byte[] array2 = new byte[array.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = (byte)array[i];
		}
		return array2;
	}

	// Token: 0x06000DC7 RID: 3527 RVA: 0x0010D374 File Offset: 0x0010B574
	internal static Encoding GetEncoding(string name)
	{
		Encoding encoding = Encoding.GetEncoding(name.Replace('_', '-'));
		if (encoding is UTF8Encoding)
		{
			return new UTF8Encoding(false, true);
		}
		return encoding;
	}

	// Token: 0x06000DC8 RID: 3528 RVA: 0x0010D3A2 File Offset: 0x0010B5A2
	public static void GetCharsForString(string str, int start, int end, char[] destination, int destinationStart)
	{
		str.CopyTo(start, destination, 0, end - start);
	}

	// Token: 0x06000DC9 RID: 3529 RVA: 0x0010D3B0 File Offset: 0x0010B5B0
	public static sbyte[] GetBytesForString(string str)
	{
		return SocotraRuntime.GetBytesForStringFromSjis(str);
	}

	// Token: 0x06000DCA RID: 3530 RVA: 0x0010D3B8 File Offset: 0x0010B5B8
	public static sbyte[] GetBytesForStringUtf8(string str)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(str);
		sbyte[] array = new sbyte[bytes.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (sbyte)bytes[i];
		}
		return array;
	}

	// Token: 0x06000DCB RID: 3531 RVA: 0x0010D3F0 File Offset: 0x0010B5F0
	public static sbyte[] GetBytesForStringFromSjis(string str)
	{
		byte[] array = ToEncoding.ToSJIS(str);
		sbyte[] array2 = new sbyte[array.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = (sbyte)array[i];
		}
		return array2;
	}

	// Token: 0x06000DCC RID: 3532 RVA: 0x0010D423 File Offset: 0x0010B623
	public static int CompareOrdinal(string s1, string s2)
	{
		return string.CompareOrdinal(s1, s2);
	}

	// Token: 0x06000DCD RID: 3533 RVA: 0x0010D42C File Offset: 0x0010B62C
	public static void PrintStackTrace(Exception e)
	{
		Debug.LogException(e);
	}

	// Token: 0x0400081F RID: 2079
	[SerializeField]
	private string[] Args;

	// Token: 0x04000820 RID: 2080
	public static DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
}
