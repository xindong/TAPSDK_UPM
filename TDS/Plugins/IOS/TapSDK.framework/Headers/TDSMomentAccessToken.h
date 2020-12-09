//
//  TDSMomentAccessToken.h
//  TDSMomentSource
//
//  Created by Insomnia on 2020/12/2.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSMomentAccessToken : NSObject

/// 唯一标志
@property (nonatomic, copy) NSString * kid;

/// 认证码
@property (nonatomic, copy) NSString * accessToken;

/// 认证码类型
@property (nonatomic, copy) NSString * tokenType;

/// mac密钥
@property (nonatomic, copy) NSString * macKey;

/// mac密钥计算方式
@property (nonatomic, copy) NSString * macAlgorithm;

/// 用户授权的权限，多个时以逗号隔开
@property (nonatomic, copy) NSString * scope;

/// 根据JSON生成 TTSDKAccessToken
/// @param accessTokenString json字符串类型的AccessToken
+ (TDSMomentAccessToken *)build:(NSString *)accessTokenString;

/// 通过参数生成实例
+ (TDSMomentAccessToken *)build:(NSString *)kid accessToken:(NSString *)accessToken tokenType:(NSString *)tokenType macKey:(NSString *)macKey macAlgorithm:(NSString *)macAlgorithm;

/// 转换成json字符串
- (NSString *)toJsonString;


/**
 *  @brief 获取当前认证
 *
 *  该认证会优先读取本地缓存，不存在时将会返回nil
 */
+ (TDSMomentAccessToken *)currentAccessToken;

@end

NS_ASSUME_NONNULL_END
