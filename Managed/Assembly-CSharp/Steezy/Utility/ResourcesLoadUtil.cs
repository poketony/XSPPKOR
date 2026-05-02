using System;
using System.Collections;
using UnityEngine;

namespace Steezy.Utility
{
	// Token: 0x02000096 RID: 150
	public static class ResourcesLoadUtil
	{
		// Token: 0x06000F89 RID: 3977 RVA: 0x0011550D File Offset: 0x0011370D
		public static GameObject GetGameObj(string objName, bool isThrowException = false)
		{
			return ResourcesLoadUtil.GetGameObj(objName, true, isThrowException);
		}

		// Token: 0x06000F8A RID: 3978 RVA: 0x00115517 File Offset: 0x00113717
		public static GameObject GetGameObjDontCache(string objName, bool isThrowException = false)
		{
			return ResourcesLoadUtil.GetGameObj(objName, false, isThrowException);
		}

		// Token: 0x06000F8B RID: 3979 RVA: 0x00115524 File Offset: 0x00113724
		private static GameObject GetGameObj(string objName, bool isCache, bool isThrowException)
		{
			GameObject gameObject = (GameObject)ResourcesLoadUtil.gameObjHash[objName];
			if (gameObject == null)
			{
				gameObject = (GameObject)Resources.Load(objName);
				if (gameObject == null)
				{
					if (isThrowException)
					{
						throw new Exception("File Not Found!! [File Name] -> " + objName);
					}
				}
				else if (isCache)
				{
					ResourcesLoadUtil.gameObjHash.Add(objName, gameObject);
				}
			}
			return gameObject;
		}

		// Token: 0x06000F8C RID: 3980 RVA: 0x00115584 File Offset: 0x00113784
		public static void ClearGameObjHash()
		{
			ResourcesLoadUtil.gameObjHash = new Hashtable();
		}

		// Token: 0x06000F8D RID: 3981 RVA: 0x00115590 File Offset: 0x00113790
		public static void RemoveGameObjHashItem(string name)
		{
			if (string.IsNullOrEmpty(name) || ResourcesLoadUtil.gameObjHash == null || ResourcesLoadUtil.gameObjHash.ContainsKey(name))
			{
				return;
			}
			ResourcesLoadUtil.gameObjHash.Remove(name);
		}

		// Token: 0x06000F8E RID: 3982 RVA: 0x001155BA File Offset: 0x001137BA
		public static Object GetCommonObj(string objName, bool isThrowException = false)
		{
			return ResourcesLoadUtil.GetCommonObj(objName, true, isThrowException);
		}

		// Token: 0x06000F8F RID: 3983 RVA: 0x001155C4 File Offset: 0x001137C4
		public static Object GetCommonObjDontCache(string objName, bool isThrowException = false)
		{
			return ResourcesLoadUtil.GetCommonObj(objName, false, isThrowException);
		}

		// Token: 0x06000F90 RID: 3984 RVA: 0x001155D0 File Offset: 0x001137D0
		private static Object GetCommonObj(string objName, bool isCache, bool isThrowException)
		{
			Object @object = (Object)ResourcesLoadUtil.commonObjHash[objName];
			if (@object == null)
			{
				@object = Resources.Load(objName);
				if (@object == null)
				{
					if (isThrowException)
					{
						throw new Exception("File Not Found!! [File Name] -> " + objName);
					}
				}
				else if (isCache)
				{
					ResourcesLoadUtil.commonObjHash.Add(objName, @object);
				}
			}
			return @object;
		}

		// Token: 0x06000F91 RID: 3985 RVA: 0x0011562B File Offset: 0x0011382B
		public static void ClearCommonObjHash()
		{
			ResourcesLoadUtil.commonObjHash = new Hashtable();
		}

		// Token: 0x06000F92 RID: 3986 RVA: 0x00115637 File Offset: 0x00113837
		public static Texture GetTextureObj(string objName, bool isThrowException = false)
		{
			return ResourcesLoadUtil.GetTextureObj(objName, true, isThrowException);
		}

		// Token: 0x06000F93 RID: 3987 RVA: 0x00115641 File Offset: 0x00113841
		public static Texture GetTextureObjDontCache(string objName, bool isThrowException = false)
		{
			return ResourcesLoadUtil.GetTextureObj(objName, false, isThrowException);
		}

		// Token: 0x06000F94 RID: 3988 RVA: 0x0011564C File Offset: 0x0011384C
		private static Texture GetTextureObj(string objName, bool isCache, bool isThrowException)
		{
			Texture texture = (Texture)ResourcesLoadUtil.textureObjHash[objName];
			if (texture == null)
			{
				texture = (Texture)Resources.Load(objName);
				if (texture == null)
				{
					if (isThrowException)
					{
						throw new Exception("File Not Found!! [File Name] -> " + objName);
					}
				}
				else if (isCache)
				{
					ResourcesLoadUtil.textureObjHash.Add(objName, texture);
				}
			}
			return texture;
		}

