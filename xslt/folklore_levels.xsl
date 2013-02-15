<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
	<xsl:template match="ranks">
		<html>
			<head>
				<title>Folklore Leveling Overview</title>
			</head>
			<body>
				<h1>Folklore Leveling Overview</h1>
				<p>The following table covers the experience required to attain a new rank, as well
					as the hit points at that level.</p>
				<table border="1">
					<thead>
						<tr>
							<td>Rank</td>
							<td>Max hit points</td>
							<td>Experience needed for next level</td>
						</tr>
					</thead>
					<tbody>
						<xsl:for-each select="rank">
							<tr>
								<td>
									<xsl:value-of select="@id"/>
								</td>
								<td>
									<xsl:value-of select="hp"/>
								</td>
								<td>
									<xsl:value-of select="next"/>
								</td>
							</tr>
						</xsl:for-each>
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
