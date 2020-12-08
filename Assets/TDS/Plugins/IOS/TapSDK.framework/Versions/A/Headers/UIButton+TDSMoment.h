//
//  UIButton+TDSMoment.h
//  TapMoment
//
//  Created by ritchie on 2020/7/28.
//  Copyright © 2020 TapTap. All rights reserved.
//

#import <UIKit/UIKit.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM(NSUInteger, __TTButtonEdgeInsetsStyle) {
    __TTButtonEdgeInsetsStyleTop, // image在上，label在下
    __TTButtonEdgeInsetsStyleLeft, // image在左，label在右
    __TTButtonEdgeInsetsStyleBottom, // image在下，label在上
    __TTButtonEdgeInsetsStyleRight // image在右，label在左
};

@interface UIButton (TapMoment)
- (void)tds_layoutButtonWithEdgeInsetsStyle:(__TTButtonEdgeInsetsStyle)style imageTitleSpace:(CGFloat)space;
@end

NS_ASSUME_NONNULL_END
