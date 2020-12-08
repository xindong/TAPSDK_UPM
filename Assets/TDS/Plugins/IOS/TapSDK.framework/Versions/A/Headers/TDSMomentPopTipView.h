//
//  TDSMomentPopTipView.h
//  TapMoment
//
//  Created by JiangJiahao on 2020/8/17.
//  Copyright © 2020 JiangJiahao. All rights reserved.
//

#import <UIKit/UIKit.h>

NS_ASSUME_NONNULL_BEGIN

typedef void(^PopTipConfirmCallback)(void);
typedef void(^PopTipCloseCallback)(void);

@interface TDSMomentPopTipView : UIView

@property (nonatomic) PopTipConfirmCallback confirmCallback;
@property (nonatomic) PopTipCloseCallback cancelCallback;
// 点击背景取消，默认否
@property (nonatomic) BOOL touchBgDismiss;

+ (TDSMomentPopTipView *)createPopTipView:(NSString *)title
                                content:(NSString *)content
                            confirmText:(NSString *)confirmText;


- (void)showInView:(UIView *)targetView;
- (void)dismiss;

@end

NS_ASSUME_NONNULL_END
