//
//  TDSAccount.h
//  TDSCommon
//
//  Created by Bottle K on 2020/9/29.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM (NSInteger, TDSAccountType) {
    TAP,
    XD,
    XDG
};

@interface TDSAccount : NSObject
@property (nonatomic, copy, readonly) NSString *token;
@property (nonatomic, copy, readonly) NSString *kid;
@property (nonatomic, copy, readonly) NSString *access_token;
@property (nonatomic, copy, readonly) NSString *token_type;
@property (nonatomic, copy, readonly) NSString *mac_key;
@property (nonatomic, copy, readonly) NSString *mac_algorithm;

- (instancetype)initWithToken:(NSString *)token type:(TDSAccountType)type;

- (TDSAccountType)getAccountType;

@end

NS_ASSUME_NONNULL_END
