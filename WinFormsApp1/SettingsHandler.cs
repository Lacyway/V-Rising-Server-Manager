using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager
{

    public class EmptyJSON
    {

    }

    public class CastleStatModifiersGlobal
    {
        public double TickPeriod { get; set; } = 5.0;
        public double DamageResistance { get; set; } = 0.0;
        public int SafetyBoxLimit { get; set; } = 1;
        public int TombLimit { get; set; } = 12;
        public int VerminNestLimit { get; set; } = 4;
        public PylonPenalties? PylonPenalties { get; set; }
        public FloorPenalties? FloorPenalties { get; set; }
        public HeartLimits? HeartLimits { get; set; }
        public int CastleLimit { get; set; } = 2;
    }

    public class EquipmentStatModifiersGlobal
    {
        public double MaxEnergyModifier { get; set; } = 1.0;
        public double MaxHealthModifier { get; set; } = 1.0;
        public double ResourceYieldModifier { get; set; } = 1.0;
        public double PhysicalPowerModifier { get; set; } = 1.0;
        public double SpellPowerModifier { get; set; } = 1.0;
        public double SiegePowerModifier { get; set; } = 1.0;
        public double MovementSpeedModifier { get; set; } = 1.0;
    }

    public class FloorPenalties
    {
        public EmptyJSON? Range1 { get; set; }
        public EmptyJSON? Range2 { get; set; }
        public EmptyJSON? Range3 { get; set; }
        public EmptyJSON? Range4 { get; set; }
        public EmptyJSON? Range5 { get; set; }
    }

    public class GameTimeModifiers
    {
        public double DayDurationInSeconds { get; set; } = 1080.00;
        public int DayStartHour { get; set; } = 9;
        public int DayStartMinute { get; set; } = 0;
        public int DayEndHour { get; set; } = 17;
        public int DayEndMinute { get; set; } = 0;
        public int BloodMoonFrequency_Min { get; set; } = 10;
        public int BloodMoonFrequency_Max { get; set; } = 18;
        public double BloodMoonBuff { get; set; } = 0.2;
    }

    public class HeartLimits
    {
        public Level1? Level1 { get; set; }
        public Level2? Level2 { get; set; }
        public Level3? Level3 { get; set; }
        public Level4? Level4 { get; set; }
    }

    public class Level1
    {
        public int Level { get; set; } = 1;
        public int FloorLimit { get; set; } = 30;
        public int ServantLimit { get; set; } = 3;
    }

    public class Level2
    {
        public int Level { get; set; } = 2;
        public int FloorLimit { get; set; } = 80;
        public int ServantLimit { get; set; } = 5;
    }

    public class Level3
    {
        public int Level { get; set; } = 3;
        public int FloorLimit { get; set; } = 150;
        public int ServantLimit { get; set; } = 7;
    }

    public class Level4
    {
        public int Level { get; set; } = 4;
        public int FloorLimit { get; set; } = 250;
        public int ServantLimit { get; set; } = 9;
    }

    public class PlayerInteractionSettings
    {
        public int TimeZone { get; set; } = 0;
        public VSPlayerWeekdayTime? VSPlayerWeekdayTime { get; set; }
        public VSPlayerWeekendTime? VSPlayerWeekendTime { get; set; }
        public VSCastleWeekdayTime? VSCastleWeekdayTime { get; set; }
        public VSCastleWeekendTime? VSCastleWeekendTime { get; set; }
    }

    public class PylonPenalties
    {
        public EmptyJSON? Range1 { get; set; }
        public EmptyJSON? Range2 { get; set; }
        public EmptyJSON? Range3 { get; set; }
        public EmptyJSON? Range4 { get; set; }
        public EmptyJSON? Range5 { get; set; }
    }

    public class Range1
    {
        public double? Percentage { get; set; }
        public int? Lower { get; set; }
        public int? Higher { get; set; }
    }

    public class Range2
    {
        public double? Percentage { get; set; }
        public int? Lower { get; set; }
        public int? Higher { get; set; }
    }

    public class Range3
    {
        public double? Percentage { get; set; }
        public int? Lower { get; set; }
        public int? Higher { get; set; }
    }

    public class Range4
    {
        public double? Percentage { get; set; }
        public int? Lower { get; set; }
        public int? Higher { get; set; }
    }

    public class Range5
    {
        public double? Percentage { get; set; }
        public int? Lower { get; set; }
        public int? Higher { get; set; }
    }

    public class UnitStatModifiersGlobal
    {
        public double MaxHealthModifier { get; set; } = 1.0;
        public double PowerModifier { get; set; } = 1.0;
    }

    public class UnitStatModifiersVBlood
    {
        public double MaxHealthModifier { get; set; } = 1.0;
        public double PowerModifier { get; set; } = 1.0;
    }

    public class VampireStatModifiers
    {
        public double MaxHealthModifier { get; set; } = 1.0;
        public double MaxEnergyModifier { get; set; } = 1.0;
        public double PhysicalPowerModifier { get; set; } = 1.0;
        public double SpellPowerModifier { get; set; } = 1.0;
        public double ResourcePowerModifier { get; set; } = 1.0;
        public double SiegePowerModifier { get; set; } = 1.0;
        public double DamageReceivedModifier { get; set; } = 1.0;
        public double ReviveCancelDelay { get; set; } = 5.0;
    }

    public class VSCastleWeekdayTime
    {
        public int StartHour { get; set; } = 17;
        public int StartMinute { get; set; } = 0;
        public int EndHour { get; set; } = 23;
        public int EndMinute { get; set; } = 0;
    }

    public class VSCastleWeekendTime
    {
        public int StartHour { get; set; } = 17;
        public int StartMinute { get; set; } = 0;
        public int EndHour { get; set; } = 23;
        public int EndMinute { get; set; } = 0;
    }

    public class VSPlayerWeekdayTime
    {
        public int StartHour { get; set; } = 17;
        public int StartMinute { get; set; } = 0;
        public int EndHour { get; set; } = 23;
        public int EndMinute { get; set; } = 0;
    }

    public class VSPlayerWeekendTime
    {
        public int StartHour { get; set; } = 17;
        public int StartMinute { get; set; } = 0;
        public int EndHour { get; set; } = 23;
        public int EndMinute { get; set; } = 0;
    }

    public class Rcon
    {
        public bool Enabled { get; set; } = false;
        public string Password { get; set; } = "somepassword";
        public int Port { get; set; } = 25575;
    }

    public class GameSettings
    {
        public int GameModeType { get; set; } = 0;
        public int CastleDamageMode { get; set; } = 0;
        public int SiegeWeaponHealth { get; set; } = 2;
        public int PlayerDamageMode { get; set; } = 0;
        public int CastleHeartDamageMode { get; set; } = 0;
        public int PvPProtectionMode { get; set; } = 2;
        public int DeathContainerPermission { get; set; } = 0;
        public int RelicSpawnType { get; set; } = 0;
        public bool CanLootEnemyContainers { get; set; } = true;
        public bool BloodBoundEquipment { get; set; } = true;
        public bool TeleportBoundItems { get; set; } = true;
        public bool AllowGlobalChat { get; set; } = true;
        public bool AllWaypointsUnlocked { get; set; } = false;
        public bool FreeCastleClaim { get; set; } = false;
        public bool FreeCastleDestroy { get; set; } = false;
        public bool InactivityKillEnabled { get; set; } = true;
        public int InactivityKillTimeMin { get; set; } = 3600;
        public int InactivityKillTimeMax { get; set; } = 604800;
        public int InactivityKillSafeTimeAddition { get; set; } = 172800;
        public int InactivityKillTimerMaxItemLevel { get; set; } = 84;
        public bool DisableDisconnectedDeadEnabled { get; set; }
        public int DisableDisconnectedDeadTimer { get; set; } = 60;
        public double InventoryStacksModifier { get; set; } = 1.0;
        public double DropTableModifier_General { get; set; } = 1.0;
        public double DropTableModifier_Missions { get; set; } = 1.0;
        public double MaterialYieldModifier_Global { get; set; } = 1.0;
        public double BloodEssenceYieldModifier { get; set; } = 1.0;
        public double JournalVBloodSourceUnitMaxDistance { get; set; } = 25.0;
        public double PvPVampireRespawnModifier { get; set; } = 1.0;
        public int CastleMinimumDistanceInFloors { get; set; } = 2;
        public int ClanSize { get; set; } = 4;
        public double BloodDrainModifier { get; set; } = 1.0;
        public double DurabilityDrainModifier { get; set; } = 1.0;
        public double GarlicAreaStrengthModifier { get; set; } = 1.0;
        public double HolyAreaStrengthModifier { get; set; } = 1.0;
        public double SilverStrengthModifier { get; set; } = 1.0;
        public double SunDamageModifier { get; set; } = 1.0;
        public double CastleDecayRateModifier { get; set; } = 1.0;
        public double CastleBloodEssenceDrainModifier { get; set; } = 1.0;
        public double CastleSiegeTimer { get; set; } = 420.0;
        public double CastleUnderAttackTimer { get; set; } = 60.0;
        public bool AnnounceSiegeWeaponSpawn { get; set; } = true;
        public bool ShowSiegeWeaponMapIcon { get; set; } = true;
        public double BuildCostModifier { get; set; } = 1.0;
        public double RecipeCostModifier { get; set; } = 1.0;
        public double CraftRateModifier { get; set; } = 1.0;
        public double ResearchCostModifier { get; set; } = 1.0;
        public double RefinementCostModifier { get; set; } = 1.0;
        public double RefinementRateModifier { get; set; } = 1.0;
        public double ResearchTimeModifier { get; set; } = 1.0;
        public double DismantleResourceModifier { get; set; } = 1.0;
        public double ServantConvertRateModifier { get; set; } = 1.0;
        public double RepairCostModifier { get; set; } = 1.0;
        public double Death_DurabilityFactorLoss { get; set; } = 0.25;
        public double Death_DurabilityLossFactorAsResources { get; set; } = 1.0;
        public int? StarterEquipmentId { get; set; }
        public int? StarterResourcesId { get; set; }
        public List<object>? VBloodUnitSettings { get; set; }
        public List<int>? UnlockedAchievements { get; set; }
        public List<int>? UnlockedResearchs { get; set; }
        public GameTimeModifiers? GameTimeModifiers { get; set; }
        public VampireStatModifiers? VampireStatModifiers { get; set; }
        public UnitStatModifiersGlobal? UnitStatModifiers_Global { get; set; }
        public UnitStatModifiersVBlood? UnitStatModifiers_VBlood { get; set; }
        public EquipmentStatModifiersGlobal? EquipmentStatModifiers_Global { get; set; }
        public CastleStatModifiersGlobal? CastleStatModifiers_Global { get; set; }
        public PlayerInteractionSettings? PlayerInteractionSettings { get; set; }
    }

    public class ServerSettings
    {
        public string Name { get; set; } = "V Rising Server";
        public string Description { get; set; } = "";
        public int Port { get; set; } = 9876;
        public int QueryPort { get; set; } = 9877;
        public int MaxConnectedUsers { get; set; } = 40;
        public int MaxConnectedAdmins { get; set; } = 4;
        public int ServerFps { get; set; } = 30;
        public string SaveName { get; set; } = "world1";
        public string Password { get; set; } = "";
        public bool Secure { get; set; } = false;
        public bool ListOnMasterServer { get; set; } = true;
        public int AutoSaveCount { get; set; } = 25;
        public int AutoSaveInterval { get; set; } = 600;
        public string GameSettingsPreset { get; set; } = "";
        public bool AdminOnlyDebugEvents { get; set; } = true;
        public bool DisableDebugEvents { get; set; } = false;
        public Rcon? Rcon { get; set; }
    }


}