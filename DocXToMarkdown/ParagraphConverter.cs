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
      _converters = JsonConvert.DeserializeObject<Dictionary<String, String>>( File.ReadAllText( @"settings.json" ) );
    }

    public static BaseConverter CreateForParagraph( Paragraph p ) {
      var isList = p.IsListItem;
      if( isList ) return createConverterForList( p );

      var type = Type.GetType( "DocXToMarkdown.Converter." + _converters[p.StyleName] );
      return (BaseConverter)Activator.CreateInstance( type, new [] { p } );
    }

    private static BaseConverter createConverterForList( Paragraph p ) {
      if( p.ListItemType == ListItemType.Numbered )
        return new OrderedList( p );
      else return new UnorderedList( p );

    }

    private static readonly IDictionary<String, String> _converters;
  }
}
