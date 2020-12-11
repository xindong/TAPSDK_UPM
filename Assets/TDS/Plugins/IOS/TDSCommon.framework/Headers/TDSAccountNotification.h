//
//  TDSAccountNotification.h
//  TDSCommon
//
//  Created by Bottle K on 2020/10/13.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@protocol  TDSAccountNotification <NSObject>

- (void)onAccountChanged:(TDSAccount *)newAccount
              oldAccount:(TDSAccount *)oldAccount;

- (void)onAccountLogout:(TDSAccount *)newAccount;
@end

NS_ASSUME_NONNULL_END
