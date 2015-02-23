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
	public delegate void ATDelegate();
	public static ATDelegate OnAdShown = delegate {};
	public static ATDelegate OnAdSkipped = delegate {};
	public static ATDelegate OnAdClicked  = delegate {};
	public static ATDelegate OnAdFailedToShow  = delegate {};
	
	public static void StartSessionAndroid(string appId){
#if UNITY_ANDROID
		AdTapsyAndroid.StartSession(appId);
#endif
	}

	public static void StartSessionIOS(string appId) {
#if UNITY_IPHONE
		AdTapsyIOS.StartSession (appId);
#endif	
	}

	public static void SetTestMode(bool enabled, params string[] testDevices){
#if UNITY_ANDROID
		AdTapsyAndroid.SetTestMode(enabled, testDevices);
#endif
#if UNITY_IPHONE
		AdTapsyIOS.SetTestMode(enabled, testDevices);
#endif
	}
 
	public static void ShowInterstitial(){
#if UNITY_ANDROID
		AdTapsyAndroid.ShowInterstitial();
#endif
#if UNITY_IPHONE
		AdTapsyIOS.ShowInterstitial ();
#endif
	}
	public static bool CloseAd(){
#if UNITY_ANDROID
		return AdTapsyAndroid.CloseAd();
#endif
		return false;
	}
}