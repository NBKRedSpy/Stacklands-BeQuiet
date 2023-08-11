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

		public void Awake()
		{

			Log = Logger;

			CardListConfig = this.Config.GetEntry<string>("Card List", "dog, old_dog" , new ConfigUI()
			{
				Tooltip = "The comma delimited list of cards to silence"
			});
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
			

		}
	}
}
