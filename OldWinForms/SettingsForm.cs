using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using Newtonsoft.Json;

namespace ServerManager
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.logo;            
            SetupDefaults();
            if (Properties.Settings.Default.AutoLoadGameSettings == true && File.Exists(Properties.Settings.Default.GameSettingsFile))
                LoadSettings(true, false, 0);
        }

        public class ListBoxItem
        {
            public string? Text { get; set; }
            public int Value { get; set; }
        }

        public void SetupDefaults()
        {
            GameTypeComboBox.SelectedIndex = 0;
            CastleDamageModeComboBox.SelectedIndex = 0;
            SiegeWeaponHealthComboBox.SelectedIndex = 2;
            PlayerDamageModeComboBox.SelectedIndex = 0;
            CastleHeartDamageModeComboBox.SelectedIndex = 0;
            PvPProtectionModeComboBox.SelectedIndex = 2;
            DeathContainerPermissionComboBox.SelectedIndex = 0;
            RelicSpawnTypeComboBox.SelectedIndex = 0;
            TimeZoneComboBox.SelectedIndex = 0;
            UnlockedResearchCheckedListBox.DisplayMember = "Text";
            UnlockedResearchCheckedListBox.ValueMember = "Value";
            UnlockedResearchCheckedListBox.Items.Insert(0, new ListBoxItem { Text = "Tier 1", Value = -495424062 });
            UnlockedResearchCheckedListBox.Items.Insert(1, new ListBoxItem { Text = "Tier 2", Value = -1292809886 });
            UnlockedResearchCheckedListBox.Items.Insert(2, new ListBoxItem { Text = "Tier 3", Value = -1262194203 });
            UnlockedAchievementsCheckedListBox.DisplayMember = "Text";
            UnlockedAchievementsCheckedListBox.ValueMember = "Value";
            UnlockedAchievementsCheckedListBox.Items.Insert(0, new ListBoxItem { Text = "Collecting the Remains", Value = -1770927128 });
            UnlockedAchievementsCheckedListBox.Items.Insert(1, new ListBoxItem { Text = "Wielding the Sword", Value = 436375429 });
            UnlockedAchievementsCheckedListBox.Items.Insert(2, new ListBoxItem { Text = "Mastering Magic", Value = -1400391027 });
            UnlockedAchievementsCheckedListBox.Items.Insert(3, new ListBoxItem { Text = "Armour of Bones", Value = -2071097880 });
            UnlockedAchievementsCheckedListBox.Items.Insert(4, new ListBoxItem { Text = "Into the Woods", Value = 1695239324 });
            UnlockedAchievementsCheckedListBox.Items.Insert(5, new ListBoxItem { Text = "Stone Breaker", Value = 1502386974 });
            UnlockedAchievementsCheckedListBox.Items.Insert(6, new ListBoxItem { Text = "Lord of Shadows", Value = 1694767961 });
            UnlockedAchievementsCheckedListBox.Items.Insert(7, new ListBoxItem { Text = "Fortify", Value = -1899098914 });
            UnlockedAchievementsCheckedListBox.Items.Insert(8, new ListBoxItem { Text = "Getting Ready for the Hunt", Value = 560247139 });
            UnlockedAchievementsCheckedListBox.Items.Insert(9, new ListBoxItem { Text = "Blood Hunt", Value = -1995132640 });
            UnlockedAchievementsCheckedListBox.Items.Insert(10, new ListBoxItem { Text = "The first book in the Library", Value = -1434604634 });
            UnlockedAchievementsCheckedListBox.Items.Insert(11, new ListBoxItem { Text = "Expanding my Domain", Value = 1668809517 });
            UnlockedAchievementsCheckedListBox.Items.Insert(12, new ListBoxItem { Text = "Building a Castle", Value = 334973636 });
            UnlockedAchievementsCheckedListBox.Items.Insert(13, new ListBoxItem { Text = "Lord of the Manor", Value = 606418711 });
            UnlockedAchievementsCheckedListBox.Items.Insert(14, new ListBoxItem { Text = "Servants", Value = -892747762 });
            UnlockedAchievementsCheckedListBox.Items.Insert(15, new ListBoxItem { Text = "Army of Darkness", Value = -437605270 });
            UnlockedAchievementsCheckedListBox.Items.Insert(16, new ListBoxItem { Text = "Throne of Command", Value = -2104585843 });
            UnlockedAchievementsCheckedListBox.Items.Insert(17, new ListBoxItem { Text = "Soul Stones", Value = -327597689 });
            UnlockedAchievementsCheckedListBox.Items.Insert(17, new ListBoxItem { Text = "Blood of Liminance", Value = 1762480233 });
            VBloodUnitSettingsDataGridView.Rows.Add("Alpha Wolf", -1905691330, 16, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Keely the Frost Archer", 1124739990, 20, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Rufus the Foreman", 2122229952, 20, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Errol the Stonebreaker", -2025101517, 20, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Lidia the Chaos Archer", 763273073, 26, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Grayson the Armourer", 1106149033, 27, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Goreswine the Ravager", 577478542, 27, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Putrid Rat", -2039908510, 30, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Clive the Firestarter", 1896428751, 30, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Polora the Feywalker", -484556888, 34, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Ferocious Bear", -1391546313, 36, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Nicholaus the Fallen", 153390636, 37, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Quincey the Bandit King", -1659822956, 37, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Beatrice the Tailor", -1942352521, 38, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Vincent the Frostbringer", -29797003, 40, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Christina the Sun Priestess", -99012450, 44, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Leandra the Shadow Priestess", 939467639, 46, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Tristan the Vampire Hunter", -1449631170, 46, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Terah the Geomancer", -1065970933, 48, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Meredith the Bright Archer", 850622034, 52, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Frostmaw the Mountain Terror", 24378719, 56, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Octavian the Militia Captain", 1688478381, 58, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Raziel the Shepherd", -680831417, 60, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Ungora the Spider Queen", -548489519, 60, false);
            VBloodUnitSettingsDataGridView.Rows.Add("The Duke of Balaton", -203043163, 62, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Foulrot the Soultaker", -1208888966, 62, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Jade the Vampire Hunter", -1968372384, 62, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Willfred Werewolf Chieftain", -1007062401, 64, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Mairwyn the Elementalist", -2013903325, 64, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Morian the Stormwing Matriach", 685266977, 68, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Azariel the Sunbringer", 114912615, 68, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Terrorclaw the Ogre", -1347412392, 68, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Matka the Curse Weaver", -910296704, 72, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Nightmarshal Styx the Sunderer", 1112948824, 76, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Gorecrusher the Behemoth", -1936575244, 78, false);
            VBloodUnitSettingsDataGridView.Rows.Add("The Winged Horror", -393555055, 78, false);
            VBloodUnitSettingsDataGridView.Rows.Add("Solarus the Immaculate", -740796338, 80, false);
        }

        private void SaveSettings()
        {
            bool CanLootEnemyContainersBool = true;
            bool BloodBoundEquipmentBool = true;
            bool TeleportBoundItemsBool = true;
            bool AllowGlobalChatBool = true;
            bool AllWaypointsUnlockedBool = false;
            bool FreeCastleClaimBool = false;
            bool FreeCastleDestroyBool = false;
            bool InactivityKillEnabledBool = true;
            bool DisableDisconnectedDeadEnabledBool = true;
            bool AnnounceSiegeWeaponSpawnBool = true;
            bool ShowSiegeWeaponMapIconBool = true;
            int StarterEquipment = 0;
            int StarterResources = 0;

            if (CanLootEnemyContainersRadioFalse.Checked)
            {
                CanLootEnemyContainersBool = false;
            }
            if (BloodBoundEquipmentRadioFalse.Checked)
            {
                BloodBoundEquipmentBool = false;
            }
            if (TeleportBoundItemsRadioFalse.Checked)
            {
                TeleportBoundItemsBool = false;
            }
            if (AllowGlobalChatRadioFalse.Checked)
            {
                AllowGlobalChatBool = false;
            }
            if (AllWaypointsUnlockedRadioTrue.Checked)
            {
                AllWaypointsUnlockedBool = true;
            }
            if (FreeCastleClaimRadioTrue.Checked)
            {
                FreeCastleClaimBool = true;
            }
            if (FreeCastleDestroyRadioTrue.Checked)
            {
                FreeCastleDestroyBool = true;
            }
            if (InactivityKillEnabledRadioFalse.Checked)
            {
                InactivityKillEnabledBool = false;
            }
            if (DisableDisconnectedDeadEnabledRadioFalse.Checked)
            {
                DisableDisconnectedDeadEnabledBool = false;
            }
            if (AnnounceSiegeWeaponSpawnRadioFalse.Checked)
            {
                AnnounceSiegeWeaponSpawnBool = false;
            }
            if (ShowSiegeWeaponMapIconRadioFalse.Checked)
            {
                ShowSiegeWeaponMapIconBool = false;
            }
            switch (StarterEquipmentComboBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    StarterEquipment = -376135143;
                    break;
                case 2:
                    StarterEquipment = -1613823352;
                    break;
                case 3:
                    StarterEquipment = -258598606;
                    break;
                case 4:
                    StarterEquipment = 1177675846;
                    break;
            }
            switch (StarterResourcesComboBox.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    StarterResources = -696202180;
                    break;
                case 2:
                    StarterResources = 481718792;
                    break;
                case 3:
                    StarterResources = -766909665;
                    break;
            }

            List<int> unlockedResearch = new List<int>();
            foreach (ListBoxItem item in UnlockedResearchCheckedListBox.CheckedItems)
            {
                int value = (item).Value;
                unlockedResearch.Add(value);
            }

            List<int> unlockedAchievements = new List<int>();
            foreach (ListBoxItem item in UnlockedAchievementsCheckedListBox.CheckedItems)
            {
                int value = (item).Value;
                unlockedAchievements.Add(value);
            }
            List<VBloodUnitSetting> VBloodList = new List<VBloodUnitSetting>();
            foreach (DataGridViewRow row in VBloodUnitSettingsDataGridView.Rows)
            {
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                int level = Convert.ToInt32(row.Cells["Level"].Value);
                bool unlocked = Convert.ToBoolean(row.Cells["DefaultUnlocked"].Value);
                if (level > 100)
                    level = 100;
                if (level < 1)
                    level = 1;
                VBloodUnitSetting unit = new VBloodUnitSetting()
                {
                    UnitId = id,
                    UnitLevel = level,
                    DefaultUnlocked = unlocked
                };
                VBloodList.Add(unit);
            }

            GameSettings main = new GameSettings()
            {
                GameModeType = GameTypeComboBox.SelectedIndex,
                CastleDamageMode = CastleDamageModeComboBox.SelectedIndex,
                SiegeWeaponHealth = SiegeWeaponHealthComboBox.SelectedIndex,
                PlayerDamageMode = PlayerDamageModeComboBox.SelectedIndex,
                CastleHeartDamageMode = CastleHeartDamageModeComboBox.SelectedIndex,
                PvPProtectionMode = PvPProtectionModeComboBox.SelectedIndex,
                DeathContainerPermission = DeathContainerPermissionComboBox.SelectedIndex,
                RelicSpawnType = RelicSpawnTypeComboBox.SelectedIndex,
                CanLootEnemyContainers = CanLootEnemyContainersBool,
                BloodBoundEquipment = BloodBoundEquipmentBool,
                TeleportBoundItems = TeleportBoundItemsBool,
                AllowGlobalChat = AllowGlobalChatBool,
                AllWaypointsUnlocked = AllWaypointsUnlockedBool,
                FreeCastleClaim = FreeCastleClaimBool,
                FreeCastleDestroy = FreeCastleDestroyBool,
                InactivityKillEnabled = InactivityKillEnabledBool,
                InactivityKillTimeMin = decimal.ToInt32(InactivityKillTimeMinNumber.Value),
                InactivityKillTimeMax = decimal.ToInt32(InactivityKillTimeMaxNumber.Value),
                InactivityKillSafeTimeAddition = decimal.ToInt32(InactivityKillSafeTimeAdditionNumber.Value),
                InactivityKillTimerMaxItemLevel = decimal.ToInt32(InactivityKillTimerMaxItemLevelNumber.Value),
                DisableDisconnectedDeadEnabled = DisableDisconnectedDeadEnabledBool,
                DisableDisconnectedDeadTimer = decimal.ToInt32(DisableDisconnectedDeadEnabledNumber.Value),
                InventoryStacksModifier = decimal.ToDouble(InventoryStacksModifierNumber.Value),
                DropTableModifier_General = decimal.ToDouble(DropTableModifier_GeneralNumber.Value),
                DropTableModifier_Missions = decimal.ToDouble(DropTableModifier_MissionsNumber.Value),
                MaterialYieldModifier_Global = decimal.ToDouble(MaterialYieldModifier_GlobalNumber.Value),
                BloodEssenceYieldModifier = decimal.ToDouble(BloodEssenceYieldModifierNumber.Value),
                JournalVBloodSourceUnitMaxDistance = decimal.ToDouble(JournalVBloodSourceUnitMaxDistanceNumber.Value),
                PvPVampireRespawnModifier = decimal.ToDouble(PvPVampireRespawnModifierNumber.Value),
                CastleMinimumDistanceInFloors = decimal.ToInt32(CastleMinimumDistanceInFloorsNumber.Value),
                ClanSize = decimal.ToInt32(ClanSizeNumber.Value),
                BloodDrainModifier = decimal.ToDouble(BloodDrainModifierNumber.Value),
                DurabilityDrainModifier = decimal.ToDouble(DurabilityDrainModifierNumber.Value),
                GarlicAreaStrengthModifier = decimal.ToDouble(GarlicAreaStrengthModifierNumber.Value),
                HolyAreaStrengthModifier = decimal.ToDouble(HolyAreaStrengthModifierNumber.Value),
                SilverStrengthModifier = decimal.ToDouble(SilverStrengthModifierNumber.Value),
                SunDamageModifier = decimal.ToDouble(SunDamageModifierNumber.Value),
                CastleDecayRateModifier = decimal.ToDouble(CastleDecayRateModifierNumber.Value),
                CastleBloodEssenceDrainModifier = decimal.ToDouble(CastleBloodEssenceDrainModifierNumber.Value),
                CastleSiegeTimer = decimal.ToDouble(CastleSiegeTimerNumber.Value),
                CastleUnderAttackTimer = decimal.ToDouble(CastleUnderAttackTimerNumber.Value),
                AnnounceSiegeWeaponSpawn = AnnounceSiegeWeaponSpawnBool,
                ShowSiegeWeaponMapIcon = ShowSiegeWeaponMapIconBool,
                BuildCostModifier = decimal.ToDouble(BuildCostModifierNumber.Value),
                RecipeCostModifier = decimal.ToDouble(RecipeCostModifierNumber.Value),
                CraftRateModifier = decimal.ToDouble(CraftRateModifierNumber.Value),
                ResearchCostModifier = decimal.ToDouble(ResearchCostModifierNumber.Value),
                RefinementCostModifier = decimal.ToDouble(RefinementCostModifierNumber.Value),
                RefinementRateModifier = decimal.ToDouble(RefinementRateModifierNumber.Value),
                ResearchTimeModifier = decimal.ToDouble(ResearchTimeModifierNumber.Value),
                DismantleResourceModifier = decimal.ToDouble(DismantleResourceModifierNumber.Value),
                ServantConvertRateModifier = decimal.ToDouble(ServantConvertRateModifierNumber.Value),
                RepairCostModifier = decimal.ToDouble(RepairCostModifierNumber.Value),
                Death_DurabilityFactorLoss = decimal.ToDouble(Death_DurabilityFactorLossNumber.Value),
                Death_DurabilityLossFactorAsResources = decimal.ToDouble(Death_DurabilityLossFactorAsResourcesNumber.Value),
                StarterEquipmentId = StarterEquipment,
                StarterResourcesId = StarterResources,
                VBloodUnitSettings = VBloodList,
                UnlockedAchievements = unlockedAchievements,
                UnlockedResearchs = unlockedResearch,
                GameTimeModifiers = new GameTimeModifiers()
                {
                    DayDurationInSeconds = decimal.ToDouble(DayDurationInSecondsNumber.Value),
                    DayStartHour = decimal.ToInt16(DayStartHourNumber.Value),
                    DayStartMinute = decimal.ToInt16(DayStartMinuteNumber.Value),
                    DayEndHour = decimal.ToInt16(DayEndHourNumber.Value),
                    DayEndMinute = decimal.ToInt16(DayEndMinuteNumber.Value),
                    BloodMoonFrequency_Min = decimal.ToInt16(BloodMoonFrequency_MinNumber.Value),
                    BloodMoonFrequency_Max = decimal.ToInt16(BloodMoonFrequency_MaxNumber.Value),
                    BloodMoonBuff = decimal.ToDouble(BloodMoonBuffNumber.Value),
                },
                VampireStatModifiers = new VampireStatModifiers()
                {
                    MaxHealthModifier = decimal.ToDouble(VampireMaxHealthModifierNumber.Value),
                    MaxEnergyModifier = decimal.ToDouble(VampireMaxEnergyModifierNumber.Value),
                    PhysicalPowerModifier = decimal.ToDouble(VampirePhysicalPowerModifierNumber.Value),
                    SpellPowerModifier = decimal.ToDouble(VampireSpellPowerModifierNumber.Value),
                    ResourcePowerModifier = decimal.ToDouble(VampireResourcePowerModifierNumber.Value),
                    SiegePowerModifier = decimal.ToDouble(VampireSiegePowerModifierNumber.Value),
                    DamageReceivedModifier = decimal.ToDouble(VampireDamageReceivedModifierNumber.Value),
                    ReviveCancelDelay = decimal.ToDouble(VampireReviveCancelDelayNumber.Value)
                },
                UnitStatModifiers_Global = new UnitStatModifiersGlobal()
                {
                    MaxHealthModifier = decimal.ToDouble(MaxHealthModifier_GlobalNumber.Value),
                    PowerModifier = decimal.ToDouble(PowerModifier_GlobalNumber.Value)
                },
                UnitStatModifiers_VBlood = new UnitStatModifiersVBlood()
                {
                    MaxHealthModifier = decimal.ToDouble(MaxHealthModifier_VBloodNumber.Value),
                    PowerModifier = decimal.ToDouble(PowerModifier_VBloodNumber.Value)
                },
                EquipmentStatModifiers_Global = new EquipmentStatModifiersGlobal()
                {
                    MaxEnergyModifier = decimal.ToDouble(MaxEnergyModifier_EquipmentNumber.Value),
                    MaxHealthModifier = decimal.ToDouble(MaxHealthModifier_EquipmentNumber.Value),
                    ResourceYieldModifier = decimal.ToDouble(ResourceYieldModifier_EquipmentNumber.Value),
                    PhysicalPowerModifier = decimal.ToDouble(PhysicalPowerModifier_EquipmentNumber.Value),
                    SpellPowerModifier = decimal.ToDouble(SpellPowerModifier_EquipmentNumber.Value),
                    SiegePowerModifier = decimal.ToDouble(SiegePowerModifier_EquipmentNumber.Value),
                    MovementSpeedModifier = decimal.ToDouble(MovementSpeedModifier_EquipmentNumber.Value)
                },
                CastleStatModifiers_Global = new CastleStatModifiersGlobal()
                {
                    TickPeriod = decimal.ToDouble(TickPeriodNumber.Value),
                    DamageResistance = decimal.ToDouble(DamageResistanceNumber.Value),
                    SafetyBoxLimit = decimal.ToInt16(SafetyBoxLimitNumber.Value),
                    TombLimit = decimal.ToInt16(TombLimitNumber.Value),
                    VerminNestLimit = decimal.ToInt16(VerminNestLimitNumber.Value),
                    PylonPenalties = new PylonPenalties()
                    {
                        Range1 = new EmptyJSON(),
                        Range2 = new EmptyJSON(),
                        Range3 = new EmptyJSON(),
                        Range4 = new EmptyJSON(),
                        Range5 = new EmptyJSON()
                    },
                    FloorPenalties = new FloorPenalties()
                    {
                        Range1 = new EmptyJSON(),
                        Range2 = new EmptyJSON(),
                        Range3 = new EmptyJSON(),
                        Range4 = new EmptyJSON(),
                        Range5 = new EmptyJSON()
                    },
                    HeartLimits = new HeartLimits()
                    {
                        Level1 = new Level1()
                        {
                            Level = 1,
                            FloorLimit = decimal.ToInt16(FloorLimit1Number.Value),
                            ServantLimit = decimal.ToInt16(ServantLimit1Number.Value)
                        },
                        Level2 = new Level2()
                        {
                            Level = 2,
                            FloorLimit = decimal.ToInt16(FloorLimit2Number.Value),
                            ServantLimit = decimal.ToInt16(ServantLimit2Number.Value)
                        },
                        Level3 = new Level3()
                        {
                            Level = 3,
                            FloorLimit = decimal.ToInt16(FloorLimit3Number.Value),
                            ServantLimit = decimal.ToInt16(ServantLimit3Number.Value)
                        },
                        Level4 = new Level4()
                        {
                            Level = 4,
                            FloorLimit = decimal.ToInt16(FloorLimit4Number.Value),
                            ServantLimit = decimal.ToInt16(ServantLimit4Number.Value)
                        }
                    },
                    CastleLimit = decimal.ToInt16(CastleLimitNumber.Value)
                },
                PlayerInteractionSettings = new PlayerInteractionSettings()
                {
                    TimeZone = TimeZoneComboBox.SelectedIndex,
                    VSPlayerWeekdayTime = new VSPlayerWeekdayTime()
                    {
                        StartHour = decimal.ToInt16(StartHourNumber_VSPlayerWeekday.Value),
                        StartMinute = decimal.ToInt16(StartMinuteNumber_VSPlayerWeekday.Value),
                        EndHour = decimal.ToInt16(EndHourNumber_VSPlayerWeekday.Value),
                        EndMinute = decimal.ToInt16(EndMinuteNumber_VSPlayerWeekday.Value)
                    },
                    VSPlayerWeekendTime = new VSPlayerWeekendTime()
                    {
                        StartHour = decimal.ToInt16(StartHourNumber_VSPlayerWeekend.Value),
                        StartMinute = decimal.ToInt16(StartMinuteNumber_VSPlayerWeekend.Value),
                        EndHour = decimal.ToInt16(EndHourNumber_VSPlayerWeekend.Value),
                        EndMinute = decimal.ToInt16(EndMinuteNumber_VSPlayerWeekend.Value)
                    },
                    VSCastleWeekdayTime = new VSCastleWeekdayTime()
                    {
                        StartHour = decimal.ToInt16(StartHourNumber_VSCastleWeekday.Value),
                        StartMinute = decimal.ToInt16(StartMinuteNumber_VSCastleWeekday.Value),
                        EndHour = decimal.ToInt16(EndHourNumber_VSCastleWeekday.Value),
                        EndMinute = decimal.ToInt16(EndMinuteNumber_VSCastleWeekday.Value)
                    },
                    VSCastleWeekendTime = new VSCastleWeekendTime()
                    {
                        StartHour = decimal.ToInt16(StartHourNumber_VSCastleWeekend.Value),
                        StartMinute = decimal.ToInt16(StartMinuteNumber_VSCastleWeekend.Value),
                        EndHour = decimal.ToInt16(EndHourNumber_VSCastleWeekend.Value),
                        EndMinute = decimal.ToInt16(EndMinuteNumber_VSCastleWeekend.Value)
                    }
                }

            };
            string SettingsJSON = JsonConvert.SerializeObject(main, Formatting.Indented);
            if (Directory.Exists(Properties.Settings.Default.Save_Path + @"\Saves\v1\" + Properties.Settings.Default.Save_Name))
            {
                SaveSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path + @"\Saves\v1\" + Properties.Settings.Default.Save_Name;
            }
            else
            {
                SaveSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path;
            }
            if (Properties.Settings.Default.AutoLoadGameSettings == true && MessageBox.Show("Save to auto-loaded file?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (File.Exists(Properties.Settings.Default.GameSettingsFile))
                {
                    File.Copy(Properties.Settings.Default.GameSettingsFile, Properties.Settings.Default.GameSettingsFile + ".bak", true);
                }
                File.WriteAllText(Properties.Settings.Default.GameSettingsFile, SettingsJSON);
                MessageBox.Show("File successfully saved to: \n" + Properties.Settings.Default.GameSettingsFile);
            }
            else if (SaveSettingsDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(SaveSettingsDialog.FileName))
                {
                    File.Copy(SaveSettingsDialog.FileName, SaveSettingsDialog.FileName + ".bak", true);
                }
                File.WriteAllText(SaveSettingsDialog.FileName, SettingsJSON);
                MessageBox.Show("File successfully saved to: \n" + SaveSettingsDialog.FileName);
            }

        }

        private void LoadSettings(bool AutoLoad, bool Preset, int PresetToLoad)
        {
            string FileToLoad = "temp";
            string PresetFile = "temp";
            switch (Preset)
            {
                case false:
                    if (Directory.Exists(Properties.Settings.Default.Save_Path + @"\Saves\v1\" + Properties.Settings.Default.Save_Name))
                    {
                        LoadSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path + @"\Saves\v1\" + Properties.Settings.Default.Save_Name;
                    }
                    else
                    {
                        LoadSettingsDialog.InitialDirectory = Properties.Settings.Default.Save_Path;
                    }
                    if (AutoLoad == true)
                    {
                        FileToLoad = Properties.Settings.Default.GameSettingsFile;
                    }
                    else if (LoadSettingsDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileToLoad = LoadSettingsDialog.FileName;
                    }                    
                    else
                    {
                        return;
                    }
                    break;
                case true:
                    switch (PresetToLoad)
                    {
                        case 1:
                            PresetFile = "ServerManager.Resources.Standard_PvE.json";
                            break;
                        case 2:
                            PresetFile = "ServerManager.Resources.Standard_PvE_Easy.json";
                            break;
                        case 3:
                            PresetFile = "ServerManager.Resources.Standard_PvE_Hard.json";
                            break;
                        case 4:
                            PresetFile = "ServerManager.Resources.PvE_Dawn_Lvl30.json";
                            break;
                        case 5:
                            PresetFile = "ServerManager.Resources.PvE_Noon_Lvl50.json";
                            break;
                        case 6:
                            PresetFile = "ServerManager.Resources.PvE_Dusk_Lvl70.json";
                            break;
                        case 7:
                            PresetFile = "ServerManager.Resources.Standard_PvP.json";
                            break;
                        case 8:
                            PresetFile = "ServerManager.Resources.Standard_PvP_Easy.json";
                            break;
                        case 9:
                            PresetFile = "ServerManager.Resources.Standard_PvP_Hard.json";
                            break;
                        case 10:
                            PresetFile = "ServerManager.Resources.PvP_Dawn_Lvl30.json";
                            break;
                        case 11:
                            PresetFile = "ServerManager.Resources.PvP_Noon_Lvl50.json";
                            break;
                        case 12:
                            PresetFile = "ServerManager.Resources.PvP_Dusk_Lvl70.json";
                            break;
                        case 13:
                            PresetFile = "ServerManager.Resources.Full_Loot_PvP.json";
                            break;
                        case 14:
                            PresetFile = "ServerManager.Resources.Solo_PvP.json";
                            break;
                        case 15:
                            PresetFile = "ServerManager.Resources.Duo_PvP.json";
                            break;
                    }
                    break;

            }
            if (Preset == true)
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream(PresetFile))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string LoadedJSON = reader.ReadToEnd();
                    LoadHandler(LoadedJSON);
                }
            }
            else
            {
                using (StreamReader reader = new StreamReader(FileToLoad))
                {
                    string LoadedJSON = reader.ReadToEnd();
                    LoadHandler(LoadedJSON);
                }
            }
            
        }

        private void LoadHandler(string Loaded)
        {
            try
            {
                GameSettings LoadedSettings = JsonConvert.DeserializeObject<GameSettings>(Loaded);
                if (int.TryParse(LoadedSettings.GameModeType.ToString(), out int GameModeTypeValue))
                {
                    GameTypeComboBox.SelectedIndex = GameModeTypeValue;
                }
                else
                {
                    switch (LoadedSettings.GameModeType)
                    {
                        case "PvE":
                            GameTypeComboBox.SelectedIndex = 0;
                            break;
                        case "PvP":
                            GameTypeComboBox.SelectedIndex = 1;
                            break;
                    }
                }
                if (int.TryParse(LoadedSettings.CastleDamageMode.ToString(), out int CastleDamageModeValue))
                {
                    CastleDamageModeComboBox.SelectedIndex = CastleDamageModeValue;
                }
                else
                {
                    switch (LoadedSettings.CastleDamageMode)
                    {
                        case "Never":
                            CastleDamageModeComboBox.SelectedIndex = 0;
                            break;
                        case "Always":
                            CastleDamageModeComboBox.SelectedIndex = 1;
                            break;
                        case "TimeRestricted":
                            CastleDamageModeComboBox.SelectedIndex = 2;
                            break;
                    }
                }
                if (int.TryParse(LoadedSettings.SiegeWeaponHealth.ToString(), out int SiegeWeaponHealthValue))
                {
                    SiegeWeaponHealthComboBox.SelectedIndex = SiegeWeaponHealthValue;
                }
                else
                {
                    switch (LoadedSettings.SiegeWeaponHealth)
                    {
                        case "VeryLow":
                            SiegeWeaponHealthComboBox.SelectedIndex = 0;
                            break;
                        case "Low":
                            SiegeWeaponHealthComboBox.SelectedIndex = 1;
                            break;
                        case "Normal":
                            SiegeWeaponHealthComboBox.SelectedIndex = 2;
                            break;
                        case "High":
                            SiegeWeaponHealthComboBox.SelectedIndex = 3;
                            break;
                        case "VeryHigh":
                            SiegeWeaponHealthComboBox.SelectedIndex = 4;
                            break;
                    }
                }
                if (int.TryParse(LoadedSettings.PlayerDamageMode.ToString(), out int PlayerDamageModeValue))
                {
                    PlayerDamageModeComboBox.SelectedIndex = PlayerDamageModeValue;
                }
                else
                {
                    switch (LoadedSettings.PlayerDamageMode)
                    {
                        case "Always":
                            PlayerDamageModeComboBox.SelectedIndex = 0;
                            break;
                        case "Restricted":
                            PlayerDamageModeComboBox.SelectedIndex = 1;
                            break;
                    }
                }
                if (int.TryParse(LoadedSettings.CastleHeartDamageMode.ToString(), out int CastleHeartDamageModeValue))
                {
                    CastleHeartDamageModeComboBox.SelectedIndex = CastleHeartDamageModeValue;
                }
                else
                {
                    switch (LoadedSettings.CastleHeartDamageMode)
                    {
                        case "CanBeDestroyedOnlyWhenDecaying":
                            CastleHeartDamageModeComboBox.SelectedIndex = 0;
                            break;
                        case "CanBeDestroyedByPlayers":
                            CastleHeartDamageModeComboBox.SelectedIndex = 1;
                            break;
                        case "CanBeSeizedOrDestroyedByPlayers":
                            CastleHeartDamageModeComboBox.SelectedIndex = 2;
                            break;
                    }
                }
                if (int.TryParse(LoadedSettings.PvPProtectionMode.ToString(), out int PvPProtectionModeValue))
                {
                    PvPProtectionModeComboBox.SelectedIndex = PvPProtectionModeValue;
                }
                else
                {
                    switch (LoadedSettings.PvPProtectionMode)
                    {
                        case "Disabled":
                            PvPProtectionModeComboBox.SelectedIndex = 0;
                            break;
                        case "VeryShort":
                            PvPProtectionModeComboBox.SelectedIndex = 1;
                            break;
                        case "Short":
                            PvPProtectionModeComboBox.SelectedIndex = 2;
                            break;
                        case "Medium":
                            PvPProtectionModeComboBox.SelectedIndex = 3;
                            break;
                        case "Long":
                            PvPProtectionModeComboBox.SelectedIndex = 4;
                            break;
                    }
                }
                if (int.TryParse(LoadedSettings.DeathContainerPermission.ToString(), out int DeathContainerPermissionValue))
                {
                    DeathContainerPermissionComboBox.SelectedIndex = DeathContainerPermissionValue;
                }
                else
                {
                    switch (LoadedSettings.DeathContainerPermission)
                    {
                        case "Anyone":
                            DeathContainerPermissionComboBox.SelectedIndex = 0;
                            break;
                        case "ClanMembers":
                            DeathContainerPermissionComboBox.SelectedIndex = 1;
                            break;
                        case "OnlySelf":
                            DeathContainerPermissionComboBox.SelectedIndex = 2;
                            break;
                    }
                }
                if (int.TryParse(LoadedSettings.RelicSpawnType.ToString(), out int RelicSpawnTypeValue))
                {
                    RelicSpawnTypeComboBox.SelectedIndex = RelicSpawnTypeValue;
                }
                else
                {
                    switch (LoadedSettings.RelicSpawnType)
                    {
                        case "Unique":
                            RelicSpawnTypeComboBox.SelectedIndex = 0;
                            break;
                        case "Plentiful":
                            RelicSpawnTypeComboBox.SelectedIndex = 1;
                            break;
                    }
                }
                if (LoadedSettings.CanLootEnemyContainers == true)
                {
                    CanLootEnemyContainersRadioTrue.Checked = true;
                    CanLootEnemyContainersRadioFalse.Checked = false;
                }
                else
                {
                    CanLootEnemyContainersRadioTrue.Checked = false;
                    CanLootEnemyContainersRadioFalse.Checked = true;
                }
                if (LoadedSettings.BloodBoundEquipment == true)
                {
                    BloodBoundEquipmentRadioTrue.Checked = true;
                    BloodBoundEquipmentRadioFalse.Checked = false;
                }
                else
                {
                    BloodBoundEquipmentRadioTrue.Checked = false;
                    BloodBoundEquipmentRadioFalse.Checked = true;
                }
                if (LoadedSettings.TeleportBoundItems == true)
                {
                    TeleportBoundItemsRadioTrue.Checked = true;
                    TeleportBoundItemsRadioFalse.Checked = false;
                }
                else
                {
                    TeleportBoundItemsRadioTrue.Checked = false;
                    TeleportBoundItemsRadioFalse.Checked = true;
                }
                if (LoadedSettings.AllowGlobalChat == true)
                {
                    AllowGlobalChatRadioTrue.Checked = true;
                    AllowGlobalChatRadioFalse.Checked = false;
                }
                else
                {
                    AllowGlobalChatRadioTrue.Checked = false;
                    AllowGlobalChatRadioFalse.Checked = true;
                }
                if (LoadedSettings.AllWaypointsUnlocked == true)
                {
                    AllWaypointsUnlockedRadioTrue.Checked = true;
                    AllWaypointsUnlockedRadioFalse.Checked = false;
                }
                else
                {
                    AllWaypointsUnlockedRadioTrue.Checked = false;
                    AllWaypointsUnlockedRadioFalse.Checked = true;
                }
                if (LoadedSettings.FreeCastleClaim == true)
                {
                    FreeCastleClaimRadioTrue.Checked = true;
                    FreeCastleClaimRadioFalse.Checked = false;
                }
                else
                {
                    FreeCastleClaimRadioTrue.Checked = false;
                    FreeCastleClaimRadioFalse.Checked = true;
                }
                if (LoadedSettings.FreeCastleDestroy == true)
                {
                    FreeCastleDestroyRadioTrue.Checked = true;
                    FreeCastleDestroyRadioFalse.Checked = false;
                }
                else
                {
                    FreeCastleDestroyRadioTrue.Checked = false;
                    FreeCastleDestroyRadioFalse.Checked = true;
                }
                if (LoadedSettings.InactivityKillEnabled == true)
                {
                    InactivityKillEnabledRadioTrue.Checked = true;
                    InactivityKillEnabledRadioFalse.Checked = false;
                }
                else
                {
                    InactivityKillEnabledRadioTrue.Checked = false;
                    InactivityKillEnabledRadioFalse.Checked = true;
                }
                switch (LoadedSettings.StarterEquipmentId)
                {
                    case -376135143:
                        StarterEquipmentComboBox.SelectedIndex = 1;
                        break;
                    case -1613823352:
                        StarterEquipmentComboBox.SelectedIndex = 2;
                        break;
                    case -258598606:
                        StarterEquipmentComboBox.SelectedIndex = 3;
                        break;
                    case 1177675846:
                        StarterEquipmentComboBox.SelectedIndex = 4;
                        break;
                    default:
                        StarterEquipmentComboBox.SelectedIndex = 0;
                        break;
                }
                switch (LoadedSettings.StarterResourcesId)
                {
                    case -696202180:
                        StarterResourcesComboBox.SelectedIndex = 1;
                        break;
                    case 481718792:
                        StarterResourcesComboBox.SelectedIndex = 2;
                        break;
                    case -766909665:
                        StarterResourcesComboBox.SelectedIndex = 3;
                        break;
                    default:
                        StarterResourcesComboBox.SelectedIndex = 0;
                        break;
                }
                InactivityKillTimeMinNumber.Value = Convert.ToInt32(LoadedSettings.InactivityKillTimeMin);
                InactivityKillTimeMaxNumber.Value = Convert.ToInt32(LoadedSettings.InactivityKillTimeMax);
                InactivityKillSafeTimeAdditionNumber.Value = Convert.ToInt32(LoadedSettings.InactivityKillSafeTimeAddition);
                InactivityKillTimerMaxItemLevelNumber.Value = Convert.ToInt16(LoadedSettings.InactivityKillTimerMaxItemLevel);
                if (LoadedSettings.DisableDisconnectedDeadEnabled == true)
                {
                    DisableDisconnectedDeadEnabledRadioTrue.Checked = true;
                    DisableDisconnectedDeadEnabledRadioFalse.Checked = false;
                }
                else
                {
                    DisableDisconnectedDeadEnabledRadioTrue.Checked = false;
                    DisableDisconnectedDeadEnabledRadioFalse.Checked = true;
                }
                DisableDisconnectedDeadEnabledNumber.Value = Convert.ToInt16(LoadedSettings.DisableDisconnectedDeadTimer);
                InventoryStacksModifierNumber.Value = Convert.ToDecimal(LoadedSettings.InventoryStacksModifier);
                DropTableModifier_GeneralNumber.Value = Convert.ToDecimal(LoadedSettings.DropTableModifier_General);
                DropTableModifier_MissionsNumber.Value = Convert.ToDecimal(LoadedSettings.DropTableModifier_Missions);
                MaterialYieldModifier_GlobalNumber.Value = Convert.ToDecimal(LoadedSettings.MaterialYieldModifier_Global);
                BloodEssenceYieldModifierNumber.Value = Convert.ToDecimal(LoadedSettings.BloodEssenceYieldModifier);
                JournalVBloodSourceUnitMaxDistanceNumber.Value = Convert.ToDecimal(LoadedSettings.JournalVBloodSourceUnitMaxDistance);
                PvPVampireRespawnModifierNumber.Value = Convert.ToDecimal(LoadedSettings.PvPVampireRespawnModifier);
                CastleMinimumDistanceInFloorsNumber.Value = Convert.ToInt16(LoadedSettings.CastleMinimumDistanceInFloors);
                ClanSizeNumber.Value = Convert.ToInt16(LoadedSettings.ClanSize);
                BloodDrainModifierNumber.Value = Convert.ToDecimal(LoadedSettings.BloodDrainModifier);
                DurabilityDrainModifierNumber.Value = Convert.ToDecimal(LoadedSettings.DurabilityDrainModifier);
                GarlicAreaStrengthModifierNumber.Value = Convert.ToDecimal(LoadedSettings.GarlicAreaStrengthModifier);
                HolyAreaStrengthModifierNumber.Value = Convert.ToDecimal(LoadedSettings.HolyAreaStrengthModifier);
                SilverStrengthModifierNumber.Value = Convert.ToDecimal(LoadedSettings.SilverStrengthModifier);
                SunDamageModifierNumber.Value = Convert.ToDecimal(LoadedSettings.SunDamageModifier);
                CastleDecayRateModifierNumber.Value = Convert.ToDecimal(LoadedSettings.CastleDecayRateModifier);
                CastleBloodEssenceDrainModifierNumber.Value = Convert.ToDecimal(LoadedSettings.CastleBloodEssenceDrainModifier);
                CastleSiegeTimerNumber.Value = Convert.ToDecimal(LoadedSettings.CastleSiegeTimer);
                CastleUnderAttackTimerNumber.Value = Convert.ToDecimal(LoadedSettings.CastleUnderAttackTimer);
                if (LoadedSettings.AnnounceSiegeWeaponSpawn == true)
                {
                    AnnounceSiegeWeaponSpawnRadioTrue.Checked = true;
                    AnnounceSiegeWeaponSpawnRadioFalse.Checked = false;
                }
                else
                {
                    AnnounceSiegeWeaponSpawnRadioTrue.Checked = false;
                    AnnounceSiegeWeaponSpawnRadioFalse.Checked = true;
                }
                if (LoadedSettings.ShowSiegeWeaponMapIcon == true)
                {
                    ShowSiegeWeaponMapIconRadioTrue.Checked = true;
                    ShowSiegeWeaponMapIconRadioFalse.Checked = false;
                }
                else
                {
                    ShowSiegeWeaponMapIconRadioTrue.Checked = false;
                    ShowSiegeWeaponMapIconRadioFalse.Checked = true;
                }
                BuildCostModifierNumber.Value = Convert.ToDecimal(LoadedSettings.BuildCostModifier);
                RecipeCostModifierNumber.Value = Convert.ToDecimal(LoadedSettings.RecipeCostModifier);
                CraftRateModifierNumber.Value = Convert.ToDecimal(LoadedSettings.CraftRateModifier);
                ResearchCostModifierNumber.Value = Convert.ToDecimal(LoadedSettings.ResearchCostModifier);
                RefinementCostModifierNumber.Value = Convert.ToDecimal(LoadedSettings.RefinementCostModifier);
                RefinementRateModifierNumber.Value = Convert.ToDecimal(LoadedSettings.RefinementRateModifier);
                ResearchTimeModifierNumber.Value = Convert.ToDecimal(LoadedSettings.ResearchTimeModifier);
                DismantleResourceModifierNumber.Value = Convert.ToDecimal(LoadedSettings.DismantleResourceModifier);
                ServantConvertRateModifierNumber.Value = Convert.ToDecimal(LoadedSettings.ServantConvertRateModifier);
                RepairCostModifierNumber.Value = Convert.ToDecimal(LoadedSettings.RepairCostModifier);
                Death_DurabilityFactorLossNumber.Value = Convert.ToDecimal(LoadedSettings.Death_DurabilityFactorLoss);
                Death_DurabilityLossFactorAsResourcesNumber.Value = Convert.ToDecimal(LoadedSettings.Death_DurabilityLossFactorAsResources);
                DayDurationInSecondsNumber.Value = Convert.ToDecimal(LoadedSettings.GameTimeModifiers.DayDurationInSeconds);
                DayStartHourNumber.Value = Convert.ToDecimal(LoadedSettings.GameTimeModifiers.DayStartHour);
                DayStartMinuteNumber.Value = Convert.ToDecimal(LoadedSettings.GameTimeModifiers.DayStartMinute);
                DayEndHourNumber.Value = Convert.ToDecimal(LoadedSettings.GameTimeModifiers.DayEndHour);
                DayEndMinuteNumber.Value = Convert.ToDecimal(LoadedSettings.GameTimeModifiers.DayEndMinute);
                BloodMoonFrequency_MinNumber.Value = Convert.ToDecimal(LoadedSettings.GameTimeModifiers.BloodMoonFrequency_Min);
                BloodMoonFrequency_MaxNumber.Value = Convert.ToDecimal(LoadedSettings.GameTimeModifiers.BloodMoonFrequency_Max);
                BloodMoonBuffNumber.Value = Convert.ToDecimal(LoadedSettings.GameTimeModifiers.BloodMoonBuff);
                VampireMaxHealthModifierNumber.Value = Convert.ToDecimal(LoadedSettings.VampireStatModifiers.MaxHealthModifier);
                VampireMaxEnergyModifierNumber.Value = Convert.ToDecimal(LoadedSettings.VampireStatModifiers.MaxEnergyModifier);
                VampirePhysicalPowerModifierNumber.Value = Convert.ToDecimal(LoadedSettings.VampireStatModifiers.PhysicalPowerModifier);
                VampireSpellPowerModifierNumber.Value = Convert.ToDecimal(LoadedSettings.VampireStatModifiers.SpellPowerModifier);
                VampireResourcePowerModifierNumber.Value = Convert.ToDecimal(LoadedSettings.VampireStatModifiers.ResourcePowerModifier);
                VampireSiegePowerModifierNumber.Value = Convert.ToDecimal(LoadedSettings.VampireStatModifiers.SiegePowerModifier);
                VampireDamageReceivedModifierNumber.Value = Convert.ToDecimal(LoadedSettings.VampireStatModifiers.DamageReceivedModifier);
                VampireReviveCancelDelayNumber.Value = Convert.ToDecimal(LoadedSettings.VampireStatModifiers.ReviveCancelDelay);
                MaxHealthModifier_GlobalNumber.Value = Convert.ToDecimal(LoadedSettings.UnitStatModifiers_Global.MaxHealthModifier);
                PowerModifier_GlobalNumber.Value = Convert.ToDecimal(LoadedSettings.UnitStatModifiers_Global.PowerModifier);
                MaxHealthModifier_VBloodNumber.Value = Convert.ToDecimal(LoadedSettings.UnitStatModifiers_VBlood.MaxHealthModifier);
                PowerModifier_VBloodNumber.Value = Convert.ToDecimal(LoadedSettings.UnitStatModifiers_VBlood.PowerModifier);
                MaxEnergyModifier_EquipmentNumber.Value = Convert.ToDecimal(LoadedSettings.EquipmentStatModifiers_Global.MaxEnergyModifier);
                MaxHealthModifier_EquipmentNumber.Value = Convert.ToDecimal(LoadedSettings.EquipmentStatModifiers_Global.MaxHealthModifier);
                ResourceYieldModifier_EquipmentNumber.Value = Convert.ToDecimal(LoadedSettings.EquipmentStatModifiers_Global.ResourceYieldModifier);
                PhysicalPowerModifier_EquipmentNumber.Value = Convert.ToDecimal(LoadedSettings.EquipmentStatModifiers_Global.PhysicalPowerModifier);
                SpellPowerModifier_EquipmentNumber.Value = Convert.ToDecimal(LoadedSettings.EquipmentStatModifiers_Global.SpellPowerModifier);
                SiegePowerModifier_EquipmentNumber.Value = Convert.ToDecimal(LoadedSettings.EquipmentStatModifiers_Global.SiegePowerModifier);
                MovementSpeedModifier_EquipmentNumber.Value = Convert.ToDecimal(LoadedSettings.EquipmentStatModifiers_Global.MovementSpeedModifier);
                TickPeriodNumber.Value = Convert.ToDecimal(LoadedSettings.CastleStatModifiers_Global.TickPeriod);
                DamageResistanceNumber.Value = Convert.ToDecimal(LoadedSettings.CastleStatModifiers_Global.DamageResistance);
                SafetyBoxLimitNumber.Value = Convert.ToInt16(LoadedSettings.CastleStatModifiers_Global.SafetyBoxLimit);
                TombLimitNumber.Value = Convert.ToInt16(LoadedSettings.CastleStatModifiers_Global.TombLimit);
                VerminNestLimitNumber.Value = Convert.ToInt16(LoadedSettings.CastleStatModifiers_Global.VerminNestLimit);
                FloorLimit1Number.Value = Convert.ToInt16(LoadedSettings.CastleStatModifiers_Global.HeartLimits.Level1.FloorLimit);
                ServantLimit1Number.Value = Convert.ToInt16(LoadedSettings.CastleStatModifiers_Global.HeartLimits.Level1.ServantLimit);
                FloorLimit2Number.Value = Convert.ToInt16(LoadedSettings.CastleStatModifiers_Global.HeartLimits.Level2.FloorLimit);
                ServantLimit2Number.Value = Convert.ToInt16(LoadedSettings.CastleStatModifiers_Global.HeartLimits.Level2.ServantLimit);
                FloorLimit3Number.Value = Convert.ToInt16(LoadedSettings.CastleStatModifiers_Global.HeartLimits.Level3.FloorLimit);
                ServantLimit3Number.Value = Convert.ToInt16(LoadedSettings.CastleStatModifiers_Global.HeartLimits.Level3.ServantLimit);
                FloorLimit4Number.Value = Convert.ToInt16(LoadedSettings.CastleStatModifiers_Global.HeartLimits.Level4.FloorLimit);
                ServantLimit4Number.Value = Convert.ToInt16(LoadedSettings.CastleStatModifiers_Global.HeartLimits.Level4.ServantLimit);
                CastleLimitNumber.Value = Convert.ToInt16(LoadedSettings.CastleStatModifiers_Global.CastleLimit);
                if (int.TryParse(LoadedSettings.PlayerInteractionSettings.TimeZone.ToString(), out int TimeZoneValue))
                {
                    TimeZoneComboBox.SelectedIndex = TimeZoneValue;
                }
                else
                {
                    switch (LoadedSettings.PlayerInteractionSettings.TimeZone)
                    {
                        case "Local":
                            TimeZoneComboBox.SelectedIndex = 0;
                            break;
                        case "UTC":
                            TimeZoneComboBox.SelectedIndex = 1;
                            break;
                        case "PST":
                            TimeZoneComboBox.SelectedIndex = 2;
                            break;
                        case "EST":
                            TimeZoneComboBox.SelectedIndex = 3;
                            break;
                        case "CET":
                            TimeZoneComboBox.SelectedIndex = 4;
                            break;
                        case "CST":
                            TimeZoneComboBox.SelectedIndex = 5;
                            break;
                    }
                }
                StartHourNumber_VSPlayerWeekday.Value = Convert.ToInt16(LoadedSettings.PlayerInteractionSettings.VSPlayerWeekdayTime.StartHour);
                StartMinuteNumber_VSPlayerWeekday.Value = Convert.ToInt16(LoadedSettings.PlayerInteractionSettings.VSPlayerWeekdayTime.StartMinute);
                EndHourNumber_VSPlayerWeekday.Value = Convert.ToInt16(LoadedSettings.PlayerInteractionSettings.VSPlayerWeekdayTime.EndHour);
                EndMinuteNumber_VSPlayerWeekday.Value = Convert.ToInt16(LoadedSettings.PlayerInteractionSettings.VSPlayerWeekdayTime.EndMinute);
                StartHourNumber_VSPlayerWeekend.Value = Convert.ToInt16(LoadedSettings.PlayerInteractionSettings.VSPlayerWeekendTime.StartHour);
                StartMinuteNumber_VSPlayerWeekend.Value = Convert.ToInt16(LoadedSettings.PlayerInteractionSettings.VSPlayerWeekendTime.StartMinute);
                EndHourNumber_VSPlayerWeekend.Value = Convert.ToInt16(LoadedSettings.PlayerInteractionSettings.VSPlayerWeekendTime.EndHour);
                EndMinuteNumber_VSPlayerWeekend.Value = Convert.ToInt16(LoadedSettings.PlayerInteractionSettings.VSPlayerWeekendTime.EndMinute);
                StartHourNumber_VSCastleWeekday.Value = Convert.ToInt16(LoadedSettings.PlayerInteractionSettings.VSCastleWeekdayTime.StartHour);
                StartMinuteNumber_VSCastleWeekday.Value = Convert.ToInt16(LoadedSettings.PlayerInteractionSettings.VSCastleWeekdayTime.StartMinute);
                EndHourNumber_VSCastleWeekday.Value = Convert.ToInt16(LoadedSettings.PlayerInteractionSettings.VSCastleWeekdayTime.EndHour);
                EndMinuteNumber_VSCastleWeekday.Value = Convert.ToInt16(LoadedSettings.PlayerInteractionSettings.VSCastleWeekdayTime.EndMinute);
                StartHourNumber_VSCastleWeekend.Value = Convert.ToInt16(LoadedSettings.PlayerInteractionSettings.VSCastleWeekendTime.StartHour);
                StartMinuteNumber_VSCastleWeekend.Value = Convert.ToInt16(LoadedSettings.PlayerInteractionSettings.VSCastleWeekendTime.StartMinute);
                EndHourNumber_VSCastleWeekend.Value = Convert.ToInt16(LoadedSettings.PlayerInteractionSettings.VSCastleWeekendTime.EndHour);
                EndMinuteNumber_VSCastleWeekend.Value = Convert.ToInt16(LoadedSettings.PlayerInteractionSettings.VSCastleWeekendTime.EndMinute);
                foreach (VBloodUnitSetting unit in LoadedSettings.VBloodUnitSettings)
                {
                    foreach (DataGridViewRow row in VBloodUnitSettingsDataGridView.Rows)
                    {
                        if (row.Cells[1].Value.ToString().Contains(unit.UnitId.ToString()))
                        {
                            row.Cells[2].Value = unit.UnitLevel.ToString();
                            row.Cells[3].Value = unit.DefaultUnlocked;
                        }
                    }
                }
                foreach (int value in LoadedSettings.UnlockedAchievements)
                {
                    for (int i = 0; i < UnlockedAchievementsCheckedListBox.Items.Count; i++)
                    {
                        ListBoxItem lbi = UnlockedAchievementsCheckedListBox.Items[i] as ListBoxItem;
                        if (lbi.Value == value)
                        {
                            UnlockedAchievementsCheckedListBox.SetItemChecked(i, true);
                        }
                    }
                }
                if (LoadedSettings.UnlockedResearchs.Contains(-495424062))
                {
                    UnlockedResearchCheckedListBox.SetItemChecked(0, true);
                }
                if (LoadedSettings.UnlockedResearchs.Contains(-1292809886))
                {
                    UnlockedResearchCheckedListBox.SetItemChecked(1, true);
                }
                if (LoadedSettings.UnlockedResearchs.Contains(-1262194203))
                {
                    UnlockedResearchCheckedListBox.SetItemChecked(2, true);
                }
            }
            catch (NullReferenceException)
            {
                //For now this error is ok, we ignore it. Means one or more entries were missing.
            }
            catch (ArgumentOutOfRangeException e)
            {
                MessageBox.Show("One or more values are set too high/low in the loaded file. Unable to load the file.\n\n" + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to quit?\nAll unsaved data will be lost.", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void InactivityKillEnabledRadioTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (InactivityKillEnabledRadioTrue.Checked)
            {
                InactivityKillTimeMinNumber.ReadOnly = false;
                InactivityKillTimeMinNumber.Increment = 1;
            }
        }

        private void InactivityKillEnabledRadioFalse_CheckedChanged(object sender, EventArgs e)
        {
            if (InactivityKillEnabledRadioFalse.Checked)
            {
                InactivityKillTimeMinNumber.ReadOnly = true;
                InactivityKillTimeMinNumber.Increment = 0;
            }
        }

        private void DisableDisconnectedDeadEnabledRadioTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (DisableDisconnectedDeadEnabledRadioTrue.Checked)
            {
                DisableDisconnectedDeadEnabledNumber.ReadOnly = false;
                DisableDisconnectedDeadEnabledNumber.Increment = 1;
            }
        }

        private void DisableDisconnectedDeadEnabledRadioFalse_CheckedChanged(object sender, EventArgs e)
        {
            if (DisableDisconnectedDeadEnabledRadioFalse.Checked)
            {
                DisableDisconnectedDeadEnabledNumber.ReadOnly = true;
                DisableDisconnectedDeadEnabledNumber.Increment = 0;
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSettings(false, false, 0);
        }

        private void VBloodUnitSettingsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2) // 1 should be your column index
            {
                int i;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Please enter a numeric whole value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    
                }
            }
        }

        private void standardPvEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nAll unsaved changes are lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSettings(false, true, 1);
            }
        }

        private void standardPvEEasyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nAll unsaved changes are lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSettings(false, true, 2);
            }
        }

        private void standardPvEHardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nAll unsaved changes are lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSettings(false, true, 3);
            }
        }
        private void pvEDawnLevel30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nAll unsaved changes are lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSettings(false, true, 4);
            }
        }

        private void pvENoonLevel50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nAll unsaved changes are lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSettings(false, true, 5);
            }
        }

        private void pvEDuskLevel70ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nAll unsaved changes are lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSettings(false, true, 6);
            }
        }

        private void standardPvPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nAll unsaved changes are lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSettings(false, true, 7);
            }
        }

        private void standardPvPEasyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nAll unsaved changes are lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSettings(false, true, 8);
            }
        }

        private void standardPvPHardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nAll unsaved changes are lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSettings(false, true, 9);
            }
        }

        private void pvPDawnLevel30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nAll unsaved changes are lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSettings(false, true, 10);
            }
        }

        private void pvPNoonLevel50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nAll unsaved changes are lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSettings(false, true, 11);
            }
        }

        private void pvPDuskLevel70ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nAll unsaved changes are lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSettings(false, true, 12);
            }
        }

        private void pvPFullLootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nAll unsaved changes are lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSettings(false, true, 13);
            }
        }

        private void pvPSoloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nAll unsaved changes are lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSettings(false, true, 14);
            }
        }

        private void pvPDuoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nAll unsaved changes are lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoadSettings(false, true, 15);
            }
        }
    }
}
