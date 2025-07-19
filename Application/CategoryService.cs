using Ingenio_Assessment.Infrastructure;

namespace Ingenio_Assessment.Application;
public class CategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public string GetCategoryInfo(int categoryId)
    {
        var category = _repository.GetById(categoryId);
        if (category == null) return "Category not found";

        string keyword = category.Keyword;
        var current = category;
        while (string.IsNullOrWhiteSpace(keyword) && current.ParentCategoryId != -1)
        {
            current = _repository.GetById(current.ParentCategoryId);
            if (current == null) break;
            keyword = current.Keyword;
        }

        return $"ParentCategoryID={category.ParentCategoryId}, Name={category.Name}, Keywords={keyword}";
    }

    public List<int> GetCategoryIdsByLevel(int level)
    {
        var allCategories = _repository.GetAll();
        var map = allCategories.ToDictionary(c => c.Id, c => c.ParentCategoryId);

        Dictionary<int, int> levelMap = new();

        foreach (var category in allCategories)
        {
            int depth = 1;
            int parent = category.ParentCategoryId;

            while (parent != -1)
            {
                depth++;
                if (map.ContainsKey(parent))
                    parent = map[parent];
                else
                    break;
            }

            levelMap[category.Id] = depth;
        }

        return levelMap.Where(kv => kv.Value == level).Select(kv => kv.Key).ToList();
    }
}


