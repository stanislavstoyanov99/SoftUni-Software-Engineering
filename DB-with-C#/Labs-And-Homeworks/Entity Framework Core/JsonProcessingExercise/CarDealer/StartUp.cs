using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using AutoMapper;

using CarDealer.Data;
using CarDealer.Models;

using Newtonsoft.Json;
using CarDealer.DTO.Import;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new CarDealerContext();

            string suppliersJson = File.ReadAllText(@"./../../../Datasets/suppliers.json");
            string partsJson = File.ReadAllText(@"./../../../Datasets/parts.json");
            string carsJson = File.ReadAllText(@"./../../../Datasets/cars.json");

            //Console.WriteLine(ImportParts(db, suppliersJson));
            //Console.WriteLine(ImportParts(db, partsJson));
            Console.WriteLine(ImportCars(db, carsJson));
        }

        // Problem 09. Import Suppliers 
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            Supplier[] suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);

            int suppliersCount = context.SaveChanges();

            return $"Successfully imported {suppliersCount}.";
        }

        // Problem 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);

            int partsCount = context.SaveChanges();

            return $"Successfully imported {partsCount}.";
        }

        // Problem 11. Import Cars 
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            CarDto[] cars = JsonConvert.DeserializeObject<CarDto[]>(inputJson);

            foreach (var carDto in cars)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partId in carDto.PartsId)
                {
                    if (context.Cars.FirstOrDefault(c => c.Id == car.Id) == null)
                    {
                        PartCar partCar = new PartCar
                        {
                            CarId = car.Id,
                            PartId = partId
                        };

                        if (car.PartCars.FirstOrDefault(p => p.PartId == partId) == null)
                        {
                            context.PartCars.Add(partCar);
                        }
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {cars.Length}.";
        }
    }
}