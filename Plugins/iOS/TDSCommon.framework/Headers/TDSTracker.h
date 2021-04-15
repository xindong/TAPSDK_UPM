//
//  TDSTracker.h
//  TDSCommon
//
//  Created by TapTap-David on 2021/1/15.
//

#import <Foundation/Foundation.h>
#import "TDSTrackerConfig.h"

NS_ASSUME_NONNULL_BEGIN

@interface TDSTracker : NSObject

- (instancetype)initWithConfig:(TDSTrackerConfig *)config;

- (void)track:(NSDictionary *)logContentsMap;

@end

NS_ASSUME_NONNULL_END
