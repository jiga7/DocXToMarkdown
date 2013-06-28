using System;
using Novacode;

namespace DocXToMarkdown.Converter {

  public class Header5 : BaseConverter {

    public Header5(Paragraph p ) : base( p )  { }

    public override string Convert() {
      return "##### " + _text + " #####" + Environment.NewLine + Environment.NewLine;
    }

  }

}
