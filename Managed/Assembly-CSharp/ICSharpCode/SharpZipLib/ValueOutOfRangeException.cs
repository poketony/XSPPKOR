using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib
{
	// Token: 0x02000138 RID: 312
	[Serializable]
	public class ValueOutOfRangeException : StreamDecodingException
	{
		// Token: 0x060016AE RID: 5806 RVA: 0x0012DC51 File Offset: 0x0012BE51
		public ValueOutOfRangeException(string nameOfValue)
			: base(nameOfValue + " out of range")
		{
		}

		// Token: 0x060016AF RID: 5807 RVA: 0x0012DC64 File Offset: 0x0012BE64
		public ValueOutOfRangeException(string nameOfValue, long value, long maxValue, long minValue = 0L)
			: this(nameOfValue, value.ToString(), maxValue.ToString(), minValue.ToString())
		{
		}

		// Token: 0x060016B0 RID: 5808 RVA: 0x0012DC82 File Offset: 0x0012BE82
		public ValueOutOfRangeException(string nameOfValue, string value, string maxValue, string minValue = "0")
			: base(string.Concat(new string[] { nameOfValue, " out of range: ", value, ", should be ", minValue, "..", maxValue }))
		{
		}

		// Token: 0x060016B1 RID: 5809 RVA: 0x0012DCBE File Offset: 0x0012BEBE
		private ValueOutOfRangeException()
		{
		}

		// Token: 0x060016B2 RID: 5810 RVA: 0x0012DCC6 File Offset: 0x0012BEC6
		private ValueOutOfRangeException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		// Token: 0x060016B3 RID: 5811 RVA: 0x0012DCD0 File Offset: 0x0012BED0
		protected ValueOutOfRangeException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
