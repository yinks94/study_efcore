using Microsoft.EntityFrameworkCore;

using DgeHrm3.DAL.Model;


namespace DgeHrm3.DAL.Interfaces;
public interface IDataStoreContext : IUnitOfWork
{
    DbSet<Subject> Subjects
    {
        get;
    }
    DbSet<School> Schools
    {
        get;
    }
    DbSet<Quota> Quotas
    {
        get;
    }
}