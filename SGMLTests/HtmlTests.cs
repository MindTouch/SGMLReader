/*
 * 
 * Copyright (c) 2007-2011 MindTouch. All rights reserved.
 * 
 */

using NUnit.Framework;
using Sgml;

namespace SGMLTests {

    [TestFixture]
    public partial class UnitTests {

        //--- Methods ---

        [Test]
        public void Attribute_without_value_01() {
            Test("01.test", XmlRender.Load, CaseFolding.None, "html", true);
        }

        [Test]
        public void Attribute_with_missing_closing_quote_before_gt_char_02() {
            Test("02.test", XmlRender.Load, CaseFolding.None, "html", true);
        }

        [Test]
        public void Attribute_with_missing_closing_quote_before_lt_char_03() {
            Test("03.test", XmlRender.Load, CaseFolding.None, "html", true);
        }

        [Test]
        public void Text_with_wrong_entities_or_entities_with_missing_trailing_semicolon_04() {
            Test("04.test", XmlRender.Load, CaseFolding.None, "html", true);
        }

        [Test]
        public void Text_with_32bit_numeric_entity_05() {
            Test("05.test", XmlRender.Load, CaseFolding.None, "html", true);
        }

        [Test]
        public void Text_from_ms_office_06() {
            Test("06.test", XmlRender.Load, CaseFolding.None, "html", true);
        }

        [Test]
        public void Attribute_with_nested_quotes_07() {
            Test("07.test", XmlRender.Load, CaseFolding.None, "html", true);
        }

        [Test]
        public void CData_section_with_xml_chars_08() {
            Test("08.test", XmlRender.Load, CaseFolding.None, "html", true);
        }

        [Test]
        public void Convert_markup_tolower_09() {
            Test("09.test", XmlRender.Load, CaseFolding.ToLower, "html", true);
        }
    }
}

