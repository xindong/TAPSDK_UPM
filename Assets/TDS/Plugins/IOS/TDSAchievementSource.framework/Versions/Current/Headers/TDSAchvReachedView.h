//
//  TDSAchvReachedView.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/10/26.
//

#import <UIKit/UIKit.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSAchvReachedView : UIView

- (instancetype)initWithFrame:(CGRect)frame isHorizontal:(BOOL)isHorizontal;
- (void)setTotalAchievememt:(NSInteger)total completeNum:(NSInteger)completeNum;

@end

NS_ASSUME_NONNULL_END
