<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
	<xsl:template match="disgaea">
		<html>
			<head>
				<title>Disgaea: Hour of Darkness Specialists</title>
				<style type="text/css">
					td {
						font-size:.9em;
					}
					@media print {
						td {
							page-break-inside:avoid;
						}
					}
					@page table {
						size:landscape;
					}
				</style>
			</head>
			<body>
				<h1>Disgaea: Hour of Darkness Specialists</h1>
				<p>The following is a listing of Specialists for Disgaea: Hour of Darkness, Greatest Hits edition, for the Playstation 2.</p>
				<p>Also included is space to enter what power, as well as what character / item you have placed the specialist(s) you have unlocked.</p>
				<p>(Unless you're using Opera, you may want to copy this into a new word processing document and print from there. Unfortunately, only Opera seems to support the CSS used for a nice print layout.)</p>
				<xsl:apply-templates select="specialists"/>
				<p>Last updated October 18 2008.</p>
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
	<xsl:template match="specialists">
		<table border="1" cellpadding="3" cellspacing="0">
			<thead>
				<tr>
					<td>Specialist</td>
					<td>Description / Type / Max</td>
					<td>Character / item 1</td>
					<td>Character / item 2</td>
					<td>Character / item 3</td>
					<td>Character / item 4</td>
					<td>Character / item 5</td>
				</tr>
			</thead>
			<tbody>
				<xsl:for-each select="specialist">
					<tr>
						<td>
							<xsl:value-of select="name"/>
						</td>
						<td>
							<xsl:value-of select="description"/><br />
							Type: <xsl:value-of select="type"/><br />
							Max: <xsl:value-of select="max"/>
						</td>
						<td>&#160;</td>
						<td>&#160;</td>
						<td>&#160;</td>
						<td>&#160;</td>
						<td>&#160;</td>
					</tr>
				</xsl:for-each>
			</tbody>
		</table>
		
	</xsl:template>
</xsl:stylesheet>
