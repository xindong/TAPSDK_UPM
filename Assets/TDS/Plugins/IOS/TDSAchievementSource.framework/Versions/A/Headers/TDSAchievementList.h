//
//  TDSAchievementList.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/9/14.
//  Copyright © 2020 taptap. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TDSAchievementModel.h"

NS_ASSUME_NONNULL_BEGIN

@interface TDSAchievementList : NSObject
/**
 成就列表
 */
@property (nonatomic, strong) NSArray<TDSAchievementModel *> *list;
@property (nonatomic, strong) NSDictionary *user;


-(void)setUserID;

@end

NS_ASSUME_NONNULL_END
