using System;
using Novacode;

namespace DocXToMarkdown.Converter {

  public class Header2 : BaseConverter {

    public Header2( DocX d, Paragraph p ) : base( d,p )  { }

    public override string Convert() {
      return "## " + _text + " ##"+ Environment.NewLine + Environment.NewLine;
    }

  }

}
