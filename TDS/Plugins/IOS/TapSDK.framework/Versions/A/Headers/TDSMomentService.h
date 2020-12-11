//
//  TDSMomentService.h
//  TDSMomentSource
//
//  Created by Insomnia on 2020/11/11.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSMomentService : NSObject

+ (void)setMomentCallback:(void (^)(NSString *result))callback;

+ (void)clientId:(NSString *)clientId;

+ (void)getNoticeData;

+ (void)config:(NSNumber *)config;

+ (void)closeMoment;

+ (void)title:(NSString *)title content:(NSString *)content;

+ (void)config:(NSNumber *)config imagePaths:(NSArray <NSString *> *)imagePaths content:(NSString *)content;

+ (void)config:(NSNumber *)config videoPaths:(NSArray <NSString *> *)videoPaths title:(NSString *)title desc:(NSString *)desc;

+ (void)config:(NSNumber *)config videoPaths:(NSArray <NSString *> *)videoPaths imagePaths:(NSArray <NSString *> * _Nullable )imagePaths title:(NSString *)title desc:(NSString *)desc;


@end

NS_ASSUME_NONNULL_END
