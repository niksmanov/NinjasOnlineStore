using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.JacketCommands
{
    public class JacketSearchCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ISqlDatabase database;

        public JacketSearchCommand(IWriter writer, IReader reader, ISqlDatabase database)
        {
            this.writer = writer;
            this.reader = reader;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            switch (parameters[0])
            {
                case "ListAllJackets": this.ListAllJackets();
                    break;
                case "ListJacketsByColor": this.ListJacketsByColor();
                    break;
                case "ListJacketsByColorAndSize": this.ListJacketsByColorAndSize();
                    break;
                case "ListJacketsByPrice": this.ListJacketsByPrice();
                    break;
                case "ListJacketsByGender": this.ListJacketsByGender();
                    break;
                default: throw new ArgumentException("The provided command is not supported!");
            }

            return "Create command executed successfully";
        }

        private void ListAllJackets()
        {
            var jacketsCollection = this.database.Jackets.ToList();

            foreach (var jacket in jacketsCollection)
            {
                this.writer.WriteLine($"Id: {jacket.Id}, Brand: {jacket.Brand.Name}, Model: {jacket.Model.Name}, Color: {jacket.Color.Name}, Type: {jacket.Kind.Name}, Size: {jacket.Size.Name}, Price: {jacket.Price} EUR");
            }
            this.writer.WriteLine($"We have {jacketsCollection.Count()} jackets in total!");

            this.database.SaveChanges();
        }

        private void ListJacketsByColor()
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
            var jacketsCollection = this.database.Jackets.ToList();
            var sortedByColor = jacketsCollection.Where(j => j.Color.Name == (color));

            this.writer.WriteLine($"{color} color jackets are!");

            foreach (var jacket in sortedByColor)
            {
                this.writer.WriteLine($"Id: {jacket.Id}, Brand: {jacket.Brand.Name}, Model: {jacket.Model.Name}, Color: {jacket.Color.Name}, Type: {jacket.Kind.Name}, Size: {jacket.Size.Name}, Price: {jacket.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByColor.Count()} jackets with that color!");

            this.database.SaveChanges();
        }

        private void ListJacketsByColorAndSize()
        {
            var colors = this.database.Colors.ToList();
            var sizes = this.database.Sizes.ToList();

            this.writer.WriteLine("Please choose one of the following colors:");
            foreach (var item in colors)
            {
                this.writer.Write(item.Name + ' ');
            }
            this.writer.WriteLine("");
            var color = this.reader.ReadLine();

            this.writer.WriteLine("Please choose one of the following sizes:");
            foreach (var item in sizes)
            {
                this.writer.Write(item.Name + ' ');
            }
            this.writer.WriteLine("");
            var size = this.reader.ReadLine();

            var colorToShow = colors.Select(c => c.Name == color);
            var sizeToShow = sizes.Select(s => s.Name == size);
            var jacketsCollection = this.database.Jackets.ToList();
            var sortedByColor = jacketsCollection.Where(j => (j.Color.Name == (color)) && (j.Size.Name == (size)));

            this.writer.WriteLine($"{color} color jackets size {size} are!");

            foreach (var jacket in sortedByColor)
            {
                this.writer.WriteLine($"Id: {jacket.Id}, Brand: {jacket.Brand.Name}, Model: {jacket.Model.Name}, Color: {jacket.Color.Name}, Type: {jacket.Kind.Name}, Size: {jacket.Size.Name}, Price: {jacket.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByColor.Count()} jackets with {color} color and size {size}!");

            this.database.SaveChanges();
        }

        private void ListJacketsByPrice()
        {
            this.writer.WriteLine("Please choose minimum price:");
            var priceOne = decimal.Parse(this.reader.ReadLine());

            this.writer.WriteLine("Please choose maximum price:");
            var priceTwo = decimal.Parse(this.reader.ReadLine());

            var jacketsCollection = this.database.Jackets.ToList();
            var sortedByPrice = jacketsCollection.Where(j => (j.Price >= (priceOne)) && (j.Price <= (priceTwo)));

            this.writer.WriteLine($"Jackets with price between {priceOne} and {priceTwo} are!");

            foreach (var jacket in sortedByPrice)
            {
                this.writer.WriteLine($"Id: {jacket.Id}, Brand: {jacket.Brand.Name}, Model: {jacket.Model.Name}, Color: {jacket.Color.Name}, Type: {jacket.Kind.Name}, Size: {jacket.Size.Name}, Price: {jacket.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByPrice.Count()} jackets in a price rage between {priceOne} and {priceTwo}!");

            this.database.SaveChanges();
        }

        private void ListJacketsByGender()
        {
            var genders = this.database.Kinds.ToList();

            this.writer.WriteLine("Please choose gender:");
            foreach (var item in genders)
            {
                this.writer.Write(item.Name + ' ');
            }

            this.writer.WriteLine("");

            var gender = this.reader.ReadLine();
            var genderToShow = genders.Select(g => g.Name == gender);
            var jacketsCollection = this.database.Jackets.ToList();
            var sortedByGender = jacketsCollection.Where(j => j.Kind.Name == (gender));

            this.writer.WriteLine($"{gender} jackets are!");

            foreach (var jacket in sortedByGender)
            {
                this.writer.WriteLine($"Id: {jacket.Id}, Brand: {jacket.Brand.Name}, Model: {jacket.Model.Name}, Color: {jacket.Color.Name}, Type: {jacket.Kind.Name}, Size: {jacket.Size.Name}, Price: {jacket.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByGender.Count()} {gender} jackets!");

            this.database.SaveChanges();
        }
    }
}
