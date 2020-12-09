//
//  TapDBEvent.h
//  TapDB_iOS
//
//  Created by JiangJiahao on 2019/7/22.
//  Copyright © 2019 JiangJiahao. All rights reserved.
//

#import <Foundation/Foundation.h>
/*
 
 TapDBEvent简介：
 
 该SDK可用于手机APP进行各种事件统计，统计数据将发送到心动服务器并进行分析，最终形成数据报表。
 
 基本概念：
 
 account：统计系统子账号，可在心动平台生成，统计数据存放在某个对应的account下，无关联的两套统计数据建议使用两个子账号。
 identify：tyrantdb统计系统需要将一系列事件对应到某一用户身上，用户不是特指注册用户，未注册的使用者也认为是一个用户，这里用identify标识用户。identify还可以设置一些用户属性，后续事件也可以关联上已有的用户属性。identify设置后，会自动保存在客户端中，下次运行应用可以读取到之前存储的用户标识。
 event：事件，主要统计元素，每个事件对应到某个identify，并且具备一个名称name和一些属性。
 
 使用方法：
 
 1.创建一个TapDBEvent实例并设置统计系统子账号。
 
 ---
 TapDBEvent *tyrantdb = [[Tyrantdb alloc] init];
 [tyrantdb setAccount:@"iossdktest"];
 ---
 
 2.设置用户标识，可以调用autoIdentify自动设置用户标识，或者使用identify主动设置一个用户标识。
 如果跟踪的用户都是注册用户，并且希望把统计数据关联到对应的用户上，应该主动设置用户标识，比如使用用户的ID
 如果需要跟踪非注册用户，或者不需要把统计数据关联到对应的用户上，可以使用autoIdentify自动设置用户标识，该方法将自动生成一个uuid作为用户标识。
 设置identify后，tyrantdb会将identify存储在本地，下次应用程序启动时，如果调用autoIdentify，则会读取缓存的identify而不是又生成一个uuid，这样可以保证事件对应到同一个用户。
 
 ---
 [TapDBEvent autoIdentify];
 ---
 or
 ---
 [TapDBEvent identify:@"xdid_123456"];
 ---
 
 3.为用户设置属性，为用户设置属性后，可以统计到具备某一属性的用户后续的事件情况。
 在设置用户标识时，可以一并设置用户属性，自动设置用户标识调用autoIdentifyWithProperties，主动设置用户标识调用identify:properties:
 需要在设置用户标识后设置用户标识，直接调用setProperties，对同一用户标识多次设置属性采用的是merge方式
 
 ---
 NSMutableDictionary *properties_1 = [[NSMutableDictionary alloc] initWithCapacity:1];
 [properties_1 setObject:@"谷歌广告" forKey:@"用户来源"];
 [tyrantdb autoIdentifyWithProperties:properties_1];
 NSMutableDictionary *properties_2 = [[NSMutableDictionary alloc] initWithCapacity:1];
 [properties_2 setObject:@"true" forKey:@"VIP"];
 [tyrantdb setProperties:properties_2];
 ---
 or
 ---
 NSMutableDictionary *properties_1 = [[NSMutableDictionary alloc] initWithCapacity:1];
 [properties_1 setObject:@"谷歌广告" forKey:@"用户来源"];
 [tyrantdb identify:@"xdid_123456" setProperties:properties_1];
 NSMutableDictionary *properties_2 = [[NSMutableDictionary alloc] initWithCapacity:1];
 [properties_2 setObject:@"true" forKey:@"VIP"];
 [tyrantdb setProperties:properties_2];
 ---
 
 4.发送事件统计信息，事件可以附带一些属性，后面可以根据属性进行分类统计和查询
 
 ---
 NSMutableDictionary *properties = [[NSMutableDictionary alloc] initWithCapacity:1];
 [properties setObject:[[NSNumber alloc] initWithInt:50] forKey:@"充值金额"];
 [tyrantdb event:@"用户充值" properties:properties];
 ---
 
 */


