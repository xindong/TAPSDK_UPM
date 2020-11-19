//
//  NSBundle+TDSLocalizable.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/8/26.
//  Copyright © 2020 taptap. All rights reserved.
//
#import <UIKit/UIKit.h>

@interface NSBundle (TDSLocalizable)
+ (instancetype)tds_localizableBundleWithBundleName:(NSString *)bundleName;
- (NSString *)tds_localizedStringForKey:(NSString *)key value:(NSString *)value;
- (NSString *)tds_localizedStringForKey:(NSString *)key;
@end
