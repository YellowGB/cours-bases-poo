namespace Cours.Solid;

using Engine;
using System.Linq;

// Classe ne respectant pas le principe de responsabilité unique
class LoggerOriginal
{
    protected string Type;

    public LoggerOriginal(string type)
    {
        string[] types = {"fichier", "bdd"};
        if (string.IsNullOrEmpty(type) || !types.Contains(type.ToLower())) {
            throw new ArgumentException("Type non pris en charge");
        }
        this.Type = type.ToLower();
    }

    public void LogDansFichier(string nomFichier, string information)
    {
        if (this.Type == "fichier" && !string.IsNullOrEmpty(nomFichier)) {
            Console.WriteLine($"Information enregistrée dans le fichier {nomFichier}.");
        }
    }

    public void LogDansBaseDonneesSQL(string chaineConnexion, string information)
    {
        if (this.Type == "bdd" && !string.IsNullOrEmpty(chaineConnexion)) {
            Console.WriteLine("Log dans base de données effectué.");
        }
    }
}

// Réusinage/refactoring
class LoggerFichier : ILogger
{
    protected string NomFichier;

    public LoggerFichier(string nomFichier)
    {
        if (string.IsNullOrEmpty(nomFichier)) {
            throw new ArgumentException("Le fichier est inaccessible en écriture");
        }
        this.NomFichier = nomFichier;
    }

    public void Ecrire(string information)
    {
        if (string.IsNullOrEmpty(information)) {
            throw new ArgumentException("Aucune information à loguer");
        }
        Console.WriteLine($"Information enregistrée dans le fichier {this.NomFichier}.");
    }
}

class LoggerBaseDonneesSQL : ILogger
{
    protected string ChaineConnexion;

    public LoggerBaseDonneesSQL(string chaineConnexion)
    {
        if (string.IsNullOrEmpty(chaineConnexion)) {
            throw new ArgumentException("La chaîne de connexion est vide");
        }
        this.ChaineConnexion = chaineConnexion;
    }

    public void Ecrire(string information)
    {
        if (string.IsNullOrEmpty(information)) {
            throw new ArgumentException("Aucune information à loguer");
        }
        Console.WriteLine("Log dans base de données effectué.");
    }
}

// Les classes "Logger" ont passé un contrat avec l'interface "ILogger" d'implémentation de la méthode "Ecrire"
interface ILogger
{
    public void Ecrire(string information);
}

public class SRPDemo : IDemoMaker
{
    public void Run()
    {
        Console.WriteLine("Démonstration du principe et suite dans l'exemple OCP");
    }
}