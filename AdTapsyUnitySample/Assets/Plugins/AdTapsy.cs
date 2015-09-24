//
//  AdTapsySDK.cs
//  AdTapsy
//
//  Copyright (c) 2014 AdTapsy Ltd. All rights reserved.
//	<support@adtapsy.com>
//
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdTapsy : MonoBehaviour {
	public const int InterstitialZone = 0;
	public const int RewardedVideoZone = 1;

	public delegate void ATDelegate(int zoneId);
	public static ATDelegate OnAdCached = delegate {};
	public static ATDelegate OnAdShown = delegate {};
	public static ATDelegate OnAdSkipped = delegate {};
	public static ATDelegate OnAdClicked  = delegate {};
	public static ATDelegate OnAdFailedToShow  = delegate {};
	public static ATDelegate OnRewardEarned = delegate{};

	public static void StartSessionAndroid(string appId){
#if UNITY_ANDROID  && !UNITY_EDITOR
		AdTapsyAndroid.StartSession(appId);
#endif
	}

	public static void StartSessionIOS(string appId) {
#if UNITY_IPHONE && !UNITY_EDITOR
		AdTapsyIOS.StartSession (appId);
#endif	
	}

	public static void SetTestMode(bool enabled, params string[] testDevices){
#if UNITY_ANDROID  && !UNITY_EDITOR
		AdTapsyAndroid.SetTestMode(enabled, testDevices);
#endif
#if UNITY_IPHONE && !UNITY_EDITOR
		AdTapsyIOS.SetTestMode(enabled, testDevices);
#endif
	}
 
	public static void ShowInterstitial(){
#if UNITY_ANDROID  && !UNITY_EDITOR
		AdTapsyAndroid.ShowInterstitial();
#endif
#if UNITY_IPHONE && !UNITY_EDITOR
		AdTapsyIOS.ShowInterstitial ();
#endif
	}
	
	public static bool IsInterstitialReadyToShow(){
#if UNITY_ANDROID  && !UNITY_EDITOR
		return AdTapsyAndroid.IsInterstitialReadyToShow();
#endif
#if UNITY_IPHONE && !UNITY_EDITOR
		return AdTapsyIOS.IsInterstitialReadyToShow();
#else
		return false;
#endif
	}
	public static void ShowRewardedVideo(){
#if UNITY_ANDROID  && !UNITY_EDITOR
		AdTapsyAndroid.ShowRewardedVideo();
#endif
#if UNITY_IPHONE && !UNITY_EDITOR
		AdTapsyIOS.ShowRewardedVideo ();
#endif
	}
	
	public static bool IsRewardedVideoReadyToShow(){
#if UNITY_ANDROID  && !UNITY_EDITOR
		return AdTapsyAndroid.IsRewardedVideoReadyToShow();
#endif
#if UNITY_IPHONE && !UNITY_EDITOR
		return AdTapsyIOS.IsRewardedVideoReadyToShow();
#else
		return false;
#endif
	}

	
	public static bool CloseAd(){
#if UNITY_ANDROID  && !UNITY_EDITOR
		return AdTapsyAndroid.CloseAd();
#else
		return false;
#endif
	}
	public static void SetRewardedVideoAmount(int amount){
#if UNITY_ANDROID && !UNITY_EDITOR
		AdTapsyAndroid.SetRewardedVideoAmount(amount);
#endif
#if UNITY_IPHONE && !UNITY_EDITOR
	AdTapsyIOS.SetRewardedVideoAmount(amount);
#endif
	}
	public static void SetUserIdentifier(string userId){
#if UNITY_ANDROID && !UNITY_EDITOR
		AdTapsyAndroid.SetUserIdentifier(userId);
#endif
#if UNITY_IPHONE && !UNITY_EDITOR
		AdTapsyIOS.SetUserIdentifier(userId);
#endif
	}
	public static void SetRewardedVideoPrePopupEnabled(bool toShow){
#if UNITY_ANDROID && !UNITY_EDITOR
		AdTapsyAndroid.SetRewardedVideoPrePopupEnabled(toShow);
#endif
#if UNITY_IPHONE && !UNITY_EDITOR
		AdTapsyIOS.SetRewardedVideoPrePopupEnabled(toShow);
#endif
	}
	public static void SetRewardedVideoPostPopupEnabled(bool toShow){
#if UNITY_ANDROID && !UNITY_EDITOR
		AdTapsyAndroid.SetRewardedVideoPostPopupEnabled(toShow);
#endif
#if UNITY_IPHONE && !UNITY_EDITOR
		AdTapsyIOS.SetRewardedVideoPrePopupEnabled(toShow);
#endif
	}
}