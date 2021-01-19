
echo "TapSDK Unity auto push start"

hasGit=`which git` #判断是否已安装git
if [ ! $hasGit ];then
  echo 'Please download git first!';
  exit 1;
else 
  # 获取当前分支
  branch=`git branch | grep "*"`
  # 截取分支名
  currBranch=${branch:2}
  
  echo $currBranch

  git subtree split --prefix=TDS --branch upm
  git checkout upm
  git tag $1
  git remote set-url upm git@github.com:xindong/TAPSDK_UPM.git
  git push upm upm --tags 
  git checkout $currBranch --force 
  
fi

echo "TapSDK Unity auto push finish!"

