//
//  TDSRegionNetClient.h
//  TDSCommonSource
//
//  Created by TapTap-David on 2020/11/18.
//

#import <Foundation/Foundation.h>
#import "TDSNetExecutor.h"
NS_ASSUME_NONNULL_BEGIN

@interface TDSRegionNetClient : NSObject
+ (instancetype)sharedInstance;

- (TDSNetExecutor *)doWithRequest:(TDSNetRequestModel *)request;
@end

NS_ASSUME_NONNULL_END
