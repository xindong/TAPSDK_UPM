//
//  TDSErrorDelegate.h
//  TapSDK
//
//  Created by Insomnia on 2020/12/10.
//

@protocol TDSErrorDelegate <NSObject>

@optional

- (void)errorWithCode:(NSInteger)code msg:(NSString *)msg extras:(id)extras;

@end
