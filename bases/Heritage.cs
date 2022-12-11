namespace Cours.Bases;

using Engine;

// Class parent
public class AnimalHeritage
{
    public string Nom;
    public double Age;
    public byte NbPattes;

    public AnimalHeritage(string nom, double age, byte nbPattes)
    {
        // Le mot-clé "this" fait référence à l'instance (l'objet courant)
        this.Nom = nom;
        this.Age = age;
        this.NbPattes = nbPattes;
    }

    public void Dormir()
    {
        Console.WriteLine($"{this.Nom} dort.");
    }
}

// Enfant 1
public class OursHeritage : AnimalHeritage
{
    public string Couleur;

    // Surcharge du constructeur
    public OursHeritage(string nom, double age, byte nbPattes, string couleur) : base(nom, age, nbPattes)
    {
        this.Couleur = couleur;
    }

    // Méthodes supplémentaires
    public void Griffer()
    {
        Console.WriteLine("L'ours griffe.");
    }

    public void MangerMiel(uint nbPots)
    {
        Console.WriteLine($"L'ours mange {nbPots} pots de miel.");
    }
}

// Enfant 2
public class FlamantRoseHeritage : AnimalHeritage
{
    // Reprise du construteur du parent
    public FlamantRoseHeritage(string nom, double age, byte nbPattes) : base(nom, age, nbPattes) {}

    // Méthode supplémentaire
    public void Voler()
    {
        Console.WriteLine("Le flamant rose s'envole.");
    }
}

public class HeritageDemo : IDemoMaker
{
    public void Run()
    {
        AnimalHeritage animal = new AnimalHeritage("Jane", 38, 2);
        animal.Dormir();

        Helpers.ConsoleSeparator();

        OursHeritage ours = new OursHeritage("Teddy", 4, 4, "brun");
        ours.Griffer();
        ours.MangerMiel(3);
        ours.Dormir();

        Helpers.ConsoleSeparator();

        FlamantRoseHeritage flamantRose = new FlamantRoseHeritage("Fifi", 12, 2);
        flamantRose.Voler();
        flamantRose.Dormir();
    }
}