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
    public OrderService(IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository,
        IProductRepository productRepository,
        ICustomerRepository customerRepository,
        IStoreRepository storeRepository,
        IStaffRepository staffRepository
        )
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _orderItemRepository = orderItemRepository ?? throw new ArgumentNullException(nameof(orderItemRepository));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository)); 
        _storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository)); 
        _staffRepository = staffRepository ?? throw new ArgumentNullException(nameof(staffRepository)); 
    }
    public async Task<int> CreateOrder(NewOrder newOrder)
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
        if(!customerExist)
            throw new InvalidOperationException("Client n'existe pas");
        var storeExist = await _storeRepository.Exist(newOrder.StoreId);
        if (!storeExist)
            throw new InvalidOperationException("Société n'existe pas");

        var staff = await _staffRepository.Exist(newOrder.StaffId);
        if (!staff)
            throw new InvalidOperationException("Vendeur n'existe pas");

        var orderNo = await _orderRepository.Create(newOrder);

        foreach (var item in newOrder.newOrderLines)
        {
            if (item.ProductId <= 0)
                throw new InvalidOperationException("Impossible de créer la facture");

            var productIsExist = await _productRepository.Exist(item.ProductId);

            if (!productIsExist)
                throw new InvalidOperationException("Impossible de charger le produit ");
        }
        await _orderItemRepository.CreateOrderItems(newOrder.newOrderLines, orderNo);

        return orderNo;
    }
}

