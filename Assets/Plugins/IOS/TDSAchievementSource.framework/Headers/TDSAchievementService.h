//
//  Header.h
//  TDSAchievement
//
//  Created by xe on 2020/10/15.
//  Copyright © 2020 taptap. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <TDSCommonSource/TDSBridge.h>

NS_ASSUME_NONNULL_BEGIN

@interface TDSAchievementService : NSObject

+ (void)registerBridgeCallback:(void (^)(NSString *result))callback;

+ (void)xdToken:(NSString *)token appId:(NSString *)appId;

+ (void)tapToken:(NSString *)string appId:(NSString *)appId;

+ (void)fetchAllAchievementList:(void (^)(NSString *result))callback;

+ (void)fetchUserAchievementList:(void (^)(NSString *result))callback;

+ (void)displayId:(NSString *)displayId;

+ (void)displayId:(NSString *)displayId growStep:(NSNumber *)numSteps;

+ (void)displayId:(NSString *)displayId numStep:(NSNumber *)numSteps;

+ (void)getLocalAllAchievementList:(void (^)(NSString *result))callback;

+ (void)getLocalUserAchievementList:(void (^)(NSString *result))callback;

+ (void)showAchievementPage;

@end

NS_ASSUME_NONNULL_END
