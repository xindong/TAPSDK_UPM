//
//  TDSAchievementDelegate.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/9/21.
//  Copyright © 2020 taptap. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TDSAchievementModel.h"

NS_ASSUME_NONNULL_BEGIN

@protocol TDSAchievementDelegate <NSObject>

/*初始化成功*/
- (void)onAchievementSDKInitSuccess;

/*初始化失败*/
- (void)onAchievementSDKInitFail:(nullable NSError *)error;

/*成就状态变化*/
- (void)onAchievementStatusUpdate:(nullable TDSAchievementModel *)achievement
                          failure:(nullable NSError *)error;

@end

NS_ASSUME_NONNULL_END
