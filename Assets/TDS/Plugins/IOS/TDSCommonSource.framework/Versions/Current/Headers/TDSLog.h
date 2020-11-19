//
//  TDSLog.h
//  TDSCommonSource
//
//  Created by Insomnia on 2020/10/26.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

#ifndef TDSLogInfo
#define TDSLogInfo(model, format, ...) TDSLogInfoFunc(model, [NSString stringWithFormat:format, ## __VA_ARGS__], __PRETTY_FUNCTION__)
#endif

#ifndef TDSLogCustom
#define TDSLogCustom(model, tag, format, ...) TDSLogCustomFunc(model, tag, [NSString stringWithFormat:format, ## __VA_ARGS__], __PRETTY_FUNCTION__)
#endif

#ifndef TDSLogCrash
#define TDSLogCrash(model, format, ...) TDSLogCustomFunc(model, @"Crash", [NSString stringWithFormat:format, ## __VA_ARGS__], __PRETTY_FUNCTION__)
#endif

@interface TDSLogModel : NSObject
@property (nonatomic, copy, nonnull) NSString *sdkName;
@property (nonatomic, copy, nonnull) NSString *sdkCode;
@property (nonatomic, copy, nonnull) NSString *sdkVersion;
@end

@interface TDSLog : NSObject

+ (instancetype)sharedInstance;

- (void)tdsLogWithModel:(TDSLogModel * _Nonnull)model tags:(NSString *)tag content:(NSString *)content;

@end


/** 记录Info标签日志 */
FOUNDATION_EXPORT void TDSLogInfoFunc(TDSLogModel* _Nonnull model, NSString* _Nonnull log, const char * func);
/** 记录自定义标签日志 */
FOUNDATION_EXPORT void TDSLogCustomFunc(TDSLogModel* _Nonnull model, NSString *_Nonnull tag, NSString* _Nonnull log,const char * func);

NS_ASSUME_NONNULL_END
