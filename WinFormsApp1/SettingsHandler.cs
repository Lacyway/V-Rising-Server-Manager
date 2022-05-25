using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{

    public class EmptyJSON
    {

    }

    public class CastleStatModifiersGlobal
    {
        public double? TickPeriod { get; set; }
        public double? DamageResistance { get; set; }
        public int? SafetyBoxLimit { get; set; }
        public int? TombLimit { get; set; }
        public int? VerminNestLimit { get; set; }
        public PylonPenalties? PylonPenalties { get; set; }
        public FloorPenalties? FloorPenalties { get; set; }
        public HeartLimits? HeartLimits { get; set; }
        public int? CastleLimit { get; set; }
    }

    public class EquipmentStatModifiersGlobal
    {
        public double? MaxEnergyModifier { get; set; }
        public double? MaxHealthModifier { get; set; }
        public double? ResourceYieldModifier { get; set; }
        public double? PhysicalPowerModifier { get; set; }
        public double? SpellPowerModifier { get; set; }
        public double? SiegePowerModifier { get; set; }
        public double? MovementSpeedModifier { get; set; }
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
        public double? DayDurationInSeconds { get; set; }
        public int? DayStartHour { get; set; }
        public int? DayStartMinute { get; set; }
        public int? DayEndHour { get; set; }
        public int? DayEndMinute { get; set; }
        public int? BloodMoonFrequency_Min { get; set; }
        public int? BloodMoonFrequency_Max { get; set; }
        public double? BloodMoonBuff { get; set; }
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
        public int? Level { get; set; }
        public int? FloorLimit { get; set; }
        public int? ServantLimit { get; set; }
    }

    public class Level2
    {
        public int? Level { get; set; }
        public int? FloorLimit { get; set; }
        public int? ServantLimit { get; set; }
    }

    public class Level3
    {
        public int? Level { get; set; }
        public int? FloorLimit { get; set; }
        public int? ServantLimit { get; set; }
    }

    public class Level4
    {
        public int? Level { get; set; }
        public int? FloorLimit { get; set; }
        public int? ServantLimit { get; set; }
    }

    public class PlayerInteractionSettings
    {
        public string? TimeZone { get; set; }
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
        public double? MaxHealthModifier { get; set; }
        public double? PowerModifier { get; set; }
    }

    public class UnitStatModifiersVBlood
    {
        public double? MaxHealthModifier { get; set; }
        public double? PowerModifier { get; set; }
    }

    public class VampireStatModifiers
    {
        public double? MaxHealthModifier { get; set; }
        public double? MaxEnergyModifier { get; set; }
        public double? PhysicalPowerModifier { get; set; }
        public double? SpellPowerModifier { get; set; }
        public double? ResourcePowerModifier { get; set; }
        public double? SiegePowerModifier { get; set; }
        public double? DamageReceivedModifier { get; set; }
        public double? ReviveCancelDelay { get; set; }
    }

    public class VSCastleWeekdayTime
    {
        public int? StartHour { get; set; }
        public int? StartMinute { get; set; }
        public int? EndHour { get; set; }
        public int? EndMinute { get; set; }
    }

    public class VSCastleWeekendTime
    {
        public int? StartHour { get; set; }
        public int? StartMinute { get; set; }
        public int? EndHour { get; set; }
        public int? EndMinute { get; set; }
    }

    public class VSPlayerWeekdayTime
    {
        public int? StartHour { get; set; }
        public int? StartMinute { get; set; }
        public int? EndHour { get; set; }
        public int? EndMinute { get; set; }
    }

    public class VSPlayerWeekendTime
    {
        public int? StartHour { get; set; }
        public int? StartMinute { get; set; }
        public int? EndHour { get; set; }
        public int? EndMinute { get; set; }
    }

    public class RootSettings
    {
        public int? GameModeType { get; set; }
        public int? CastleDamageMode { get; set; }
        public int? SiegeWeaponHealth { get; set; }
        public int? PlayerDamageMode { get; set; }
        public int? CastleHeartDamageMode { get; set; }
        public int? PvPProtectionMode { get; set; }
        public int? DeathContainerPermission { get; set; }
        public int? RelicSpawnType { get; set; }
        public bool CanLootEnemyContainers { get; set; }
        public bool BloodBoundEquipment { get; set; }
        public bool TeleportBoundItems { get; set; }
        public bool AllowGlobalChat { get; set; }
        public bool AllWaypointsUnlocked { get; set; }
        public bool FreeCastleClaim { get; set; }
        public bool FreeCastleDestroy { get; set; }
        public bool InactivityKillEnabled { get; set; }
        public int? InactivityKillTimeMin { get; set; }
        public int? InactivityKillTimeMax { get; set; }
        public int? InactivityKillSafeTimeAddition { get; set; }
        public int? InactivityKillTimerMaxItemLevel { get; set; }
        public bool DisableDisconnectedDeadEnabled { get; set; }
        public int? DisableDisconnectedDeadTimer { get; set; }
        public double? InventoryStacksModifier { get; set; }
        public double? DropTableModifier_General { get; set; }
        public double? DropTableModifier_Missions { get; set; }
        public double? MaterialYieldModifier_Global { get; set; }
        public double? BloodEssenceYieldModifier { get; set; }
        public double? JournalVBloodSourceUnitMaxDistance { get; set; }
        public double? PvPVampireRespawnModifier { get; set; }
        public int? CastleMinimumDistanceInFloors { get; set; }
        public int? ClanSize { get; set; }
        public double? BloodDrainModifier { get; set; }
        public double? DurabilityDrainModifier { get; set; }
        public double? GarlicAreaStrengthModifier { get; set; }
        public double? HolyAreaStrengthModifier { get; set; }
        public double? SilverStrengthModifier { get; set; }
        public double? SunDamageModifier { get; set; }
        public double? CastleDecayRateModifier { get; set; }
        public double? CastleBloodEssenceDrainModifier { get; set; }
        public double? CastleSiegeTimer { get; set; }
        public double? CastleUnderAttackTimer { get; set; }
        public bool AnnounceSiegeWeaponSpawn { get; set; }
        public bool ShowSiegeWeaponMapIcon { get; set; }
        public double? BuildCostModifier { get; set; }
        public double? RecipeCostModifier { get; set; }
        public double? CraftRateModifier { get; set; }
        public double? ResearchCostModifier { get; set; }
        public double? RefinementCostModifier { get; set; }
        public double? RefinementRateModifier { get; set; }
        public double? ResearchTimeModifier { get; set; }
        public double? DismantleResourceModifier { get; set; }
        public double? ServantConvertRateModifier { get; set; }
        public double? RepairCostModifier { get; set; }
        public double? Death_DurabilityFactorLoss { get; set; }
        public double? Death_DurabilityLossFactorAsResources { get; set; }
        public int? StarterEquipmentId { get; set; }
        public int? StarterResourcesId { get; set; }
        public List<object>? VBloodUnitSettings { get; set; }
        public List<object>? UnlockedAchievements { get; set; }
        public List<object>? UnlockedResearchs { get; set; }
        public GameTimeModifiers? GameTimeModifiers { get; set; }
        public VampireStatModifiers? VampireStatModifiers { get; set; }
        public UnitStatModifiersGlobal? UnitStatModifiers_Global { get; set; }
        public UnitStatModifiersVBlood? UnitStatModifiers_VBlood { get; set; }
        public EquipmentStatModifiersGlobal? EquipmentStatModifiers_Global { get; set; }
        public CastleStatModifiersGlobal? CastleStatModifiers_Global { get; set; }
        public PlayerInteractionSettings? PlayerInteractionSettings { get; set; }
    }

}