namespace Ingenio_Assessment.Domain;

public class Category
{
    public int Id { get; set; }
    public int ParentCategoryId { get; set; }
    public string Name { get; set; }
    public string Keyword { get; set; }
}