//
//  TapSDK.h
//  TapSDK
//
//  Created by Bottle K on 2020/12/24.
//

#import <Foundation/Foundation.h>

//! Project version number for TapSDK.
FOUNDATION_EXPORT double TapSDKVersionNumber;

//! Project version string for TapSDK.
FOUNDATION_EXPORT const unsigned char TapSDKVersionString[];

#define Tap_SDK_VERSION @"0.1.27"


#import <TapSDK/TDSInitializer.h>
#import <TapSDK/TDSErrorDelegate.h>
#import <TapSDK/TDSErrorModel.h>
#import <TapSDK/TDSConfig.h>

#if __has_include(<TapDB/TapDB.h>)
#import <TapDB/TapDB.h>
#import <TDSMoment/TDSMomentSdk.h>
#import <TapLogin/TapLoginHelper.h>
#import <TapLogin/IscTapLoginService.h>
#else
#import "TapDB.h"
#import "TDSMomentSdk.h"
#import "TapLoginHelper.h"
#import "IscTapLoginService.h"
#endif
