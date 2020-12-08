//
//  TapDBEventBase.h
//  TapDB_iOS
//
//  Created by JiangJiahao on 2020/8/4.
//  Copyright © 2020 JiangJiahao. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TapDBEventBase : NSObject

- (void)setAccount:(NSString *)account module:(nullable NSString *)module catogery:(NSString *)catogery;
- (void)setClientId:(NSString *)clientId module:(nullable NSString *)module catogery:(NSString *)catogery;

+ (void)TapDBEventLog:(NSString *)log;

@end

NS_ASSUME_NONNULL_END
