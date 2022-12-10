using Cours.Engine;

Console.Write("Demo : ");
string demo = Console.ReadLine()! + "Demo";

Type type = Type.GetType($"Cours.Bases.{demo}")!;
IDemoMaker demoMaker = (IDemoMaker) Activator.CreateInstance(type)!;

demoMaker.Run();