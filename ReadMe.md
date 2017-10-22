# SgmlReaderCore - Convert (almost) any HTML to valid XML (everywhere using C#)

SgmlReader is a versatile C# .NET library written by Chris Lovett for parsing 
HTML/SGML files using the XmlReader API. A command line utility is also provided 
which outputs the well formed XML result.
[Exodus](http://www.exodusfinancas.com.br) also uses the SgmlReader library in its framework. Changes in order to let OFX parsing was applied in the spirit 
of the original author, we're providing these changes in our Exodus Repository: 
[Exodus Sistemas repository](https://github.com/ExodusSistemas/SGMLReaderCore).

## SgmlReaderCore API

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

### SgmlReaderCore Properties

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

## SgmlReaderCore.dll Command Line Tool

### Usage

The command line executable version has the following options:

    dotnet sgmlreader.dll <options> [InputUri] [OutputFile]

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

    dotnet sgmlreader.dll -html *.htm *.xml

Converts all the MSN home page to XML storing the result in the local file 
"msn.xml".

    dotnet sgmlreader.dll -html http://www.msn.com -proxy myproxy:80 msn.xml

Converts the given OFX file to XML using the SGML DTD "ofx160.dtd" specified in 
the test.ofx file.

    dotnet sgmlreader.dll -dtd ofx160.dtd test.ofx ofx.xml

## Community
If you have questions, please post them on 
[StackOverflow](http://stackoverflow.com/questions/tagged/sgmlreadercore) and tag 
them with *sgmlreader*.  You may also email bugs, feedback and/or feature 
requests to <a href="mailto:clovett@microsoft.com">Chris Lovett</a>.

If you fix an issue, please submit follow these guidelines:

1. Make sure the code formatting is **identical** to the existing code formatting. 
You know that you're doing it right if your code is indistinguishable from
existing code.
1. Run the unit test to make sure no regressions are being introduced.
1. Add a unit test to confirm your fix or feature.
1. Submit a pull request on [GitHub](https://github.com/ExodusSistemas/SGMLReaderCore).

## Release History
*Note:* since this is a fork for diferent platforms, the version and changes should be handled diferently from the orignial library on [GitHub](https://github.com/ExodusSistemas/SGMLReaderCore); 


### Release notes for 0.9.0.0 (2017-Oct-21)

* First commit with changes originated from fork from version 1.8.12 from [GitHub](https://github.com/ExodusSistemas/SGMLReaderCore)

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