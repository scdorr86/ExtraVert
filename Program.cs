﻿List<Plant> plants = new List<Plant>()
{
  new Plant()
  {
    Species = "Norway Maple",
    LightNeeds = 5,
    AskingPrice = 100.00M,
    City = "Nashville",
    Zip = 37221,
    Sold = false,
    AvailableUntil = new DateTime(2023, 12, 31)
  },
    new Plant()
  {
    Species = "Japanese Honeysuckle",
    LightNeeds = 4,
    AskingPrice = 150.00M,
    City = "Seattle",
    Zip = 98101,
    Sold = false,
    AvailableUntil = new DateTime(2023, 10, 31)
  },
    new Plant()
  {
    Species = "Stinking Willie",
    LightNeeds = 3,
    AskingPrice = 50.00M,
    City = "Palo Alto",
    Zip = 94304,
    Sold = false,
    AvailableUntil = new DateTime(2023, 9, 30)
  },
    new Plant()
  {
    Species = "Hemlock",
    LightNeeds = 2,
    AskingPrice = 175.00M,
    City = "Denver",
    Zip = 80014,
    Sold = false,
    AvailableUntil = new DateTime(2023, 5, 31)
  },
    new Plant()
  {
    Species = "Scotch Broom",
    LightNeeds = 1,
    AskingPrice = 125.00M,
    City = "Portland",
    Zip = 97035,
    Sold = true,
    AvailableUntil = new DateTime(2023, 7, 31)
  }
};

Random random = new Random();
int randomIndex;
do
{
    randomIndex = random.Next(0, plants.Count);
}
while (plants[randomIndex].Sold == true);

string welcome = "Welcome to ExtraVert!";

Console.WriteLine(welcome);
string? choice = null;
while (choice != "H")
{
    Console.WriteLine(@"Choose an option:
                        A. Display All Plants
                        B. Post a plant to be adopted
                        C. Adopt a plant
                        D. Delist a plant
                        E. See Plant of the Day
                        F. Search Plants by Light Needs
                        G. Plants Available to Adopt
                        H. Exit");

    choice = Console.ReadLine();

    if (choice == "H")
    {
        Console.Clear();
        Console.WriteLine("Adios, amigo!");
    }
    else if (choice == "B")
    {
        Console.WriteLine("Please enter your Plant Information:");
        PostPlant();
    }
    else if (choice == "C")
    {
        Console.WriteLine("Please select plant to Adopt");
        AdoptPlant();
    }
    else if (choice == "D")
    {
        Console.WriteLine("Please select a plant to Delist");
        DelistPlant();
    }
    else if (choice == "E")
    {
        PlantOfDay();
        Console.WriteLine("test line");
    }
    else if (choice == "F")
    {
        FilterLightNeeds();
    }
    else if (choice == "G")
    {
        AdoptablePlants();
    }
    else if (choice == "A")
    {
        ListPlants();
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Please enter an option letter");
    }
}

void ListPlants()
{
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice}. This post expires on {plants[i].AvailableUntil}.");
    }
}

void PostPlant()
{
    Plant plant = new Plant();

    Console.WriteLine("Please enter Species");
    string? speicesInput = Console.ReadLine();
    plant.Species = speicesInput;

    Console.WriteLine("Please enter Light needs (1-5)");
    double lightInput = Convert.ToDouble(Console.ReadLine());
    plant.LightNeeds = lightInput;

    Console.WriteLine("Please enter Asking Price");
    decimal priceInput = Convert.ToDecimal(Console.ReadLine());
    plant.AskingPrice = priceInput;

    Console.WriteLine("Please enter City");
    string? cityInput = (Console.ReadLine());
    plant.City = cityInput;

    Console.WriteLine("Please enter Zip Code");
    int zipInput = Convert.ToInt32(Console.ReadLine());
    plant.Zip = zipInput;

    Console.WriteLine("Please enter the date this post should expire");

    DatePrompt();

    plant.Sold = false;

    plants.Add(plant);
}

void AdoptPlant()
{
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "is NOT" : "IS")} available for {plants[i].AskingPrice}");
    }

    int adoptInput = Convert.ToInt32(Console.ReadLine());
    plants[adoptInput - 1].Sold = true;
}

void DelistPlant()
{
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }

    int delistInput = Convert.ToInt32(Console.ReadLine());
    plants.RemoveAt(delistInput - 1);
}

void PlantOfDay()
{
    Console.WriteLine($"The plant of the day is {plants[randomIndex].Species} in {plants[randomIndex].City} {(plants[randomIndex].Sold ? " and  it was sold" : "and it is available")} for {plants[randomIndex].AskingPrice}");
};

void FilterLightNeeds()
{
  List<Plant> lightFilter = new List<Plant>();

  Console.WriteLine("Please enter a maximum light need");

  double maxLightInput = Convert.ToDouble(Console.ReadLine());

  foreach (Plant plant in plants)
  {
    if (plant.LightNeeds <= maxLightInput)
    {
      lightFilter.Add(plant);
    }
  }
    for (int i = 0; i < lightFilter.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {lightFilter[i].Species} with light need of {lightFilter[i].LightNeeds}.");
    }
};

void DatePrompt ()
{
      Plant plant = new Plant();

      Console.WriteLine("Day: "); 
      var day = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Month: ");
      var month = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Year: ");
      var year = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine(year);
      Console.WriteLine(month);
    
      plant.AvailableUntil = new DateTime(year, month, day);
}

void AdoptablePlants()
{
    List<Plant> AdoptablePlants = new List<Plant>();
    
    DateTime CurrentDate = DateTime.Now;
    
    foreach (Plant plant in plants)
    {
        if (plant.AvailableUntil < CurrentDate && !plant.Sold)
        {
            AdoptablePlants.Add(plant);
        }
    }
    // print out the latest products to the console 
    for (int i = 0; i < AdoptablePlants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {AdoptablePlants[i].Species}");
    }
};
