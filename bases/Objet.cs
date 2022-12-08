namespace Cours.Bases;

using Classes;
using Engine;


public class ObjetDemo : DemoMaker
{
    public void run()
    {
        // Instanciation de la classe Oiseau dans l'objet exempleOiseau
        Oiseau exempleOiseau = new Oiseau("bleu", 22);
        // Appel de la méthode "voler" de la classe Oiseau instanciée
        exempleOiseau.voler();
    }
}