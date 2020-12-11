# TapSDK

### 前提条件

* 安装Unity **Unity 2018.3**或更高版本

* IOS **10**或更高版本

* Android 目标为**API19**或更高版本

### 1.添加TapSDK

* 使用Unity Pacakge Manager

```json
//在YourProjectPath/Packages/manifest.json中添加以下代码
"dependencies":{
        "com.tds.sdk":"https://github.com/xindong/TAPSDK_UPM.git#0.0.4-alpha"
    }
```

### 2.配置TapSDK

#### 2.1 Android 配置

编辑Assets/Plugins/Android/AndroidManifest.xml文件,在Application Tag下添加以下代码。
```xml
    <activity
        android:name="com.taptap.sdk.TapTapActivity"
        android:configChanges="keyboard|keyboardHidden|screenLayout|screenSize|orientation"
        android:exported="false"
        android:theme="@android:style/Theme.Translucent.NoTitleBar.Fullscreen" />
```

#### 2.2 IOS 配置

在Assets/Plugins/IOS/Resource目录下创建TDS-Info.plist文件,复制以下代码并且替换其中的ClientId。
```xml
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
    <key>taptap</key>
    <dict>
        <key>client_id</key>
        <string>{Your-ClientId}</string>
    </dict>
</dict>
</plist>
```

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
        "TDSCommon",
        "TDSMoment",
        "TDSLogin",
        "TDSCore",
        "TDSTapDB"
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
//TapTap ClientId
TapSDK.TDSCore.Init(clientId);
```
##### 3.1.3 开启TapDB
```c#
TapSDK.TDSCore.EnableTapDB(gameVersion,gameChannel);
```
##### 3.1.4 开启内嵌动态
```c#
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
