// See https://aka.ms/new-console-template for more information

using System.Xml.Linq;

Console.WriteLine("Hello, World!");

var xmlFile = Directory.EnumerateFiles(".", "*.pdb.xml", SearchOption.AllDirectories).FirstOrDefault();
if (xmlFile == null) return;

var xmlDoc = XDocument.Load(xmlFile);
var xmlSymbols = xmlDoc.Root!
    .Element("tables")!
    .Elements().First(x => x.Attribute("name")!.Value == "Symbols")
    .Elements().ToArray();

Console.WriteLine($"PDB XML Symbol Count: {xmlSymbols.Length}");

var numInvalidSymbols = 0;
foreach (var symbol in xmlSymbols)
{
    var nameAttr = symbol.Attribute("name")!;
    if (nameAttr.Value.Length > 2000)
    {
        Console.WriteLine($"Fixed Name: {nameAttr.Value}");
        nameAttr.Value = nameAttr.Value[..2000];
        numInvalidSymbols++;
    }
}

var outputFile = $"{Path.GetFileNameWithoutExtension(xmlFile)}_fixed.pdb.xml";
xmlDoc.Save(outputFile);

Console.WriteLine($"PDB XML Symbols Fixed: {numInvalidSymbols}\nOutput: {outputFile}");
