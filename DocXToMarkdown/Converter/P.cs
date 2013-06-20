using System;
using System.Linq;
using Novacode;

namespace DocXToMarkdown.Converter {

  public class P : BaseConverter {

    public P(Paragraph p ) : base( p )  { }

    public override string Convert() {
      if( String.IsNullOrWhiteSpace( _text ) ) return String.Empty;

      return _text + Environment.NewLine + Environment.NewLine;
    }
 
  }

}
