//
//  TDSTapDBService.h
//  TDSTapDBSource
//
//  Created by Bottle K on 2020/12/7.
//

#import <Foundation/Foundation.h>
#import "TDSBridge.h"

NS_ASSUME_NONNULL_BEGIN

@interface TDSTapDBService : NSObject
+ (void)  appId:(nullable NSString *)appId
       clientId:(nullable NSString *)clientId
        channel:(nullable NSString *)channel
    gameVersion:(nullable NSString *)gameVersion;

+ (void)userId:(NSString *)userId;

+ (void)userId:(NSString *)userId
        openId:(NSString *)openId
     loginType:(NSString *)loginType;

+ (void)name:(NSString *)name;

+ (void)level:(NSNumber *)level;

+ (void)server:(NSString *)server;

+ (void) orderId:(NSString *)orderId
         product:(NSString *)product
          amount:(NSNumber *)amount
    currencyType:(NSString *)currencyType
         payment:(NSString *)payment;

+ (void)eventCode:(NSString *)eventCode
       properties:(NSString *)properties;
@end

NS_ASSUME_NONNULL_END
