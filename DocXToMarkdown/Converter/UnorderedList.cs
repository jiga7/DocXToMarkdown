using System;
using Novacode;

namespace DocXToMarkdown.Converter {

  public class OrderedList : BaseConverter {

    public OrderedList(Paragraph p ) : base( p )  { }

    public override string Convert() {
      return "1. " + _text + Environment.NewLine;
    }

  }

}
