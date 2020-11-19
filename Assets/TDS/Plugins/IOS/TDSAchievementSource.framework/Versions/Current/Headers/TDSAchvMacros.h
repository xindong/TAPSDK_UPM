//
//  TDSAchvMacros.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/11/4.
//

#import "TDSUIHelper.h"
#import "TDSImagaTool.h"
#import "TDSLanguageTool.h"
#import <TDSCommonSource/NSBundle+TDSLocalizable.h>

///-------------------------
/// @name 变量-屏幕尺寸相关
///-------------------------
#ifndef SCREEN_WIDTH
#define SCREEN_WIDTH  ([UIScreen mainScreen].bounds.size.width)
#endif

#ifndef SCREEN_HEIGHT
#define SCREEN_HEIGHT ([UIScreen mainScreen].bounds.size.height)
#endif
///-------------------------
/// @name 变量-颜色相关
///-------------------------
#define RGBCOLOR(r, g, b)               [UIColor colorWithRed : (r) / 255.0f green : (g) / 255.0f blue : (b) / 255.0f alpha : 1]
#define RGBACOLOR(r, g, b, a)           [UIColor colorWithRed : (r) / 255.0f green : (g) / 255.0f blue : (b) / 255.0f alpha : (a)]

// sample: Designer - #FF0000, We - HEXCOLOR(0xFF0000)
#define HEXCOLOR(hexValue)              [UIColor colorWithRed : ((CGFloat)((hexValue & 0xFF0000) >> 16)) / 255.0 green : ((CGFloat)((hexValue & 0xFF00) >> 8)) / 255.0 blue : ((CGFloat)(hexValue & 0xFF)) / 255.0 alpha : 1.0]

#define HEXACOLOR(hexValue, alphaValue) [UIColor colorWithRed : ((CGFloat)((hexValue & 0xFF0000) >> 16)) / 255.0 green : ((CGFloat)((hexValue & 0xFF00) >> 8)) / 255.0 blue : ((CGFloat)(hexValue & 0xFF)) / 255.0 alpha : (alphaValue)]


// 通过 safeArea 判断是否是 iPhone X系列
#define TDSUI_IS_IPHONE_X                       [TDSUIHelper isIPhoneX]
// statusBar 高度，无论 statusBar 是否隐藏都会返回高度
#define TDSUI_STATUS_BAR_HEIGHT                 [TDSUIHelper statusBarHeight]
// 导航栏和状态栏的总高度
#define TDSUI_NAV_STATUS_BAR_HEIGHT             [TDSUIHelper statusAndNavBarHeight]
// iPhone X 系列机型返回 34，否则返回 0
#define TDSUI_SAFE_AREA_BOTTOM_HEIGHT           [TDSUIHelper safeAreaBottomHeight]

// 是否横竖屏
// 用户界面横屏了才会返回YES
#define TDSUI_IS_LANDSCAPE                      UIInterfaceOrientationIsLandscape([[UIApplication sharedApplication] statusBarOrientation])
// 无论支不支持横屏，只要设备横屏了，就会返回YES
#define TDSUI_IS_DEVICE_LANDSCAPE               UIDeviceOrientationIsLandscape([[UIDevice currentDevice] orientation])

// 屏幕宽度，会根据横竖屏的变化而变化
#define TDSUI_SCREEN_WIDTH                      [[UIScreen mainScreen] bounds].size.width

// 屏幕宽度，跟横竖屏无关
#define TDSUI_DEVICE_WIDTH                      (TDSUI_IS_LANDSCAPE ? [[UIScreen mainScreen] bounds].size.height : [[UIScreen mainScreen] bounds].size.width)

// 屏幕高度，会根据横竖屏的变化而变化
#define TDSUI_SCREEN_HEIGHT                     [[UIScreen mainScreen] bounds].size.height

// 屏幕高度，跟横竖屏无关
#define TDSUI_DEVICE_HEIGHT                     (TDSUI_IS_LANDSCAPE ? [[UIScreen mainScreen] bounds].size.width : [[UIScreen mainScreen] bounds].size.height)

// 获取一个像素
#define TDSUI_PixelOne                          [TDSUIHelper pixelOne]

//设备屏幕尺寸
// iPhoneXS MAX,XR
#define TDSUI_IS_61_65INCH_SCREEN               [TDSUIHelper is61InchScreen]
// iPhoneX,XS
#define TDSUI_IS_58INCH_SCREEN                  [TDSUIHelper is58InchScreen]
// iPhone6/7/8 Plus
#define TDSUI_IS_55INCH_PRO_SCREEN              [TDSUIHelper is55InchScreen]
// iPhone6/7/8
#define TDSUI_IS_47INCH_SCREEN                  [TDSUIHelper is47InchScreen]
// iPhone5/5s/SE
#define TDSUI_IS_40INCH_SCREEN                  [TDSUIHelper is40InchScreen]
// iPhone4/4s
#define TDSUI_IS_35INCH_SCREEN                  [TDSUIHelper is35InchScreen]

#define TDS_LocalizationLanguage(key) [TDSLanguageTool tds_localizedStringForKey:key]


