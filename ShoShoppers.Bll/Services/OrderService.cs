using MailBodyPack;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShoShoppers.Bll.Filters;
using ShoShoppers.Bll.Models.Error;
using ShoShoppers.Bll.Models.HelperModels;
using ShoShoppers.Bll.Models.Orders;
using ShoShoppers.Bll.Services.Interfaces;
using ShoShoppers.Dal.Contexts;
using ShoShoppers.Dal.Entities;
using ShoShoppers.Dal.Entities.ItemsForSale;
using System.Net;

namespace ShoShoppers.Bll.Services;

/// <summary>
///     Class which decribes all methods to work with Order Services
/// </summary>
public sealed class OrderService : BaseService<Order, OrderFilter>, IOrderService
{
    /// <summary>
    ///     Service for Email logic
    /// </summary>
    private readonly IEMailService _emailService;

    /// <summary>
    ///     Kate`s email
    /// </summary>
    private const string AdminEmail = "katyabroa@gmail.com";

    /// <summary>
    ///     Constructor for Order Service
    /// </summary>
    /// <param name="context">Database context</param>
    /// <param name="emailService">Service for email logic</param>
    /// <param name="pinService">Service for pin logic</param>
    /// <param name="shopperService">Service for shopper logic</param>
    public OrderService(ShoShoppersContext context, IEMailService emailService) : base(context)
    {
        _emailService = emailService;
    }

    /// <summary>
    ///     Getting entities from database by selecting filter
    /// </summary>
    /// <param name="range">Selected pagination for the entity</param>
    /// <param name="filter">Selected filter for the entity</param>
    /// <param name="sort">Selected sorting for the entity</param>
    /// <returns>Pagination Helper of the entity</returns>
    public override async ValueTask<PaginationHelper<Order>> GetAsync(string? range = null, string? filter = null,
        string? sort = null)
    {
        var query = Context.Orders.AsQueryable();

        OrderFilter? filterVal = null;

        if (!string.IsNullOrEmpty(filter)) filterVal = JsonConvert.DeserializeObject<OrderFilter>(filter);

        if (filterVal != null)
            query = query.Where(f => !filterVal.Id.HasValue || f.Id == filterVal.Id)
                .Where(f => string.IsNullOrEmpty(filterVal.UserItems) ||
                            f.UserItems.ToLower().Contains(filterVal.UserItems.ToLower()))
                .Where(f => string.IsNullOrEmpty(filterVal.USerEmail) ||
                            f.UserEmail.ToLower().Contains(filterVal.USerEmail.ToLower()))
                .Where(f => string.IsNullOrEmpty(filterVal.UserName) ||
                            f.UserName.ToLower().Contains(filterVal.UserName.ToLower()))
                .Where(f => string.IsNullOrEmpty(filterVal.UserSurname) ||
                            f.UserSurname.ToLower().Contains(filterVal.UserSurname.ToLower()))
                .Where(f => string.IsNullOrEmpty(filterVal.PostOffice) ||
                            f.PostOffice.ToLower().Contains(filterVal.PostOffice.ToLower()))
                .Where(f => string.IsNullOrEmpty(filterVal.UserPhoneNumber) ||
                            f.UserPhoneNumber.ToLower().Contains(filterVal.UserPhoneNumber.ToLower()))
                .Where(f => !filterVal.DateOfOrder.HasValue || f.DateOfOrder == filterVal.DateOfOrder)
                .Where(f => !filterVal.DateToFinishOrderAndDiliver.HasValue ||
                            f.DateToFinishOrderAndDiliver == filterVal.DateToFinishOrderAndDiliver)
                .Where(f => !filterVal.IsOrderDone.HasValue || f.IsOrderDone == filterVal.IsOrderDone)
                .Where(f => !filterVal.IsOrderMade.HasValue || f.IsOrderMade == filterVal.IsOrderMade)
                .Where(f => !filterVal.OrderPrice.HasValue || f.OrderPrice == filterVal.OrderPrice)
                .Where(f => string.IsNullOrEmpty(filterVal.UserUniqueToken) ||
                            f.UserUniqueToken.ToLower().Contains(filterVal.UserUniqueToken.ToLower()));

        query = SetSorting(query, sort);

        return await SetPaginationAsync(query, query.Count(), range);
    }

