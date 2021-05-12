using System;
using System.Collections.Generic;
using System.Text;

namespace TerrariaLauncher.Commons.DomainObjects
{
    public class Slot
    {
        public enum SlotType
        {
            Air,
            HotBar,
            MainInventory,
            Coin,
            Ammo,
            Cursor,
            Armor,
            Accessory,
            VanityArmor,
            VanityAccessory,
            ArmorDye,
            AccessoryDye,
            Equipment,
            EquipmentDye,
            PiggyBank,
            Safe,
            Trash,
            DefenderForge,
            VoidVault
        }

        private int id;
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                if (this.id >= Inventory.HotBarIndex.Start && this.id < Inventory.HotBarIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.HotBar;
                }
                else if (this.id >= Inventory.MainInventoryIndex.Start && this.id < Inventory.MainInventoryIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.MainInventory;
                }
                else if (this.id >= Inventory.CoinIndex.Start && this.id < Inventory.CoinIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.Coin;
                }
                else if (this.id >= Inventory.AmmoIndex.Start && this.id < Inventory.AmmoIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.Ammo;
                }
                else if (this.id >= Inventory.CursorIndex.Start && this.id < Inventory.CursorIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.Cursor;
                }
                else if (this.id >= Inventory.ArmorIndex.Start && this.id < Inventory.ArmorIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.Armor;
                }
                else if (this.id >= Inventory.AccessoryIndex.Start && this.id < Inventory.AccessoryIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.Accessory;
                }
                else if (this.id >= Inventory.VanityArmorIndex.Start && this.id < Inventory.VanityArmorIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.VanityArmor;
                }
                else if (this.id >= Inventory.VanityAccessoryIndex.Start && this.id < Inventory.VanityAccessoryIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.VanityAccessory;
                }
                else if (this.id >= Inventory.ArmorDyeIndex.Start && this.id < Inventory.ArmorDyeIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.ArmorDye;
                }
                else if (this.id >= Inventory.AccessoryDyeIndex.Start && this.id < Inventory.AccessoryDyeIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.AccessoryDye;
                }
                else if (this.id >= Inventory.EquipmentIndex.Start && this.id < Inventory.EquipmentIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.Equipment;
                }
                else if (this.id >= Inventory.EquipmentDyeIndex.Start && this.id < Inventory.EquipmentDyeIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.EquipmentDye;
                }
                else if (this.id >= Inventory.PiggyBankIndex.Start && this.id < Inventory.PiggyBankIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.PiggyBank;
                }
                else if (this.id >= Inventory.SafeIndex.Start && this.id < Inventory.SafeIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.Safe;
                }
                else if (this.id >= Inventory.TrashIndex.Start && this.id < Inventory.TrashIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.Trash;
                }
                else if (this.id >= Inventory.DefenderForgeIndex.Start && this.id < Inventory.DefenderForgeIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.DefenderForge;
                }
                else if (this.id >= Inventory.VoidVaultIndex.Start && this.id < Inventory.VoidVaultIndex.ExclusiveEnd)
                {
                    this.Type = SlotType.VoidVault;
                }
                else
                {
                    this.Type = SlotType.Air;
                }
            }
        }

        public Item Item { get; set; }

        public SlotType Type { get; private set; }
    }
}
