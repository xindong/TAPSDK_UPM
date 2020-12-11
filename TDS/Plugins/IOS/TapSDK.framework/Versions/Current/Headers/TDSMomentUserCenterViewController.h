//
//  TDSMomentUserCenterViewController.h
//  TapMoment
//
//  Created by ritchie on 2020/9/1.
//  Copyright © 2020 JiangJiahao. All rights reserved.
//

//#import "TapWebViewController.h"
#import "TDSMomentWebViewController.h"
#import "TDSMomentAccessToken.h"
NS_ASSUME_NONNULL_BEGIN

@interface TDSMomentUserCenterViewController : TDSMomentWebViewController
- (instancetype)initWithAccessToken:(TDSMomentAccessToken *)accessToken
                             config:(TDSMomentConfig *)config
                             userId:(NSString *)userId
                            isTapId:(BOOL)isTapId;

@end

NS_ASSUME_NONNULL_END
