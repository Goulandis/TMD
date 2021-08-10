## 克隆仓库

```
git clone <仓库地址>
```

## 查看当前分支

```
git branch
```

## 查看所有分支

```
git branch -a
```

## 切换本地分支

```
git checkout <本地分支名>
```

## 下载远程分支到本地分支

```
git checkout -b <本地分支名> <远程分支名>
```

远程分支名一般为`origin/远程仓库名`

## 删除本地分支

```
git branch -D <本地分支名>
```

## 新建本地分支

```
git branch <新分支名>
```

## 提交本地分支到仓库

```
git push origin <分支名>
```



## 查看本地仓库修改状态

```
git status
```

## 清除本地所有修改(未add)

```
git clean -df .
```

## 查看提交日志

```
git log <文件路径>
```

加文件路径则查看指定文件的提交日志，不加则查看所有的提交日志

## 查看所有文件的修改

```
git diff
```

## 查看指定文件的修改

```
git diff <文件路径>
```

## 还原所有文件的修改

```
git checkout
```

## 还原指定文件的修改

```
git checkout <文件路径>//多个文件之间用空格隔开
```

## Add指定文件

```
git add <文件路径>
```

多文件用空格隔开

## 回退Add的操作

有时我们会直接`git add .`可能会将我们不想往上传的文件给add了，此时可以使用

```
git reset <文件路径>
```

单独的git reset是回退所有add操作，git reset <文件路径>可以指定回退某一个文件，多文件用空格隔开。

## 撤销Commit

```
git reset --hard HEAD^
```

HEAD指向当前节点的指针，HEAD^指向前一个结点的指针

## 查看Commit提交

```
git show
```
