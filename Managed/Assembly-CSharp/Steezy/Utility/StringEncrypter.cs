using System;
using System.Security.Cryptography;
using System.Text;

namespace Steezy.Utility
{
	// Token: 0x020000B5 RID: 181
	public static class StringEncrypter
	{
		// Token: 0x060010A9 RID: 4265 RVA: 0x001193BC File Offset: 0x001175BC
		public static string AesDecryptString(string sourceString, string password)
		{
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			byte[] array;
			byte[] array2;
			StringEncrypter.AesGenerateKeyFromPassword("cFXRc=Prd*l_F8/W", password, rijndaelManaged.KeySize, out array, rijndaelManaged.BlockSize, out array2);
			rijndaelManaged.Key = array;
			rijndaelManaged.IV = array2;
			byte[] array3 = Convert.FromBase64String(sourceString);
			ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor();
			byte[] array4 = cryptoTransform.TransformFinalBlock(array3, 0, array3.Length);
			cryptoTransform.Dispose();
			return Encoding.UTF8.GetString(array4);
		}

		// Token: 0x060010AA RID: 4266 RVA: 0x00119424 File Offset: 0x00117624
		public static string AesEncryptString(string sourceString, string password)
		{
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			byte[] array;
			byte[] array2;
			StringEncrypter.AesGenerateKeyFromPassword("cFXRc=Prd*l_F8/W", password, rijndaelManaged.KeySize, out array, rijndaelManaged.BlockSize, out array2);
			rijndaelManaged.Key = array;
			rijndaelManaged.IV = array2;
			byte[] bytes = Encoding.UTF8.GetBytes(sourceString);
			ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor();
			byte[] array3 = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
			cryptoTransform.Dispose();
			return Convert.ToBase64String(array3);
		}

		// Token: 0x060010AB RID: 4267 RVA: 0x0011948C File Offset: 0x0011768C
		private static void AesGenerateKeyFromPassword(string saltString, string password, int keySize, out byte[] key, int blockSize, out byte[] iv)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(saltString);
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, bytes);
			key = rfc2898DeriveBytes.GetBytes(keySize / 8);
			iv = rfc2898DeriveBytes.GetBytes(blockSize / 8);
		}

		// Token: 0x060010AC RID: 4268 RVA: 0x001194C8 File Offset: 0x001176C8
		public static string Md5EncryptString(string strToEncrypt)
		{
			byte[] bytes = new UTF8Encoding().GetBytes(strToEncrypt);
			byte[] array = new MD5CryptoServiceProvider().ComputeHash(bytes);
			string text = "";
			for (int i = 0; i < array.Length; i++)
			{
				text += Convert.ToString(array[i], 16).PadLeft(2, '0');
			}
			return text.PadLeft(32, '0');
		}

		// Token: 0x040009B6 RID: 2486
		private const string GENERATE_KEY_SALT_STRING = "cFXRc=Prd*l_F8/W";
	}
}
