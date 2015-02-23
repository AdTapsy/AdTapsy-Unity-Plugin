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
    
    void AdTapsySetTestMode(BOOL testModeEnabled, const char** deviceIds);
}


@interface AdTapsyDelegateImpl: NSObject<AdTapsyDelegate>

/**
 * Called when ad shown successfuly
 */
- (void) adtapsyDidShowAd;

/**
 * Called when ad failed to show. All used ad networks has no fill.
 */
- (void) adtapsyDidFailedToShowAd;

/**
 * Called when user clicked on ad
 */
- (void) adtapsyDidClickedAd;

/**
 * Called when user skipped ad (clicked X button to close)
 */
- (void) adtapsyDidSkippedAd;

@end