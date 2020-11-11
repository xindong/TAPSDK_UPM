//
//  TDSLanguageTool.h
//  TDSAchievementSource
//
//  Created by TapTap-David on 2020/11/10.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSLanguageTool : NSObject
+ (NSString *)tds_localizedStringForKey:(NSString *)key;
+ (NSString *)tds_localizedStringForKey:(NSString *)key value:(nullable NSString *)value;
@end

NS_ASSUME_NONNULL_END
