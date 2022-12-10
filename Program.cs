using Cours.Engine;

Console.Write("Demo : ");
string demo = Console.ReadLine()! + "Demo";
string[] path = demo.Split('.');

Type type = Type.GetType($"Cours.{path[0]}.{path[1]}")!;
IDemoMaker demoMaker = (IDemoMaker) Activator.CreateInstance(type)!;

demoMaker.Run();