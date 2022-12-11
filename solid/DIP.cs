namespace Cours.Solid;

using Engine;

// Module de haut niveau, répond à la question "QUOI ?" (écrire)
class GestionnaireEvenement
{
    public void EnregistrerEvenement(ILogger logger, string evenement)
    {
        /*  Les modules de bas niveau sont les différentes classes "LoggerXXX"
            implémentant l'interface "ILogger" répondant à la question "COMMENT ?"
            (en écrivant dans un fichier, une base de données, un cache, etc.)
        */
        logger.Ecrire(evenement);
    }
}

public class DIPDemo : IDemoMaker
{
    public void Run()
    {
        GestionnaireEvenement gestionnaire = new GestionnaireEvenement();
        gestionnaire.EnregistrerEvenement(new LoggerFichier("/tmp/alert.log"), "Ceci est le dernier principe SOLID !");
    }
}