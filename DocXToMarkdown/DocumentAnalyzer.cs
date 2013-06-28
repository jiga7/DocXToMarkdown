using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Novacode;

namespace DocXToMarkdown {

  public class DocumentAnalyzer {

    public DocumentAnalyzer( DocX document ) {
      _document = document;
    }

    public void Analyze() {
      _result = _document.Paragraphs.Select( p => getStyleName( p ) ).Distinct();
    }

    private String getStyleName( Paragraph p ) {
      if( p.IsListItem ) {
        return ( p.ListItemType == ListItemType.Numbered ? "ordered_" : "unordered_" ) + p.StyleName;
      } else return p.StyleName;
    }

    public IDictionary<String, String> Result {
      get {
        return _result.ToDictionary( s => s, s => guessType( s ) );
      }
    }

    private String guessType( string styleName ) {
      var match = Regex.Match( styleName, @"\d+" );
      if( match.Success) {
        var number = Regex.Replace( match.Groups[0].Value, "^0+", String.Empty );
        return "Header" + (number.Length > 0 ? number : "1");
      }

      return "P";
    }

    private IEnumerable<String> _result;
    private DocX _document; 
  }

}
