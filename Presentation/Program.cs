using Ingenio_Assessment.Application;
using Ingenio_Assessment.Infrastructure;

namespace Ingenio_Assessment.Presentation;

class Program
{
    static void Main()
    {
        var repository = new MockCategoryRepository();
        var service = new CategoryService(repository);

        PrintUseCase1(service);
        PrintUseCase2(service);

        PrintLineBreak();
    }

    static void PrintUseCase1(CategoryService service)
    {
        PrintSectionHeader("Use Case 1 Results");

        PrintCategoryInfo(service, 201);
        PrintCategoryInfo(service, 202);
    }

    static void PrintUseCase2(CategoryService service)
    {
        PrintSectionHeader("Use Case 2 Results");

        PrintCategoryIdsByLevel(service, 2);
        PrintCategoryIdsByLevel(service, 3);
    }

    static void PrintCategoryInfo(CategoryService service, int input)
    {
        Console.WriteLine($"Input: {input}");
        Console.WriteLine($"Output: {service.GetCategoryInfo(input)}");
    }

    static void PrintCategoryIdsByLevel(CategoryService service, int level)
    {
        var ids = service.GetCategoryIdsByLevel(level);
        Console.WriteLine($"Level {level}: [{string.Join(", ", ids)}]");
    }

    static void PrintSectionHeader(string title)
    {
        Console.WriteLine("============================================================");
        Console.WriteLine(title);
    }

    static void PrintLineBreak()
    {
        Console.WriteLine("============================================================");
    }
}
