//
//  TapTime.h
//  TapTapSDK
//
//  Created by Bottle K on 2020/10/9.
//  Copyright © 2020 易玩. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TapTime : NSObject

+ (instancetype)sharedInstance;

- (void)checkTime:(NSInteger)serverTime;

- (NSInteger)getCurrentTime;
@end

NS_ASSUME_NONNULL_END
