# Template Creator

[![Build status](https://ci.appveyor.com/api/projects/status/p5ou4mbj7248lqho?svg=true)](https://ci.appveyor.com/project/madskristensen/templatecreator)

Download this extension from the [VS Marketplace](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.TemplateCreator)
or get the [CI build](http://vsixgallery.com/extension/49719076-63de-4191-8f25-470f5fb3b6cb/).

---------------------------------------

Makes it easy to create templates for 'dotnet new'

See the [change log](CHANGELOG.md) for changes and road map.

## Features

- Generate template file
- Add Visual Studio host file
- Add .NET CLI host file

### Generate template file
Right-click the project you want to turn into a template and click *Create Template...*.

![Context menu project](art/context-menu-project.png)

That will create a folder called *.template.config* and add a file called *template.json* to it. The folder is not being added to the project, but exist on disk in the root of the project directory.

![Solution Explorer](art/solution-explorer.png)

## Add Visual Studio/.NET CLI host files
To have the template show up in the ASP.NET project dialog, you need to add a Visual Studio specific host file to the *.template.config* folder.

![Add host files](art/add-host-files.png)

To control the CLI experience using *dotnet new* you need a .NET CLI specific host file.

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