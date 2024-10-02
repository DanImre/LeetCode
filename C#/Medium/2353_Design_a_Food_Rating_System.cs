using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium
{
    public class Medium_2353
    {
        public Medium_2353()
        {

        }

        public class Food : IComparable<Food>
        {
            public Food(int rating, string name)
            {
                Rating = rating;
                Name = name;
            }

            public int Rating { get; set; }
            public string Name { get; set; }

            public int CompareTo(Food? other)
            {
                if (other == null)
                    throw new ArgumentException();

                if (Rating == other.Rating)
                    return Name.CompareTo(other.Name);

                return -1 * Rating.CompareTo(other.Rating);
            }
        }

        public class FoodRatings
        {
            Dictionary<string, PriorityQueue<Food, Food>> cuisinesToFood = new Dictionary<string, PriorityQueue<Food, Food>>();
            Dictionary<string, int> foodsToRatings = new Dictionary<string, int>();
            Dictionary<string, string> foodsToCuisines = new Dictionary<string, string>();
            public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
            {
                for (int i = 0; i < foods.Length; i++)
                {
                    if (!cuisinesToFood.ContainsKey(cuisines[i]))
                        cuisinesToFood.Add(cuisines[i], new PriorityQueue<Food, Food>());

                    cuisinesToFood[cuisines[i]].Enqueue(new Food(ratings[i], foods[i]), new Food(ratings[i], foods[i]));
                    foodsToRatings.Add(foods[i], ratings[i]);
                    foodsToCuisines.Add(foods[i], cuisines[i]);
                }
            }

            public void ChangeRating(string food, int newRating)
            {
                foodsToRatings[food] = newRating;
                cuisinesToFood[foodsToCuisines[food]].Enqueue(new Food(newRating, food), new Food(newRating, food));
            }

            public string HighestRated(string cuisine)
            {
                while (cuisinesToFood[cuisine].Peek().Rating != foodsToRatings[cuisinesToFood[cuisine].Peek().Name])
                    cuisinesToFood[cuisine].Dequeue();

                return cuisinesToFood[cuisine].Peek().Name;
            }
        }
    }
}
