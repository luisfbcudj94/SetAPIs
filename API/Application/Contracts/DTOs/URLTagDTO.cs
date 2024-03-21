namespace API.Application.Contracts.DTOs
{
    public class URLTagDTO
    {
        public virtual Guid Id { get; set; }
        public virtual Guid UrlId { get; set; }
        public virtual Guid TagId { get; set; }
    }
}
