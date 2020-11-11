//
//  TDSAchvCollectionViewCell.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/10/30.
//

#import <UIKit/UIKit.h>
#import "TDSAchievementModel.h"
NS_ASSUME_NONNULL_BEGIN

@interface TDSAchvCollectionViewCell : UICollectionViewCell
@property (nonatomic, strong) UIImageView *bottomView;
- (void)setAchievementModel:(TDSAchievementModel *)model isEven:(BOOL)isEven isTop:(BOOL)isTop isEnd:(BOOL)isEnd;
- (void)addLayoutBottomView:(BOOL)isEven isTop:(BOOL)isTop isEnd:(BOOL)isEnd;

@end

NS_ASSUME_NONNULL_END
