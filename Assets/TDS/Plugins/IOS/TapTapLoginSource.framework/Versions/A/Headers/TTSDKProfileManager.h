//
//  TTSDKProfileManager.h
//  TapTapSDK
//
//  Created by TapTap on 2017/10/26.
//  Copyright © 2017年 易玩. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TTSDKProfile.h"
#import "TTSDKAccessToken.h"

/**
 * @brief 获取用户信息响应回调方法
 *
 * @param profile 获取的用户信息
 * @param error   错误类型
 */
typedef void (^TTSDKManagerProfileManagerRequestHandler)(TTSDKProfile * profile, NSError * error);

/**
 *  @brief TapTap获取用户信息封装类
 *
 *  该类封装了TapTap获取用户信息相关的方法
 */
@interface TTSDKProfileManager : NSObject

/**
 *  @brief 使用指定的登入授权Token获取对应的用户信息
 *
 *  @param token   用户授权
 *  @param handler 回调方法
 */
+ (void) fetchProfileForAccessToken:(TTSDKAccessToken *)token
                            handler:(TTSDKManagerProfileManagerRequestHandler)handler;

/**
 *  @brief 使用当前默认登入授权Token获取对应的用户信息
 *
 *  @param handler 回调方法
 */
+ (void) fetchProfileByCurrentAccessToken:(TTSDKManagerProfileManagerRequestHandler)handler;

@end
