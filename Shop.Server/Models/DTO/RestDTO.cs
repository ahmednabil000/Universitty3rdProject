namespace Shop.Server.Models.DTO
{
	public class RestDTO<T>
	{
		public T Data { get; set; }
		public int PageSize { get; set; }
		public int PageIndex { get; set; }
		public RestDTO() { }
	}
}
