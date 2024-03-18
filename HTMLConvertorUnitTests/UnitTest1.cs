using Microsoft.VisualBasic;
using Markdown_display;
using Markdown_display.Pattern;


namespace HTMLConvertorUnitTests
{
    public class UnitTest1
    {
        private string AddExtraLines(string text) => text + "\r\n\r\n";

        [Theory]
        [InlineData("**bold**", "<p>\n<b>bold</b>\n</p>\n")]
        [InlineData("_italic_", "<p>\n<i>italic</i>\n</p>\n")]
        [InlineData("`monospaced`", "<p>\n<tt>monospaced</tt>\n</p>\n")]

        [InlineData(" **bold** ", "<p>\n <b>bold</b> \n</p>\n")]
        [InlineData(" _italic_ ", "<p>\n <i>italic</i> \n</p>\n")]
        [InlineData(" `monospaced` ", "<p>\n <tt>monospaced</tt> \n</p>\n")]

        [InlineData("This word is **bold**", "<p>\nThis word is <b>bold</b>\n</p>\n")]
        [InlineData("This word is _italic_", "<p>\nThis word is <i>italic</i>\n</p>\n")]
        [InlineData("This word is `monospaced`", "<p>\nThis word is <tt>monospaced</tt>\n</p>\n")]


        [InlineData("This word is **bold** and that`s cool", "<p>\nThis word is <b>bold</b> and that`s cool\n</p>\n")]
        [InlineData("This word is _italic_ and that`s cool", "<p>\nThis word is <i>italic</i> and that`s cool\n</p>\n")]
        [InlineData("This word is `monospaced` and that`s cool", "<p>\nThis word is <tt>monospaced</tt> and that`s cool\n</p>\n")]

        [InlineData("**_**", "<p>\n<b>_</b>\n</p>\n")]
        [InlineData("`_`", "<p>\n<tt>_</tt>\n</p>\n")]

        [InlineData("Why this**work", "<p>\nWhy this**work\n</p>\n")]
        [InlineData("Why this_work", "<p>\nWhy this_work\n</p>\n")]
        [InlineData("Why this`work", "<p>\nWhy this`work\n</p>\n")]


        [InlineData("**bold1** **bold2** **bold3**", "<p>\n<b>bold1</b> <b>bold2</b> <b>bold3</b>\n</p>\n")]
        [InlineData("_italic1_ _italic2_ _italic3_", "<p>\n<i>italic1</i> <i>italic2</i> <i>italic3</i>\n</p>\n")]
        [InlineData("`monospaced1` `monospaced2` `monospaced3`", "<p>\n<tt>monospaced1</tt> <tt>monospaced2</tt> <tt>monospaced3</tt>\n</p>\n")]

        [InlineData(" _good_job_ ", "<p>\n <i>good_job</i> \n</p>\n")]
        [InlineData(" `good`job` ", "<p>\n <tt>good`job</tt> \n</p>\n")]

        [InlineData(" **bold case** ", "<p>\n <b>bold case</b> \n</p>\n")]
        [InlineData(" _italic case_ ", "<p>\n <i>italic case</i> \n</p>\n")]
        [InlineData(" `monospaced case` ", "<p>\n <tt>monospaced case</tt> \n</p>\n")]

        [InlineData("**bold1**, **bold2**, **bold3**", "<p>\n<b>bold1</b>, <b>bold2</b>, <b>bold3</b>\n</p>\n")]
        [InlineData("_italic1_, _italic2_, _italic3_", "<p>\n<i>italic1</i>, <i>italic2</i>, <i>italic3</i>\n</p>\n")]
        [InlineData("`monospaced1`, `monospaced2`, `monospaced3`", "<p>\n<tt>monospaced1</tt>, <tt>monospaced2</tt>, <tt>monospaced3</tt>\n</p>\n")]

        [InlineData("**bold**, _italic_, `monospaced`", "<p>\n<b>bold</b>, <i>italic</i>, <tt>monospaced</tt>\n</p>\n")]
        [InlineData("**bold**, _ita_lic_, `mono`spaced`", "<p>\n<b>bold</b>, <i>ita_lic</i>, <tt>mono`spaced</tt>\n</p>\n")]

        [InlineData("paragraph1\r\n\r\n", "<p>\nparagraph1\n</p>\n")]
        [InlineData("paragraph1\r\n\r\nparagraph2\r\n\r\nparagraph3\r\n\r\n", "<p>\nparagraph1\n</p>\n<p>\nparagraph2\n</p>\n<p>\nparagraph3\n</p>\n")]

        [InlineData("paragraph1\r\n```\r\npreformatted\r\n``` ", "<p>\nparagraph1\r\n<pre>preformatted</pre> \n</p>\n")]
        [InlineData("paragraph1\r\n```\r\npreformatted\r\npreformatted `too`\r\nand _this_\r\n``` ", "<p>\nparagraph1\r\n<pre>preformatted\r\npreformatted `too`\r\nand _this_</pre> \n</p>\n")]
        [InlineData("paragraph1\r\n```\r\npreformatted **bold**, _italic_, `monospaced`\r\n``` ", "<p>\nparagraph1\r\n<pre>preformatted **bold**, _italic_, `monospaced`</pre> \n</p>\n")]


        public void DoConversionTest(string text, string expected)
        {
            //Arrange
            Convertor convertor = new(new HTMLPatterns());
            text = AddExtraLines(text);
            //Act
            string result = convertor.Start(text);
            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("**_text_**", "Convertion error on \"**_text_**\"")]
        [InlineData("**`text`**", "Convertion error on \"**`text`**\"")]
        [InlineData("_`text`_", "Convertion error on \"_`text`_\"")]
        [InlineData("**`_text_`**", "Convertion error on \"**`_text_`**\"")]
        [InlineData("`_**text**_`", "Convertion error on \"`_**text**_`\"")]

        [InlineData(" **text", "Convertion error on \"**text\"")]
        [InlineData(" `text", "Convertion error on \"`text\"")]
        [InlineData(" _text", "Convertion error on \"_text\"")]

        [InlineData(" `te`xt", "Convertion error on \"`te`xt\"")]
        [InlineData(" _te_xt", "Convertion error on \"_te_xt\"")]

        [InlineData(" **text **bold**", "Convertion error on \"**text\"")]
        [InlineData(" `text `monospaced`", "Convertion error on \"`text\"")]
        [InlineData(" _text _italic_", "Convertion error on \"_text\"")]

        [InlineData(" **** ", "Convertion error on \"****\"")]
        [InlineData(" `` ", "Convertion error on \"``\"")]
        [InlineData(" __ ", "Convertion error on \"__\"")]
        public void ErrorDoConversionTest(string text, string expected)
        {
            //Arrange
            Convertor convertor = new(new HTMLPatterns());
            text = AddExtraLines(text);
            //Act
            Exception exception = Assert.Throws<Exception>(() => _ = convertor.Start(text));
            //Assert
            Assert.Equal(expected, exception.Message);
        }
    }
}