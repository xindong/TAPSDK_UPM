# TDS 成就 SDK 说明文档 v1.0.0

## 1. 准备
* 接入 TapAchievement SDK

* 导入需要调用的头文件
    ```objectivec
    #import <TDSAchievement/TDSAchievementDelegate.h>
    #import <TDSAchievement/TDSAchievement.h>
    #import <TDSAchievement/TDSAchievementModel.h>
    ```
*  在编译选项‘Other Linker Flags’中加入「-ObjC」和 「-all_load」。

## 2. 设置回调
* 调用SDK接口后，结果以Protocol方式回调结果，调用者需要实现TDSAchievementDelegate.h中声明的方法。
```
// 回调必须在初始化 init 前设置才有效
注册方式 [TDSAchievement registerCallBack: xxx];
/*初始化成功*/
- (void)onAchievementSDKInitSuccess{
}

/*初始化失败*/
- (void)onAchievementSDKInitFail:(nullable NSError *)error{
}

/*成就状态变化*/
- (void)onAchievementStatusUpdate:(nullable TDSAchievementModel *)achievement
                          failure:(nullable NSError *)error{
}
```

## 3. 初始化
初始化前请先设置回调, init 会在回调内返回初始化结果, 只有在 `onAchievementSDKInitSuccess` 回调后才能进行成就的操作，失败时请重试或者提示玩家。
* Tips:如果使用心动登录SDK，请联系对接人员手动绑定Tap后台的appid和心动后台的appid，不然无法成功获得用户数据。
```
// appid 为注册游戏时获得的 clientId
// 使用TapTap登录时
TTSDKAccessToken *accessToken = [TTSDKAccessToken currentAccessToken];
NSString *tapTokenJson = [accessToken toJsonString];
[TDSAchievement initWithTAP:tapTokenJson appId:@"appid"];

// 使用心动登录SDK登录时
NSString *xdToken = [XDCore getAccessToken];
[TDSAchievement initWithXD:xdToken appId:@"appid"];
```

## 4. 成就数据解析
成就包含的数据含义如下，或许数据时请使用相对应的 get 方法
```
/*base*/
@property (nonatomic, copy, readonly) NSString *achievementId;  //成就Id
@property (nonatomic, copy, readonly) NSString *displayId;      //自行设置的id
@property (nonatomic, copy, readonly) NSString *achieveIcon;    //成就达成时的icon
@property (nonatomic, copy, readonly) NSString *title;          //标题
@property (nonatomic, copy, readonly) NSString *subTitle;       //副标题
@property (nonatomic, assign, readonly) NSInteger visible;      //是否是隐藏成就
@property (nonatomic, assign, readonly) NSInteger showOrder;    //当前成就在列表中的位置
@property (nonatomic, assign, readonly) NSInteger step;         //成就达成需要的步数
@property (nonatomic, assign, readonly) double createTime;      //成就创建时间

/*user*/
@property (nonatomic, assign) NSInteger fullReached;            //成就是否达成
@property (nonatomic, assign) double reachedTime;               //当前状态达成时间
@property (nonatomic, assign) NSInteger reachedStep;            //当前达成步数
```

## 5. 获取全部成就数据
全部成就列表分为本地数据（初始化时加载）和拉取远程数据（强制走网络获取）两个接口
```
// 本地数据
NSArray *allAchievementList = [TDSAchievement getLocalAllAchievementList];
// 远程数据 闭包返回
[TDSAchievement fetchAllAchievementList:^(NSArray<TDSAchievementModel *> * _Nullable result, NSError * _Nullable error) {
}]
```

## 6. 获取玩家已获取的成就数据
玩家已获取成就列表分为本地数据（初始化时加载）和拉取远程数据（强制走网络获取）两个接口
```
// 本地数据
NSArray *userAchievementList = [TDSAchievement getLocalUserAchievementList];

// 远程数据 闭包返回
[TDSAchievement fetchUserAchievementList:^(NSArray<TDSAchievementModel *> * _Nullable result, NSError * _Nullable error) {
}]
```

## 7. 达成成就
```
// 达成成就请传递自行配置的 DisplayID，达成后会在回调的 onAchievementStatusUpdate 方法内返回该成就当前状态
[TDSAchievement reach:@"displayId"];
```

## 8. 步长成就增长步数
成就增长步数提供两种方式调用 （需要参数 displayId 和 步数），`growSteps` 中传递当前增量达成的步数（例如：多走了5步，则传递5即可），`makeSteps` 中传递当前成就已达成的步数，(例如：当前已经走了100步，则传递100)，调用 `growSteps` 时SDK内部会计算当前全量步数
```
// 增量
[TDSAchievement growSteps:@"displayId" numSteps:5];
// 全量
[TDSAchievement makeSteps:@"displayId" numSteps:100];
```

## 9.状态码
```
//在回调的方法内返回错误均包含错误码，有几个特殊的情况需要单独处理
int SDK_NOT_INIT = 9001; // 未初始化或者初始化失败时调用初始化以外的接口
int ACHIEVEMENT_NOT_FOUND = 9002; // 更新成就时没有找到对应的成就内容
int UNAUTHORIZED = 401;// 当前用户身份过期，请重新触发登录流程，并使用登录完成后新的token调用init接口刷新成就系统数据
```
