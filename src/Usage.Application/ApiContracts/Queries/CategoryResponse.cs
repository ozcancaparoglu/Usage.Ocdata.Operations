namespace Usage.Application.ApiContracts.Queries
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int? State { get; set; }
    }
}
