using System;
using System.IO;
using DocXToMarkdown.Parser;
using Xunit;

namespace DocXToMarkdown.Tests {

  public class ParserTests {

    [Fact]
    public void Parser_ShouldExists() {
      Assert.DoesNotThrow( () => DocXParser.Parse( String.Empty ) );
    }

    [Fact]
    public void Parser_ForEmptyFilenameShouldReturnEmptyResult() {
      var result = DocXParser.Parse( String.Empty );
      Assert.Equal( String.Empty, result );
    }

    [Fact]
    public void Headers_ShouldProperParseHeaders() {
      var result = DocXParser.Parse( @"./docx/headers_and_paragraph.docx" );
      Assert.Equal( File.ReadAllText( @"./md/headers_and_paragraph.md" ), result );
    }

    [Fact]
    public void List_ShouldProperParseOrderedList() {
      var result = DocXParser.Parse( @"./docx/ordered_list.docx" );
      Assert.Equal( File.ReadAllText( @"./md/ordered_list.md" ), result );
    }

    [Fact]
    public void List_ShouldProperParseUnorderedList() {
      var result = DocXParser.Parse( @"./docx/unordered_list.docx" );
      Assert.Equal( File.ReadAllText( @"./md/unordered_list.md" ), result );
    }
  }
}
