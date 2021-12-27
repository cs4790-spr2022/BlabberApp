# BlabberApp

BlabberApp a Twitter-like .NETcore class project that will be used throughout this semester.  Each assignment will use the same project directory and be identified using `git tags` such as `hw01`, `hw02`, etc.  I will grade the assignment with the specified tag, so be sure to complete the assignment before you tag it! Both the code and the tag needs to be pushed to Github to receive credit.

You can do your development on your own personal computer or use the class server at `ubuntu-s-1vcpu-1gb-sfo2-01` IP:64.225.37.60

## SSH Tunneling

SSH tunneling or port forwarding is a technique for viewing a remote web server on your local machine.  It makes it look like the web server is running locally when actually it is running in your account on the class server.  Here is detailed information: [SSH Port Forwarding](https://www.ssh.com/ssh/tunneling/example).  Here is an example of my personal port fowarding command:

`ssh 64.225.37.60 -L 5041:localhost:5041 -N`

This technique should only be used if you are doing your development on the class server at `ubuntu-s-1vcpu-1gb-sfo2-01` IP:64.225.37.60

## Homework 01 (85 points)

In this assignment you will be setting up your development environment.  Again, this can be on your computer or on the class server.

Run `dotnet --info` to ensure you have at least **6.0.0** or greater and NO other version installed.  Should look something like this:

```
.NET SDK (reflecting any global.json):
 Version:   6.0.101
 Commit:    ef49f6213a

Runtime Environment:
 OS Name:     Mac OS X
 OS Version:  12.1
 OS Platform: Darwin
 RID:         osx.12-x64
 Base Path:   /usr/local/share/dotnet/sdk/6.0.101/

Host (useful for support):
  Version: 6.0.1
  Commit:  3a25a7f1cc

.NET SDKs installed:
  6.0.101 [/usr/local/share/dotnet/sdk]

.NET runtimes installed:
  Microsoft.AspNetCore.App 6.0.1 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 6.0.1 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
```

The tag for this assignment will be `hw01`.  Execute the commands below to setup your BlabberApp solution.

- `mkdir -p BlabberApp`
- `cd BlabberApp`
- `dotnet new webapp -o Client --no-https`
- `cd Client`
- `dotnet build`

Execute the command below to run your BlabberApp client application:

- `dotnet run`
- Open your browser
- In the address bar enter `https:\\localhost:5001`.

**NOTE**: If you have changed the port in your `Properties/launchSettings.json` file use that port number instead.

When totally complete execute these commands:

- `dotnet clean`
- `cd ..`
- `touch .gitignore`
- `edit .gitignore`
-- `add "obj"`
- `git init`
- `git add .`
- `git commit -m "Initial commit"`
- `git tag vhw01`
- `git remote add origin https://github.com/cs4790-spr2022/dbs67-BlabberApp.git`
- `git push -u master origin`

