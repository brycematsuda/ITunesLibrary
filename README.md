ITunesLibrary
===================
A fork of the [iTunesLibraryParser](https://github.com/asciamanna/iTunesLibraryParser) library.

ITunesLibrary is implemented in C# utilizing LINQ-To-XML. Given the location of a iTunes Music Library XML file it parses the PropertyList format, which is defined by the Document Type Declaration (DTD) defined here [http://www.apple.com/DTDs/PropertyList-1.0.dtd](http://www.apple.com/DTDs/PropertyList-1.0.dtd). It supports parsing tracks, albums, playlists, and podcasts.

## Changes from original
- Updated target framework to the latest .NET version.
- Renamed to "ITunesLibrary" to distinguish it from other library, and to leave open possible expansion to other media formats
- Renamed "ITunesLibrary" to "ITunesMusicLibrary" to prevent namespace collisions (also the default XML library file name is "iTunes Music Library.xml")
- Parser and utility classes moved to separate folders and namespaces for organizational purposes
- Added unused PR changes from old repo
- Changing coding style to follow standard C# styling and most Roslyn analyzer suggestions where applicable
- Using Coverlet library for code coverage

## Usage
```csharp
var library = new ITunesMusicLibrary("iTunesLibrary.xml");

var tracks = library.Tracks 
// returns all tracks in the iTunes Library

var albums = library.Albums
// returns all albums in the iTunes Library

var playlists = library.Playlists
// returns all playlists in the iTunes Library
```

## Versioning
ITunesLibary will be maintained under the [Semantic Versioning guidelines](http://semver.org). Releases will follow this format:

```
<major>.<minor>.<build>
```

 * If a release breaks backward compatibility the major version will be bumped (resetting minor and build back to zero). 
 * New features and updates without breaking backward compatibility will bump the minor version (resetting the build to zero)
 * Bug fixes and small miscellaneous changes increase the build number

## To do
- Upload package to Nuget.org
- Add CI