//
//  TDSMomentGCDThrottle.h
//  TapMoment
//
//  Created by ritchie on 2020/7/30.
//  Copyright © 2020 TapTap. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN


typedef void (^TDSMomentGCDThrottleBlock) (void);


/** Throttle type */
typedef NS_ENUM(NSInteger, TDSMomentGCDThrottleType) {
    TDSMomentGCDThrottleTypeDelayAndInvoke,/**< Throttle will wait for [threshold] seconds to invoke the block, when new block comes, it cancels the previous block and restart waiting for [threshold] seconds to invoke the new one. */
    TDSMomentGCDThrottleTypeInvokeAndIgnore,/**< Throttle invokes the block at once and then wait for [threshold] seconds before it can invoke another new block, all block invocations during waiting time will be ignored. */
};


#pragma mark -
@interface TDSMomentGCDThrottle : NSObject

void dispatch_throttle(NSTimeInterval threshold, TDSMomentGCDThrottleBlock block);
void dispatch_throttle_on_queue(NSTimeInterval threshold, dispatch_queue_t queue, TDSMomentGCDThrottleBlock block);
void dispatch_throttle_by_type(NSTimeInterval threshold, TDSMomentGCDThrottleType type, TDSMomentGCDThrottleBlock block);
void dispatch_throttle_by_type_on_queue(NSTimeInterval threshold, TDSMomentGCDThrottleType type, dispatch_queue_t queue, TDSMomentGCDThrottleBlock block);



+ (void)throttle:(NSTimeInterval)threshold block:(TDSMomentGCDThrottleBlock)block;
+ (void)throttle:(NSTimeInterval)threshold queue:(dispatch_queue_t)queue block:(TDSMomentGCDThrottleBlock)block;
+ (void)throttle:(NSTimeInterval)threshold type:(TDSMomentGCDThrottleType)type block:(TDSMomentGCDThrottleBlock)block;
+ (void)throttle:(NSTimeInterval)threshold type:(TDSMomentGCDThrottleType)type queue:(dispatch_queue_t)queue block:(TDSMomentGCDThrottleBlock)block ignoreBlock:( nullable TDSMomentGCDThrottleBlock)ignoreBlock;

@end

NS_ASSUME_NONNULL_END
