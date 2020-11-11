//
//  TDSAchvStyleView.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/10/28.
//

#import <UIKit/UIKit.h>
#import "TDSAchievementModel.h"
#import <TDSCommonSource/TDSWebImageView.h>
NS_ASSUME_NONNULL_BEGIN

@interface TDSAchvStyleView : UIView
@property (nonatomic, assign) BOOL isDetail;
@property (nonatomic, strong) TDSAchievementModel *model;
@end

NS_ASSUME_NONNULL_END
