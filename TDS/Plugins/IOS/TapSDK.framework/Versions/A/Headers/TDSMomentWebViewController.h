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
#import "TDSMomentAccessToken.h"

@protocol TDSSDKForumWebViewDelegate <NSObject>
-(void) onWebviewResult : (NSString *) result;
@end

@interface TDSMomentWebViewController : UIViewController

@property (weak, nonatomic) id<TDSMomentDelegate> delegate;
@property (weak, nonatomic) id<TDSSDKForumWebViewDelegate> resultDelegate;

@property (nonatomic, copy) NSString *clientId;
@property (nonatomic, strong) TDSMomentAccessToken *accessToken;
@property (nonatomic, strong) TDSMomentConfig *config;
@property (nonatomic, strong) TDSMomentWKWebViewJavascriptBridge *bridge;
@property (nonatomic, copy) NSString *version;

@property (nonatomic, copy) NSString *customUA;

@property (nonatomic, copy) NSString *URL;

- (void)dismissSelf;

@end
