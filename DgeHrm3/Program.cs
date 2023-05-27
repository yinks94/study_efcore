using DgeHrm3.DAL.Context;
using DgeHrm3.DAL.Interfaces;
using DgeHrm3.DAL.Model;
using DgeHrm3.DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddDbContext<DataStoreContext>();
        //services.AddSingleton<IRepositoryFactory, RepositoryFactory>();
        services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        //services.AddSingleton<ISchoolRepository, SchoolRepository>();
        //services.AddSingleton<ISubjectRepository, SubjectRepository>();
        //services.AddSingleton<IQuotaRepository, QuotaRepository>();

        return services.BuildServiceProvider();
    }

    static void Main(string[] args)
    {
        var service = ConfigureServices();


        var _subjectRepoistory = service.GetService<IGenericRepository<Subject>>();
        var _quotaRepoistory = service.GetService<IGenericRepository<Quota>>();
        var _schoolRepoistory = service.GetService<IGenericRepository<School>>();

        //var _subjectRepoistory = service.GetService<IRepositoryFactory>().GetSubjectRepository();
        //var _quotaRepoistory = service.GetService<IRepositoryFactory>().GetQuotaRepository();
        //var _schoolRepoistory = service.GetService<IRepositoryFactory>().GetSchoolRepository();

        //var _subjectRepoistory = service.GetService<ISchoolRepository>();
        //var _quotaRepoistory = service.GetService<IQuotaRepository>();
        //var _schoolRepoistory = service.GetService<ISchoolRepository>();

        //foreach (var subject in _subjectRepoistory.GetAll())
        //{
        //    Console.WriteLine($"{subject}");
        //}

        foreach (var school in _schoolRepoistory.GetAll())
        {
            Console.WriteLine($"{school}");
        }

        foreach (var quota in _quotaRepoistory.GetAll())
        {
            Console.WriteLine($"{quota}");
        }

        using (var context = service.GetService<DataStoreContext>())
        {

            foreach (var subject in context.Subjects)
            {
                Console.WriteLine($"{subject}");
            }

            foreach (var school in context.Schools)
            {
                Console.WriteLine($"{school}");
            }

            foreach (var quota in context.Quotas)
            {
                Console.WriteLine($"{quota}");
            }
            var quota2 = context.Quotas.Where(e => e.QutoaId == 9893).FirstOrDefault();
            Console.WriteLine($"{quota2}");
        }
        Console.WriteLine("Hello, World!");
    }
}