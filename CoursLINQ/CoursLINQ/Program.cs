using System;
using System.Drawing;
using System.Transactions;

namespace CoursLINQ;

internal class Program
{
    private static string[] _firstNames =
        [
            "Gilles",
            "Maurice",
            "Raymond",
            "Anaïs",
            "Henri",
            "Hugues",
            "Eugène",
            "Danielle",
            "Stéphanie",
            "Charlotte",
            "Robert",
            "Audrey",
            "Patrick",
            "François",
            "Alexandre",
            "Thomas",
            "Margaud",
            "Dominique",
            "Philippine",
            "Simone",
            "Timothée",
            "Jean",
            "Noémi",
            "Xavier",
            "Michèle",
            "Christine",
            "Georges",
            "Bernadette",
            "Colette",
            "David",
            "Marie",
            "Josette",
            "Catherine",
            "Michelle",
            "Luc",
            "Geneviève",
            "Matthieu",
            "Julie",
            "Luce",
            "Grégoire",
            "René",
            "Gabrielle",
            "Marguerite",
            "Léon",
            "Olivier",
            "Patricia",
            "Philippe",
            "Agathe",
            "Isabelle",
            "Alexandria",
            "Stéphane",
            "Guillaume",
            "Christophe",
            "Christelle",
            "Laurent",
            "Anne",
            "Julien",
            "Arthur",
            "Astrid"
        ];
    private static string[] _lastNames =
        [
            "RENAULT",
            "DUHAMEL",
            "RENAUD",
            "RENARD-VALETTE",
            "MICHAUD",
            "PERRIER-RENARD",
            "DEVAUX-CHARPENTIER",
            "BRIAND",
            "LAPORTE",
            "MASSE",
            "CAMUS",
            "PIRES",
            "CLEMENT",
            "ROGER",
            "DELATTRE",
            "MOREAU",
            "LEBON",
            "MORIN",
            "GUILLON",
            "LAUNAY",
            "BEGUE",
            "DIALLO-BLOT",
            "ALLARD",
            "MARTINEZ",
            "COLAS",
            "HERNANDEZ",
            "DESCAMPS",
            "LOISEAU",
            "ROBIN",
            "LACOMBE",
            "BLANCHET",
            "JACQUOT",
            "SCHNEIDER-MAURICE",
            "SOUSA",
            "RODRIGUES",
            "MEYER-BONNEAU",
            "LAROCHE",
            "CHARTIER",
            "GOSSELIN",
            "DELAUNAY",
            "PERON",
            "GRONDIN-GROS",
            "HOARAU",
            "BIGOT",
            "SANTOS",
            "COULON",
            "TECHER",
            "PAGES-LEROY",
            "DELAHAYE",
            "VALETTE",
            "ROUX-DIAS",
            "BERGER",
            "LEBLANC",
            "PELLETIER",
            "FERREIRA",
            "LEDUC",
            "BOYER",
            "GILBERT",
            "LEROY",
            "FERRAND",
            "BOULANGER",
            "LECLERC",
            "LEDOUX",
            "CARLIER",
            "FRANCOIS",
            "TANGUY",
            "FONTAINE",
            "TORRES",
            "ROSSI",
            "DUPUIS",
            "DUBOIS",
            "MARTEL",
            "DENIS",
        ];
    private static Random _random = new();

