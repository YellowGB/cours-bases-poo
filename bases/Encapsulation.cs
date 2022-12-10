namespace Cours.Bases;

using Engine;

public class AnimalEncapsulation
{
    // Une propriété "protected" n'est accessible que par la classe elle-même et ses enfants 
    protected string Nom;
    protected double Age;
    protected byte NbPattes;

    // Une méthode "public" est accessible à tous
    public AnimalEncapsulation(string nom, double age, byte nbPattes)
    {
        this.Nom = nom;
        this.Age = age;
        this.NbPattes = nbPattes;
    }

    // Setters/mutateurs permettant de contrôler l'implémentation des propriétés
    public void SetNom(string nom)
    {
        this.Nom = nom;
    }

    public void SetAge(double age)
    {
        /*
            Termine l'exécution de la méthode prématurément
            si les conditions ne sont pas remplies.
            On appelle cela une "guard clause"
        */
        if (age < 0) {
            Console.WriteLine("Un animal ne peut pas avoir un age négatif !");
            return;
        }

        this.Age = age;
    }

    public void SetNbPattes(byte nbPattes)
    {
        this.NbPattes = nbPattes;
    }

    // Getters/accesseurs permettant d'accéder aux propriétés de manière contrôlée
    public string GetNom()
    {
        return this.Nom;
    }

    public double GetAge()
    {
        if (this.IsOld()) {
            Console.WriteLine("C'est un vieil animal !");
        }
        return this.Age;
    }

    public byte GetNbPattes()
    {
        return this.NbPattes;
    }

    public void Dormir()
    {
        Console.WriteLine($"{this.Nom} dort.");
    }

    // Une méthode "private" n'est accessible qu'à l'intérieur de la classe elle-même
    private bool IsOld()
    {
        return this.Age >= 100;
    }
}

public class OursEncapsulation : AnimalEncapsulation
{
    // Une propriété "private" n'est accessible que par la classe elle-même
    private string _couleur;

    public OursEncapsulation(string nom, double age, byte nbPattes, string couleur) : base(nom, age, nbPattes)
    {
        this._couleur = couleur;
    }

    public void SetCouleur(string? couleur)
    {
        if (string.IsNullOrEmpty(couleur)) {
            Console.WriteLine("Vous n'avez indiqué aucune couleur !");
            return;
        }
        this._couleur = couleur;
    }

    public string GetCouleur()
    {
        return this._couleur;
    }

    public void Griffer()
    {
        Console.WriteLine("L'ours griffe.");
    }

    public void MangerMiel(uint nbPots)
    {
        Console.WriteLine($"L'ours mange {nbPots} pots de miel.");
    }
}

public class FlamantRoseEncapsulation : AnimalEncapsulation
{
    public FlamantRoseEncapsulation(string nom, double age, byte nbPattes) : base(nom, age, nbPattes) {}

    new public void Dormir()
    {
        Console.WriteLine($"Le flamant rose de {this.Age} ans essaie de dormir.");
    }

    public void Voler()
    {
        Console.WriteLine("Le flamant rose s'envole.");
    }

    public void CheckAge()
    {
        Console.WriteLine($"Le flamant rose a {this.Age} ans.");
        // Nous ne pouvons pas accéder à une méthode "private" du parent
        //if (this.IsOld()) {
        //    Console.WriteLine("C'est un vieil animal !");
        //}
    }
}

public class EncapsulationDemo : IDemoMaker
{
    public void Run()
    {
        AnimalEncapsulation animal = new AnimalEncapsulation("Jane", 38, 2);

        Console.WriteLine($"L'animal a {animal.GetAge()} ans.");

        Console.Write("Nouvel âge de l'animal : ");
        animal.SetAge(Convert.ToDouble(Console.ReadLine()));
        //animal.Age = 32;
        Console.WriteLine($"L'animal a {animal.GetAge()} ans.");
        //animal.IsOld();

        Console.WriteLine("---");

        OursEncapsulation ours = new OursEncapsulation("Teddy", 4, 4, "brun");

        Console.WriteLine($"C'est un ours {ours.GetCouleur()}.");

        Console.Write("Nouvelle couleur de l'ours : ");
        ours.SetCouleur(Console.ReadLine());
        Console.WriteLine($"C'est un ours {ours.GetCouleur()}.");

        Console.WriteLine("---");

        FlamantRoseEncapsulation flamantRose = new FlamantRoseEncapsulation("Fifi", 12, 2);
        flamantRose.CheckAge();
    }
}