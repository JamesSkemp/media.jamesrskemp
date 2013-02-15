try {
	$("a[href*='http://']:not([href*='" + location.hostname + "'])").attr("rel", "external");
	// Track external links through Analytics.
	$("a[rel*='external']").click(function(){pageTracker._trackPageview('/outgoing/'+ $(this).attr('href'));});
	$("a[rel*='download']").click(function(){pageTracker._trackPageview('/download/'+ $(this).attr('href'));});
} catch (ex) {
}