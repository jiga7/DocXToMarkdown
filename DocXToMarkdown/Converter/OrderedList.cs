using System;
using Novacode;

namespace DocXToMarkdown.Converter {

  public class UnorderedList : BaseConverter {

    public UnorderedList(Paragraph p ) : base( p )  { }

    public override string Convert() {
      return "* " + _paragraph.Text + Environment.NewLine;
    }

  }

}
