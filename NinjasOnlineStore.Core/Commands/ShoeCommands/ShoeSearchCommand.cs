using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.ShoeCommands
{
    public class ShoeSearchCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ISqlDatabase database;

        public ShoeSearchCommand(IWriter writer, IReader reader, ISqlDatabase database)
        {
            this.writer = writer;
            this.reader = reader;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            switch (parameters[0].ToLower())
            {
                case "listallshoes":
                    this.ListAllShoes();
                    break;
                case "listshoesbycolor":
                    this.ListShoesByColor();
                    break;
                case "listshoesbycolorandsize":
                    this.ListShoesByColorAndSize();
                    break;
                case "listshoesbyprice":
                    this.ListShoesByPrice();
                    break;
                case "listshoesbygender":
                    this.ListShoesByGender();
                    break;
                default: throw new ArgumentException("The provided command is not supported!");
            }

            return "Create command executed successfully";
        }

        private void ListAllShoes()
        {
            var shoesCollection = this.database.Shoes.ToList();

            foreach (var shoes in shoesCollection)
            {
                this.writer.WriteLine($"Id: {shoes.Id}, Brand: {shoes.Brand.Name}, Model: {shoes.Model.Name}, Color: {shoes.Color.Name}, Type: {shoes.Kind.Name}, Size: {shoes.Size.Name}, Price: {shoes.Price} EUR");
            }
            this.writer.WriteLine($"We have {shoesCollection.Count()} shoes in total!");

            this.database.SaveChanges();
        }

        private void ListShoesByColor()
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
            var shoesCollection = this.database.Shoes.ToList();
            var sortedByColor = shoesCollection.Where(s => s.Color.Name == (color));

            this.writer.WriteLine($"The {color} shoes are!");

            foreach (var shoes in sortedByColor)
            {
                this.writer.WriteLine($"Id: {shoes.Id}, Brand: {shoes.Brand.Name}, Model: {shoes.Model.Name}, Color: {shoes.Color.Name}, Type: {shoes.Kind.Name}, Size: {shoes.Size.Name}, Price: {shoes.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByColor.Count()} shoes with that color!");

            this.database.SaveChanges();
        }

        private void ListShoesByColorAndSize()
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
            var shoesCollection = this.database.Shoes.ToList();
            var sortedByColor = shoesCollection.Where(s => (s.Color.Name == (color)) && (s.Size.Name == (size)));

            this.writer.WriteLine($"{color} color shoes size {size} are!");

            foreach (var shoe in sortedByColor)
            {
                this.writer.WriteLine($"Id: {shoe.Id}, Brand: {shoe.Brand.Name}, Model: {shoe.Model.Name}, Color: {shoe.Color.Name}, Type: {shoe.Kind.Name}, Size: {shoe.Size.Name}, Price: {shoe.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByColor.Count()} shoes with {color} color and size {size}!");

            this.database.SaveChanges();
        }

        private void ListShoesByPrice()
        {
            this.writer.WriteLine("Please choose minimum price:");
            var priceOne = decimal.Parse(this.reader.ReadLine());

            this.writer.WriteLine("Please choose maximum price:");
            var priceTwo = decimal.Parse(this.reader.ReadLine());

            var shoesCollection = this.database.Shoes.ToList();
            var sortedByPrice = shoesCollection.Where(s => (s.Price >= (priceOne)) && (s.Price <= (priceTwo)));

            this.writer.WriteLine($"Shoes with price between {priceOne} and {priceTwo} are!");

            foreach (var shoe in sortedByPrice)
            {
                this.writer.WriteLine($"Id: {shoe.Id}, Brand: {shoe.Brand.Name}, Model: {shoe.Model.Name}, Color: {shoe.Color.Name}, Type: {shoe.Kind.Name}, Size: {shoe.Size.Name}, Price: {shoe.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByPrice.Count()} shoes in a price rage between {priceOne} and {priceTwo}!");

            this.database.SaveChanges();
        }

        private void ListShoesByGender()
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
            var shoesCollection = this.database.Shoes.ToList();
            var sortedByGender = shoesCollection.Where(s => s.Kind.Name == (gender));

            this.writer.WriteLine($"{gender} shoes are!");

            foreach (var shoe in sortedByGender)
            {
                this.writer.WriteLine($"Id: {shoe.Id}, Brand: {shoe.Brand.Name}, Model: {shoe.Model.Name}, Color: {shoe.Color.Name}, Type: {shoe.Kind.Name}, Size: {shoe.Size.Name}, Price: {shoe.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByGender.Count()} {gender} shoes!");

            this.database.SaveChanges();
        }
    }
}
