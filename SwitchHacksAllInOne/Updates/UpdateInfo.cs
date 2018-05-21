using System;
using System.Collections;
using System.Collections.Generic;

namespace SwitchHacksAllInOne.Updates
{
    /// <summary>
    /// File which contains Name, Folderpath, Link to repo, version and Filetype.
    /// Because I honestly don't have the nerve to implement an autoupdater at this point,
    /// I will provide the packages within this program directly. Later on, I'll add an update feature, maybe you can help aswell.
    /// </summary>
    [Serializable, WillImplementLater]
    public class UpdateInfo
    {
        public string Name { get; set; }
        public string FolderPath { get; set; }
        public string UpdatePath { get; set; }
        public string TagName { get; set; }
        public TypeOfFile TypeOfFile { get; set; }

        public UpdateInfo(string pName, string pFolderPath, string pUpdatePath, string pTagName, TypeOfFile pTypeOfFile)
        {
            Name = pName;
            FolderPath = pFolderPath;
            UpdatePath = pUpdatePath;
            TagName = pTagName;
            TypeOfFile = pTypeOfFile;
        }

    }

    public enum TypeOfFile
    {
        Homebrew,
        Payload,
        Launcher,
        Linux,
    }

    /// <summary>
    /// This class generates a list of the included/recommended tools
    /// </summary>
    [WillImplementLater]
    public class StandardUpdateInfo
    {
        public List<UpdateInfo> UpdateInfos { get; set; }

        public StandardUpdateInfo()
        {
            UpdateInfos = new List<UpdateInfo>
            {
                new UpdateInfo("HomebrewLauncher", "SDCard\\Homebrew\\", @"switchbrew/nx-hbmenu", "v2.0.0", TypeOfFile.Homebrew),
                new UpdateInfo("Hekate-ipl-4x", "SDCard\\Payload\\", @"nx-python/hekate-ipl-4x", "v1.0.0", TypeOfFile.Payload)
            };
        }

    }

    /// <summary>
    /// Indicates that I'm a lazy dork.
    /// </summary>
    public class WillImplementLaterAttribute : Attribute { }

}