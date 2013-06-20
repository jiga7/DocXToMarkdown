using System;
using Novacode;

namespace DocXToMarkdown.Converter {

  public class P : BaseConverter {

    public P(Paragraph p ) : base( p )  { }

    public override string Convert() {
      if( String.IsNullOrWhiteSpace( _paragraph.Text ) ) return String.Empty;
      return _paragraph.Text + Environment.NewLine + Environment.NewLine;
    }

  }

}
