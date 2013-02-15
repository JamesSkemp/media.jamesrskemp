<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
	<xsl:output indent="yes" method="html" omit-xml-declaration="yes"/>
	<xsl:template match="games">
		<xsl:text disable-output-escaping="yes"><![CDATA[<!doctype html>]]></xsl:text>
		<html lang="en">
			<head>
				<meta charset="utf-8" />
				<title>James Skemp's Video Games - mobile version</title>
				<meta name="author" content="James Skemp" />
				<meta name="description" content="Mobile version of James Skemp's video games, powered by jQuery Mobile." />
				<meta name="viewport" content="width=device-width, initial-scale=1.0" />
				<link rel="stylesheet" href="http://code.jquery.com/mobile/1.0b1/jquery.mobile-1.0b1.min.css" />
				<script src="http://code.jquery.com/jquery-1.6.1.min.js"></script>
				<script>
					$(document).bind("mobileinit", function() {
						$.mobile.page.prototype.options.addBackBtn = true;
					});
				</script>
				<script src="http://code.jquery.com/mobile/1.0b1/jquery.mobile-1.0b1.min.js"></script>
				<style type="text/css">
					.inline-sub
					{
						font-size:.85em;
						margin-left:2em;
					}
				</style>
			</head>
			<body lang="en">
				<section id="page-intro" data-role="page">
					<header data-role="header" data-theme="b"><h1>Home</h1></header>
					<div class="content" data-role="content">
						<ul data-role="listview">
							<li><a href="#page-owned-title">Games owned by title</a></li>
							<li><a href="#page-owned-system">Games owned by system</a></li>
							<li><a href="#page-sold">Games sold</a></li>
						</ul>
					</div>
					<footer data-role="footer"><h1>Created by <a href="http://jamesrskemp.com" rel="external author">James Skemp</a></h1></footer>
				</section>
				<section id="page-owned-title" data-role="page">
					<header data-role="header" data-theme="b"><a href="#page-intro" class="ui-btn-right" data-icon="home" data-iconpos="notext" data-direction="reverse">Home</a><h1>Owned games</h1></header>
					<div class="content" data-role="content">
						<ul data-role="listview" data-theme="b">
							<xsl:for-each select="game">
								<xsl:sort select="upper-case(title)"/>
								<xsl:sort select="concat(system/console, ' ', system/version)"/>
								<xsl:if test="(own = 'yes') and (not(@addOn) or @addOn != 'true')">
									<li><xsl:value-of select="title" /><span class="inline-sub"><xsl:value-of select="concat(system/console, ' ', system/version)" /></span></li>
								</xsl:if>
							</xsl:for-each>
						</ul>
					</div>
					<footer data-role="footer"><h1>Footer text</h1></footer>
				</section>
				<section id="page-sold" data-role="page">
					<header data-role="header" data-theme="b"><a href="#page-intro" class="ui-btn-right" data-icon="home" data-iconpos="notext" data-direction="reverse">Home</a><h1>Sold games</h1></header>
					<div class="content" data-role="content">
						<ul data-role="listview" data-theme="b">
							<xsl:for-each select="game">
								<xsl:sort select="upper-case(title)"/>
								<xsl:if test="own = 'no' and (not(@addOn) or @addOn != 'true')">
									<li><xsl:value-of select="title" /><span class="inline-sub"><xsl:value-of select="concat(system/console, ' ', system/version)" /></span></li>
								</xsl:if>
							</xsl:for-each>
						</ul>
					</div>
					<footer data-role="footer"><h1>Created by <a href="http://jamesrskemp.com" rel="external author">James Skemp</a></h1></footer>
				</section>
				<section id="page-owned-system" data-role="page">
					<header data-role="header" data-theme="b"><a href="#page-intro" class="ui-btn-right" data-icon="home" data-iconpos="notext" data-direction="reverse">Home</a><h1>Games owned by system</h1></header>
					<div class="content" data-role="content">
						<ul data-role="listview">
							<xsl:for-each-group select="game" group-by="concat(system/console, ' ', system/version)">
								<xsl:sort select="upper-case(concat(system/console, ' ', system/version))"/>
								<xsl:sort select="upper-case(title)"/>
								<li><xsl:value-of select="concat(system/console, ' ', system/version)" />
									<ul>
										<xsl:for-each select="current-group()">
											<xsl:sort select="upper-case(title)"/>
											<xsl:if test="own = 'yes' and (not(@addOn) or @addOn != 'true')">
												<li><xsl:value-of select="title"/></li>
											</xsl:if>
										</xsl:for-each>
									</ul>
								</li>
							</xsl:for-each-group>
						</ul>
					</div>
					<footer data-role="footer"><h1>Created by <a href="http://jamesrskemp.com" rel="external author">James Skemp</a></h1></footer>
				</section>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>