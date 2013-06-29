<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:xs="http://www.w3.org/2001/XMLSchema" exclude-result-prefixes="xs" version="2.0">
	<xd:doc xmlns:xd="http://www.oxygenxml.com/ns/doc/xsl" scope="stylesheet">
		<xd:desc>
			<xd:p><xd:b>Created on:</xd:b> Oct 12, 2009</xd:p>
			<xd:p><xd:b>Author:</xd:b> James Skemp</xd:p>
			<xd:p></xd:p>
		</xd:desc>
	</xd:doc>
	<xsl:template match="/">
		<html>
			<head>
				<title><xsl:value-of select="/blades/title"/></title>
				<style type="text/css">
					tbody tr {
					}
					.kisukeOdd {
						background-color:#9cf;
					}
					.kisukeEven {
						background-color:#69c;
					}
					.momohimeOdd {
						background-color:#f9c;
					}
					.momohimeEven {
						background-color:#f99;
					}
					.sharedOdd {
						background-color:#fcf;
					}
					.sharedEven {
						background-color:#f9f;
					}
				</style>
			</head>
			<body>
				<h1><xsl:value-of select="/blades/title"/></h1>
				<p><xsl:value-of select="blades/description"/></p>
				<table border="1" cellpadding="3" cellspacing="0" summary="">
					<thead>
						<tr>
							<th>Blade name</th>
							<th>Blade type</th>
							<th>Attack</th>
							<th>Secret art</th>
							<th>Effect</th>
							<th>Character</th>
							<th>Note(s)</th>
						</tr>
					</thead>
					<tbody>
						<xsl:for-each select="blades/blade">
							<tr>
								<xsl:choose>
									<xsl:when test="(position() mod 2) = 0">
										<xsl:choose>
											<xsl:when test="character = 'Kisuke'"><xsl:attribute name="class">kisukeEven</xsl:attribute></xsl:when>
											<xsl:when test="character = 'Momohime'"><xsl:attribute name="class">momohimeEven</xsl:attribute></xsl:when>
											<xsl:when test="character = 'shared'"><xsl:attribute name="class">sharedEven</xsl:attribute></xsl:when>
										</xsl:choose>
									</xsl:when>
									<xsl:otherwise>
										<xsl:choose>
											<xsl:when test="character = 'Kisuke'"><xsl:attribute name="class">kisukeOdd</xsl:attribute></xsl:when>
											<xsl:when test="character = 'Momohime'"><xsl:attribute name="class">momohimeOdd</xsl:attribute></xsl:when>
											<xsl:when test="character = 'shared'"><xsl:attribute name="class">sharedOdd</xsl:attribute></xsl:when>
										</xsl:choose>
									</xsl:otherwise>
								</xsl:choose>
								<td><xsl:value-of select="name"/></td>
								<td><xsl:value-of select="type"/></td>
								<td><xsl:value-of select="attack"/></td>
								<td><xsl:value-of select="secretArt"/></td>
								<td><xsl:choose>
									<xsl:when test="effect"><xsl:value-of select="effect"/></xsl:when>
									<xsl:otherwise>-</xsl:otherwise>
								</xsl:choose></td>
								<td><xsl:value-of select="character"/></td>
								<td><xsl:value-of select="notes"/></td>
							</tr>
						</xsl:for-each>
					</tbody>
				</table>
				<p>Read more and leave comments at <a href="http://strivinglife.com/words/post/Muramasa-The-Demon-Blade-Complete-weapon-listing.aspx">Muramasa: The Demon Blade - Complete weapon listing</a>.</p>
				<p>Last updated: <xsl:value-of select="/blades/updated"/></p>
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