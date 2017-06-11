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
            switch (parameters[0].ToLower())
            {
                case "listallpants":
                    this.ListAllPants();
                    break;
                case "listpantsbycolor":
                    this.ListPantsByColor();
                    break;
                case "listpantsbycolorandsize":
                    this.ListPantsByColorAndSize();
                    break;
                case "listpantsbyprice":
                    this.ListPantsByPrice();
                    break;
                case "listpantsbygender":
                    this.ListPantsByGender();
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

        private void ListPantsByColorAndSize()
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
            var pantsCollection = this.database.Pants.ToList();
            var sortedByColor = pantsCollection.Where(p => (p.Color.Name == (color)) && (p.Size.Name == (size)));

            this.writer.WriteLine($"{color} color pants size {size} are!");

            foreach (var pants in sortedByColor)
            {
                this.writer.WriteLine($"Id: {pants.Id}, Brand: {pants.Brand.Name}, Model: {pants.Model.Name}, Color: {pants.Color.Name}, Type: {pants.Kind.Name}, Size: {pants.Size.Name}, Price: {pants.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByColor.Count()} pants with {color} color and size {size}!");

            this.database.SaveChanges();
        }

        private void ListPantsByPrice()
        {
            this.writer.WriteLine("Please choose minimum price:");
            var priceOne = decimal.Parse(this.reader.ReadLine());

            this.writer.WriteLine("Please choose maximum price:");
            var priceTwo = decimal.Parse(this.reader.ReadLine());

            var pantsCollection = this.database.Pants.ToList();
            var sortedByPrice = pantsCollection.Where(p => (p.Price >= (priceOne)) && (p.Price <= (priceTwo)));

            this.writer.WriteLine($"Pants with price between {priceOne} and {priceTwo} are!");

            foreach (var pants in sortedByPrice)
            {
                this.writer.WriteLine($"Id: {pants.Id}, Brand: {pants.Brand.Name}, Model: {pants.Model.Name}, Color: {pants.Color.Name}, Type: {pants.Kind.Name}, Size: {pants.Size.Name}, Price: {pants.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByPrice.Count()} pants in a price rage between {priceOne} and {priceTwo}!");

            this.database.SaveChanges();
        }

        private void ListPantsByGender()
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
            var pantsCollection = this.database.Pants.ToList();
            var sortedByGender = pantsCollection.Where(p => p.Kind.Name == (gender));

            this.writer.WriteLine($"{gender} pants are!");

            foreach (var pants in sortedByGender)
            {
                this.writer.WriteLine($"Id: {pants.Id}, Brand: {pants.Brand.Name}, Model: {pants.Model.Name}, Color: {pants.Color.Name}, Type: {pants.Kind.Name}, Size: {pants.Size.Name}, Price: {pants.Price} EUR");
            }
            this.writer.WriteLine($"We have {sortedByGender.Count()} {gender} pants!");

            this.database.SaveChanges();
        }
    }
}
