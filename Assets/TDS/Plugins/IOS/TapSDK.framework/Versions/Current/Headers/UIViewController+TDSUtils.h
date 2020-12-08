//
// Created by 孙毅 on 2018/9/27.
// Copyright (c) 2018 xd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

//from https://stackoverflow.com/questions/24825123/get-the-current-view-controller-from-the-app-delegate
@interface UIViewController (Utils)

+(UIViewController*)tds_currentViewController;

@end
