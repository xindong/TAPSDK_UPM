//
//  TapTapSDKHttpRequest.h
//  TapTapSDK
//
//  Created by 任龙 on 2017/10/27.
//  Copyright © 2017年 易玩. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface TapTapSDKHttpRequest : NSObject

+ (void)requestByGetWithUrl:(NSURL *)url
                    headers:(NSDictionary<NSString *, NSString *> *)headers
                    handler:(void(^)(NSData * data, NSURLResponse * response, NSError * error))handler;

+ (void)requestByPostWithUrl:(NSURL *)url
                     headers:(NSDictionary *)headers
                        body:(NSData *)body
                     handler:(void(^)(NSData * data, NSURLResponse * response, NSError * error))handler;

+ (NSString *)genMacTokenWithUrl:(NSString *)url
                          method:(NSString *)method
                         oAuthID:(NSString *)oAuthID
                     oAuthMacKey:(NSString *)oAuthMacKey;

@end
