﻿using NinjasOnlineStore.App.Core.Commands.Contracts;
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
            switch (parameters[0])
            {
                case "ListAllShoes":
                    this.ListAllShoes();
                    break;
                case "ListShoesByColor":
                    this.ListShoesByColor();
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
    }
}
