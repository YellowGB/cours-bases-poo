namespace Cours.Bases;

using Engine;

// Classe abstraite
public abstract class Forme
{
    public abstract int GetAire();
}

// Classe concrète
public class Carre : Forme
{
    private int _cote;

    public Carre(int n) => _cote = n;

    // L'implémentation de la méthode "GetAire" est obligatoire pour éviter une erreur de compilation
    public override int GetAire()
    {
        return this._cote * this._cote;
    }
}

public class AbstractionDemo : IDemoMaker
{
    public void Run()
    {
        Carre carre = new Carre(4);
        Console.WriteLine($"Aire du carré : {carre.GetAire()}");
    }
}