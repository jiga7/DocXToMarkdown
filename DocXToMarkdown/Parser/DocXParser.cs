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

    public DocXParser() {
      var settings = Path.GetFileNameWithoutExtension( Global.Filename ) + ".json";
      if( !File.Exists( settings ) ) settings = Environment.CurrentDirectory + "/settings.json";
      _converters = JsonConvert.DeserializeObject<Dictionary<String, String>>( File.ReadAllText( settings ) );
    }

    public string Parse() {
      var sb = new StringBuilder();
      using( var doc = DocX.Load( Global.Filename ) ) {
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

    private readonly IDictionary<String, String> _converters;
  }

}
