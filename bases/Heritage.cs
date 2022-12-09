namespace Cours.Bases;

using Engine;

// Class parent
public class Animal
{
    protected string name;
    protected double age;
    protected byte nbPattes;

    public Animal(string name, double age, byte nbPattes)
    {
        this.name = name;
        this.age = age;
        this.nbPattes = nbPattes;
    }

    public void dormir()
    {
        Console.WriteLine($"{this.name} dort.");
    }
}

// Enfant 1
public class Ours : Animal
{
    private string couleur;

    // Surcharge du constructeur
    public Ours(string name, double age, byte nbPattes, string couleur) : base(name, age, nbPattes)
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
public class FlamantRose : Animal
{
    // Reprise du construteur du parent
    public FlamantRose(string name, double age, byte nbPattes) : base(name, age, nbPattes) {}

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
        Animal animal = new Animal("Jane", 38, 2);
        animal.dormir();

        Ours ours = new Ours("Teddy", 4, 4, "brun");
        ours.griffer();
        ours.mangerMiel(3);
        ours.dormir();

        FlamantRose flamantRose = new FlamantRose("Fifi", 12, 2);
        flamantRose.voler();
        flamantRose.dormir();
    }
}