using Ingenio_Assessment.Domain;

namespace Ingenio_Assessment.Infrastructure;
public interface ICategoryRepository
{
    Category GetById(int id);
    List<Category> GetAll();
}
