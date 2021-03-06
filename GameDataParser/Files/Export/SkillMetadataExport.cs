﻿using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using GameDataParser.Crypto.Common;
using GameDataParser.Parsers;
using Maple2Storage.Types.Metadata;

namespace GameDataParser.Files.Export
{
    public class SkillMetadataExport
    {

        public void Export()
        {
            string headerFile = VariableDefines.XML_PATH.Replace(".m2d", ".m2h");
            List<PackFileEntry> files = FileList.ReadFile(File.OpenRead(headerFile));
            MemoryMappedFile memFile = MemoryMappedFile.CreateFromFile(VariableDefines.XML_PATH);

            // Parse and save some item data from xml file
            List<SkillMetadata> skills = SkillParser.Parse(memFile, files);
            SkillParser.Write(skills);
        }
    }
}
