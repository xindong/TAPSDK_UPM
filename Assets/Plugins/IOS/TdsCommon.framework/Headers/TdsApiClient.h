//
//  TdsApiClient.h
//
//  Created by TapTap-David on 2020/9/25.
//  Copyright © 2020 taptap. All rights reserved.
//
#import "TdsCommon/TDSAsyncHttp.h"
#import "TdsAccount.h"
#import "TdsCommonHeader.h"

NS_ASSUME_NONNULL_BEGIN

@interface TdsApiClient : TDSAsyncHttp

- (instancetype)initWithHeader:(TdsCommonHeader *)header;

- (TDSAsyncHttp *)httpGet:(NSString *)urlStr
            requestParams:(nullable NSDictionary *)requestParams
                   params:(nullable NSDictionary *)params
                  account:(nullable TdsAccount *)account
                 callBack:(CallBackBlock)callBackBlock
           failedCallback:(CallBackBlock)failedCallback;

- (TDSAsyncHttp *)httpPost:(NSString *)urlStr
             requestParams:(nullable NSDictionary *)requestParams
                    params:(nullable NSDictionary *)params
                   account:(nullable TdsAccount *)account
                  callBack:(CallBackBlock)callBackBlock
            failedCallback:(CallBackBlock)failedCallback;
@end

NS_ASSUME_NONNULL_END
