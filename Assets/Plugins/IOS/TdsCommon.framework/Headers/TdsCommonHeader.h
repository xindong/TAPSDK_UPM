//
//  TdsCommonHeader.h
//  TdsCommon
//
//  Created by Bottle K on 2020/9/29.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TdsCommonHeader : NSObject

- (instancetype)init:(NSString *)sdkName
      sdkVersionCode:(NSString *)sdkVersionCode
      sdkVersionName:(NSString *)sdkVersionName;

- (NSString *)getXUAValue;
@end

NS_ASSUME_NONNULL_END
