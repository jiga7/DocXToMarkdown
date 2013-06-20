﻿using System;
using Novacode;

namespace DocXToMarkdown.Converter {

  public class Header1 : BaseConverter {

    public Header1(Paragraph p ) : base( p )  { }

    public override string Convert() {
      return "# " + _paragraph.Text + " #"+ Environment.NewLine + Environment.NewLine;
    }

  }

}
