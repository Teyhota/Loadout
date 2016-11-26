﻿using System;
using Rocket.API;
using Rocket.Unturned.Player;
using System.Collections.Generic;
using SDG.Unturned;
using Rocket.Unturned.Chat;

namespace Loadout
{
	public class commandLoad : IRocketCommand
	{
		public AllowedCaller AllowedCaller
		{
			get { return AllowedCaller.Player; }
		}

		public string Name
		{
			get { return "loadkit"; }
		}

		public string Help
		{
			get { return "This command will load your saved gear, you can save your gear by typing /savekit"; }
		}

		public string Syntax
		{
			get { return ""; }
		}

		public List<string> Aliases
		{
			get { return new List<string>(); }
		}

		public void Execute(IRocketPlayer caller, string[] command)
		{
			UnturnedPlayer player = (UnturnedPlayer)caller;
			//LOADING PLAYERS INVENTORY :3
			//LOADING / GIVING CLOTHES :3
			PlayerClothing clo = player.Player.clothing;
			LoadoutClothes clothes = Loadout.instance.inventories[player.CSteamID].clothes;

			LoadoutHat hat = clothes.hat;
			LoadoutMask mask = clothes.mask;
			LoadoutShirt shirt = clothes.shirt;
			LoadoutVest vest = clothes.vest;
			LoadoutBackpack backpack = clothes.backpack;
			LoadoutPants pants = clothes.pants;

			if (hat != null) clo.askWearHat(hat.id, hat.quality, hat.state, true);
			if (mask != null) clo.askWearMask(mask.id, mask.quality, mask.state, true);
			if (shirt != null) clo.askWearShirt(shirt.id, shirt.quality, shirt.state, true);
			if (vest != null) clo.askWearVest(vest.id, vest.quality, vest.state, true);
			if (backpack != null) clo.askWearBackpack(backpack.id, backpack.quality, backpack.state, true);
			if (pants != null) clo.askWearPants(pants.id, pants.quality, pants.state, true);
			//END

			//LOADING / GIVING ITEMS :3
			foreach (ushort id in Loadout.instance.inventories[player.CSteamID].items)
			{
				player.GiveItem(new Item(id, true));
			}
			//END
			//END
			UnturnedChat.Say(player, "Your kit loaded suffescully!");
		}

		public List<string> Permissions
		{
			get
			{
				return new List<string>
				{
					"loadout.use"
				};

			}
		}
	}
}