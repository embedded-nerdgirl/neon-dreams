using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace NeonDreams
{
    internal class ItemManager
    {
        public static Dictionary<uint, Item> RegisteredItems = new();

        public static void LoadItemsFromJSON(string path = "assets/json/items")
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"[ItemManager] Directory not found: {path}");
                return;
            }

            // todo: refactor this ASAP!
            var jsonFiles = Directory.GetFiles(path, "*.json");
            foreach (var file in jsonFiles)
            {
                try
                {
                    string json = File.ReadAllText(file);
                    var itemData = JsonSerializer.Deserialize<ItemJsonSchema>(json);

                    if (itemData != null)
                    {
                        Item? item = CreateItemFromJson(itemData);
                        if (item != null)
                        {
                            RegisteredItems[item.ItemIdentifier] = item;
                            Console.WriteLine($"[ItemManager] Loaded item: {item.ItemName}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ItemManager] Failed to load item from {file}: {ex.Message}");
                }
            }
        }

        private static Item? CreateItemFromJson(ItemJsonSchema data)
        {
            if (!uint.TryParse(data.Id, out uint parsedId))
            {
                Console.WriteLine($"[ItemManager] Invalid ID format for item: {data.Name}");
                return null;
            }

            bool sellable = data.Sellable ?? false;
            uint sellValue = data.Sell_Value ?? 0;
            string assetPath = data.Texture;

            Enum.TryParse(data.Base_Attr, true, out ItemBaseAttributes baseAttr);

            if (data.Damage.HasValue)
            {
                return new Weapon(data.Name, data.Desc, assetPath, parsedId, sellable, sellValue, data.Damage.Value);
            }
            else if (data.Defense.HasValue && data.Equip_Slot != null)
            {
                if (!Enum.TryParse(data.Equip_Slot, true, out ItemBaseAttributes equipSlot))
                {
                    Console.WriteLine($"[ItemManager] Invalid equip slot for armour: {data.Equip_Slot}");
                    return null;
                }

                return new Armour(data.Name, data.Desc, assetPath, parsedId, sellable, sellValue, data.Defense.Value, equipSlot);
            }
            else
            {
                return new Material(data.Name, data.Desc, assetPath, parsedId, sellable, sellValue);
            }
        }

        private class ItemJsonSchema
        {
            public string Id { get; set; } = "";
            public string Name { get; set; } = "";
            public string Desc { get; set; } = "";
            public string Base_Attr { get; set; } = "";
            public bool? Sellable { get; set; }
            public uint? Sell_Value { get; set; }
            public string Texture { get; set; } = "";

            public uint? Damage { get; set; }
            public uint? Defense { get; set; }
            public string? Equip_Slot { get; set; }
        }
    }
}
