using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Socotra.IO;
using Steezy.Utility;
using UnityEngine;
using UnityEngine.Video;

namespace Socotra.Media
{
	// Token: 0x02000116 RID: 278
	public class MediaManager : SingletonBehaviour<MediaManager>
	{
		// Token: 0x060015A1 RID: 5537 RVA: 0x0012BBA5 File Offset: 0x00129DA5
		private void Start()
		{
		}

		// Token: 0x060015A2 RID: 5538 RVA: 0x0012BBA7 File Offset: 0x00129DA7
		private void Update()
		{
		}

		// Token: 0x060015A3 RID: 5539 RVA: 0x0012BBAC File Offset: 0x00129DAC
		public static MediaImage GetImage(string url)
		{
			LogUtils.LogTrace("<color='orange'>GetImage : </color>" + url);
			if (url.StartsWith("scratchpad:///"))
			{
				ScratchPadData scratchPadData = SingletonBehaviour<ScratchPadManager>.Instance.GetScratchPadData(url);
				if (scratchPadData is ScratchPadDataImage)
				{
					return new MediaImage((scratchPadData as ScratchPadDataImage).BaseSprite, false);
				}
				if (scratchPadData is ScratchPadDataBinary)
				{
					return MediaManager.GetImage((ByteArrayInputStream)(scratchPadData as ScratchPadDataBinary).GetInputStream());
				}
			}
			else if (url.StartsWith("resource:///"))
			{
				Resources resources = SingletonBehaviour<ResourcesManager>.Instance.GetResources(url.Substring(12));
				if (resources != null)
				{
					if (resources.GetResource(0) is Sprite)
					{
						return new MediaImage((Sprite)resources.GetResource(0), false);
					}
					if (resources.GetResource(0) is Texture2D)
					{
						return new MediaImage(resources.GetResource(0) as Texture2D, false);
					}
					if (resources.GetResource(0) is VideoClip)
					{
						return new MediaImage(resources.GetResource(0) as VideoClip, false);
					}
					return MediaManager.GetImage(resources.GetByteData(0));
				}
			}
			return null;
		}

		// Token: 0x060015A4 RID: 5540 RVA: 0x0012BCBA File Offset: 0x00129EBA
		public static MediaImage GetImage(byte[] data)
		{
			return MediaManager.GetImage(data.Select((byte x) => (sbyte)x).ToArray<sbyte>());
		}

		// Token: 0x060015A5 RID: 5541 RVA: 0x0012BCEC File Offset: 0x00129EEC
		public static MediaImage GetImage(sbyte[] data)
		{
			string hashCode = MediaManager.GetHashCode(data);
			Resources resources = SingletonBehaviour<ResourcesManager>.Instance.GetResources(hashCode);
			if (resources != null)
			{
				if (resources.GetResource(0) is Sprite)
				{
					return new MediaImage((Sprite)resources.GetResource(0), false);
				}
				if (resources.GetResource(0) is Texture2D)
				{
					return new MediaImage(resources.GetResource(0) as Texture2D, false);
				}
				if (resources.GetResource(0) is VideoClip)
				{
					return new MediaImage(resources.GetResource(0) as VideoClip, false);
				}
			}
			return new MediaImage(data.Select((sbyte x) => (byte)x).ToArray<byte>(), true);
		}

		// Token: 0x060015A6 RID: 5542 RVA: 0x0012BDA8 File Offset: 0x00129FA8
		public static MediaImage GetImage(InputStream inputstream)
		{
			sbyte[] array = new sbyte[inputstream.Available()];
			inputstream.Read(ref array);
			return MediaManager.GetImage(array);
		}

		// Token: 0x060015A7 RID: 5543 RVA: 0x0012BDD0 File Offset: 0x00129FD0
		public static MediaImage GetImage(ByteArrayInputStream bis)
		{
			sbyte[] array = new sbyte[bis.Available()];
			bis.Read(ref array);
			return MediaManager.GetImage(array);
		}

