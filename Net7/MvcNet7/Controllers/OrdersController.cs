using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcNet7.Data;
using MvcNet7.Dto;
using MvcNet7.Helper;
using MvcNet7.Interfaces;
using MvcNet7.Models;
using LogLevel = MvcNet7.Interfaces.LogLevel;

namespace MvcNet7.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ILogRepository _logRepository;
        private readonly OrderContext _context;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        
        public OrdersController(ILogRepository logRepository,OrderContext context, IOrderRepository orderRepository, IMapper mapper)
        {
            _logRepository = logRepository;
            _context = context;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string sortOrder,
                                    string currentFilter,
                                    string searchString,
                                    int? pageNumber)
        {
            _logRepository.WriteLog($"OrdersController-Index", LogLevel.Info);
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            ViewData["ProductNameParm"] = sortOrder == "product_name" ? "product_name_desc" : "product_name";
            ViewData["CategoryNameParm"] = sortOrder == "category_name" ? "category_name_desc" : "category_name";
            ViewData["CustomerNameParm"] = sortOrder == "customer_name" ? "customer_name_desc" : "customer_name";
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            IQueryable<Order> orders = (await _orderRepository.GetAllOrders2()).AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                //orders = orders.Where(s => s.Customer.Name.Contains(searchString)
                //                       || s.Product.Name.Contains(searchString));
                orders = orders.Where(s => s.Product.Category.Name.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "product_name":
                    orders = orders.OrderBy(s => s.Product.Name);
                    break;
                case "product_name_desc":
                    orders = orders.OrderByDescending(s => s.Product.Name);
                    break;
                case "category_name":
                    orders = orders.OrderBy(s => s.Product.Category.Name);
                    break;
                case "category_name_desc":
                    orders = orders.OrderByDescending(s => s.Product.Category.Name);
                    break;
                case "customer_name":
                    orders = orders.OrderBy(s => s.Customer.Name);
                    break;
                case "customer_name_desc":
                    orders = orders.OrderByDescending(s => s.Customer.Name);
                    break;
                case "name_desc":
                    orders = orders.OrderByDescending(s => s.Product.Name);
                    break;
                case "Date":
                    orders = orders.OrderBy(s => s.OrderDate);
                    break;
                case "date_desc":
                    orders = orders.OrderByDescending(s => s.OrderDate);
                    break;
                default:
                    orders = orders.OrderBy(s => s.Product.Name);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Order>.CreateAsync(orders, pageNumber ?? 1, pageSize));
        }


        //it is get method
        public IActionResult AddOrder()
        {
            var customerQuery = _context.Customers.ToList();
            var productQuery = _context.Products.ToList();

            List<SelectListItem> customers = new List<SelectListItem>();
            List<SelectListItem> products = new List<SelectListItem>();
            if (customerQuery.Any())
                customerQuery.ForEach(item => customers.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() }));

            if (productQuery.Any())
                productQuery.ForEach(item => products.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() }));

            ViewBag.Customers = customers;
            ViewBag.Products = products;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync(OrderDto orderCreate)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                if (orderCreate == null)
                    return BadRequest(ModelState);

                var orderMap = _mapper.Map<Order>(orderCreate);

                if (!(await _orderRepository.CreateOrder(orderMap ?? new Order())))
                {
                    ModelState.AddModelError("", "Something went wrong while savin");
                    return StatusCode(500, ModelState);
                }

                TempData["msg"] = "Added successfully";
                return RedirectToAction("AddOrder");

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not added!!!";
                return View();
            }

        }
    }
}
