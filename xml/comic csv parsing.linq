<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.VisualBasic.dll</Reference>
  <Namespace>Microsoft.VisualBasic.FileIO</Namespace>
</Query>

var basePath = @"C:\Users\James\Projects\JamesRSkemp\JamesRSkemp.Media.Web\xml\";
var filePath = basePath + "Comics.xlsx - Comics.csv";
var xmlPath = basePath + "Comics.xml";

TextFieldParser parser = new TextFieldParser(filePath);
parser.TextFieldType = FieldType.Delimited;
parser.SetDelimiters(",");
var line = 0;
var comics = new List<Comic>();
while (!parser.EndOfData) 
{
	//Processing row
	string[] fields = parser.ReadFields();

	if (fields[0] == "AutoNumber") {
		line++;
		continue;
	}

	var comic = new Comic();
	comic.AutoNumber = int.Parse(fields[0]);
	comic.DescriptiveName = fields[1];
	comic.Series = fields[2];
	comic.Volume = fields[3];
	comic.Number = fields[4];
	comic.PrintingEdition = fields[5];
	comic.Publisher = fields[6];
	comic.MonthYearPublished = fields[7];
	comic.Price = fields[8];
	comic.BoughtAt = fields[9];
	comic.BoughtDate = fields[10];
	comic.BoughtPrice = fields[11];
	comic.Quantity = fields[12];
	comic.Notes = fields[13];

	foreach (string field in fields) 
	{
		//field.Dump();
		//TODO: Process field
	}
	comics.Add(comic);
	line++;
}
parser.Close();

comics.Select (c => c.AutoNumber).Max (c => c).Dump();

comics
	//.Where (c => c.DescriptiveName.Contains("Batman"))
	//.Where (c => c.BoughtAt.Contains("Amazon"))
	.Dump();
// 582 = 577
// this is no longer necessary.
/*
System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(comics.GetType());
System.IO.StreamWriter file = new System.IO.StreamWriter(xmlPath);
writer.Serialize(file, comics);
file.Close();
*/
}

public class Comic {
	public int AutoNumber { get; set; }
	public string DescriptiveName { get; set; }
	public string Series { get; set; }
	public string Volume { get; set; }
	public string Number { get; set; }
	public string PrintingEdition { get; set; }
	public string Publisher { get; set; }
	public string MonthYearPublished { get; set; }
	public string Price { get; set; }
	public string BoughtAt { get; set; }
	public string BoughtDate { get; set; }
	public string BoughtPrice { get; set; }
	public string Quantity { get; set; }
	public string Notes { get; set; }

	public Comic() {
	}
