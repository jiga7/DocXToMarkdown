using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Novacode;

namespace DocXToMarkdown {

  public class DocumentAnalyzer {

    public DocumentAnalyzer( DocX document ) {
      _document = document;
    }

    public void Analyze() {
      _result = _document.Paragraphs.Select( p => getStyleName( p ) ).Distinct();
    }

    private string getStyleName( Paragraph p ) {
      if( p.IsListItem ) {
        return ( p.ListItemType == ListItemType.Numbered ? "ordered_" : "unordered_" ) + p.StyleName;
      } else return p.StyleName;
    }

    public IEnumerable<String> Result {
      get {
        return _result;
      }
    }

    private IEnumerable<String> _result;
    private DocX _document; 
  }

}
