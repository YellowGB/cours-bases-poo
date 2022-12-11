namespace Cours.Patterns;

using Engine;

class ContexteJeu
{
    private EtatJeu? _etat = null;

    public ContexteJeu(EtatJeu etat)
    {
        this.TransitionVers(etat);
    }

    public void TransitionVers(EtatJeu etat)
    {
        Console.WriteLine($"ContexteJeu : passage dans le mode {etat.GetType().Name}.");
        this._etat = etat;
        this._etat.SetContexte(this);
    }

    public void VersExploration()
    {
        this._etat.HandleExploration();
    }

    public void VersCombat()
    {
        this._etat.HandleCombat();
    }
}

abstract class EtatJeu
{
    protected ContexteJeu Context;

    public void SetContexte(ContexteJeu context)
    {
        this.Context = context;
    }

    public abstract void HandleCombat();

    public abstract void HandleExploration();
}

class EtatExploration : EtatJeu
{
    public override void HandleCombat()
    {
        this.Context.TransitionVers(new EtatCombat());
        Console.WriteLine("Le joueur entre en combat.");
    }

    public override void HandleExploration()
    {
        Console.WriteLine("Le joueur explore le monde.");
    }
}

class EtatCombat : EtatJeu
{
    public override void HandleCombat()
    {
        Console.Write("Le joueur est en combat.");
    }

    public override void HandleExploration()
    {
        this.Context.TransitionVers(new EtatExploration());
        Console.WriteLine("Le joueur sort de combat.");
    }
}

public class StateDemo : IDemoMaker
{
    public void Run()
    {
        var contexte = new ContexteJeu(new EtatExploration());

        Helpers.ConsoleSeparator();
        contexte.VersCombat();

        Helpers.ConsoleSeparator();
        contexte.VersExploration();
    }
}