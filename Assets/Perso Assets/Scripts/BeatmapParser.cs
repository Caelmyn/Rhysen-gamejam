using System.IO;


public class BeatmapParser {
  string _path;

  public BeatmapParser(string path) {
    _path = path;
  }

  public Load() {
    StringReader sr = new StringReader(_path);

    _buffer = sr.ReadToEnd();
  }

  public Parse() {
    full lines
    ----------
    section title: \[word\]
    named value: keyval
    anonymous value: val
    comment: //.*

    components
    ----------
    keyval: label\:\s*
    val: (types|array)
    types: (int|float|label)
    int: -?\d+
    float: int?.\d+
    label: .+
    string: ".+"
    word: [a-zA-Z\d]+
    array: types(,\s*types)*
  }
}
