using System;
using Novacode;

namespace DocXToMarkdown.Converter {

  public class OrderedList : BaseConverter {

    public OrderedList(Paragraph p ) : base( p )  { }

    public override string Convert() {
      return "1. " + _paragraph.Text + Environment.NewLine;
    }

  }

}
