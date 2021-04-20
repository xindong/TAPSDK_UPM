//
//  TapTapForum.h
//  TapTapSDK
//
//  Created by JiangJiahao on 2019/11/21.
//  Copyright © 2019 taptap. All rights reserved.
//

#import "TDSPostMomentData.h"
#import "TDSMomentResultCode.h"
#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

/**
 v1.2.0
 */

typedef NS_ENUM (NSInteger, TDSMomentOrientation) {
    TDSMomentOrientationDefault   = -1,
    TDSMomentOrientationLandscape = 0,
    TDSMomentOrientationPortrait  = 1,
};

# pragma mark 回调代理
@protocol TDSMomentDelegate <NSObject>

@optional

- (void)onMomentCallbackWithCode:(NSInteger)code msg:(NSString *)msg;

@end

# pragma mark Config 参数
@interface TDSMomentConfig : NSObject

@property (nonatomic, assign) TDSMomentOrientation orientation;

+ (TDSMomentConfig *)createWithOrientation:(TDSMomentOrientation)orientation;
@end

# pragma mark SDK 公开方法
@interface TDSMomentSdk : NSObject

/// 初始化
/// @param clientId clienId
+ (void)initSDKWithClientId:(NSString *)clientId;

/// 设置代理
/// @param delegate 代理
+ (void)setDelegate:(id <TDSMomentDelegate>)delegate;

/// 打开动态
/// @param config TDSMomentConfig
+ (void)openTapMomentWithConfig:(TDSMomentConfig *)config;

/// 打开好友个人中心
/// @param config TDSMomentConfig
/// @param userId openId
+ (void)openUserCenterWithConfig:(TDSMomentConfig *)config
                          userId:(NSString *)userId;

/// 打开动态场景化入口
/// @param config TDSMomentConfig
/// @param sceneId 场景化入口id
+ (void)openSceneEntryWithConfig:(TDSMomentConfig *)config
                         sceneId:(NSString *)sceneId;

/// 发布动态
/// @param content 发布的动态内容
/// @param config 配置
/// @warning `moment`参数：动态内容为视频请选择`TDSVideoMomentData`, 动态内容为图片时请选择 `TDSImageMomentData`。
+ (void)openPostMomentPageWithContent:(TDSPostMomentData *_Nonnull)content
                               config:(TDSMomentConfig *_Nonnull)config;

/// 关闭所有内嵌窗口
/// @param title 弹窗标题
/// @param content 弹窗内容
/// @param showConfirm 是否显示确认弹窗
/// @warning 传空或者空串不弹框
+ (void)closeMomentWithTitle:(NSString *)title
                     content:(NSString *)content
                 showConfirm:(BOOL)showConfirm;

/// 直接关闭所有内嵌窗口
/// @warning 该方法不弹二次确认窗口
+ (void)closeMoment;

/// 获取新动态数量
/// @warning 结果在 `Delegate` 下的 `onMomentCallbackWithCode:msg:`, code == TM_RESULT_CODE_NEW_MSG_SUCCEED时，`msg` 即为消息数量
+ (void)fetchNewMessage;

/// 获取SDK版本名
+ (NSString *)getSdkVersion;

/// 获取SDK版本号
+ (NSString *)getSdkVersionCode;
@end

NS_ASSUME_NONNULL_END
