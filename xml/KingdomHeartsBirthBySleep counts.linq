<Query Kind="Statements" />

String xmlFile = @"C:\Users\James\Projects\JamesRSkemp\JamesRSkemp.Media.Web\xml\KingdomHeartsBirthBySleep.xml";

XDocument document = XDocument.Load(xmlFile);

var createdCommands = from commands in document.Descendants("Meld")
						select new {
							commands.Attribute("Command").Value
						};

var ingredient1Commands = from commands in document.Descendants("Meld")
						select new {
							commands.Elements("Ingredient").ElementAt(0).Value
						};

var ingredient2Commands = from commands in document.Descendants("Meld")
						select new {
							commands.Elements("Ingredient").ElementAt(1).Value
						};

var abilities = from ability in document.Descendants("Ability")
				select new {
					Name = ability.Attribute("Name").Value,
					Type = ability.Attribute("Type").Value,
					Maximum = ability.Attribute("Maximum").Value,
					Description = ability.Attribute("Description").Value,
					ability
				};
				
//abilities.Select(a => a.Name).Dump();

/*
createdCommands.Count().Dump();
createdCommands.Where(c => c.Value != "").Count().Dump();
createdCommands.Distinct().Where(c => c.Value != "").OrderBy(c => c.Value).Count().Dump();
ingredient1Commands.Distinct().Where(c => c.Value != "").OrderBy(c => c.Value).Count().Dump();
ingredient2Commands.Distinct().Where(c => c.Value != "").OrderBy(c => c.Value).Count().Dump();
createdCommands.Union(ingredient1Commands).Union(ingredient2Commands).Distinct().Where(c => c.Value != "").OrderBy(c => c.Value).Dump();
*/

var allCommands = from command in document.Descendants("Command")
					select new {
						Name = command.Attribute("Name").Value,
						Type = command.Attribute("Type").Value,
						Subtype = (command.Attribute("Subtype") != null ? command.Attribute("Subtype").Value : null),
						MaximumLevel = (command.Attribute("MaximumLevel") != null && command.Attribute("MaximumLevel").Value != "" ? (int?)int.Parse(command.Attribute("MaximumLevel").Value) : null),
						command
					};

//allCommands.OrderBy(c => c.Type).ThenBy(c => c.Subtype).ThenBy(c => c.Name).Dump();
//allCommands.Where(c => c.Subtype == "Defense").OrderBy(c => c.Type).ThenBy(c => c.Subtype).ThenBy(c => c.Name).Dump();
//allCommands.Where(c => c.Name == "Mine Shield").Dump();

String characterName = "Terra";// Terra Ven Aqua

var characterCommands = from commands in document.Element("KingdomHeartsBirthBySleep").Element("Characters").Elements("Character").Where(c => c.Attribute("Name").Value == characterName).Descendants("Command")
						select new {
							Id = commands.Attribute("Id").Value,
							Name = commands.Attribute("Name").Value,
							Type = commands.Attribute("Type").Value,
							Subtype = (commands.Attribute("Subtype") != null ? commands.Attribute("Subtype").Value : null)
						};

characterCommands.Dump();