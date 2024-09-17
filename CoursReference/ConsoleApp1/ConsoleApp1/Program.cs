using Microsoft.VisualBasic.FileIO;
using System;
using System.Runtime.CompilerServices;

namespace ConsoleApp1;
//public : Visible à l'exterieur du projet
//internal : Visible uniquement à l'intérieur du projet
//protected : Visible par la classe et les enfants
//private : Visible par la classe

internal class Program
{
    public static void Main()
    {
        Contact contact = new();

        Console.Write("Bonjour, quel est votre nom ? ");
        contact.LastName = Console.ReadLine();
        
        Console.Write("et votre prénom ? ");
        contact.FirstName = Console.ReadLine() ?? string.Empty;
        contact.FirstName.ToUpper();
        
        Console.Write("et votre date de naissance ? ");
        string birthdateString = Console.ReadLine() ?? string.Empty;

        if (DateTime.TryParse(birthdateString, out DateTime birthdate))
        {
            contact.Birthdate = birthdate;
        }

        Console.WriteLine(contact.ToString());
    }

}