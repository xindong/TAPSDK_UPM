//
//  TDSCacheDataManager.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/9/14.
//  Copyright © 2020 taptap. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TDSAchievementModel.h"

NS_ASSUME_NONNULL_BEGIN

@interface TDSCacheDataManager : NSObject

+ (instancetype)sharedManager;

/**
 缓存成就列表数据
*/
- (void)cacheAchievementListData:(NSArray<TDSAchievementModel *> *)object;
/**
 获取成就列表缓存数据
*/
- (NSArray<TDSAchievementModel *> *)getAchievementListData;

/**
 缓存用户成就列表数据
 */
- (void)cacheUserAchievementData:(NSArray<TDSAchievementModel *> *)object;

/**
 获取用户成就缓存数据
 */
- (NSArray<TDSAchievementModel *> *)getUserAchievementCacheData;

/**
 删除用户缓存数据
 */
- (void)deleteUserCacheData;

@end

NS_ASSUME_NONNULL_END
