#!/bin/sh
export LANG="en_US.UTF-8"

CURRENT_BRANCH=${CI_MERGE_REQUEST_SOURCE_BRANCH_NAME}
echo "current branch is ${CURRENT_BRANCH}"
echo "merge  branch is ${CI_MERGE_REQUEST_SOURCE_BRANCH_NAME}"

echo $CI_REPOSITORY_URL
echo ${CI_REPOSITORY_URL#*@}

git remote set-url origin https://${CI_PUSH_USER}:${CI_PUSH_TOKEN}@git.gametaptap.com/$CI_PROJECT_PATH.git
git config --global user.name  "ci-gitlab"
git config --global user.email "tds-developer@xd.com"


git fetch origin;
git branch -D mr;
git checkout -f origin/master;
git checkout -b mr origin/master;
git checkout mr;
if [ $? -ne 0 ];then
  echo "切换到 mr 分支失败"
  exit 2;
fi;
git branch;
echo "merge begin from ${CURRENT_BRANCH}"

branches=$(java -jar ./.ci/release.jar list-mr)

for branch in $branches
do
  git merge origin/$branch -m "merge branch $branch by ci"
  if [ $? -ne 0 ]
  then
    echo "$branch 合并失败"
    java -jar ./.ci/release.jar message --title="${CI_PROJECT_TITLE} " --body="<${CI_MERGE_REQUEST_PROJECT_URL}|${CI_MERGE_REQUEST_LABELS}>  Merge Failed！"
    exit 2;
  fi;
done;

sdkVersion=$(java -jar .ci/release.jar nb-ver)

# 打 tag 并且推送到远程
if [ $? -eq 0 ]; then
  echo "开始打 tag nb-$sdkVersion"
  git tag nb-$sdkVersion
  git push origin nb-$sdkVersion
fi;

echo "send to slack end"