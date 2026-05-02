using System;

namespace Socotra.IO
{
	// Token: 0x02000127 RID: 295
	public class HttpConnection : Connection
	{
		// Token: 0x0600163C RID: 5692 RVA: 0x0012D0C4 File Offset: 0x0012B2C4
		public void SetRequestMethod(string method)
		{
		}

		// Token: 0x0600163D RID: 5693 RVA: 0x0012D0C6 File Offset: 0x0012B2C6
		public void SetRequestProperty(string key, string value)
		{
		}

		// Token: 0x0600163E RID: 5694 RVA: 0x0012D0C8 File Offset: 0x0012B2C8
		public int GetResponseCode()
		{
			return 200;
		}

		// Token: 0x0600163F RID: 5695 RVA: 0x0012D0CF File Offset: 0x0012B2CF
		public void Connect()
		{
		}

		// Token: 0x06001640 RID: 5696 RVA: 0x0012D0D1 File Offset: 0x0012B2D1
		public void Close()
		{
		}

		// Token: 0x06001641 RID: 5697 RVA: 0x0012D0D3 File Offset: 0x0012B2D3
		public InputStream OpenInputStream()
		{
			return null;
		}

		// Token: 0x06001642 RID: 5698 RVA: 0x0012D0D6 File Offset: 0x0012B2D6
		public OutputStream OpenOutputStream()
		{
			return null;
		}

		// Token: 0x06001643 RID: 5699 RVA: 0x0012D0D9 File Offset: 0x0012B2D9
		public DataInputStream OpenDataInputStream()
		{
			return null;
		}

		// Token: 0x06001644 RID: 5700 RVA: 0x0012D0DC File Offset: 0x0012B2DC
		public DataOutputStream OpenDataOutputStream()
		{
			return null;
		}

		// Token: 0x06001645 RID: 5701 RVA: 0x0012D0DF File Offset: 0x0012B2DF
		public long GetLength()
		{
			return 0L;
		}

		// Token: 0x04000CA2 RID: 3234
		public static string GET = "GET";

		// Token: 0x04000CA3 RID: 3235
		public static string HEAD = "HEAD";

		// Token: 0x04000CA4 RID: 3236
		public static int HTTP_ACCEPTED = 202;

		// Token: 0x04000CA5 RID: 3237
		public static int HTTP_BAD_GATEWAY = 502;

		// Token: 0x04000CA6 RID: 3238
		public static int HTTP_BAD_METHOD = 405;

		// Token: 0x04000CA7 RID: 3239
		public static int HTTP_BAD_REQUEST = 400;

		// Token: 0x04000CA8 RID: 3240
		public static int HTTP_CLIENT_TIMEOUT = 408;

		// Token: 0x04000CA9 RID: 3241
		public static int HTTP_CONFLICT = 409;

		// Token: 0x04000CAA RID: 3242
		public static int HTTP_CREATED = 201;

		// Token: 0x04000CAB RID: 3243
		public static int HTTP_ENTITY_TOO_LARGE = 413;

		// Token: 0x04000CAC RID: 3244
		public static int HTTP_EXPECT_FAILED = 417;

		// Token: 0x04000CAD RID: 3245
		public static int HTTP_FORBIDDEN = 403;

		// Token: 0x04000CAE RID: 3246
		public static int HTTP_GATEWAY_TIMEOUT = 504;

		// Token: 0x04000CAF RID: 3247
		public static int HTTP_GONE = 410;

		// Token: 0x04000CB0 RID: 3248
		public static int HTTP_INTERNAL_ERROR = 500;

		// Token: 0x04000CB1 RID: 3249
		public static int HTTP_LENGTH_REQUIRED = 411;

		// Token: 0x04000CB2 RID: 3250
		public static int HTTP_MOVED_PERM = 301;

		// Token: 0x04000CB3 RID: 3251
		public static int HTTP_MOVED_TEMP = 302;

		// Token: 0x04000CB4 RID: 3252
		public static int HTTP_MULT_CHOICE = 300;

		// Token: 0x04000CB5 RID: 3253
		public static int HTTP_NO_CONTENT = 204;

		// Token: 0x04000CB6 RID: 3254
		public static int HTTP_NOT_ACCEPTABLE = 406;

		// Token: 0x04000CB7 RID: 3255
		public static int HTTP_NOT_AUTHORITATIVE = 203;

		// Token: 0x04000CB8 RID: 3256
		public static int HTTP_NOT_FOUND = 404;

		// Token: 0x04000CB9 RID: 3257
		public static int HTTP_NOT_IMPLEMENTED = 501;

		// Token: 0x04000CBA RID: 3258
		public static int HTTP_NOT_MODIFIED = 304;

		// Token: 0x04000CBB RID: 3259
		public static int HTTP_OK = 200;

		// Token: 0x04000CBC RID: 3260
		public static int HTTP_PARTIAL = 206;

		// Token: 0x04000CBD RID: 3261
		public static int HTTP_PAYMENT_REQUIRED = 402;

		// Token: 0x04000CBE RID: 3262
		public static int HTTP_PRECON_FAILED = 412;

		// Token: 0x04000CBF RID: 3263
		public static int HTTP_PROXY_AUTH = 407;

		// Token: 0x04000CC0 RID: 3264
		public static int HTTP_REQ_TOO_LONG = 414;

		// Token: 0x04000CC1 RID: 3265
		public static int HTTP_RESET = 205;

		// Token: 0x04000CC2 RID: 3266
		public static int HTTP_SEE_OTHER = 303;

		// Token: 0x04000CC3 RID: 3267
		public static int HTTP_TEMP_REDIRECT = 307;

		// Token: 0x04000CC4 RID: 3268
		public static int HTTP_UNAUTHORIZED = 401;

		// Token: 0x04000CC5 RID: 3269
		public static int HTTP_UNAVAILABLE = 503;

		// Token: 0x04000CC6 RID: 3270
		public static int HTTP_UNSUPPORTED_RANGE = 416;

		// Token: 0x04000CC7 RID: 3271
		public static int HTTP_UNSUPPORTED_TYPE = 415;

		// Token: 0x04000CC8 RID: 3272
		public static int HTTP_USE_PROXY = 305;

		// Token: 0x04000CC9 RID: 3273
		public static int HTTP_VERSION = 505;

		// Token: 0x04000CCA RID: 3274
		public static string POST = "POST";

		// Token: 0x04000CCB RID: 3275
		private byte[] dummyData = new byte[1024];
	}
}
