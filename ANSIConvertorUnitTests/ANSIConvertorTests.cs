using Markdown_display;
using Markdown_display.Pattern;

namespace ANSIConvertorUnitTests
{
    public class ANSIConvertorTests
    {
        private string AddExtraLines(string text) => text + "\r\n\r\n";

        [Theory]
        [InlineData("**bold**", "\u001b[1mbold\u001b[22m\n\n")]
        [InlineData("_italic_", "\u001b[3mitalic\u001b[23m\n\n")]
        [InlineData("`monospaced`", "\u001b[7mmonospaced\u001b[27m\n\n")]

        [InlineData(" **bold** ", " \u001b[1mbold\u001b[22m \n\n")]
        [InlineData(" _italic_ ", " \u001b[3mitalic\u001b[23m \n\n")]
        [InlineData(" `monospaced` ", " \u001b[7mmonospaced\u001b[27m \n\n")]

        [InlineData("This word is **bold**", "This word is \u001b[1mbold\u001b[22m\n\n")]
        [InlineData("This word is _italic_", "This word is \u001b[3mitalic\u001b[23m\n\n")]
        [InlineData("This word is `monospaced`", "This word is \u001b[7mmonospaced\u001b[27m\n\n")]


        [InlineData("This word is **bold** and that`s cool", "This word is \u001b[1mbold\u001b[22m and that`s cool\n\n")]
        [InlineData("This word is _italic_ and that`s cool", "This word is \u001b[3mitalic\u001b[23m and that`s cool\n\n")]
        [InlineData("This word is `monospaced` and that`s cool", "This word is \u001b[7mmonospaced\u001b[27m and that`s cool\n\n")]

        [InlineData("**_**", "\u001b[1m_\u001b[22m\n\n")]
        [InlineData("`_`", "\u001b[7m_\u001b[27m\n\n")]

        [InlineData("Why this**work", "Why this**work\n\n")]
        [InlineData("Why this_work", "Why this_work\n\n")]
        [InlineData("Why this`work", "Why this`work\n\n")]


        [InlineData("**bold1** **bold2** **bold3**", "\u001b[1mbold1\u001b[22m \u001b[1mbold2\u001b[22m \u001b[1mbold3\u001b[22m\n\n")]
        [InlineData("_italic1_ _italic2_ _italic3_", "\u001b[3mitalic1\u001b[23m \u001b[3mitalic2\u001b[23m \u001b[3mitalic3\u001b[23m\n\n")]
        [InlineData("`monospaced1` `monospaced2` `monospaced3`", "\u001b[7mmonospaced1\u001b[27m \u001b[7mmonospaced2\u001b[27m \u001b[7mmonospaced3\u001b[27m\n\n")]

        [InlineData(" _good_job_ ", " \u001b[3mgood_job\u001b[23m \n\n")]
        [InlineData(" `good`job` ", " \u001b[7mgood`job\u001b[27m \n\n")]

        [InlineData(" **bold case** ", " \u001b[1mbold case\u001b[22m \n\n")]
        [InlineData(" _italic case_ ", " \u001b[3mitalic case\u001b[23m \n\n")]
        [InlineData(" `monospaced case` ", " \u001b[7mmonospaced case\u001b[27m \n\n")]

        [InlineData("**bold1**, **bold2**, **bold3**", "\u001b[1mbold1\u001b[22m, \u001b[1mbold2\u001b[22m, \u001b[1mbold3\u001b[22m\n\n")]
        [InlineData("_italic1_, _italic2_, _italic3_", "\u001b[3mitalic1\u001b[23m, \u001b[3mitalic2\u001b[23m, \u001b[3mitalic3\u001b[23m\n\n")]
        [InlineData("`monospaced1`, `monospaced2`, `monospaced3`", "\u001b[7mmonospaced1\u001b[27m, \u001b[7mmonospaced2\u001b[27m, \u001b[7mmonospaced3\u001b[27m\n\n")]

        [InlineData("**bold**, _italic_, `monospaced`", "\u001b[1mbold\u001b[22m, \u001b[3mitalic\u001b[23m, \u001b[7mmonospaced\u001b[27m\n\n")]
        [InlineData("**bold**, _ita_lic_, `mono`spaced`", "\u001b[1mbold\u001b[22m, \u001b[3mita_lic\u001b[23m, \u001b[7mmono`spaced\u001b[27m\n\n")]

        [InlineData("paragraph1\r\n\r\n", "paragraph1\n\n")]
        [InlineData("paragraph1\r\n\r\nparagraph2\r\n\r\nparagraph3\r\n\r\n", "paragraph1\n\nparagraph2\n\nparagraph3\n\n")]

        [InlineData("paragraph1\r\n```\r\npreformatted\r\n```", "paragraph1\r\n\u001b[7mpreformatted\u001b[27m\n\n")]
        [InlineData("paragraph1\r\n```\r\npreformatted\r\npreformatted `too`\r\nand _this_\r\n```", "paragraph1\r\n\u001b[7mpreformatted\r\npreformatted `too`\r\nand _this_\u001b[27m\n\n")]
        [InlineData("paragraph1\r\n```\r\npreformatted **bold**, _italic_, `monospaced`\r\n```", "paragraph1\r\n\u001b[7mpreformatted **bold**, _italic_, `monospaced`\u001b[27m\n\n")]


        public void DoConversionTest(string text, string expected)
        {
            //Arrange
            Patterns format = new ANSIPatterns();
            Convertor convertor = new(format);
            text = AddExtraLines(text);
            //Act
            string result = convertor.Start(text);
            //Assert
            Assert.Equal(expected, result);
        }
    }
}