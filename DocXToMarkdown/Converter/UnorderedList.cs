using System;
using Novacode;

namespace DocXToMarkdown.Converter {

  public class OrderedList : BaseConverter {

    public OrderedList( DocX d, Paragraph p ) : base( d, p )  { }

    public override string Convert() {
      return "1. " + _text + Environment.NewLine;
    }

  }

}
