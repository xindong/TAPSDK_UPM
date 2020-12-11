//
//  TDSMomentNetErrorHUD.h
//  TapMoment
//
//  Created by ritchie on 2020/7/28.
//  Copyright © 2020 JiangJiahao. All rights reserved.
//

#import <UIKit/UIKit.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSMomentNetErrorHUD : UIView
@property (nonatomic, copy) void(^reloadHandle)(TDSMomentNetErrorHUD *hud) ;

@property (nonatomic, assign) BOOL hidden NS_UNAVAILABLE; 

- (void)showHUDBG;

// 线程安全
- (void)hideHUD;
- (void)showHUD;

@end

NS_ASSUME_NONNULL_END
