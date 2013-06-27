using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Novacode;

namespace DocXToMarkdown {

  class Program {

    static void Main( string[] args ) {
      var command = args[0];

      if( "/analyze".Equals( command ) )
        analyze( args[1] );

      Console.ReadKey();
    }

    private static void analyze( string filename ) {
      var doc = DocX.Load( filename );
      var analyzer = new DocumentAnalyzer( doc );

      analyzer.Analyze();

      var json = JsonConvert.SerializeObject( analyzer.Result.ToDictionary( s => s, _ => String.Empty ), new JsonSerializerSettings { Formatting = Newtonsoft.Json.Formatting.Indented } );
      Console.WriteLine(json);
      File.WriteAllText( "settings.json", json );
    }

  }

}
