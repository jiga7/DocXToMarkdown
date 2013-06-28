using System;
using System.IO;
using DocXToMarkdown.Parser;
using Xunit;

namespace DocXToMarkdown.Tests {

  public class ParserTests {

    [Fact]
    public void Parser_ForEmptyFilenameShouldReturnEmptyResult() {
      var parser = new DocXParser( String.Empty );
      var result = parser.Parse();
      Assert.Equal( String.Empty, result );
    }

    [Fact]
    public void Headers_ShouldProperParseHeaders() {
      var parser = new DocXParser( @"./docx/headers_and_paragraph.docx" );
      var result = parser.Parse();
      Assert.Equal( File.ReadAllText( @"./md/headers_and_paragraph.md" ), result );
    }

    [Fact]
    public void List_ShouldProperParseOrderedList() {
      var parser = new DocXParser( @"./docx/ordered_list_and_link.docx");
      var result = parser.Parse();
      Assert.Equal( File.ReadAllText( @"./md/ordered_list_and_link.md" ), result );
    }

    [Fact]
    public void List_ShouldProperParseUnorderedList() {
      var parser = new DocXParser( @"./docx/unordered_list.docx" );
      var result = parser.Parse();
      Assert.Equal( File.ReadAllText( @"./md/unordered_list.md" ), result );
    }

    [Fact]
    public void Picture_ShouldParsePicture() {
      var parser = new DocXParser( @"./docx/picture.docx" );
      var result = parser.Parse();
      Assert.Equal( "![Obraz 1](./images/image1.jpg)", result );
    }

  }

}
