<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
	<xsl:template match="/">
		<html>
			<head>
				<title>Books Library Listing for <xsl:value-of select="/books/information/name" /></title>
			</head>
			<body>
				<h1>Books</h1>
				<p>The following books are contained in the library of <xsl:value-of select="/books/information/name" />.</p>
				<table>
					<thead>
						<tr>
							<td>Title</td>
							<td>Authors</td>
							<td>Read?</td>
						</tr>
					</thead>
					<tbody>
						<xsl:for-each select="/books/book">
							<xsl:sort select="title" data-type="text"/>
							<xsl:choose>
								<xsl:when test="sell/@sold"></xsl:when>
								<xsl:otherwise>
									<tr>
										<td><xsl:value-of select="title"/></td>
										<td><xsl:for-each select="authors/author"><xsl:value-of select="."/><br /></xsl:for-each></td>
										<td><xsl:value-of select="readings/@finished"/></td>
									</tr>
								</xsl:otherwise>
							</xsl:choose>
						</xsl:for-each>
					</tbody>
				</table>
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