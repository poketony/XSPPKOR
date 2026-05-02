using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x02000099 RID: 153
	public class PlayerPrefsX
	{
		// Token: 0x06000FB1 RID: 4017 RVA: 0x00115B34 File Offset: 0x00113D34
		public static void SetEncriptString(string key, string value, string password)
		{
			string text = StringEncrypter.Md5EncryptString(string.Concat(new string[] { key, "_", password, "_", value }));
			PlayerPrefs.SetString(key, value);
			PlayerPrefs.SetString(key + "_save_key", text);
		}

		// Token: 0x06000FB2 RID: 4018 RVA: 0x00115B88 File Offset: 0x00113D88
		public static string GetEncriptString(string key, string password, string defaultValue = "")
		{
			string @string = PlayerPrefs.GetString(key);
			if (!PlayerPrefsX.CheckEncryption(key, @string, password))
			{
				return defaultValue;
			}
			return @string;
		}

		// Token: 0x06000FB3 RID: 4019 RVA: 0x00115BA9 File Offset: 0x00113DA9
		public static void SetEncriptFloat(string key, float value, string password)
		{
			PlayerPrefsX.SetEncriptString(key, value.ToString(), password);
		}

		// Token: 0x06000FB4 RID: 4020 RVA: 0x00115BBC File Offset: 0x00113DBC
		public static float GetEncriptFloat(string key, string password, float defaultValue = 0f)
		{
			float num = defaultValue;
			float.TryParse(PlayerPrefsX.GetEncriptString(key, password, defaultValue.ToString()), out num);
			return num;
		}

		// Token: 0x06000FB5 RID: 4021 RVA: 0x00115BE2 File Offset: 0x00113DE2
		public static void SetEncriptInt(string key, int value, string password)
		{
			PlayerPrefsX.SetEncriptString(key, value.ToString(), password);
		}

		// Token: 0x06000FB6 RID: 4022 RVA: 0x00115BF4 File Offset: 0x00113DF4
		public static int GetEncriptInt(string key, string password, int defaultValue = 0)
		{
			int num = defaultValue;
			int.TryParse(PlayerPrefsX.GetEncriptString(key, password, defaultValue.ToString()), out num);
			return num;
		}

		// Token: 0x06000FB7 RID: 4023 RVA: 0x00115C1A File Offset: 0x00113E1A
		public static void SetEncriptLong(string key, long value, string password)
		{
			PlayerPrefsX.SetEncriptString(key, value.ToString(), password);
		}

		// Token: 0x06000FB8 RID: 4024 RVA: 0x00115C2C File Offset: 0x00113E2C
		public static long GetEncriptLong(string key, string password, long defaultValue = 0L)
		{
			long num = defaultValue;
			long.TryParse(PlayerPrefsX.GetEncriptString(key, password, defaultValue.ToString()), out num);
			return num;
		}

		// Token: 0x06000FB9 RID: 4025 RVA: 0x00115C52 File Offset: 0x00113E52
		public static void SetEncriptDictionary<TKey, TValue>(string key, Dictionary<TKey, TValue> value, string password)
		{
			PlayerPrefsX.SetEncriptString(key, PlayerPrefsX.Serialize<Dictionary<TKey, TValue>>(value), password);
		}

		// Token: 0x06000FBA RID: 4026 RVA: 0x00115C64 File Offset: 0x00113E64
		public static Dictionary<TKey, TValue> GetEncriptDictionary<TKey, TValue>(string key, string password)
		{
			Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
			string encriptString = PlayerPrefsX.GetEncriptString(key, password, "");
			if (!string.IsNullOrEmpty(encriptString))
			{
				dictionary = PlayerPrefsX.Deserialize<Dictionary<TKey, TValue>>(encriptString);
			}
			return dictionary;
		}

		// Token: 0x06000FBB RID: 4027 RVA: 0x00115C94 File Offset: 0x00113E94
		public static void SetEncriptList<TValue>(string key, List<TValue> value, string password)
		{
			PlayerPrefsX.SetEncriptString(key, PlayerPrefsX.Serialize<List<TValue>>(value), password);
		}

		// Token: 0x06000FBC RID: 4028 RVA: 0x00115CA4 File Offset: 0x00113EA4
		public static List<TValue> GetEncriptList<TValue>(string key, string password)
		{
			List<TValue> list = new List<TValue>();
			string encriptString = PlayerPrefsX.GetEncriptString(key, password, "");
			if (!string.IsNullOrEmpty(encriptString))
			{
				list = PlayerPrefsX.Deserialize<List<TValue>>(encriptString);
			}
			return list;
		}

		// Token: 0x06000FBD RID: 4029 RVA: 0x00115CD4 File Offset: 0x00113ED4
		public static void SetEncriptObject<TValue>(string key, TValue value, string password)
		{
			PlayerPrefsX.SetEncriptString(key, PlayerPrefsX.Serialize<TValue>(value), password);
		}

		// Token: 0x06000FBE RID: 4030 RVA: 0x00115CE4 File Offset: 0x00113EE4
		public static TValue GetEncriptObject<TValue>(string key, string password) where TValue : class
		{
			TValue tvalue = default(TValue);
			string encriptString = PlayerPrefsX.GetEncriptString(key, password, "");
			if (!string.IsNullOrEmpty(encriptString))
			{
				tvalue = PlayerPrefsX.Deserialize<TValue>(encriptString);
			}
			return tvalue;
		}

		// Token: 0x06000FBF RID: 4031 RVA: 0x00115D18 File Offset: 0x00113F18
		public static bool CheckEncryption(string key, string value, string password)
		{
			string text = StringEncrypter.Md5EncryptString(string.Concat(new string[] { key, "_", password, "_", value }));
			return PlayerPrefs.HasKey(key + "_save_key") && PlayerPrefs.GetString(key + "_save_key") == text;
		}

		// Token: 0x06000FC0 RID: 4032 RVA: 0x00115D7C File Offset: 0x00113F7C
		public static bool HasKey(string key)
		{
			return PlayerPrefs.HasKey(key);
		}

		// Token: 0x06000FC1 RID: 4033 RVA: 0x00115D84 File Offset: 0x00113F84
		public static void DeleteKey(string key)
		{
			PlayerPrefs.DeleteKey(key);
			if (PlayerPrefsX.HasKey(key + "_save_key"))
			{
				PlayerPrefs.DeleteKey(key + "_save_key");
			}
		}

		// Token: 0x06000FC2 RID: 4034 RVA: 0x00115DB0 File Offset: 0x00113FB0
		public static bool SetBool(string name, bool value)
		{
			try
			{
				PlayerPrefs.SetInt(name, value ? 1 : 0);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000FC3 RID: 4035 RVA: 0x00115DE4 File Offset: 0x00113FE4
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}

		// Token: 0x06000FC4 RID: 4036 RVA: 0x00115DEF File Offset: 0x00113FEF
		public static bool GetBool(string name, bool defaultValue)
		{
			return 1 == PlayerPrefs.GetInt(name, defaultValue ? 1 : 0);
		}

		// Token: 0x06000FC5 RID: 4037 RVA: 0x00115E04 File Offset: 0x00114004
		public static long GetLong(string key, long defaultValue)
		{
			int @int;
			int int2;
			PlayerPrefsX.SplitLong(defaultValue, out @int, out int2);
			@int = PlayerPrefs.GetInt(key + "_lowBits", @int);
			int2 = PlayerPrefs.GetInt(key + "_highBits", int2);
			return (long)(((ulong)int2 << 32) | (ulong)@int);
		}

		// Token: 0x06000FC6 RID: 4038 RVA: 0x00115E48 File Offset: 0x00114048
		public static long GetLong(string key)
		{
			int @int = PlayerPrefs.GetInt(key + "_lowBits");
			return (long)(((ulong)PlayerPrefs.GetInt(key + "_highBits") << 32) | (ulong)@int);
		}

		// Token: 0x06000FC7 RID: 4039 RVA: 0x00115E7D File Offset: 0x0011407D
		private static void SplitLong(long input, out int lowBits, out int highBits)
		{
			lowBits = (int)((uint)input);
			highBits = (int)((uint)(input >> 32));
		}

		// Token: 0x06000FC8 RID: 4040 RVA: 0x00115E8C File Offset: 0x0011408C
		public static void SetLong(string key, long value)
		{
			int num;
			int num2;
			PlayerPrefsX.SplitLong(value, out num, out num2);
			PlayerPrefs.SetInt(key + "_lowBits", num);
			PlayerPrefs.SetInt(key + "_highBits", num2);
		}

		// Token: 0x06000FC9 RID: 4041 RVA: 0x00115EC5 File Offset: 0x001140C5
		public static bool SetVector2(string key, Vector2 vector)
		{
			return PlayerPrefsX.SetFloatArray(key, new float[] { vector.x, vector.y });
		}

		// Token: 0x06000FCA RID: 4042 RVA: 0x00115EE8 File Offset: 0x001140E8
		private static Vector2 GetVector2(string key)
		{
			float[] floatArray = PlayerPrefsX.GetFloatArray(key);
			if (floatArray.Length < 2)
			{
				return Vector2.zero;
			}
			return new Vector2(floatArray[0], floatArray[1]);
		}

		// Token: 0x06000FCB RID: 4043 RVA: 0x00115F13 File Offset: 0x00114113
		public static Vector2 GetVector2(string key, Vector2 defaultValue)
		{
			if (PlayerPrefs.HasKey(key))
			{
				return PlayerPrefsX.GetVector2(key);
			}
			return defaultValue;
		}

		// Token: 0x06000FCC RID: 4044 RVA: 0x00115F25 File Offset: 0x00114125
		public static bool SetVector3(string key, Vector3 vector)
		{
			return PlayerPrefsX.SetFloatArray(key, new float[] { vector.x, vector.y, vector.z });
		}

		// Token: 0x06000FCD RID: 4045 RVA: 0x00115F50 File Offset: 0x00114150
		public static Vector3 GetVector3(string key)
		{
			float[] floatArray = PlayerPrefsX.GetFloatArray(key);
			if (floatArray.Length < 3)
			{
				return Vector3.zero;
			}
			return new Vector3(floatArray[0], floatArray[1], floatArray[2]);
		}

		// Token: 0x06000FCE RID: 4046 RVA: 0x00115F7E File Offset: 0x0011417E
		public static Vector3 GetVector3(string key, Vector3 defaultValue)
		{
			if (PlayerPrefs.HasKey(key))
			{
				return PlayerPrefsX.GetVector3(key);
			}
			return defaultValue;
		}

		// Token: 0x06000FCF RID: 4047 RVA: 0x00115F90 File Offset: 0x00114190
		public static bool SetQuaternion(string key, Quaternion vector)
		{
			return PlayerPrefsX.SetFloatArray(key, new float[] { vector.x, vector.y, vector.z, vector.w });
		}

		// Token: 0x06000FD0 RID: 4048 RVA: 0x00115FC4 File Offset: 0x001141C4
		public static Quaternion GetQuaternion(string key)
		{
			float[] floatArray = PlayerPrefsX.GetFloatArray(key);
			if (floatArray.Length < 4)
			{
				return Quaternion.identity;
			}
			return new Quaternion(floatArray[0], floatArray[1], floatArray[2], floatArray[3]);
		}

		// Token: 0x06000FD1 RID: 4049 RVA: 0x00115FF5 File Offset: 0x001141F5
		public static Quaternion GetQuaternion(string key, Quaternion defaultValue)
		{
			if (PlayerPrefs.HasKey(key))
			{
				return PlayerPrefsX.GetQuaternion(key);
			}
			return defaultValue;
		}

		// Token: 0x06000FD2 RID: 4050 RVA: 0x00116007 File Offset: 0x00114207
		public static bool SetColor(string key, Color color)
		{
			return PlayerPrefsX.SetFloatArray(key, new float[] { color.r, color.g, color.b, color.a });
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x0011603C File Offset: 0x0011423C
		public static Color GetColor(string key)
		{
			float[] floatArray = PlayerPrefsX.GetFloatArray(key);
			if (floatArray.Length < 4)
			{
				return new Color(0f, 0f, 0f, 0f);
			}
			return new Color(floatArray[0], floatArray[1], floatArray[2], floatArray[3]);
		}

		// Token: 0x06000FD4 RID: 4052 RVA: 0x00116081 File Offset: 0x00114281
		public static Color GetColor(string key, Color defaultValue)
		{
			if (PlayerPrefs.HasKey(key))
			{
				return PlayerPrefsX.GetColor(key);
			}
			return defaultValue;
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x00116094 File Offset: 0x00114294
		public static bool SetBoolArray(string key, bool[] boolArray)
		{
			byte[] array = new byte[(boolArray.Length + 7) / 8 + 5];
			array[0] = Convert.ToByte(PlayerPrefsX.ArrayType.Bool);
			new BitArray(boolArray).CopyTo(array, 5);
			PlayerPrefsX.Initialize();
			PlayerPrefsX.ConvertInt32ToBytes(boolArray.Length, array);
			return PlayerPrefsX.SaveBytes(key, array);
		}

		// Token: 0x06000FD6 RID: 4054 RVA: 0x001160E0 File Offset: 0x001142E0
		public static bool[] GetBoolArray(string key)
		{
			if (!PlayerPrefs.HasKey(key))
			{
				return new bool[0];
			}
			byte[] array = Convert.FromBase64String(PlayerPrefs.GetString(key));
			if (array.Length < 5)
			{
				Debug.LogError("Corrupt preference file for " + key);
				return new bool[0];
			}
			if (array[0] != 2)
			{
				Debug.LogError(key + " is not a boolean array");
				return new bool[0];
			}
			PlayerPrefsX.Initialize();
			byte[] array2 = new byte[array.Length - 5];
			Array.Copy(array, 5, array2, 0, array2.Length);
			BitArray bitArray = new BitArray(array2);
			bitArray.Length = PlayerPrefsX.ConvertBytesToInt32(array);
			bool[] array3 = new bool[bitArray.Count];
			bitArray.CopyTo(array3, 0);
			return array3;
		}

		// Token: 0x06000FD7 RID: 4055 RVA: 0x00116188 File Offset: 0x00114388
		public static bool[] GetBoolArray(string key, bool defaultValue, int defaultSize)
		{
			if (PlayerPrefs.HasKey(key))
			{
				return PlayerPrefsX.GetBoolArray(key);
			}
			bool[] array = new bool[defaultSize];
			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}
			return array;
		}

		// Token: 0x06000FD8 RID: 4056 RVA: 0x001161BC File Offset: 0x001143BC
		public static bool SetStringArray(string key, string[] stringArray)
		{
			byte[] array = new byte[stringArray.Length + 1];
			array[0] = Convert.ToByte(PlayerPrefsX.ArrayType.String);
			PlayerPrefsX.Initialize();
			for (int i = 0; i < stringArray.Length; i++)
			{
				if (stringArray[i] == null)
				{
					Debug.LogError("Can't save null entries in the string array when setting " + key);
					return false;
				}
				if (stringArray[i].Length > 255)
				{
					Debug.LogError("Strings cannot be longer than 255 characters when setting " + key);
					return false;
				}
				array[PlayerPrefsX.idx++] = (byte)stringArray[i].Length;
			}
			try
			{
				PlayerPrefs.SetString(key, Convert.ToBase64String(array) + "|" + string.Join("", stringArray));
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000FD9 RID: 4057 RVA: 0x00116284 File Offset: 0x00114484
		public static string[] GetStringArray(string key)
		{
			if (!PlayerPrefs.HasKey(key))
			{
				return new string[0];
			}
			string @string = PlayerPrefs.GetString(key);
			int num = @string.IndexOf("|"[0]);
			if (num < 4)
			{
				Debug.LogError("Corrupt preference file for " + key);
				return new string[0];
			}
			byte[] array = Convert.FromBase64String(@string.Substring(0, num));
			if (array[0] != 3)
			{
				Debug.LogError(key + " is not a string array");
				return new string[0];
			}
			PlayerPrefsX.Initialize();
			int num2 = array.Length - 1;
			string[] array2 = new string[num2];
			int num3 = num + 1;
			for (int i = 0; i < num2; i++)
			{
				int num4 = (int)array[PlayerPrefsX.idx++];
				if (num3 + num4 > @string.Length)
				{
					Debug.LogError("Corrupt preference file for " + key);
					return new string[0];
				}
				array2[i] = @string.Substring(num3, num4);
				num3 += num4;
			}
			return array2;
		}

		// Token: 0x06000FDA RID: 4058 RVA: 0x00116378 File Offset: 0x00114578
		public static string[] GetStringArray(string key, string defaultValue, int defaultSize)
		{
			if (PlayerPrefs.HasKey(key))
			{
				return PlayerPrefsX.GetStringArray(key);
			}
			string[] array = new string[defaultSize];
			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}
			return array;
		}

		// Token: 0x06000FDB RID: 4059 RVA: 0x001163AC File Offset: 0x001145AC
		public static bool SetIntArray(string key, int[] intArray)
		{
			return PlayerPrefsX.SetValue<int[]>(key, intArray, PlayerPrefsX.ArrayType.Int32, 1, new Action<int[], byte[], int>(PlayerPrefsX.ConvertFromInt));
		}

		// Token: 0x06000FDC RID: 4060 RVA: 0x001163C3 File Offset: 0x001145C3
		public static bool SetFloatArray(string key, float[] floatArray)
		{
			return PlayerPrefsX.SetValue<float[]>(key, floatArray, PlayerPrefsX.ArrayType.Float, 1, new Action<float[], byte[], int>(PlayerPrefsX.ConvertFromFloat));
		}

		// Token: 0x06000FDD RID: 4061 RVA: 0x001163DA File Offset: 0x001145DA
		public static bool SetVector2Array(string key, Vector2[] vector2Array)
		{
			return PlayerPrefsX.SetValue<Vector2[]>(key, vector2Array, PlayerPrefsX.ArrayType.Vector2, 2, new Action<Vector2[], byte[], int>(PlayerPrefsX.ConvertFromVector2));
		}

		// Token: 0x06000FDE RID: 4062 RVA: 0x001163F1 File Offset: 0x001145F1
		public static bool SetVector3Array(string key, Vector3[] vector3Array)
		{
			return PlayerPrefsX.SetValue<Vector3[]>(key, vector3Array, PlayerPrefsX.ArrayType.Vector3, 3, new Action<Vector3[], byte[], int>(PlayerPrefsX.ConvertFromVector3));
		}

		// Token: 0x06000FDF RID: 4063 RVA: 0x00116408 File Offset: 0x00114608
		public static bool SetQuaternionArray(string key, Quaternion[] quaternionArray)
		{
			return PlayerPrefsX.SetValue<Quaternion[]>(key, quaternionArray, PlayerPrefsX.ArrayType.Quaternion, 4, new Action<Quaternion[], byte[], int>(PlayerPrefsX.ConvertFromQuaternion));
		}

		// Token: 0x06000FE0 RID: 4064 RVA: 0x0011641F File Offset: 0x0011461F
		public static bool SetColorArray(string key, Color[] colorArray)
		{
			return PlayerPrefsX.SetValue<Color[]>(key, colorArray, PlayerPrefsX.ArrayType.Color, 4, new Action<Color[], byte[], int>(PlayerPrefsX.ConvertFromColor));
		}

		// Token: 0x06000FE1 RID: 4065 RVA: 0x00116438 File Offset: 0x00114638
		private static bool SetValue<T>(string key, T array, PlayerPrefsX.ArrayType arrayType, int vectorNumber, Action<T, byte[], int> convert) where T : IList
		{
			byte[] array2 = new byte[4 * array.Count * vectorNumber + 1];
			array2[0] = Convert.ToByte(arrayType);
			PlayerPrefsX.Initialize();
			for (int i = 0; i < array.Count; i++)
			{
				convert(array, array2, i);
			}
			return PlayerPrefsX.SaveBytes(key, array2);
		}

		// Token: 0x06000FE2 RID: 4066 RVA: 0x0011649A File Offset: 0x0011469A
		private static void ConvertFromInt(int[] array, byte[] bytes, int i)
		{
			PlayerPrefsX.ConvertInt32ToBytes(array[i], bytes);
		}

		// Token: 0x06000FE3 RID: 4067 RVA: 0x001164A5 File Offset: 0x001146A5
		private static void ConvertFromFloat(float[] array, byte[] bytes, int i)
		{
			PlayerPrefsX.ConvertFloatToBytes(array[i], bytes);
		}

		// Token: 0x06000FE4 RID: 4068 RVA: 0x001164B0 File Offset: 0x001146B0
		private static void ConvertFromVector2(Vector2[] array, byte[] bytes, int i)
		{
			PlayerPrefsX.ConvertFloatToBytes(array[i].x, bytes);
			PlayerPrefsX.ConvertFloatToBytes(array[i].y, bytes);
		}

		// Token: 0x06000FE5 RID: 4069 RVA: 0x001164D6 File Offset: 0x001146D6
		private static void ConvertFromVector3(Vector3[] array, byte[] bytes, int i)
		{
			PlayerPrefsX.ConvertFloatToBytes(array[i].x, bytes);
			PlayerPrefsX.ConvertFloatToBytes(array[i].y, bytes);
			PlayerPrefsX.ConvertFloatToBytes(array[i].z, bytes);
		}

		// Token: 0x06000FE6 RID: 4070 RVA: 0x00116510 File Offset: 0x00114710
		private static void ConvertFromQuaternion(Quaternion[] array, byte[] bytes, int i)
		{
			PlayerPrefsX.ConvertFloatToBytes(array[i].x, bytes);
			PlayerPrefsX.ConvertFloatToBytes(array[i].y, bytes);
			PlayerPrefsX.ConvertFloatToBytes(array[i].z, bytes);
			PlayerPrefsX.ConvertFloatToBytes(array[i].w, bytes);
		}

		// Token: 0x06000FE7 RID: 4071 RVA: 0x00116568 File Offset: 0x00114768
		private static void ConvertFromColor(Color[] array, byte[] bytes, int i)
		{
			PlayerPrefsX.ConvertFloatToBytes(array[i].r, bytes);
			PlayerPrefsX.ConvertFloatToBytes(array[i].g, bytes);
			PlayerPrefsX.ConvertFloatToBytes(array[i].b, bytes);
			PlayerPrefsX.ConvertFloatToBytes(array[i].a, bytes);
		}

		// Token: 0x06000FE8 RID: 4072 RVA: 0x001165C0 File Offset: 0x001147C0
		public static int[] GetIntArray(string key)
		{
			List<int> list = new List<int>();
			PlayerPrefsX.GetValue<List<int>>(key, list, PlayerPrefsX.ArrayType.Int32, 1, new Action<List<int>, byte[]>(PlayerPrefsX.ConvertToInt));
			return list.ToArray();
		}

		// Token: 0x06000FE9 RID: 4073 RVA: 0x001165F0 File Offset: 0x001147F0
		public static int[] GetIntArray(string key, int defaultValue, int defaultSize)
		{
			if (PlayerPrefs.HasKey(key))
			{
				return PlayerPrefsX.GetIntArray(key);
			}
			int[] array = new int[defaultSize];
			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}
			return array;
		}

		// Token: 0x06000FEA RID: 4074 RVA: 0x00116624 File Offset: 0x00114824
		public static float[] GetFloatArray(string key)
		{
			List<float> list = new List<float>();
			PlayerPrefsX.GetValue<List<float>>(key, list, PlayerPrefsX.ArrayType.Float, 1, new Action<List<float>, byte[]>(PlayerPrefsX.ConvertToFloat));
			return list.ToArray();
		}

		// Token: 0x06000FEB RID: 4075 RVA: 0x00116654 File Offset: 0x00114854
		public static float[] GetFloatArray(string key, float defaultValue, int defaultSize)
		{
			if (PlayerPrefs.HasKey(key))
			{
				return PlayerPrefsX.GetFloatArray(key);
			}
			float[] array = new float[defaultSize];
			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}
			return array;
		}

		// Token: 0x06000FEC RID: 4076 RVA: 0x00116688 File Offset: 0x00114888
		public static Vector2[] GetVector2Array(string key)
		{
			List<Vector2> list = new List<Vector2>();
			PlayerPrefsX.GetValue<List<Vector2>>(key, list, PlayerPrefsX.ArrayType.Vector2, 2, new Action<List<Vector2>, byte[]>(PlayerPrefsX.ConvertToVector2));
			return list.ToArray();
		}

		// Token: 0x06000FED RID: 4077 RVA: 0x001166B8 File Offset: 0x001148B8
		public static Vector2[] GetVector2Array(string key, Vector2 defaultValue, int defaultSize)
		{
			if (PlayerPrefs.HasKey(key))
			{
				return PlayerPrefsX.GetVector2Array(key);
			}
			Vector2[] array = new Vector2[defaultSize];
			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}
			return array;
		}

		// Token: 0x06000FEE RID: 4078 RVA: 0x001166F0 File Offset: 0x001148F0
		public static Vector3[] GetVector3Array(string key)
		{
			List<Vector3> list = new List<Vector3>();
			PlayerPrefsX.GetValue<List<Vector3>>(key, list, PlayerPrefsX.ArrayType.Vector3, 3, new Action<List<Vector3>, byte[]>(PlayerPrefsX.ConvertToVector3));
			return list.ToArray();
		}

		// Token: 0x06000FEF RID: 4079 RVA: 0x00116720 File Offset: 0x00114920
		public static Vector3[] GetVector3Array(string key, Vector3 defaultValue, int defaultSize)
		{
			if (PlayerPrefs.HasKey(key))
			{
				return PlayerPrefsX.GetVector3Array(key);
			}
			Vector3[] array = new Vector3[defaultSize];
			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}
			return array;
		}

		// Token: 0x06000FF0 RID: 4080 RVA: 0x00116758 File Offset: 0x00114958
		public static Quaternion[] GetQuaternionArray(string key)
		{
			List<Quaternion> list = new List<Quaternion>();
			PlayerPrefsX.GetValue<List<Quaternion>>(key, list, PlayerPrefsX.ArrayType.Quaternion, 4, new Action<List<Quaternion>, byte[]>(PlayerPrefsX.ConvertToQuaternion));
			return list.ToArray();
		}

		// Token: 0x06000FF1 RID: 4081 RVA: 0x00116788 File Offset: 0x00114988
		public static Quaternion[] GetQuaternionArray(string key, Quaternion defaultValue, int defaultSize)
		{
			if (PlayerPrefs.HasKey(key))
			{
				return PlayerPrefsX.GetQuaternionArray(key);
			}
			Quaternion[] array = new Quaternion[defaultSize];
			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}
			return array;
		}

		// Token: 0x06000FF2 RID: 4082 RVA: 0x001167C0 File Offset: 0x001149C0
		public static Color[] GetColorArray(string key)
		{
			List<Color> list = new List<Color>();
			PlayerPrefsX.GetValue<List<Color>>(key, list, PlayerPrefsX.ArrayType.Color, 4, new Action<List<Color>, byte[]>(PlayerPrefsX.ConvertToColor));
			return list.ToArray();
		}

		// Token: 0x06000FF3 RID: 4083 RVA: 0x001167F0 File Offset: 0x001149F0
		public static Color[] GetColorArray(string key, Color defaultValue, int defaultSize)
		{
			if (PlayerPrefs.HasKey(key))
			{
				return PlayerPrefsX.GetColorArray(key);
			}
			Color[] array = new Color[defaultSize];
			for (int i = 0; i < defaultSize; i++)
			{
				array[i] = defaultValue;
			}
			return array;
		}

		// Token: 0x06000FF4 RID: 4084 RVA: 0x00116828 File Offset: 0x00114A28
		private static void GetValue<T>(string key, T list, PlayerPrefsX.ArrayType arrayType, int vectorNumber, Action<T, byte[]> convert) where T : IList
		{
			if (PlayerPrefs.HasKey(key))
			{
				byte[] array = Convert.FromBase64String(PlayerPrefs.GetString(key));
				if ((array.Length - 1) % (vectorNumber * 4) != 0)
				{
					Debug.LogError("Corrupt preference file for " + key);
					return;
				}
				if ((PlayerPrefsX.ArrayType)array[0] != arrayType)
				{
					Debug.LogError(key + " is not a " + arrayType.ToString() + " array");
					return;
				}
				PlayerPrefsX.Initialize();
				int num = (array.Length - 1) / (vectorNumber * 4);
				for (int i = 0; i < num; i++)
				{
					convert(list, array);
				}
			}
		}

		// Token: 0x06000FF5 RID: 4085 RVA: 0x001168B2 File Offset: 0x00114AB2
		private static void ConvertToInt(List<int> list, byte[] bytes)
		{
			list.Add(PlayerPrefsX.ConvertBytesToInt32(bytes));
		}

		// Token: 0x06000FF6 RID: 4086 RVA: 0x001168C0 File Offset: 0x00114AC0
		private static void ConvertToFloat(List<float> list, byte[] bytes)
		{
			list.Add(PlayerPrefsX.ConvertBytesToFloat(bytes));
		}

		// Token: 0x06000FF7 RID: 4087 RVA: 0x001168CE File Offset: 0x00114ACE
		private static void ConvertToVector2(List<Vector2> list, byte[] bytes)
		{
			list.Add(new Vector2(PlayerPrefsX.ConvertBytesToFloat(bytes), PlayerPrefsX.ConvertBytesToFloat(bytes)));
		}

		// Token: 0x06000FF8 RID: 4088 RVA: 0x001168E7 File Offset: 0x00114AE7
		private static void ConvertToVector3(List<Vector3> list, byte[] bytes)
		{
			list.Add(new Vector3(PlayerPrefsX.ConvertBytesToFloat(bytes), PlayerPrefsX.ConvertBytesToFloat(bytes), PlayerPrefsX.ConvertBytesToFloat(bytes)));
		}

		// Token: 0x06000FF9 RID: 4089 RVA: 0x00116906 File Offset: 0x00114B06
		private static void ConvertToQuaternion(List<Quaternion> list, byte[] bytes)
		{
			list.Add(new Quaternion(PlayerPrefsX.ConvertBytesToFloat(bytes), PlayerPrefsX.ConvertBytesToFloat(bytes), PlayerPrefsX.ConvertBytesToFloat(bytes), PlayerPrefsX.ConvertBytesToFloat(bytes)));
		}

		// Token: 0x06000FFA RID: 4090 RVA: 0x0011692B File Offset: 0x00114B2B
		private static void ConvertToColor(List<Color> list, byte[] bytes)
		{
			list.Add(new Color(PlayerPrefsX.ConvertBytesToFloat(bytes), PlayerPrefsX.ConvertBytesToFloat(bytes), PlayerPrefsX.ConvertBytesToFloat(bytes), PlayerPrefsX.ConvertBytesToFloat(bytes)));
		}

		// Token: 0x06000FFB RID: 4091 RVA: 0x00116950 File Offset: 0x00114B50
		public static void ShowArrayType(string key)
		{
			byte[] array = Convert.FromBase64String(PlayerPrefs.GetString(key));
			if (array.Length != 0)
			{
				PlayerPrefsX.ArrayType arrayType = (PlayerPrefsX.ArrayType)array[0];
				Debug.Log(key + " is a " + arrayType.ToString() + " array");
			}
		}

		// Token: 0x06000FFC RID: 4092 RVA: 0x00116993 File Offset: 0x00114B93
		private static void Initialize()
		{
			if (BitConverter.IsLittleEndian)
			{
				PlayerPrefsX.endianDiff1 = 0;
				PlayerPrefsX.endianDiff2 = 0;
			}
			else
			{
				PlayerPrefsX.endianDiff1 = 3;
				PlayerPrefsX.endianDiff2 = 1;
			}
			if (PlayerPrefsX.byteBlock == null)
			{
				PlayerPrefsX.byteBlock = new byte[4];
			}
			PlayerPrefsX.idx = 1;
		}

		// Token: 0x06000FFD RID: 4093 RVA: 0x001169D0 File Offset: 0x00114BD0
		private static bool SaveBytes(string key, byte[] bytes)
		{
			try
			{
				PlayerPrefs.SetString(key, Convert.ToBase64String(bytes));
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000FFE RID: 4094 RVA: 0x00116A04 File Offset: 0x00114C04
		private static void ConvertFloatToBytes(float f, byte[] bytes)
		{
			PlayerPrefsX.byteBlock = BitConverter.GetBytes(f);
			PlayerPrefsX.ConvertTo4Bytes(bytes);
		}

		// Token: 0x06000FFF RID: 4095 RVA: 0x00116A17 File Offset: 0x00114C17
		private static float ConvertBytesToFloat(byte[] bytes)
		{
			PlayerPrefsX.ConvertFrom4Bytes(bytes);
			return BitConverter.ToSingle(PlayerPrefsX.byteBlock, 0);
		}

		// Token: 0x06001000 RID: 4096 RVA: 0x00116A2A File Offset: 0x00114C2A
		private static void ConvertInt32ToBytes(int i, byte[] bytes)
		{
			PlayerPrefsX.byteBlock = BitConverter.GetBytes(i);
			PlayerPrefsX.ConvertTo4Bytes(bytes);
		}

		// Token: 0x06001001 RID: 4097 RVA: 0x00116A3D File Offset: 0x00114C3D
		private static int ConvertBytesToInt32(byte[] bytes)
		{
			PlayerPrefsX.ConvertFrom4Bytes(bytes);
			return BitConverter.ToInt32(PlayerPrefsX.byteBlock, 0);
		}

		// Token: 0x06001002 RID: 4098 RVA: 0x00116A50 File Offset: 0x00114C50
		private static void ConvertTo4Bytes(byte[] bytes)
		{
			bytes[PlayerPrefsX.idx] = PlayerPrefsX.byteBlock[PlayerPrefsX.endianDiff1];
			bytes[PlayerPrefsX.idx + 1] = PlayerPrefsX.byteBlock[1 + PlayerPrefsX.endianDiff2];
			bytes[PlayerPrefsX.idx + 2] = PlayerPrefsX.byteBlock[2 - PlayerPrefsX.endianDiff2];
			bytes[PlayerPrefsX.idx + 3] = PlayerPrefsX.byteBlock[3 - PlayerPrefsX.endianDiff1];
			PlayerPrefsX.idx += 4;
		}

		// Token: 0x06001003 RID: 4099 RVA: 0x00116AC0 File Offset: 0x00114CC0
		private static void ConvertFrom4Bytes(byte[] bytes)
		{
			PlayerPrefsX.byteBlock[PlayerPrefsX.endianDiff1] = bytes[PlayerPrefsX.idx];
			PlayerPrefsX.byteBlock[1 + PlayerPrefsX.endianDiff2] = bytes[PlayerPrefsX.idx + 1];
			PlayerPrefsX.byteBlock[2 - PlayerPrefsX.endianDiff2] = bytes[PlayerPrefsX.idx + 2];
			PlayerPrefsX.byteBlock[3 - PlayerPrefsX.endianDiff1] = bytes[PlayerPrefsX.idx + 3];
			PlayerPrefsX.idx += 4;
		}

		// Token: 0x06001004 RID: 4100 RVA: 0x00116B30 File Offset: 0x00114D30
		private static string Serialize<T>(T obj)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream();
			binaryFormatter.Serialize(memoryStream, obj);
			return Convert.ToBase64String(memoryStream.GetBuffer());
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x00116B60 File Offset: 0x00114D60
		private static T Deserialize<T>(string str)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(str));
			return (T)((object)binaryFormatter.Deserialize(memoryStream));
		}

		// Token: 0x0400097C RID: 2428
		private static int endianDiff1;

		// Token: 0x0400097D RID: 2429
		private static int endianDiff2;

		// Token: 0x0400097E RID: 2430
		private static int idx;

		// Token: 0x0400097F RID: 2431
		private static byte[] byteBlock;

		// Token: 0x04000980 RID: 2432
		private const string ENCRYPT_HASH_KEY_SUFFIX = "_save_key";

		// Token: 0x02000200 RID: 512
		private enum ArrayType
		{
			// Token: 0x040013E8 RID: 5096
			Float,
			// Token: 0x040013E9 RID: 5097
			Int32,
			// Token: 0x040013EA RID: 5098
			Bool,
			// Token: 0x040013EB RID: 5099
			String,
			// Token: 0x040013EC RID: 5100
			Vector2,
			// Token: 0x040013ED RID: 5101
			Vector3,
			// Token: 0x040013EE RID: 5102
			Quaternion,
			// Token: 0x040013EF RID: 5103
			Color
		}
	}
}
