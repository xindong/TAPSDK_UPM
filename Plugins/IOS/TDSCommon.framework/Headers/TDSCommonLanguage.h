//
//  TDSCommonLanguage.h
//  TDSCommon
//
//  Created by Bottle K on 2021/3/4.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM (NSInteger, TDSLanguageType) {
    TDSLanguageType_zh_Hans,// 简中
    TDSLanguageType_zh_Hant,// 繁中
    TDSLanguageType_en,// 英文
};

@interface TDSCommonLanguage : NSObject

@property (nonatomic, assign) BOOL regionIsIO;
+ (instancetype)shareInstance;

+ (void)setCurrentLanguage:(TDSLanguageType)langType;

+ (NSString *)getCurrentLanguage;

+ (NSDictionary *)readJsonFile:(NSString *)filePath;

+ (NSString *)getTextWith:(NSDictionary *)dic byKey:(NSString *)key;
@end

NS_ASSUME_NONNULL_END
