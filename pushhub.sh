#!/bin/sh
remoteUPM=0

checkBranchExist() {
  for repo in $(git remote -v); do
    if [ "$repo"="upm" ]; then
      remoteUPM=1
    fi
  done
}

hasGit=$(which git) #判断是否已安装git
if [ ! $hasGit ]; then
  echo 'Please download git first!'
  exit 1
else
  # 获取当前分支
  branch=$(git branch | grep "*")
  # 截取分支名
  currBranch=${branch:2}
  echo $currBranch
  git subtree split --prefix=TDS --branch upm

  git checkout upm

  checkBranchExist

  if [ $remoteUPM=1 ]; then
    echo "Github remove upm repo"
    git remote rm upm
  fi
  git remote add upm git@github.com:xindong/TAPSDK_UPM.git
  git fetch upm
  echo "Github add upm repo"
  git push upm upm --tags
  git checkout $currBranch --force
fi
