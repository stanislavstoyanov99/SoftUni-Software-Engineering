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

    using Data;
    using Models;
    using CarDealer.Dtos.Import;
    using CarDealer.Dtos.Export;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new CarDealerContext();

            //Mapper.Initialize(cfg => cfg.AddProfile(new CarDealerProfile()));

            //string suppliers = File.ReadAllText("./../../../Datasets/suppliers.xml");
            //string parts = File.ReadAllText("./../../../Datasets/parts.xml");
            //string cars = File.ReadAllText("./../../../Datasets/cars.xml");
            //string customers = File.ReadAllText("./../../../Datasets/customers.xml");
            //string sales = File.ReadAllText("./../../../Datasets/sales.xml");

            Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }

        // Problem 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var rootAttribute = new XmlRootAttribute("Suppliers");
            var xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), rootAttribute);

            using var stringReader = new StringReader(inputXml);

            ImportSupplierDto[] suppliersDto = (ImportSupplierDto[])xmlSerializer.Deserialize(stringReader);

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
            var xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), rootAttribute);

            using var stringReader = new StringReader(inputXml);

            ImportPartDto[] partsDto = (ImportPartDto[])xmlSerializer.Deserialize(stringReader);

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
            var xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), rootAttribute);

            using var stringReader = new StringReader(inputXml);

            var carsDto = (ImportCarDto[])xmlSerializer.Deserialize(stringReader);

            foreach (var carDto in carsDto)
            {
                var car = Mapper.Map<Car>(carDto);
                context.Cars.Add(car);

                var parts = carDto.Parts
                    .Where(imp => context.Parts.Any(p => p.Id == imp.Id))
                    .Select(p => p.Id)
                    .Distinct()
                    .ToList();

                foreach (var partId in parts)
                {
                    var partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    car.PartCars.Add(partCar);
                }
            }

            context.SaveChanges();

            int carsCount = carsDto.Length;

            return $"Successfully imported {carsCount}";
        }

        // Problem 12. Import Customers 
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var rootAttribute = new XmlRootAttribute("Customers");
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), rootAttribute);

            using var stringReader = new StringReader(inputXml);

            ImportCustomerDto[] customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(stringReader);

            var customers = Mapper.Map<Customer[]>(customersDto);
            context.Customers.AddRange(customers);

            int customersCount = context.SaveChanges();

            return $"Successfully imported {customersCount}";
        }

        // Problem 13. Import Sales 
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var rootAttribute = new XmlRootAttribute("Sales");
            var xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), rootAttribute);

            using var stringReader = new StringReader(inputXml);

            var salesDto = ((ImportSaleDto[])xmlSerializer.Deserialize(stringReader))
                .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                .ToArray();

            var sales = Mapper.Map<Sale[]>(salesDto);

            context.Sales.AddRange(sales);

            int salesCount = context.SaveChanges();

            return $"Successfully imported {salesCount}";
        }

        // Problem 14. Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carsWithDistance = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new CarInfoDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            var rootAttribute = new XmlRootAttribute("cars");
            var xmlSerializer = new XmlSerializer(typeof(CarInfoDto[]), rootAttribute);

            StringBuilder sb = new StringBuilder();

            using var stringWriter = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(stringWriter, carsWithDistance, namespaces);

            return sb.ToString().TrimEnd();
        }

        // Problem 15. Export Cars From Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var carsFromBmw = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new CarBmwDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            var rootAttribute = new XmlRootAttribute("cars");
            var xmlSerializer = new XmlSerializer(typeof(CarBmwDto[]), rootAttribute);

            StringBuilder sb = new StringBuilder();

            using var stringWriter = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(stringWriter, carsFromBmw, namespaces);

            return sb.ToString().TrimEnd();
        }

        // Problem 16. Export Local Suppliers 
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new LocalSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            var rootAttribute = new XmlRootAttribute("suppliers");
            var xmlSerializer = new XmlSerializer(typeof(LocalSupplierDto[]), rootAttribute);

            StringBuilder sb = new StringBuilder();

            using var stringWriter = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(stringWriter, localSuppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        // Problem 17. Export Cars With Their List Of Parts 
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new CarsWithPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                        .Select(pc => new PartDto
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .OrderByDescending(pc => pc.Price)
                        .ToArray()
                })
                .ToArray();

            var rootAttribute = new XmlRootAttribute("cars");
            var xmlSerializer = new XmlSerializer(typeof(CarsWithPartsDto[]), rootAttribute);

            StringBuilder sb = new StringBuilder();

            using var stringWriter = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(stringWriter, carsWithParts, namespaces);

            return sb.ToString().TrimEnd();
        }

        // Problem 18. Export Total Sales By Customer 
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new CustomerDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars
                        .Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            var rootAttribute = new XmlRootAttribute("customers");
            var xmlSerializer = new XmlSerializer(typeof(CustomerDto[]), rootAttribute);

            StringBuilder sb = new StringBuilder();

            using var stringWriter = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(stringWriter, customers, namespaces);

            return sb.ToString().TrimEnd();
        }

        // Problem 19. Export Sales With Applied Discount 
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscount = context.Sales
                .Select(s => new SaleDto
                {
                    Car = new CarDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) -
                    (s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100)
                })
                .ToArray();

            var rootAttribute = new XmlRootAttribute("sales");
            var xmlSerializer = new XmlSerializer(typeof(SaleDto[]), rootAttribute);

            StringBuilder sb = new StringBuilder();

            using var stringWriter = new StringWriter(sb);

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(stringWriter, salesWithDiscount, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}