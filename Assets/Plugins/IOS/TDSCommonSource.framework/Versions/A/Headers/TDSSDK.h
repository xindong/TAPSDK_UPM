//
//  TDSSDK.h
//  TDSCommon
//
//  Created by Bottle K on 2020/10/13.
//

#import <Foundation/Foundation.h>
#import "TDSAccount.h"
#import "TDSAccountNotification.h"

NS_ASSUME_NONNULL_BEGIN
typedef NSString *TDSLanguage NS_STRING_ENUM;

FOUNDATION_EXPORT TDSLanguage const TDSLanguageCN;
FOUNDATION_EXPORT TDSLanguage const TDSLanguageEN;

@interface TDSSDK : NSObject

+ (instancetype)new NS_UNAVAILABLE;

+ (instancetype)shareInstance;

- (void)initWithAppID:(NSString *)appid
          accountType:(TDSAccountType)accountType
                token:(NSString *)token;

- (NSString *)getApppId;

- (TDSAccount *)getAccont;

- (BOOL)isLoggedin;

- (void)setCurrentAccount:(TDSAccountType)accountType
                    token:(NSString *)token;

- (void)logout;

- (void)registerAccountNotification:(NSString *)key
                       notification:(id<TDSAccountNotification>)notification;

- (void)unRegisterAccountNotification:(NSString *)key;

- (void)setLanguage:(NSString *)language;

- (NSString *)getLanguage;
@end

NS_ASSUME_NONNULL_END
