﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ITunesLibrary.Parsers
{
    internal abstract class LibraryItemParserBase
    {
        protected abstract string GetCollectionNodeName();

        protected IEnumerable<XElement> ParseElements(string libraryContents)
        {
            return from x in XDocument.Parse(libraryContents).Descendants("dict").Descendants(GetCollectionNodeName()).Descendants("dict")
                   where x.Descendants("key").Count() > 1
                   select x;
        }
    }
}