//
//  TDSLoginService.h
//  TapTapLoginSource
//
//  Created by Bottle K on 2020/12/2.
//

#import <Foundation/Foundation.h>
#import <TDSCommonSource/TDSBridge.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSLoginService : NSObject

+ (void)clientID:(NSString *)clientID;

+ (void)clientID:(NSString *)clientID regionType:(BOOL)isCN roundCorner:(BOOL)roundCorner;

+ (void)regionType:(BOOL)isCN roundCorner:(BOOL)roundCorner;

+ (void)registerLoginCallback:(void (^)(NSString *result))callback;

+ (void)permissions:(NSArray *)permissions;

+ (void)currentAccessToken:(void (^)(NSString *result))callback;

+ (void)currentProfile:(void (^)(NSString *result))callback;

+ (void)fetchProfileForCurrentAccessToken:(void (^)(NSString *result))callback;

+ (void)logout;
@end

NS_ASSUME_NONNULL_END