		// Token: 0x060015A8 RID: 5544 RVA: 0x0012BDF8 File Offset: 0x00129FF8
		public static MediaSound GetSound(string url)
		{
			LogUtils.LogTrace("<color='orange'>GetSound : </color>" + url);
			if (url.StartsWith("scratchpad:///"))
			{
				ScratchPadData scratchPadData = SingletonBehaviour<ScratchPadManager>.Instance.GetScratchPadData(url);
				if (scratchPadData is ScratchPadDataSound)
				{
					ScratchPadDataSound scratchPadDataSound = scratchPadData as ScratchPadDataSound;
					return new MediaSound(scratchPadDataSound.BaseAudio)
					{
						Loop = scratchPadDataSound.Loop
					};
				}
				if (scratchPadData is ScratchPadDataBinary)
				{
					return MediaManager.GetSound(scratchPadData.GetInputStream());
				}
			}
			else if (url.StartsWith("resource:///"))
			{
				Resources resources = SingletonBehaviour<ResourcesManager>.Instance.GetResources(url.Substring(12));
				if (resources != null)
				{
					MediaSound mediaSound = new MediaSound((AudioClip)resources.GetResource(0));
					if (resources is ResourcesSound)
					{
						mediaSound.Loop = (resources as ResourcesSound).Loop;
					}
					return mediaSound;
				}
			}
			return null;
		}

		// Token: 0x060015A9 RID: 5545 RVA: 0x0012BEC0 File Offset: 0x0012A0C0
		public static MediaSound GetSound(InputStream input)
		{
			if (input is SoundInputStream)
			{
				return new MediaSound((input as SoundInputStream).Sound.BaseAudio)
				{
					Loop = (input as SoundInputStream).Sound.Loop
				};
			}
			if (input is ByteArrayInputStream)
			{
				sbyte[] array = new sbyte[input.Available()];
				(input as ByteArrayInputStream).Read(ref array);
				return MediaManager.GetSound(array);
			}
			Debug.LogWarning("Not Found InputStream:" + ((input != null) ? input.ToString() : null));
			return null;
		}

		// Token: 0x060015AA RID: 5546 RVA: 0x0012BF47 File Offset: 0x0012A147
		public static MediaSound GetSound(byte[] data)
		{
			return MediaManager.GetSound(data.Select((byte x) => (sbyte)x).ToArray<sbyte>());
		}

		// Token: 0x060015AB RID: 5547 RVA: 0x0012BF78 File Offset: 0x0012A178
		public static MediaSound GetSound(sbyte[] data)
		{
			string hashCode = MediaManager.GetHashCode(data);
			Debug.Log("File Hash:" + hashCode + " / " + data.Length.ToString());
			Resources resources = SingletonBehaviour<ResourcesManager>.Instance.GetResources(hashCode);
			if (resources != null)
			{
				MediaSound mediaSound = new MediaSound((AudioClip)resources.GetResource(0));
				if (resources is ResourcesSound)
				{
					mediaSound.Loop = (resources as ResourcesSound).Loop;
				}
				return mediaSound;
			}
			Debug.LogWarning("Not found Hash:" + hashCode);
			return null;
		}

		// Token: 0x060015AC RID: 5548 RVA: 0x0012BFFF File Offset: 0x0012A1FF
		public static MediaSound GetSound(AudioClip audio)
		{
			return new MediaSound(audio);
		}

		// Token: 0x060015AD RID: 5549 RVA: 0x0012C008 File Offset: 0x0012A208
		public static string GetHashCode(sbyte[] data)
		{
			SHA1CryptoServiceProvider sha1CryptoServiceProvider = new SHA1CryptoServiceProvider();
			byte[] array = new byte[data.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)data[i];
			}
			byte[] array2 = sha1CryptoServiceProvider.ComputeHash(array);
			sha1CryptoServiceProvider.Clear();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in array2)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString();
		}
	}
}
