using Usage.Application.Dtos.Common;

namespace Usage.Application.Dtos
{
    public class CategoryDto : DtoBase
    {
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public ICollection<CategoryAttributeDto> CategoryAttributes { get; set; }
    }
}
