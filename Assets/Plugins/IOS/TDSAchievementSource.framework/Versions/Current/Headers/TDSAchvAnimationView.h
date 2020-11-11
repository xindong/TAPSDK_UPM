//
//  TDSAchvAnimationView.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/10/30.
//

#import <UIKit/UIKit.h>
#import <TDSCommonSource/TDSWebImageView.h>
NS_ASSUME_NONNULL_BEGIN

@interface TDSAchvAnimationView : UIView
@property (nonatomic, strong) UIView *bottomView;
@property (nonatomic, strong) TDSWebImageView *iconImgView;
@property (nonatomic, strong) UILabel *titleLabel;
@end

NS_ASSUME_NONNULL_END
