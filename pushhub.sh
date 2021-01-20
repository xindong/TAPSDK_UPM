#!/bin/sh
remoteUPM=0

checkRepoExist() {
  for repo in $(git remote -v); do
    echo $repo
    if [ $repo=upm ]; then
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
  
  git config --local http.postBuffer 524288000

  git subtree split --prefix=TDS --branch upm

  git checkout upm

  checkRepoExist

  if [ $remoteUPM=0 ]; then
    git remote add upm git@github.com:xindong/TAPSDK_UPM.git
  fi
  
  echo "currentBranch: $(git branch | grep "*")"

  git fetch upm

  git tag $1
  
  git push upm upm --tags
  
  git checkout $currBranch --force
fi
