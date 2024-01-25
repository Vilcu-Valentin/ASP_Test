using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public OrderController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Order
    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetOrders()
    {
        return _context.Orders.Include(o => o.OrderProducts).ToList();
    }

    // GET: api/Order/{id}
    [HttpGet("{id}")]
    public ActionResult<Order> GetOrder(int id)
    {
        var order = _context.Orders.Include(o => o.OrderProducts).FirstOrDefault(o => o.OrderId == id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }

    // POST: api/Order
    [HttpPost]
    public ActionResult<Order> PostOrder(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
    }

    // POST: api/Order/{orderId}/Product/{productId}
    [HttpPost("{orderId}/Product/{productId}")]
    public ActionResult AddProductToOrder(int orderId, int productId)
    {
        var order = _context.Orders.Find(orderId);
        var product = _context.Products.Find(productId);

        if (order == null || product == null)
        {
            return NotFound();
        }

        var orderProduct = new OrderProduct
        {
            OrderId = orderId,
            ProductId = productId
        };

        _context.OrderProducts.Add(orderProduct);
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Order/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
        {
            return NotFound();
        }

        _context.Orders.Remove(order);
        _context.SaveChanges();

        return NoContent();
    }

}
