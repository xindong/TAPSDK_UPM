//
//  TTSDKRequestManagerDelegate.h
//  TapTapSDK
//
//  Created by 任龙 on 2017/10/26.
//  Copyright © 2017年 易玩. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TTSDKLoginManager.h"
#import "TTSDKAccessToken.h"

@interface TTSDKLoginManagerProxy : NSObject

+ (instancetype)sharedInstance;

- (void)addLoginManagerRequestHandler:(TTSDKLoginManagerRequestHandler)handler
                               forKey:(NSString *)key;

- (void)handleURL:(NSURL *)url;

- (TTSDKAccessToken *)currentAccessToken;

- (void)clearAccessToken;

- (void)createToken:(NSString *)code verifier:(NSString *)verifier handler:(void (^)(TTSDKAccessToken *, NSError *))handler;

@end
