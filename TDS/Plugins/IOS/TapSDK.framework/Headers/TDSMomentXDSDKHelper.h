//
//  TDSMomentXDSDKHelper.h
//  TapMoment
//
//  Created by 孙毅 on 2020/6/17.
//  Copyright © 2020 JiangJiahao. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TDSMomentAccessToken.h"

typedef void(^TapTapLoginResultBlock)(NSDictionary *resultDic);

typedef NS_ENUM(NSUInteger, TapTapLoginCallBackCode) {
    TapTapLoginCallBackCodeSuccess = 0,
    TapTapLoginCallBackCodeFail,
    TapTapLoginCallBackCodeCancel,
};

@interface TDSMomentXDSDKHelper : NSObject

+ (BOOL)hasXDSDK;

+ (void)getCurrentTapToken:(TapTapLoginResultBlock)callback;

+ (void)getCurrentTapToken:(TapTapLoginResultBlock)callback cache:(BOOL)cache;

+ (void)getUserInfo:(TapTapLoginResultBlock)callback;

+ (void)openBindTapDialog:(BOOL)needConfirm callback:(TapTapLoginResultBlock)callback;

+ (void)verifiedRealName:(NSString *)name cardNo:(NSString *)cardNo;

+ (void)bindTapTapWithArg:(NSDictionary *)arg callback:(TapTapLoginResultBlock)callback;

+ (void)getTapTokenWithCallback:(TapTapLoginResultBlock)callback;

+ (void)validateWithTapToken:(NSDictionary *)tapToken callback:(TapTapLoginResultBlock)callback;

+ (void)getAccessToken:(void(^)(TDSMomentAccessToken *token))complete;

+ (void)getAccessToken:(void(^)(TDSMomentAccessToken *token))complete cache:(BOOL)cache;

// 这个入参为getCurrentTapToken的返回值可能为空
// if resultDic[@"code"] == 0 时候使用
// if(resultDic && [@0 isEqualToNumber:[resultDic objectForKey:@"code"]])
+ (TDSMomentAccessToken *)convertAccessTokenWith:(NSDictionary *)dict;

@end

