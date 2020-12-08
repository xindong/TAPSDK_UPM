//
//  TTSDKApplicationDelegate.h
//  TapTapSDK
//
//  Created by TapTap on 2017/10/18.
//  Copyright © 2017年 易玩. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Foundation/Foundation.h>

/**
 *  @brief Application代理
 */
@interface TTSDKApplicationDelegate : NSObject

+ (instancetype)sharedInstance;

/**
 *  @brief openURL方法的调用
 *
 *  请在AppDelegate中调用此方法（详见开发文档）
 */
- (BOOL)handleTapTapOpenURL:(NSURL *)url;

@end
