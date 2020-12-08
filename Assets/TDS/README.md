# TapSDK

------

### 前提条件

* 安装Unity **5.6.4**或更高版本

* IOS **10**或更高版本

* Android 目标为**API19**或更高版本

### 1.添加TapSDK

* 使用Unity Pacakge Manager

```json
//在{project.hold}/Packages/manifest.json中添加以下代码
"dependencies":{
        "com.tds.sdk":"https://github.com/xindong/TAPSDK_UPM.git#0.0.1-alpha"
    }
```
* 导入TapSDK.unitypackage

### 2.配置TapSDK

### 3.接口描述

```c#
//命名空间均为
using TapSDK;
```

#### 3.1 TapSDK 初始化

##### 3.1.1 在.amsdef中添加引用

```json
{
    "name": "YourProject",
    "references": [
        "TDSCommon",//基础
        "TDSMoment",//动态
        "TDSLogin",//登陆
        "TDSCore",//基础
        "TDSTapDB"//TapDB
    ],
    "includePlatforms": [
        "Android",
        "iOS"
    ],
    ...
}
```

##### 3.1.2 初始化

```c#
// clientId 为 TapTap ClientId
TapSDK.TDSCore.Init(clientId);
```
##### 3.1.3 开启TapDB
```c#
//开启TDSTapDB
TapSDK.TDSCore.EnableTapDB(gameVersion,gameChannel);
```
##### 3.1.4 开启内嵌动态
```c#
//开启TDS内嵌动态
TapSDK.TDSCore.EnableMoment();
```

#### 3.2 TapSDK 登陆

```c#
//命名空间
using TDSLogin;
```

##### 3.2.1 初始化

```c#
/**
 *  TDSLogin初始化
 *  @param clientId TapTapId
 */
TapSDK.TDSLogin.Init(clientId);

/**
 *  TDSLogin初始化
 *  @param clientId TapTapId
 *  @param isCN true 大陆 false 非大陆
 *  @param isRoundCorner true 开启圆角 false 关闭圆角
 */
TapSDK.TDSLogin.Init(clientId,isCN,isRoundCorner);
```

##### 3.2.2 注册LoginCallback回调

调用 **TDSLogin.RegisterLoginCallback()** 来处理登陆结果回调

```c#
TapSDK.TDSLogin.RegisterLoginCallback(loginCallback);
```

如果登陆成功，则会回调 **LoginCallback.LoginSuccess(TDSAccessToken)**,登陆取消以及登陆失败则会相应的回调对应接口。

##### 3.2.3 开始登陆

```c#
/**
 * @params permissions 所需要的权限
 */
TapSDK.TDSLogin.StartLogin(string[] permissions);
```
##### 3.2.4 获取当前Token

```c#
TapSDK.TDSLogin.GetCurrentAccessToken((accessToken)=>
{
    //获取成功返回AccessToken
});
```

##### 3.2.5 获取Profile

```c#
TapSDK.TDSLogin.GetCurrentProfile((profile)=>
{
    //获取成功
});

TapSDK.TDSLogin.FetchProfileForCurrentAccessToken((profile)=>
{
    //获取成功
},(errorMsg)=>{
    //获取失败
});
```

##### 3.2.5 退出登录

```c#
TapSDK.TDSLogin.Logout();
```

#### 3.3 动态

#### 3.4 TapDB

##### 3.4.1 TapDB初始化

```c#
/**
 * TapDB 初始化
 * @param appId 控制台注册的AppId
 * @param channel 分包渠道
 * @param gameVersion 安装包版本号
 */
TapSDK.TDSTapDB.Init(appId,clientId,channel,gameVersion);
```

##### 3.4.2 记录一个用户
记录一个用户。当用户登陆时调用。
```c#
TapSDK.TDSTapDB.SetUser(userId);

/**
 * @param userId 用户ID
 * @param openId 通过第三方登陆获取的openId
 * @param loginType 第三方登陆枚举
 */
TapSDK.TDSTapDB.SetUser(userId,openId,loginType);
```
##### 3.4.3 用户名称
设置用户名。
```c#
TapSDK.TDSTapDB.SetName(name);
```
##### 3.4.4 用户等级
设置用户等级。用户登录或升级时调用
```c#
TapSDK.TDSTapDB.SetLevel(level);
```

##### 3.4.5 用户所在服务器
设置用户所在服务器。用户登陆或切换服务器时调用。
```c#
TapSDK.TDSTapDB.SetServer(server);
```
##### 3.4.6 充值
充值成功时调用。
```c#
/**
 *
 * @param orderId 订单Id
 * @param product 商品Id
 * @param amount 充值金额。单位分
 * @param currencyType 货币类型。国际通行三字母表示法，为空时默认CNY。参考：人民币 CNY，美元 USD；欧元 EUR
 * @param payment 长度大于0并小于等于256。充值渠道
 */
TapSDK.TDSTapDB.OnCharge(orderId,product,amount,currencyType,payment);
```

##### 3.4.7 自定义事件
推送自定义事件。需要在控制台预先进行配置。
```c#
/**
 *
 * @param eventCode 在控制台中的事件编码
 * @prarm properties 自定义时间的JSON字符串
 */
TapSDK.TDSTapDB.OnEvent(eventCode,properties);
```