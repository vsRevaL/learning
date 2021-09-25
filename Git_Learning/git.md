# Git learning

## Git commands

| Command | Use case 
| ------- | --------
| `clone` | Bring a repository that is hosted somewhere like Github into a folder on you local machine. <br> `git clone [git@github.com:..]` <br>
| `status` | Shows all of the files that were updated, created, or deleted, but haven't been saved in a commit yet. <br> `git status` <br>
| `add` | Track your files and changes in Git. <br> `git add .` or `git add [filenames]` 
| `commit` | Save your files in Git. <br> `git commit -m "Added index.html, modified README.md" -m "some Description"` <br> we saved then commit, but it isn't live on Github yet. <br>
| `push` | Upload Git commits to a remote repo, like Github. <br> ` git push origin [branch (main is common)]` <br>
| `pull` | `git pull origin [branch name]` Download changes from remote repo to your local machine, the opposite of push. <br>
| `init` | This command turns a directory into an empty Git repository. This is the first step in creating a repository. After running git init, adding and committing files/directories is possible. (Initialize git repository in current folder.) `git init` <br>
| `remote`| Remote means somewhere else, but not on this computer; Add a reference to the remote repository on Github <br> `git remote add origin [git@github.com:...]` <br> `git remote -v` Shows any remote repositories that I've connected this repo <br> `git remote remove origin` If remote origin already exists. <br>
| `merge` | Integrate branches together. git merge combines the changes from one branch to another branch. For example, merge the changes made in a staging branch into the stable branch. <br> `git merge [branch name]`
| `branch` | Shows the branches. <br>  `git branch -d [branch name]` to delete branch
| `checkout` | `git checkout [new branch name]`to witch branch <br> `git checkout -b [name]` to create branch. <br>
| `diff` | `git diff [name of the branch]` Shows what changes have been made since the last commit, compares two versions of code
| `reset` | `git reset (filename)` to undo `add` <br> `git reset HEAD~1` to reset last commit <br> `git reset -hard [hash from git log` go back to previous commit
| `log` | log commits

### Create new repository using Github

- *(new) repository already exists on Github*
- `clone`
- `add`
- `commit`
- `push`

### What about starting a repository locally?

- `init`
- `add`
- `commit`
- *need to create a new repository on Github*
- `remote`  
- `push`

## Git Branching

- to push branch: ` git push --set-upstream origin [branch name]`
- pull request: request to have your code pulled into another branch.
- merge conflict: same files had been changed.

### Create branch, update a file, make a pull request, update code on local machine

- `checkout -b testbranch`
- *Make changes on that branch.*
- `add`
- `commit`
- *Now the changes only saved on the `testbranch` branch.*
- *Instead of `merge`, pushing changes on that branch (`testbranch` in this case) to Github and then making a pu (pull request) is more common.:*
- `git push --set-upstream origin testbranch`
- *Now lets make a pr from the `testbranch` to the main branch on Github, and then merge them!*


- *Now the changes aren't there yet on our local environment, so we need to `pull` them from Github.*   
- `git checkout main`
- `git pull origin main`
- *if successful, we can delete the `testbranch` branch.*
- `git branch -d testbranch`

### What if having a *merge conflict* ?

- `git checkout testb`
- *modify something*
- `add`
- `commit`
- `checkout main`
- *modify*
- `add`
- `commit`
- `checkout testb`
- `merge main` - shows error about conflict
- *we need to edit the conflict*
- `add`
- `commit`

## Undoing Git

- `log`
- *copy a hash*  
- `reset -hard`

## Forking

- Forking is making a copy of other people repository.
- To Fork, click Fork button on Github at a repository.

<br>

References: 
- http://guides.beanstalkapp.com/version-control/common-git-commands.html
- https://www.youtube.com/watch?v=RGOj5yH7evk
- https://www.youtube.com/watch?v=hZznWbEGv1U

<br>