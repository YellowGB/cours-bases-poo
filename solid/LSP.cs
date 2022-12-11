namespace Cours.Solid;

using Engine;

public class LSPDemo : IDemoMaker
{
    public void Run()
    {
        string information = "[ALERT] Une alerte a été loguée ici.";
        /*  Remplacer "ILogger" par "LoggerFichier" ou "LoggerBaseDonneesSQL"
            ne compromet pas la bonne exécution du programme.
            L'appel peut donc se faire avec n'importe quelle classe implémentant l'interface. */
        this.EcrireInformation(new LoggerFichier("/tmp/alert.log"), information);
        this.EcrireInformation(new LoggerBaseDonneesSQL("Server=(localdb)\\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb"), information);
    }

    private void EcrireInformation(ILogger logger, string information)
    {
        logger.Ecrire(information);
    }
}