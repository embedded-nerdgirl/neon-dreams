

using System.Collections.Generic;

namespace NeonDreams
{
    // Two Is here looks goofy but prefixing interfaces with I is the C# standard so whatevs
    // I wish I knew why this was the case, oh well.
    public interface IIenventory
    {
        void AddItem(Item item);
        void RemoveItem(Item item);
        IReadOnlyList<Item> GetItems();
    }
}