namespace Cours.Bases.Classes;

// Classe
public class Oiseau
{
    // Propriétés
    private string _couleur;
    private int _plumes;

    // Constructeur
    public Oiseau(string couleur, int plumes)
    {
        // Le mot-clé "this" fait référence à l'instance (l'objet courant)
        this._couleur = couleur;
        this._plumes = plumes;
    }

    // Méthode
    public void Voler()
    {
        Console.WriteLine($"L'oiseau {this._couleur} à {this._plumes} plumes vole.");
    }
}

public class Chat
{
    // Une méthode statique ne nécessite pas d'instance pour être exécutée
    public static void Info()
    {
        Console.WriteLine("Un chat est toujours mignon !");
    }
}