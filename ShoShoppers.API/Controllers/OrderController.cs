using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoShoppers.Bll.Filters;
using ShoShoppers.Bll.Models.Orders;
using ShoShoppers.Bll.Services.Interfaces;
using ShoShoppers.Dal.Entities;
using System.ComponentModel.DataAnnotations;

namespace ShoShoppers.API.Controllers;

/// <summary>
///     Controller to add orders, update info about them, get them to view their info
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
[Produces("application/json")]
public sealed class OrderController : ControllerBase
{
    /// <summary>
    ///     Service for Order logic
    /// </summary>
    private readonly IOrderService _orderService;

    /// <summary>
    ///     Mapping Order entites
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    ///     Constructor for Order  controller
    /// </summary>
    /// <param name="orderService">Order service provider</param>
    /// <param name="mapper">Varialble for mapping entities DTO`s</param>
    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    /// <summary>
    ///     Adding order to database
    /// </summary>
    /// <param name="orderDto">Order which will be added</param>
    /// <returns>An ActionResult of OrderDto</returns>
    /// <status code="200">Succesfully added</status>
    /// <status code="201">Order which was created</status>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddOrderAsync([Required] OrderDto orderDto)
    {
        var orderCreated =
            await _orderService.AddAsync(_mapper.Map<Order>(orderDto));

        return CreatedAtRoute("GetOrder",
            new
            {
                orderCreated.Id,
                orderCreated.DateOfOrder,
                orderCreated.DateToFinishOrderAndDiliver,
                orderCreated.UserItems,
                orderCreated.UserEmail,
                orderCreated.UserName,
                orderCreated.UserSurname,
                orderCreated.PostOffice,
                orderCreated.UserPhoneNumber,
                orderCreated.IsOrderDone,
                orderCreated.OrderPrice
            }, orderCreated);
    }

    /// <summary>
    ///     Receiving all orders from database
    /// </summary>
    /// <param name="range">Selected pagination for Order entity</param>
    /// <param name="filter">Selected filter for Order entity</param>
    /// <param name="sort">Selected sorting for Order entity</param>
    /// <returns>List of filtered by options or not order</returns>
    /// <status code="200">Orders received</status>
    /// <status code="400">There is no orders</status>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetOrdersAsync(string? range = null, string? filter = null,
    string? sort = null)
    {
        var paginationHelper = await _orderService.GetAsync(range, filter, sort);

        if (paginationHelper.Entities == null) return BadRequest();

        Response.Headers.Add("Access-Control-Expose-Headers", "Content-Range");
        Response.Headers.Add("Content-Range",
            $"{typeof(Order).Name.ToLower()} {paginationHelper.From}-{paginationHelper.To}/{paginationHelper.Count}");

        return Ok(paginationHelper.Entities);
    }

    /// <summary>
    ///     Receiving order by id
    /// </summary>
    /// <param name="id">Id of the order</param>
    /// <returns>Order by id</returns>
    /// <status code="200">Order received</status>
    /// <status code="404">Order not found</status>
    [HttpGet("{id}", Name = "GetOrder")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOrderAsync(long id)
    {
        var orderFromRepo = await _orderService.FindAsync(new OrderFilter { Id = id });

        if (orderFromRepo == null) return NotFound();

        return Ok(orderFromRepo);
    }

    /// <summary>
    ///     Updating order`s fields
    /// </summary>
    /// <param name="id">Order`s id which will be updated</param>
    /// <param name="orderForUpdate">Updating current order on it`s options</param>
    /// <returns>An ActionResult</returns>
    /// <status code="200">Succesfully updated</status>
    /// <status code="500">There is no order by such id</status>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateOrderAsync([Required] long id,
        Order orderForUpdate)
    {
        var updatedOrder = _mapper.Map<Order>(orderForUpdate);
        updatedOrder.Id = id;
        await _orderService.UpdateAsync(updatedOrder);

        return Ok(orderForUpdate);
    }

    /// <summary>
    ///     Removing order from database by it`s id
    /// </summary>
    /// <param name="id">Order`s id</param>
    /// <returns>An ActionResult</returns>
    /// <status code="200">Succesfully removed</status>
    /// <status code="500">There is no order by such id</status>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteOrderAsync([Required] long id)
    {
        var orderForDelete = new Order { Id = id };
        await _orderService.DeleteAsync(orderForDelete);

        return Ok(orderForDelete);
    }

    /// <summary>
    ///     Generating unique token for user
    /// </summary>
    /// <returns>New guid for user</returns>
    [AllowAnonymous]
    [HttpGet("GenerateUserUniqueToken")]
    public async Task<IActionResult> GenerateUserUniqueTokenAsync()
    {
        return Ok(await _orderService.GenerateUserUniqueTokenAsync());
    }

    /// <summary>
    ///     Updating order by user token 
    /// </summary>
    /// <param name="orderDto">OrderDto with data of order</param>
    /// <returns>400 if token is empty or if entity by such token does not exists and 200 if everything ok</returns>
    [AllowAnonymous]
    [HttpPut("CreateOrderByUserToken")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateOrderByUserTokenAsync([Required] OrderDto orderDto)
    {
        await _orderService.CreateOrderAsync(_mapper.Map<Order>(orderDto));

        await _orderService.UpdatePinsAndShoppersAmmountAsync(orderDto);

        return Ok();
    }
}
