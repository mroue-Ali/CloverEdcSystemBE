using HandlebarsDotNet;
using System.IO;

namespace CloverEdc.Api;

public class CodeGeneration
{
    public static void Main(string[] args)
    {
        
        var models = new List<string> { "Site", "Study" }; // Add your models
        var templatesPath = "Templates"; // Adjust path if necessary
        var outputPath = "GeneratedCode"; // Adjust path for output
        
        Directory.CreateDirectory(outputPath);

        foreach (var model in models)
        {
            GenerateFile("RepositoryTemplate.hbs", templatesPath, outputPath, model, "Repository");
            GenerateFile("ControllerTemplate.hbs", templatesPath, outputPath, model, "Controller");
            GenerateFile("ServiceTemplate.hbs", templatesPath, outputPath, model, "Service");
        }
        
    }

    private static void GenerateFile(string templateName, string templatesPath, string outputPath, string modelName, string fileSuffix)
    {
        var templateContent = File.ReadAllText(Path.Combine(templatesPath, templateName));
        var template = Handlebars.Compile(templateContent);

        var data = new
        {
            ModelName = modelName,
            ModelNameLower = char.ToLowerInvariant(modelName[0]) + modelName.Substring(1)
        };

        var result = template(data);

        File.WriteAllText(Path.Combine(outputPath, $"{modelName}{fileSuffix}.cs"), result);
    }
}
