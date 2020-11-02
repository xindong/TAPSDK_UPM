//
//  TDSAchievementModel+achievement.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/9/18.
//  Copyright © 2020 taptap. All rights reserved.
//

NS_ASSUME_NONNULL_BEGIN

@interface TDSAchievementModel ()

@property (nonatomic, assign) BOOL isChange;

+ (instancetype)achievementModelWithDictionary:(NSDictionary *)dict;
@end

NS_ASSUME_NONNULL_END
