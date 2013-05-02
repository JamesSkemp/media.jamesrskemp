<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Extensions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Activation.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Client.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Entity.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Namespace>System.Web.Script.Serialization</Namespace>
</Query>

XDocument xml = XDocument.Load(@"C:\Users\James\Projects\GitHub\JamesRSkemp\JamesRSkemp.Media.Web\xml\video_games.xml");

var datum = from x in xml.Descendants("game")
	//where x.Element("own").Value == "yes" && x.Attribute("addOn") == null
		//&& x.Element("system").Element("console").Value == "PlayStation"
		//&& x.Attribute("electronic") == null
	select new {
		Id = x.Attribute("id").Value,
		Title = x.Element("title").Value,
		System = string.Concat(x.Element("system").Element("console").Value, " ", x.Element("system").Element("version").Value).Trim(),
		Notes = x.Element("notes").Value,
		Own = x.Element("own").Value,
		Date = x.Element("purchase").Element("date").Value,
		Price = x.Element("purchase").Element("price").Value,
		Place = x.Element("purchase").Element("place").Value,
		SellDate = x.Element("sell") == null || x.Element("sell").Element("date") == null ? "" : x.Element("sell").Element("date").Value,
		SellPrice = x.Element("sell") == null || x.Element("sell").Element("price") == null ? "" : x.Element("sell").Element("price").Value,
		SellPlace = x.Element("sell") == null || x.Element("sell").Element("place") == null ? "" : x.Element("sell").Element("place").Value,
		AddOn = x.Attribute("addOn") != null ? x.Attribute("addOn").Value : "",
		Electronic = x.Attribute("electronic") != null ? x.Attribute("electronic").Value : "",
		Beat = x.Attribute("beat") != null ? Boolean.Parse(x.Attribute("beat").Value) : false,
		//X = x
	};


JavaScriptSerializer serializer = new JavaScriptSerializer();
var output = serializer.Serialize(new { VideoGames = datum});

File.WriteAllText(@"C:\Users\James\Projects\GitHub\JamesRSkemp\JamesRSkemp.Web\App_Data\Projects\VideoGameProfile\VideoGames.json", output);
File.WriteAllText(@"C:\Users\James\Projects\GitHub\VideoGamesSpa\SimpleWebsite\Content\json\VideoGames.json", output);

output.Dump();