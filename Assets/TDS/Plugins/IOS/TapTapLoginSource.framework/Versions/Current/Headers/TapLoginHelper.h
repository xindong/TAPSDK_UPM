//
//  TapLoginHelper.h
//  TapTapLoginSource
//
//  Created by Bottle K on 2020/12/2.
//

#import <Foundation/Foundation.h>
#import "TTSDKLoginManager.h"
#import "TTSDKConfig.h"
#import "TTSDKAccessToken.h"
#import "TTSDKProfile.h"
#import "TTSDKLoginResult.h"

NS_ASSUME_NONNULL_BEGIN

@interface TapLoginHelper : NSObject
+ (void)initWithClientID:(NSString *)clientID;

+ (void)initWithClientID:(NSString *)clientID config:(TTSDKConfig *_Nullable)config;

+ (void)changeConfig:(TTSDKConfig *_Nullable)config;

+ (void)registerLoginCallback:(TTSDKLoginManagerRequestHandler)callback;

+ (void)startTapLogin:(NSArray *)permissions;

+ (TTSDKAccessToken *)currentAccessToken;

+ (TTSDKProfile *)currentProfile;

+ (void)fetchProfileForCurrentAccessToken:(void (^)(TTSDKProfile *profile, NSError *error))callback;

+ (void)logout;
@end

NS_ASSUME_NONNULL_END
