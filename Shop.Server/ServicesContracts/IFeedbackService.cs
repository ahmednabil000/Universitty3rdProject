


using Shop.Server.Models;

public interface IFeedbackService
{
    Task<Resault<Feedback>> AddProductFeedbackAsync(string prodId, float rate, string comment);
    Task<Resault<Feedback>> UpdateProductFeedbackAsync(Guid feedbackId, string newComment, float newRate);
    Task<Resault<Feedback>> DeleteProductFeedbackAsync(Guid feedbackId);
    Task<Resault<FeedbackDTO>> GetProductFeedbacks(string prdoId);
}