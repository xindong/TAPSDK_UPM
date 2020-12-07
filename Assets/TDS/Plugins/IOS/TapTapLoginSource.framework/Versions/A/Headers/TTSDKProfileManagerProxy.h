//
//  TTSDKProfileManagerDelegate.h
//  TapTapSDK
//
//  Created by 任龙 on 2017/10/27.
//  Copyright © 2017年 易玩. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TTSDKProfile.h"
#import "TTSDKAccessToken.h"
#import "TTSDKProfileManager.h"

@interface TTSDKProfileManagerProxy : NSObject

+ (instancetype)sharedInstance;

- (void)clearProfile;

- (void)fetchProfileForAccessToken:(TTSDKAccessToken *)token
                           handler:(TTSDKManagerProfileManagerRequestHandler)handler;

@property (nonatomic, retain) TTSDKProfile *currentProfile;

@end
