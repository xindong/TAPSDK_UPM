//
//  EngineBridgeProxy.h
//  Bridge
//
//  Created by xe on 2020/10/15.
//  Copyright © 2020 xe. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "BridgeCallback.h"
#import "Bridge.h"

@interface EngineBridgeProxy : NSObject<BridgeCallback>

+(EngineBridgeProxy *)shareInstance;

-(void) onResult:(NSString*) result;

@end
