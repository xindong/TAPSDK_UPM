//
//  TTSDKTapDBHelper.h
//  TapTapSDK
//
//  Created by JiangJiahao on 2020/8/5.
//  Copyright © 2020 易玩. All rights reserved.
//  动态调用tapdb sdk

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TTSDKTapDBHelper : NSObject
/**
 * 初始化，尽早调用
 * clientId: apTap登录sdk后台页面 client id
 * channel: 分包渠道名称，可为空
 * gameVersion: 游戏版本，可为空，为空时，自动获取游戏安装包的版本（Xcode配置中的Version）
 */
+ (void)onStartWithClientId:(NSString *)clientId channel:(nullable NSString *)channel version:(nullable NSString *)gameVersion;

/// 记录一个用户（不是游戏角色！！！！），需要保证唯一性
/// @param userId 用户ID。不同用户需要保证ID的唯一性
/// @param openId 通过第三方登录获取到的openId
/// @param loginType 登录方式
+ (void)setUser:(NSString *)userId openId:(NSString *)openId loginType:(NSString *)loginType;

@end

NS_ASSUME_NONNULL_END
