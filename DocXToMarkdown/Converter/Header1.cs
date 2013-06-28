using System;
using Novacode;

namespace DocXToMarkdown.Converter {

  public class Header1 : BaseConverter {

    public Header1(DocX d, Paragraph p ) : base( d, p )  { }

    public override string Convert() {
      return "# " + _text + " #"+ Environment.NewLine + Environment.NewLine;
    }

  }

}
