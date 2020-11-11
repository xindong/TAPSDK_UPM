//
//  TDSAchvAlertView.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/10/27.
//

#import <UIKit/UIKit.h>
#import "TDSAchievementModel.h"
NS_ASSUME_NONNULL_BEGIN

@interface TDSAchvAlertView : UIView
- (instancetype)initWithFrame:(CGRect)frame isHorizontal:(BOOL)isHorizontal;
- (void)showAnimationWithModel:(TDSAchievementModel *)model totalNum:(NSInteger)totalNum completeNum:(NSInteger)count;

@property (nonatomic, assign) CGFloat wordSpace;
@end

NS_ASSUME_NONNULL_END
