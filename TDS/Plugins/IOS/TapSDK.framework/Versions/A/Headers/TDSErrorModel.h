//
//  TDSErrorModel.h
//  TapSDK
//
//  Created by Insomnia on 2020/12/14.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSErrorModel : NSObject

@property (nonatomic, assign) NSInteger code;
@property (nonatomic, copy) NSString *error;
@property (nonatomic, copy) NSString *errorDescription;
@property (nonatomic, copy) NSString *msg;

@end

NS_ASSUME_NONNULL_END
