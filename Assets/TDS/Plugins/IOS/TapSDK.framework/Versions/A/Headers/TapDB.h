//
//  TyrantdbGameTracker.h
//  TapDB_iOS
//
//  Created by JiangJiahao on 2019/7/23.
//  Copyright © 2019 JiangJiahao. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

typedef struct LoginType{
    NSString *loginType;
}TapDBLoginType;

/*
自定义登录方式：
TapDBLoginType customLoginType = {@"custom"};
*/
FOUNDATION_EXPORT TapDBLoginType const TapDBLoginTypeTapTap;
FOUNDATION_EXPORT TapDBLoginType const TapDBLoginTypeWeiXin;
FOUNDATION_EXPORT TapDBLoginType const TapDBLoginTypeQQ;
FOUNDATION_EXPORT TapDBLoginType const TapDBLoginTypeTourist;
FOUNDATION_EXPORT TapDBLoginType const TapDBLoginTypeApple;
FOUNDATION_EXPORT TapDBLoginType const TapDBLoginTypeZhifubao;
FOUNDATION_EXPORT TapDBLoginType const TapDBLoginTypeFacebook;
FOUNDATION_EXPORT TapDBLoginType const TapDBLoginTypeGoogle;
FOUNDATION_EXPORT TapDBLoginType const TapDBLoginTypeTwitter;
FOUNDATION_EXPORT TapDBLoginType const TapDBLoginTypePhoneNumber;

// 账户类型
typedef NS_ENUM(NSInteger,TGTUserType) {
    TGTTypeAnonymous = 0, // 匿名用户
    TGTTypeRegistered // 注册用户
};

// 性别
typedef NS_ENUM(NSInteger,TGTUserSex) {
    TGTSexMale = 0, // 男性
    TGTSexFemale, // 女性
    TGTSexUnknown // 性别未知
};

@interface TapDB : NSObject

/**
 * 调用该接口修改数据发送的域名，有特殊需要时调用，调用必须位于初始化之前
 * 域名必须是https://abc.example.com/的格式，不能为空
 */
+ (void)setHost:(NSString *)host;

/**
 * 调用该接口修改自定义事件数据发送的域名，有特殊需要时调用，调用必须位于初始化之前
 * 域名必须是https://abc.example.com/的格式，不能为空
 */
+ (void)setCustomEventHost:(NSString *)host;

/**
 * 初始化，尽早调用
 * appId: 注册游戏时获得的APP ID
 * channel: 分包渠道名称，可为空
 * gameVersion: 游戏版本，可为空，为空时，自动获取游戏安装包的版本（Xcode配置中的Version）
 */
+ (void)onStart:(NSString *)appId channel:(nullable NSString *)channel version:(nullable NSString *)gameVersion;

/**
 * 初始化，尽早调用
 * clientId: TapTap登录sdk后台页面 client id
 * channel: 分包渠道名称，可为空
 * gameVersion: 游戏版本，可为空，为空时，自动获取游戏安装包的版本（Xcode配置中的Version）
 */
+ (void)onStartWithClientId:(NSString *)clientId channel:(nullable NSString *)channel version:(nullable NSString *)gameVersion;


/// 记录一个用户（注意是平台用户，不是游戏角色！！！！），需要保证唯一性
/// @param userId  用户的ID (注意是平台用户ID，不是游戏角色ID！！！！），如果是匿名用户，由游戏生成，需要保证不同平台用户的唯一性
+ (void)setUser:(NSString *)userId;


/// 记录一个用户（不是游戏角色！！！！），需要保证唯一性
/// @param userId 用户ID。不同用户需要保证ID的唯一性
/// @param openId 通过第三方登录获取到的openId
/// @param loginType 登录方式
+ (void)setUser:(NSString *)userId openId:(NSString *)openId loginType:(TapDBLoginType)loginType;
/**
 * 记录一个用户（注意是平台用户，不是游戏角色！！！！），需要保证唯一性
 * userId: 用户的ID（注意是平台用户ID，不是游戏角色ID！！！！），如果是匿名用户，由游戏生成，需要保证不同平台用户的唯一性
 * userType: 用户类型
 * userSex: 用户性别
 * userAge: 用户年龄，年龄未知传递0
 */
