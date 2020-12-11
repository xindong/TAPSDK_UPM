//
//  TapTapSDKHttpUtilities.h
//  TapTapSDK
//
//  Created by 任龙 on 2017/10/24.
//  Copyright © 2017年 易玩. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface TapTapSDKHttpUtilities : NSObject

+ (NSString *)URLEncodeString:(NSString *)str;

+ (NSString *)URLDecodeString:(NSString *)str;

+ (NSString *)currentTime;

+ (NSString *)randomStringInLength:(int)length;

+ (NSString *)createACodeVerifier:(NSUInteger)length;

+ (NSString *)SHA256:(NSString *)key;

+ (NSString *)md5String:(NSString *)str;

+ (NSString *)base64HMacSha1WithSecret:(NSString *)secret data:(NSString *)data;

+ (NSDictionary *) queryDictionaryFromURL:(NSURL *)url;

@end
