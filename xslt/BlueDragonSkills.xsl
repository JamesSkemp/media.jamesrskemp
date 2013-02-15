<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
      xmlns:xs="http://www.w3.org/2001/XMLSchema"
      exclude-result-prefixes="xs"
      version="2.0">
	<xsl:template match="/">
		<html>
			<head>
				<title>Blue Dragon Skills</title>
			</head>
			<body>
				<h1>Blue Dragon Skills</h1>
				<p>The following is a list of skills for Blue Dragon, for the Xbox 360. Base skills are in italic.</p>
				<xsl:apply-templates select="skills"></xsl:apply-templates>
				<p>Last updated May 17 2009.</p>
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
	<xsl:template match="skills">
		<table border="1" cellpadding="3" cellspacing="0">
			<thead>
				<tr>
					<th>Shadow Class</th>
					<th>Skill</th>
					<th>Rank</th>
					<th>Upgraded?</th>
				</tr>
			</thead>
			<tbody>
				<xsl:for-each select="skill">
					<xsl:sort select="@class"/>
					<xsl:sort select="@rank" data-type="number"/>
					<tr>
						<td><xsl:value-of select="@class"/></td>
						<td>
							<xsl:choose>
								<xsl:when test="@base"><em><xsl:value-of select="self::skill"/></em></xsl:when>
								<xsl:otherwise><xsl:value-of select="self::skill"/></xsl:otherwise>
							</xsl:choose>
						</td>
						<td><xsl:value-of select="@rank"/></td>
						<td>
							<xsl:choose>
								<xsl:when test="@level">yes</xsl:when>
								<xsl:otherwise>&#160;</xsl:otherwise>
							</xsl:choose>
						</td>
					</tr>
				</xsl:for-each>
			</tbody>
		</table>
	</xsl:template>
</xsl:stylesheet>
