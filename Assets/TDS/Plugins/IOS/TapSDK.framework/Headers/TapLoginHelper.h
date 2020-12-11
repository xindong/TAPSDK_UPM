//
//  TapLoginHelper.h
//  TapTapLoginSource
//
//  Created by Bottle K on 2020/12/2.
//

#import <Foundation/Foundation.h>
#import "TTSDKConfig.h"
#import "TTSDKAccessToken.h"
#import "TTSDKProfile.h"
#import "TTSDKLoginResult.h"

NS_ASSUME_NONNULL_BEGIN

typedef void (^TapLoginResultCallback)(TTSDKLoginResult *result, NSError *error);

@interface TapLoginHelper : NSObject
+ (void)initWithClientID:(NSString *)clientID;

+ (void)initWithClientID:(NSString *)clientID config:(TTSDKConfig *_Nullable)config;

+ (void)changeTapLoginConfig:(TTSDKConfig *_Nullable)config;

+ (void)addLoginResultCallback:(TapLoginResultCallback)callback;

+ (void)removeLoginResultCallback:(TapLoginResultCallback)callback;

+ (void)startTapLogin:(NSArray *)permissions;

+ (TTSDKAccessToken *)currentAccessToken;

+ (TTSDKProfile *)currentProfile;

+ (void)fetchProfileForCurrentAccessToken:(void (^)(TTSDKProfile *profile, NSError *error))callback;

+ (void)logout;

+ (BOOL)isTapTapClientSupport;

+ (BOOL)isTapTapGlobalClientSupport;
@end

NS_ASSUME_NONNULL_END
