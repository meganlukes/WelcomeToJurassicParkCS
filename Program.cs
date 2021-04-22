using System;
using System.Collections.Generic;
using System.Linq;

namespace WelcomeToJurassicParkCS
{
    class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; set; } = DateTime.Now;
        public int Weight { get; set; }
        public int EnclosureNumber { get; set; }
        public void Description()
        {
            Console.WriteLine($"{Name} was received {WhenAcquired}");
            Console.WriteLine($"{Name} is a {DietType}");
            Console.WriteLine("Speaking of which you should probably adjust the feed schedule since it now weights {Weight}kg.");
            Console.WriteLine($"Assuming it hasn't escaped yet, {Name} should be in Enclosure {EnclosureNumber}");
            Console.WriteLine("I call all the dinosaurs 'it' because shockingly enough, we didn't cover sexing dinosaurs at business school.");
        }
    }


    class Program
    {
        static void Greeting()
        {
            Console.WriteLine("I got the master inventory for you, just like you asked.");
            Console.WriteLine("I'll admit I'm surprised you decided to reopen.");
            Console.WriteLine("I mean, haven't we already tried this four times and it ended horribly each time?");
            Console.WriteLine("Hey, it's your wrongful death lawsuit money.");
        }

        static string PromptForString(string prompt)
        {
            var userInput = Console.ReadLine();
            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);
            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }

        static void View(List<Dinosaur> dinoList)
        {
            var listLength = dinoList.Count;
            if (listLength == 0)
            {
                Console.WriteLine("We don't have any dinosaurs yet. Go take it up with the lab.");
            }
            else
            {
                var dinoByDateList = dinoList.OrderBy(dino => dino.Name);
                Console.WriteLine("In the order that they were acquired, our current inventory is composed of:");
                for (int i = 0; i < listLength; i++)
                {
                    Console.WriteLine("dinoByDateList.Name[i]");
                }
            }
        }

        static List<Dinosaur> Add(List<Dinosaur> dinoList)
        {
            var newDino = new Dinosaur();
            newDino.Name = PromptForString("What is the dinosaur's name?");
            Console.WriteLine("Is it an Herbivore or a Carnivore?    ");
            var inputtedDiet = Console.ReadLine();
            while (inputtedDiet != "Carnivore" && inputtedDiet != "Herbivore")
            {
                Console.WriteLine("Sorry, the database doesn't have that as an option. Is it an Herbivore or a Carnivore?   ");
                inputtedDiet = Console.ReadLine();
            }
            newDino.DietType = inputtedDiet;
            newDino.Weight = PromptForInteger("How much does it weigh in kilograms?(Please type a whole number)   ");
            newDino.EnclosureNumber = PromptForInteger("What is the new dinosaur's enclosure number?   ");
            dinoList.Add(newDino);
            return dinoList;
        }

        static List<Dinosaur> Remove(List<Dinosaur> dinoList)
        {
            var dino = PromptForString("Which dinosaur needs to be removed from the inventory?    ");
            Dinosaur dinoToDelete = dinoList.FirstOrDefault(rex => rex.Name == dino);

            if (dinoToDelete == null)
            {
                Console.WriteLine("There's nothing named {dino} on our inventory list.");
            }
            else
            {
                dinoList.Remove(dinoToDelete);
                Console.WriteLine($"{dino} is now off the inventory list.");
            }
            return dinoList;
        }

        static List<Dinosaur> Transfer(List<Dinosaur> dinoList)
        {
            string tempDinoName;
            tempDinoName = PromptForString("What is the name of the dinosaur you would like to transfer?");
            var isThisDinoHere = dinoList.Any(aDinoName => aDinoName.Name == tempDinoName);
            while (isThisDinoHere == false)
            {
                tempDinoName = PromptForString("Sorry, I don't have a dinosaur with that name on the inventory list. What is the name of the dinosaur you would like to transfer?");
                isThisDinoHere = dinoList.Any(aDinoName => aDinoName.Name == tempDinoName);
            }
            var dinoName = tempDinoName;
            var indexOfDino = dinoList.FindIndex(dino => dino.Name == dinoName);
            int enclosureNumber = PromptForInteger($"To which enclosure would you like {dinoName} tranferred?");
            dinoList[indexOfDino].EnclosureNumber = enclosureNumber;
            return dinoList;
        }

        static void Summary(List<Dinosaur> dinoList)
        {
            var numberOfCarnivores = dinoList.Count(dino => dino.DietType == "carnivore");
            var numberOfHerbivores = dinoList.Count(dino => dino.DietType == "herbivore");
            Console.WriteLine($"We currently have {numberOfCarnivores} carnivores and {numberOfHerbivores} herbivores.");
        }

        static void Main(string[] args)
        {
            var dinosaurInventory = new List<Dinosaur>();
            Greeting();
            var keepAnnoyingMe = true;
            while (keepAnnoyingMe)
            {
                Console.WriteLine("Would you like to (V)iew the list of dinosaurs in the order that they were aqcuired, (A)dd a new dinosaur to the inventory, (R)emove a dinosaur from the inventory, (T)ransfer a dinosaur to a different enclosure, (S)ee a list of our carnivores and herbivores, or (G)o find something else to do?");
                var selection = Console.ReadLine().ToUpper();
                if (selection == "V")
                {
                    View(dinosaurInventory);
                }
                else if (selection == "A")
                {
                    Add(dinosaurInventory);
                }
                else if (selection == "R")
                {
                    Remove(dinosaurInventory);
                }
                else if (selection == "S")
                {
                    Summary(dinosaurInventory);
                }
                else
                {
                    keepAnnoyingMe = false;
                }

            }





            /*var defaultDino = new Dinosaur();
            defaultDino.Name = "Chicken";
            defaultDino.Weight = 5;
            defaultDino.DietType = "Herbivore";
            defaultDino.EnclosureNumber = 1;

            defaultDino.Description(); */



        }
    }

}