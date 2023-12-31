﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Web;
using HarmonyLib;
using UnityEngine;

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
				//Search for multiple in case a mod adds a class derived from TrashCan
				List<TrashCan> dustBinCards = WorldManager.instance?.CardDataPrefabs
					.Where(x => x is TrashCan)
					.Cast<TrashCan>()
					.ToList();

				var emptyAudioClip = AudioClip.Create("BeQuiet_Empty", 1, 1, 44000, false);
				emptyAudioClip.SetData(new float[] { 0f }, 0);

				foreach (var dustbinCard in dustBinCards)
				{
					//The game's audio player expects there to always be at least one audio clip.
					//	create and add an empty one.

					dustbinCard.DestroySounds = new List<UnityEngine.AudioClip>()
					{
						emptyAudioClip
					};

				}
			}
		}
	}
}
