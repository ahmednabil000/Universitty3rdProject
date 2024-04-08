namespace Shop.Server.Models.DTO
{
	public class RequestDTO
	{
		public int PageSize { get; set; } = 10;
		public int PageIndex { get; set; } = 0;
		public string? FilterQuery { get; set; } = null;

	}
}
