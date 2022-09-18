# Working on this Repo

The following is a set of guidelines to help keep push/pull and merge issues at bay.

## Step 1 : Find or choose an issue
- Take a look at all the Open issues or create new issues
- Choose an issue to work on and assign yourself to it, so everyone knows it's being worked on
**Note** : Every change in this project should have an associated issue! 

## Step 2 : Fork the Repo.
- Fork this repository. This will create a 'local copy' of this repository on your Github Profile.
```
$ git clone https://github.com/<your-username>/stress-project
$ cd stress-project
$ git remote add upstream https://github.com/Kreateer/stress-project
```
- If you have already forked the project, update your copy before working.
```
$ git remote update
$ git checkout <branch-name>
$ git rebase upstream/<branch-name>
```
## Step 3 : Branch
Create a new branch. Use its name to identify the issue you're addressing.
```
# It will create a new branch with name Branch_Name and switch to that branch 
$ git checkout -b branch_name
```
## Step 4 : Work on the assigned issue
- Work on the issue(s) assigned to you. 
- Add all the files/folders needed.
- After you've made changes or additions to the project, add your changes to the branch you've just created:
```
# To add all new changes to the branch you checked out
$ git add .
```
## Step 5 : Commit
- To commit give a descriptive message, so that everyone can understand what changes you've made. In the Git CLI, you can do this by:
```
# This message gets associated with all the files you have changed
$ git commit -m 'message
```
- **NOTE**: A Pull Request should have **only one commit**. Multiple commits should be **squashed**(compiled into one).

## Step 6 : Push to Remote
- Once you're sure you've included everything you needed in your commit, upload your changes to your fork:
```
# To push your work to your remote repository
$ git push -u origin Branch_Name
```

## Step 7 : Pull Request
- Go to your repository in browser and click on **'Compare and Pull Requests'** (alternatively, you can use your preferred Git client to do PRs from). Then add a title and description to your pull request that explains your solution(s).

- Once your Pull Request has been submitted, it will be reviewed and merged if valid.

## Need more help?
You can refer to the following articles on basics of Git and Github in case you need a refresher:
- [Forking a Repo](https://help.github.com/en/github/getting-started-with-github/fork-a-repo)
- [Cloning a Repo](https://help.github.com/en/desktop/contributing-to-projects/creating-an-issue-or-pull-request)
- [How to create a Pull Request](https://opensource.com/article/19/7/create-pull-request-github)
- [Getting started with Git and GitHub](https://towardsdatascience.com/getting-started-with-git-and-github-6fcd0f2d4ac6)
- [Learn GitHub from Scratch](https://lab.github.com/githubtraining/introduction-to-github)