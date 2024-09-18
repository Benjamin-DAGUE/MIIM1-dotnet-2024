using System;

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

        #endregion

        #region 2 - Afficher les personnes nées en janvier et en février

        #endregion

        #region 3 - Afficher les personnes nées un samedi ou un dimanche

        #endregion

        #region 4 - Afficher les personnes pour lesquelles le prénom a plus de 7 caractères

        #endregion

        #region 5 - Afficher les personnes nées en janvier et en février et pour lesquelles le prénom a plus de 7 caractères

        #endregion

        #region 6 - Calculer la moyenne d'age des personnes

        #endregion

        #region 7 - Afficher les personnes de la plus ancienne à la plus jeune

        #endregion

        #region 8 - Afficher les personnes dont l'age est supérieur à la moyenne d'âge

        #endregion

        #region 9 - Saisisez une chaîne et afficher les personnes dont le nom contient la recherche (non sensible à la casse)

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
