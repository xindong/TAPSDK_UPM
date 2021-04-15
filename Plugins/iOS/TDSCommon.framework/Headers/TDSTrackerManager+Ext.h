//
//  TDSTrackerManager+Ext.h
//  TDSCommon
//
//  Created by TapTap-David on 2021/3/23.
//

#import <TDSCommon/TDSCommon.h>
#import <TDSCommon/UserModel.h>
#import <TDSCommon/PageModel.h>
#import <TDSCommon/ActionModel.h>
#import <TDSCommon/NetworkStateModel.h>
#import <TDSCommon/TDSTrackerManager.h>
NS_ASSUME_NONNULL_BEGIN

@interface TDSTrackerManager ()
- (TDSTrackerManager *(^)(UserModel *userModel))userModel;
- (TDSTrackerManager *(^)(ActionModel *actionModel))actionModel;
- (TDSTrackerManager *(^)(PageModel *pageModel))pageModel;
- (TDSTrackerManager *(^)(NetworkStateModel *networkModel))networkModel;
- (TDSTrackerManager *(^)(void))track;
@end

NS_ASSUME_NONNULL_END
