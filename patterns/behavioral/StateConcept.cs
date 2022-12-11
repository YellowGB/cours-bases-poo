namespace Cours.Patterns;

using Engine;

/*  Le "Contexte" définit l'interface présentant un intérêt pour les clients.
    Il maintient également une référence à une instance d'une sous-classe "Etat"
    qui représente l'état actuel du contexte */
class Contexte
{
    // Une référence à l'état actuel du contexte
    private Etat? _etat = null;

    public Contexte(Etat etat)
    {
        this.TransitionVers(etat);
    }

    // Le contexte permet de changer l'objet "Etat" lors de l'exécution (runtime).
    public void TransitionVers(Etat etat)
    {
        Console.WriteLine($"Contexte : Transition vers {etat.GetType().Name}.");
        this._etat = etat;
        this._etat.SetContexte(this);
    }

    // Le contexte délègue une partie de son comportement à l'objet "Etat" courant
    public void Requete1()
    {
        this._etat.Handle1();
    }

    public void Requete2()
    {
        this._etat.Handle2();
    }
}

/*  La classe de base "Etat" déclare les méthodes que tous les Etats concrets
    doivent implémenter et fournit également une référence (backreference) à
    l'objet "Contexte", associé à l'état. Cette référence peut être utilisée
    par les "Etats" pour faire transitionner le "Contexte" vers un autre "Etat" */
abstract class Etat
{
    protected Contexte Context;

    public void SetContexte(Contexte context)
    {
        this.Context = context;
    }

    public abstract void Handle1();

    public abstract void Handle2();
}

// Les "Etats" concrets implémentent différents comportements, associés à un état du "Contexte"
class EtatConcretA : Etat
{
    public override void Handle1()
    {
        Console.WriteLine("EtatConcretA se charge de requete1.");
        Console.WriteLine("EtatConcretA veut changer l'état du contexte.");
        this.Context.TransitionVers(new EtatConcretB());
    }

    public override void Handle2()
    {
        Console.WriteLine("EtatConcretA se charge de requete2.");
    }
}

class EtatConcretB : Etat
{
    public override void Handle1()
    {
        Console.Write("EtatConcretB se charge de requete1.");
    }

    public override void Handle2()
    {
        Console.WriteLine("EtatConcretB se charge de requete2.");
        Console.WriteLine("EtatConcretB veut changer l'état du contexte.");
        this.Context.TransitionVers(new EtatConcretA());
    }
}

public class StateConceptDemo : IDemoMaker
{
    public void Run()
    {
        // Le code client
        var contexte = new Contexte(new EtatConcretA());

        Helpers.ConsoleSeparator();
        contexte.Requete1();

        Helpers.ConsoleSeparator();
        contexte.Requete2();
    }
}