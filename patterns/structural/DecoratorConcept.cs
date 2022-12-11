namespace Cours.Patterns;

using Engine;

// Le composant de base définit des opérations pouvant être altérées par des décorateurs
public abstract class Composant
{
    public abstract string Operation();
}

// Les composants concrets fournissent des implémentations par défaut des opérations
// Il peut y avoir plusieurs variantes de ces classes
class ComposantConcret : Composant
{
    public override string Operation()
    {
        return "ComposantConcret";
    }
}

/*  La classe "Décorateur" de base suit la même interface que les autres composants.
    Le but principal de cette classe est de définir l'interface recouvrant
    tous les décorateurs concrets. */
abstract class Decorateur : Composant
{
    protected Composant Composant;

    public Decorateur(Composant composant)
    {
        this.Composant = composant;
    }

    public void SetComposant(Composant composant)
    {
        this.Composant = composant;
    }

    // Le décorateur délègue tout le travail au composant le recouvrant
    public override string Operation()
    {
        if (this.Composant != null)
        {
            return this.Composant.Operation();
        }
        else
        {
            return string.Empty;
        }
    }
}

// Les décorateurs concrets appellent l'objet couvert et modifient son résultat d'une certaine manière
class DecorateurConcretA : Decorateur
{
    public DecorateurConcretA(Composant comp) : base(comp) {}

    /*  Les décorateurs peuvent appeler l'implémentation de l'opération du parent
        au lieu d'appeler l'objet couvert directement. Cette approche simplifie
        l'extension des classes "Decorateur" */
    public override string Operation()
    {
        return $"DecorateurConcretA({base.Operation()})";
    }
}

// Les décorateurs peuvent exécuter leur comportement avant ou après l'appel vers un objet couvert
class DecorateurConcretB : Decorateur
{
    public DecorateurConcretB(Composant comp) : base(comp) {}

    public override string Operation()
    {
        return $"DecorateurConcretB({base.Operation()})";
    }
}

public class ClientDecorateur
{
    /*  Le code client fonctionne avec tous les objets utilisant l'interface "Composant".
        De cette manière, il peut rester indépendant des classes concrètes
        des composants avec lesquels il travaille */
    public void ClientDecorateurCode(Composant Composant)
    {
        Console.WriteLine("RESULTAT : " + Composant.Operation());
    }
}

public class DecoratorConceptDemo : IDemoMaker
{
    public void Run()
    {
        ClientDecorateur client = new ClientDecorateur();

        var simple = new ComposantConcret();
        Console.WriteLine("Client : J'obtiens un composant simple :");
        client.ClientDecorateurCode(simple);

        Helpers.ConsoleSeparator();

        DecorateurConcretA decorateur1 = new DecorateurConcretA(simple);
        DecorateurConcretB decorateur2 = new DecorateurConcretB(decorateur1);
        Console.WriteLine("Client : Maintenant j'ai obtenu un composant décorateur :");
        client.ClientDecorateurCode(decorateur2);
    }
}