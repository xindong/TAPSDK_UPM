//
//  TDSMomentAlertView.h
//  TapMoment
//
//  Created by JiangJiahao on 2020/8/12.
//  Copyright © 2020 JiangJiahao. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

NS_ASSUME_NONNULL_BEGIN

typedef void(^ConfirmCallback)(void);
typedef void(^CancelCallback)(void);

@interface TDSMomentAlertView : UIView

@property (nonatomic) NSTextAlignment contentAlignment;
@property (nonatomic) ConfirmCallback confirmCallback;
@property (nonatomic) CancelCallback cancelCallback;
// 点击背景取消，默认否
@property (nonatomic) BOOL touchBgDismiss;

+ (TDSMomentAlertView *)createAlertView:(NSString *)title
                                content:(NSString *)content
                            confirmText:(NSString *)confirmText
                             cancelText:(NSString *)cancelText;


- (void)showInView:(UIView *)targetView;
- (void)dismiss;

@end

NS_ASSUME_NONNULL_END
