using System;
using Novacode;

namespace DocXToMarkdown.Converter {

  public class Header2 : BaseConverter {

    public Header2(Paragraph p ) : base( p )  { }

    public override string Convert() {
      return "## " + _paragraph.Text + " ##"+ Environment.NewLine + Environment.NewLine;
    }

  }

}
