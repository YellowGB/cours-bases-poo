namespace Cours.Solid;

using Engine;

public class OCPDemo : IDemoMaker
{
    public void Run()
    {
        // Première version
        Console.Write("Type de log : ");
        string type = Console.ReadLine()!;

        LoggerOriginal loggerOriginal = new LoggerOriginal(type);

        // Uniquement ouvert à la modification
        if (type == "fichier") {
            loggerOriginal.LogDansFichier("/tmp/alert.log", "[ALERT] Une alerte a été loguée ici.");
        }
        else if (type == "bdd") {
            loggerOriginal.LogDansBaseDonneesSQL("Server=(localdb)\\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb", "[ALERT] Une alerte a été loguée ici.");
        }

        Helpers.ConsoleSeparator();

        // Version SRP
        Console.Write("Type de log : ");
        type = Console.ReadLine()!;

        ILogger loggerSRP;

        // Ouvert à l'extension
        if (type == "fichier") {
            loggerSRP = new LoggerFichier("/tmp/alert.log");
        }
        else if (type == "bdd") {
            loggerSRP = new LoggerBaseDonneesSQL("Server=(localdb)\\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb");
        }
        else {
            return;
        }

        // Fermé à la modification
        loggerSRP.Ecrire("[ALERT] Une alerte a été loguée ici.");
    }
}