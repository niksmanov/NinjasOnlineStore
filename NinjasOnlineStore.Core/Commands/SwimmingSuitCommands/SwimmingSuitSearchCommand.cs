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
            switch (parameters[0].ToLower())
            {
                case "listallswimmingsuits":
                    this.ListAllSwimmingSuits();
                    break;
                case "listswimmingsuitsbycolor":
                    this.ListSwimmingSuitsByColor();
                    break;
                case "listswimmingsuitsbycolorandprice":
                    this.ListSwimmingSuitsByColorAndSize();
                    break;
                case "listswimmingsuitsbyprice":
                    this.ListSwimmingSuitsByPrice();
                    break;
                case "listswimmingsuitsbygender":
                    this.ListSwimmingSuitsByGender();
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
            this.writer.WriteLine($"We have {sortedByColor.Count()} swimming suits with that color!");

            this.database.SaveChanges();
        }

        private void ListSwimmingSuitsByColorAndSize()
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
            var swimmingSuitsCollection = this.database.SwimmingSuits.ToList();
            var sortedByColor = swimmingSuitsCollection.Where(s => (s.Color.Name == (color)) && (s.Size.Name == (size)));

            this.writer.WriteLine($"{color} color swimming suits  size {size} are!");

            foreach (var swimmingSuit in sortedByColor)
            {
                this.writer.WriteLine($"Id: {swimmingSuit.Id}, Brand: {swimmingSuit.Brand.Name}, Model: {swimmingSuit.Model.Name}, Color: {swimmingSuit.Color.Name}, Type: {swimmingSuit.Kind.Name}, Size: {swimmingSuit.Size.Name}, Price: {swimmingSuit.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByColor.Count()} swimming suits with {color} color and size {size}!");

            this.database.SaveChanges();
        }

        private void ListSwimmingSuitsByPrice()
        {
            this.writer.WriteLine("Please choose minimum price:");
            var priceOne = decimal.Parse(this.reader.ReadLine());

            this.writer.WriteLine("Please choose maximum price:");
            var priceTwo = decimal.Parse(this.reader.ReadLine());

            var swimmingSuitsCollection = this.database.SwimmingSuits.ToList();
            var sortedByPrice = swimmingSuitsCollection.Where(s => (s.Price >= (priceOne)) && (s.Price <= (priceTwo)));

            this.writer.WriteLine($"Swimming suits with price between {priceOne} and {priceTwo} are!");

            foreach (var swimmingSuit in sortedByPrice)
            {
                this.writer.WriteLine($"Id: {swimmingSuit.Id}, Brand: {swimmingSuit.Brand.Name}, Model: {swimmingSuit.Model.Name}, Color: {swimmingSuit.Color.Name}, Type: {swimmingSuit.Kind.Name}, Size: {swimmingSuit.Size.Name}, Price: {swimmingSuit.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByPrice.Count()} swimming suits in a price rage between {priceOne} and {priceTwo}!");

            this.database.SaveChanges();
        }

        private void ListSwimmingSuitsByGender()
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
            var swimmingSuitsCollection = this.database.SwimmingSuits.ToList();
            var sortedByGender = swimmingSuitsCollection.Where(s => s.Kind.Name == (gender));

            this.writer.WriteLine($"{gender} swimming suits are!");

            foreach (var swimmingSuit in sortedByGender)
            {
                this.writer.WriteLine($"Id: {swimmingSuit.Id}, Brand: {swimmingSuit.Brand.Name}, Model: {swimmingSuit.Model.Name}, Color: {swimmingSuit.Color.Name}, Type: {swimmingSuit.Kind.Name}, Size: {swimmingSuit.Size.Name}, Price: {swimmingSuit.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByGender.Count()} {gender} swimming suits!");

            this.database.SaveChanges();
        }
    }
}
