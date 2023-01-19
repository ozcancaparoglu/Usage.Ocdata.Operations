using Ocdata.Operations.Entities;

namespace Usage.Domain.CategoryAggregate
{
    public class CategoryAttribute : EntityBase
    {
        public int CategoryId { get; private set; }
        public int AttributeId { get; private set; }
        public bool IsRequired { get; private set; }
        public bool IsVariantable { get; private set; }

        protected CategoryAttribute()
        {
        }

        public CategoryAttribute(int categoryId, int attributeId, bool isRequired, bool isVariantable) : this()
        {
            CategoryId = categoryId;
            AttributeId = attributeId;
            IsRequired = isRequired;
            IsVariantable = isVariantable;
        }

        public void SetCategoryAttribute(int categoryId, int attributeId, bool isRequired, bool isVariantable)
        {
            CategoryId = categoryId;
            AttributeId = attributeId;
            IsRequired = isRequired;
            IsVariantable = isVariantable;
        }


    }
}
