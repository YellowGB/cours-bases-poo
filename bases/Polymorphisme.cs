namespace Cours.Bases;

using Engine;

public class AnimalPolymorphisme
{
    protected string Nom {get; set;}
    protected double Age {get; set;}
    protected byte NbPattes {get; set;}

    public AnimalPolymorphisme(string nom, double age, byte nbPattes)
    {
        this.Nom = nom;
        this.Age = age;
        this.NbPattes = nbPattes;
    }

    public void Dormir()
    {
        Console.WriteLine($"{this.Nom} dort.");
    }

    // Méthode virtuelle
    public virtual void Courir()
    {
        Console.WriteLine("L'animal court.");
    }
}

public class OursPolymorphisme : AnimalPolymorphisme
{
    private string _couleur {get; set;}

    public OursPolymorphisme(string nom, double age, byte nbPattes, string couleur) : base(nom, age, nbPattes)
    {
        this._couleur = couleur;
    }

    // Redéfinition/override de la méthode "Courir"
    public override void Courir()
    {
        Console.WriteLine($"L'ours {this._couleur} court.");
    }

    public void Manger()
    {
        Console.WriteLine("L'ours a faim !");
    }

    // Surcharge/overload de la méthode "Manger"
    public void Manger(byte nombre)
    {
        Console.WriteLine($"L'ours mange {nombre} fois.");
    }

    // Autre surcharge de la méthode "Manger"
    public void Manger(string nourriture, char genre = 'p')
    {
        if (genre == 'f') {
            Console.WriteLine($"L'ours mange de la {nourriture}.");
        }
        else if (genre == 'm') {
            Console.WriteLine($"L'ours mange du {nourriture}.");
        }
        else {
            Console.WriteLine($"L'ours mange des {nourriture}.");
        }
    }
}

public class FlamantRosePolymorphisme : AnimalPolymorphisme
{
    public FlamantRosePolymorphisme(string nom, double age, byte nbPattes) : base(nom, age, nbPattes) {}

    // Redéfinition : cache la méthode originelle et la remplace
    new public void Dormir()
    {
        Console.WriteLine($"Le flamant rose de {this.Age} ans essaie de dormir.");
    }

    // Ecrasement/override de la méthode "Courir"
    public override void Courir()
    {
        // Exécution de la méthode "courir" originelle telle que définie dans la classe "Animal"
        base.Courir();
        // Exécution supplémentaire propre à la classe "FlamantRose"
        Console.WriteLine("Il ne court pas très vite.");
    }
}

public class PolymorphismeDemo : IDemoMaker
{
    public void Run()
    {
        AnimalPolymorphisme animal = new AnimalPolymorphisme("Jane", 38, 2);
        OursPolymorphisme ours = new OursPolymorphisme("Teddy", 4, 4, "brun");
        FlamantRosePolymorphisme flamantRose = new FlamantRosePolymorphisme("Fifi", 12, 2);

        animal.Dormir();
        ours.Dormir();
        flamantRose.Dormir();

        Helpers.ConsoleSeparator();

        animal.Courir();
        ours.Courir();
        flamantRose.Courir();

        Helpers.ConsoleSeparator();

        ours.Manger();
        ours.Manger(3);
        ours.Manger("purée", 'f');
    }
}