﻿var JamesRSkemp = {
	LocalStorage: {
		isSupported: function () {
			try {
				return 'localStorage' in window && window['localStorage'] !== null;
			} catch (e) {
				return false;
			}
		},
		itemCount: function () {
			if (JamesRSkemp.LocalStorage.isSupported()) {
				return window.localStorage.length;
			}
			return 0;
		},
		bytesUsed: function () {
			if (JamesRSkemp.LocalStorage.isSupported()) {
				var total = 0;
				for (var i = 0; i < window.localStorage.length; i++) {
					total += window.localStorage.getItem(window.localStorage.key(i)).length;
				}
				return total;
			}
			return 0;
		}
	},
	ApplicationCache: {
		isSupported: function () {
			try {
				return 'applicationCache' in window && window['applicationCache'] !== null;
			} catch (e) {
				return false;
			}
		},
		currentStatus: function () {
			var cacheStatus = 'unknown';
			if (JamesRSkemp.ApplicationCache.isSupported()) {
				var cacheStatusValues = [];
				cacheStatusValues[0] = 'uncached';
				cacheStatusValues[1] = 'idle';
				cacheStatusValues[2] = 'checking';
				cacheStatusValues[3] = 'downloading';
				cacheStatusValues[4] = 'updateready';
				cacheStatusValues[5] = 'obsolete';

				cacheStatus = cacheStatusValues[window.applicationCache.status];
			}

			return cacheStatus;
		},
		checkForManifestUpdate: function () {
			if (JamesRSkemp.ApplicationCache.isSupported()) {
				window.applicationCache.update();
			}
			return;
		}
	},

	// HTML5
	supportsOffline: function () {
		return !!window.applicationCache;
	},
	browserOffline: function () {
		if (JamesRSkemp.supportsOffline() && 'onLine' in navigator) {
			return !navigator.onLine;
		}
		return false;
	},

	// Debugging
	dumpObject: function (o) {
		var objectInfo = "";
		var objectToDebug = o;
		objectInfo += "Type: " + typeof objectToDebug + "\n";
		objectInfo += "toString(): " + " value: [" + objectToDebug.toString() + "]\n";

		if (typeof objectToDebug === 'object') {
			for (var prop in objectToDebug) {
				objectInfo += "property: " + prop + " value: [" + objectToDebug[prop] + "]\n";
			}
		}
		alert(objectInfo);
	},
	recordConsoleMessage: function (message) {
		try {
			if (typeof (console) !== 'undefined') {
				console.log(message);
				return true;
			} else {
				//alert(message);
			}
		} catch (e) {
			dumpObject(e);
		}
		return false;
	}
};