/*
 * ----------------------------------------------------------------------------
 * "THE BEER-WARE LICENSE" (Revision 42):
 * <christopher.g.steel@gmail.com> wrote this file.  As long as you retain this notice you
 * can do whatever you want with this stuff. If we meet some day, and you think
 * this stuff is worth it, you can buy me a beer in return. Christopher George Steel
 * ----------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;

public class BeatmapParser {
	public delegate void LineHandler(string line);

	ILineProvider _lp;

	public BeatmapParser(ILineProvider lp) {
		_lp = lp;
	}

	public void Parse() {
		var sections = new Dictionary<string, LineHandler> {
			{"[General]", _ParseGeneral},
			{"[Difficulty]", _ParseDifficulty},
			{"[HitObjects]", _ParseHitObjects}
		};
		LineHandler currentSectionHandler = null;

		foreach (string line in _lp.getLine()) {
			if (_IsSectionTitle(line)) {
				Console.WriteLine("changing section title");
				currentSectionHandler = sections[line];
			} else {
				currentSectionHandler(line);
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
