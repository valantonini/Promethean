# Promethean

[![Build Status](https://travis-ci.org/valantonini/Promethean.svg?branch=master)](https://travis-ci.org/valantonini/Promethean)

A procedural dungeon generator library compatible with Unity3d built on .Net Standard 2.0. Aiming to render in under 30 seconds on an iPhone 8 

## 1st Stage Goal
- No walls, render as 2 only floor or empty tiles

## 2nd Stage Goals

Convert the byte array to a tileset that indicates:
- horizontal wall
- vertical wall
- L shaped wall corners x 4 (1 for each orientation)
- floor
- horizontal corridor
- vertical corridor
- L shaped corridor x 4 (1 for each orientation)
- T shaped corridor x 4 (1 for each orientation)

## Limitations
- Square tiles
- No diagonals 
- Only square rooms 
- Fixed size rooms (temporary)

