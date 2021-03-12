//
//  bridge.h
//  bridge
//
//  Created by xe on 2020/10/15.
//  Copyright © 2020 xe. All rights reserved.
//

#import <Foundation/Foundation.h>

#import <TDSCommon/TDSBridgeTool.h>
#import <TDSCommon/TDSBridgeProxy.h>
#import <TDSCommon/TDSBridgeCallback.h>
#import <TDSCommon/TDSCommandTask.h>
#import <TDSCommon/TDSCommand.h>
#import <TDSCommon/TDSResult.h>

//! Project version number for bridge.
FOUNDATION_EXPORT double bridgeVersionNumber;

//! Project version string for bridge.
FOUNDATION_EXPORT const unsigned char bridgeVersionString[];

// In this header, you should import all the public headers of your framework using statements like #import <bridge/PublicHeader.h>

@interface TDSBridge : NSObject

@property (nonatomic, weak) id<TDSBridgeCallback>delegte;

+ (instancetype)instance;

- (void)callHandler:(NSString*) command;

- (void)registerHandler:(NSString*) command
      bridgeCallback:(id<TDSBridgeCallback>) callback;

@end


