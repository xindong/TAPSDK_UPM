//
//  TapDBIdTool.h
//  TapDB_iOS
//
//  Created by JiangJiahao on 2019/10/13.
//  Copyright © 2019 JiangJiahao. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TapDBIdTool : NSObject

+ (NSString *)getTapDBId:(NSString *)idfa;

+ (NSString *)getInstallUUID;
+ (NSString *)getPersistUUID;

+ (NSString *)generateUUID;

@end

NS_ASSUME_NONNULL_END
