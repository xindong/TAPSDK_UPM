//
//  TDSNetClientConfig.h
//  TDSCommonSource
//
//  Created by Insomnia on 2020/10/20.
//

#import <Foundation/Foundation.h>
#import "TDSCommonHeader.h"

NS_ASSUME_NONNULL_BEGIN

@interface TDSNetConfigModel : NSObject
/// 可扩展头
@property (nonatomic, copy, nullable) NSString *baseUrl;
@property (nonatomic, copy, nullable) NSDictionary *extensionHeader;
@property (nonatomic, strong) TDSCommonHeader *commonHeader;
@end

NS_ASSUME_NONNULL_END
