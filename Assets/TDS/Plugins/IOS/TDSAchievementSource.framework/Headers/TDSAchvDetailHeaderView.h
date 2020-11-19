//
//  TDSAchvDetailHeaderView.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/10/27.
//

#import <UIKit/UIKit.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSAchvDetailHeaderView : UIView
@property (nonatomic, copy) void(^cancelBlock)(void);
- (void)setTotalAchievements:(NSInteger)totalCount completeNum:(NSInteger)count;
@end

NS_ASSUME_NONNULL_END
