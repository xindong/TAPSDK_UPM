//
//  TDSAchievement.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/9/21.
//  Copyright © 2020 taptap. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TDSAchievementDelegate.h"

NS_ASSUME_NONNULL_BEGIN
typedef void (^TTAchievementRequestHandler)(NSArray<TDSAchievementModel *> *_Nullable result, NSError *_Nullable error);

@interface TDSAchievement : NSObject

+ (instancetype)shareInstance;
/**
 设置回调协议
 *
 @param delegate <TDSAchievementDelegate>
 */
+ (void)registerCallBack:(nonnull id<TDSAchievementDelegate>)delegate;

+ (void)initSDK;

/**
 *  @brief XD/XDG登录时 SDK初始化方法
 *
 *  请尽量在程序启动的时候初始化
 */
+ (void)initWithXD:(NSString *)token appId:(NSString *)appId;

/**
 *  @brief TAP登录时 SDK初始化方法
 *
 *  请尽量在程序启动的时候初始化
 */
+ (void)initWithTAP:(NSString *)string appId:(NSString *)appId;

/**
*  @brief 获取所有成就数据
*
*/
+ (void)fetchAllAchievementList:(TTAchievementRequestHandler)callBack;

/**
*  @brief  获取当前用户成就列表
*
*/
+ (void)fetchUserAchievementList:(TTAchievementRequestHandler)callBack;

/**
*  @brief  达成成就
*
*  @param displayId 成就ID
*/
+ (void)reach:(NSString *)displayId;

/**
*  @brief  记录步长成就 （增加的步长）
*
*  @param displayId 成就ID
*  @param numSteps 增加的步长
*/
+ (void)growSteps:(NSString *)displayId numSteps:(NSInteger)numSteps;

/**
*  @brief  记录步长成就（总的步长）
*
*  @param displayId 成就ID
*  @param numSteps 总的步长
*/
+ (void)makeSteps:(NSString *)displayId numSteps:(NSInteger)numSteps;

/**
* @brief 获取本地所有成就列表
 */
+ (NSArray<TDSAchievementModel *> *)getLocalAllAchievementList;

/**
* @brief 获取本地用户成就列表
 */
+ (NSArray<TDSAchievementModel *> *)getLocalUserAchievementList;

/**
* @brief 获取成就UI
 */
- (void)showAchievementPage;

@end

NS_ASSUME_NONNULL_END
