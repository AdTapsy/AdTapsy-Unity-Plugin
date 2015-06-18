using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class AdTapsyAndroid {
	
	static AdTapsyAndroid(){
		#if UNITY_ANDROID
		AndroidJNI.AttachCurrentThread();
		#endif
	}
	
	public static void StartSession(string appId){
		#if UNITY_ANDROID  
		getAdTapsy().CallStatic("setEngine", "unity");
		getAdTapsy().CallStatic("setDelegate", new AdTapsyDelegate());
		getAdTapsy().CallStatic("startSession", getCurrentActivity(), appId);
		#endif
	}
	
	public static void SetTestMode(bool enabled, params string[] testDevices){
		#if UNITY_ANDROID 
		getAdTapsy().CallStatic("setTestMode", true, testDevices);
		#endif
	}
	
	public static void ShowInterstitial(){
		#if UNITY_ANDROID 
		getAdTapsy().CallStatic("showInterstitial", getCurrentActivity());
		#endif
	}
	public static bool CloseAd(){
		#if UNITY_ANDROID
		return getAdTapsy().CallStatic<bool>("closeAd");
		#else
		return false;
		#endif
	}
	public static bool isAdReadyToShow(){
		#if UNITY_ANDROID
		return getAdTapsy().CallStatic<bool>("isAdReadyToShow");
		#else
		return false;
		#endif
	}
	#if UNITY_ANDROID
	private static AndroidJavaObject getCurrentActivity(){
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"); 
		return jo;
	}
	private static AndroidJavaClass getAdTapsy(){
		return new AndroidJavaClass("com.adtapsy.sdk.AdTapsy");
	}
	
	private class AdTapsyDelegate : AndroidJavaProxy
	{
		
		public AdTapsyDelegate() : base("com.adtapsy.sdk.AdTapsyDelegate")
		{
			
		}
		
		void onAdShown()
		{
			AdTapsy.OnAdShown.Invoke ();
		}
		void onAdSkipped(){
			AdTapsy.OnAdSkipped.Invoke ();
		}
		void onAdClicked(){
			AdTapsy.OnAdClicked.Invoke ();
		}
		void onAdFailToShow(){
			AdTapsy.OnAdFailedToShow.Invoke ();
		}
		void onAdCached(){
			AdTapsy.OnAdCached.Invoke ();
		}
	}
	#endif
	
}