//
//  TDSMomentLoginHelper.h
//  TapMoment
//
//  Created by ritchie on 2020/10/21.
//  Copyright © 2020 JiangJiahao. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN



@interface TDSMomentLoginHelper : NSObject

typedef void(^TapTapLoginResultHandle)(NSDictionary *resultDic, BOOL success);

+ (void)taptapLogin:(TapTapLoginResultHandle)completion;
@end

NS_ASSUME_NONNULL_END
