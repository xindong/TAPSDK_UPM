//
//  TDSAchvHorizontalListView.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/10/30.
//

#import <UIKit/UIKit.h>
#import "TDSAchvCollectionHeaderView.h"
#import "TDSAchcHCollectionViewCell.h"
#import "TDSAchvCollectionView.h"
NS_ASSUME_NONNULL_BEGIN

@interface TDSAchvHorizontalListView : UIView
@property (nonatomic, copy) void(^cancelBlock)(void);
@property (nonatomic, strong) TDSAchvCollectionView *collectionView;
@property (nonatomic, assign) BOOL isTop;
- (void)setTotalAchievements:(NSInteger)totalCount completeNum:(NSInteger)count;
@end

NS_ASSUME_NONNULL_END
