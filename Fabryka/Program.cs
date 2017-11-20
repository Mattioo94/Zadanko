using Fabryka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml;

namespace Fabryka
{
    class Program
    {
        private static readonly object guard = new object();

        static void Main(string[] args)
        {
            List<IVehicle> vehicles = new List<IVehicle>();
            List<Thread> threads = new List<Thread>();

            var document = new XmlDocument();
            while(true)
            {
                try
                {
                    string input = Console.In.ReadToEnd();
                    document.LoadXml(input);

                    if (document.ChildNodes.Count != 1)
                        throw new Exception("Podaj poprawne dane");

                    XmlNode order = document.ChildNodes.Item(0);
                    foreach (XmlNode item in order.ChildNodes)
                    {
                        if (item.Attributes.Count != 1)
                            throw new Exception("Podaj poprawne dane");

                        while (threads.Where(x => x.IsAlive).Count() == 3) {
                            // No to czekamy skoro tylko 3 wątki.. ;)
                        }

                        threads.Add(new Thread(() =>
                        {
                            IVehicle vehicle = Factory.Build(item.Attributes[0].InnerText);
                            lock (guard)
                            {
                                vehicles.Add(vehicle);
                            }
                        }));
                        threads.Last().Start();
                    }

                    threads.ForEach(x => x.Join());
                    threads.Clear();

                    Console.WriteLine(vehicles.Sum(x => x?.Expense ?? 0));
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
