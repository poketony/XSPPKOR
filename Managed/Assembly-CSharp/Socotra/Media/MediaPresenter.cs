using System;

namespace Socotra.Media
{
	// Token: 0x02000117 RID: 279
	public interface MediaPresenter
	{
		// Token: 0x060015AF RID: 5551
		MediaResource GetMediaResource();

		// Token: 0x060015B0 RID: 5552
		void Play();

		// Token: 0x060015B1 RID: 5553
		void SetAttribute(int attrib, int value);

		// Token: 0x060015B2 RID: 5554
		void SetMediaListener(MediaListener listener);

		// Token: 0x060015B3 RID: 5555
		void Stop();
	}
}
