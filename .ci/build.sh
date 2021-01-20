#!/bin/sh
export LANG="en_US.UTF-8"

BUILD_TYPE=$1

tag=${CI_COMMIT_TAG} 

echo $tag

buildFail() {
    java -jar ./.ci/release.jar message --title="${CI_PROJECT_TITLE} $BUILD_TYPE build " --body="<${CI_JOB_URL}|Package Failed>"
    exit 1
}

judgeResult() {
    if [ $? -ne 0 ]; then
        if [ -z "$1" ]; then
            echo "$1"
        else
            echo ">>     failed      <<\n"
        fi
        buildFail
    fi
}

java -jar ./.ci/release.jar message --title="${CI_PROJECT_TITLE} $BUILD_TYPE UPM Push " --body="<${CI_JOB_URL}|Package Start>"

project_dir=$(pwd)

uploadToGithub() {
    sh $project_dir/pushhub.sh $tag
}   

uploadToGithub

judgeResult "UPM push failed!"
java -jar ./.ci/release.jar message --title="TapSDK UPM Push Success" --body="<https://github.com/xindong/TAPSDK_UPM/tree/${tag}| https://github.com/xindong/TAPSDK_UPM#${tag}>"
judgeResult "UPM push failed!"
echo "send to slack end"