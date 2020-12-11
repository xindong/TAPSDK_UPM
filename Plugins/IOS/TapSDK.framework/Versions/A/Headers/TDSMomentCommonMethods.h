//
//  TDSMomentCommonMethods.h
//  TapMoment
//
//  Created by JiangJiahao on 2020/8/12.
//  Copyright © 2020 JiangJiahao. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
NS_ASSUME_NONNULL_BEGIN

#define HEXColor(rgbValue) \
[UIColor colorWithRed:((float)((rgbValue & 0xFF0000) >> 16)) / 255.0 \
                green:((float)((rgbValue & 0xFF00) >> 8)) / 255.0 \
                blue :((float)(rgbValue & 0xFF)) / 255.0 alpha:1.0]

@interface TDSMomentCommonMethods : NSObject

+ (void)addShadowToView:(UIView *)targetView innerShadowColor:
(int)innerShadowColor outerShadowColor:(int)outerShadowColor shadowOffset:(CGSize)shadowOffset;

@end

NS_ASSUME_NONNULL_END
