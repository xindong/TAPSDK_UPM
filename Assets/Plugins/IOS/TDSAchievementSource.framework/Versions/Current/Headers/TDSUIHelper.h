//
//  TDSUIHelper.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/8/26.
//  Copyright © 2020 taptap. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@interface TDSUIHelper : NSObject

@end

@interface TDSUIHelper (UIGraphic)
/// 获取一像素的大小
+ (CGFloat)pixelOne;

/// 判断size是否超出范围
+ (void)inspectContextSize:(CGSize)size;

/// context是否合法
+ (void)inspectContextIfInvalidatedInDebugMode:(CGContextRef _Nonnull)context;

+ (BOOL)inspectContextIfInvalidatedInReleaseMode:(CGContextRef _Nonnull)context;

@end

@interface TDSUIHelper (Device)

+ (BOOL)isIPad;
+ (BOOL)isIPadPro;
+ (BOOL)isIPod;
+ (BOOL)isIPhone;
+ (BOOL)isSimulator;

+ (BOOL)is61InchScreen;
+ (BOOL)is58InchScreen;
+ (BOOL)is55InchScreen;
+ (BOOL)is47InchScreen;
+ (BOOL)is40InchScreen;
+ (BOOL)is35InchScreen;

+ (CGSize)screenSizeFor61Inch;
+ (CGSize)screenSizeFor58Inch;
+ (CGSize)screenSizeFor55Inch;
+ (CGSize)screenSizeFor47Inch;
+ (CGSize)screenSizeFor40Inch;
+ (CGSize)screenSizeFor35Inch;

// 用于获取 iPhoneX 安全区域的 insets
+ (UIEdgeInsets)safeAreaInsetsForIPhoneX;

// 通过 safeArea 判断是否是 iPhone X
+ (BOOL)isIPhoneX;
// statusBar 高度，无论 statusBar 是否隐藏都会返回高度
+ (CGFloat)statusBarHeight;
// 导航栏和状态栏的总高度，无论 statusBar 是否隐藏都会返回高度
+ (CGFloat)statusAndNavBarHeight;
// iPhone X 系列机型返回 34，否则返回 0
+ (CGFloat)safeAreaBottomHeight;

@end

