﻿namespace Draven.Structures.Platform.Summoner
{
    using System;

    using RtmpSharp.IO;
    using RtmpSharp.IO.AMF3;

    [Serializable]
    [SerializedName("com.riotgames.platform.summoner.spellbook.SpellBookPageDTO")]
    public class SpellBookPageDTO
    {
        [SerializedName("entries")]
        public ArrayCollection SlotEntries { get; set; }
        [SerializedName("summonerId")]
        public Double SummonerId { get; set; }
        [SerializedName("createDate")]
        public DateTime CreateDate { get; set; }
        [SerializedName("name")]
        public String Name { get; set; }
        [SerializedName("pageId")]
        public Double PageId { get; set; }
        [SerializedName("current")]
        public Boolean Current { get; set; }
    }
}
