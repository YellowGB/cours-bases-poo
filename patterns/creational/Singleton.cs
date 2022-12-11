namespace Cours.Patterns;

using Engine;

/*  Un pays ne peut avoir qu'un seul gouvernement,
    sans tenir compte des identités personnelles des
    individus qui le compose. */
// Le singleton devrait toujours être "sealed" pour éviter l'héritage
public sealed class Gouvernement
{
    private string _ministreSante;
    private string _ministreJustice;
    private string _ministreInterieur;
    private string _ministreEconomie;
    // etc.

    /*  Le constructeur d'un singleton doit toujours être "private" pour empêcher
        un appel direct au constructeur depuis l'extérieur avec l'opérateur "new" */
    private Gouvernement(string ministreSante, string ministreJustice, string ministreInterieur, string ministreEconomie) {
        this._ministreSante = ministreSante;
        this._ministreJustice = ministreJustice;
        this._ministreInterieur = ministreInterieur;
        this._ministreEconomie = ministreEconomie;
    }

    // L'instance du singleton est stockée dans un champ statique
    private static Gouvernement? _instance;

    // La méthode statique  contrôlant l'accès au singleton
    public static Gouvernement GetInstance(string ministreSante = "Poste vacant", string ministreJustice = "Poste vacant", string ministreInterieur = "Poste vacant", string ministreEconomie = "Poste vacant")
    {
        if (_instance == null) {
            _instance = new Gouvernement(ministreSante, ministreJustice, ministreInterieur, ministreEconomie);
        }
        return _instance;
    }

    // Définition d'une logique métier
    public void NommerMinistreJustice(string? nom)
    {
        // _instance._ministreJustice = nom ?? "Poste vacant";

        this.InfoMinistreJustice();
    }

    public void InfoMinistreJustice()
    {
        // Console.WriteLine($"Ministre de la Justice : {_instance._ministreJustice}");
    }
}

public class SingletonDemo : IDemoMaker
{
    public void Run()
    {
        // Le code client
        Gouvernement g1 = Gouvernement.GetInstance();
        Gouvernement g2 = Gouvernement.GetInstance();

        if (g1 == g2) {
            Console.WriteLine("Le singleton fonctionne, les deux variables contiennent la même instance.");
        }
        else {
            Console.WriteLine("Le singleton a échoué, les deux variables ne contiennent pas la même instance.");
        }

        Helpers.ConsoleSeparator();

        g1.InfoMinistreJustice();
        Console.Write("Nommer un ou une ministre de la justice : ");
        string? ministre = Console.ReadLine();
        g1.NommerMinistreJustice(ministre);
    }
}