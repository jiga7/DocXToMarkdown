using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DocXToMarkdown.Converter;
using Newtonsoft.Json;
using Novacode;

namespace DocXToMarkdown {
  public static class ParagraphConverter {

    static ParagraphConverter() {
      _converters = JsonConvert.DeserializeObject<Dictionary<String, String>>( File.ReadAllText( @"./Configuration/pl.json" ) );
    }

    public static BaseConverter CreateForParagraph( Paragraph p ) {
      var type = Type.GetType( "DocXToMarkdown.Converter." + _converters[p.StyleName] );
      return (BaseConverter)Activator.CreateInstance( type, new [] { p } );
    }

    private static readonly IDictionary<String, String> _converters;
  }
}
