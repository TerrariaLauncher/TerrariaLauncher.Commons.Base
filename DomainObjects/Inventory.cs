using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaLauncher.Commons.DomainObjects
{
    public class Inventory
    {
        #region Internal Constants
        public const int HotBarSlots = 10;
        public const int MainInventorySlots = 40;
        public const int CoinSlots = 4;
        public const int AmmoSlots = 4;

        public const int CursorSlots = 1;

        public const int ArmorSlots = 3;
        public const int AccessorySlots = 7;

        public const int VanityArmorSlots = 3;
        public const int VanityAccessorySlots = 7;

        public const int ArmorDyeSlots = 3;
        public const int AccessoryDyeSlots = 7;

        public const int EquipmentSlots = 5;
        public const int EquipmentDyeSlots = 5;

        public const int PiggyBankSlots = 40;
        public const int SafeSlots = 40;

        public const int TrashSlots = 1;

        public const int DefenderForgeSlots = 40;
        public const int VoidVaultSlots = 40;

        public const int TotalSlots =
            HotBarSlots + MainInventorySlots + CoinSlots + AmmoSlots + CursorSlots +
            ArmorSlots + AccessorySlots + VanityArmorSlots + VanityAccessorySlots +
            ArmorDyeSlots + AccessoryDyeSlots +
            EquipmentSlots +
            EquipmentDyeSlots +
            PiggyBankSlots +
            SafeSlots +
            TrashSlots +
            DefenderForgeSlots +
            VoidVaultSlots;

        // The order of these index segments follow the order of TSPlayer.inventory array (the same as the order of slot in slot event).
        public static readonly (int Start, int ExclusiveEnd) HotBarIndex = (0, HotBarSlots);
        public static readonly (int Start, int ExclusiveEnd) MainInventoryIndex = (HotBarIndex.ExclusiveEnd, HotBarIndex.ExclusiveEnd + MainInventorySlots);
        public static readonly (int Start, int ExclusiveEnd) CoinIndex = (MainInventoryIndex.ExclusiveEnd, MainInventoryIndex.ExclusiveEnd + CoinSlots);
        public static readonly (int Start, int ExclusiveEnd) AmmoIndex = (CoinIndex.ExclusiveEnd, CoinIndex.ExclusiveEnd + AmmoSlots);

        public static readonly (int Start, int ExclusiveEnd) CursorIndex = (AmmoIndex.ExclusiveEnd, AmmoIndex.ExclusiveEnd + CursorSlots);

        public static readonly (int Start, int ExclusiveEnd) ArmorIndex = (CursorIndex.ExclusiveEnd, CursorIndex.ExclusiveEnd + ArmorSlots);
        public static readonly (int Start, int ExclusiveEnd) AccessoryIndex = (ArmorIndex.ExclusiveEnd, ArmorIndex.ExclusiveEnd + AccessorySlots);

        public static readonly (int Start, int ExclusiveEnd) VanityArmorIndex = (AccessoryIndex.ExclusiveEnd, AccessoryIndex.ExclusiveEnd + VanityArmorSlots);
        public static readonly (int Start, int ExclusiveEnd) VanityAccessoryIndex = (VanityArmorIndex.ExclusiveEnd, VanityArmorIndex.ExclusiveEnd + VanityAccessorySlots);

        public static readonly (int Start, int ExclusiveEnd) ArmorDyeIndex = (VanityAccessoryIndex.ExclusiveEnd, VanityAccessoryIndex.ExclusiveEnd + ArmorDyeSlots);
        public static readonly (int Start, int ExclusiveEnd) AccessoryDyeIndex = (ArmorDyeIndex.ExclusiveEnd, ArmorDyeIndex.ExclusiveEnd + AccessoryDyeSlots);

        public static readonly (int Start, int ExclusiveEnd) EquipmentIndex = (AccessoryDyeIndex.ExclusiveEnd, AccessoryDyeIndex.ExclusiveEnd + EquipmentSlots);
        public static readonly (int Start, int ExclusiveEnd) EquipmentDyeIndex = (EquipmentIndex.ExclusiveEnd, EquipmentIndex.ExclusiveEnd + EquipmentDyeSlots);

        public static readonly (int Start, int ExclusiveEnd) PiggyBankIndex = (EquipmentDyeIndex.ExclusiveEnd, EquipmentDyeIndex.ExclusiveEnd + PiggyBankSlots);
        public static readonly (int Start, int ExclusiveEnd) SafeIndex = (PiggyBankIndex.ExclusiveEnd, PiggyBankIndex.ExclusiveEnd + SafeSlots);

        public static readonly (int Start, int ExclusiveEnd) TrashIndex = (SafeIndex.ExclusiveEnd, SafeIndex.ExclusiveEnd + TrashSlots);

        public static readonly (int Start, int ExclusiveEnd) DefenderForgeIndex = (TrashIndex.ExclusiveEnd, TrashIndex.ExclusiveEnd + DefenderForgeSlots);
        public static readonly (int Start, int ExclusiveEnd) VoidVaultIndex = (DefenderForgeIndex.ExclusiveEnd, DefenderForgeIndex.ExclusiveEnd + VoidVaultSlots);
        #endregion

        #region Indices for manipulate Terraria data structures
        // The meaning of (ArraySlots = PartXSlots + PartYSlots + ...) is prepresent the structure of each items array in Terraria.

        // Length of "TPlayer.inventory" array: 59
        public const int TerrariaInventorySlots = HotBarSlots + MainInventorySlots + CoinSlots + AmmoSlots + CursorSlots;
        // Length of "TPlayer.armor" array: 20
        public const int TerrariaArmorSlots = ArmorSlots + AccessorySlots + VanityArmorSlots + VanityAccessorySlots;
        // Length of "TPlayer.dye" array: 10
        public const int TerrariaDyeSlots = ArmorDyeSlots + AccessoryDyeSlots;
        // Length of "TPlayer.miscEquip" array: 5
        public const int TerrariaEquipmentSlots = EquipmentSlots;
        // Length of "TPlayer.miscDye" array: 5
        public const int TerrariaEquipmentDyeSlots = EquipmentDyeSlots;

        // Length of "TPlayer.bank1.item" array: 40
        public const int TerrariaPiggyBankSlots = PiggyBankSlots;
        // Length of "TPlayer.bank2.item" array: 40
        public const int TerrariaSafeSlots = SafeSlots;
        // Length of "TPlayer.bank3.item" array: 40
        public const int TerrariaDefenderForge = DefenderForgeSlots;
        // Length of "TPlayer.bank4.item" array: 40
        public const int TerrariaVoidVaultSlots = VoidVaultSlots;

        // Trash item is stored in "TPlayer.trashItem" field.
        // Cursor item is not only stored in "TPlayer.inventory", but also stored in "TPlayer.HeldItem" property.

        // Index segments in "TPlayer.inventory" array.
        public static readonly (int Start, int ExclusiveEnd) TerrariaHotBarIndex = (0, HotBarSlots);
        public static readonly (int Start, int ExclusiveEnd) TerrariaMainInventoryIndex = (TerrariaHotBarIndex.ExclusiveEnd, TerrariaHotBarIndex.ExclusiveEnd + MainInventorySlots);
        public static readonly (int Start, int ExclusiveEnd) TerrariaCoinIndex = (TerrariaMainInventoryIndex.ExclusiveEnd, TerrariaMainInventoryIndex.ExclusiveEnd + CoinSlots);
        public static readonly (int Start, int ExclusiveEnd) TerrariaAmmoIndex = (TerrariaCoinIndex.ExclusiveEnd, TerrariaCoinIndex.ExclusiveEnd + AmmoSlots);
        public static readonly (int Start, int ExclusiveEnd) TerrariaCursorIndex = (TerrariaAmmoIndex.ExclusiveEnd, TerrariaAmmoIndex.ExclusiveEnd + CursorSlots);

        // Index segments in "TPlayer.armor" array.
        public static readonly (int Start, int ExclusiveEnd) TerrariaArmorIndex = (0, ArmorSlots);
        public static readonly (int Start, int ExclusiveEnd) TerrariaAccessoryIndex = (TerrariaArmorIndex.ExclusiveEnd, TerrariaArmorIndex.ExclusiveEnd + AccessorySlots);
        public static readonly (int Start, int ExclusiveEnd) TerrariaVanityArmorIndex = (TerrariaAccessoryIndex.ExclusiveEnd, TerrariaAccessoryIndex.ExclusiveEnd + VanityArmorSlots);
        public static readonly (int Start, int ExclusiveEnd) TerrariaVanityAccessoryIndex = (TerrariaVanityArmorIndex.ExclusiveEnd, TerrariaVanityArmorIndex.ExclusiveEnd + VanityAccessorySlots);
        // Index segments in "TPlayer.dye" array.
        public static readonly (int Start, int ExclusiveEnd) TerrariaArmorDyeIndex = (0, ArmorDyeSlots);
        public static readonly (int Start, int ExclusiveEnd) TerrariaAccessoryDyeIndex = (TerrariaArmorDyeIndex.ExclusiveEnd, TerrariaArmorDyeIndex.ExclusiveEnd + AccessoryDyeSlots);

        // Index segments in "TPlayer.miscEquip" array.
        public static readonly (int Start, int ExclusiveEnd) TerrariaEquipmentIndex = (0, EquipmentSlots);
        // Index segments in "TPlayer.miscDye" array.
        public static readonly (int Start, int ExclusiveEnd) TerrariaEquipmentDyeIndex = (0, EquipmentDyeSlots);

        // Index segments in "TPlayer.bank1" array.
        public static readonly (int Start, int ExclusiveEnd) TerrariaPiggyBankIndex = (0, PiggyBankSlots);
        // Index segments in "TPlayer.bank2" array.
        public static readonly (int Start, int ExclusiveEnd) TerrariaSafeIndex = (0, SafeSlots);
        // Index segments in "TPlayer.bank3" array.
        public static readonly (int Start, int ExclusiveEnd) TerrariaDefenderForgeIndex = (0, DefenderForgeSlots);
        // Index segments in "TPlayer.bank4" array.
        public static readonly (int Start, int ExclusiveEnd) TerrariaVoidVaultIndex = (0, VoidVaultSlots);
        #endregion

        public readonly Item[] All;

        public readonly ArraySegment<Item> HotBar;
        public readonly ArraySegment<Item> MainInventory;
        public readonly ArraySegment<Item> Coins;
        public readonly ArraySegment<Item> Ammo;

        public ArraySegment<Item> Cursor;

        public readonly ArraySegment<Item> Armor;
        public readonly ArraySegment<Item> Accessories;

        public readonly ArraySegment<Item> VanityArmor;
        public readonly ArraySegment<Item> VanityAccessories;

        public readonly ArraySegment<Item> ArmorDye;
        public readonly ArraySegment<Item> AccessoryDye;

        public readonly ArraySegment<Item> Equipment;
        public readonly ArraySegment<Item> EquipmentDye;

        public readonly ArraySegment<Item> PiggyBank;
        public readonly ArraySegment<Item> Safe;

        public ArraySegment<Item> Trash;

        public readonly ArraySegment<Item> DefenderForge;
        public readonly ArraySegment<Item> VoidVault;

        public Inventory()
        {
            this.All = new Item[TotalSlots];

            this.HotBar = new ArraySegment<Item>(this.All, HotBarIndex.Start, HotBarSlots);
            this.MainInventory = new ArraySegment<Item>(this.All, MainInventoryIndex.Start, MainInventorySlots);
            this.Coins = new ArraySegment<Item>(this.All, CoinIndex.Start, CoinSlots);
            this.Ammo = new ArraySegment<Item>(this.All, AmmoIndex.Start, AmmoSlots);

            this.Cursor = new ArraySegment<Item>(this.All, CursorIndex.Start, CursorSlots);

            this.Armor = new ArraySegment<Item>(this.All, ArmorIndex.Start, ArmorSlots);
            this.Accessories = new ArraySegment<Item>(this.All, AccessoryIndex.Start, AccessorySlots);

            this.VanityArmor = new ArraySegment<Item>(this.All, VanityArmorIndex.Start, VanityArmorSlots);
            this.VanityAccessories = new ArraySegment<Item>(this.All, VanityAccessoryIndex.Start, VanityAccessorySlots);

            this.ArmorDye = new ArraySegment<Item>(this.All, ArmorDyeIndex.Start, ArmorDyeSlots);
            this.AccessoryDye = new ArraySegment<Item>(this.All, AccessoryDyeIndex.Start, AccessoryDyeSlots);

            this.Equipment = new ArraySegment<Item>(this.All, EquipmentIndex.Start, EquipmentSlots);
            this.EquipmentDye = new ArraySegment<Item>(this.All, EquipmentDyeIndex.Start, EquipmentDyeSlots);

            this.PiggyBank = new ArraySegment<Item>(this.All, PiggyBankIndex.Start, PiggyBankSlots);
            this.Safe = new ArraySegment<Item>(this.All, SafeIndex.Start, SafeSlots);

            this.Trash = new ArraySegment<Item>(this.All, TrashIndex.Start, TrashSlots);

            this.DefenderForge = new ArraySegment<Item>(this.All, DefenderForgeIndex.Start, DefenderForgeSlots);
            this.VoidVault = new ArraySegment<Item>(this.All, VoidVaultIndex.Start, VoidVaultSlots);
        }
    }
}
