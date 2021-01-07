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

//#import "TapTapSDK.h"

NS_ASSUME_NONNULL_BEGIN

/**
 v1.2.0
 */

typedef NS_ENUM (NSInteger, TDSMomentOrientation) {
    TDSMomentOrientationDefault   = -1,
    TDSMomentOrientationLandscape = 0,
    TDSMomentOrientationPortrait  = 1,
};

@protocol TDSMomentDelegate <NSObject>

@optional

- (void)onMomentCallbackWithCode:(NSInteger)code msg:(NSString *)msg;

@end

@interface TDSMomentConfig : NSObject

@property (nonatomic, assign) TDSMomentOrientation orientation;

+ (TDSMomentConfig *)createWithOrientation:(TDSMomentOrientation)orientation;
@end

@interface TDSMomentSdk : NSObject

+ (void)initSDKWithClientId:(NSString *)clientId;

+ (void)setDelegate:(id <TDSMomentDelegate>)delegate;

+ (NSString *)getSdkVersion;

+ (NSString *)getSdkVersionCode;

+ (void)openTapMomentWithConfig:(TDSMomentConfig *)config;

/// 打开好友个人中心
/// @param config TDSMomentConfig
/// @param userId openId
+ (void)openUserCenterWithConfig:(TDSMomentConfig *)config userId:(NSString *)userId;

/// 关闭所有内嵌窗口
/// @param title 弹框的 title
/// @param content 弹框的 content
/// @param showConfirm 是否显示确认弹窗
/// @warning 传空或者空串不弹框
+ (void)closeMomentWithTitle:(NSString *)title
                     content:(NSString *)content
                 showConfirm:(BOOL)showConfirm;

/// 直接关闭所有内嵌窗口不弹二次确认窗口
+ (void)closeMoment;

/// 获取新动态数量
/// @warning 结果在 `Delegate` 下的 `onMomentCallbackWithCode:msg:`, code == TM_RESULT_CODE_NEW_MSG_SUCCEED时，`msg` 即为消息数量
+ (void)fetchNewMessage;

/// 发布动态
/// @param content 发布的动态内容
/// @param config 配置
/// @warning `moment`参数：动态内容为视频请选择`TDSVideoMomentData`, 动态内容为图片时请选择 `TDSImageMomentData`。
+ (void)openPostMomentPageWithContent:(TDSPostMomentData *_Nonnull)content
                               config:(TDSMomentConfig *_Nonnull)config;

@end

NS_ASSUME_NONNULL_END
