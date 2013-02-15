<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
	<xsl:template match="characters">
		<html>
			<head>
				<title>Dragon Quest VIII Character Leveling Overview</title>
			</head>
			<body>
				<h1>Dragon Quest VIII Character Leveling Overview</h1>
				<p>The following tables cover the experience required to attain a level, as well as the benefits of that level.</p>
				<p><a href="http://strivinglife.net/words/post/Dragon-Quest-VIII-Character-leveling-overview.aspx">Read more or comment on this page</a>.</p>
				<xsl:apply-templates select="character"/>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="character">
		<h1>
			<xsl:value-of select="@name"/>
		</h1>
		<table border="1">
			<thead>
				<tr>
					<th>Level</th>
					<th>Strength</th>
					<th>Agility</th>
					<th>Resilience</th>
					<th>Wisdom</th>
					<th>Max Hit Points</th>
					<th>Max Magic Points</th>
					<th>Total Skill Points</th>
					<th>Experience</th>
					<th>Spell(s) Learned</th>
				</tr>
			</thead>
			<tbody>
				<xsl:apply-templates select="levels"/>
			</tbody>
		</table>
	</xsl:template>
	<xsl:template match="levels">
		<xsl:for-each select="level">
			<tr>
				<td>
					<xsl:value-of select="@id"/>
				</td>
				<td>
					<xsl:value-of select="strength"/>
				</td>
				<td>
					<xsl:value-of select="agility"/>
				</td>
				<td>
					<xsl:value-of select="resilience"/>
				</td>
				<td>
					<xsl:value-of select="wisdom"/>
				</td>
				<td>
					<xsl:value-of select="hitpoints"/>
				</td>
				<td>
					<xsl:value-of select="magicpoints"/>
				</td>
				<td>
					<xsl:value-of select="skillpoints"/>
				</td>
				<td style="text-align:right;">
					<xsl:value-of select="experience"/>
				</td>
				<td>
					<xsl:value-of select="spell"/>&#160;
				</td>
			</tr>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>
