using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Novacode;

namespace DocXToMarkdown.Parser {

  public static class DocXParser {

    static DocXParser() {
    }

    public static object Parse( string path ) {
      if( String.IsNullOrWhiteSpace(path) ) return String.Empty;

      var sb = new StringBuilder();
      using( var doc = DocX.Load( path ) ) {
        foreach( var paragraph in doc.Paragraphs ) {
          sb.Append( analyzeParagraph( paragraph ) );
        }
      }

      return sb.ToString().TrimEnd();
    }

    private static string analyzeParagraph( Paragraph paragraph ) {
      var analyzer = ParagraphConverter.CreateForParagraph( paragraph );

      return analyzer.Convert();
    }
  }

}
