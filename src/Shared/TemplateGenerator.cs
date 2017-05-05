using System.IO;
using System.Linq;
using System.Xml.Linq;
using EnvDTE;
using Newtonsoft.Json.Linq;

namespace TemplateCreator
{
    public class TemplateGenerator
    {
        public static string CreateProjectTemplate(Project proj)
        {
            string fullPath = proj.FullName;
            string dir = Path.GetDirectoryName(fullPath);
            string name = Path.GetFileNameWithoutExtension(fullPath);

            var win = new InfoCollectorDialog(name);
            win.CenterInVs();
            if (win.ShowDialog().GetValueOrDefault())
            {
                const string solutionTemplate = @"{
    ""author"": """",
    ""classifications"": [ ],
    ""description"": """",
    ""name"": """",
    ""defaultName"": """",
    ""identity"": """",
    ""groupIdentity"": """",
    ""tags"": { },
    ""shortName"": """",
    ""sourceName"": """",
    ""guids"": [ ]
}";

                var o = JObject.Parse(solutionTemplate);
                o["author"] = win.AuthorTextBox.Text;
                o["name"] = win.FriendlyNameTextBox.Text;
                o["defaultName"] = win.DefaultNameTextBox.Text;
                o["sourceName"] = Path.GetFileNameWithoutExtension(proj.FullName);
                o["shortName"] = win.ShortNameTextBox.Text;

                var guids = (JArray)o["guids"];
                string projectGuid = ExtractProjectGuid(fullPath);

                if (!string.IsNullOrEmpty(projectGuid))
                {
                    guids.Add(ExtractProjectGuid(fullPath));
                }

                return o.ToString();
            }

            return null;
        }

        private static string ExtractProjectGuid(string fullPath)
        {
            var doc = XDocument.Load(fullPath);
            XElement element = doc.Descendants().FirstOrDefault(x => x.Name.LocalName == "ProjectGuid");
            return element?.Value;
        }
    }
}
