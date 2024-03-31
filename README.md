# Introduction

TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project.

## Getting Started

TODO: Repository contains the agreed folder structure that the project should contain.
Each folder reflects an Azure resource.
Please remove unnecessary folders from the repository.

TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:

1. Installation process
2. Software dependencies
3. Latest releases
4. API references

## Build and Test

### Setup your app for the first time on VScode:

Build the app

```bash
dotnet build -t:InstallAndroidDependencies -f:net8.0-android -p:AndroidSdkDirectory="/home/ikostov2/.android/android-sdk" -p:JavaSdkDirectory="/usr/lib/jvm/java-17-openjdk-amd64" -p:AcceptAndroidSDKLicenses=True

```

Run your emulator, afterwards get the device id by using

```bash

adb devices
```

Finally install your app by using

```bash
dotnet run --framework net8.0-android --device:5554
```

### Rebuild your app to install the latest changes

```bash

dotnet build -t:Run -f net8.0-android -p:DeviceId=emulator-5554
```

## Contribute

TODO: Explain how other users and developers can contribute to make your code better.

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:

- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)
