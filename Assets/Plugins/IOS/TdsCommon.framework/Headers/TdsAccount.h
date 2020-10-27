//
//  TdsAccount.h
//  TdsCommon
//
//  Created by Bottle K on 2020/9/29.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM (NSInteger, TdsAccountType) {
    TAP,
    XD,
    XDG
};

@interface TdsAccount : NSObject
@property (nonatomic) NSString *token;
@property (nonatomic) NSString *kid;
@property (nonatomic) NSString *access_token;
@property (nonatomic) NSString *token_type;
@property (nonatomic) NSString *mac_key;
@property (nonatomic) NSString *mac_algorithm;

- (instancetype)init:(NSString *)token;

- (TdsAccountType)getAccountType;

@end

NS_ASSUME_NONNULL_END
