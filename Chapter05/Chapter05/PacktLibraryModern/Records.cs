namespace Packt.Shared;

public class ImmutablePerson
{
    // These will not allow setting a value after instantiation
    // but do not require a value to be set. To require a value
    // make then required like.
    // public required string? FirstName { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; } 
}

public record ImmutableVehicle
{
    public int Wheels { get; init; }
    public string? Color { get; init; }
    public string? Brand { get; init; }
}

//public record ImmutableAnimal
//{
//    public string Name { get; init; }
//    public string Species { get; init; }

//    public ImmutableAnimal(string name, string species)
//    {
//        Name = name;
//        Species = species;
//    }

//    public void Deconstructor (out string name, out string species)
//    {
//        name = Name;
//        species = Species;
//    }
//}

//  Simpler syntax to define a record that auto-generates
//  the properties, constructor, and deconstructor
public record ImmutableAnimal(string Name, string Species);
