using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Novacode;

namespace DocXToMarkdown.Converter {

  public abstract class BaseConverter {

    public BaseConverter( DocX d, Paragraph p ) {
      _paragraph = p;
      _document = d;
      _text = Sanitize( _paragraph.Text );
      CheckHiperlinks();
      CheckPictures();
    }

    private void CheckPictures() {
      foreach( var picture in _paragraph.Pictures ) {
        var imageSource = _document.Images.Find( i => i.FileName.Equals( picture.FileName ) );
        var stream = imageSource.GetStream( System.IO.FileMode.Open, System.IO.FileAccess.Read );
        var filename = Path.GetFileNameWithoutExtension( Global.Filename );
        using( var fs = new FileStream(  filename + "_images/" + imageSource.FileName, FileMode.Create ) ) 
          stream.CopyTo( fs );

        _text += "![" + picture.Name + "](./" + filename + "_images/" + imageSource.FileName + ")";
      }
    }

    private void CheckHiperlinks() {
      if( _paragraph.Hyperlinks.Count > 0 ) {
        var link = _paragraph.Hyperlinks.First();
        if( link.Uri != null ) _text = "[" + _text  + "](" + link.Uri.AbsoluteUri + ")";
      }
    }

    public abstract string Convert();

    protected virtual string Sanitize( string text ) {
      return text.TrimStart( '\t' );
    }

    protected readonly Paragraph _paragraph;
    protected readonly DocX _document;
    protected string _text;
  }

}
