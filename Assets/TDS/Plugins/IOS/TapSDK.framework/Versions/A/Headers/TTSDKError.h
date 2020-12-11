//
//  TTSDKLoginError.h
//  TapTapSDK
//
//  Created by 任龙 on 2017/10/26.
//  Copyright © 2017年 易玩. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface TTSDKError : NSError

+ (instancetype)errorWithMessage:(NSString *)errorMsg code:(NSInteger)code;

@end
