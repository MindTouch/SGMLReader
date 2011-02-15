/*
 * 
 * Copyright (c) 2007-2011 MindTouch. All rights reserved.
 * 
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using NUnit.Framework;
using Sgml;

namespace SGMLTests {

    [TestFixture]
    public partial class UnitTests {

        //--- Methods ---

        [Test]
        public void Convert_attribute_without_value_01() {
            Test("01.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Recover_from_attribute_with_missing_closing_quote_before_closing_tag_char_02() {
            Test("02.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Recover_from_attribute_with_missing_closing_quote_before_opening_tag_char_03() {
            Test("03.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Recover_from_text_with_wrong_entities_or_entities_with_missing_trailing_semicolon_04() {
            Test("04.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Read_text_with_32bit_numeric_entity_05() {
            Test("05.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Read_text_from_ms_office_06() {
            Test("06.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Recover_from_attribute_with_nested_quotes_07() {
            Test("07.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Allow_CData_section_with_xml_chars_08() {
            Test("08.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Convert_tags_to_lower_09() {
            Test("09.test", XmlRender.Passthrough, CaseFolding.ToLower, "html", true);
        }

        [Test]
        public void Test_whitespace_aware_processing_10() {
            Test("10.test", XmlRender.Passthrough, CaseFolding.None, "html", false);
        }

        [Test]
        public void Recover_from_attribute_value_with_extra_quote_11() {
            Test("11.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Recover_from_unclosed_xml_comment_12() {
            Test("12.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Allow_xml_only_apos_entity_in_html_13() {
            Test("13.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Recover_from_script_tag_as_root_element_14() {
            Test("14.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Read_namespaced_attributes_with_missing_namespace_declaration_15() {
            Test("15.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Decode_entity_16() {
            Test("16.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Convert_element_with_illegal_tag_name_17() {
            Test("17.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Strip_comments_in_CData_section_18() {
            Test("18.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Nest_contents_of_style_element_into_a_CData_section_19() {
            Test("19.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Dont_push_elements_out_of_the_body_element_even_when_illegal_inside_body_20() {
            Test("20.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Clone_document_with_invalid_attribute_declarations_21() {
            Test("21.test", XmlRender.DocClone, CaseFolding.None, "html", true);
        }

        [Test]
        public void Ignore_conditional_comments_22() {
            Test("22.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Preserve_explicit_and_implicit_attribute_and_element_namespaces_23() {
            Test("23.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Preserve_explicit_attribute_and_element_namespaces_24() {
            Test("24.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Clone_document_with_explicit_attribute_and_element_namespaces_25() {
            Test("25.test", XmlRender.DocClone, CaseFolding.None, "html", true);
        }

        [Test]
        public void Preserve_explicit_attribute_namespaces_26() {
            Test("26.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Clone_document_with_explicit_attribute_namespaces_with_clone_27() {
            Test("27.test", XmlRender.DocClone, CaseFolding.None, "html", true);
        }

        [Test]
        public void Clone_document_with_explicit_element_namespaces_with_clone_28() {
            Test("28.test", XmlRender.DocClone, CaseFolding.None, "html", true);
        }

        [Test]
        public void Read_namespaced_elements_with_missing_namespace_declaration_29() {
            Test("29.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Clone_document_with_namespaced_elements_with_missing_namespace_declaration_with_clone_30() {
            Test("30.test", XmlRender.DocClone, CaseFolding.None, "html", true);
        }

        [Test]
        public void Parse_html_document_without_closing_body_tag_31() {
            Test("31.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Parse_html_document_with_leading_whitespace_and_missing_closing_tag_32() {
            Test("32.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Parse_doctype_33() {
            Test("33.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test, Ignore]
        public void Push_invalid_element_out_of_body_tag_34() {

            // NOTE (bjorg): marked as ignore, because it conflicts with another behavior of never pushing elements from the body tag.
            Test("34.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Add_missing_closing_element_tags_35() {
            Test("35.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Preserve_xml_comments_inside_script_element_36() {
            Test("36.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Allow_CDData_section_with_markup_37() {
            Test("37.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Recover_from_rogue_open_tag_char_38() {
            Test("38.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Ignore_invalid_char_after_tag_name_39() {
            Test("39.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Convert_entity_to_char_code_40() {
            Test("40.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Attribute_with_missing_equal_sign_between_key_and_value_41() {
            Test("41.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Script_element_with_explicit_CDData_section_42() {
            Test("42.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Convert_tags_to_lower_43() {
            Test("43.test", XmlRender.Passthrough, CaseFolding.ToLower, "html", true);
        }

        [Test]
        public void Load_document_44() {
            Test("44.test", XmlRender.Doc, CaseFolding.None, "html", true);
        }

        [Test]
        public void Load_document_with_text_before_root_node_45() {
            Test("45.test", XmlRender.Doc, CaseFolding.None, "html", true);
        }

        [Test]
        public void Load_document_with_text_before_root_node_46() {

            // NOTE (steveb): this is a dup of the previous test
            Test("46.test", XmlRender.Doc, CaseFolding.None, "html", true);
        }

        [Test]
        public void Load_document_with_xml_comment_before_root_node_47() {
            Test("47.test", XmlRender.Doc, CaseFolding.None, "html", true);
        }

        [Test]
        public void Decode_numeric_entities_for_non_html_content_48() {
            Test("48.test", XmlRender.Passthrough, CaseFolding.None, null, true);
        }

        [Test]
        public void Load_document_with_nested_xml_declaration_49() {
            Test("49.test", XmlRender.Doc, CaseFolding.None, "html", true);
        }

        [Test]
        public void Handle_xml_processing_instruction_with_illegal_xml_namespace_50() {
            Test("50.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Close_elements_with_missing_closing_tags_51() {
            Test("51.test", XmlRender.Passthrough, CaseFolding.None, "html", true);
        }

        [Test]
        public void Clone_document_with_elements_with_missing_closing_tags_52() {
            Test("52.test", XmlRender.DocClone, CaseFolding.None, "html", true);
        }

        [Test]
        public void Read_ofx_content_53() {
            Test("53.test", XmlRender.Passthrough, CaseFolding.None, null, true);
        }

        [Test]
        public void Test_MoveToNextAttribute() {

            // Make sure we can do MoveToElement after reading multiple attributes.
            var r = new SgmlReader {
                InputStream = new StringReader("<test id='10' x='20'><a/><!--comment-->test</test>")
            };
            Assert.IsTrue(r.Read());
            while(r.MoveToNextAttribute()) {
                _log.Debug(r.Name);
            }
            if(r.MoveToElement()) {
                _log.Debug(r.ReadInnerXml());
            }
        }

        [Test]
        public void Test_for_illegal_char_value() {
            const string source = "&test";
            var reader = new SgmlReader {
                DocType = "HTML",
                WhitespaceHandling = WhitespaceHandling.All,
                StripDocType = true,
                InputStream = new StringReader(source),
                CaseFolding = CaseFolding.ToLower
            };

            // test
            var element = System.Xml.Linq.XElement.Load(reader);
            string value = element.Value;
            Assert.IsFalse(string.IsNullOrEmpty(value), "element has no value");
            Assert.AreNotEqual((char)65535, value[value.Length - 1], "unexpected -1 as last char");
        }
    }
}