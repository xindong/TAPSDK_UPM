//
//  TDSMomentUserCenterViewController.h
//  TapMoment
//
//  Created by ritchie on 2020/9/1.
//  Copyright © 2020 JiangJiahao. All rights reserved.
//

//#import "TapWebViewController.h"
#import "TDSMomentWebViewController.h"
#ifdef __has_include
#if __has_include(<TapTapSDK/TapTapSDK.h>)
#import <TapTapLoginSource/TTSDKAccessToken.h>
#endif
#endif
NS_ASSUME_NONNULL_BEGIN

@interface TDSMomentUserCenterViewController : TDSMomentWebViewController
#ifdef __has_include
#if __has_include(<TapTapSDK/TapTapSDK.h>)
- (instancetype)initWithAccessToken:(TTSDKAccessToken *)accessToken
                             config:(TDSMomentConfig *)config
                             userId:(NSString *)userId
                            isTapId:(BOOL)isTapId;
#endif
#endif

@end

NS_ASSUME_NONNULL_END