		// Token: 0x06000F95 RID: 3989 RVA: 0x001156AC File Offset: 0x001138AC
		public static void ClearTextureObjHash()
		{
			ResourcesLoadUtil.textureObjHash = new Hashtable();
		}

		// Token: 0x06000F96 RID: 3990 RVA: 0x001156B8 File Offset: 0x001138B8
		public static Sprite GetSpriteObj(string objName, bool isThrowException = false)
		{
			return ResourcesLoadUtil.GetSpriteObj(objName, true, isThrowException);
		}

		// Token: 0x06000F97 RID: 3991 RVA: 0x001156C2 File Offset: 0x001138C2
		public static Sprite GetSpriteObjDontCache(string objName, bool isThrowException = false)
		{
			return ResourcesLoadUtil.GetSpriteObj(objName, false, isThrowException);
		}

		// Token: 0x06000F98 RID: 3992 RVA: 0x001156CC File Offset: 0x001138CC
		private static Sprite GetSpriteObj(string objName, bool isCache, bool isThrowException)
		{
			Sprite sprite = (Sprite)ResourcesLoadUtil.spriteObjHash[objName];
			if (sprite == null)
			{
				sprite = Resources.Load<Sprite>(objName);
				if (sprite == null)
				{
					if (isThrowException)
					{
						throw new Exception("File Not Found!! [File Name] -> " + objName);
					}
				}
				else if (isCache)
				{
					ResourcesLoadUtil.spriteObjHash.Add(objName, sprite);
				}
			}
			return sprite;
		}

		// Token: 0x06000F99 RID: 3993 RVA: 0x00115727 File Offset: 0x00113927
		public static void ClearSpriteObjHash()
		{
			ResourcesLoadUtil.spriteObjHash = new Hashtable();
		}

		// Token: 0x06000F9A RID: 3994 RVA: 0x00115733 File Offset: 0x00113933
		public static Sprite GetMultipleSpriteObj(string path, string spriteFileName, string spriteName, bool isThrowException = false)
		{
			return ResourcesLoadUtil.GetMultipleSpriteObj(path, spriteFileName, spriteName, true, isThrowException);
		}

		// Token: 0x06000F9B RID: 3995 RVA: 0x0011573F File Offset: 0x0011393F
		public static Sprite GetMultipleSpriteObjDontCache(string path, string spriteFileName, string spriteName, bool isThrowException = false)
		{
			return ResourcesLoadUtil.GetMultipleSpriteObj(path, spriteFileName, spriteName, false, isThrowException);
		}

		// Token: 0x06000F9C RID: 3996 RVA: 0x0011574C File Offset: 0x0011394C
		private static Sprite GetMultipleSpriteObj(string path, string spriteFileName, string spriteName, bool isCache, bool isThrowException)
		{
			string text = string.Format("{0}{1}", path, spriteFileName);
			string text2 = string.Format("{0}/{1}", text, spriteName);
			Sprite sprite2 = (Sprite)ResourcesLoadUtil.multipleSpriteObjHash[text2];
			if (sprite2 == null)
			{
				sprite2 = Array.Find<Sprite>(Resources.LoadAll<Sprite>(text), (Sprite sprite) => sprite.name.Equals(spriteName));
				if (sprite2 == null)
				{
					if (isThrowException)
					{
						throw new Exception("File Not Found!! [File Name] -> " + text2);
					}
				}
				else if (isCache)
				{
					ResourcesLoadUtil.multipleSpriteObjHash.Add(text2, sprite2);
				}
			}
			return sprite2;
		}

		// Token: 0x06000F9D RID: 3997 RVA: 0x001157E5 File Offset: 0x001139E5
		public static void ClearMultipleSpriteObjHash()
		{
			ResourcesLoadUtil.multipleSpriteObjHash = new Hashtable();
		}

		// Token: 0x06000F9E RID: 3998 RVA: 0x001157F1 File Offset: 0x001139F1
		public static Material GetMaterialObj(string objName, bool isThrowException = false)
		{
			return ResourcesLoadUtil.GetMaterialObj(objName, true, isThrowException);
		}

		// Token: 0x06000F9F RID: 3999 RVA: 0x001157FB File Offset: 0x001139FB
		public static Material GetMaterialObjDontCache(string objName, bool isThrowException = false)
		{
			return ResourcesLoadUtil.GetMaterialObj(objName, false, isThrowException);
		}

