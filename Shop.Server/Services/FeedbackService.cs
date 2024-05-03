using System.Net.Mail;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Server.Models;
using Shop.Server.ServicesContracts;

public class FeedbackService : IFeedbackService
{
    private readonly IHttpContextAccessor _ContextAccessor;
    private readonly DbAa7408UniversityprojectContext _context;
    private readonly IProductService _productService;
    public FeedbackService(IHttpContextAccessor contextAccessor, DbAa7408UniversityprojectContext context, IProductService productService)
    {
        _ContextAccessor = contextAccessor;
        _context = context;
        _productService = productService;
    }
    public async Task<Resault<Feedback>> AddProductFeedbackAsync([FromQuery] string prodId, [FromQuery] float rate, [FromQuery] string comment)
    {
        var userId = _ContextAccessor.HttpContext!.User.Claims.FirstOrDefault(c => c.Type == "user-id")?.Value;
        var prod = await _productService.GetProductAsync(prodId);

        if (prod == null) return new Resault<Feedback>(false, "Product not found", null);
        var isProdPurchasesByUser = await _context.UserPurchasedProducts.FirstOrDefaultAsync(p => p.UserId == userId && p.ProudctId == prodId);
        if (isProdPurchasesByUser == null) return new Resault<Feedback>(false, "You didn`t purchase this product before so you can`t give a feedback to this product", null);

        if (rate > 5 || rate <= 0) return new Resault<Feedback>(false, "Rate should be greater than 0 and less than or equal to 5", null);
        var feedback = new Feedback()
        {
            Id = Guid.NewGuid(),
            Message = comment,
            Rate = rate,
            ProductId = prodId,
            UserId = userId
        };
        await _context.Feedbacks.AddAsync(feedback);

        await _context.SaveChangesAsync();
        return new Resault<Feedback>(true, "Your feed back has been added successfully", feedback);
    }

    public async Task<Resault<Feedback>> DeleteProductFeedbackAsync(Guid feedbackId)
    {
        var feedback = await _context.Feedbacks.FirstOrDefaultAsync(f => f.Id == feedbackId);
        if (feedback == null) return new Resault<Feedback>(false, "Feedback not found", null);
        _context.Feedbacks.Remove(feedback);
        await _context.SaveChangesAsync();
        return new Resault<Feedback>(true, "Feedback has been removed successfully", feedback);
    }

    public async Task<Resault<FeedbackDTO>> GetProductFeedbacks(string prdoId)
    {
        var feedbacks = await _context.Feedbacks.Where(f => f.ProductId == prdoId).ToListAsync();
        if (feedbacks == null || feedbacks.Count == 0) return new Resault<FeedbackDTO>(false, "There are no feedbacks for this product", null);
        var totalRate = 0.0;
        foreach (var feedback in feedbacks)
        {
            totalRate += feedback.Rate;
        }
        totalRate = totalRate / feedbacks.Count;
        var feedbackDTO = new FeedbackDTO()
        {
            TotalRate = (float)totalRate,
            Feedbacks = feedbacks,
        };
        return new Resault<FeedbackDTO>(true, "Feedbacks here", feedbackDTO);
    }

    public async Task<Resault<Feedback>> UpdateProductFeedbackAsync(Guid feedbackId, string newComment, float newRate)
    {
        var feedback = await _context.Feedbacks.FirstOrDefaultAsync(f => f.Id == feedbackId);
        if (feedback == null) return new Resault<Feedback>(false, "Feedback not found", null);
        if (newRate > 5 || newRate <= 0) return new Resault<Feedback>(false, "Rate should be greater that 0 and less than or equal 5", feedback);
        feedback.Message = newComment;
        feedback.Rate = newRate;

        _context.Feedbacks.Update(feedback);
        await _context.SaveChangesAsync();
        return new Resault<Feedback>(true, "Feedback has been updated successfully", feedback);
    }


}