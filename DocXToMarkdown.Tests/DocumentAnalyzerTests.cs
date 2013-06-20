using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Novacode;
using Xunit;

namespace DocXToMarkdown.Tests {
  public class DocumentAnalyzerTests {

    [Fact]
    public void DocumentAnalyzer_ShouldAnalyzeDocument() {
      using( var doc = DocX.Load( "./docx/headers_and_lists.docx" ) ) {
        var analyzer = new DocumentAnalyzer( doc );
        analyzer.Analyze();
        var result = analyzer.Result;
        Assert.Equal( 5, result.Count() );
        Assert.True( result.ElementAt( 3 ).StartsWith( "ordered_" ) );
        Assert.True( result.ElementAt( 4 ).StartsWith( "unordered_" ) );
      }
    }
 
  }
}
