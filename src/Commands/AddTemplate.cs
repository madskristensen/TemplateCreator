using System;
using System.ComponentModel.Design;
using System.IO;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace TemplateCreator
{
    internal sealed class AddTemplate
    {
        private readonly Package _package;
        private Project _project;

        private AddTemplate(Package package, OleMenuCommandService commandService)
        {
            _package = package;

            var cmdId = new CommandID(PackageGuids.guidPackageCmdSet, PackageIds.AddTemplate);
            var cmd = new OleMenuCommand(Execute, cmdId);
            cmd.BeforeQueryStatus += BeforeQueryStatus;
            commandService.AddCommand(cmd);
        }

        public static AddTemplate Instance
        {
            get; private set;
        }

        private IServiceProvider ServiceProvider
        {
            get { return _package; }
        }

        public static void Initialize(Package package, OleMenuCommandService commandService)
        {
            Instance = new AddTemplate(package, commandService);
        }

        private void BeforeQueryStatus(object sender, EventArgs e)
        {
            var button = (OleMenuCommand)sender;
            button.Enabled = button.Visible = false;

            _project = VsHelpers.DTE.SelectedItems.Item(1)?.Project;
            string root = _project?.GetRootFolder();

            if (string.IsNullOrEmpty(root))
                return;

            string templateFile = Path.Combine(root, Constants.Folder, Constants.TemplateFileName);

            button.Enabled = button.Visible = !File.Exists(templateFile);
        }

        private void Execute(object sender, EventArgs e)
        {
            string json = TemplateGenerator.CreateProjectTemplate(_project);

            if (string.IsNullOrEmpty(json))
            {
                System.Diagnostics.Debug.Write("Could not generate the template");
                return;
            }

            string root = _project.GetRootFolder();

            string templateFile = Path.Combine(root, Constants.Folder, Constants.TemplateFileName);
            string folder = Path.GetDirectoryName(templateFile);

            Directory.CreateDirectory(folder);
            File.WriteAllText(templateFile, json);

            VsHelpers.OpenFileAndRefresh(templateFile);            
        }
    }
}
