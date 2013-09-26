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

  public static class Global {
    public static String Filename = String.Empty;
  }

  class Program {

    static void Main( string[] args ) {
      if( args.Length < 2 ) {
        Console.WriteLine( @"Arguments are: <command> <filename> where <command> could be ""/analyze"" or ""/convert""" );
        Environment.Exit( 1 );
      }

      var command = args[0];

      Global.Filename = args[1];

      if( "/analyze".Equals( command ) )
        analyze();
      if( "/convert".Equals( command ) )
        parse();
    }

    private static void parse() {
      makeImagesDirectory();
      var parser = new DocXParser();
      var text = parser.Parse();

      var file = Path.GetFileNameWithoutExtension( Global.Filename );
      File.WriteAllText( file + ".md", text );
    }

    private static void makeImagesDirectory() {
      var path = Path.GetFileNameWithoutExtension( Global.Filename ) + "_images";
      if( !Directory.Exists( path ) ) Directory.CreateDirectory( path );
    }

    private static void analyze() {
      var doc = DocX.Load( Global.Filename );
      var analyzer = new DocumentAnalyzer( doc );

      analyzer.Analyze();

      var json = JsonConvert.SerializeObject( analyzer.Result, new JsonSerializerSettings { Formatting = Newtonsoft.Json.Formatting.Indented } );
      Console.Write(json);
      var file = Path.GetFileNameWithoutExtension( Global.Filename );
      File.WriteAllText( file + ".json", json );
    }

  }

}
