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
