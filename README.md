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
