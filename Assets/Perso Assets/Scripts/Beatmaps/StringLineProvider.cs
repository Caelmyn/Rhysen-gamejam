/*
 * ----------------------------------------------------------------------------
 * "THE BEER-WARE LICENSE" (Revision 42):
 * <christopher.g.steel@gmail.com> wrote this file.  As long as you retain this notice you
 * can do whatever you want with this stuff. If we meet some day, and you think
 * this stuff is worth it, you can buy me a beer in return. Christopher George Steel
 * ----------------------------------------------------------------------------
 */

using System.IO;
using System.Collections.Generic;

public class StringLineProvider : ILineProvider {
  string _buffer;

  public StringLineProvider(string buffer) {
    _buffer = buffer;
  }

  public IEnumerable<string> getLine() {
    if (_buffer == null) {
			yield break;
		}
		using (var reader = new StringReader(_buffer)) {
			string line;

			while ((line = reader.ReadLine()) != null) {
				yield return line;
			}
		}
  }
}
