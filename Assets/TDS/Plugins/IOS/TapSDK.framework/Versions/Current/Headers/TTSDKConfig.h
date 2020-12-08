//
//  TTSDKConfig.h
//  TapTapSDK
//
//  Created by wzb on 2020/5/13.
//  Copyright © 2020 易玩. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM (NSInteger, RegionType) {
    RegionTypeCN,
    RegionTypeIO
};

typedef struct GameLoginType {
    NSString *_Nonnull loginType;
}GameLoginType;

// 登录方式
/*
 自定义登录方式：
 GameLoginType customLoginType = {@"custom"};
 */
FOUNDATION_EXPORT GameLoginType const GameLoginTypeTapTap;
FOUNDATION_EXPORT GameLoginType const GameLoginTypeWeiXin;
FOUNDATION_EXPORT GameLoginType const GameLoginTypeQQ;
FOUNDATION_EXPORT GameLoginType const GameLoginTypeTourist;
FOUNDATION_EXPORT GameLoginType const GameLoginTypeApple;
FOUNDATION_EXPORT GameLoginType const GameLoginTypeZhifubao;
FOUNDATION_EXPORT GameLoginType const GameLoginTypeFacebook;
FOUNDATION_EXPORT GameLoginType const GameLoginTypeGoogle;
FOUNDATION_EXPORT GameLoginType const GameLoginTypeTwitter;
FOUNDATION_EXPORT GameLoginType const GameLoginTypePhoneNumber;

@interface TTSDKConfig : NSObject

/// 是否为圆角，默认为圆角
@property (nonatomic, assign) BOOL roundCorner;
/// 限定登录客户端
@property (nonatomic, assign) RegionType regionType;
/// 是否开启tapdb统计
@property (nonatomic) BOOL openTapDB;
/// 渠道名，如『AppStore』
@property (nullable, nonatomic) NSString *channel;
/// 游戏版本
@property (nullable, nonatomic) NSString *gameVersion;

@end

NS_ASSUME_NONNULL_END
