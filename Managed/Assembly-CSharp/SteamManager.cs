using System;
using System.Text;
using AOT;
using Steamworks;
using UnityEngine;

// Token: 0x02000062 RID: 98
[DisallowMultipleComponent]
public class SteamManager : MonoBehaviour
{
	// Token: 0x17000017 RID: 23
	// (get) Token: 0x06000E36 RID: 3638 RVA: 0x0010EB06 File Offset: 0x0010CD06
	protected static SteamManager Instance
	{
		get
		{
			if (SteamManager.s_instance == null)
			{
				return new GameObject("SteamManager").AddComponent<SteamManager>();
			}
			return SteamManager.s_instance;
		}
	}

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x06000E37 RID: 3639 RVA: 0x0010EB2A File Offset: 0x0010CD2A
	public static bool Initialized
	{
		get
		{
			return SteamManager.Instance.m_bInitialized;
		}
	}

	// Token: 0x06000E38 RID: 3640 RVA: 0x0010EB36 File Offset: 0x0010CD36
	[MonoPInvokeCallback(typeof(SteamAPIWarningMessageHook_t))]
	protected static void SteamAPIDebugTextHook(int nSeverity, StringBuilder pchDebugText)
	{
		Debug.LogWarning(pchDebugText);
	}

	// Token: 0x06000E39 RID: 3641 RVA: 0x0010EB3E File Offset: 0x0010CD3E
	[RuntimeInitializeOnLoadMethod(4)]
	private static void InitOnPlayMode()
	{
		SteamManager.s_EverInitialized = false;
		SteamManager.s_instance = null;
	}

	// Token: 0x06000E3A RID: 3642 RVA: 0x0010EB4C File Offset: 0x0010CD4C
	protected virtual void Awake()
	{
		if (SteamManager.s_instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		SteamManager.s_instance = this;
		if (SteamManager.s_EverInitialized)
		{
			throw new Exception("Tried to Initialize the SteamAPI twice in one session!");
		}
		Object.DontDestroyOnLoad(base.gameObject);
		if (!Packsize.Test())
		{
			Debug.LogError("[Steamworks.NET] Packsize Test returned false, the wrong version of Steamworks.NET is being run in this platform.", this);
		}
		if (!DllCheck.Test())
		{
			Debug.LogError("[Steamworks.NET] DllCheck Test returned false, One or more of the Steamworks binaries seems to be the wrong version.", this);
		}
		try
		{
			if (SteamAPI.RestartAppIfNecessary(new AppId_t(4532150U)))
			{
				Debug.Log("[Steamworks.NET] Shutting down because RestartAppIfNecessary returned true. Steam will restart the application.");
				Application.Quit();
				return;
			}
		}
		catch (DllNotFoundException ex)
		{
			string text = "[Steamworks.NET] Could not load [lib]steam_api.dll/so/dylib. It's likely not in the correct location. Refer to the README for more details.\n";
			DllNotFoundException ex2 = ex;
			Debug.LogError(text + ((ex2 != null) ? ex2.ToString() : null), this);
			Application.Quit();
			return;
		}
		this.m_bInitialized = SteamAPI.Init();
		if (!this.m_bInitialized)
		{
			Debug.LogError("[Steamworks.NET] SteamAPI_Init() failed. Refer to Valve's documentation or the comment above this line for more information.", this);
			return;
		}
		SteamManager.s_EverInitialized = true;
	}

	// Token: 0x06000E3B RID: 3643 RVA: 0x0010EC38 File Offset: 0x0010CE38
	protected virtual void OnEnable()
	{
		if (SteamManager.s_instance == null)
		{
			SteamManager.s_instance = this;
		}
		if (!this.m_bInitialized)
		{
			return;
		}
		if (this.m_SteamAPIWarningMessageHook == null)
		{
			this.m_SteamAPIWarningMessageHook = new SteamAPIWarningMessageHook_t(SteamManager.SteamAPIDebugTextHook);
			SteamClient.SetWarningMessageHook(this.m_SteamAPIWarningMessageHook);
		}
	}

	// Token: 0x06000E3C RID: 3644 RVA: 0x0010EC86 File Offset: 0x0010CE86
	protected virtual void OnDestroy()
	{
		if (SteamManager.s_instance != this)
		{
			return;
		}
		SteamManager.s_instance = null;
		if (!this.m_bInitialized)
		{
			return;
		}
		SteamAPI.Shutdown();
	}

	// Token: 0x06000E3D RID: 3645 RVA: 0x0010ECAA File Offset: 0x0010CEAA
	protected virtual void Update()
	{
		if (!this.m_bInitialized)
		{
			return;
		}
		SteamAPI.RunCallbacks();
	}

	// Token: 0x0400086B RID: 2155
	protected static bool s_EverInitialized;

	// Token: 0x0400086C RID: 2156
	protected static SteamManager s_instance;

	// Token: 0x0400086D RID: 2157
	protected bool m_bInitialized;

	// Token: 0x0400086E RID: 2158
	protected SteamAPIWarningMessageHook_t m_SteamAPIWarningMessageHook;
}
