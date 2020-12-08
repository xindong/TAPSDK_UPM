//
//  TDSMomentTool.h
//  TapMoment
//
//  Created by ritchie on 2020/7/22.
//  Copyright © 2020 TapTap. All rights reserved.
//

#import <Foundation/Foundation.h>
@class TDSMomentConfig;
NS_ASSUME_NONNULL_BEGIN

#define TMDismissNotification  @"com.tapMoment.dismissAllController"
#define TMLoginSucceedNotification @"com.tapmoment.loginSucceedNotification"
#define TMHandleTapLoginNotification @"com.tapmoment.handleTapLoginNotification"
#define TDSMomentCheckBindTap @"com.tapmoment.checkBindTapNotification"
@class UIImage;
@class UIViewController;
@interface TDSMomentTool : NSObject


+ (BOOL)exist:(NSString *)path;
+ (long long)fileSize:(NSString *)path;
+ (NSString *)mimeType:(NSString *)path;



+ (NSString *)encryptForPlainText:(NSString *)plainText;
+ (NSString *)decryptForEncryption:(NSString *)encryption;

+ (NSString *)currentLanguage;


+ (UIImage *)imageResize:(UIImage *)img maxWidth:(float)maxWidth;

+ (NSString *)randomString;

+ (NSBundle *)bundle;

+ (NSString *)timestap;
+ (NSString *)randomString:(NSInteger)length;




+ (NSString *)convertToJSONFrom:(NSDictionary *)dict;


//////
+ (NSString *)clientId;

+ (TDSMomentConfig *)sdkConfig;

+ (void)logMsg:(id)msg;
+ (void)debugMsg:(id)msg;

+ (UIViewController *)currentViewController;



@end


@interface NSString (TTEncrypt)
- (NSString *)tds_encrypt;
- (NSString *)tds_decrypt;
@end




NS_ASSUME_NONNULL_END
