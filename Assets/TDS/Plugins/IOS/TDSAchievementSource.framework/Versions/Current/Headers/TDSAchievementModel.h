//
//  TDSAchievementModel.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/9/14.
//  Copyright © 2020 taptap. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN
@class TDSAchievementStatus;

@interface TDSAchievementModel : NSObject<NSCoding>
/**
 成就ID
 */
@property (nonatomic, copy, readonly) NSString *achievementId;
/**
 展示ID
 */
@property (nonatomic, copy, readonly) NSString *displayId;
/**
 游戏ID
 */
@property (nonatomic, copy, readonly) NSString *tapAppId;
/**
 成就图片
 */
@property (nonatomic, copy, readonly) NSString *achieveIcon;
/**
 成就名称
 */
@property (nonatomic, copy) NSString *title;
/**
 成就描述
 */
@property (nonatomic, copy, readonly) NSString *subTitle;
/**
 隐藏成就 0：隐藏  1：显示
 */
@property (nonatomic, assign, readonly) NSNumber *visible;
/**
 顺序是否一致
 */
@property (nonatomic, assign, readonly) NSInteger showOrder;
/**
 完成成就总的步数
 */
@property (nonatomic, assign, readonly) NSNumber *step;
/**
 创建时间
 */
@property (nonatomic, assign) double createTime;

//用户数据
/**
 是否到达成就 1：达到成就  0：未达到成就
*/
@property (nonatomic, assign) NSInteger fullReached;
/**
 成就达到时间
 */
@property (nonatomic, assign) double reachedTime;
/**
 当前完成步数
*/
@property (nonatomic, assign) NSInteger reachedStep;
/**
 等级状态
*/
@property (nonatomic, strong) TDSAchievementStatus *stats;
/**
 是否全成就
*/
@property (nonatomic, assign) NSInteger type;

/**
 隐藏成就
 */
- (BOOL)isVisible;
/**
 成就达成
 */
- (BOOL)isFullReached;
/**
 全成就
 */
- (BOOL)isFullAchievement;

@end

@interface TDSAchievementStatus : NSObject<NSCoding>
/**
 等级
*/
@property (nonatomic, assign) NSInteger level;
/**
 百分比
*/
@property (nonatomic, assign) CGFloat rarity;
@end

NS_ASSUME_NONNULL_END
