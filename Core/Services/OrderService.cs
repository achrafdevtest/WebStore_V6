using WebStore.Controllers;
using WebStore.Core.Interface;
using WebStore.Core.Models;

namespace WebStore.Core.Services;
public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IStoreRepository _storeRepository;   
    private readonly IStaffRepository _staffRepository;
    private readonly ILogger<OrderService> _logger;
    public OrderService(IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository,
        IProductRepository productRepository,
        ICustomerRepository customerRepository,
        IStoreRepository storeRepository,
        IStaffRepository staffRepository,
        ILoggerFactory loggerFactory
        )
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _orderItemRepository = orderItemRepository ?? throw new ArgumentNullException(nameof(orderItemRepository));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository)); 
        _storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository)); 
        _staffRepository = staffRepository ?? throw new ArgumentNullException(nameof(staffRepository)); 
        _logger = loggerFactory.CreateLogger<OrderService>();   
    }
    public async Task<int> CreateOrder(NewOrder newOrder)
    {
        var log = "[Order]";
        try
        {
            // Test : before connecting with Database
            if (newOrder == null)
                throw new InvalidOperationException(nameof(newOrder));

            if (newOrder.CustomerId <= 0)
                throw new InvalidOperationException("Client invalide");

            if (newOrder.StoreId <= 0)
                throw new InvalidOperationException("Société invalide");

            if (newOrder.StaffId <= 0)
                throw new InvalidOperationException("Vendeur invalide");

            if (newOrder.newOrderLines.Count <= 0)
                throw new InvalidOperationException("Impossible de créer la facture : Ligne facture est obligatoire");

            var quantity = newOrder.newOrderLines.Where(c => c.Quantity <= 0);
            if (quantity.Any())
                throw new InvalidOperationException("Quantité invalide");

            // Test : connecting with Database

            var customerExist = await _customerRepository.Exist(newOrder.CustomerId);

            if (!customerExist)
                _logger.LogInformation($"{log} - Check if customer id exist {newOrder.CustomerId}");
            throw new InvalidOperationException("Client n'existe pas");

            var storeExist = await _storeRepository.Exist(newOrder.StoreId);

            if (!storeExist)
                _logger.LogInformation($"{log} - Check if store id exist {newOrder.StoreId}");
            throw new InvalidOperationException("Société n'existe pas");

            var staff = await _staffRepository.Exist(newOrder.StaffId);
            if (!staff)
                _logger.LogInformation($"{log} - Check if staff id exist {newOrder.StaffId}");
            throw new InvalidOperationException("Vendeur n'existe pas");

            var orderNo = await _orderRepository.Create(newOrder);

            _logger.LogInformation($"{log} - Create new order {orderNo}");

            foreach (var item in newOrder.newOrderLines)
            {
                if (item.ProductId <= 0)
                    throw new InvalidOperationException("Impossible de créer la facture");

                var productIsExist = await _productRepository.Exist(item.ProductId);

                if (!productIsExist)
                    _logger.LogInformation($"{log}:{orderNo} - Check if product id exist{item.ProductId}");
                throw new InvalidOperationException("Impossible de charger le produit ");
            }
            await _orderItemRepository.CreateOrderItems(newOrder.newOrderLines, orderNo);

            _logger.LogInformation($"{log} - Create new order item {orderNo}");

            return orderNo;
        }
        catch (Exception ex)
        {
            _logger.LogError($"{log} : {ex.Message}");

            throw;
        }

      
    }
}

