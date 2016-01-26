// Author: Christopher G Steel

using System.IO;
using System.Collections.Generic;

public class BeatmapParser {
	public delegate void LineHandler(string line);

	string _path;
	string _buffer;

	public BeatmapParser(string path) {
		_path = path;
	}

	public void Load() {
		var sr = new StringReader(_path);

		_buffer = sr.ReadToEnd();
	}

	public void Parse() {
		if (_buffer == null) {
			Load();
		}
		var sections = new Dictionary<string, LineHandler> {
			{"[General]", _ParseGeneral},
			{"[Difficulty]", _ParseDifficulty},
			{"[HitObjects]", _ParseHitObjects}
		}
		LineHandler currentSectionHandler;

		foreach (string line in _SplitBufferIntoLines()) {
			if (_IsSectionTitle(line)) {
				currentSectionHandler = sections[line];
			} else {
				currentSectionHandler(line);
			}
		}
	}

	private IEnumerable<string> _SplitBufferIntoLines() {
		if (_buffer == null) {
			yield break;
		}
		using (var reader = new System.IO.StringReader(_buffer)) {
			string line;

			while ((line = reader.ReadLine()) != null) {
				yield return line;
			}
		}
	}

	private bool _IsSectionTitle(string line) {
		return (line[0] == '[' && line[line.Length - 1] == ']');
	}

	private void _ParseGeneral(string line) {

	}

	private void _ParseDifficulty(string line) {

	}

	private void _ParseHitObjects(string line) {

	}
}

// These comments will be removed once I've figured out this
// whole parser business
//
// full lines
// ----------
// section title: \[word\]
// named value: keyval
// anonymous value: val
// comment: //.*
//
// components
// ----------
// keyval: label\:\s*
// val: (types|array)
// types: (int|float|label)
// int: -?\d+
// float: int?.\d+
// label: .+
// string: ".+"
// word: [a-zA-Z\d]+
// array: types(,\s*types)*