    static void Main(string[] args)
    {
        List<Contact> contacts = [];

        //for (int i = 0; i < 1000; i++)
        //{
        //    contacts.Add(new()
        //    {
        //        FirstName = _firstNames[_random.Next(0, _firstNames.Length)],
        //        LastName = _lastNames[_random.Next(0, _lastNames.Length)],
        //        BirthDate = DateTime.Now.AddDays(-1 * _random.Next(0, 5000))
        //    });
        //}

        //;

        //foreach (Contact contact in Enumerable.Range(0, 1000).Select(Randomize))
        //{
        //    contacts.Add(contact);
        //}

        //contacts.AddRange(Enumerable.Range(0, 1000).Select(Randomize));

        contacts.AddRange(Enumerable.Range(0, 1000).Select(i => new Contact()
        {
            FirstName = _firstNames[_random.Next(0, _firstNames.Length)],
            LastName = _lastNames[_random.Next(0, _lastNames.Length)],
            BirthDate = DateTime.Now.AddDays(-1 * _random.Next(0, 36500))
        }));

        IEnumerable<Contact> query = contacts.Where(c => c.FirstName.Contains("a"));

        query = query.Where(c => c.LastName.Contains("a"));

        foreach (Contact matchingContact in query)
        {
            Console.WriteLine(matchingContact.FirstName);
        }

        contacts
            .Where(c => c.FirstName.Contains("a"))
            .Where(c => c.LastName.Contains("a"))
            .ToList()
            .ForEach(c => Console.WriteLine(c.FirstName + " " + c.LastName));

        #region 1 - Afficher les personnes nées avant l'an 2000

        Console.WriteLine("1 - Afficher les personnes nées avant l'an 2000");
        contacts                                              //On part de la liste des personnes.
            .Where(p => p.BirthDate.Year < 2000)            //On filtre pour conserver les personnes nées avant l'an 2000.
            .ToList()                                       //On exécute la requête en créant une liste du réslutat.
            .ForEach(p => Console.WriteLine(p.FullName));   //Pour chaque personne dans la liste du résultat, on affiche son nom et son prénom.

        #endregion

        #region 2 - Afficher les personnes nées en janvier et en février

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("2 - Afficher les personnes nées en janvier et en février");
        contacts
            //.Where(p => new int[] { 1, 6 }.Contains(p.BirthDate.Month))
            .Where(p => p.BirthDate.Month <= 2)
            //.Where(p => p.BirthDate.Month <= 3)
            .ToList()
            .ForEach(p => Console.WriteLine(p.FullName));

        #endregion

        #region 3 - Afficher les personnes nées un samedi ou un dimanche

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("3 - Afficher les personnes nées un samedi ou un dimanche");
        contacts
            //.Where(p => new[] { DayOfWeek.Saturday, DayOfWeek.Sunday }.Contains(p.BirthDate.DayOfWeek))
            .Where(p => p.BirthDate.DayOfWeek == DayOfWeek.Saturday || p.BirthDate.DayOfWeek == DayOfWeek.Sunday)
            .ToList()
            .ForEach(p => Console.WriteLine(p.FullName));

        #endregion

        #region 4 - Afficher les personnes pour lesquelles le prénom a plus de 7 caractères

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("4 - Afficher les personnes pour lesquelles le prénom a plus de 7 caractères");
        contacts
            .Where(p => p.FirstName.Length > 7)
            .ToList()
            .ForEach(p => Console.WriteLine(p.FullName));

        #endregion

        #region 5 - Afficher les personnes nées en janvier et en février et pour lesquelles le prénom a plus de 7 caractères

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("5 - Afficher les personnes nées en janvier et en février et pour lesquelles le prénom a plus de 7 caractères");
        contacts
            .Where(p => p.BirthDate.Month <= 2 && p.FirstName.Length > 7)
            //.Where(p => p.BirthDate.Month <= 2)
            //.Where(p => p.FirstName.Length > 7)
            .ToList()
            .ForEach(p => Console.WriteLine(p.FullName));

        #endregion

        #region 6 - Calculer la moyenne d'age des personnes

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("6 - Calculer la moyenne d'age des personnes");
        double averageAge = contacts.Average(p => p.BirthDate.CalculateAge());
        Console.WriteLine("L'âge moyen est : " + averageAge);

        #endregion

        #region 7 - Afficher les personnes de la plus ancienne à la plus jeune

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("7 - Afficher les personnes de la plus ancienne à la plus jeune");
        contacts
            .OrderBy(p => p.BirthDate)
            .ToList()
            .ForEach(p => Console.WriteLine(p.FullName));

        #endregion

        #region 8 - Afficher les personnes dont l'age est supérieur à la moyenne d'âge

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("8 - Afficher les personnes dont l'age est supérieur à la moyenne d'âge");
        contacts
            //Cette méthode calcul la moyenne d'âge plusieurs fois (une foi par personne présente dans la liste)
            //.Where(p => p.BirthDate.CalculateAge() > contacts.Average(p => p.BirthDate.CalculateAge()))
            .Where(p => p.BirthDate.CalculateAge() > averageAge)
            .ToList()
            .ForEach(p => Console.WriteLine(p.FullName));

        #endregion

        #region 9 - Saisisez une chaîne et afficher les personnes dont le nom contient la recherche

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("9 - Saisisez une chaîne et afficher les personnes dont le nom contient la recherche");
        Console.Write("Votre recherche : ");
        string search = Console.ReadLine() ?? "";
        contacts
            .Where(p => p.FullName.Contains(search, StringComparison.CurrentCultureIgnoreCase))
            .ToList()
            .ForEach(p => Console.WriteLine(p.FullName));

        #endregion

        #region Grouping
        /*
        ----
        A
        ----
        - ALLARD Gilles
        - ALLARD Maurice
        ----
        B
        ----
        - ...
        - ...
        - ...
        ----
        D
        ----
        - ...
        ...

        */

        string currentFirstLetter = "";

        //contacts
        //    .OrderBy(c => c.LastName)
        //    .ThenBy(c => c.FirstName)
        //    .ToList()
        //    .ForEach(p =>
        //    {
        //        string firstLetter = p.LastName.Substring(1);

        //        if (currentFirstLetter != firstLetter)
        //        {
        //            currentFirstLetter = firstLetter;
        //            Console.WriteLine("-------");
        //            Console.WriteLine(currentFirstLetter);
        //            Console.WriteLine("-------");
        //        }
        //        Console.WriteLine(p.FullName);
        //    });

        foreach (var group in contacts.GroupBy(c => c.LastName.Substring(1))
            .OrderBy(g => g.Key))
        {
            Console.WriteLine("-------");
            Console.WriteLine(group.Key);
            Console.WriteLine("-------");

            foreach (var contact in group.OrderBy(c => c.LastName).ThenBy(c => c.FirstName))
            {
                Console.WriteLine(contact.FullName);
            }
        }

        #endregion


    }

    private static Contact Randomize(int i)
{
return new()
{
    FirstName = _firstNames[_random.Next(0, _firstNames.Length)],
    LastName = _lastNames[_random.Next(0, _lastNames.Length)],
    BirthDate = DateTime.Now.AddDays(-1 * _random.Next(0, 5000))
};
}
}
