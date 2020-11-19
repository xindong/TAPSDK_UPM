//
//  TDSAchievementManager.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/9/15.
//  Copyright © 2020 taptap. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TDSAchievementDelegate.h"
#import "TDSAchievement.h"
NS_ASSUME_NONNULL_BEGIN

@interface TDSAchievementManager : NSObject

@property (nonatomic, weak) id<TDSAchievementDelegate> delegate;

+ (instancetype)shareInstance;

/**
 初始化sdk
 */
- (void)initAchievement;

/**
 获取所有成就数据
 */
- (void)getAllAchievementList:(TTAchievementRequestHandler)callBack isInitial:(BOOL)isInitial;

/**
 获取当前用户成就列表数据
 */
- (void)getCurrentUserAchievementList:(nullable TTAchievementRequestHandler)callBack isInitial:(BOOL)isInitial;

/**
 达成成就 返回成就内容
 */
- (void)getReachAchievementContentWithDisplayId:(NSString *)displayId;

/**
 记录步长成就
 */
- (void)recordUserAchievementWithDisplayId:(NSString *)displayId
                                     steps:(NSInteger)steps
                                 isAllStep:(BOOL)isAllStep;

@end

NS_ASSUME_NONNULL_END
