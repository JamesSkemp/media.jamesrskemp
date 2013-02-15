<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
	<xsl:output indent="yes" method="html" omit-xml-declaration="yes"/>
	<xsl:template match="NierWeapons">
		<xsl:text disable-output-escaping="yes"><![CDATA[<!doctype html>]]></xsl:text>
		<html lang="en">
			<head>
				<meta charset="utf-8" />
				<title>James Skemp's Nier Weapon Upgrade Helper</title>
				<meta name="author" content="James Skemp" />
				<meta name="description" content="Listing of Nier weapons, and information about how to upgrade each." />
				<script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.6.4.min.js"></script>
				<style type="text/css">
					ul.weapons
					{
						list-style-type:none;
					}
					ul.weapons li
					{
						margin-bottom:.25em;
					}
					ul.weapons select
					{
						margin-right:1em;
					}
					.fullyUpgraded, .fullyUpgraded select
					{
						color:#ccc;
					}
				</style>
				<script type="text/javascript">
					$(function() {
						$('select.weapon').change(
							function() {
								// Style the text if the weapon is fully upgraded.
								if ($(this).val() == '4')
								{
									$(this).parent().addClass('fullyUpgraded');
								}
								else
								{
									$(this).parent().removeClass('fullyUpgraded');
								}
							}
						);
					});
				</script>
			</head>
			<body lang="en">
				<header><h1>Nier Weapon Upgrade Helper</h1></header>
				<section id="OneHandedSwords">
					<ul class="weapons">
						<xsl:for-each select="Weapon">
							<xsl:if test="Type = 'One-Handed Sword'">
								<li><select class="weapon" id="Weapon{@Id}"><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option></select>
									<xsl:value-of select="Name"/></li>
							</xsl:if>
						</xsl:for-each>
					</ul>
				</section>
				<section id="TwoHandedSwords">
					<ul class="weapons">
						<xsl:for-each select="Weapon">
							<xsl:if test="Type = 'Two-Handed Sword'">
								<li><select id="Weapon{@Id}"><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option></select>
									<xsl:value-of select="Name"/></li>
							</xsl:if>
						</xsl:for-each>
					</ul>
				</section>
				<section id="Spears">
					<ul class="weapons">
						<xsl:for-each select="Weapon">
							<xsl:if test="Type = 'Spear'">
								<li><select id="Weapon{@Id}"><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option></select>
									<xsl:value-of select="Name"/></li>
							</xsl:if>
						</xsl:for-each>
					</ul>
				</section>
				<section id="Materials">
					<ul>
						<xsl:for-each select="Weapon/Upgrade/Item">
							<li><xsl:value-of select="concat('Weapon', parent::Upgrade/parent::Weapon/@Id, '-', parent::Upgrade/@Level, ' ')"/><!--Weapon{parent::Upgrade/parent::Weapon/@Id}-{parent::Upgrade/@Level}--> 
								<xsl:value-of select="concat(@Quantity, ' ', @Name)"/></li>
						</xsl:for-each>
					</ul>
				</section>
				<footer><p>Created by <a href="http://jamesrskemp.com" rel="external author">James Skemp</a></p></footer>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>