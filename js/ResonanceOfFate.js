/// <reference path="/js/jquery-vsdoc.js" />
if (typeof ($) != undefined) {
	$(document).ready(function () {
		$.ajax({
			url: "/xml/ResonanceOfFate.xml",
			success: function (data) {
				var htmlOutput = "";
				$(data).find("Mission").each(function () {
					htmlOutput += "<p>" + $(this).attr('title') + "</p>";
				});
				$('#ResonanceOfFateData').html(htmlOutput);
			}
		});
	});
}