using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VRisingServerManager
{
    class ModsList
    {
        public ObservableCollection<ModInfo> ModList { get; set; } = new();
    }

    public class ModInfo : PropertyChangedBase
    {
        private bool _installed = false;
        public bool Installed
        {
            get => _installed;
            set => SetField(ref _installed, value);
        }
        private bool _downloaded = false;
        public bool Downloaded
        {
            get => _downloaded;
            set => SetField(ref _downloaded, value);
        }
        public string Name { get; set; }
        public string Full_Name { get; set; }
        public string Owner { get; set; }
        public string Package_Url { get; set; }
        public DateTime Date_Created { get; set; }
        public DateTime Date_Updated { get; set; }
        public string Uuid4 { get; set; }
        public int RatingScore { get; set; }
        public bool IsPinned { get; set; }
        public bool IsDeprecated { get; set; }
        public bool HasNsfwContent { get; set; }
        public List<string> Categories { get; set; }
        public List<Version> Versions { get; set; }
    }

    public class Version
    {
        public string Name { get; set; }
        public string Full_Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Version_Number { get; set; }
        public List<string> Dependencies { get; set; }
        public string Download_Url { get; set; }
        public int Downloads { get; set; }
        public DateTime DateCreated { get; set; }
        public string Website_Url { get; set; }
        public bool IsActive { get; set; }
        public string Uuid4 { get; set; }
        public int File_Size { get; set; }
    }
}
