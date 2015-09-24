using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sample : MonoBehaviour {
	void OnGUI() {
		int buttonWidth = 350;
		int buttonHeight = 220;
		GUIStyle buttonStyle = new GUIStyle ("button");
		buttonStyle.fontSize = 40;
		if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth/2, Screen.height / 2 - buttonHeight/2, buttonWidth, buttonHeight), "Show ad", buttonStyle)) {
			this.ShowInterstitial();
		}
		float left = Screen.width / 2f - buttonWidth / 2;
		float top = Screen.height / 1.2f - buttonHeight / 2;
		if (GUI.Button(new Rect(left, top, buttonWidth, buttonHeight), "Show rewarded ad", buttonStyle)) {
			this.ShowRewardedVideo();
		}
	}

	void ShowInterstitial() {
		if (AdTapsy.IsInterstitialReadyToShow()) {
			UnityEngine.Debug.Log("Ad is ready to be shown");
			AdTapsy.ShowInterstitial ();
		} else {
			UnityEngine.Debug.Log("Ad is not ready to be shown");
		}
	}
	void ShowRewardedVideo() {
		if (AdTapsy.IsRewardedVideoReadyToShow ()) {
			UnityEngine.Debug.Log("Ad is ready to be shown");
			AdTapsy.ShowRewardedVideo();
		} else {
			UnityEngine.Debug.Log("Ad is not ready to be shown");
		}
	}

	void Start () 
	{
		AdTapsy.SetRewardedVideoAmount (10);
		AdTapsy.SetRewardedVideoPostPopupEnabled (false);
		AdTapsy.SetRewardedVideoPrePopupEnabled (false);
		AdTapsy.SetTestMode (true, "0939F9B5190D9FFFE196393EC8B96A5F", "a46f0617d60d5f1b19b554c6014f364a");
		AdTapsy.OnAdCached += delegate(int zoneId) {
			if(zoneId == AdTapsy.InterstitialZone){
				UnityEngine.Debug.Log("***AdTapsy cached interstitial ad***");
			} else if(zoneId == AdTapsy.RewardedVideoZone){
				UnityEngine.Debug.Log("***AdTapsy cached rewarded ad***");
			}
		};
		AdTapsy.OnAdShown += delegate(int zoneId){
			if(zoneId == AdTapsy.InterstitialZone){
				UnityEngine.Debug.Log("***AdTapsy showed interstitial ad***");
			} else if(zoneId == AdTapsy.RewardedVideoZone){
				UnityEngine.Debug.Log("***AdTapsy showed rewarded ad***");
			}
		};
		AdTapsy.OnAdSkipped += delegate(int zoneId){
			if(zoneId == AdTapsy.InterstitialZone){
				UnityEngine.Debug.Log("***AdTapsy skipped interstitial ad***");
			} else if(zoneId == AdTapsy.RewardedVideoZone){
				UnityEngine.Debug.Log("***AdTapsy skipped rewarded ad***");
			}
		};
		AdTapsy.OnAdFailedToShow += delegate(int zoneId) {
			if(zoneId == AdTapsy.InterstitialZone){
				UnityEngine.Debug.Log("***AdTapsy failed to show interstitial ad***");
			} else if(zoneId == AdTapsy.RewardedVideoZone){
				UnityEngine.Debug.Log("***AdTapsy failed to show rewarded ad***");
			}
		};
		AdTapsy.OnAdClicked += delegate(int zoneId) {
			if(zoneId == AdTapsy.InterstitialZone){
				UnityEngine.Debug.Log("***AdTapsy clicked interstitial ad***");
			} else if(zoneId == AdTapsy.RewardedVideoZone){
				UnityEngine.Debug.Log("***AdTapsy clicked rewarded ad***");
			}
		};
		AdTapsy.OnRewardEarned += delegate(int amount){
			UnityEngine.Debug.Log("***AdTapsy reward earned " + amount + "***");  
		};

		AdTapsy.StartSessionAndroid ("53a412dde4b01470c1f0321e");
		AdTapsy.StartSessionIOS ("539777bae4b02eacca4bcb67");
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			/* AdTapsy.CloseAd returns whether an interstitial was closed.
			 * If so don't do anything, else handle your events
			*/
			bool adClosed = AdTapsy.CloseAd();
			if(!adClosed){
				Application.Quit();
			}
		}
	}
}