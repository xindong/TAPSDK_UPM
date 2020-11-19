//
//  TDSMomentReminderFetcher.h
//  TapMoment
//
//  Created by ritchie on 2020/7/29.
//  Copyright © 2020 JiangJiahao. All rights reserved.
//

#import <Foundation/Foundation.h>
#ifdef __has_include
#if __has_include(<TapTapSDK/TapTapSDK.h>)
#import <TapTapSDK/TapTapSDK.h>
#endif
#endif

NS_ASSUME_NONNULL_BEGIN
typedef void (^TDSMomentReminderFetcherCallback)(NSString *msgCount, int code);
@interface TDSMomentReminderFetcher : NSObject

#ifdef __has_include
#if __has_include(<TapTapSDK/TapTapSDK.h>)
@property (nonatomic, strong) TTSDKAccessToken *accessToken;
#endif
#endif

+ (TDSMomentReminderFetcher *)shared;

- (void)startWithCallback:(TDSMomentReminderFetcherCallback)callback;
- (void)stop;


@end

NS_ASSUME_NONNULL_END
