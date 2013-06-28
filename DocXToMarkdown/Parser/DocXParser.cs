using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DocXToMarkdown.Converter;
using Newtonsoft.Json;
using Novacode;

namespace DocXToMarkdown.Parser {

  public class DocXParser {

    public DocXParser( string filename ) {
      _filename = filename;
      var settings = Path.GetFileNameWithoutExtension( filename ) + ".json";
      if( !File.Exists( settings ) ) settings = "settings.json";
      _converters = JsonConvert.DeserializeObject<Dictionary<String, String>>( File.ReadAllText( settings ) );
    }

    public string Parse() {
      if( String.IsNullOrWhiteSpace(_filename) ) return String.Empty;

      var sb = new StringBuilder();
      using( var doc = DocX.Load( _filename ) ) {
        foreach( var paragraph in doc.Paragraphs ) {
          sb.Append( analyzeParagraph( doc, paragraph ) );
        }
      }

      return sb.ToString().TrimEnd();
    }

    private string analyzeParagraph( DocX doc, Paragraph paragraph ) {
      var analyzer = createForParagraph( doc, paragraph );

      return analyzer.Convert();
    }

    private BaseConverter createForParagraph( DocX doc, Paragraph paragraph ) {
      var isList = paragraph.IsListItem;
      if( isList ) return createConverterForList( doc, paragraph );

      var type = Type.GetType( "DocXToMarkdown.Converter." + _converters[paragraph.StyleName] );
      return (BaseConverter)Activator.CreateInstance( type, new object[] { doc, paragraph } );
    }

    private BaseConverter createConverterForList( DocX doc, Paragraph paragraph ) {
      if( paragraph.ListItemType == ListItemType.Numbered )
        return new OrderedList( doc, paragraph );
      else return new UnorderedList( doc, paragraph ); 
    }

    private readonly string _filename;
    private readonly IDictionary<String, String> _converters;
  }

}
