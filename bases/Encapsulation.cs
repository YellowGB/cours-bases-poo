namespace Cours.Bases;

using Engine;

public class AnimalEncapsulation
{
    // Une propriété "protected" n'est accessible que par la classe elle-même et ses enfants 
    protected string nom;
    protected double age;
    protected byte nbPattes;

    // Une méthode "public" est accessible à tous
    public AnimalEncapsulation(string nom, double age, byte nbPattes)
    {
        this.nom = nom;
        this.age = age;
        this.nbPattes = nbPattes;
    }

    // Setters/mutateurs permettant de contrôler l'implémentation des propriétés
    public void setNom(string nom)
    {
        this.nom = nom;
    }

    public void setAge(double age)
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

        this.age = age;
    }

    public void setNbPattes(byte nbPattes)
    {
        this.nbPattes = nbPattes;
    }

    // Getters/accesseurs permettant d'accéder aux propriétés de manière contrôlée
    public string getNom()
    {
        return this.nom;
    }

    public double getAge()
    {
        if (this.isOld()) {
            Console.WriteLine("C'est un vieil animal !");
        }
        return this.age;
    }

    public byte getNbPattes()
    {
        return this.nbPattes;
    }

    public void dormir()
    {
        Console.WriteLine($"{this.nom} dort.");
    }

    // Une méthode "private" n'est accessible qu'à l'intérieur de la classe elle-même
    private bool isOld()
    {
        return this.age >= 100;
    }
}

public class OursEncapsulation : AnimalEncapsulation
{
    // Une propriété "private" n'est accessible que par la classe elle-même
    private string couleur;

    public OursEncapsulation(string nom, double age, byte nbPattes, string couleur) : base(nom, age, nbPattes)
    {
        this.couleur = couleur;
    }

    public void setCouleur(string? couleur)
    {
        if (string.IsNullOrEmpty(couleur)) {
            Console.WriteLine("Vous n'avez indiqué aucune couleur !");
            return;
        }
        this.couleur = couleur;
    }

    public string getCouleur()
    {
        return this.couleur;
    }

    public void griffer()
    {
        Console.WriteLine("L'ours griffe.");
    }

    public void mangerMiel(uint nbPots)
    {
        Console.WriteLine($"L'ours mange {nbPots} pots de miel.");
    }
}

public class FlamantRoseEncapsulation : AnimalEncapsulation
{
    public FlamantRoseEncapsulation(string nom, double age, byte nbPattes) : base(nom, age, nbPattes) {}

    new public void dormir()
    {
        Console.WriteLine($"Le flamant rose de {this.age} ans essaie de dormir.");
    }

    public void voler()
    {
        Console.WriteLine("Le flamant rose s'envole.");
    }

    public void checkAge()
    {
        Console.WriteLine($"Le flamant rose a {this.age} ans.");
        // Nous ne pouvons pas accéder à une méthode "private" du parent
        //if (this.isOld()) {
        //    Console.WriteLine("C'est un vieil animal !");
        //}
    }
}

public class EncapsulationDemo : DemoMaker
{
    public void run()
    {
        AnimalEncapsulation animal = new AnimalEncapsulation("Jane", 38, 2);

        Console.WriteLine($"L'animal a {animal.getAge()} ans.");

        Console.Write("Nouvel âge de l'animal : ");
        animal.setAge(Convert.ToDouble(Console.ReadLine()));
        //animal.age = 32;
        Console.WriteLine($"L'animal a {animal.getAge()} ans.");
        //animal.isOld();

        OursEncapsulation ours = new OursEncapsulation("Teddy", 4, 4, "brun");

        Console.WriteLine($"C'est un ours {ours.getCouleur()}.");

        Console.Write("Nouvelle couleur de l'ours : ");
        ours.setCouleur(Console.ReadLine());
        Console.WriteLine($"C'est un ours {ours.getCouleur()}.");

        FlamantRoseEncapsulation flamantRose = new FlamantRoseEncapsulation("Fifi", 12, 2);
        flamantRose.checkAge();
    }
}