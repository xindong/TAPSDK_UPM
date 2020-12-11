//
//  TapTapSDKManager.h
//  TapTapSDK
//
//  Created by 任龙 on 2017/10/17.
//  Copyright © 2017年 易玩. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TTSDKConfig.h"

@interface TapTapSDKManager : NSObject

/// TapTap开发者ID
@property (nonatomic, strong) NSString *clientID;

/// 初始配置
@property (nonatomic, strong) TTSDKConfig *config;

+ (instancetype)sharedInstance;

- (NSString *)getRegionHost;

- (NSString *)getScheme;
@end
