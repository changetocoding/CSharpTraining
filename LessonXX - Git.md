# Lesson
Using Git Bash and Using Git on VSC
# Prior Homework assessment

# Lesson objectives
- Understand Source control, it's importance when working on group projects


# Lesson time to deliever:
Unknown...

# Teacher instruction 


# Course materials
### How to install
https://scribe.rip/devops-with-valentine/2021-how-to-install-git-on-windows-10-step-by-step-guide-1c9db500e734
- Add the git bash to command
- Default text editor: Use notepad++ or VScode instead of Vim

### GIT BASH:
You can tell you are on a git repo if you have this (branchName)
![image](https://user-images.githubusercontent.com/63453969/182826022-44ba6675-7934-49a7-b545-8a6316a3770c.png)

### CLONE
git clone repositorylink.git  
Eg: git clone https://github.com/changetocoding/WebLessonPlan.git

Right click within the folder you want to clone into and select "Git Bash Here"

After cloning, navigate into the folder to perform operations by typing cd clonedrepositoryfoldername

### TO UPDATE/UPLOAD A FILE TO THE REPOSITORY

git add "filename" (this instructs git to start keeping track of the file to be uploaded or updated)

git commit -m "a message for the commit" (this commits the file to be uploaded or updated)

git push


(To add all files!!!: git add .)

(To close out of comment window: :wq)


### TO GET UP-TO-DATE FILES FROM THE REPOSITORY
```
git pull
```

## Branches
### To create a branch
This will create a branch from the current branch so normally you want to do this on main
```
git checkout -b test-branch
```
### To switch to a branch
```
git checkout main
```
### To merge from main onto a feature branch you are working on
We first update main then we merge main into our feature branch
```
git checkout main
git pull
git checkout feature-branch
git merge main
```

## Using GIT in VS CODE

HOW TO PUSH A PROJECT FROM VSCODE TO GITHUB (TO LINK A REPOSITORY WITH VSCODE)
- Create a new repository for your project
- Open the project you want to upload in Vscode
- Initialise repository from the source control panel
- Add a remote repository: view, command palette, Git: Add remote (Enter repository url (ensure it ends with the extension of .git) and set a remote name)
- From your source control panel, enter a message, commit changes and push changes


HOW TO PULL A PROJECT FROM GITHUB TO VSCODE (CLONING A REPOSITORY FROM GITHUB)
- Go the VSCode: View, Command Palette, Git: Clone (Enter the repository url (ensure it ends with the extension of .git) and select a folder where you want to clone the files)

Note: You can follow same process to clone the repository of someone else

## Github
Surprisingly hard to teach.
Think should split so step by step walk through steps of how to create a repositiory on github  
Clone that repository locally  
Add a file to it  
Commit set up stream then push to it  

Then update file in vs code  
Stage the file commit  
Push it

Then update file again/add a new file  
Repeat same in git hub  

Then repeat in command line.

Must read by tutors & practitioners. These two links may help trainers come up with content for the lesson:
- https://dev.to/tracycss/git-and-github-for-beginners-po3  
- https://dev.to/ravirajthedeveloper/what-is-git-and-github-and-how-to-use-github-2mb1  
- https://dev.to/chrisachard/confused-by-git-here-s-a-git-crash-course-to-fix-that-4cmi  
- And this explained the concepts well: https://rachelcarmena.github.io/2018/12/12/how-to-teach-git.html  

# Recommendations
- Additional notes


# Homework
- The homework

