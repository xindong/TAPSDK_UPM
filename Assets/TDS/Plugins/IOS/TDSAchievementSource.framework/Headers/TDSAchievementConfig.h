//
//  TDSAchievementConfig.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/9/14.
//  Copyright © 2020 taptap. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TDSAchievement.h"

NS_ASSUME_NONNULL_BEGIN


@interface TDSAchievementConfig : NSObject

@property (nonatomic, copy) NSString *xdUserId;

@property (nonatomic, copy) NSString *tapUserId;

@property (nonatomic, copy) NSString *fileId;

+ (instancetype)sharedConfig;

@end

NS_ASSUME_NONNULL_END
