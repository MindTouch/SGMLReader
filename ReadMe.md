# SgmlReader - Convert (almost) any HTML to valid XML

SgmlReader is a versatile C# .NET library written by Chris Lovett for parsing 
HTML/SGML files using the XmlReader API. A command line utility is also provided 
which outputs the well formed XML result. The original community around 
SgmlReader was hosted by 
<strike>[GotDotNet](http://www.gotdotnet.com/Community/UserSamples/Details.aspx?SampleGuid=B90FDDCE-E60D-43F8-A5C4-C3BD760564BC)</strike>,
but this site was phased out. An archived version of the original release is 
still available in the [MSDN Code Gallery](http://code.msdn.microsoft.com/SgmlReader).

[MindTouch](http://mindtouch.com) uses the SgmlReader library extensively.  Over 
the last few years we have made many improvements to it.  In the spirit 
of the original author, we're providing back these changes in our 
[GitHub SgmlReader repository](https://github.com/MindTouch/SGMLReader).

## SgmlReaderDll API

The SgmlReader is an implementation of the XmlReader API. So the only thing you 
really need to know is how to construct it. SgmlReader has a default constructor, 
then you need to set some of the properties. To load a DTD you must specify 
DocType="HTML" or you must provide a SystemLiteral. To specify the SGML 
document you must provide either the InputStream or Href. Everything else is 
optional. Then you can read from this reader like any other XmlReader class.

### Sample Usage

    XmlDocument FromHtml(TextReader reader) {
    
        // setup SgmlReader
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

### SgmlReader Properties

* **SgmlDtd Dtd**<br/>
Specify the SgmlDtd object directly. This allows you to cache the Dtd and share 
it across multiple SgmlReaders. To load a DTD from a URL use the SystemLiteral 
property.
* **string DocType**<br/>
The name of root element specified in the DOCTYPE tag. If you specify "HTML" 
then the SgmlReader will use the built-in HTML DTD. In this case you do not need 
to specify the SystemLiteral property.
* **string PublicIdentifier**<br/>
The PUBLIC identifier in the DOCTYPE tag. This is optional.
* **string SystemLiteral**<br/>
The SYSTEM literal in the DOCTYPE tag identifying the location of the DTD.
* **string InternalSubset**<br/>
The DTD internal subset in the DOCTYPE tag. This is optional.
* **TextReader InputStream**<br/>
The input stream containing SGML data to parse. You must specify this property 
or the Href property before calling Read().
* **string Href**<br/>
Specify the location of the input SGML document as a URL.
* **string WebProxy**<br/>
Sometimes you need to specify a proxy server in order to load data via HTTP from 
outside the firewall. For example: "itgproxy:80".
* **string BaseUri**<br/>
The base Uri is used to resolve relative Uri's like the SystemLiteral and Href 
properties.
* **TextWriter ErrorLog**<br/>
DTD validation errors are written to this stream.
* **string ErrorLogFile**<br/>
DTD validation errors are written to this log file.

## SgmlReader.exe Command Line Tool

### Usage

The command line executable version has the following options:

    sgmlreader <options> [InputUri] [OutputFile]

* -e "file" : Specifies a file to write error output to.  The default is to 
generate no errors.  The special name "$stderr" redirects errors to stderr 
output stream.
* -proxy : "server"  Specifies the proxy server to use to fetch DTD's through 
the fire wall.
* -html : Specifies that the input is HTML.
* -dtd "uri" : Specifies some other SGML DTD.
* -base : Add an HTML base tag to the output.
* -pretty : Pretty print the output.
* -encoding name : Specify an encoding for the output file (default UTF-8)
* -noxml : Stops generation of XML declaration in output.
* -doctype : Copy <!DOCTYPE tag to the output.
* InputUri : The input file name or URL. Default is stdin.  If this is a local 
file name then it also supports wildcards.
* OutputFile : The optional output file name. Default is stdout.  If the 
InputUri contains wildcards then this just specifies the output file extension, 
the default being ".xml".

### Examples

Converts all .htm files to corresponding .xml files using the built in HTML DTD.

    sgmlreader -html *.htm *.xml

Converts all the MSN home page to XML storing the result in the local file 
"msn.xml".

    sgmlreader -html http://www.msn.com -proxy myproxy:80 msn.xml

Converts the given OFX file to XML using the SGML DTD "ofx160.dtd" specified in 
the test.ofx file.

    sgmlreader -dtd ofx160.dtd test.ofx ofx.xml

## Community
If you have questions, please post them on 
[StackOverflow](http://stackoverflow.com/questions/tagged/sgmlreader) and tag 
them with *sgmlreader*.  You may also email bugs, feedback and/or feature 
requests to <a href="mailto:clovett@microsoft.com">Chris Lovett</a>.

If you fix an issue, please submit follow these guidelines:

1. Make sure the code formatting is **identical** to the existing code formatting. 
You know that you're doing it right if your code is indistinguishable from
existing code.
1. Run the unit test to make sure no regressions are being introduced.
1. Add a unit test to confirm your fix or feature.
1. Submit a pull request on [GitHub](https://github.com/MindTouch/SGMLReader).

## Release History
*Note:* all 1.8.x releases up to 1.8.7 are compatible with 1.8.0.  Use assembly 
redirection to account for newer versions when recompilation is not an option.

### Release notes for 1.8.11 (2013-Jan-27)

* Pulled latest psake and nuget tools. (Andy Sherwood)
* Made sure Html.dtd was embedded as a resource in the build script for the 
nuget package. (Andy Sherwood)

### Release notes for 1.8.10 (2013-Jan-10)

* Fixed AttributeCount and m_state problems for use under Mono. (Max Zhao)
* Decode unicode surrogate pairs. (CaptainCodeman)
* Incomplete entity codes are kept intact and escaped to produce valid HTML. (Marek St&oacute;j)

### Release notes for 1.8.9 (2013-Jan-09)

* Converted license from GPL 3 to Apache 2.0.
* Consolidated read-me files.
* Cleaned up solution and project files.

### Release notes for 1.8.8 (2011-Sep-29)

* Converted project files to Visual Studio 2010. (Andy Sherwood)
* Fully nugetized. Get log4net and nunit from nuget. Build nuget package with 
build script using psake and powershell. (Andy Sherwood)

### Release notes for 1.8.7 (2010-Apr-27)

* Provide setting to ignore DTD in parsed document (again).

### Release notes for 1.8.6 (2010-Feb-19)

* Provide setting to ignore DTD in parsed document.
* An attribute with a missing value should be assumed to have the name of the 
attribute as value.
* SgmlReader ExpandEntity with entities not ending in ';' and skips a character.
* SgmlReader adds 65535 character at the end of the string.
* Add test showing behavior of > char in string literals in XML.

### Release notes for 1.8.5 (2009-Jul-19)

* Unable to parse UTF-32 entities.
* Use StringComparison.OrdinalIgnoreCase instead of 
StringComparison.InvariantCultureIgnoreCase.

### Release notes for 1.8.4 (2009-May-19)

* Corrupt attributes may lead to invalid attribute names, which make the 
produced XML unparseable.
* Error when content contains prefixed XML processing instructions (e.g. 
&lt;?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" />).
* Added -ignore flag so tests known to fail can be ignored from the suite.
* Added test to re-parse output to make sure it's valid XML (.Net sometimes was 
able to generate invalid XML).

### Release notes for 1.8.3 (2009-Apr-03)

* Fixed CData section parsing skips over characters.

### Release notes for 1.8.2 (2008-Nov-26)

* Fixed regression introduced by fixing bug 5150.
* An extra open quote/double-quote prevents the entire element from being read 
properly.
* Replaced == string equality with culture invariant string.Compare().
* Return 'null' as NameTable since none is used.
* Added '-noformat' switch for regression tests to suppress automatic 
reformatting (useful for formatting tests).

### Release notes for 1.8.1 (2008-Oct-08)

* Unclosed HTML comment causes infinite loop.
* Don't use XmlNameTable with object comparisons; it becomes unreliable after a 
while.

### Release notes for 1.8.0 (2008-Jul-28)

**BREAKING CHANGE:** requires .NET 2.0

* Major code clean-up. (thx jamesgmbutler for the contribution!)
* Add XML-only entity &amp;apos; to HTML DTD.

### Release notes for 1.7.5 (2008-Jul-01)

* Missing quote in attribute value causes catastrophic failure.
* Unknown prefixes cannot be mapped to the same namespace.

### Release notes for 1.7.4 (2008-Jun-03)

* &amp;sup2; entity is not recognized correctly.
* Added test for entities with digits.

### Release notes for 1.7.3 (2008-May-05)

* Never close the BODY tag early (it causes loss of content).
* Remove  "&lt;![CDATA[" inside CDATA sections.
* Remove "]]>" inside CDATA sections.
* Convert elements with invalid tag names into text (e.g. &lt;foo@bar.com>).

### Release notes for 1.7.2 (2007-Dec-07)

* Fixed bug where parsing CDATA section skipped first character.
* Don't double parse commented out CDATA sections.
* Added support for namespaces on elements and attributes.
* Unknown prefixes on attributes and elements resolve to '#unknown' namespace.
* Fix bug when parsing down-level comments, like &lt;![if IE]>.
* Don't allow attribute with invalid names (e.g. &lt;p foo:="invalid" ;="bad">, 
etc.).

### Release notes for 1.7.1 (2007-Sep-25)

* Added 'GetLiteralEntitiesLookup()' method.
* Fixed bugs with namespace prefixes on attributes and elements; prefixes are 
now stripped automatically.
* Added SgmlReader constructor with XmlNameTable argument to avoid failed 
comparisons when reusing the DTD.
* Ensured that SgmlReader is initialized identically when reusing a DTD.

### Release notes for 1.7

* Fix bug reported by chriswang - MoveToAttribute didn't save state properly.
* Fix bug reported by starascendent - build on Visual Studio 2003 was broken.
* Fix bug reported by sanchen - ExpandCharEntity was messed up on hex entities.
* Fix bug reported by kojiishi - off by one bug in SniffName().
* Fix bug reported by kojiishi - bug in loading XmlDocument from SgmlReader -
 this was caused by the HTML document containing an embedded &lt;?xml version='1.0'?> 
 declaration, so the SgmlReader now strips these.
* Added special stripping of punctuation characters between attributes like ",".

### Release notes for 1.6

* Improve wrapping of HTML content with auto-generated &lt;html>&lt;/html> 
container tags.

### Release notes for 1.5

* Fix detection of ContentType=text/html and switch to HTML mode.
* Fix problems parsing DOCTYPE tag when case folding is on.
* Fix reading of XHTML DTD.
* Fix parsing of content of type CDATA that resulted in the error message 
'Cannot have ']]>' inside an XML CDATA block'.
* Fix parsing of http://www.virtuelvis.com/download/162/evilml.html.
* Fix parsing of attributes missing the equals sign: height"4"  (thanks to 
Ulrich Schwanitz for his fix).
* Fix 'SniffWhitespace' thanks to "Windy Winter".
* Added TestSuite project.

### Release notes for 1.4

* Added UserAgent string "Mozilla/4.0 (compatible;);" so that SgmlReader gets 
the right content from webservers.
* Fixed handling of HTML that does not start with root &lt;html> element tag.
* Fixed handling of built in HTML entities.

### Release notes for 1.3

* Changed ToUpper to CaseFolding enum and added support for "auto-folding" based 
on input
* Added support for &lt;![CDATA[...]]> blocks
* Added proper encoding support, including support for HTML &lt;META 
http-equiv="content-type".  This means output now has the correct XML declaration 
(unless you specify the new -noxml option) and any existing xml declarations in 
the input are stripped out so you don't end up with two.
* Added support for ASP &lt;%...%> blocks (thanks to Dan Whalin).
* Now strips out DOCTYPE by default since HTML DocTypes can cause problems for 
XmlDocument when it tries to load the HTML DTD.  but added "-doctype" switch for 
those who really need it to come through.
* Fix handling of Office 2000 &lt;?xml:namespace .../> declarations.
* Remove bogus attributes that have no name, in cases like &lt;class= "test">.

### Release notes for 1.2

* Converted back to Visual Studio 7.0 since this is the lowest common denominator.
* Added ToUpper switch for upper case folding, instead of the default lower case.
* Fix handling of UNC paths.
* Added OFX test suite.
* Fixed bug in parsing CDATA type elements (like &lt;script>&lt;!-- -->&lt;/script>).

### Release notes for 1.1

* Upgraded project to Visual Studio 7.1.
* Fixed bug in accessing https authenticated sites.
* Fixed bug in handling of content that contains nulls.
* Improved handling of &lt;!DOCTYPE with PUBLIC and no SYSTEM literal.
* Fixed bug in losing attributes when auto-closing tags.
* Fixed pretty printing output by adding WhitespaceHandling flag to SgmlReader.

### Release notes for 1.0.4

* Added -encoding option so you can change the encoding of the output file.

### Release notes for 1.0.3.26932

* Implemented ReadOuterXml and ReadInnerXml and fix some bugs in dealing with 
xmlns attributes and dealing with non-HTML tags.

### Release notes for 1.0.3

* Fixed some CLS compliance problems with using SgmlReader from VB and a null 
reference exception bug when loading SgmlReader from XmlDocument.

### Release notes for 1.0.2.21225

* Fixed bug in handling of encodings. Now uses the correct encoding returned 
from the HTTP server.

### Release notes for 1.0.2.21105

* Fixed bug in handling of input that contains blank lines at the top.

### Release notes for 1.0.2

* Added fix for the way IE & Netscape deal with characters in the range 0x80 
through 0x9F in HTML.

### Release notes for 1.0.1

* Fixed bug in handling of empty elements, like &lt;INPUT>.

### Release notes for 1.0

* Add wildcard support for command line utility.

### Release notes for 0.5

* Initial release.

## License

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.