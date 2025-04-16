using System;
using System.IO;
using Raylib_cs;
using MoonSharp.Interpreter;
using System.Text.Json;

// Both items and currencies are defined in this file
// As well as the item manager system
//

// Notice '04-16-2025':
//
// I'm rewriting the entire item system to be a lot more modular and user friendly.
// As of the date above, the items are going to be written in a way that puts an
// emphasis on the ease of deserializing from ./assets/items/[ID].json and into
// some item manager such that any and all items can be created, removed, modified
// and manipulated as needed by the game, and by the future developer console (spoilers)
//
// This also means that the existing JSON schemas of items and its subclasses
// are at risk of being modified and rendered different, so expect more changes
// across the entire source tree, especially in the root/lua_tools/*.lua files.

// Items should always have unsigned where possible, negative numbers leads
// to weirdness!

namespace NeonDreams
{
    public enum WeaponDamageTypes
    {
        STANDARD,   // 0
        MAGIC,      // 1
    }

    public enum ArmourEquipSlots
    {
        HEAD,       // 0
        CHEST,      // 1
        LEGS,       // 2
    }

    public abstract class ItemBase
    {
        internal string? ItemName;
        internal string? ItemDescription;
        internal string ItemSpritePath;
        internal byte ItemMaxStack = 99;
        internal byte ItemCurrentStack = 1;
        internal bool ItemSellable = true;
        internal ushort ItemSellValue = 0;

        public ItemBase(string? iname, string? idesc, string isppath, byte imaxstck, bool isell, ushort isellval)
        {
            if (!File.Exists(isppath))
                ItemSpritePath = "assets/sprites/default.png";
            else
                ItemSpritePath = isppath;
            
            ItemName = iname;
            ItemDescription = idesc;
            ItemMaxStack = imaxstck;
            ItemSellable = isell;
            ItemSellValue = isellval;
            ItemCurrentStack = 1;
        }
    }

    public class Weapon : ItemBase
    {
        internal ushort WeaponDamage = 1;
        internal byte WeaponDamageType = 0;

        // I love incredibly long constructors like these
        public Weapon(string? wname, string? wdesc, string wsppath, byte wmaxstck, bool isell, ushort wsellval, ushort wdamage, byte wdtype)
            : base(wname, wdesc, wsppath, wmaxstck, isell, wsellval)
        {
            Assertion.That((wdtype > 2 && wdamage > 0 && wsellval > 0), "WeaponDamageType assertion failure!");
        }
    }

    public class Armour : ItemBase
    {
        internal byte ArmourEquipSlot = 0;
        internal ushort ArmourDefense = 0;

        public Armour(string? aname, string? adesc, string asppath, byte amaxstck, bool isell, ushort asellval, ushort adefense, byte aeslt)
            : base(aname, adesc, asppath, amaxstck, isell, asellval)
        {
            Assertion.That( ((aeslt < 3) && (adefense > 0) && (asellval > 0)), "Armour data assertion failure!" );
        }
    }
}