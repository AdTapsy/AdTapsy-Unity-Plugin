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

bool AdTapsyIsAdReadyToShow() {
    return [AdTapsy isAdReadyToShow];
}


@implementation AdTapsyDelegateImpl

/**
 * Called when ad is cached and ready to be shown
 */
- (void) adtapsyDidCachedAd {
    UnitySendMessage("AdTapsyIOS", "OnAdCached", "");
}

/**
 * Called when ad shown successfuly
 */
- (void) adtapsyDidShowAd {
    UnitySendMessage("AdTapsyIOS", "OnAdShown", "");
}

/**
 * Called when ad failed to show. All used ad networks has no fill.
 */
- (void) adtapsyDidFailedToShowAd {
    UnitySendMessage("AdTapsyIOS", "OnAdFailedToShow", "");
}

/**
 * Called when user clicked on ad
 */
- (void) adtapsyDidClickedAd {
    UnitySendMessage("AdTapsyIOS", "OnAdClicked", "");
}

/**
 * Called when user skipped ad (clicked X button to close)
 */
- (void) adtapsyDidSkippedAd {
    UnitySendMessage("AdTapsyIOS", "OnAdSkipped", "");
}
@end

