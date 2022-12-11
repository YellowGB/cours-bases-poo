namespace Cours.Patterns;

using Engine;

// La classe "CreateurAbstrait" déclare la méthode factory qui doit retourner un objet d'une classe Produit
abstract class CreateurAbstrait
{
    public abstract IProduit MethodeFactory();

    public string UneOperation()
        {
            // Appeler la méthode factory pour créer un objet Produit.
            var produit = MethodeFactory();
            // Utiliser le Produit.
            var resultat = "CreateurAbstrait : Le même code CreateurAbstrait vient de fonctionner avec " + produit.Operation();

            return resultat;
        }
}

class CreateurConcret1 : CreateurAbstrait
{
    public override IProduit MethodeFactory()
        {
            return new ProduitConcret1();
        }
}

class CreateurConcret2 : CreateurAbstrait
{
    public override IProduit MethodeFactory()
    {
        return new ProduitConcret2();
    }
}

public interface IProduit
{
    string Operation();
}

class ProduitConcret1 : IProduit
{
    public string Operation()
    {
        return "{resultat de ProduitConcret1}";
    }
}

class ProduitConcret2 : IProduit
{
    public string Operation()
    {
        return "{resultat de ProduitConcret2}";
    }
}

class ClientFactory
{
    public void Main()
    {
        Console.WriteLine("App : Initialisée avec le CreateurConcret1.");
        CodeClient(new CreateurConcret1());
        
        Helpers.ConsoleSeparator();

        Console.WriteLine("App : Initialisée avec le CreateurConcret2.");
        CodeClient(new CreateurConcret2());
    }

    public void CodeClient(CreateurAbstrait createur)
    {
        // ...
        Console.WriteLine("ClientFactory : Je ne connais pas la classe Createur, mais cela fonctionne toujours.\n" + createur.UneOperation());
        // ...
    }
}

public class FactoryConceptDemo : IDemoMaker
{
    public void Run()
    {
        new ClientFactory().Main();
    }
}