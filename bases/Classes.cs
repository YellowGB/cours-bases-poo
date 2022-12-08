namespace Cours.Bases.Classes;

// Classe
public class Oiseau
{
    // Propriétés
    private string couleur;
    private int plumes;

    // Constructeur
    public Oiseau(string couleur, int plumes)
    {
        this.couleur = couleur;
        this.plumes = plumes;
    }

    // Méthode
    public void voler()
    {
        Console.WriteLine($"L'oiseau {this.couleur} à {this.plumes} plumes vole.");
    }
}

public class Chat
{
    // Une méthode statique ne nécessite pas d'instance pour être exécutée
    public static void info()
    {
        Console.WriteLine("Un chat est toujours mignon !");
    }
}