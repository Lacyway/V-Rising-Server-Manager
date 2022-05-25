using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetupDefaults();
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

            RootSettings main = new RootSettings()
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
                StarterEquipmentId = 0,
                StarterResourcesId = 0,
                VBloodUnitSettings = new List<object>(),
                UnlockedAchievements = new List<object>(),
                UnlockedResearchs = new List<object>(),
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
                    TimeZone = TimeZoneComboBox.SelectedItem.ToString(),
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
        SaveSettingsDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Low" + "\\Stunlock Studios\\VRising";
        if (SaveSettingsDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(SaveSettingsDialog.FileName))
                {
                    File.Copy(SaveSettingsDialog.FileName, SaveSettingsDialog.FileName + ".bak", true);
                }
                File.WriteAllText(SaveSettingsDialog.FileName, SettingsJSON);
                MessageBox.Show("File successfully saved to: \n" + SaveSettingsDialog.FileName);
            }

        }


        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to quit?\nAll unsaved data will be lost.", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void InactivityKillEnabledRadioTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (InactivityKillEnabledRadioTrue.Checked)
            {
                InactivityKillTimeMinNumber.ReadOnly = false;
                InactivityKillTimeMinNumber.Increment = 1;
                InactivityKillTimeMaxNumber.ReadOnly = false;
                InactivityKillTimeMaxNumber.Increment = 1;
                InactivityKillSafeTimeAdditionNumber.ReadOnly = false;
                InactivityKillSafeTimeAdditionNumber.Increment = 1;
                InactivityKillTimerMaxItemLevelNumber.ReadOnly = false;
                InactivityKillTimerMaxItemLevelNumber.Increment = 1;
            }
        }

        private void InactivityKillEnabledRadioFalse_CheckedChanged(object sender, EventArgs e)
        {
            if (InactivityKillEnabledRadioFalse.Checked)
            {
                InactivityKillTimeMinNumber.ReadOnly = true;
                InactivityKillTimeMinNumber.Increment = 0;
                InactivityKillTimeMaxNumber.ReadOnly = true;
                InactivityKillTimeMaxNumber.Increment = 0;
                InactivityKillSafeTimeAdditionNumber.ReadOnly = true;
                InactivityKillSafeTimeAdditionNumber.Increment = 0;
                InactivityKillTimerMaxItemLevelNumber.ReadOnly = true;
                InactivityKillTimerMaxItemLevelNumber.Increment = 0;
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
    }
}