    /// <summary>
    ///     Checking existing of the entitiy from database by selecting filter
    /// </summary>
    /// <param name="filter">Filter for the entity</param>
    /// <returns>True if entity exist, false if no</returns>
    public override async Task<bool> IsExistAsync(OrderFilter filter)
    {
        return await Context.Orders.AnyAsync(f => (!filter.Id.HasValue || f.Id == filter.Id)
                && (string.IsNullOrEmpty(filter.UserItems) ||
                    f.UserItems.ToLower().Contains(filter.UserItems.ToLower()))
                && (string.IsNullOrEmpty(filter.USerEmail) ||
                    f.UserEmail.ToLower().Contains(filter.USerEmail.ToLower()))
                && (string.IsNullOrEmpty(filter.UserName) ||
                    f.UserName.ToLower().Contains(filter.UserName.ToLower()))
                && (string.IsNullOrEmpty(filter.UserSurname) ||
                    f.UserSurname.ToLower().Contains(filter.UserSurname.ToLower()))
                && (string.IsNullOrEmpty(filter.PostOffice) ||
                    f.PostOffice.ToLower().Contains(filter.PostOffice.ToLower()))
                && (string.IsNullOrEmpty(filter.UserPhoneNumber) ||
                    f.UserPhoneNumber.ToLower().Contains(filter.UserPhoneNumber.ToLower()))
                && (!filter.DateOfOrder.HasValue || f.DateOfOrder == filter.DateOfOrder)
                && (!filter.DateToFinishOrderAndDiliver.HasValue ||
                    f.DateToFinishOrderAndDiliver == filter.DateToFinishOrderAndDiliver)
                && (!filter.IsOrderDone.HasValue || f.IsOrderDone == filter.IsOrderDone)
                && (!filter.IsOrderMade.HasValue || f.IsOrderMade == filter.IsOrderMade)
                && (!filter.OrderPrice.HasValue || f.OrderPrice == filter.OrderPrice)
                && (string.IsNullOrEmpty(filter.UserUniqueToken) ||
                    f.UserUniqueToken.ToLower().Contains(filter.UserUniqueToken.ToLower())));
    }

    /// <summary>
    ///     Searching of the entitiy from database by selecting filter
    /// </summary>
    /// <param name="filter">Filter for the entity</param>
    /// <returns>Found entity</returns>
    public override async Task<Order?> FindAsync(OrderFilter filter)
    {
        var query = Context.Orders.AsQueryable();

        if (filter != null)
            query = query.Where(f => !filter.Id.HasValue || f.Id == filter.Id)
               .Where(f => string.IsNullOrEmpty(filter.UserItems) ||
                           f.UserItems.ToLower().Contains(filter.UserItems.ToLower()))
               .Where(f => string.IsNullOrEmpty(filter.USerEmail) ||
                           f.UserEmail.ToLower().Contains(filter.USerEmail.ToLower()))
               .Where(f => string.IsNullOrEmpty(filter.UserName) ||
                           f.UserName.ToLower().Contains(filter.UserName.ToLower()))
               .Where(f => string.IsNullOrEmpty(filter.UserSurname) ||
                           f.UserSurname.ToLower().Contains(filter.UserSurname.ToLower()))
               .Where(f => string.IsNullOrEmpty(filter.PostOffice) ||
                           f.PostOffice.ToLower().Contains(filter.PostOffice.ToLower()))
               .Where(f => string.IsNullOrEmpty(filter.UserPhoneNumber) ||
                           f.UserPhoneNumber.ToLower().Contains(filter.UserPhoneNumber.ToLower()))
               .Where(f => !filter.DateOfOrder.HasValue || f.DateOfOrder == filter.DateOfOrder)
               .Where(f => !filter.DateToFinishOrderAndDiliver.HasValue ||
                           f.DateToFinishOrderAndDiliver == filter.DateToFinishOrderAndDiliver)
               .Where(f => !filter.IsOrderDone.HasValue || f.IsOrderDone == filter.IsOrderDone)
               .Where(f => !filter.IsOrderMade.HasValue || f.IsOrderMade == filter.IsOrderMade)
               .Where(f => !filter.OrderPrice.HasValue || f.OrderPrice == filter.OrderPrice)
               .Where(f => string.IsNullOrEmpty(filter.UserUniqueToken) ||
                            f.UserUniqueToken.ToLower().Contains(filter.UserUniqueToken.ToLower()));

        return await query.FirstOrDefaultAsync();
    }

