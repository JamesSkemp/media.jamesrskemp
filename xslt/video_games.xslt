<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
	<xsl:template match="games">
		<html>
		<head>
			<title>James Skemp's video games (static listing)</title>
		</head>
		<body>
		<h1>James Skemp's video game collection</h1>
		<p>The following is a list of video games owned by <a href="https://jamesrskemp.com">James Skemp</a>.</p>
		<div style="border:1px dashed #999;margin:.25em;padding:1em;">
			<xsl:apply-templates select="game">
				<xsl:sort select="lower-case(title)" data-type="text" />
				<xsl:sort select="system/console" data-type="text" />
				<xsl:sort select="system/version" data-type="number" order="descending" />
			</xsl:apply-templates>
		</div>
		</body>
		</html>
	</xsl:template>
	<xsl:template match="game">
		<xsl:if test="own = 'yes'">
		<div style="margin:1em 0;">
			<span style="font-size:120%;font-weight:bold;"><xsl:value-of select="title" /></span>
			- <xsl:value-of select="concat(system/console, ' ', system/version)" />
			<div style="margin-left:1em;">
				<xsl:if test="purchase/date != '' or purchase/price != '' or purchase/place != ''">
					Bought <xsl:value-of select="purchase/date" />
					<xsl:if test="purchase/price != ''">
						<xsl:apply-templates select="purchase/price" />
					</xsl:if>
					<xsl:if test="purchase/place != ''">
						at <xsl:value-of select="purchase/place" />
					</xsl:if>
				</xsl:if>
			</div>
			<!--<xsl:if test="own = 'no'">
				<div style="margin-left:1em;">
					Sold <xsl:value-of select="sell/date" />
					<xsl:apply-templates select="sell/price" />
				</div>
			</xsl:if>
			<div style="margin-left:1em;">
				Still own? <xsl:value-of select="own" />
			</div>-->
			<xsl:if test="notes != ''">
				<div style="font-style:italic;margin-left:1em;">
					Notes: <xsl:value-of select="notes" />
				</div>
			</xsl:if>
		</div>
		</xsl:if>
	</xsl:template>
	<xsl:template match="price">
		for $<xsl:value-of select="." />
	</xsl:template>
</xsl:stylesheet>
