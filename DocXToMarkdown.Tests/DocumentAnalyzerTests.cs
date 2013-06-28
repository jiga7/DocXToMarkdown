using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocXToMarkdown.Converter;
using Novacode;
using Xunit;

namespace DocXToMarkdown.Tests {
  public class DocumentAnalyzerTests {

    [Fact]
    public void DocumentAnalyzer_ShouldAnalyzeDocument() {
      using( var doc = DocX.Load( "./docx/headers_and_lists.docx" ) ) {
        var analyzer = new DocumentAnalyzer( doc );
        analyzer.Analyze();
        var result = analyzer.Result.Keys;
        Assert.Equal( 5, result.Count() );
        Assert.Equal( "Nagwek001", result.ElementAt( 0 ) );
        Assert.True( result.ElementAt( 3 ).StartsWith( "ordered_" ) );
        Assert.True( result.ElementAt( 4 ).StartsWith( "unordered_" ) );
      }
    }

    [Fact]
    public void DocumentAnalyzer_ShouldGuessPossiblyStyle() { 
      using( var doc = DocX.Load( "./docx/headers_and_lists.docx" ) ) {
        var analyzer = new DocumentAnalyzer( doc );
        analyzer.Analyze();
        var result = analyzer.Result.Values;
        Assert.Equal( 5, result.Count() );
        Assert.Equal( "Header1", result.ElementAt( 0 ) );
        Assert.Equal( "Header2", result.ElementAt( 1 ) );
        Assert.Equal( "P", result.ElementAt( 2 ) );
      }
    }
 
  }
}
