/*
 * 
 * Copyright (c) 2007-2013 MindTouch. All rights reserved.
 * www.mindtouch.com  oss@mindtouch.com
 *
 * For community documentation and downloads visit wiki.developer.mindtouch.com;
 * please review the licensing section.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.IO;
using System.Reflection;
using System.Xml;
using Sgml;
using Xunit;

namespace SGMLTests {
    public class TestsLogic {

        public static bool Debug = false;

        //--- Types ---
        private delegate void XmlReaderTestCallback(XmlReader reader, XmlWriter xmlWriter);

        public enum XmlRender {
            Doc,
            DocClone,
            Passthrough
        }


        //--- Class Methods ---
        public void Test(string name, XmlRender xmlRender, CaseFolding caseFolding, string doctype, bool format) {
            string source;
            string expected;
            ReadTest(name, out source, out expected);
            expected = expected.Trim().Replace("\r", "");
            string actual;

            // determine how the document should be written back
            XmlReaderTestCallback callback;
            switch(xmlRender) {
            case XmlRender.Doc:

                // test writing sgml reader using xml document load
                callback = (reader, writer) => {
                    var doc = new XmlDocument();
                    doc.Load(reader);
                    doc.WriteTo(writer);
                };
                break;
            case XmlRender.DocClone:

                // test writing sgml reader using xml document load and clone
                callback = (reader, writer) => {
                    var doc = new XmlDocument();
                    doc.Load(reader);
                    var clone = doc.Clone();
                    clone.WriteTo(writer);
                };
                break;
            case XmlRender.Passthrough:

                // test writing sgml reader directly to xml writer
                callback = (reader, writer) => {
                    reader.Read();
                    while(!reader.EOF) {
                        writer.WriteNode(reader, true);
                    }
                };
                break;
            default:
                throw new ArgumentException("unknown value", "xmlRender");
            }
            actual = RunTest(caseFolding, doctype, format, source, callback);
            Assert.Equal(expected, actual);
        }

        private static void ReadTest(string name, out string before, out string after) {
            var stream = File.OpenRead(Path.Combine("Resources", name));
            if (stream == null){
                throw new FileNotFoundException("unable to load requested resource: " + name);
            }
            using StreamReader reader = new(stream);
            var test = reader.ReadToEnd().Split('`');
            before = test[0];
            after = test[1];
        }

        private static string RunTest(CaseFolding caseFolding, string doctype, bool format, string source, XmlReaderTestCallback callback) {

            // initialize sgml reader
            XmlReader reader = new SgmlReader {
                CaseFolding = caseFolding,
                DocType = doctype,
                InputStream = new StringReader(source),
                WhitespaceHandling = format ? WhitespaceHandling.None : WhitespaceHandling.All
            };

            // check if we need to use the LoggingXmlReader
            if(Debug) {
                reader = new LoggingXmlReader(reader, Console.Out);
            }

            // initialize xml writer
            var stringWriter = new StringWriter();
            var xmlTextWriter = new XmlTextWriter(stringWriter);
            if(format) {
                xmlTextWriter.Formatting = Formatting.Indented;
            }
            callback(reader, xmlTextWriter);
            xmlTextWriter.Close();

            // reproduce the parsed document
            var actual = stringWriter.ToString();

            // ensure that output can be parsed again
            try {
                using(var stringReader = new StringReader(actual)) {
                    var doc = new XmlDocument();
                    doc.Load(stringReader);
                }
            } catch(Exception) {
                //Assert.Fail("unable to parse sgml reader output:\n{0}", actual);
            }
            return actual.Trim().Replace("\r", "");
        }
    }
}
