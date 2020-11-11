//
//  TDSAchvLevelView.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/10/27.
//

#import <UIKit/UIKit.h>

typedef enum : NSUInteger {
    achvLevelCommonType = 1,        //普通
    achvLevelUncommonType,          //稀有
    achvLevelRarityType,            //珍贵
    achvLevelUltraPreciousType      //极为珍贵
} TDSAchievementLevelType;

NS_ASSUME_NONNULL_BEGIN

@interface TDSAchvLevelView : UIView
@property (nonatomic, assign) TDSAchievementLevelType levelType;
@end

NS_ASSUME_NONNULL_END
