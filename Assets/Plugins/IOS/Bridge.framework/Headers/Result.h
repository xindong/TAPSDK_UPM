//
//  Result.h
//  EngineBridge
//
//  Created by xe on 2020/9/28.
//  Copyright © 2020 xe. All rights reserved.
//


#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface Result : NSObject

@property (nonatomic) int code;
@property (nonatomic) NSString* message;
@property (nonatomic) NSString* content;
@property (nonatomic) NSString* callbackId;

+(Result*) code:(int)code
                content:(NSString*)content
                callbackId:(NSString*)callbackId
                message:(NSString*)message;

-(NSString*)toJSON;

@end

NS_ASSUME_NONNULL_END
