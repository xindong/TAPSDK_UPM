//
//  TDSMomentPostViewController.h
//  TapMoment
//
//  Created by ritchie on 2020/7/20.
//  Copyright © 2020 TapTap. All rights reserved.
//

#import "TDSMomentWebViewController.h"
#import "TDSMomentSdk.h"
#ifdef __has_include
#if __has_include(<TapTapSDK/TapTapSDK.h>)
#import <TapTapSDK/TapTapSDK.h>
#endif
#endif

NS_ASSUME_NONNULL_BEGIN

@class TDSPostMomentData;

@interface TDSMomentPostViewController : TDSMomentWebViewController


- (instancetype)init NS_UNAVAILABLE;
- (instancetype)new NS_UNAVAILABLE;

#ifdef __has_include
#if __has_include(<TapTapSDK/TapTapSDK.h>)
- (instancetype)initWithContent:(TDSPostMomentData *)content
                    accessToken:(TTSDKAccessToken *)accessToken
                         config:(TDSMomentConfig *)config;
#endif
#endif

@end

NS_ASSUME_NONNULL_END
