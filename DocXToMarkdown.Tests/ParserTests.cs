using System;
using System.IO;
using DocXToMarkdown.Parser;
using Xunit;

namespace DocXToMarkdown.Tests {

  public class ParserTests {

    [Fact]
    public void Headers_ShouldProperParseHeaders() {
      Global.Filename = @"./docx/headers_and_paragraph.docx";
      var parser = new DocXParser();
      var result = parser.Parse();
      Assert.Equal( File.ReadAllText( @"./md/headers_and_paragraph.md" ), result );
    }

    [Fact]
    public void List_ShouldProperParseOrderedList() {
      Global.Filename = @"./docx/ordered_list_and_link.docx";
      var parser = new DocXParser();
      var result = parser.Parse();
      Assert.Equal( File.ReadAllText( @"./md/ordered_list_and_link.md" ), result );
    }

    [Fact]
    public void List_ShouldProperParseUnorderedList() {
      Global.Filename = @"./docx/unordered_list.docx";
      var parser = new DocXParser();
      var result = parser.Parse();
      Assert.Equal( File.ReadAllText( @"./md/unordered_list.md" ), result );
    }

    [Fact]
    public void Picture_ShouldParsePicture() {
      Global.Filename = @"./docx/picture.docx";
      var parser = new DocXParser( );
      var result = parser.Parse();
      Assert.Equal( "![Obraz 1](./picture_images/image1.jpg)", result );
    }

  }

}
