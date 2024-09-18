using System.Text.Json;

namespace CoursJSON;


internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        List<Contact> contacts =
        [
            new()
            {
                FirstName = "Benjamin",
                LastName = "DAGUE",
            },
            new()
            {
                FirstName = "Jean",
                LastName = "DUPONT",
            }
        ];

        string serializedContact = JsonSerializer.Serialize(contacts);

        Console.WriteLine(serializedContact);

        serializedContact = serializedContact.Replace("Benjamin", "Jean");

        Console.WriteLine(serializedContact);

        //string filePath = "C:\\_workdir\\contact.json";
        string filePath = @"C:\_workdir\contact.json";

        File.WriteAllText(filePath, serializedContact);

        string serializedContactFromFile = File.ReadAllText(filePath);

        Console.WriteLine(serializedContactFromFile);

        contacts = JsonSerializer.Deserialize<List<Contact>>(serializedContactFromFile) 
            ?? throw new Exception("Le fichier ne contient pas un contact valide");

        Console.ReadKey();
    }
}
