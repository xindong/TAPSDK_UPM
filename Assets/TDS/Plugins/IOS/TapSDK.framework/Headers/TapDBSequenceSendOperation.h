//
//  TapDBSequenceSendOperation.h
//  TDSTapDBSource
//
//  Created by Jocer Ji on 2020/11/5.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TapDBSequenceSendOperation : NSOperation
@property(strong, nonatomic) NSDictionary *sendInfo;
@end

NS_ASSUME_NONNULL_END
