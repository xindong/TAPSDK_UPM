//
//  TDSMomentPostViewController.h
//  TapMoment
//
//  Created by ritchie on 2020/7/20.
//  Copyright © 2020 TapTap. All rights reserved.
//

#import "TDSMomentWebViewController.h"
#import "TDSMomentSdk.h"
#import "TDSMomentAccessToken.h"

NS_ASSUME_NONNULL_BEGIN

@class TDSPostMomentData;

@interface TDSMomentPostViewController : TDSMomentWebViewController


- (instancetype)init NS_UNAVAILABLE;
- (instancetype)new NS_UNAVAILABLE;

- (instancetype)initWithContent:(TDSPostMomentData *)content
                    accessToken:(TDSMomentAccessToken *)accessToken
                         config:(TDSMomentConfig *)config;

@end

NS_ASSUME_NONNULL_END
