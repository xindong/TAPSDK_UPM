//
//  Command.h
//  EngineBridge
//
//  Created by xe on 2020/9/28.
//  Copyright © 2020 xe. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN


@interface Command : NSObject

@property (nonatomic) NSString* service;
@property (nonatomic) NSString* method;
@property (nonatomic) NSString* args;
@property (nonatomic) NSString* callbackId;
@property (nonatomic) BOOL callback;

+(Command*) constructorCommand:(NSString*)commandJSON;

-(NSString*) toJSON;

@end

NS_ASSUME_NONNULL_END
