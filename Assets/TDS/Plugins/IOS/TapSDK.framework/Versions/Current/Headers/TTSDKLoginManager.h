//
//  TTSDKLoginManager.h
//  TapTapSDK
//
//  Created by TapTap on 2017/10/17.
//  Copyright © 2017年 易玩. All rights reserved.
//

#import <Foundation/Foundation.h>

@class TTSDKLoginResult;

/**
 * @brief 登录响应回调方法
 *
 * @param result 响应结果
 * @param error  错误类型（自定义错误会在error_msg中提供）
 */
typedef void (^TTSDKLoginManagerRequestHandler)(TTSDKLoginResult *result, NSError *error);

/**
 *  @brief TapTap登入封装类
 *
 *  该类封装了TapTap登入和登出相关的方法
 */
@interface TTSDKLoginManager : NSObject

/**
 *  @brief 登入方法
 *
 *  @param permissions 登入时携带的授权类型（详见开发文档）
 *  @param handler     回调方法
 */
- (void)logInWithReadPermissions:(NSArray *)permissions handler: (TTSDKLoginManagerRequestHandler)handler;

/**
 *  @brief 登出方法
 */
- (void)logout;

@end
