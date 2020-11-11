//
//  TDSAchvVerticalListView.h
//  TDSAchievement
//
//  Created by TapTap-David on 2020/10/26.
//

#import <UIKit/UIKit.h>
#import "TDSAchvCollectionHeaderView.h"
#import "TDSAchvVCollectionViewCell.h"
#import "TDSAchvCollectionView.h"
NS_ASSUME_NONNULL_BEGIN

@interface TDSAchvVerticalListView : UIView
@property (nonatomic, copy) void(^cancelBlock)(void);
@property (nonatomic, strong) TDSAchvCollectionView *collectionView;
@property (nonatomic, assign) BOOL isTop;
- (void)setTotalAchievements:(NSInteger)totalCount completeNum:(NSInteger)count;
@end

NS_ASSUME_NONNULL_END
