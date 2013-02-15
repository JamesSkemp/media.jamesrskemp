<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:xs="http://www.w3.org/2001/XMLSchema" exclude-result-prefixes="xs" version="2.0">
	<xsl:output method="xhtml" cdata-section-elements="text"/>
	<xsl:template match="/">
		<html>
			<head>
				<title>Journal entries</title>
				<style type="text/css">
					h1 {
						font-size:1.2em;
					}
					h2 {
						font-size:1.1em;
					}
					p {
						font-size:.9em;
					}
					.entry, .supp {
						margin-left:1em;
						padding:.5em;
					}
					.entry p, .supp p {
						margin:.5em auto;
					}
					.entry {
						border-top:1px solid gray;
					}
					.supp {
						border-top:1px dotted gray;
					}
					.dateInfo {
						margin-bottom:0;
						font-style:italic;
					}
					.contentText {
						margin-left:.5em;
					}
				</style>
			</head>
			<body>
				<h1>Journal entries</h1>
				<div>
					<xsl:for-each select="/journal/entry">
						<xsl:sort select="dateCreated" data-type="text"/>
						<div class="entry">
							<p class="dateInfo">Created <xsl:value-of select="dateCreated"/> UTC by <xsl:value-of select="author/name"/><br />
							Last updated: <xsl:value-of select="dateUpdated"/> UTC</p>
							<div class="contentText">
								<xsl:attribute name="id">entry<xsl:value-of select="@id"/></xsl:attribute>
								<xsl:value-of select="text" disable-output-escaping="yes"/>
							</div>
							<xsl:for-each select="supplements/supplement">
								<div class="supp">
									<xsl:attribute name="id">entry<xsl:value-of select="../../@id"/>supp<xsl:value-of select="@id"/></xsl:attribute>
									<p class="dateInfo">Added <xsl:value-of select="dateAdded"/> UTC</p>
									<div class="contentText">
										<xsl:value-of select="text" disable-output-escaping="yes"/>
									</div>
								</div>
							</xsl:for-each>
						</div>
					</xsl:for-each>
				</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
