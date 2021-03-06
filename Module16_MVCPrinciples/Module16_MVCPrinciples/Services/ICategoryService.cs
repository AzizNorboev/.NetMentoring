using Models;
using ReflectionIT.Mvc.Paging;

namespace Services
{
    public interface ICategoryService
    {
        List<Category> GetCategoryList();
        PagingList<Category> GetAllCategory(int pageSize, int page);
        Category GetById(int id);
        Category GetByName(string name);
        List<string> GetAllCategoryNames();
        void Create(Category category);
        void Update(Category category);
        bool Delete(int id);
    }
}
