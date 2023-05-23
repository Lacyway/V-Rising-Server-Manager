using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace VRisingServerManager
{
    public partial class GameSettingsEditor : Window
    {
        public GameSettings gameSettings;
        public List<FakeAchievement> fakeAchievements = new List<FakeAchievement>();
        public List<FakeVBloodUnitSetting> fakeVBloodUnits = new List<FakeVBloodUnitSetting>();
        public List<FakeResearch> fakeResearch = new List<FakeResearch>();
        public JsonSerializerOptions serializerOptions = new JsonSerializerOptions { WriteIndented = true };

        public GameSettingsEditor()
        {
            gameSettings = new GameSettings();
            DataContext = gameSettings;
            InitializeComponent();
            SetupDefaultSettings();
            if (Properties.Settings.Default.AutoLoadGameSettings == true && File.Exists(Properties.Settings.Default.GameSettingsFile))
                AutoLoad();
        }

        private void SetupDefaultSettings()
        {
            fakeVBloodUnits.Clear();
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Alpha Wolf", UnitId = -1905691330, UnitLevel = 16, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Keely the Frost Archer", UnitId = 1124739990, UnitLevel = 20, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Rufus the Foreman", UnitId = 2122229952, UnitLevel = 20, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Errol the Stonebreaker", UnitId = -2025101517, UnitLevel = 20, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Lidia the Chaos Archer", UnitId = 763273073, UnitLevel = 26, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Grayson the Armourer", UnitId = 1106149033, UnitLevel = 27, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Goreswine the Ravager", UnitId = 577478542, UnitLevel = 27, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Putrid Rat", UnitId = -2039908510, UnitLevel = 30, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Clive the Firestarter", UnitId = 1896428751, UnitLevel = 30, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Polora the Feywalker", UnitId = -484556888, UnitLevel = 34, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Ferocious Bear", UnitId = -1391546313, UnitLevel = 36, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Nicholaus the Fallen", UnitId = 153390636, UnitLevel = 37, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Quincey the Bandit King", UnitId = -1659822956, UnitLevel = 37, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Beatrice the Tailor", UnitId = -1942352521, UnitLevel = 38, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Vincent the Frostbringer", UnitId = -29797003, UnitLevel = 40, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Christina the Sun Priestess", UnitId = -99012450, UnitLevel = 44, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Kriig the Undead General", UnitId = -1365931036, UnitLevel = 44, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Leandra the Shadow Priestess", UnitId = 939467639, UnitLevel = 46, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Tristan the Vampire Hunter", UnitId = -1449631170, UnitLevel = 46, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Bane the Shadowblade", UnitId = 613251918, UnitLevel = 47, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Grethel the Glassblower", UnitId = 910988233, UnitLevel = 47, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Maja the Dark Savant", UnitId = 1945956671, UnitLevel = 47, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Terah the Geomancer", UnitId = -1065970933, UnitLevel = 48, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Meredith the Bright Archer", UnitId = 850622034, UnitLevel = 52, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Frostmaw the Mountain Terror", UnitId = 24378719, UnitLevel = 56, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Octavian the Militia Captain", UnitId = 1688478381, UnitLevel = 58, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Raziel the Shepherd", UnitId = -680831417, UnitLevel = 60, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Ungora the Spider Queen", UnitId = -548489519, UnitLevel = 60, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Domina the Blade Dancer", UnitId = -1101874342, UnitLevel = 60, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Angram the Purifier", UnitId = 106480588, UnitLevel = 60, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Ziva the Engineer", UnitId = 172235178, UnitLevel = 60, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "The Duke of Balaton", UnitId = -203043163, UnitLevel = 62, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Foulrot the Soultaker", UnitId = -1208888966, UnitLevel = 62, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Jade the Vampire Hunter", UnitId = -1968372384, UnitLevel = 62, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "The Old Wanderer", UnitId = 109969450, UnitLevel = 62, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Willfred Werewolf Chieftain", UnitId = -1007062401, UnitLevel = 64, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Mairwyn the Elementalist", UnitId = -2013903325, UnitLevel = 64, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Cyril the Cursed Smith", UnitId = 326378955, UnitLevel = 65, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Sir Magnus the Overseer", UnitId = -26105228, UnitLevel = 66, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Morian the Stormwing Matriach", UnitId = 685266977, UnitLevel = 68, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Azariel the Sunbringer", UnitId = 114912615, UnitLevel = 68, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Terrorclaw the Ogre", UnitId = -1347412392, UnitLevel = 68, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Baron du Bouchon the Sommelier", UnitId = 192051202, UnitLevel = 70, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Matka the Curse Weaver", UnitId = -910296704, UnitLevel = 72, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Henry Blackbrew the Doctor", UnitId = 814083983, UnitLevel = 74, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Nightmarshal Styx the Sunderer", UnitId = 1112948824, UnitLevel = 76, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Voltatia the Power Master", UnitId = 2054432370, UnitLevel = 77, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Gorecrusher the Behemoth", UnitId = -1936575244, UnitLevel = 78, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "The Winged Horror", UnitId = -393555055, UnitLevel = 78, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Solarus the Immaculate", UnitId = -740796338, UnitLevel = 80, DefaultUnlocked = false });
            fakeVBloodUnits.Add(new FakeVBloodUnitSetting() { Name = "Adam the Firstborn", UnitId = 1233988687, UnitLevel = 83, DefaultUnlocked = false });
            VBloodData.ItemsSource = fakeVBloodUnits;
            fakeAchievements.Clear();
            fakeAchievements.Add(new FakeAchievement() { ID = -1770927128, Name = "1. Collecting the Remains", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = 436375429, Name = "2. Wielding the Sword", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = -1400391027, Name = "3. Mastering Magic", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = -2071097880, Name = "4. Armour of Bones", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = 1695239324, Name = "5. Into the Woods", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = 1502386974, Name = "6. Stone Breaker", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = 1694767961, Name = "7. Lord of Shadows", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = -1899098914, Name = "8. Fortify", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = 560247139, Name = "9. Getting Ready for the Hunt", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = -1995132640, Name = "10. Blood Hunt", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = -1434604634, Name = "11. The first book in the Library", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = 1668809517, Name = "12. Expanding my Domain", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = 134993992, Name = "13. Waygate", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = 334973636, Name = "14. Building a Castle", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = 606418711, Name = "15. Lord of the Manor", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = -892747762, Name = "16. Servants", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = -437605270, Name = "17. Army of Darkness", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = -2104585843, Name = "18. Throne of Command", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = 1805684941, Name = "19. A Castle reaching the Sky", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = -699165894, Name = "20. Nightfall Steed", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = 1861267375, Name = "21. Vampire Empire", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = -327597689, Name = "22. Soul Stones", Unlocked = false });
            fakeAchievements.Add(new FakeAchievement() { ID = 1762480233, Name = "23. Blood of Liminance", Unlocked = false });
            AchievementsData.ItemsSource = fakeAchievements;
            fakeResearch.Clear();
            fakeResearch.Add(new FakeResearch() { Name = "Tier 1", ID = -495424062, Unlocked = false });
            fakeResearch.Add(new FakeResearch() { Name = "Tier 2", ID = -1292809886, Unlocked = false });
            fakeResearch.Add(new FakeResearch() { Name = "Tier 3", ID = -1262194203, Unlocked = false });
            ResearchData.ItemsSource = fakeResearch;
        }

        private void FileMenuSave_Click(object sender, RoutedEventArgs e)
        {
            gameSettings.UnlockedAchievements.Clear();
            foreach (var item in fakeAchievements)
            {
                if (item.Unlocked == true)
                {
                    gameSettings.UnlockedAchievements.Add(item.ID);
                }
            }
            gameSettings.VBloodUnitSettings.Clear();
            foreach (var vblood in fakeVBloodUnits)
            {
                gameSettings.VBloodUnitSettings.Add(new VBloodUnitSetting() { UnitId = vblood.UnitId, UnitLevel = vblood.UnitLevel, DefaultUnlocked = vblood.DefaultUnlocked });
            }
            gameSettings.UnlockedResearchs.Clear();
            foreach (var research in fakeResearch)
            {
                if (research.Unlocked == true)
                    gameSettings.UnlockedResearchs.Add(research.ID);
            }
            switch (StarterEquipmentCombo.SelectedIndex)
            {
                case 0: 
                    gameSettings.StarterEquipmentId = 0;
                    break;
                case 1:
                    gameSettings.StarterEquipmentId = -387090868;
                    break;
                case 2:
                    gameSettings.StarterEquipmentId = -376135143;
                    break;
                case 3:
                    gameSettings.StarterEquipmentId = -1613823352;
                    break;
                case 4:
                    gameSettings.StarterEquipmentId = -1714743400;
                    break;
                case 5:
                    gameSettings.StarterEquipmentId = -258598606;
                    break;
                case 6:
                    gameSettings.StarterEquipmentId = 1177675846;
                    break;
            }
            switch (StarterResourcesCombo.SelectedIndex)
            {
                case 0:
                    gameSettings.StarterResourcesId = 0;
                    break;
                case 1:
                    gameSettings.StarterResourcesId = -696202180;
                    break;
                case 2:
                    gameSettings.StarterResourcesId = 329280709;
                    break;
                case 3:
                    gameSettings.StarterResourcesId = 481718792;
                    break;
                case 4:
                    gameSettings.StarterResourcesId = 470364250;
                    break;
                case 5:
                    gameSettings.StarterResourcesId = -766909665;
                    break;
                case 6:
                    gameSettings.StarterResourcesId = -2131982548;
                    break;
            }            
            try
            {
                string SettingsJSON = JsonSerializer.Serialize(gameSettings, serializerOptions);
                if (Properties.Settings.Default.AutoLoadGameSettings == true)
                {
                    if (MessageBox.Show("Save to auto-loaded file?", "Save", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (File.Exists(Properties.Settings.Default.GameSettingsFile))
                        {
                            File.Copy(Properties.Settings.Default.GameSettingsFile, Properties.Settings.Default.GameSettingsFile + ".bak", true);
                        }
                        File.WriteAllText(Properties.Settings.Default.GameSettingsFile, SettingsJSON);
                        MessageBox.Show("File successfully saved to: \n" + Properties.Settings.Default.GameSettingsFile);
                        return;
                    }
                }
                SaveFileDialog SaveSettingsDialog = new SaveFileDialog
                {
                    Filter = "\"JSON files\"|*.json",
                    DefaultExt = "json",
                    FileName = "ServerGameSettings.json"
                };
                if (Directory.Exists(Properties.Settings.Default.Save_Path + @"\Saves\v1\" + Properties.Settings.Default.Save_Name))
                {
                    SaveSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path + @"\Saves\v1\" + Properties.Settings.Default.Save_Name;
                }
                else
                {
                    SaveSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path;
                }
                if (SaveSettingsDialog.ShowDialog() == true)
                {
                    if (File.Exists(SaveSettingsDialog.FileName))
                    {
                        File.Copy(SaveSettingsDialog.FileName, SaveSettingsDialog.FileName + ".bak", true);
                    }
                    File.WriteAllText(SaveSettingsDialog.FileName, SettingsJSON);
                    MessageBox.Show("File successfully saved to: \n" + SaveSettingsDialog.FileName);
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }

        private void FileMenuLoad_Click(object sender, RoutedEventArgs e)
        {
            string? FileToLoad = "temp";
            OpenFileDialog OpenSettingsDialog = new OpenFileDialog
            {
                Filter = "\"JSON files\"|*.json",
                DefaultExt = "json",
                FileName = "ServerGameSettings.json"
            };
            if (Directory.Exists(Properties.Settings.Default.Save_Path + @"\Saves\v1\" + Properties.Settings.Default.Save_Name))
            {
                OpenSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path + @"\Saves\v1\" + Properties.Settings.Default.Save_Name;
            }
            else
            {
                OpenSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path;
            }
            if (OpenSettingsDialog.ShowDialog() == true && FileToLoad != null)
            {
                FileToLoad = OpenSettingsDialog.FileName;
            }
            else
            {
                return;
            }
            using (StreamReader reader = new StreamReader(FileToLoad))
            {
                string LoadedJSON = reader.ReadToEnd();
                LoadHandler(LoadedJSON);
            }
        }

        private void AutoLoad()
        {
            using (StreamReader reader = new StreamReader(Properties.Settings.Default.GameSettingsFile))
            {
                string LoadedJSON = reader.ReadToEnd();
                LoadHandler(LoadedJSON);
            }
        }

        private void LoadPreset(string Preset)
        {
            //var assembly = Assembly.GetExecutingAssembly();
            //Stream stream = assembly.GetManifestResourceStream("VRisingServerManager.Resources." + Preset);
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("VRisingServerManager.Resources." + Preset);
            using (StreamReader reader = new StreamReader(stream))
            {
                string LoadedJSON = reader.ReadToEnd();
                LoadHandler(LoadedJSON);
            }
        }

        private void LoadHandler(string JSON)
        {
            try
            {
                SetupDefaultSettings();
                GameSettings LoadedSettings = JsonSerializer.Deserialize<GameSettings>(JSON);
                if (!int.TryParse(LoadedSettings.GameModeType.ToString(), out int GameModeTypeValue))
                {
                    switch (LoadedSettings.GameModeType.ToString())
                    {
                        case "PvE":
                            LoadedSettings.GameModeType = 0;
                            break;
                        case "PvP":
                            LoadedSettings.GameModeType = 1;
                            break;
                    }
                }
                else
                {
                    LoadedSettings.GameModeType = GameModeTypeValue;
                }
                if (!int.TryParse(LoadedSettings.CastleDamageMode.ToString(), out int CastleDamageModeValue))
                {
                    switch (LoadedSettings.CastleDamageMode.ToString())
                    {
                        case "Never":
                            LoadedSettings.CastleDamageMode = 0;
                            break;
                        case "Always":
                            LoadedSettings.CastleDamageMode = 1;
                            break;
                        case "TimeRestricted":
                            LoadedSettings.CastleDamageMode = 2;
                            break;
                    }
                }
                else
                {
                    LoadedSettings.CastleDamageMode = CastleDamageModeValue;
                }
                if (!int.TryParse(LoadedSettings.SiegeWeaponHealth.ToString(), out int SiegeWeaponHealthValue))
                {
                    switch (LoadedSettings.SiegeWeaponHealth.ToString())
                    {
                        case "VeryLow":
                            LoadedSettings.SiegeWeaponHealth = 0;
                            break;
                        case "Low":
                            LoadedSettings.SiegeWeaponHealth = 1;
                            break;
                        case "Normal":
                            LoadedSettings.SiegeWeaponHealth = 2;
                            break;
                        case "High":
                            LoadedSettings.SiegeWeaponHealth = 3;
                            break;
                        case "VeryHigh":
                            LoadedSettings.SiegeWeaponHealth = 4;
                            break;
                    }
                }
                else
                {
                    LoadedSettings.SiegeWeaponHealth = SiegeWeaponHealthValue;
                }
                if (!int.TryParse(LoadedSettings.PlayerDamageMode.ToString(), out int PlayerDamageModeValue))
                {
                    switch (LoadedSettings.PlayerDamageMode.ToString())
                    {
                        case "Always":
                            LoadedSettings.PlayerDamageMode = 0;
                            break;
                        case "Restricted":
                            LoadedSettings.PlayerDamageMode = 1;
                            break;
                    }
                }
                else
                {
                    LoadedSettings.PlayerDamageMode = PlayerDamageModeValue;
                }
                if (!int.TryParse(LoadedSettings.CastleHeartDamageMode.ToString(), out int CastleHeartDamageModeValue))
                {
                    switch (LoadedSettings.CastleHeartDamageMode.ToString())
                    {
                        case "CanBeDestroyedOnlyWhenDecaying":
                            LoadedSettings.CastleHeartDamageMode = 0;
                            break;
                        case "CanBeDestroyedByPlayers":
                            LoadedSettings.CastleHeartDamageMode = 1;
                            break;
                        case "CanBeSeizedOrDestroyedByPlayers":
                            LoadedSettings.CastleHeartDamageMode = 2;
                            break;
                    };
                }
                else
                {
                    LoadedSettings.CastleHeartDamageMode = CastleHeartDamageModeValue;
                }
                if (!int.TryParse(LoadedSettings.PvPProtectionMode.ToString(), out int PvPProtectionModeValue))
                {
                    switch (LoadedSettings.PvPProtectionMode.ToString())
                    {
                        case "Disabled":
                            LoadedSettings.PvPProtectionMode = 0;
                            break;
                        case "VeryShort":
                            LoadedSettings.PvPProtectionMode = 1;
                            break;
                        case "Short":
                            LoadedSettings.PvPProtectionMode = 2;
                            break;
                        case "Medium":
                            LoadedSettings.PvPProtectionMode = 3;
                            break;
                        case "Long":
                            LoadedSettings.PvPProtectionMode = 4;
                            break;
                    }
                }
                else
                {
                    LoadedSettings.PvPProtectionMode = PvPProtectionModeValue;
                }
                if (!int.TryParse(LoadedSettings.DeathContainerPermission.ToString(), out int DeathContainerPermissionValue))
                {
                    switch (LoadedSettings.DeathContainerPermission.ToString())
                    {
                        case "Anyone":
                            LoadedSettings.DeathContainerPermission = 0;
                            break;
                        case "ClanMembers":
                            LoadedSettings.DeathContainerPermission = 1;
                            break;
                        case "OnlySelf":
                            LoadedSettings.DeathContainerPermission = 2;
                            break;
                    }
                }
                else
                {
                    LoadedSettings.DeathContainerPermission = DeathContainerPermissionValue;
                }
                if (!int.TryParse(LoadedSettings.RelicSpawnType.ToString(), out int RelicSpawnTypeValue))
                {
                    switch (LoadedSettings.RelicSpawnType.ToString())
                    {
                        case "Unique":
                            LoadedSettings.RelicSpawnType = 0;
                            break;
                        case "Plentiful":
                            LoadedSettings.RelicSpawnType = 1;
                            break;
                    }
                }
                else
                {
                    LoadedSettings.RelicSpawnType = RelicSpawnTypeValue;
                }
                switch (LoadedSettings.StarterEquipmentId)
                {
                    case -387090868:
                        StarterEquipmentCombo.SelectedIndex = 1;
                        break;
                    case -376135143:
                        StarterEquipmentCombo.SelectedIndex = 2;
                        break;
                    case -1613823352:
                        StarterEquipmentCombo.SelectedIndex = 3;
                        break;
                    case -1714743400:
                        StarterEquipmentCombo.SelectedIndex = 4;
                        break;
                    case -258598606:
                        StarterEquipmentCombo.SelectedIndex = 5;
                        break;
                    case 1177675846:
                        StarterEquipmentCombo.SelectedIndex = 6;
                        break;
                    default:
                        StarterEquipmentCombo.SelectedIndex = 0;
                        break;
                }
                switch (LoadedSettings.StarterResourcesId)
                {
                    case -696202180:
                        StarterResourcesCombo.SelectedIndex = 1;
                        break;
                    case 329280709:
                        StarterResourcesCombo.SelectedIndex = 2;
                        break;
                    case 481718792:
                        StarterResourcesCombo.SelectedIndex = 3;
                        break;
                    case 470364250:
                        StarterResourcesCombo.SelectedIndex = 4;
                        break;
                    case -766909665:
                        StarterResourcesCombo.SelectedIndex = 5;
                        break;
                    case -2131982548:
                        StarterResourcesCombo.SelectedIndex = 6;
                        break;
                    default:
                        StarterResourcesCombo.SelectedIndex = 0;
                        break;
                }
                if (!int.TryParse(LoadedSettings.PlayerInteractionSettings.TimeZone.ToString(), out int TimeZoneValue))
                {
                    switch (LoadedSettings.PlayerInteractionSettings.TimeZone.ToString())
                    {
                        case "Local":
                            TimeZoneCombo.SelectedIndex = 0;
                            break;
                        case "UTC":
                            TimeZoneCombo.SelectedIndex = 1;
                            break;
                        case "PST":
                            TimeZoneCombo.SelectedIndex = 2;
                            break;
                        case "EST":
                            TimeZoneCombo.SelectedIndex = 3;
                            break;
                        case "CET":
                            TimeZoneCombo.SelectedIndex = 4;
                            break;
                        case "CST":
                            TimeZoneCombo.SelectedIndex = 5;
                            break;
                    }
                }
                else
                {
                    LoadedSettings.PlayerInteractionSettings.TimeZone = TimeZoneValue;
                }
                foreach (VBloodUnitSetting unit in LoadedSettings.VBloodUnitSettings)
                {
                    foreach (FakeVBloodUnitSetting fakeUnit in fakeVBloodUnits)
                    {
                        if (unit.UnitId == fakeUnit.UnitId)
                        {
                            fakeUnit.UnitLevel = unit.UnitLevel;
                            fakeUnit.DefaultUnlocked = unit.DefaultUnlocked;
                        }
                    }
                }
                foreach (int achievement in LoadedSettings.UnlockedAchievements)
                {
                    foreach (FakeAchievement fakeAchievement in fakeAchievements)
                    {
                        if (achievement == fakeAchievement.ID)
                            fakeAchievement.Unlocked = true;
                    }
                }
                foreach (int research in LoadedSettings.UnlockedResearchs)
                {
                    foreach (FakeResearch fakeResearch in fakeResearch)
                    {
                        if (research == fakeResearch.ID)
                            fakeResearch.Unlocked = true;
                    }
                }
                gameSettings = LoadedSettings;
                DataContext = gameSettings;
                VBloodData.Items.Refresh();
                AchievementsData.Items.Refresh();
                ResearchData.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void FileMenuExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoadPresetButton(object parameter, RoutedEventArgs e)
        {
            string toSend = ((MenuItem)parameter).Tag.ToString();
            LoadPreset(toSend);
        }
    }
}
