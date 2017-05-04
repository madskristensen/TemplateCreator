# Template Creator

[![Build status](https://ci.appveyor.com/api/projects/status/p5ou4mbj7248lqho?svg=true)](https://ci.appveyor.com/project/madskristensen/templatecreator)

<!-- Update the VS Gallery link after you upload the VSIX-->
Download this extension from the [VS Gallery](https://visualstudiogallery.msdn.microsoft.com/[GuidFromGallery])
or get the [CI build](http://vsixgallery.com/extension/49719076-63de-4191-8f25-470f5fb3b6cb/).

---------------------------------------

Makes it easy to create templates for 'dotnet new'

See the [change log](CHANGELOG.md) for changes and road map.

## Features

- Generate template file

### Generate template file
Right-click the project you want to turn into a template and click *Create Template...*.

![Context menu project](art/context-menu-project.png)

That will create a folder called *.template.config* and add a file called *template.json* to it. The folder is not being added to the project, but exist on disk in the root of the project directory.

## Contribute
Check out the [contribution guidelines](.github/CONTRIBUTING.md)
if you want to contribute to this project.

For cloning and building this project yourself, make sure
to install the
[Extensibility Tools](https://visualstudiogallery.msdn.microsoft.com/ab39a092-1343-46e2-b0f1-6a3f91155aa6)
extension for Visual Studio which enables some features
used by this project.

## License
[Apache 2.0](LICENSE)