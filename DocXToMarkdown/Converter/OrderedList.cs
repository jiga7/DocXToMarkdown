using System;
using Novacode;

namespace DocXToMarkdown.Converter {

  public class UnorderedList : BaseConverter {

    public UnorderedList( DocX d, Paragraph p ) : base( d, p )  { }

    public override string Convert() {
      return "* " + _text +Environment.NewLine;
    }

  }

}
