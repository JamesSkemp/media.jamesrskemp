const fs = require('fs');
const xml2js = require('xml2js');
const stringKeys = ['title', 'console', 'version', 'price', 'notes'];

const xmlFile = fs.readFile('./xml/video_games.xml', (err, data) => {
	if (err) {
		throw err;
	}

	const parser = new xml2js.Parser();

	parser.parseString(data, function (err, result) {
		if (err) {
			throw err;
		}

		fs.writeFile('./json/video_games.json', JSON.stringify(result, videoGameXmlReplacer, '\t'), (err) => {
			if (err) {
				throw err;
			}
			console.log('Done');
		});
	});
});

function videoGameXmlReplacer(key, value) {
	if (value && typeof value === 'object' && value.hasOwnProperty('$') && !value.hasOwnProperty('game')) {
		// For the game elements, replace the generated $ with meta.
		value['meta'] = value['$'];
	}
	if (stringKeys.includes(key)) {
		if (key === "notes") {
			return value.toString().replace(/\s+/g, ' ').trim();
		}
		return value.toString();
	} else if (key === "date") {
		const stringValue = value.toString();
		if (stringValue === '[object Object]') {
			return null;
		}
		return stringValue;
	} else if (key === "own") {
		return value === "yes";
	} else if (key === "addOn" || key === "electronic" || key === "beat" || key === "used") {
		return value === "true";
	} else if (key === "system" || key === "purchase" || key === "sell") {
		return value[0];
	} else if (key === "place") {
		if (value[0].hasOwnProperty('_')) {
			return value[0]['_'];
		}
		return value[0];
	} else if (key === "id") {
		return Number(value);
	} else if (key === "$") {
		if (value.hasOwnProperty("xmlns:xsi")) {
			return undefined;
		}
		// We changed it to 'meta' above, so drop the game attributes as well.
		return undefined;
	} else if (key === "xmlns:xsi" || key === "xsi:noNamespaceSchemaLocation") {
		return undefined;
	}
	return value;
}
