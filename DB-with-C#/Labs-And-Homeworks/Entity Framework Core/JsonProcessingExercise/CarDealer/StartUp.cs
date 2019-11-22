using System;
using System.IO;
using System.Linq;

using CarDealer.Data;
using CarDealer.Models;
using CarDealer.DTO.Import;
using CarDealer.DTO.Export;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
            string customersJson = File.ReadAllText(@"./../../../Datasets/customers.json");
            string salesJson = File.ReadAllText(@"./../../../Datasets/sales.json");

            //Console.WriteLine(ImportParts(db, suppliersJson));
            //Console.WriteLine(ImportParts(db, partsJson));
            //Console.WriteLine(ImportCars(db, carsJson));
            //Console.WriteLine(ImportCustomers(db, customersJson));
            //Console.WriteLine(ImportSales(db, salesJson));

            Console.WriteLine(GetSalesWithAppliedDiscount(db));
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

            context.SaveChanges();

            return $"Successfully imported {cars.Length}.";
        }

        // Problem 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            Customer[] customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);

            int customersCount = context.SaveChanges();

            return $"Successfully imported {customersCount}.";
        }

        // Problem 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            Sale[] sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);

            int salesCount = context.SaveChanges();

            return $"Successfully imported {salesCount}.";
        }

        // Problem 14. Export Ordered Customers 
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var orderedCustomers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new CustomerDto
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            string jsonExport = JsonConvert.SerializeObject(orderedCustomers, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });

            return jsonExport;
        }

        // Problem 15. Export Cars from make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsFromMakeToyota = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new MakeToyotaDto
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            string jsonExport = JsonConvert.SerializeObject(carsFromMakeToyota, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });

            return jsonExport;
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
                .ToList();

            string jsonExport = JsonConvert.SerializeObject(localSuppliers, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });

            return jsonExport;
        }

        // Problem 17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(c => new CarAndPartDto
                {
                    Car = new CarInfoDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    Parts = c.PartCars.Select(cp => new PartDto
                    {
                        Name = cp.Part.Name,
                        Price = $"{cp.Part.Price:F2}"
                    })
                    .ToArray()
                })
                .ToArray();

            string jsonExport = JsonConvert.SerializeObject(carsWithParts, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });

            return jsonExport;
        }

        // Problem 18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var totalSales = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new CustomerCarDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            string jsonExport = JsonConvert.SerializeObject(totalSales, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            });

            return jsonExport;
        }

        // Problem 19. Export Sales With Applied Discount 
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new SaleDto
                {
                    Car = new CarInfoDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    Price = $"{s.Car.PartCars.Sum(pc => pc.Part.Price):F2}",
                    PriceWithDiscount = $@"{s.Car.PartCars.Sum(pc => pc.Part.Price) 
                    - (s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100):F2}"
                })
                .ToList();

            string jsonExport = JsonConvert.SerializeObject(sales, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });

            return jsonExport;
        }
    }
}