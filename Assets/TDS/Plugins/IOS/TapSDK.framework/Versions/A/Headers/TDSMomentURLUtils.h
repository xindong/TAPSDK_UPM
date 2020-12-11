//
//  TapTapForumURLUtils.h
//  TapTapForum
//
//  Created by JiangJiahao on 2019/11/25.
//  Copyright © 2019 JiangJiahao. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSMomentURLUtils : NSObject
+ (NSString *) encodeURI:(NSString *) string;
+ (NSString *)decodeBase64Url:(NSString *)string;

+ (NSString *)URLEncode:(NSString *)url;
+ (NSString *)URLDecode:(NSString *)url;
+ (NSDictionary *)dictionaryWithJsonString:(NSString *)jsonString;
@end

NS_ASSUME_NONNULL_END
