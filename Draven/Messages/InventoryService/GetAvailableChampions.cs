﻿using Draven.Structures;

using RtmpSharp.IO.AMF3;
using RtmpSharp.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Draven.Messages.InventoryService
{
    using Draven.DatabaseManager;
    using Draven.Structures.Platform.Catalog;

    class GetAvailableChampions : IMessage
    {
        public RemotingMessageReceivedEventArgs HandleMessage(object sender, RemotingMessageReceivedEventArgs e)
        {
            ArrayCollection champions = new ArrayCollection();

            List<DatabaseManager.DBChampions> ChampionDatas = DatabaseManager.getAllChampions();

            foreach (var champ in ChampionDatas)
            {
                var champDTO = new ChampionDTO
                {
                    Owned = true,
                    ChampionID = champ.ID,
                    Active = true,
                    BotEnabled = false,
                    Banned = false,
                    Chromas = "",
                    Description = "",
                    DisplayName = "",
                    ChampionData = null,
                    FreeToPlayReward = true,
                    OwnedByYourTeam = true,
                    OwnedByEnemyTeam = true,
                    DefaultSkin = "",
                    FreeToPlay = true,
                };

                champDTO.ChampionSkins = new ArrayCollection();

                List<int> ChampionSkinDatas = DatabaseManager.getAllChampionSkinsForId(champ.ID);

                foreach(var skin in ChampionSkinDatas)
                {
                    var champSkinData = new ChampionSkinDTO
                    {
                        ChampionID = champ.ID,
                        SkinID = skin,
                        StillObtainable = true,
                        Owned = true
                    };

                    champDTO.ChampionSkins.Add(champSkinData);
                }

                champions.Add(champDTO);
            }

            //champions.Add(new Dictionary<string, int>());

            e.ReturnRequired = true;
            e.Data = champions;

            return e;
        }
    }
}
