# SGMLReader - Convert any HTML to valid XML
SGMLReader is a versatile C# .NET library written by Chris Lovett for parsing HTML/SGML files. The original community around SGMLReader used to be hosted by [GotDotNet](http://www.gotdotnet.com/Community/UserSamples/Details.aspx?SampleGuid=B90FDDCE-E60D-43F8-A5C4-C3BD760564BC), but this site was phased out (update: it appears the code has re-surfaced on [MSDN Code Gallery](http://code.msdn.microsoft.com/SgmlReader), but without any updates). [MindTouch Dream](http://developer.mindtouch.com/en/docs/Dream) and [MindTouch Core](http://developer.mindtouch.com/en/docs/MindTouch) use the SGMLReader library extensively.  Over the last few years we have made many improvements to this code; thereby, making us  the de facto maintainers of this library.  In the spirit of the original author, we're providing back these changes on the MindTouch Developer Center site.

	XmlDocument FromHtml(TextReader reader) {
	
		// setup SGMLReader
		Sgml.SgmlReader sgmlReader = new Sgml.SgmlReader();
		sgmlReader.DocType = "HTML";
		sgmlReader.WhitespaceHandling = WhitespaceHandling.All;
		sgmlReader.CaseFolding = Sgml.CaseFolding.ToLower;
		sgmlReader.InputStream = reader;
	
		// create document
		XmlDocument doc = new XmlDocument();
		doc.PreserveWhitespace = true;
		doc.XmlResolver = null;
		doc.Load(sgmlReader);
		return doc;
	}


## Sample Output
Visit the [HTML-to-XML Conversion Examples page](http://developer.mindtouch.com/en/docs/SgmlReader/HTML-to-XML_Conversion_Examples) to see how SGMLReader converts HTML source into valid XML.

## Community
If you find/fix issues in SGMLReader, please post them in the [SGMLReader forum](http://forums.developer.mindtouch.com/forumdisplay.php?f=22).

## Release History
Visit the [SGMLReader wiki page](http://developer.mindtouch.com/en/docs/SgmlReader) for a complete release history.