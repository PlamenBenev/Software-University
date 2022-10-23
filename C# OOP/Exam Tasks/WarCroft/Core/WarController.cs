using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party = new List<Character>();
		private List<Item> pool = new List<Item>();
		public WarController()
		{
		}

		public string JoinParty(string[] args)
		{
			string charType = args[0];
			string name = args[1];
			Character character = null;
			if (charType == "Warrior")
			{
				character = new Warrior(name);
			}
			else if (charType == "Priest")
			{
				character = new Priest(name);
			}
			else
				throw new ArgumentException($"Invalid character type \"{charType}\"!");

			party.Add(character);
			return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			string type = args[0];
			if (type == "FirePotion")
            {
				pool.Add(new FirePotion());
            }
			else if (type == "HealthPotion")
			{
				pool.Add(new HealthPotion());
			}
			else
            {
				throw new ArgumentException($"Invalid item \"{ type }\"!");
            }
			return $"{type} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			Character character = party.Find(x => x.Name == args[0]);

			if (character == null)
            {
				throw new ArgumentException($"Character {args[0]} not found!");
            }
			if (pool.Count == 0)
            {
				throw new InvalidOperationException("No items left in pool!");
            }
			Item item = pool[pool.Count - 1];
			character.Bag.AddItem(item);
			pool.Remove(item);
			return $"{args[0]} picked up {item.GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			Character member = party.First(x => x.Name == args[0]);
			if (member == null)
            {
				throw new ArgumentException($"Character {args[0]} not found!");

			}
			//member.Bag.GetItem(args[1]);
			Item item = member.Bag.GetItem(args[1]);
			member.UseItem(item);
			return $"{args[0]} used {args[1]}.";
		}

		public string GetStats()
		{
			var sorted = party.OrderByDescending(x => x.IsAlive)
				.ThenByDescending(x => x.Health).ToList();

			string returner = "";
            foreach (var item in sorted)
            {
				string deadOrAlive = "Dead";
				if (item.IsAlive)
                {
					deadOrAlive = "Alive";
                }
				returner += 
					$"{item.Name} - HP: {item.Health}/{item.BaseHealth}, AP: {item.Armor}/{item.BaseArmor}, Status: {deadOrAlive}{Environment.NewLine}";

			}
			return returner;
		}

		public string Attack(string[] args)
		{
			Warrior attacker = (Warrior)party.Find(x => x.Name == args[0]);
			Character reciever = party.Find(x => x.Name == args[1]);

			if (attacker == null)
            {
				throw new ArgumentException($"Character {args[0]} not found!");
            }
			if (reciever == null)
			{
				throw new ArgumentException($"Character {args[1]} not found!");
			}
			if (!attacker.IsAlive || !reciever.IsAlive)
            {
				throw new ArgumentException($"{attacker.Name} cannot attack!");
            }
			attacker.Attack(reciever);
			string returner = 
				$"{attacker.Name} attacks {reciever.Name} for {attacker.AbilityPoints} hit points! {reciever.Name} has {reciever.Health}/{reciever.BaseHealth} HP and {reciever.Armor}/{reciever.BaseArmor} AP left!";
			if (!reciever.IsAlive)
            {
				returner += $"{reciever.Name} is dead!";
			}
			return returner;
		}

		public string Heal(string[] args)
		{
			Priest healer = (Priest)party.First(x => x.Name == args[0]);
			Character reciever = party.First(x => x.Name == args[1]);

			if (healer == null)
			{
				throw new ArgumentException($"Character {args[0]} not found!");
			}
			if (reciever == null)
			{
				throw new ArgumentException($"Character {args[1]} not found!");
			}
			if (!healer.IsAlive || !reciever.IsAlive)
            {
				throw new ArgumentException($"{args[0]} cannot heal!");
            }
			healer.Heal(reciever);
			return $"{healer.Name} heals {reciever.Name} for {healer.AbilityPoints}! {reciever.Name} has {reciever.Health} health now!";
		}
	}
}
