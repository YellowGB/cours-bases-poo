namespace Cours.Bases;

using Engine;

// Class parent
public class AnimalHeritage
{
    public string nom;
    public double age;
    public byte nbPattes;

    public AnimalHeritage(string nom, double age, byte nbPattes)
    {
        // Le mot-clé "this" fait référence à l'instance (l'objet courant)
        this.nom = nom;
        this.age = age;
        this.nbPattes = nbPattes;
    }

    public void dormir()
    {
        Console.WriteLine($"{this.nom} dort.");
    }
}

// Enfant 1
public class OursHeritage : AnimalHeritage
{
    public string couleur;

    // Surcharge du constructeur
    public OursHeritage(string nom, double age, byte nbPattes, string couleur) : base(nom, age, nbPattes)
    {
        this.couleur = couleur;
    }

    // Méthodes supplémentaires
    public void griffer()
    {
        Console.WriteLine("L'ours griffe.");
    }

    public void mangerMiel(uint nbPots)
    {
        Console.WriteLine($"L'ours mange {nbPots} pots de miel.");
    }
}

// Enfant 2
public class FlamantRoseHeritage : AnimalHeritage
{
    // Reprise du construteur du parent
    public FlamantRoseHeritage(string nom, double age, byte nbPattes) : base(nom, age, nbPattes) {}

    // Cache la méthode originelle et la remplace
    new public void dormir()
    {
        Console.WriteLine($"Le flamant rose de {this.age} ans essaie de dormir.");
    }

    // Méthode supplémentaire
    public void voler()
    {
        Console.WriteLine("Le flamant rose s'envole.");
    }
}

public class HeritageDemo : DemoMaker
{
    public void run()
    {
        AnimalHeritage animal = new AnimalHeritage("Jane", 38, 2);
        animal.dormir();

        OursHeritage ours = new OursHeritage("Teddy", 4, 4, "brun");
        ours.griffer();
        ours.mangerMiel(3);
        ours.dormir();

        FlamantRoseHeritage flamantRose = new FlamantRoseHeritage("Fifi", 12, 2);
        flamantRose.voler();
        flamantRose.dormir();
    }
}