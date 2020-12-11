//
//  TapSDK.h
//  TapSDK
//
//  Created by Insomnia on 2020/12/1.
//

#import <Foundation/Foundation.h>

FOUNDATION_EXPORT double TapSDKVersionNumber;
FOUNDATION_EXPORT const unsigned char TapSDKVersionString[];


#if __has_include(<TapSDK/TapSDK.h>)

#import <TapSDK/TDSInitializer.h>
#import <TapSDK/TDSConfig.h>
#import <TapSDK/TDSErrorDelegate.h>

#else

#import "TDSInitializer.h"
#import "TDSConfig.h"
#import "TDSErrorDelegate.h"

#endif
