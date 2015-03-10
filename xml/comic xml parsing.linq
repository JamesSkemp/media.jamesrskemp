<Query Kind="Statements">
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

var basePath = @"C:\Users\James\Projects\JamesRSkemp\JamesRSkemp.Media.Web\xml\";
var filePath = basePath + "Comics.xlsx - Comics.csv";
var xmlPath = basePath + "Comics.xml";

var xml = XDocument.Load(xmlPath);

List<Comic> comics = new List<Comic>();

XmlSerializer serializer = new XmlSerializer(comics.GetType());

StreamReader reader = new StreamReader(xmlPath);
comics = (List<Comic>)serializer.Deserialize(reader);
reader.Close();

comics.Select (c => c.AutoNumber).Max (c => c).Dump();

comics
	//.Where (c => c.DescriptiveName.Contains("Flaming"))
	.OrderBy (c => c.DescriptiveName)
	.Dump();
// 582 = 577
// 615 (last number) = 610
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
