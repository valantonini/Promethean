# Promethean

[![Build Status](https://travis-ci.org/valantonini/Promethean.svg?branch=master)](https://travis-ci.org/valantonini/Promethean)

<a href="https://prometheanapp.azurewebsites.net/" target="_blank" title="Try it here">Try it here. Refresh to generate a dungeon</a>

A procedural dungeon generator library compatible with Unity3d built on .Net Standard 2.0. Aiming to render in under 30 seconds on an iPhone 8.

![Current Progress](https://raw.githubusercontent.com/valantonini/Promethean/master/Examples/Example.png "Current Progress")

## 1st Stage Goal
- [x] No walls, render as 2 only floor or empty tiles

## 2nd Stage Goals

- [x] Convert the byte array to a tileset that indicates:
- Inside Corner x 4
- Outside Corner x 4
- Wall x 4 (Top, Right, Bottom, Left)
- Floor

## 3rd Stage Goals
- [x] Support a variety of room shapes
- [x] Prevent overlapping of rooms

## 4th Stage Goals
- More intelligent room overlap failover
- Defined entries and exits of tooms

## 5th Stage Goals
- Doors

## Far future
- doodads

## Limitations
- Square tiles
- No diagonals 
- ~~Only square rooms~~

