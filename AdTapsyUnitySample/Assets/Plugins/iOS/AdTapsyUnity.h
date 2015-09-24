//
//  AdTapsyUnity.h
//  AdTapsy
//
//  Created by Borislav Gizdov on 8/18/14.
//  Copyright (c) 2014 AdTapsy Ltd. All rights reserved.
//	<support@adtapsy.com>
//
#import "AdTapsy.h"


extern "C" {
    void AdTapsyStartSession(const char* appId);

    void AdTapsyShowInterstitial();

    void AdTapsyShowRewardedVideo();
    
    void AdTapsySetTestMode(BOOL testModeEnabled, const char** deviceIds);
    
    bool AdTapsyIsInterstitialReadyToShow();

    bool AdTapsyIsRewardedVideoReadyToShow();

    void AdTapsySetRewardedVideoAmount(int amount);

    void AdTapsySetRewardedVideoPrePopupEnabled(BOOL toShow);

    void AdTapsySetRewardedVideoPostPopupEnabled(BOOL toShow);

    void AdTapsySetUserIdentifier(const char* userId);
}


@interface AdTapsyDelegateImpl: NSObject<AdTapsyDelegate>

/**
 * Called when Interstitial ad shown successfuly
 */
- (void) adtapsyDidShowInterstitialAd;

/**
 * Called when Interstitial ad failed to show. All used ad networks has no fill.
 */
- (void) adtapsyDidFailedToShowInterstitialAd;

/**
 * Called when user clicked on Interstitial ad
 */
- (void) adtapsyDidClickedInterstitialAd;

/**
 * Called when user skipped Interstitial ad (clicked X button to close)
 */
- (void) adtapsyDidSkippedInterstitialAd;


/**
 * Called when at least one Interstitial ad is loaded and ready to show
 */
- (void) adtapsyDidCachedInterstitialAd;


/**
 * Called when rewarded video ad shown successfuly
 */
- (void) adtapsyDidShowRewardedVideoAd;

/**
 * Called when rewarded video ad failed to show. All used ad networks has no fill.
 */
- (void) adtapsyDidFailedToShowRewardedVideoAd;

/**
 * Called when user clicked on rewarded video ad
 */
- (void) adtapsyDidClickedRewardedVideoAd;

/**
 * Called when user skipped rewarded video ad (clicked X button to close)
 */
- (void) adtapsyDidSkippedRewardedVideoAd;


/**
 * Called when at least one rewarded video ad is loaded and ready to show
 */
- (void) adtapsyDidCachedRewardedVideoAd;

/**
 * Called when user earned reward for video view
 */
-(void) adtapsyDidEarnedReward:(BOOL) success andAmount:(int) amount;

@end