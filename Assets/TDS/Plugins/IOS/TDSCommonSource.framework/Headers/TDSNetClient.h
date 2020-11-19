//
//  TDSNetClient.h
//  TDSCommonSource
//
//  Created by Insomnia on 2020/10/20.
//

#import <Foundation/Foundation.h>
#import "TDSNetClientModel.h"
#import "TDSNetExecutor.h"

// 待定
typedef void (^TDSNetProgressBlock) (NSProgress *_Nonnull downloadProgress);
// 返回值待定
typedef void (^TDSNetSuccessBlock) (NSDictionary *_Nullable resultDic);
// 返回值待定
typedef void (^TDSNetFailureBlock) (NSError *_Nonnull error);


NS_ASSUME_NONNULL_BEGIN

@interface TDSNetClient : NSObject

// success / failure 传递data中内容
- (instancetype)initWithConfig:(TDSNetConfigModel *)config;

- (void)requestWithModel:(TDSNetRequestModel *)model success:(TDSNetSuccessBlock)success;

- (void)requestWithModel:(TDSNetRequestModel *)model success:(TDSNetSuccessBlock)success failure:(nullable TDSNetFailureBlock)failure;

- (void)requestWithModel:(TDSNetRequestModel *)model success:(TDSNetSuccessBlock)success failure:(nullable TDSNetFailureBlock)failure progress:(nullable TDSNetProgressBlock)progress;

@end

NS_ASSUME_NONNULL_END
