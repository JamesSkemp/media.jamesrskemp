<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
	<xsl:template match="/">
		<html>
			<head>
				<title>CD listing for James Skemp</title>
				<style type="text/css">
					ul {
						list-style-type:none;
						margin-left:0.5em;
					}
				</style>
			</head>
			<body>
				<h1>CD listing for James Skemp</h1>
				<ul>
					<xsl:for-each select="albums/album">
						<xsl:sort select="artist"/>
						<xsl:sort select="title"/>
						<li><xsl:value-of select="artist"/> - <xsl:value-of select="title"/></li>
					</xsl:for-each>
				</ul>
				<br /><br /><br />
				<script type="text/javascript">
					var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
					document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
				</script>
				<script type="text/javascript">
					var pageTracker = _gat._getTracker("UA-541034-10");
					pageTracker._initData();
					pageTracker._trackPageview();
				</script>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>