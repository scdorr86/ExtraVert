List<Plant> plants = new List<Plant>()
{
  new Plant()
  {
    Species = "Norway Maple",
    LightNeeds = 3,
    AskingPrice = 100.00M,
    City = "Nashville",
    Zip = 37221,
    Sold = false
  },
    new Plant()
  {
    Species = "Japanese Honeysuckle",
    LightNeeds = 3,
    AskingPrice = 150.00M,
    City = "Seattle",
    Zip = 98101,
    Sold = false
  },
    new Plant()
  {
    Species = "Stinking Willie",
    LightNeeds = 3,
    AskingPrice = 50.00M,
    City = "Palo Alto",
    Zip = 94304,
    Sold = false
  },
    new Plant()
  {
    Species = "Hemlock",
    LightNeeds = 3,
    AskingPrice = 175.00M,
    City = "Denver",
    Zip = 80014,
    Sold = false
  },
    new Plant()
  {
    Species = "Scotch Broom",
    LightNeeds = 3,
    AskingPrice = 125.00M,
    City = "Portland",
    Zip = 97035,
    Sold = false
  }
};

string welcome = "Welcome to ExtraVert!";
ListPlants();

Console.WriteLine(welcome);
string? choice = null;
while (choice != "E")
{
    Console.WriteLine(@"Choose an option:
                        A. Display All Plants
                        B. Post a plant to be adopted
                        C. Adopt a plant
                        D. Delist a plant
                        E. Exit");
    
    choice = Console.ReadLine();
    
    if (choice == "E")
    {
        Console.WriteLine("Adios, amigo!");
    }
    else if (choice == "B")
    {
        throw new NotImplementedException("Post a plant to be adopted");
    }
    else if (choice == "C")
    {
        throw new NotImplementedException("Adopt a plant");
    }
    else if (choice == "D")
    {
        throw new NotImplementedException("Delist a plant");
    }
    else if (choice == "A")
    {
        // throw new NotImplementedException("Display all plants");
        ListPlants();
    }
}

void ListPlants()
{
  for (int i = 0; i <plants.Count; i++)
  {
    Console.WriteLine($"{i + 1}. {plants[i].Species}");
  }
}
