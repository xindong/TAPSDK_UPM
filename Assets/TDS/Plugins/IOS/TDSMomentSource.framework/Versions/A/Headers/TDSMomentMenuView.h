//
//  TDSMomentMenuView.h
//  TapMoment
//
//  Created by JiangJiahao on 2020/8/12.
//  Copyright © 2020 JiangJiahao. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

NS_ASSUME_NONNULL_BEGIN
typedef void(^ItemClickCallback)(void);

@interface TDSMomentMenuItem : NSObject

@property (nonatomic) NSString *imageName;
@property (nonatomic) NSString *title;
@property (nonatomic) ItemClickCallback callback;

+ (TDSMomentMenuItem *)createMenuItem:(NSString *)title image:(NSString *)imageName callback:(ItemClickCallback)callback;

@end

@interface TDSMomentMenuView : UIView

+ (TDSMomentMenuView *)createMenuView:(NSArray *)items;

- (void)showInView:(UIView *)targetView;
- (void)dismiss;

@end

NS_ASSUME_NONNULL_END
