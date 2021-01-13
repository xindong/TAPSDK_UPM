#!/bin/sh
 
#UNITY程序的路径#
UNITY_PATH=/Applications/Unity/Hub/Editor/2020.1.5f1c1/Unity.app/Contents/MacOS/Unity
 
#游戏程序路径#
PROJECT_PATH=/Users/xiaoyi/Documents/UnityProject/TDSSDKAllUnity
 
#在Unity中构建apk#
$UNITY_PATH -projectPath $PROJECT_PATH -executeMethod ProjectBuild.BuildForAndroid project-$1 -quit

echo "Apk生成完毕"