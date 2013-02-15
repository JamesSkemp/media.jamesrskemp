<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:xs="http://www.w3.org/2001/XMLSchema" exclude-result-prefixes="xs"
	xmlns:xd="http://www.oxygenxml.com/ns/doc/xsl" version="2.0">
	<xsl:output method="html" encoding="utf-8" indent="yes" />
	<xsl:template match="/">
		<!--<xsl:text disable-output-escaping='yes'>&lt;!DOCTYPE html></xsl:text>-->
		<html><!--<html manifest="/manifest/generic.manifest">-->
			<head>
				<title>Resonance of Fate</title>
				<style type="text/css">
					table th, table td {
						border-bottom:1px solid gray;
						padding-right:1em;
						padding-left:.5em;
						vertical-align:top;
					}
				</style>
				<script type="text/javascript">
					if (window.applicationCache) {
						//alert(window.applicationCache.status);
					}
				</script>
			</head>
			<body>
				<h1>Resonance of Fate</h1>
				<ul>
					<li><a href="#heading_arena">Arena</a></li>
					<li><a href="#heading_characters">Characters</a></li>
					<li><a href="#heading_weapons">Weapons</a></li>
				</ul>
				<h2 id="heading_arena">Arena</h2>
				
				<h3>Rank enemies</h3>
				<table summary="">
					<thead>
						<tr>
							<th>Rank</th>
							<th>Chapter available</th>
							<th>Entry fee</th>
							<th>Battle coins reward</th>
							<th>Enemies</th>
						</tr>
					</thead>
					<tbody>
						<xsl:for-each select="/ResonanceOfFate/Arena/Ranks/Rank">
							<tr>
								<td><xsl:value-of select="@id"/></td>
								<td><xsl:value-of select="@chapter"/></td>
								<td><xsl:value-of select="@price"/></td>
								<td><xsl:value-of select="@battleCoins"/></td>
								<td>
									<xsl:for-each select="Enemies/Enemy">
										<xsl:if test="@name != ''">
											<xsl:value-of select="@name"/> - level <xsl:value-of select="@level"/>
											<xsl:if test="@quantity != ''"> (x<xsl:value-of select="@quantity"/>)</xsl:if><br />
										</xsl:if>
									</xsl:for-each>
								</td>
							</tr>
						</xsl:for-each>
					</tbody>
				</table>
				
				<h3>Battle multipliers</h3>
				<table summary="Arena battle multipliers">
					<thead>
						<tr>
							<th>Battle number</th>
							<th>Reward multiplier</th>
						</tr>
					</thead>
					<tbody>
						<xsl:for-each select="/ResonanceOfFate/Arena/Multipliers/Multiplier">
							<tr>
								<td><xsl:value-of select="@id"/></td>
								<td><xsl:value-of select="@value"/></td>
							</tr>
						</xsl:for-each>
					</tbody>
				</table>
				
				<h2 id="heading_Characters">Characters</h2>
				<xsl:for-each select="/ResonanceOfFate/Characters/Character">
					<h3><xsl:value-of select="@name"/></h3>
					<h4>Leveling</h4>
					<table summary="Character leveing information">
						<thead>
							<tr>
								<th>Level</th>
								<th>Hit points</th>
								<th>Weight</th>
							</tr>
						</thead>
						<tbody>
							<xsl:for-each select="Levels/Level">
								<tr>
									<td><xsl:value-of select="@id"/></td>
									<td><xsl:value-of select="@hitPoints"/></td>
									<td><xsl:value-of select="@weight"/></td>
								</tr>
							</xsl:for-each>
						</tbody>
					</table>

					<h4>Skills</h4>
					<table summary="Character skill information">
						<thead>
							<tr>
								<th>Type</th>
								<th>Level</th>
								<th>Skill</th>
							</tr>
						</thead>
						<tbody>
							<xsl:for-each select="Skills/Skill">
								<tr>
									<td><xsl:value-of select="@type"/></td>
									<td><xsl:value-of select="@level"/></td>
									<td><xsl:value-of select="@name"/></td>
								</tr>
							</xsl:for-each>
						</tbody>
					</table>
				</xsl:for-each>
				
				<h2 id="heading_weapons">Weapons</h2>
				
				<h3>Weapon listing</h3>
				<table summary="Listing of weapons">
					<thead>
						<tr>
							<th>Name</th>
							<th>Type</th>
							<th>Weight</th>
							<th>Image</th>
						</tr>
					</thead>
					<tbody>
						<xsl:for-each select="/ResonanceOfFate/Weapons/Listing/Weapon">
							<tr>
								<td><xsl:value-of select="@name"/></td>
								<td><xsl:value-of select="@type"/></td>
								<td><xsl:value-of select="@weight"/></td>
								<td>
									<xsl:if test="@imageLocation != ''">
										<a href="{@imageLocation}" target="_blank">View image</a>
									</xsl:if>
								</td>
							</tr>
						</xsl:for-each>
					</tbody>
				</table>
				
				<h3>Custom parts</h3>
				<table summary="Listing of custom parts">
					<thead>
						<tr>
							<th>Name</th>
							<th>Image</th>
						</tr>
					</thead>
					<tbody>
						<xsl:for-each select="/ResonanceOfFate/Weapons/CustomParts/Parts">
							<tr>
								<td><xsl:value-of select="@name"/></td>
								<td>
									<xsl:if test="@imageLocation != ''">
										<a href="{@imageLocation}" target="_blank">View image</a>
									</xsl:if>
								</td>
							</tr>
						</xsl:for-each>
					</tbody>
				</table>
				
				<h3>Weapon leveling</h3>
				<table summary="Information on leveling of weapons.">
					<thead>
						<tr>
							<th>Level</th>
							<th>Experience to next level</th>
						</tr>
					</thead>
					<tbody>
						<xsl:for-each select="/ResonanceOfFate/Weapons/Leveling/Level">
							<tr>
								<td><xsl:value-of select="@id"/></td>
								<td><xsl:value-of select="@experience"/></td>
							</tr>
						</xsl:for-each>
					</tbody>
				</table>				


				<h2>additional information ...</h2>
				<p>Until it's been cleaned up, view source to view additional information, such as character level and weapons.</p>
				<!-- todo -->
				
				
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
