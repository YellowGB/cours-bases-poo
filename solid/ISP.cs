namespace Cours.Solid;

using Engine;

// Interface ne respectant pas le principe de séparation des interfaces
interface IAnimal
{
    public void Voler();
    public void Nager();
}

class BaleineOriginal : IAnimal
{
    public void Voler()
    {
        throw new Exception("Je ne sais pas voler !");
    }

    public void Nager()
    {
        Console.WriteLine("Je nage.");
    }
}

class Ecureil : IAnimal
{
    public void Voler()
    {
        throw new Exception("Je ne sais pas voler !");
    }

    public void Nager()
    {
        throw new Exception("Je ne sais pas nager !");
    }
}

// Interfaces séparées, respectant le principe IS (Interface Segregation)
interface IAnimalNageur
{
    public void Nager();
}

interface IAnimalVolant
{
    public void Voler();
}

// La classe se sert dans la liste des interfaces qu'elle a besoin d'implémenter
class Baleine : IAnimalNageur
{
    public void Nager()
    {
        Console.WriteLine("Je nage.");
    }
}

public class ISPDemo : IDemoMaker
{
    public void Run()
    {
        // Première implémentation problématique
        BaleineOriginal baleineOriginal = new BaleineOriginal();
        // baleineOriginal.Voler();
        baleineOriginal.Nager();

        Helpers.ConsoleSeparator();

        // Deuxième implémentation problématique
        Ecureil ecureil = new Ecureil();
        // ecureil.Voler();
        // ecureil.Nager();

        Helpers.ConsoleSeparator();

        // Nouvelle classe n'implementant que ce qui lui correspond
        Baleine baleine = new Baleine();
        baleine.Nager();
    }
}