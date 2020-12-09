//
//  bridge.h
//  bridge
//
//  Created by xe on 2020/10/15.
//  Copyright © 2020 xe. All rights reserved.
//

#import <Foundation/Foundation.h>

#import "TDSBridgeTool.h"
#import "TDSBridgeProxy.h"
#import "TDSBridgeCallback.h"
#import "TDSCommandTask.h"
#import "TDSCommand.h"
#import "TDSResult.h"

//! Project version number for bridge.
FOUNDATION_EXPORT double bridgeVersionNumber;

//! Project version string for bridge.
FOUNDATION_EXPORT const unsigned char bridgeVersionString[];

// In this header, you should import all the public headers of your framework using statements like #import <bridge/PublicHeader.h>

@interface TDSBridge : NSObject

@property (nonatomic, weak) id<TDSBridgeCallback>delegte;

+(instancetype) instance;

-(void) callHandler:(NSString*) command;

-(void) registerCallback:(id<TDSBridgeCallback>) callback;

-(void) registerHandler:(NSString*) command
      bridgeCallback:(id<TDSBridgeCallback>) callback;

@end


