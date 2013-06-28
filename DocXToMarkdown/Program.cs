using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using DocXToMarkdown.Parser;
using Newtonsoft.Json;
using Novacode;

namespace DocXToMarkdown {

  class Program {

    static void Main( string[] args ) {
      var command = args[0];

      if( "/analyze".Equals( command ) )
        analyze( args[1] );
      if( "/convert".Equals( command ) )
        parse( args[1] );
    }

    private static void parse( string filename ) {
      var parser = new DocXParser( filename );
      var text = parser.Parse();

      var file = Path.GetFileNameWithoutExtension( filename );
      File.WriteAllText( file + ".md", text );
    }

    private static void analyze( string filename ) {
      var doc = DocX.Load( filename );
      var analyzer = new DocumentAnalyzer( doc );

      analyzer.Analyze();

      var json = JsonConvert.SerializeObject( analyzer.Result, new JsonSerializerSettings { Formatting = Newtonsoft.Json.Formatting.Indented } );
      Console.Write(json);
      var file = Path.GetFileNameWithoutExtension( filename );
      File.WriteAllText( file + ".json", json );
    }

  }

}
