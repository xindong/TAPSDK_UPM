//
//  TDSErrorDelegate.h
//  TapSDK
//
//  Created by Insomnia on 2020/12/10.
//

#import "TDSErrorModel.h"

@protocol TDSErrorDelegate <NSObject>

@optional

///  事件回调
/// @param code 事件code
/// @param msg 事件消息
/// @param err 错误信息
- (void)errorWithCode:(NSInteger)code msg:(NSString *)msg err:(TDSErrorModel *)err;

@end
