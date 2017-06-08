using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.JSON;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.JacketCommands
{
    public class JacketSearchCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        public JacketSearchCommand(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public string Execute(IList<string> parameters)
        {
            switch (parameters[0])
            {
                case "ListAllJackets": this.ListAllJackets();
                    break;
                case "ListJacketsByColor": this.ListJacketsByColor();
                    break;
                default: throw new ArgumentException("The provided command is not supported!");
            }

            return "Create command executed successfully";
        }

        private void ListAllJackets()
        {
            var database = JsonImporter.SQLServerDbConnecton();
            var jacketsCollection = database.Jackets.ToList();

            foreach (var jacket in jacketsCollection)
            {
                this.writer.WriteLine($"Id: {jacket.Id}, Brand: {jacket.Brand.Name}, Model: {jacket.Model.Name}, Color: {jacket.Color.Name}, Type: {jacket.Kind.Name}, Size: {jacket.Size.Name}, Price: {jacket.Price} EUR");
            }
            this.writer.WriteLine($"We have {jacketsCollection.Count()} jackets in total!");

            database.SaveChanges();
        }

        private void ListJacketsByColor()
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
            var jacketsCollection = database.Jackets.ToList();
            var sortedByColor = jacketsCollection.Where(j => j.Color.Name == (color));

            this.writer.WriteLine($"The {color} jackets are!");

            foreach (var jacket in sortedByColor)
            {
                this.writer.WriteLine($"Id: {jacket.Id}, Brand: {jacket.Brand.Name}, Model: {jacket.Model.Name}, Color: {jacket.Color.Name}, Type: {jacket.Kind.Name}, Size: {jacket.Size.Name}, Price: {jacket.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByColor.Count()} jackets with that color!");

            database.SaveChanges();

        }
    }
}
