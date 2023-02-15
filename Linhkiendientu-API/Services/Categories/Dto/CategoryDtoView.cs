namespace Linhkiendientu_API.Services.Categories.Dto
{
    public class CategoryDtoView
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<CategoryDto> data { get; set; }
    }

    public class CategoryViewApiObject
    {
        public bool success { get; set; }
        public string message { get; set; }
        public CategoryDto data { get; set; }
    }
}
