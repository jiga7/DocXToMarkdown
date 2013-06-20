using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Novacode;

namespace DocXToMarkdown.Converter {
  public abstract class BaseConverter {

    public BaseConverter( Paragraph p) {
      _paragraph = p;
    }

   public abstract string Convert();

   protected Paragraph _paragraph;
  }
}
