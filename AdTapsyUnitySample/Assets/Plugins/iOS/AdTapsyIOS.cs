using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class AdTapsyIOS : MonoBehaviour
{ 
#if UNITY_IPHONE
    // import C-function from our plugin
    [DllImport ("__Internal")]
    public static extern void AdTapsyStartSession(string appId);

    [DllImport ("__Internal")]
    public static extern void AdTapsyShowInterstitial();


    [DllImport ("__Internal")]
    public static extern bool AdTapsyIsAdReadyToShow();

	[DllImport ("__Internal")]
	public static extern void AdTapsySetTestMode(bool enabled, params string[] testDevices);

	private static AdTapsyIOS instance;
	
	private static void createInstance()
	{
		if(instance == null)
		{
			instance = FindObjectOfType( typeof(AdTapsyIOS) ) as AdTapsyIOS;
			if(instance == null)
			{
				instance = new GameObject("AdTapsyIOS").AddComponent<AdTapsyIOS>();
				GameObject.DontDestroyOnLoad(instance.gameObject);
			}
		}
	}


#endif
    /**
    * Start session, call this method on game loading
    */
    public static void StartSession(string appId) {
#if UNITY_IPHONE
        // it won't work in Editor, so don't run it there
        if(Application.platform != RuntimePlatform.OSXEditor) {
			createInstance();
            AdTapsyStartSession(appId);
        }
#endif
    }

	public static void SetTestMode(bool enabled, params string[] testDevices){
		#if UNITY_IPHONE 
		AdTapsySetTestMode(enabled, testDevices);
		#endif
	}

    /**
    * Show interstitial ad
    */
    public static void ShowInterstitial() {
#if UNITY_IPHONE
        // it won't work in Editor, so don't run it there
        if(Application.platform != RuntimePlatform.OSXEditor) {
            AdTapsyShowInterstitial();
        }
#endif
    }

	public static bool isAdReadyToShow(){
#if UNITY_IPHONE
		return AdTapsyIsAdReadyToShow();
#else
		return false;
#endif
	}


#if UNITY_IPHONE
	public void OnAdCached( string empty )
	{
		Debug.Log("**** OnAdCached ***!");
		AdTapsy.OnAdCached.Invoke();
	}
	
	public void OnAdShown( string empty )
	{
		Debug.Log("**** OnAdShown ***!");
		AdTapsy.OnAdShown.Invoke();
	}
	
	public void OnAdSkipped( string empty )
	{
		Debug.Log("**** OnAdSkipped ***!");
		AdTapsy.OnAdSkipped.Invoke();
	}
	
	public void OnAdClicked( string empty )
	{
		Debug.Log("**** OnAdClicked ***!");
		AdTapsy.OnAdClicked.Invoke();
	}
	
	public void OnAdFailedToShow( string empty )
	{
		Debug.Log("**** OnAdFailedToShow ***!");
		AdTapsy.OnAdFailedToShow.Invoke();
	}
#endif
}

