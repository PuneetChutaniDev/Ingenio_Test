using Ingenio_Assessment.Domain;

namespace Ingenio_Assessment.Infrastructure;
public class MockCategoryRepository : ICategoryRepository
{
    private readonly List<Category> _categories = new()
    {
        new Category { Id = 100, ParentCategoryId = -1, Name = "Business", Keyword = "Money" },
        new Category { Id = 200, ParentCategoryId = -1, Name = "Tutoring", Keyword = "Teaching" },
        new Category { Id = 101, ParentCategoryId = 100, Name = "Accounting", Keyword = "Taxes" },
        new Category { Id = 102, ParentCategoryId = 100, Name = "Taxation", Keyword = "" },
        new Category { Id = 201, ParentCategoryId = 200, Name = "Computer", Keyword = "" },
        new Category { Id = 103, ParentCategoryId = 101, Name = "Corporate Tax", Keyword = "" },
        new Category { Id = 109, ParentCategoryId = 101, Name = "Small Business Tax", Keyword = "" },
        new Category { Id = 202, ParentCategoryId = 201, Name = "Operating System", Keyword = "" },
    };

    public Category GetById(int id) => _categories.FirstOrDefault(c => c.Id == id);
    public List<Category> GetAll() => _categories;
}

