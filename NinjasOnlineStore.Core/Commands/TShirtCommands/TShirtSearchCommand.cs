using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.App.Core.Contracts;
using NinjasOnlineStore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NinjasOnlineStore.Core.Commands.TShirtCommands
{
    public class TShirtSearchCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ISqlDatabase database;

        public TShirtSearchCommand(IWriter writer, IReader reader, ISqlDatabase database)
        {
            this.writer = writer;
            this.reader = reader;
            this.database = database;
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
                case "ListTShirtsByColorAndSize":
                    this.ListTShirtsByColorAndSize();
                    break;
                case "ListTShirtsByPrice":
                    this.ListTShirtsByPrice();
                    break;
                case "ListTShirtsByGender":
                    this.ListTShirtsByGender();
                    break;
                default: throw new ArgumentException("The provided command is not supported!");
            }

            return "Create command executed successfully";
        }

        private void ListAllTShirts()
        {
            var tShirtsCollection = this.database.TShirts.ToList();

            foreach (var tShirt in tShirtsCollection)
            {
                this.writer.WriteLine($"Id: {tShirt.Id}, Brand: {tShirt.Brand.Name}, Model: {tShirt.Model.Name}, Color: {tShirt.Color.Name}, Type: {tShirt.Kind.Name}, Size: {tShirt.Size.Name}, Price: {tShirt.Price} EUR");
            }
            this.writer.WriteLine($"We have {tShirtsCollection.Count()} T-Shirts in total!");

            this.database.SaveChanges();
        }

        private void ListTShirtsByColor()
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
            var tShirtsCollection = this.database.TShirts.ToList();
            var sortedByColor = tShirtsCollection.Where(j => j.Color.Name == (color));

            this.writer.WriteLine($"{color} color T-Shirts are!");

            foreach (var tShirt in sortedByColor)
            {
                this.writer.WriteLine($"Id: {tShirt.Id}, Brand: {tShirt.Brand.Name}, Model: {tShirt.Model.Name}, Color: {tShirt.Color.Name}, Type: {tShirt.Kind.Name}, Size: {tShirt.Size.Name}, Price: {tShirt.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByColor.Count()} T-Shirts with that color!");

            this.database.SaveChanges();
        }

        private void ListTShirtsByColorAndSize()
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
            var tShirtsCollection = this.database.TShirts.ToList();
            var sortedByColor = tShirtsCollection.Where(t => (t.Color.Name == (color)) && (t.Size.Name == (size)));

            this.writer.WriteLine($"{color} color T-Shirts size {size} are!");

            foreach (var tShirt in sortedByColor)
            {
                this.writer.WriteLine($"Id: {tShirt.Id}, Brand: {tShirt.Brand.Name}, Model: {tShirt.Model.Name}, Color: {tShirt.Color.Name}, Type: {tShirt.Kind.Name}, Size: {tShirt.Size.Name}, Price: {tShirt.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByColor.Count()} T-Shirts with {color} color and size {size}!");

            this.database.SaveChanges();
        }

        private void ListTShirtsByPrice()
        {
            this.writer.WriteLine("Please choose minimum price:");
            var priceOne = decimal.Parse(this.reader.ReadLine());

            this.writer.WriteLine("Please choose maximum price:");
            var priceTwo = decimal.Parse(this.reader.ReadLine());

            var tShirtsCollection = this.database.TShirts.ToList();
            var sortedByPrice = tShirtsCollection.Where(t => (t.Price >= (priceOne)) && (t.Price <= (priceTwo)));

            this.writer.WriteLine($"T-Shirts with price between {priceOne} and {priceTwo} are!");

            foreach (var tShirt in sortedByPrice)
            {
                this.writer.WriteLine($"Id: {tShirt.Id}, Brand: {tShirt.Brand.Name}, Model: {tShirt.Model.Name}, Color: {tShirt.Color.Name}, Type: {tShirt.Kind.Name}, Size: {tShirt.Size.Name}, Price: {tShirt.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByPrice.Count()} T-Shirts in a price rage between {priceOne} and {priceTwo}!");

            this.database.SaveChanges();
        }

        private void ListTShirtsByGender()
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
            var tShirtsCollection = this.database.TShirts.ToList();
            var sortedByGender = tShirtsCollection.Where(t => t.Kind.Name == (gender));

            this.writer.WriteLine($"{gender} T-Shirts are!");

            foreach (var tShirt in sortedByGender)
            {
                this.writer.WriteLine($"Id: {tShirt.Id}, Brand: {tShirt.Brand.Name}, Model: {tShirt.Model.Name}, Color: {tShirt.Color.Name}, Type: {tShirt.Kind.Name}, Size: {tShirt.Size.Name}, Price: {tShirt.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByGender.Count()} {gender} T-Shirts!");

            this.database.SaveChanges();
        }
    }
}
