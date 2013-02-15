/*
SyntaxHighlighter brush for Microsoft Log Parser created by James Skemp - http://jamesrskemp.com/ and http://logparserplus.com/

Released under Attribution-Noncommercial 3.0 - http://creativecommons.org/licenses/by-nc/3.0/

SyntaxHighlighter by Alex Gorbatchev - http://alexgorbatchev.com/
*/
SyntaxHighlighter.brushes.LogParser = function() {
	var functions = 'add bit_and bit_not bit_or bit_shl bit_xol'
		+ 'case'
		+ 'coalesce computer_name div exp exp10 extract_extension extract_filename extract_path extract_prefix extract_suffix extract_token extract_value floor hashmd5_file hashseq hex_to_asc hex_to_hex16 hex_to_hex32 hex_to_hex8 hex_to_int hex_to_print in_row_number index_of int_to_ipv4 ipv4_to_int last_index_of log log10 ltrim mod mul out_row_number qntfloor_to_digit qntround_to_digit quantize replace_chr replace_if_not_null replace_str resolve_sid reversedns rot13 round rtrim sequence sqr sqroot strcat strcnt strlen strrepeat strrev sub substr system_date system_time system_timestamp system_utcoffset to_date to_hex to_int to_localtime to_lowercase to_real to_string to_time to_timestamp to_uppercase to_utctime trim urlescape urlunescape win32_error_description'
		+ 'count sum avg min max propcount propsum grouping';
	var expressions = 'all any between in like and not or';
	var clauses = 'select using into from where group having order by';
	var keywords = 'logparser rtp';
	var operators = '';

	this.regexList = [
		{ regex: /--(.*)$/gm, css: 'comments' },
		{ regex: SyntaxHighlighter.regexLib.multiLineCComments, css: 'comments' },
		//{ regex: SyntaxHighlighter.regexLib.multiLineDoubleQuotedString, css: 'string' },
		{ regex: new RegExp(this.getKeywords(functions), 'gmi'), css: 'functions' },
		{ regex: new RegExp(this.getKeywords(clauses), 'gmi'), css: 'keyword' },
		{ regex: new RegExp(this.getKeywords(expressions), 'gmi'), css: 'color3' },
		//{ regex: new RegExp(this.getKeywords(operators), 'gmi'), css: 'color1' },
		{ regex: new RegExp(this.getKeywords(keywords), 'gmi'), css: 'preprocessor' }
		// comments keyword string preprocessor variable value functions constants script color1 color2 color3 plain
	];
};

SyntaxHighlighter.brushes.LogParser.prototype = new SyntaxHighlighter.Highlighter();
SyntaxHighlighter.brushes.LogParser.aliases = ['logparser'];