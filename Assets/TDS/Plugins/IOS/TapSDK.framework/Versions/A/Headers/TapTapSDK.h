//
//  TapTapSDK.h
//  TapTapSDK
//
//  Created by TapTap on 2017/10/17.
//  Copyright © 2017年 易玩. All rights reserved.
//

#import <Foundation/Foundation.h>

#define SDK_VERSION @"2.5.3"  //!< SDK Version

#import "TTSDKApplicationDelegate.h"
#import "TTSDKLoginResult.h"
#import "TTSDKAccessToken.h"
#import "TTSDKLoginManager.h"
#import "TTSDKProfile.h"
#import "TTSDKProfileManager.h"
#import "TTSDKConfig.h"

@interface TapTapSDK : NSObject

/**
 *  @brief SDK初始化方法
 *
 *  请尽量在程序启动的时候初始化
 *  @param clientID TapTap开发者ID
 */
+ (void)sdkInitialize:(NSString *_Nonnull)clientID;

/**
 *  @brief SDK初始化方法
 *
 *  请尽量在程序启动的时候初始化
 *  @param clientID TapTap开发者ID
 *  @param config 初始配置
 */
+ (void)sdkInitialize:(NSString *_Nonnull)clientID config:(TTSDKConfig *_Nullable)config;

/// 更改Config参数
/// @param config 配置参数
+ (void)changeConfig:(TTSDKConfig *_Nullable)config;
/**
 *  @brief 判断当前的TapTap版本是否支持该SDK调用
 *
 *  @return 支持返回YES，不支持返回NO
 */
+ (BOOL)isTapTapClientSupport;
/**
 *  @brief 判断当前的TapTap Global版本是否支持该SDK调用
 *
 *  @return 支持返回YES，不支持返回NO
 */
+ (BOOL)isTapTapGlobalClientSupport;

@end
