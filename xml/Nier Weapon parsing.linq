<Query Kind="Statements" />

XDocument weaponsXml = XDocument.Load(@"C:\Users\James\Projects\JamesRSkemp\JamesRSkemp.Media.Web\xml\NierWeapons.xml");

var items = weaponsXml
				.Descendants()
				.Elements("Item")
				.Select(i => new WeaponItem { Name = i.Attribute("Name").Value, Quantity = i.Attribute("Quantity") != null ? int.Parse(i.Attribute("Quantity").Value) : 1 })
				.OrderBy(i => i.Name).ThenBy(i => i.Quantity)
				;

var itemsGrouped = items.GroupBy(i => i.Name).Select(g => new WeaponItem { Name = g.Key, Quantity = g.Sum(i => i.Quantity) });

//items.Dump();
itemsGrouped.Dump();

}
public class WeaponItem {
	public string Name {get;set;}
	public int Quantity {get;set;}
