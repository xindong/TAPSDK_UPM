//
//  Header.h
//  TDSAchievement
//
//  Created by xe on 2020/10/15.
//  Copyright © 2020 taptap. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <Bridge/Bridge.h>

NS_ASSUME_NONNULL_BEGIN

@interface AchievementService : NSObject

+ (void)registerCallback:(void (^)(NSString *result))callback;

+ (void)xdToken:(NSString *)token appId:(NSString *)appId;

+ (void)tapToken:(NSString *)string appId:(NSString *)appId;

+ (void)fetchAllAchievementList:(void (^)(NSString *result))callback;

+ (void)fetchUserAchievementList:(void (^)(NSString *result))callback;

+ (void)displayId:(NSString *)displayId;

+ (void)displayId:(NSString *)displayId growStep:(NSInteger)numSteps;

+ (void)displayId:(NSString *)displayId numStep:(NSInteger)numSteps;

+ (void)getLocalAllAchievementList:(void (^)(NSString *result))callback;

+ (void)getLocalUserAchievementList:(void (^)(NSString *result))callback;

@end

NS_ASSUME_NONNULL_END
