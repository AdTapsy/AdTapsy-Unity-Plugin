using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sample : MonoBehaviour {
	void OnGUI() {
		int buttonWidth = 300;
		int buttonHeight = 180;
		GUIStyle buttonStyle = new GUIStyle ("button");
		buttonStyle.fontSize = 40;
		if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth/2, Screen.height / 2 - buttonHeight/2, buttonWidth, buttonHeight), "Show ad", buttonStyle)) {
			if(AdTapsy.isAdReadyToShow()){
				this.ShowInterstitial();
			} else {
				UnityEngine.Debug.Log("There was no ad to be shown");
			}
		}
	}

	void ShowInterstitial() {
		if (AdTapsy.isAdReadyToShow()) {
			UnityEngine.Debug.Log("Ad is ready to be shown");
			AdTapsy.ShowInterstitial ();
		} else {
			UnityEngine.Debug.Log("Ad is not ready to be shown");
		}
	}

	void Start () 
	{
		AdTapsy.SetTestMode (true, "0939F9B5190D9FFFE196393EC8B96A5F", "a46f0617d60d5f1b19b554c6014f364a");
		AdTapsy.OnAdCached += delegate { UnityEngine.Debug.Log("***AdTapsy.OnAdCached***");};
		AdTapsy.OnAdShown += delegate { UnityEngine.Debug.Log("***AdTapsy.OnAdShown***");};
		AdTapsy.OnAdSkipped += delegate { UnityEngine.Debug.Log("***AdTapsy.OnAdSkipp***");};
		AdTapsy.OnAdFailedToShow += delegate { UnityEngine.Debug.Log("***AdTapsy.OnAdFailedToShow***");};
		AdTapsy.OnAdClicked += delegate { UnityEngine.Debug.Log("***AdTapsy.OnAdClicked***");};

		AdTapsy.StartSessionAndroid ("54982cf7e4b052cd2a20a7b8");
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