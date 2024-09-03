using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Dal.Repository;

public class BaseRepository
{
    protected readonly HospitalDbContext _ctx;
    public BaseRepository(HospitalDbContext connectionSrting)
    {
        _ctx = connectionSrting;
    }
}