		// Token: 0x06000FA0 RID: 4000 RVA: 0x00115808 File Offset: 0x00113A08
		private static Material GetMaterialObj(string objName, bool isCache, bool isThrowException)
		{
			Material material = (Material)ResourcesLoadUtil.materialObjHash[objName];
			if (material == null)
			{
				material = Resources.Load<Material>(objName);
				if (material == null)
				{
					if (isThrowException)
					{
						throw new Exception("File Not Found!! [File Name] -> " + objName);
					}
				}
				else if (isCache)
				{
					ResourcesLoadUtil.materialObjHash.Add(objName, material);
				}
			}
			return material;
		}

		// Token: 0x06000FA1 RID: 4001 RVA: 0x00115863 File Offset: 0x00113A63
		public static void ClearMaterialObjHash()
		{
			ResourcesLoadUtil.materialObjHash = new Hashtable();
		}

		// Token: 0x06000FA2 RID: 4002 RVA: 0x0011586F File Offset: 0x00113A6F
		public static AnimationClip GetAnimationClipObj(string objName, bool isThrowException = false)
		{
			return ResourcesLoadUtil.GetAnimationClipObj(objName, true, isThrowException);
		}

		// Token: 0x06000FA3 RID: 4003 RVA: 0x00115879 File Offset: 0x00113A79
		public static AnimationClip GetAnimationClipObjDontCache(string objName, bool isThrowException = false)
		{
			return ResourcesLoadUtil.GetAnimationClipObj(objName, false, isThrowException);
		}

		// Token: 0x06000FA4 RID: 4004 RVA: 0x00115884 File Offset: 0x00113A84
		private static AnimationClip GetAnimationClipObj(string objName, bool isCache, bool isThrowException)
		{
			AnimationClip animationClip = (AnimationClip)ResourcesLoadUtil.animationClipObjHash[objName];
			if (animationClip == null)
			{
				animationClip = Resources.Load<AnimationClip>(objName);
				if (animationClip == null)
				{
					if (isThrowException)
					{
						throw new Exception("File Not Found!! [File Name] -> " + objName);
					}
				}
				else if (isCache)
				{
					ResourcesLoadUtil.animationClipObjHash.Add(objName, animationClip);
				}
			}
			return animationClip;
		}

		// Token: 0x06000FA5 RID: 4005 RVA: 0x001158DF File Offset: 0x00113ADF
		public static void ClearAnimationClipObjHash()
		{
			ResourcesLoadUtil.animationClipObjHash = new Hashtable();
		}

		// Token: 0x06000FA6 RID: 4006 RVA: 0x001158EB File Offset: 0x00113AEB
		public static RuntimeAnimatorController GetAnimatorObj(string objName, bool isThrowException = false)
		{
			return ResourcesLoadUtil.GetAnimatorObj(objName, true, isThrowException);
		}

		// Token: 0x06000FA7 RID: 4007 RVA: 0x001158F5 File Offset: 0x00113AF5
		public static RuntimeAnimatorController GetAnimatorObjDontCache(string objName, bool isThrowException = false)
		{
			return ResourcesLoadUtil.GetAnimatorObj(objName, false, isThrowException);
		}

		// Token: 0x06000FA8 RID: 4008 RVA: 0x00115900 File Offset: 0x00113B00
		private static RuntimeAnimatorController GetAnimatorObj(string objName, bool isCache, bool isThrowException)
		{
			RuntimeAnimatorController runtimeAnimatorController = (RuntimeAnimatorController)ResourcesLoadUtil.animatorObjHash[objName];
			if (runtimeAnimatorController == null)
			{
				runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(objName);
				if (runtimeAnimatorController == null)
				{
					if (isThrowException)
					{
						throw new Exception("File Not Found!! [File Name] -> " + objName);
					}
				}
				else if (isCache)
				{
					ResourcesLoadUtil.animatorObjHash.Add(objName, runtimeAnimatorController);
				}
			}
			return runtimeAnimatorController;
		}

		// Token: 0x06000FA9 RID: 4009 RVA: 0x0011595B File Offset: 0x00113B5B
		public static void ClearAnimatorObjHash()
		{
			ResourcesLoadUtil.animatorObjHash = new Hashtable();
		}

		// Token: 0x0400096F RID: 2415
		private static Hashtable gameObjHash = new Hashtable();

		// Token: 0x04000970 RID: 2416
		private static Hashtable commonObjHash = new Hashtable();

		// Token: 0x04000971 RID: 2417
		private static Hashtable textureObjHash = new Hashtable();

		// Token: 0x04000972 RID: 2418
		private static Hashtable spriteObjHash = new Hashtable();

		// Token: 0x04000973 RID: 2419
		private static Hashtable multipleSpriteObjHash = new Hashtable();

		// Token: 0x04000974 RID: 2420
		private static Hashtable materialObjHash = new Hashtable();

		// Token: 0x04000975 RID: 2421
		private static Hashtable animationClipObjHash = new Hashtable();

		// Token: 0x04000976 RID: 2422
		private static Hashtable animatorObjHash = new Hashtable();
	}
}
