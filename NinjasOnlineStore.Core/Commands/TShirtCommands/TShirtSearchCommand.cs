using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.JSON;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.TShirtCommands
{
    public class TShirtSearchCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        public TShirtSearchCommand(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public string Execute(IList<string> parameters)
        {
            switch (parameters[0])
            {
                case "ListAllTShirts":
                    this.ListAllTShirts();
                    break;
                case "ListTShirtsByColor":
                    this.ListTShirtsByColor();
                    break;
                default: throw new ArgumentException("The provided command is not supported!");
            }

            return "Create command executed successfully";
        }

        private void ListAllTShirts()
        {
            var database = JsonImporter.SQLServerDbConnecton();
            var tShirtsCollection = database.TShirts.ToList();

            foreach (var tShirt in tShirtsCollection)
            {
                this.writer.WriteLine($"Id: {tShirt.Id}, Brand: {tShirt.Brand.Name}, Model: {tShirt.Model.Name}, Color: {tShirt.Color.Name}, Type: {tShirt.Kind.Name}, Size: {tShirt.Size.Name}, Price: {tShirt.Price} EUR");
            }
            this.writer.WriteLine($"We have {tShirtsCollection.Count()} T-Shirts in total!");

            database.SaveChanges();
        }

        private void ListTShirtsByColor()
        {
            var database = JsonImporter.SQLServerDbConnecton();
            var colors = database.Colors.ToList();

            this.writer.WriteLine("Please choose one of the following colors:");
            foreach (var item in colors)
            {
                this.writer.Write(item.Name + ' ');
            }

            this.writer.WriteLine("");

            var color = this.reader.ReadLine();
            var colorToShow = colors.Select(c => c.Name == color);
            var tShirtsCollection = database.TShirts.ToList();
            var sortedByColor = tShirtsCollection.Where(j => j.Color.Name == (color));

            this.writer.WriteLine($"The {color} T-Shirts are!");

            foreach (var tShirt in sortedByColor)
            {
                this.writer.WriteLine($"Id: {tShirt.Id}, Brand: {tShirt.Brand.Name}, Model: {tShirt.Model.Name}, Color: {tShirt.Color.Name}, Type: {tShirt.Kind.Name}, Size: {tShirt.Size.Name}, Price: {tShirt.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByColor.Count()} T-Shirt with that color!");

            database.SaveChanges();

        }
    }
}
