/*
 * ----------------------------------------------------------------------------
 * "THE BEER-WARE LICENSE" (Revision 42):
 * <christopher.g.steel@gmail.com> wrote this file.  As long as you retain this notice you
 * can do whatever you want with this stuff. If we meet some day, and you think
 * this stuff is worth it, you can buy me a beer in return. Christopher George Steel
 * ----------------------------------------------------------------------------
 */

using System.Collections.Generic;

public interface ILineProvider {
  IEnumerable<string> getLine();
}