    /// <summary>
    ///     Generating unique token for user
    /// </summary>
    /// <returns>New guid to string</returns>
    public async ValueTask<string> GenerateUserUniqueTokenAsync()
    {
        var userUniqueToken = Guid.NewGuid().ToString();

        await AddAsync(new Order { UserUniqueToken = userUniqueToken, IsOrderMade = false });

        return userUniqueToken;
    }

    /// <summary>
    ///     Updating order by user token
    /// </summary>
    /// <param name="entity">Entity with token</param>
    /// <returns>null if entity does not exists and entity if it exists</returns>
    public async ValueTask<Order> CreateOrderAsync(Order entity)
    {
        if (string.IsNullOrEmpty(entity.UserUniqueToken))
        {
            throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "User unique token is empty.");
        }

        var orderFilter = new OrderFilter { UserUniqueToken = entity.UserUniqueToken };

        var orderForUpdate = await FindAsync(orderFilter);

        if (orderForUpdate == null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, "Such order wasn`t found.");
        }
        else if (orderForUpdate.IsOrderMade == true)
        {
            throw new HttpStatusCodeException(HttpStatusCode.PaymentRequired, "Such order is already created");
        }

        entity.Id = orderForUpdate.Id;
        entity.IsOrderMade = true;
        Context.Entry(orderForUpdate).State = EntityState.Detached;

        await UpdateAsync(entity);

        await _emailService.AddAsync(new Email { Mail = entity.UserEmail });

        await _emailService.SendEmailsAsync(new EmailHelper
        {
            Subject = $"Замовлення  №{entity.UserUniqueToken[^12..]} Sho?Shoppers!",
            HtmlBody = GenerateEmailBody(entity)
        }, new List<string> { entity.UserEmail, AdminEmail });

        return entity;
    }

    /// <summary>
    ///     Updating pins and shoppers tables 
    /// </summary>
    /// <param name="order">Order`s user items</param>
    /// <returns>Task</returns>
    public async Task UpdatePinsAndShoppersAmmountAsync(OrderDto order)
    {
        foreach (var item in order.UserItems)
        {
            var entity = await Context.BaseEntityForSales
                .Where(entity => entity.Id == item.Id)
                .FirstOrDefaultAsync();

            if (entity != null && entity.ItemAmmount > 0 && (entity is Pin || entity is Shopper))
            {
                entity.ItemAmmount -= item.Ammount;
                Context.BaseEntityForSales.Update(entity);
            }
        }

        await Context.SaveChangesAsync();
    }

    /// <summary>
    ///     Generating email body with MailBodyPack
    /// </summary>
    /// <param name="order">Entity with info of user order</param>
    /// <returns>String with mailbody</returns>
    private static string GenerateEmailBody(Order order)
    {
        string[] items = order.UserItems.Split(",");

        return MailBody.CreateBody().Title($"Ваше замовлення №{order.UserUniqueToken[^12..]}:")
            .UnorderedList(items.Where(item => item.Length != 0).Select(item => MailBody.CreateBlock().Text(item)))
            .Paragraph("")
            .Paragraph($"При оплаті сьогодні замовлення буде відправлено  до {order.DateToFinishOrderAndDiliver}")
            .Paragraph($"До сплати {order.OrderPrice} грн. Оплата за реквізитами 5375 4141 1425 1688.")
            .Paragraph("При оплаті вказуйте прізвище та ім'я!")
            .Paragraph("Наші контакти: +380674421792 (менеджер Катерина).")
            .Paragraph("Дякуємо за замовлення!")
            .Paragraph("— Sho?Shoppers!")
            .Link("https://shoshoppers.works/", "shoshoppers.works")
            .ToString();
    }
}
