namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    using Data;
    using FastFood.Models;
    using ViewModels.Orders;
    using AutoMapper.QueryableExtensions;
    using System;
    using FastFood.Models.Enums;

    public class OrdersController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrdersController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var viewOrder = new CreateOrderViewModel
            {
                Items = this.context
                .Items
                .Select(x => x.Name)
                .ToList(),
                Employees = this.context
                .Employees
                .Select(x => x.Name)
                .ToList(),
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            var item = this.context.Items
                .FirstOrDefault(i => i.Name == model.ItemName);

            model.ItemId = item.Id;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var order = this.mapper.Map<Order>(model);

            order.DateTime = DateTime.UtcNow;
            order.Type = Enum.Parse<OrderType>(model.OrderType);

            order.OrderItems.Add(new OrderItem
            {
                ItemId = model.ItemId,
                Order = order,
                Quantity = model.Quantity
            });

            this.context.Orders.Add(order);

            this.context.SaveChanges();

            return this.RedirectToAction("All", "Orders");
        }

        public IActionResult All()
        {
            var orders = this.context.Orders
                .ProjectTo<OrderAllViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(orders);
        }
    }
}
