//
//  UIView+TDSExtension.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/10/27.
//

#import <UIKit/UIKit.h>

NS_ASSUME_NONNULL_BEGIN
typedef void(^FinishBlock)(void);

typedef NS_ENUM(NSInteger, AlertShowStyle) {
    AlertShowStyleFromTop = 0,
    AlertShowStyleFromBottom,
    AlertShowStyleFromCenter,
};

@interface UIView (TDSExtension)
- (void)tds_addAlertAnimationWithStyle:(AlertShowStyle)styleType withFinishBlock:(FinishBlock _Nullable)block;

- (void)tds_drawRoundedCorners:(UIRectCorner)corner cornerRadii:(CGSize)size;

- (void)tds_showScaleAnimation:(id)delegate
            fromScaleValue:(CGFloat)fromValue
              toScaleValue:(CGFloat)toValue
                    repeat:(CGFloat)repeat
                  duration:(CGFloat)duration
                       key:(nullable NSString *)key;

- (void)tds_showOpacityAnimation:(CGFloat)fromAlpha
                     toAlpha:(CGFloat)toAlpha
                      repeat:(CGFloat)repeat
                    duration:(CGFloat)duration;

- (void)tds_clearAnimation;

@property (nonatomic, assign) CGFloat centerX;

@property (nonatomic, assign) CGFloat centerY;

@property (nonatomic, assign) CGFloat y;

@property (nonatomic, assign) CGFloat x;

@property (nonatomic, assign) CGFloat height;

@property (nonatomic, assign) CGFloat width;

@property (nonatomic, assign) CGPoint origin;

@property (nonatomic, assign) CGSize size;

@end

NS_ASSUME_NONNULL_END
