using System;
using System.Linq;
using DocXToMarkdown.Converter;
using Novacode;
using Xunit;

namespace DocXToMarkdown.Tests {

  public class ParagraphConverterTests {

    [Fact]
    public void Converter_ShouldCreateHeader1ForGivenStyle() {
      using( var doc = DocX.Load( "./docx/headers_and_paragraph.docx" ) ) {
        var result = ParagraphConverter.CreateForParagraph( doc.Paragraphs.First() );
        Assert.IsType<Header1>( result );
      }
    }
  }
}
