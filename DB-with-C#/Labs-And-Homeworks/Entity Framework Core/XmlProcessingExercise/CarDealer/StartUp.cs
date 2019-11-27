namespace CarDealer
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    using AutoMapper;
    using AutoMapper.Configuration;

    using Data;
    using Models;
    using CarDealer.Dtos.Import;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new CarDealerContext();

            Mapper.Initialize(cfg => cfg.AddProfile(new CarDealerProfile()));

            string suppliers = File.ReadAllText("./../../../Datasets/suppliers.xml");
            string parts = File.ReadAllText("./../../../Datasets/parts.xml");
            string cars = File.ReadAllText("./../../../Datasets/cars.xml");

            Console.WriteLine(ImportCars(db, cars));
        }

        // Problem 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var rootAttribute = new XmlRootAttribute("Suppliers");
            var xmlSerializer = new XmlSerializer(typeof(ImportSupplier[]), rootAttribute);

            using var stringReader = new StringReader(inputXml);

            ImportSupplier[] suppliersDto = (ImportSupplier[])xmlSerializer.Deserialize(stringReader);

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);
                context.Suppliers.Add(supplier);
            }

            int suppliersCount = context.SaveChanges();

            return $"Successfully imported {suppliersCount}";
        }

        // Problem 10. Import Parts 
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var rootAttribute = new XmlRootAttribute("Parts");
            var xmlSerializer = new XmlSerializer(typeof(ImportPart[]), rootAttribute);

            using var stringReader = new StringReader(inputXml);

            ImportPart[] partsDto = (ImportPart[])xmlSerializer.Deserialize(stringReader);

            foreach (var partDto in partsDto)
            {
                var supplier = context.Suppliers
                    .FirstOrDefault(s => s.Id == partDto.SupplierId);

                if (supplier != null)
                {
                    var part = Mapper.Map<Part>(partDto);
                    context.Parts.Add(part);
                }
            }

            int partsCount = context.SaveChanges();

            return $"Successfully imported {partsCount}";
        }

        // Problem 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var rootAttribute = new XmlRootAttribute("Cars");
            var xmlSerializer = new XmlSerializer(typeof(ImportCar[]), rootAttribute);

            using var stringReader = new StringReader(inputXml);

            var carsDto = (ImportCar[])xmlSerializer.Deserialize(stringReader);

            foreach (var carDto in carsDto)
            {
                var car = Mapper.Map<Car>(carDto);
                context.Cars.Add(car);

                foreach (var part in carDto.Parts.PartsId)
                {
                    var partCar = car.PartCars
                        .FirstOrDefault(pc => pc.PartId == part.Id);

                    var dbPart = context.Parts
                        .FirstOrDefault(p => p.Id == part.Id);

                    if (partCar == null && dbPart != null)
                    {
                        var partCarToAdd = new PartCar
                        {
                            CarId = car.Id,
                            PartId = part.Id
                        };

                        car.PartCars.Add(partCarToAdd);
                    }
                }
            }

            context.SaveChanges();

            int carsCount = carsDto.Length;

            return $"Successfully imported {carsCount}";
        }
    }
}