using Cours.Bases;
using Cours.Bases.Classes;
using Cours.Engine;

Console.Write("Demo : ");
string demo = Console.ReadLine()! + "Demo";

Type type = Type.GetType($"Cours.Bases.{demo}")!;
DemoMaker demoMaker = (DemoMaker) Activator.CreateInstance(type)!;

demoMaker.run();