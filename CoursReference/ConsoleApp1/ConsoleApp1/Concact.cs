namespace ConsoleApp1;

internal class Contact //: Object // par défaut, une classe hérite de la classe Object.
{
    #region Fields
    
    // Les champs doivent être privé (principe d'encapsulation).
    private int _age;
    string _firstName; //Par défaut, le modification d'accès d'un champ est private.

    #endregion

    #region Properties

    //Une propriété permet de créer une méthode get et une méthode set pour exposer un champ privé.
    public string FirstName
    {
        //Il est possible de définir les méthodes get et set en "bodied".
        get => _firstName;
        set => _firstName = value;
    }

    //Cette syntaxe permet d'éviter d'avoir à déclarer le champ privé, il va être créé automatiquement.
    //Même si on pourrait penser que cette syntaxe revient à créer un champ public, ce n'est techniquement pas le cas.
    //Il est important de respecter le principe d'encapsulation.
    public string? LastName { get; set; } // string? permet de définir une chaîne qui autorise les valeurs null.
    //public string LastName; //Cette syntaxe ne respecte pas le principe d'encapsulation.

    public DateTime? Birthdate { get; set; } // DateTime? permet de définir une datet et heure qui autorise les valeurs null.

    #endregion

    #region Constructors
    
    //Un constructeur vide est créé par défaut si aucun constructeur est spécifié.
    //Il en va de même pour le destructeur.
    public Contact()
    {
        //_firstname est des type string (et non pas string?) ce qui signifie qu'il doit avoir une valeur autre que null avant la fin du constructeur.
        //Ce n'est pas le case de LastName qui est de type string? et qui autorise donc d'avoir une valeur null.
        _firstName = string.Empty; 
    }

    #endregion

    #region Methods

    //En Java, on va créer des méthodes get/set pour l'accès aux champs privés.
    //La notion de propriété n'existe pas en Java.
    //La notion de propriété est une simplification de syntaxe, le résultat est le même à la compilation.
    public string GetFirstName() => _firstName; //=> Permet de créer une méthode sans corps (bodied). C'est une méthode avec une seule instruction. Le return est implicite.
    //{
    //    return _firstName;
    //}

    public void SetFirstName(string value)
        => _firstName = value;
    //{
    //    _firstName = value;
    //}

    //La classe Object définie une méthode ToString marquée comme virtual.
    //Ceci signifie que la classe Object permet aux héritier de surcharger son comportement soit en le complétant soit en le modifiant entièrement. 
    public override string ToString()
    {
        //return FirstName + " " + LastName;
        //return string.Format("{0} {1}", FirstName, LastName);
        //return $"{FirstName} {LastName}";
        string toString = FirstName;

        if (string.IsNullOrWhiteSpace(LastName) == false)
        {
            toString += " " + LastName;
        }

        if (Birthdate != null)
        {
            //toString += $" né le {Birthdate.Value.ToLongDateString()}";
            //toString += $" né le {Birthdate.Value.ToString("D")}";
            toString += $" né le {Birthdate:D}";
        }

        return toString;
    }

    #endregion
}
