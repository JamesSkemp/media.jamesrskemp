// ==UserScript==
// @name		GameTrailers fixes
// @namespace	http://jamesrskemp.com/userscripts/001
// @description	Removes ads.
// @match		http://www.gametrailers.com/*
// @version		0.2
// ==/UserScript==


function addJQuery(callback) {
  var script = document.createElement("script");
  script.setAttribute("src", "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.2.min.js");
  script.addEventListener('load', function() {
    var script = document.createElement("script");
    script.textContent = "(" + callback.toString() + ")();";
    document.body.appendChild(script);
  }, false);
  document.body.appendChild(script);
}

// the guts of this userscript
function main() {
	/*window.jQuery('.ad_728x90').html('').removeClass('ad_728x90');*/
	window.jQuery('#video-player').attr('width', 640).attr('height', 360);
	window.jQuery('.add').html('').removeClass('add').removeAttr('id');
	window.jQuery('.share_buttons').html('');
}

// load jQuery and execute the main function
addJQuery(main);


document.getElementById('ContinuousPlay').checked = false;
document.getElementById('ContinuousPlay').setAttribute('id', 'ContinuousPlayFixed');
document.getElementById('ad_top').innerHTML = 'asdf';
document.getElementById('ad_top').setAttribute('id', 'ad_topFixed');

/*
960 - 640
540 - 360
*/