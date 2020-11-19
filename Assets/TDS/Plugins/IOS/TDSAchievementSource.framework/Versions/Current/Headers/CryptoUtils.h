//
//  CryptoUtils.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/9/22.
//  Copyright © 2020 taptap. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface CryptoUtils : NSObject

+ (NSData *)aesEncrypt:(NSString *)key encryptData:(NSData *)data;

+ (NSData *)aesDecrypt:(NSString *)key encryptData:(NSData *)data;

@end

NS_ASSUME_NONNULL_END
