//
//  TapDBEventMobile.h
//  TapDB_iOS
//
//  Created by JiangJiahao on 2020/8/4.
//  Copyright © 2020 JiangJiahao. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TapDBEventBase.h"

NS_ASSUME_NONNULL_BEGIN

@interface TapDBEventMobile : TapDBEventBase
+ (TapDBEventMobile *)TapDBEvent:(NSString *)account module:(nullable NSString *)module catogery:(NSString *)catogery;
+ (TapDBEventMobile *)TapDBEventWithClientId:(nullable NSString *)clientId module:(nullable NSString *)module catogery:(NSString *)catogery;
@end

NS_ASSUME_NONNULL_END
