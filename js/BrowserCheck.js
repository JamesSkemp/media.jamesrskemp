function createBaseContainer(containerElem) {
	if (containerElem) {
		containerElem.style.display = 'block';
		containerElem.style.fontFamily = 'sans-serif';
		containerElem.style.fontSize = '11px';
		containerElem.style.textAlign = 'center';
		containerElem.style.textDecoration = 'none';
		containerElem.style.padding = '0.5em';
		containerElem.style.position = 'absolute';
		containerElem.style.top = '0';
		containerElem.style.right = '0';
		containerElem.style.width = '400px';
		containerElem.style.zIndex = '999999';
	}
}
function oldBrowser(browser) {
	var block = document.createElement('a');
	block.setAttribute('id', 'jrs_BrowserCheck');
	createBaseContainer(block);
	block.setAttribute('href', 'http://strivinglife.com/browser/old/' + escape(browser) + '/');
	block.setAttribute('target', '_blank');
	block.style.backgroundColor = '#fcf';
	block.style.border = '1px solid #c9c';
	browserLanguage = document.createTextNode("It looks like you're using an old version of " + browser + ". If able, please consider upgrading. (Click here to find out more.)");
	block.appendChild(browserLanguage);
	document.body.appendChild(block);
}
function newBrowser(browser) {
	var block = document.createElement('a');
	block.setAttribute('id', 'jrs_BrowserCheck');
	createBaseContainer(block);
	block.setAttribute('href', 'http://strivinglife.com/browser/new/' + escape(browser) + '/');
	block.setAttribute('target', '_blank');
	block.style.backgroundColor = '#cfc';
	block.style.border = '1px solid #c9c';
	browserLanguage = document.createTextNode("Using the new version of " + browser + ", eh? Very nice.");
	block.appendChild(browserLanguage);
	document.body.appendChild(block);
}
function currentBrowser(browser) {
	var block = document.createElement('a');
	block.setAttribute('id', 'jrs_BrowserCheck');
	createBaseContainer(block);
	block.setAttribute('href', 'http://strivinglife.com/browser/current/' + escape(browser) + '/');
	block.setAttribute('target', '_blank');
	block.style.backgroundColor = '#ffc';
	block.style.border = '1px solid #c9c';
	browserLanguage = document.createTextNode("Well, you're either using the current version of your browser, or I'm not checking for it.");
	block.appendChild(browserLanguage);
	document.body.appendChild(block);
}
try {
	if (navigator.userAgent && (window.addEventListener || window.attachEvent)) {
		var browser = navigator.userAgent;
		var oldIE = (browser.indexOf("MSIE 6") >= 0) ? true : false;
		var newIE = (browser.indexOf("MSIE 8") >= 0) ? true : false;
		var oldFF = (browser.indexOf("Firefox/1") >= 0 || browser.indexOf("Firefox/2") >= 0) ? true : false;
		var oldNN = (browser.indexOf("Netscape/") >= 0) ? true : false;
		var oldO = false;
		var oldC = (browser.indexOf("Chrome/0.") >= 0) ? true : false; // Chrome must be checked before Safari.
		var oldS = (browser.indexOf("Safari/") >= 0 && (browser.indexOf("Version/3.0") >= 0 || browser.indexOf("Version/3.1") >= 0)) ? true : false;
		if (oldIE) {
			if (window.addEventListener) {
				window.addEventListener("load", function() { oldBrowser('Internet Explorer'); }, false);
			} else {
				window.attachEvent("onload", function() { oldBrowser("Internet Explorer"); });
			}
		} else if (oldFF) {
			if (window.addEventListener) {
				window.addEventListener("load", function() { oldBrowser('Firefox'); }, false);
			} else {
				window.attachEvent("onload", function() { oldBrowser('Firefox'); });
			}
		} else if (oldNN) {
			if (window.addEventListener) {
				window.addEventListener("load", function() { oldBrowser('Netscape'); }, false);
			} else {
				window.attachEvent("onload", function() { oldBrowser('Netscape'); });
			}
		} else if (oldO) {
			if (window.addEventListener) {
				window.addEventListener("load", function() { oldBrowser('Opera'); }, false);
			} else {
				window.attachEvent("onload", function() { oldBrowser('Opera'); });
			}
		} else if (oldC) {
			if (window.addEventListener) {
				window.addEventListener("load", function() { oldBrowser('Chrome'); }, false);
			} else {
				window.attachEvent("onload", function() { oldBrowser('Chrome'); });
			}
		} else if (oldS) {
			if (window.addEventListener) {
				window.addEventListener("load", function() { oldBrowser('Safari'); }, false);
			} else {
				window.attachEvent("onload", function() { oldBrowser('Safari'); });
			}
		} else if (newIE) {
			if (window.addEventListener) {
				window.addEventListener("load", function() { newBrowser('Internet Explorer'); }, false);
			} else {
				window.attachEvent("onload", function() { newBrowser('Internet Explorer'); });
			}
		} else {
			/*if (window.addEventListener) {
			window.addEventListener("load", function() { currentBrowser(''); }, false);
			} else {
			window.attachEvent("onload", function() { currentBrowser(''); });
			}*/
		}
	}
} catch (e) { }