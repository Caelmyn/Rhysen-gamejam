/*
 * ----------------------------------------------------------------------------
 * "THE BEER-WARE LICENSE" (Revision 42):
 * <christopher.g.steel@gmail.com> wrote this file.  As long as you retain this notice you
 * can do whatever you want with this stuff. If we meet some day, and you think
 * this stuff is worth it, you can buy me a beer in return. Christopher George Steel
 * ----------------------------------------------------------------------------
 */

﻿using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class TBeatmapParser {

    [Test]
    public void Flow()
    {
        //Arrange
        var buffer = @"
          [General]
          AudioFilename: Testing_time_mate.mp3
          Mode: 0
          [HitObjects]
          424,116,11550,1,8,0:0:0:0:
          388,84,11790,1,0,0:0:0:0:
          352,56,12030,1,4,0:0:0:0:
          260,96,12510,5,8,0:0:0:0:
          176,48,12990,1,0,0:0:0:0:
          92,96,13470,1,8,0:0:0:0:
          112,140,13710,1,0,0:0:0:0:
          132,184,13950,1,2,0:0:0:0:

          [Difficulty]
          HPDrainRate: 4
          CircleSize: 3
          OverallDifficulty: 4
        ";
        var provider = new StringLineProvider(buffer);
        var parser = new BeatmapParser(provider);

        //Assert.AreEqual(newGameObjectName, gameObject.name);
    }
}
