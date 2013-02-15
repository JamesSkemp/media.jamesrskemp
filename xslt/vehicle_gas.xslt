<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
	<xsl:template match="/">
		<html>
		<head>
			<title>Vehicle gas information</title>
		</head>
		<body>
			<h1>Vehicle gas information</h1>
			<p>The following cars are registered for <xsl:value-of select="/vehicles/personNameFirst" />&#160;<xsl:value-of select="/vehicles/personNameLast" />.</p>
			<xsl:apply-templates select="vehicles/vehicle"/>
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
	<xsl:template match="vehicle">
		<h2><xsl:value-of select="year"/>&#160;<xsl:value-of select="make"/>&#160;<xsl:value-of select="model"/></h2>
		<xsl:apply-templates select="fillups"/>
	</xsl:template>
	<xsl:template match="fillups">
		<table>
			<thead>
				<th style="width:75px;">Date</th>
				<th style="width:75px;">Miles on the vehicle</th>
				<th style="width:75px;">Miles driven</th>
				<th style="width:75px;">Gallons added</th>
				<th style="width:75px;">Cost per gallon</th>
				<th style="width:75px;">Total cost</th>
				<th style="width:75px;">Miles/gallon</th>
				<th style="padding-left:1em;">Notes</th>
			</thead>
			<tbody>
		<xsl:for-each select="fillup">
			<tr>
				<td style="text-align:right;"><xsl:value-of select="date"/></td>
				<td style="text-align:right;"><xsl:value-of select="milesCar"/></td>
				<td style="text-align:right;"><xsl:value-of select="milesDriven"/></td>
				<td style="text-align:right;"><xsl:value-of select="gallons"/></td>
				<td style="text-align:right;">$<xsl:value-of select="costGallon"/></td>
				<td style="text-align:right;">$<xsl:value-of select="costTotal"/></td>
				<td style="text-align:right;"><xsl:value-of select="format-number(milesDriven div gallons, '##00.000')"/></td>
				<td style="font-style:italic;padding-left:1em;"><xsl:value-of select="notes"/></td>
			</tr>
		</xsl:for-each>
			</tbody>
			<xsl:variable name="milesMax">
				<xsl:for-each select="fillup/milesCar">
					<xsl:sort data-type="number" order="descending"/>
					<xsl:if test="position() = 1">
						<xsl:choose>
							<xsl:when test=". = 160342">
								<xsl:value-of select=". - 149210"/>
							</xsl:when>
							<xsl:otherwise>
								<xsl:value-of select="."/>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:if>
				</xsl:for-each>
			</xsl:variable>
			<tfoot>
				<td style="border-top:1px solid black;">Totals/averages:</td>
				<td style="border-top:1px solid black;text-align:right;"></td>
				<td style="border-top:1px solid black;text-align:right;"><xsl:value-of select="$milesMax"/></td>
				<td style="border-top:1px solid black;text-align:right;"><xsl:value-of select="format-number(sum(fillup/gallons),'###00.000')"/></td>
				<td style="border-top:1px solid black;text-align:right;">$<xsl:value-of select="format-number(sum(fillup/costGallon) div count(fillup/costGallon),'##0.000')"/></td>
				<td style="border-top:1px solid black;text-align:right;">$<xsl:value-of select="format-number(sum(fillup/costTotal),'###00.00')"/></td>
				<td style="border-top:1px solid black;text-align:right;"></td>
				<td style="border-top:1px solid black;text-align:right;"></td>
			</tfoot>
		</table>
	</xsl:template>

</xsl:stylesheet>