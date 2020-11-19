//
//  TDSApiClient.h
//
//  Created by TapTap-David on 2020/9/25.
//  Copyright © 2020 taptap. All rights reserved.
//

#import "TDSAsyncHttp.h"
#import "TDSAccount.h"
#import "TDSCommonHeader.h"

NS_ASSUME_NONNULL_BEGIN

@interface TDSApiClient : TDSAsyncHttp

- (instancetype)initWithHeader:(TDSCommonHeader *)header;

- (TDSAsyncHttp *)httpGet:(NSString *)urlStr
            requestParams:(nullable NSDictionary *)requestParams
                   params:(nullable NSDictionary *)params
                     auth:(BOOL)needAuth
                 callBack:(CallBackBlock)callBackBlock
           failedCallback:(CallBackBlock)failedCallback;

- (TDSAsyncHttp *)httpPost:(NSString *)urlStr
             requestParams:(nullable NSDictionary *)requestParams
                    params:(nullable NSDictionary *)params
                      auth:(BOOL)needAuth
                  callBack:(CallBackBlock)callBackBlock
            failedCallback:(CallBackBlock)failedCallback;
@end

NS_ASSUME_NONNULL_END
