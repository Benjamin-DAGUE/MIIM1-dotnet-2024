using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursLINQ;


/*
 **************************************************
 * Exemple de création d'une méthode d'extension. *
 **************************************************

    En C#, il est possible d'ajouter des méthodes à une classe ou une structure existante, c'est ce qu'on appel les méthodes d'extensions.
    C'est ce procédé qui est utilisée par LINQ pour ajouter des méthodes à IEnumerable<T>.
    
    Pour créer une méthode d'extension, il est nécessaire de créer une classe static.
    La méthode d'extension doit elle ausi être statique.

    Une méthode d'extension doit avoir la signature suivante

    public|internal|protected static <TYPE DE RETOUR> [NomDeLaMethode](this <TYPE A COMPLETER> [nomInstanceAppelée])

    Voici un exemple d'utilisation de la méthode public static int CalculateAge(this DateTime birthDate)

    DateTime birth = new DateTime(1987, 12, 24);
    int age = birth.CalculateAge();

    Cela revient à faire

    DateTime birth = new DateTime(1987, 12, 24);
    int age = DateTimeExtension.CalculateAge(birth);

*/

public static class DateTimeExtension
{
    //La méthode d'extension suivante s'applique au type DateTime.
    //birthdate contient la valeur de l'instance sur laquelle la méthode d'extension est appelée.
    public static int CalculateAge(this DateTime birthDate)
    {
        int age = DateTime.Now.Year - birthDate.Year;

        if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
        {
            age--;
        }

        return age;
    }
}
