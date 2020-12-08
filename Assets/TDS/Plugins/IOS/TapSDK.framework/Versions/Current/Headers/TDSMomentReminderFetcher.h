//
//  TDSMomentReminderFetcher.h
//  TapMoment
//
//  Created by ritchie on 2020/7/29.
//  Copyright © 2020 JiangJiahao. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TDSMomentAccessToken.h"


NS_ASSUME_NONNULL_BEGIN
typedef void (^TDSMomentReminderFetcherCallback)(NSString *msgCount, int code);
@interface TDSMomentReminderFetcher : NSObject

@property (nonatomic, strong) TDSMomentAccessToken *accessToken;

+ (TDSMomentReminderFetcher *)shared;

- (void)startWithCallback:(TDSMomentReminderFetcherCallback)callback;
- (void)stop;


@end

NS_ASSUME_NONNULL_END
