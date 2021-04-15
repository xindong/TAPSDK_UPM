//
//  TDSTrackerCache.h
//  TDSCommon
//
//  Created by TapTap-David on 2021/1/18.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSTrackerCache : NSObject
+ (instancetype)sharedInstance;

/**
 缓存用户未上报日志数据
 */
- (void)cacheUserUnreportData:(nullable NSMutableArray *)object name:(NSString *)name ;

/**
 获取用户未上报日志数据
 */
- (NSMutableArray *)getUserUnreportCacheDataWithName:(NSString *)name;

/**
 删除用户缓存数据
 */
- (void)deleteUserCacheDataWithName:(NSString *)name;
@end

NS_ASSUME_NONNULL_END
