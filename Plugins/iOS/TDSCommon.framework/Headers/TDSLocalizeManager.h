//
//  TDSLocalizeManager.h
//  TDSCommon
//
//  Created by Bottle K on 2021/3/8.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM (NSInteger, TDSLang) {
    TDSLang_Auto,// 自动
    TDSLang_zh_Hans,// 简中
    TDSLang_zh_Hant,// 繁中
    TDSLang_en,// 英文
};

@interface TDSLocalizeManager : NSObject

@property (nonatomic, assign) BOOL regionIsIO;

+ (instancetype)shareInstance;

/// 设定当前语言类型
/// @param langType 语言类型
+ (void)setCurrentLanguage:(TDSLang)langType;

/// 注册SDK本地化翻译
/// @param sdk SDK tag
/// @param filePath 本地化翻译文件位置
+ (void)addSDKLocalization:(NSString *)sdk localizedFilePath:(NSString *)filePath;

/// 注册SDK本地化翻译
/// @param sdk SDK tag
/// @param localizedDic 本地化翻译字典
+ (void)addSDKLocalization:(NSString *)sdk localizedDic:(NSDictionary *)localizedDic;

/// 获取本地化翻译
/// @param sdk SDK tag
/// @param key 本地化翻译key
+ (NSString *)getLocalizedStringWithSDK:(NSString *)sdk localizedKey:(NSString *)key;

@end

NS_ASSUME_NONNULL_END
