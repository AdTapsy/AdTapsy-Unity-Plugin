//
//  AdTapsyUnity.c
//  AdTapsy
//
//  Created by Borislav Gizdov on 8/18/14.
//  Copyright (c) 2014 AdTapsy Ltd. All rights reserved.
//  <support@adtapsy.com>
//

#import "AdTapsyUnity.h"
#import "AdTapsy.h"

// Converts C style string to NSString
NSString* CreateNSString (const char* string)
{
    if (string)
        return [NSString stringWithUTF8String: string];
    else
        return [NSString stringWithUTF8String: ""];
}

// Helper method to create C string copy
char* MakeStringCopy (const char* string)
{
    if (string == NULL)
        return NULL;
    
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    return res;
}

NSArray* CreateNSArray(const char** deviceIds) {
    int length = sizeof(deviceIds)/sizeof(*deviceIds);
    NSMutableArray * arr = [[NSMutableArray alloc] initWithCapacity: length];
    for (int i = 0; i < length; i++)
    {
        [arr addObject: [NSString stringWithCString: deviceIds[i] encoding:NSASCIIStringEncoding]];
    }
    
    return arr;
}

extern UIViewController* UnityGetGLViewController();


// Start AdTapsy session for app id
void AdTapsyStartSession(const char* appId) {
    printf("[AdTapsy Unity] Start Session\n");
    [AdTapsy setEngine: @"unity"];
    [AdTapsy startSession: CreateNSString(appId)];
    AdTapsyDelegateImpl * delegate = [[AdTapsyDelegateImpl alloc] init];
    delegate = (__bridge AdTapsyDelegateImpl *) (__bridge_retained void *) delegate;
    [AdTapsy setDelegate: delegate];
}

void AdTapsySetTestMode(BOOL testModeEnabled, const char** deviceIds) {
    printf("[AdTapsy Unity] Set TestMode\n");
    [AdTapsy setTestMode:testModeEnabled andTestDevices: CreateNSArray(deviceIds)];
}

// Show interstitial ad
void AdTapsyShowInterstitial() {
    printf("[AdTapsy Unity] Show Interstitial\n");
    [AdTapsy showInterstitial: UnityGetGLViewController()];
}

// Show rewarded video ad
void AdTapsyShowRewardedVideo() {
    printf("[AdTapsy Unity] Show Rewarded Video\n");
    [AdTapsy showRewardedVideo: UnityGetGLViewController()];
}

bool AdTapsyIsInterstitialReadyToShow() {
    return [AdTapsy isInterstitialReadyToShow];
}

bool AdTapsyIsRewardedVideoReadyToShow() {
    return [AdTapsy isRewardedVideoReadyToShow];
}

void AdTapsySetRewardedVideoAmount(int amount) {
    printf("[AdTapsy Unity] Set Rewarded Video Amount\n");
    [AdTapsy setRewardedVideoAmount:amount];
}

void AdTapsySetRewardedVideoPrePopupEnabled(BOOL toShow) {
    printf("[AdTapsy Unity] Set Rewarded Video Pre Popupe\n");
    [AdTapsy setRewardedVideoPrePopupEnabled:toShow];
}

void AdTapsySetRewardedVideoPostPopupEnabled(BOOL toShow) {
    printf("[AdTapsy Unity] Set Rewarded Video Post Popup\n");
    [AdTapsy setRewardedVideoPostPopupEnabled:toShow];
}


void AdTapsySetUserIdentifier(const char* userId) {
    printf("[AdTapsy Unity] Set User ID\n");
    [AdTapsy setUserIdentifier: CreateNSString(userId)];
}


@implementation AdTapsyDelegateImpl

/**
 * Called when ad is cached and ready to be shown
 */
- (void) adtapsyDidCachedInterstitialAd {
    UnitySendMessage("AdTapsyIOS", "OnAdCached", "0");
}

/**
 * Called when ad shown successfuly
 */
- (void) adtapsyDidShowInterstitialAd {
    UnitySendMessage("AdTapsyIOS", "OnAdShown", "0");
}

/**
 * Called when ad failed to show. All used ad networks has no fill.
 */
- (void) adtapsyDidFailedToShowInterstitialAd {
    UnitySendMessage("AdTapsyIOS", "OnAdFailedToShow", "0");
}

/**
 * Called when user clicked on ad
 */
- (void) adtapsyDidClickedInterstitialAd {
    UnitySendMessage("AdTapsyIOS", "OnAdClicked", "0");
}

/**
 * Called when user skipped ad (clicked X button to close)
 */
- (void) adtapsyDidSkippedInterstitialAd {
    UnitySendMessage("AdTapsyIOS", "OnAdSkipped", "0");
}

/**
 * Called when ad is cached and ready to be shown
 */
- (void) adtapsyDidCachedRewardedVideoAd {
    UnitySendMessage("AdTapsyIOS", "OnAdCached", "1");
}

/**
 * Called when ad shown successfuly
 */
- (void) adtapsyDidShowRewardedVideoAd {
    UnitySendMessage("AdTapsyIOS", "OnAdShown", "1");
}

/**
 * Called when ad failed to show. All used ad networks has no fill.
 */
- (void) adtapsyDidFailedToShowRewardedVideoAd {
    UnitySendMessage("AdTapsyIOS", "OnAdFailedToShow", "1");
}

/**
 * Called when user clicked on ad
 */
- (void) adtapsyDidClickedRewardedVideoAd {
    UnitySendMessage("AdTapsyIOS", "OnAdClicked", "1");
}

/**
 * Called when user skipped ad (clicked X button to close)
 */
- (void) adtapsyDidSkippedRewardedVideoAd {
    UnitySendMessage("AdTapsyIOS", "OnAdSkipped", "1");
}

/**
 * Called when user earned reward for video view
 */
-(void) adtapsyDidEarnedReward:(BOOL) success andAmount:(int) amount {
    char str[10];
    sprintf(str, "%d", amount);
    UnitySendMessage("AdTapsyIOS", "OnRewardEarned", str);
}

@end

