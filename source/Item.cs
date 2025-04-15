using System;
using Raylib_cs;
using MoonSharp.Interpreter;
using System.Text.Json;

// Both items and currencies are defined in this file
// As well as the item manager system
//

namespace NeonDreams
{
    // From the base Item class all ingame item types are derived and implemented
    public enum ItemTypes
    {
        ITEM_WEAPON,
        ITEM_MATERIAL,
        ITEM_CURRENCY,
        ITEM_WEARABLE,
    }

    // This gets a tad more granular with descriptions before getting into type-specific JSON
    public enum ItemBaseAttributes
    {
        WEARABLE_HEAD,
        WEARABLE_CHEST,
        WEARABLE_LEGS,
        WEAPON_MELEE,
        WEAPON_MAGIC,
        IS_SELLABLE,
        IS_UNSELLABLE, 
    }

    public abstract class Item
    {
        // Base item data, exists on every item that exists
        internal string? ItemName { get; set; }
        internal string? ItemDesc { get; set; }
        internal uint ItemIdentifier { get; set; }

        public Item(string? name, string? desc, uint id)
        {
            ItemName = name;
            ItemDesc = desc;
            ItemIdentifier = id;

            if (ItemName == null)
                ItemName = "ITEM";
            if (ItemDesc == null)
                ItemDesc = "This item does not have a description.";
        }
    }

    public class Weapon : Item
    {
        public Weapon(string? name, string? desc, uint id) : base(name, desc, id)
        {

        }
    }

    public class Armour : Item
    {
        public Armour(string? name, string? desc, uint id) : base(name, desc, id)
        {
            
        }
    }

    public class Material : Item
    {
        public Material(string? name, string? desc, uint id) : base(name, desc, id)
        {
            
        }
    }

    // This is a strange one, maybe currency should be handled differently...
    // todo: maybe not do this?
    public class Coin : Item
    {
        public Coin(string? name, string? desc, uint id) : base(name, desc, id)
        {
            
        }
    }

    // Now this mess can stay quiet and untouched until the item schemas are intact, ready, and finalized
    internal class ItemManager
    {

    }
}