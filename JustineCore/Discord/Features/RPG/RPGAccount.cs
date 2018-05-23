﻿using System.Collections.Generic;

namespace JustineCore.Discord.Features.RPG
{
    public class RpgAccount
    {
        public uint Strength { get; set; }
        public uint Dexterity { get; set; }
        public int SlotLimit { get; set; } = 5;
        public List<InventorySlot> InventorySlots { get; set; } = new List<InventorySlot>();
    }
}