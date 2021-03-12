//
//  TDSConfig.h
//  TapSDK
//
//  Created by Insomnia on 2020/12/1.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM (NSInteger, TDSRegionType) {
    TDSRegionTypeCN,
    TDSRegionTypeIO
};

@interface TDSConfig : NSObject
@property (nonatomic, copy) NSString *clientId;
@property (nonatomic, assign) TDSRegionType region;
@end

NS_ASSUME_NONNULL_END
