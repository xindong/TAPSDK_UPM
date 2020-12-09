//
//  TDSMomentGCDTimer.h
//  TapMoment
//
//  Created by ritchie on 2020/7/30.
//  Copyright © 2020 TapTap. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSMomentGCDTimer : NSObject
+ (NSString*)timerTask:(void(^)(void))task
            start:(NSTimeInterval) start
         interval:(NSTimeInterval) interval
          repeats:(BOOL) repeats
             async:(BOOL)async;

+(void)canelTimer:(NSString*) timerName;
@end

NS_ASSUME_NONNULL_END
