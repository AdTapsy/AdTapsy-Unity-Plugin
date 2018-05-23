using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class AdTapsyAndroid {
	
	static AdTapsyAndroid(){
		#if UNITY_ANDROID  && !UNITY_EDITOR
		AndroidJNI.AttachCurrentThread();
		#endif
	}
	
	public static void StartSession(string appId){
		#if UNITY_ANDROID  && !UNITY_EDITOR 
		getAdTapsy().CallStatic("setEngine", "unity");
		getAdTapsy().CallStatic("setDelegate", new AdTapsyDelegate());
		getAdTapsy().CallStatic("setRewardedDelegate", new AdTapsyRewardedDelegate());
		getAdTapsy().CallStatic("startSession", getCurrentActivity(), appId);
		#endif
	}

	public static void SetTestMode(bool enabled, params string[] testDevices){
		#if UNITY_ANDROID  && !UNITY_EDITOR
		getAdTapsy().CallStatic("setTestMode", true, testDevices);
		#endif
	}
	
	public static void ShowInterstitial(){
		#if UNITY_ANDROID  && !UNITY_EDITOR
		getAdTapsy().CallStatic("showInterstitial", getCurrentActivity());
		#endif
	}
	public static void ShowRewardedVideo(){
		#if UNITY_ANDROID  && !UNITY_EDITOR
		getAdTapsy().CallStatic("showRewardedVideo", getCurrentActivity());
		#endif
	}
	public static bool CloseAd(){
		#if UNITY_ANDROID  && !UNITY_EDITOR
		return getAdTapsy().CallStatic<bool>("closeAd");
		#else
		return false;
		#endif
	}
	public static bool IsInterstitialReadyToShow(){
		#if UNITY_ANDROID  && !UNITY_EDITOR
		return getAdTapsy().CallStatic<bool>("isInterstitialReadyToShow");
		#else
		return false;
		#endif
	}
	public static bool IsRewardedVideoReadyToShow(){
		#if UNITY_ANDROID  && !UNITY_EDITOR
		return getAdTapsy().CallStatic<bool>("isRewardedVideoReadyToShow");
		#else
		return false;
		#endif
	}
	public static void SetRewardedVideoAmount(int amount){
#if UNITY_ANDROID  && !UNITY_EDITOR
		getAdTapsy().CallStatic("setRewardedVideoAmount", amount);
#endif
	}
	public static void SetUserIdentifier(string userId){
#if UNITY_ANDROID  && !UNITY_EDITOR
		getAdTapsy().CallStatic("setUserIdentifier", userId);
#endif
	}
	public static void SetRewardedVideoPrePopupEnabled(bool toShow){
#if UNITY_ANDROID  && !UNITY_EDITOR
		getAdTapsy().CallStatic("setRewardedVideoPrePopupEnabled", toShow);
#endif
	}
	public static void SetRewardedVideoPostPopupEnabled(bool toShow){
#if UNITY_ANDROID  && !UNITY_EDITOR
		getAdTapsy().CallStatic("setRewardedVideoPostPopupEnabled", toShow);
#endif
	}

    public static void SetUserSubjectToGdpr(bool value){
#if UNITY_ANDROID  && !UNITY_EDITOR
        getAdTapsy().CallStatic("setUserSubjectToGdpr", value);
#endif
    }
    public static void SetConsentGrantedGdpr(bool value){
#if UNITY_ANDROID  && !UNITY_EDITOR
        getAdTapsy().CallStatic("setConsentGrantedGdpr", value);
#endif
    }

	#if UNITY_ANDROID  && !UNITY_EDITOR
	private static AndroidJavaObject getCurrentActivity(){
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"); 
		return jo;
	}
	 

	private static AndroidJavaClass getAdTapsy(){
		return new AndroidJavaClass("com.adtapsy.sdk.AdTapsy");
	}
	private class AdTapsyRewardedDelegate : AndroidJavaProxy
	{
		public AdTapsyRewardedDelegate() : base("com.adtapsy.sdk.AdTapsyRewardedDelegate")
		{

		}
		void onRewardEarned(int amount){
			AdTapsy.OnRewardEarned.Invoke (amount);
		}
	}
	private class AdTapsyDelegate : AndroidJavaProxy
	{
		
		public AdTapsyDelegate() : base("com.adtapsy.sdk.AdTapsyDelegate")
		{
			
		}
		
		void onAdShown(int zoneId)
		{
			AdTapsy.OnAdShown.Invoke (zoneId);
		}
		void onAdSkipped(int zoneId){
			AdTapsy.OnAdSkipped.Invoke (zoneId);
		}
		void onAdClicked(int zoneId){
			AdTapsy.OnAdClicked.Invoke (zoneId);
		}
		void onAdFailToShow(int zoneId){
			AdTapsy.OnAdFailedToShow.Invoke (zoneId);
		}
		void onAdCached(int zoneId){
			AdTapsy.OnAdCached.Invoke (zoneId);
		}
	}
	#endif
	
}
