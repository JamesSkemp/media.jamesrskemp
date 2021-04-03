const fs = require('fs');
const xml2js = require('xml2js');

const xmlFile = fs.readFile('./xml/video_games.xml', (err, data) => {
	if (err) {
		throw err;
	}

	const parser = new xml2js.Parser();

	parser.parseString(data, function (err, result) {
		if (err) {
			throw err;
		}

		fs.writeFile('./json/video_games.json', JSON.stringify(result, null, '\t'), (err) => {
			if (err) {
				throw err;
			}
			console.log('Done');
		});
	});
});
