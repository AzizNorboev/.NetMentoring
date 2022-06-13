namespace EF_API.DAL.Repositories
{
    public abstract class RepositoryBase
    {
        protected ApplicationContext _context { get; set; }

        public RepositoryBase(ApplicationContext context)
        {
            _context = context;
        }
    }
}
