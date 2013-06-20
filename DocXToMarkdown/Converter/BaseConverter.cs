using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Novacode;

namespace DocXToMarkdown.Converter {

  public abstract class BaseConverter {

    public BaseConverter( Paragraph p ) {
      _paragraph = p;
      _text = Sanitize( _paragraph.Text );
      CheckHiperlinks();
    }

    private void CheckHiperlinks() {
      if( _paragraph.Hyperlinks.Count > 0 ) {
        var link = _paragraph.Hyperlinks.First();
        _text = "[" + _text  + "](" + link.Uri.AbsoluteUri + ")";
      }
    }

    public abstract string Convert();

    protected virtual string Sanitize( string text ) {
      return text.TrimStart( '\t' );
    }

    protected Paragraph _paragraph;
    protected string _text;
  }

}
