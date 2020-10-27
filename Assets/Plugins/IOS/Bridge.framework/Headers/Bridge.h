//
//  bridge.h
//  bridge
//
//  Created by xe on 2020/10/15.
//  Copyright © 2020 xe. All rights reserved.
//

#import <Foundation/Foundation.h>

#import "BridgeTool.h"
#import "EngineBridgeProxy.h"
#import "BridgeCallback.h"
#import "Command.h"
#import "Result.h"

//! Project version number for bridge.
FOUNDATION_EXPORT double bridgeVersionNumber;

//! Project version string for bridge.
FOUNDATION_EXPORT const unsigned char bridgeVersionString[];

// In this header, you should import all the public headers of your framework using statements like #import <bridge/PublicHeader.h>

@interface Bridge : NSObject

@property (nonatomic, weak) id<BridgeCallback>delegte;

+(instancetype) instance;

-(void) callHandler:(NSString*) command;

-(void) registerCallback:(id<BridgeCallback>) callback;

-(void) registerHandler:(NSString*) command
      bridgeCallback:(id<BridgeCallback>) callback;

@end


