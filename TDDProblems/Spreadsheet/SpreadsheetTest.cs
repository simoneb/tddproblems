using System;
using NUnit.Framework;

namespace TDDProblems.Spreadsheet
{
    public class SpreadsheetTest
    {
        [Test]
        public void Cells_should_be_empty_by_default()
        {
            Sheet sheet = new Sheet();
            Assert.That(sheet["A1"], Is.Empty);
            Assert.That(sheet["ZX347"], Is.Empty);
        }

        [TestCase("A string", "A string")]
        [TestCase("A different string", "A different string")]
        [TestCase("", "")]
        public void Text_cells_should_be_stored(string input, string expected)
        {
            Sheet sheet = new Sheet();
            sheet["A21"] = input;

            Assert.That(sheet["A21"], Is.EqualTo(expected));
        }

        [Test]
        public void Many_cells_can_exist()
        {
            Sheet sheet = new Sheet();
            sheet["A1"] = "First";
            sheet["X27"] = "Second";
            sheet["ZX901"] = "Third";

            Assert.That(sheet["A1"], Is.EqualTo("First"));
            Assert.That(sheet["X27"], Is.EqualTo("Second"));
            Assert.That(sheet["ZX901"], Is.EqualTo("Third"));

            sheet["A1"] = "Fourth";

            Assert.That(sheet["A1"], Is.EqualTo("Fourth"));
            Assert.That(sheet["X27"], Is.EqualTo("Second"));
            Assert.That(sheet["ZX901"], Is.EqualTo("Third"));
        }

        [TestCase("X99", "X99")]
        [TestCase("14", "14")]
        [TestCase(" 99 X", " 99 X")]
        [TestCase(" 1234 ", "1234")]
        [TestCase(" ", " ")]
        public void Test_that_numeric_strings_are_identified(string input, string expected)
        {
            Sheet sheet = new Sheet();
            String theCell = "A21";

            sheet[theCell]= input;
            AssertCellValue(sheet, theCell, expected);
        }

        [TestCase("Some string", "Some string")]
        [TestCase(" 1234 ", " 1234 ")]
        [TestCase("=7", "=7")]
        public void Test_That_We_Have_Access_To_Cell_Literal_Values_For_Editing(string expected, string input)
        {
            Sheet sheet = new Sheet();
            String theCell = "A21";

            sheet[theCell] = input;
            Assert.That(sheet.GetLiteral(theCell), Is.EqualTo(expected));
        }

        [Test]
        public void Test_malformed_formula()
        {
            Sheet sheet = new Sheet();
            sheet["B1"] = " =7";

            Assert.That(sheet["B1"], Is.EqualTo(" =7"));
            Assert.That(sheet.GetLiteral("B1"), Is.EqualTo(" =7"));
        }

        [Test]
        public void Test_Constant_Formula()
        {
            Sheet sheet = new Sheet();
            sheet["A1"] = "=7";
            Assert.That(sheet.GetLiteral("A1"), Is.EqualTo("=7"));
            Assert.That(sheet["A1"], Is.EqualTo("7"));
        }

        [TestCase("6")]
        [TestCase("7")]
        public void Test_Parentheses(string value)
        {
            Sheet sheet = new Sheet();
            sheet["A1"] = string.Format("=({0})", value);
            Assert.That(sheet["A1"], Is.EqualTo(value));
        }

        [Test]
        public void testDeepParentheses()
        {
            Sheet sheet = new Sheet();
            sheet["A1"] = "=((((10))))";
            Assert.That(sheet["A1"], Is.EqualTo("10"));
        }

        [Test]
        public void testMultiply()
        {
            Sheet sheet = new Sheet();
            sheet["A1"] = "=2*3*4";
            Assert.That(sheet["A1"], Is.EqualTo("24"));
        }

        [Test]
        public void testAdd()
        {
            Sheet sheet = new Sheet();
            sheet["A1"] = "=71+2+3";
            Assert.That(sheet["A1"], Is.EqualTo("76"));
        }

        private static void AssertCellValue(Sheet s, string cell, string value)
        {
            Assert.That(s[cell], Is.EqualTo(value));
        }
    }
}