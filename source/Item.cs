using System;
using Raylib_cs;
using MoonSharp.Interpreter;
using System.Text.Json;

// Both items and currencies are defined in this file
// As well as the item manager system
//

namespace NeonDreams
{
    // Turns out we can remove this enum since the classes handle the weapon types better. 

    // This gets a tad more granular with descriptions before getting into type-specific JSON
    // Items can have more than one base attribute, but things will get weird if there are conflicts
    public enum ItemBaseAttributes
    {
        WEARABLE_HEAD,      // 0
        WEARABLE_CHEST,     // 1
        WEARABLE_LEGS,      // 2
        WEAPON_MELEE,       // 3
        WEAPON_MAGIC,       // 4
        IS_SELLABLE,        // 5
        IS_UNSELLABLE,      // 6
    }

    public abstract class Item
    {
        // Base item data, exists on every item that exists
        internal string? ItemName { get; set; }
        internal string? ItemDesc { get; set; }
        internal string ItemAssetPath { get; set; }
        internal uint ItemIdentifier { get; set; }
        internal bool ItemSellable { get; set; }
        internal uint ItemSellValue { get; set; }

        public Item(string? name, string? desc, string assetPath, uint id, bool sellable, uint value)
        {
            ItemName = name;
            ItemDesc = desc;
            ItemAssetPath = assetPath;
            ItemIdentifier = id;
            ItemSellable = sellable;
            ItemSellValue = value;
        }
    }

    public class Weapon : Item
    {
        public uint WeaponDamage { get; private set; }

        public Weapon(string? name, string? desc, string assetPath, uint id, bool sellable, uint value, uint damage)
            : base(name, desc, assetPath, id, sellable, value)
        {
            WeaponDamage = damage;
        }
    }

    public class Armour : Item
    {
        public uint ArmourDefense { get; private set; }
        public ItemBaseAttributes ArmourEquipSlot { get; private set; }

        public Armour(string? name, string? desc, string assetPath, uint id, bool sellable, uint value, uint defense, ItemBaseAttributes equipSlot)
            : base(name, desc, assetPath, id, sellable, value)
        {
            ArmourDefense = defense;
            ArmourEquipSlot = equipSlot;
        }
    }


    public class Material : Item
    {
        public Material(string? name, string? desc, string assetPath, uint id, bool sellable, uint value) 
            : base(name, desc, assetPath, id, sellable, value)
        {
            
        }
    }

    // Currency is handled in `currency.cs` now
    // And the item manager in ItemMgr.cs
}