+ (void)setUser:(NSString *)userId userType:(TGTUserType)userType userSex:(TGTUserSex)userSex userAge:(NSInteger)userAge userName:(NSString *)userName DEPRECATED_MSG_ATTRIBUTE("已弃用，直接调用 setUser:(NSString *)userId 即可");

/**
 * 目前TapDB SDK仅支持单实例模式，如果多次调用onStart方法，只有最初传入的appid生效。调用该函数可以获取生效的信息
 * 返回值：包含appId和channel的NSDictionary，对应的value均可能为nil
 */
+ (NSDictionary *)getStartInfo;

/**
 * 设置用户等级，初次设置时或升级时调用
 * level: 等级
 */
+ (void)setLevel:(NSInteger)level;

/**
 * 设置用户服务器，初次设置或更改服务器的时候调用
 * server: 服务器
 */
+ (void)setServer:(NSString *)server;

/// 设置用户名
/// @param name 必传，长度大于0并小于等于256，用户名
+ (void)setName:(NSString *)name;

/**
 * 发起充值请求时调用
 * orderId: 订单ID，不能为空
 * product: 产品名称，可为空
 * amount: 充值金额（分）
 * currencyType: 货币类型，可为空，参考：人民币 CNY，美元 USD；欧元 EUR
 * payment: 支付方式，可为空，如：支付宝
 */
+ (void)onChargeRequest:(NSString *)orderId product:(NSString *)product amount:(NSInteger)amount currencyType:(NSString *)currencyType payment:(NSString *)payment DEPRECATED_MSG_ATTRIBUTE("已弃用");

/**
 * 充值成功时调用
 * orderId: 订单ID，不能为空，与上一个接口的orderId对应
 */
+ (void)onChargeSuccess:(NSString *)orderId DEPRECATED_MSG_ATTRIBUTE("已弃用");

/**
 * 充值失败时调用
 * orderId: 订单ID，不能为空，与上一个接口的orderId对应
 * reason: 失败原因，可为空
 */
+ (void)onChargeFail:(NSString *)orderId reason:(NSString *)reason DEPRECATED_MSG_ATTRIBUTE("已弃用");

/**
 * 充值成功时调用
 * orderId: 订单ID，可为空
 * product: 产品名称，可为空
 * amount: 充值金额（单位分，即无论什么币种，都需要乘以100）
 * currencyType: 货币类型，可为空，参考：人民币 CNY，美元 USD；欧元 EUR
 * payment: 支付方式，可为空，如：支付宝
 */
+ (void)onChargeSuccess:(NSString *)orderId product:(NSString *)product amount:(NSInteger)amount currencyType:(NSString *)currencyType payment:(NSString *)payment;

/**
 * 当客户端无法跟踪充值请求发起，只能跟踪到充值成功的事件时，调用该接口记录充值信息
 * orderId: 订单ID，可为空
 * product: 产品名称，可为空
 * amount: 充值金额（单位分，即无论什么币种，都需要乘以100）
 * currencyType: 货币类型，可为空，参考：人民币 CNY，美元 USD；欧元 EUR
 * virtualCurrencyAmount: 充值获得的虚拟币
 * payment: 支付方式，可为空，如：支付宝
 */
+ (void)onChargeOnlySuccess:(NSString *)orderId product:(NSString *)product amount:(NSInteger)amount currencyType:(NSString *)currencyType virtualCurrencyAmount:(NSInteger)virtualCurrencyAmount payment:(NSString *)payment DEPRECATED_MSG_ATTRIBUTE("已弃用,请调用onChargeSuccess:product:amount:currencyType:payment");

/**
 * 自定义事件
 * eventCode: 事件代码，需要在控制后台预先进行配置
 * properties: 事件属性，需要在控制后台预先进行配置,值为长度大于0并小于等于256的字符串或绝对值小于1E11的浮点数
 */
+ (void)onEvent:(NSString *)eventCode properties:(NSDictionary *)properties;
@end

NS_ASSUME_NONNULL_END