NS_ASSUME_NONNULL_BEGIN

@interface TapDBEvent : NSObject

/**
 * 调用该接口修改数据发送的域名，有特殊需要时调用，调用必须位于创建对象之前
 * 域名必须是https://abc.example.com/的格式，不能为空
 */
+ (void)setHost:(NSString *)host;

/**
 * 调用该接口修改自定义事件数据发送的域名，有特殊需要时调用，调用必须位于创建对象之前
 * 域名必须是https://abc.example.com/的格式，不能为空
 */
+ (void)setCustomEventHost:(NSString *)host;
+ (NSString *)getHost;;
/**
 * 获取一个TapDBEvent实例，如果要同时使用多个TapDBEvent对象，要保证两个对象的catogery参数不同
 * account：子账号
 * module：统计业务类别，用来区分不同的统计业务，服务器会有不同的计算逻辑，默认为nil即可
 * catogery：用来区分不同统计对象的，内部缓存用户标识也和该字段有关
 */
+ (TapDBEvent *)TapDBEvent:(NSString *)account module:(nullable NSString *)module catogery:(NSString *)catogery;

// clientId ：TapTap获得的clientId
+ (TapDBEvent *)TapDBEventWithClientId:(nullable NSString *)clientId module:(nullable NSString *)module catogery:(NSString *)catogery;

/**
 * 设置统计系统子账号，如果要同时使用多个Tyrantdb对象，要保证两个对象的catogery参数不同
 * account：子账号
 * module：统计业务类别，用来区分不同的统计业务，服务器会有不同的计算逻辑，默认为nil即可
 * catogery：用来区分不同统计对象的，内部缓存用户标识也和该字段有关
 */
- (void)setAccount:(NSString *)account module:(nullable NSString *)module catogery:(NSString *)catogery;


/// 设置openId和登录方式
/// @param openId taptap openid
/// @param loginType 登录方式
- (void)setOpenId:(NSString *)openId loginType:(NSString *)loginType;
/**
 * 判断是否已有之前存储过的用户标识，如果存在，调用autoIdentify接口可以继续使用存储过的用户标识到当前实例
 */
- (BOOL)hasSavedIdentify;

/**
 * 获取已存储的用户标识，而非当前实例绑定的用户标识
 */
- (NSString *)getSavedIdentify;

/**
 * 自动生成用户标识，如果有之前存储过的用户标识，则读取存储的用户标识
 * 实际调用[self autoIdentifyWithProperties:nil setIp:nil setTimestamp:nil]
 */
- (void)autoIdentify;

/**
 * 自动生成用户标识，并设置一些用户属性，如果有之前存储过的用户标识，则读取存储的用户标识
 * 实际调用[self autoIdentifyWithProperties:properties setIp:nil setTimestamp:nil]
 */
- (void)autoIdentifyWithProperties:(nullable NSDictionary *)properties;

/**
 * 设置当前实例用户标识
 * 实际调用[self identify:identify setProperties:nil setIp:nil setTimestamp:nil]
 */
- (void)identify:(NSString *)identify;

/**
 * 设置当前实例用户标识，并设置一些用户属性
 * 实际调用[self identify:identify setProperties:properties setIp:nil setTimestamp:nil]
 */
- (void)identify:(NSString *)identify properties:(nullable NSDictionary *)properties;

/**
 * 获取当前实例用户标识
 */
- (NSString *)getIdentify;

/**
 * 清除用户标识，会清除当前实例子账号下的用户标识数据，存储在本地的用户标识也会一并清除
 */
- (void)clearIdentify;

/**
 * 发送一个带属性的统计事件
 * name：事件名称
 * properties：事件属性
 */
- (void)event:(NSString *)name properties:(NSDictionary *)properties;

- (void)custom:(NSString *)name;
- (void)custom:(NSString *)name properties:(nullable NSDictionary *)properties;

/**
 * 获取未发送的消息条数
 */
- (NSUInteger)getOperationCount;

@end

NS_ASSUME_NONNULL_END
