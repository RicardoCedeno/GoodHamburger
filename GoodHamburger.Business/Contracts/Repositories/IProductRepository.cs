using GoodHamburger.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Business.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<List<SandwichDto>> GetAllSandwiches();
        Task<List<ExtraDto>> GetAllExtras();
    }
}
