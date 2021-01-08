//
//  TapSDK.h
//  TapSDK
//
//  Created by Bottle K on 2020/12/24.
//

#import <Foundation/Foundation.h>
#import <TDSCommon/TDSCommonMacros.h>

#if isRND

#define TAP_IS_RND true

#else

#define TAP_IS_RND false

#endif

//! Project version number for TapSDK.
FOUNDATION_EXPORT double TapSDKVersionNumber;

//! Project version string for TapSDK.
FOUNDATION_EXPORT const unsigned char TapSDKVersionString[];

#define Tap_SDK_VERSION @"0.1.27"


#import <TapSDK/TDSInitializer.h>
#import <TapSDK/TDSErrorDelegate.h>
#import <TapSDK/TDSErrorModel.h>
#import <TapSDK/TDSConfig.h>
