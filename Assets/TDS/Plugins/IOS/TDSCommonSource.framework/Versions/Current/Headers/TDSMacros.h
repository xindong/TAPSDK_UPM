//
//  TDSMacros.h
//  TDSCommonSource
//
//  Created by Insomnia on 2020/10/19.
//

#import <Foundation/Foundation.h>
#import "TDSmetamacro.h"

#ifndef TDS_LOCK
#define TDS_LOCK(lock) dispatch_semaphore_wait(lock, DISPATCH_TIME_FOREVER);
#endif

#ifndef TDS_UNLOCK
#define TDS_UNLOCK(lock) dispatch_semaphore_signal(lock);
#endif

#define TDSSemaphoreCreate \
static dispatch_semaphore_t signalSemaphore; \
static dispatch_once_t onceTokenSemaphore; \
dispatch_once(&onceTokenSemaphore, ^{ \
    signalSemaphore = dispatch_semaphore_create(1); \
});

#define TDSSemaphoreWait TDS_LOCK(signalSemaphore)
#define TDSSemaphoreSignal TDS_UNLOCK(signalSemaphore)

#ifndef weakify
#define weakify(...) \
tds_keywordify \
metamacro_foreach_cxt(tds_weakify_,, __weak, __VA_ARGS__)
#endif

#ifndef strongify
#define strongify(...) \
tds_keywordify \
_Pragma("clang diagnostic push") \
_Pragma("clang diagnostic ignored \"-Wshadow\"") \
metamacro_foreach(tds_strongify_,, __VA_ARGS__) \
_Pragma("clang diagnostic pop")
#endif

#define tds_weakify_(INDEX, CONTEXT, VAR) \
CONTEXT __typeof__(VAR) metamacro_concat(VAR, _weak_) = (VAR);

#define tds_strongify_(INDEX, VAR) \
__strong __typeof__(VAR) VAR = metamacro_concat(VAR, _weak_);

#if DEBUG
#define tds_keywordify autoreleasepool {}
#else
#define tds_keywordify try {} @catch (...) {}
#endif
