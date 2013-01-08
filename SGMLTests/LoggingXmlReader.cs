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
using System.Xml;
using log4net;
using NUnit.Framework;
using Sgml;

namespace SGMLTests {
    public class LoggingXmlReader : XmlReader {

        //--- Fields ---
        private readonly XmlReader _reader;
        private readonly TextWriter _logger;

        //--- Constructors ---
        public LoggingXmlReader(XmlReader reader, TextWriter logger) {
            _reader = reader;
            _logger = logger;
        }

        //--- Properties ---
        public override XmlNodeType NodeType
        {
            get
            {
                var result = _reader.NodeType;
                _logger.WriteLine("NodeType = {0}", result);
                return result;
            }
        }

        public override string Name
        {
            get
            {
                var result = _reader.Name;
                _logger.WriteLine("Name = {0}", result);
                return result;
            }
        }

        public override string LocalName
        {
            get
            {
                var result = _reader.LocalName;
                _logger.WriteLine("LocalName = {0}", result);
                return result;
            }
        }

        public override string NamespaceURI
        {
            get
            {
                var result = _reader.NamespaceURI;
                _logger.WriteLine("NamespaceURI = {0}", result);
                return result;
            }
        }

        public override string Prefix
        {
            get
            {
                var result = _reader.Prefix;
                _logger.WriteLine("Prefix = {0}", result);
                return result;
            }
        }

        public override bool HasValue
        {
            get
            {
                var result = _reader.HasValue;
                _logger.WriteLine("HasValue = {0}", result);
                return result;
            }
        }

        public override string Value
        {
            get
            {
                var result = _reader.Value;
                _logger.WriteLine("Value = {0}", result);
                return result;
            }
        }

        public override int Depth
        {
            get
            {
                var result = _reader.Depth;
                _logger.WriteLine("Depth = {0}", result);
                return result;
            }
        }

        public override string BaseURI
        {
            get
            {
                var result = _reader.BaseURI;
                _logger.WriteLine("BaseURI = {0}", result);
                return result;
            }
        }

        public override bool IsEmptyElement
        {
            get
            {
                var result = _reader.IsEmptyElement;
                _logger.WriteLine("IsEmptyElement = {0}", result);
                return result;
            }
        }

        public override bool IsDefault
        {
            get
            {
                var result = _reader.IsDefault;
                _logger.WriteLine("IsDefault = {0}", result);
                return result;
            }
        }

        public override char QuoteChar
        {
            get
            {
                var result = _reader.QuoteChar;
                _logger.WriteLine("QuoteChar = {0}", result);
                return result;
            }
        }

        public override XmlSpace XmlSpace
        {
            get
            {
                var result = _reader.XmlSpace;
                _logger.WriteLine("XmlSpace = {0}", result);
                return result;
            }
        }

        public override string XmlLang
        {
            get
            {
                var result = _reader.XmlLang;
                _logger.WriteLine("XmlLang = {0}", result);
                return result;
            }
        }
        public override int AttributeCount
        {
            get
            {
                var result = _reader.AttributeCount;
                _logger.WriteLine("AttributeCount = {0}", result);
                return result;
            }
        }

        public override string this[int i]
        {
            get
            {
                var result = _reader[i];
                _logger.WriteLine("this[i] = {0}", result);
                return result;
            }
        }

        public override string this[string name]
        {
            get
            {
                var result = _reader[name];
                _logger.WriteLine("this[name] = {0}", result);
                return result;
            }
        }

        public override string this[string name, string namespaceURI]
        {
            get
            {
                var result = _reader[name, namespaceURI];
                _logger.WriteLine("this[name, namespaceURI] = {0}", result);
                return result;
            }
        }

        public override XmlNameTable NameTable
        {
            get
            {
                var result = _reader.NameTable;
                _logger.WriteLine("NameTable = {0}", result);
                return result;
            }
        }

        public override bool EOF
        {
            get
            {
                var result = _reader.EOF;
                _logger.WriteLine("EOF = {0}", result);
                return result;
            }
        }

        public override ReadState ReadState
        {
            get
            {
                var result = _reader.ReadState;
               _logger.WriteLine("ReadState = {0}", result);
                return result;
            }
        }

        //--- Methods ---
        public override string GetAttribute(string name)
        {
            var result = _reader.GetAttribute(name);
            _logger.WriteLine("GetAttribute('{1}') = {0}", result, name);
            return result;
        }

        public override string GetAttribute(string name, string namespaceURI)
        {
            var result = _reader.GetAttribute(name, namespaceURI);
            _logger.WriteLine("GetAttribute('{1}', '{2}') = {0}", result, name, namespaceURI);
            return result;
        }

        public override string GetAttribute(int i)
        {
            var result = _reader.GetAttribute(i);
            _logger.WriteLine("GetAttribute({1}) = {0}", result, i);
            return result;
        }

        public override bool MoveToAttribute(string name)
        {
            var result = _reader.MoveToAttribute(name);
            _logger.WriteLine("MoveToAttribute('{1}') = {0}", result, name);
            return result;
        }

        public override bool MoveToAttribute(string name, string ns)
        {
            var result = _reader.MoveToAttribute(name, ns);
            _logger.WriteLine("MoveToAttribute('{1}', '{2}') = {0}", result, name, ns);
            return result;
        }

        public override void MoveToAttribute(int i)
        {
            _reader.MoveToAttribute(i);
            _logger.WriteLine("MoveToAttribute({0})", i);
        }

        public override bool MoveToFirstAttribute()
        {
            var result = _reader.MoveToFirstAttribute();
            _logger.WriteLine("MoveToFirstAttribute() = {0}", result);
            return result;
        }

        public override bool MoveToNextAttribute()
        {
            var result = _reader.MoveToNextAttribute();
            _logger.WriteLine("MoveToNextAttribute() = {0}", result);
            return result;
        }

        public override bool MoveToElement()
        {
            var result = _reader.MoveToElement();
            _logger.WriteLine("MoveToElement() = {0}", result);
            return result;
        }

        public override bool Read()
        {
            var result = _reader.Read();
            _logger.WriteLine("Read() = {0}", result);
            return result;
        }

        public override void Close()
        {
            _reader.Close();
            _logger.WriteLine("Close()");
        }

        public override string ReadString()
        {
            var result = _reader.ReadString();
            _logger.WriteLine("ReadString() = {0}", result);
            return result;
        }

        public override string ReadInnerXml()
        {
            var result = _reader.ReadInnerXml();
            _logger.WriteLine("ReadInnerXml() = {0}", result);
            return result;
        }

        public override string ReadOuterXml()
        {
            var result = _reader.ReadOuterXml();
            _logger.WriteLine("ReadOuterXml() = {0}", result);
            return result;
        }

        public override string LookupNamespace(string prefix)
        {
            var result = _reader.LookupNamespace(prefix);
            _logger.WriteLine("LookupNamespace('{1}') = {0}", result, prefix);
            return result;
        }

        public override void ResolveEntity()
        {
            _reader.ResolveEntity();
            _logger.WriteLine("ResolveEntity()");
        }

        public override bool ReadAttributeValue()
        {
            var result = _reader.ReadAttributeValue();
            _logger.WriteLine("ReadAttributeValue() = {0}", result);
            return result;
        }
    }
}

