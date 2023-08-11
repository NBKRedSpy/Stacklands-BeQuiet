using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Web;
using HarmonyLib;

namespace Stacklands_BeQuiet
{
	public class Plugin : Mod
	{
		public static ModLogger Log;

		public static ConfigEntry<string> CardListConfig;

		public static ConfigEntry<bool> MuteDustBinSpecialSounds;

		public static ConfigEntry<bool> MuteDustBinCardDestroy;


		public void Awake()
		{

			Log = Logger;

			CardListConfig = this.Config.GetEntry<string>("Card List", "dog,old_dog,cat,old_cat" , new ConfigUI()
			{
				Tooltip = "The comma delimited list of cards to silence"
			});

			CardListConfig.UI.RestartAfterChange = true;

			MuteDustBinSpecialSounds = this.Config.GetEntry<bool>("Mute dustbin", false, new ConfigUI()
			{
				Tooltip = "If enabled, the dustbin will not make a sound when cards are destroyed.  This is a louder sound."
			});

			MuteDustBinSpecialSounds.UI.RestartAfterChange = true;

			MuteDustBinCardDestroy = this.Config.GetEntry<bool>("Mute dustbin card destroy", false, new ConfigUI()
			{
				Tooltip = "If enabled, will prevent the card destroyed by a dustbin from making a sound.  This is a quiet tick."
			});

			MuteDustBinCardDestroy.UI.RestartAfterChange = true;

			Harmony.PatchAll();


		}

		public override void Ready()
		{
			List<string> cards = Plugin.CardListConfig.Value
				.Split(",", StringSplitOptions.RemoveEmptyEntries)
				.Select(x => x.Trim())
				.ToList();

			List<CardData> foundCardDataList = WorldManager.instance?.CardDataPrefabs.Join(cards, x => x.Id, x => x, (outer, inner) => outer)
			   .ToList();

			Plugin.Log.Log($"{foundCardDataList.Count} cards found.  Matches: '{String.Join(",", foundCardDataList.Select(x => x.Id))}'");

			foreach (var item in foundCardDataList)
			{
				item.PickupSound = null;
			}

			if(MuteDustBinSpecialSounds.Value)
			{
				TrashCan dustBinCard = (TrashCan) WorldManager.instance?.CardDataPrefabs
					.Where(x => x is TrashCan).SingleOrDefault();


				if(dustBinCard != null)
				{
					dustBinCard.DestroySounds = new List<UnityEngine.AudioClip>();
				}
			}
		}
	}
}
