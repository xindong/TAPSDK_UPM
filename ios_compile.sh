#!/bin/sh
 
#UNITY程序的路径#
UNITY_PATH=/Applications/Unity/Hub/Editor/2020.1.5f1c1/Unity.app/Contents/MacOS/Unity
 
#游戏程序路径#
PROJECT_PATH=/Users/xiaoyi/Documents/UnityProject/TDSSDKAllUnity
 
#在Unity中构建apk#
$UNITY_PATH -projectPath $PROJECT_PATH -executeMethod ProjectBuild.BuildForIOS -quit

echo "开始XCode build"

Project_Folder="TapSDKUnity"
#工程名字(Target名字)
Project_Name="Unity-iPhone"
#配置环境，Release或者Debug
Configuration="Release"
#加载各个版本的plist文件
EnterpriseExportOptionsPlist=$PROJECT_PATH/ExportOptions.plist

xcodebuild -project $PROJECT_PATH/$Project_Folder/$Project_Name.xcodeproj -scheme $Project_Name -configuration $Configuration -archivePath $PROJECT_PATH/$Project_Folder/build/$Project_Name-enterprise.xcarchive clean archive build

xcodebuild -exportArchive -archivePath $PROJECT_PATH/$Project_Folder/build/$Project_Name-enterprise.xcarchive -exportOptionsPlist $EnterpriseExportOptionsPlist -exportPath ~/Desktop/$Project_Name-enterprise.ipa
