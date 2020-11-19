//
//  TDSSDKForumWebViewController.h
//  TapTapSDK
//
//  Created by sunyi on 2018/1/2.
//  Copyright © 2018年 易玩. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "TDSMomentWKWebViewJavascriptBridge.h"
#import "TDSMomentSdk.h"
#ifdef __has_include
#if __has_include(<TapTapSDK/TapTapSDK.h>)
#import <TapTapLoginSource/TTSDKAccessToken.h>
#endif
#endif

@protocol TDSSDKForumWebViewDelegate <NSObject>
-(void) onWebviewResult : (NSString *) result;
@end

@interface TDSMomentWebViewController : UIViewController

@property (weak, nonatomic) id<TDSMomentDelegate> delegate;
@property (weak, nonatomic) id<TDSSDKForumWebViewDelegate> resultDelegate;

@property (nonatomic, copy) NSString *clientId;
#ifdef __has_include
#if __has_include(<TapTapSDK/TapTapSDK.h>)
@property (nonatomic, strong) TTSDKAccessToken *accessToken;
#endif
#endif
@property (nonatomic, strong) TDSMomentConfig *config;
@property (nonatomic, strong) TDSMomentWKWebViewJavascriptBridge *bridge;
@property (nonatomic, copy) NSString *version;

@property (nonatomic, copy) NSString *customUA;

@property (nonatomic, copy) NSString *URL;

- (void)dismissSelf;

@end
