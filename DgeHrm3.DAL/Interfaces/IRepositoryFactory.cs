using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgeHrm3.DAL.Interfaces;

public interface IRepositoryFactory
{
    public ISubjectRepository GetSubjectRepository();

    public ISchoolRepository GetSchoolRepository();

    public IQuotaRepository GetQuotaRepository();
}
