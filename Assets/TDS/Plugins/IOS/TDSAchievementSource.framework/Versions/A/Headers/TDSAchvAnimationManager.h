//
//  TDSAchvAnimationManager.h
//  TDSAchievementSource
//
//  Created by TapTap-David on 2020/11/6.
//

#import <Foundation/Foundation.h>
#import "TDSAchievementModel.h"

NS_ASSUME_NONNULL_BEGIN

@interface TDSAchvAnimationManager : NSObject
+ (instancetype)sharedManager;
- (void)showAnimationWithModel:(TDSAchievementModel *)model;
@end

NS_ASSUME_NONNULL_END
