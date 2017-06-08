using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.PantsCommands
{
    public class PantsSearchCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ISqlDatabase database;

        public PantsSearchCommand(IWriter writer, IReader reader, ISqlDatabase database)
        {
            this.writer = writer;
            this.reader = reader;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            switch (parameters[0])
            {
                case "ListAllPants":
                    this.ListAllPants();
                    break;
                case "ListPantsByColor":
                    this.ListPantsByColor();
                    break;
                default: throw new ArgumentException("The provided command is not supported!");

            }

            return "Create command executed successfully";
        }

        private void ListAllPants()
        {
            var pantsCollection = this.database.Pants.ToList();

            foreach (var pants in pantsCollection)
            {
                this.writer.WriteLine($"Id: {pants.Id}, Brand: {pants.Brand.Name}, Model: {pants.Model.Name}, Color: {pants.Color.Name}, Type: {pants.Kind.Name}, Size: {pants.Size.Name}, Price: {pants.Price} EUR");
            }
            this.writer.WriteLine($"We have {pantsCollection.Count()} pairs of pants in total!");

            this.database.SaveChanges();
        }

        private void ListPantsByColor()
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
            var pantsCollection = this.database.Pants.ToList();
            var sortedByColor = pantsCollection.Where(j => j.Color.Name == (color));

            this.writer.WriteLine($"The {color} pantss are!");

            foreach (var pants in sortedByColor)
            {
                this.writer.WriteLine($"Id: {pants.Id}, Brand: {pants.Brand.Name}, Model: {pants.Model.Name}, Color: {pants.Color.Name}, Type: {pants.Kind.Name}, Size: {pants.Size.Name}, Price: {pants.Price} EUR");

            }
            this.writer.WriteLine($"We have {sortedByColor.Count()} pants with that color!");
            
            this.database.SaveChanges();
        }
    }
}
