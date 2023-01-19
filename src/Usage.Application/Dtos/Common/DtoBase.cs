namespace Usage.Application.Dtos.Common
{
    public abstract class DtoBase
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? State { get; set; }
    }
}
