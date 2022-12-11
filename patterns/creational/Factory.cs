namespace Cours.Patterns;

using Engine;

abstract class Monstre
{
    public abstract IMonstre FabriquerMonstre();

    public string UneAttaque()
        {
            var monstre = FabriquerMonstre();
            return $"Le monstre attaque de la manière suivante : {monstre.Attaque()}.";
        }
}

class MonstreMelee : Monstre
{
    public override IMonstre FabriquerMonstre()
        {
            return new AttaqueMelee();
        }
}

class MonstreDistance : Monstre
{
    public override IMonstre FabriquerMonstre()
    {
        return new AttaqueDistance();
    }
}

public interface IMonstre
{
    string Attaque();
}

class AttaqueMelee : IMonstre
{
    public string Attaque()
    {
        return "un coup de griffe provoquant 3 points de dégâts direct";
    }
}

class AttaqueDistance : IMonstre
{
    public string Attaque()
    {
        return "une flèche empoisonnée provoquant 1 point de dégâts par seconde pendant 5 secondes";
    }
}

class Joueur
{
    public void Main()
    {
        Console.WriteLine("Joueur : J'aperçois un monstre au corps-à-corps.");
        SubirAttaque(new MonstreMelee());
        
        Helpers.ConsoleSeparator();

        Console.WriteLine("Joueur : J'aperçois un monstre à distance.");
        SubirAttaque(new MonstreDistance());
    }

    public void SubirAttaque(Monstre monstre)
    {
        Console.WriteLine("Joueur: Je me fais attaquer par le monstre.\n" + monstre.UneAttaque());
    }
}

public class FactoryDemo : IDemoMaker
{
    public void Run()
    {
        new Joueur().Main();
    }
}