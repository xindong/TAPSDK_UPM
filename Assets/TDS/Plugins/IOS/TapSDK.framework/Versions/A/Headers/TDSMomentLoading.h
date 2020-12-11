//
//  TDSMomentLoading.h
//  TapMoment
//
//  Created by ritchie on 2020/10/21.
//  Copyright © 2020 JiangJiahao. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSMomentLoading : NSObject
#pragma mark - UI

/// 显示
/// @param duration `duration ` > 0 == 无限时长
+ (void)showWithDuration:(NSInteger)duration;
+ (void)hide;
@end

NS_ASSUME_NONNULL_END
