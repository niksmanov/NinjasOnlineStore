using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.SwimmingSuitCommands
{
    public class SwimmingSuitSearchCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ISqlDatabase database;

        public SwimmingSuitSearchCommand(IWriter writer, IReader reader, ISqlDatabase database)
        {
            this.writer = writer;
            this.reader = reader;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            switch (parameters[0])
            {
                case "ListAllSwimmingSuits":
                    this.ListAllSwimmingSuits();
                    break;
                case "ListSwimmingSuitsByColor":
                    this.ListSwimmingSuitsByColor();
                    break;
                default: throw new ArgumentException("The provided command is not supported!");
            }

            return "Create command executed successfully";
        }

        private void ListAllSwimmingSuits()
        {
            var swimmingSuitsCollection = this.database.SwimmingSuits.ToList();

            foreach (var swimmingSuits in swimmingSuitsCollection)
            {
                this.writer.WriteLine($"Id: {swimmingSuits.Id}, Brand: {swimmingSuits.Brand.Name}, Model: {swimmingSuits.Model.Name}, Color: {swimmingSuits.Color.Name}, Type: {swimmingSuits.Kind.Name}, Size: {swimmingSuits.Size.Name}, Price: {swimmingSuits.Price} EUR");
            }
            this.writer.WriteLine($"We have {swimmingSuitsCollection.Count()} swimming suits in total!");

            this.database.SaveChanges();
        }

        private void ListSwimmingSuitsByColor()
        {
            var colors = this.database.Colors.ToList();

            this.writer.WriteLine("Please choose one of the following colors:");
            foreach (var item in colors)
            {
                this.writer.Write(item.Name + ' ');
            }

            this.writer.WriteLine("");

            var color = this.reader.ReadLine();
            var colorToShow = colors.Select(c => c.Name == color);
            var swimmingSuitsCollection = this.database.SwimmingSuits.ToList();
            var sortedByColor = swimmingSuitsCollection.Where(j => j.Color.Name == (color));

            this.writer.WriteLine($"The {color} swimming suits are!");

            foreach (var swimmingSuits in sortedByColor)
            {
                this.writer.WriteLine($"Id: {swimmingSuits.Id}, Brand: {swimmingSuits.Brand.Name}, Model: {swimmingSuits.Model.Name}, Color: {swimmingSuits.Color.Name}, Type: {swimmingSuits.Kind.Name}, Size: {swimmingSuits.Size.Name}, Price: {swimmingSuits.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByColor.Count()} swimmingSuits with that color!");

            this.database.SaveChanges();

        }
    }
}
