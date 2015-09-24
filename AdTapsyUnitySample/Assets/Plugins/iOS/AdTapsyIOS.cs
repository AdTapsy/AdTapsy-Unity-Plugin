using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class AdTapsyIOS : MonoBehaviour
{ 
#if UNITY_IPHONE && !UNITY_EDITOR
    // import C-function from our plugin
    [DllImport ("__Internal")]
    public static extern void AdTapsyStartSession(string appId);

    [DllImport ("__Internal")]
    public static extern void AdTapsyShowInterstitial();

    [DllImport ("__Internal")]
    public static extern void AdTapsyShowRewardedVideo();

    [DllImport ("__Internal")]
    public static extern bool AdTapsyIsInterstitialReadyToShow();

    [DllImport ("__Internal")]
    public static extern bool AdTapsyIsRewardedVideoReadyToShow();

    [DllImport ("__Internal")]
    public static extern void AdTapsySetRewardedVideoPrePopupEnabled(bool toShow);

    [DllImport ("__Internal")]
    public static extern void AdTapsySetRewardedVideoPostPopupEnabled(bool toShow);

	[DllImport ("__Internal")]
	public static extern void AdTapsySetTestMode(bool enabled, params string[] testDevices);

	[DllImport ("__Internal")]
	public static extern void AdTapsySetRewardedVideoAmount(int amount);

	[DllImport ("__Internal")]
	public static extern void AdTapsySetUserIdentifier(string userId);

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
#if UNITY_IPHONE && !UNITY_EDITOR
        // it won't work in Editor, so don't run it there
        if(Application.platform != RuntimePlatform.OSXEditor) {
			createInstance();
            AdTapsyStartSession(appId);
        }
#endif
    }

	public static void SetTestMode(bool enabled, params string[] testDevices){
		#if UNITY_IPHONE  && !UNITY_EDITOR
		AdTapsySetTestMode(enabled, testDevices);
		#endif
	}

    /**
    * Show interstitial ad
    */
    public static void ShowInterstitial() {
#if UNITY_IPHONE && !UNITY_EDITOR
        // it won't work in Editor, so don't run it there
        if(Application.platform != RuntimePlatform.OSXEditor) {
            AdTapsyShowInterstitial();
        }
#endif
    }

    /**
    * Show rewarded video ad
    */
    public static void ShowRewardedVideo() {
#if UNITY_IPHONE && !UNITY_EDITOR
        // it won't work in Editor, so don't run it there
        if(Application.platform != RuntimePlatform.OSXEditor) {
            AdTapsyShowRewardedVideo();
        }
#endif
    }

	public static bool IsInterstitialReadyToShow(){
#if UNITY_IPHONE && !UNITY_EDITOR
		return AdTapsyIsInterstitialReadyToShow();
#else
		return false;
#endif
	}

	public static bool IsRewardedVideoReadyToShow(){
#if UNITY_IPHONE && !UNITY_EDITOR
		return AdTapsyIsInterstitialReadyToShow();
#else
		return false;
#endif
	}

	
	public static void SetRewardedVideoAmount(int amount){
		#if UNITY_IPHONE  && !UNITY_EDITOR
		AdTapsySetRewardedVideoAmount(amount);
		#endif
	}

	public static void SetRewardedVideoPrePopupEnabled(bool toShow){
		#if UNITY_IPHONE  && !UNITY_EDITOR
		AdTapsySetRewardedVideoPrePopupEnabled(toShow);
		#endif
	}

	public static void SetRewardedVideoPostPopupEnabled(bool toShow){
		#if UNITY_IPHONE  && !UNITY_EDITOR
		AdTapsySetRewardedVideoPostPopupEnabled(toShow);
		#endif
	}

	public static void SetUserIdentifier(string userId){
		#if UNITY_IPHONE  && !UNITY_EDITOR
		AdTapsySetUserIdentifier(userId);
		#endif
	}


#if UNITY_IPHONE && !UNITY_EDITOR
	public void OnAdCached( string zoneId )
	{
		Debug.Log("**** OnAdCached ***!");
		AdTapsy.OnAdCached.Invoke(Convert.ToInt32(zoneId));
	}
	
	public void OnAdShown( string zoneId )
	{
		Debug.Log("**** OnAdShown ***!");
		AdTapsy.OnAdShown.Invoke(Convert.ToInt32(zoneId));
	}
	
	public void OnAdSkipped( string zoneId )
	{
		Debug.Log("**** OnAdSkipped ***!");
		AdTapsy.OnAdSkipped.Invoke(Convert.ToInt32(zoneId));
	}
	
	public void OnAdClicked( string zoneId )
	{
		Debug.Log("**** OnAdClicked ***!");
		AdTapsy.OnAdClicked.Invoke(Convert.ToInt32(zoneId));
	}
	
	public void OnAdFailedToShow( string zoneId )
	{
		Debug.Log("**** OnAdFailedToShow ***!");
		AdTapsy.OnAdFailedToShow.Invoke(Convert.ToInt32(zoneId));
	}

	public void OnRewardEarned( string amount )
	{
		Debug.Log("**** OnRewardEarned ***!");
		AdTapsy.OnRewardEarned.Invoke(Convert.ToInt32(amount));
	}

#endif
}

