using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public Cocktail(string name,int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }
        public void Add(Ingredient ingredient)
        {
            bool isItValid = true;
            foreach (var item in Ingredients)
            {
                if (item.Name == ingredient.Name || Capacity <= Ingredients.Count ||
                    ingredient.Alcohol > MaxAlcoholLevel)
                {
                    isItValid = false;
                    break;
                }
            }
            if (isItValid)
            {
                Ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {
            foreach (var item in Ingredients)
            {
                if (item.Name == name)
                {
                    Ingredients.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredient = null;
            foreach (var item in Ingredients)
            {
                if (item.Name == name)
                {
                    ingredient = item;
                }
            }
            return ingredient;
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            Ingredient ingredient = null ;
            int mostAlcohol = 0;
            foreach (var item in Ingredients)
            {
                if (item.Alcohol > mostAlcohol)
                {
                    mostAlcohol = item.Alcohol;
                    ingredient = item;
                }
            }
            return ingredient;
        }
        public int CurrentAlcoholLevel
        {
            get
            {
                int level = 0;
                foreach (var item in Ingredients)
                {
                    level += item.Alcohol;
                }
                return level;
            }
        }
        public string Report()
        {
            return $"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, Ingredients)}";
        }
    }
}
