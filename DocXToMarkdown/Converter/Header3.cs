using System;
using Novacode;

namespace DocXToMarkdown.Converter {

  public class Header3 : BaseConverter {

    public Header3(Paragraph p ) : base( p )  { }

    public override string Convert() {
      return "### " + _text + " ###" + Environment.NewLine + Environment.NewLine;
    }

  }

}
