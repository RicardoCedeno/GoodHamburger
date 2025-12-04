using GoodHamburger.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Business.Contracts.Services
{
    public interface IProductServices
    {
        Task<List<SandwichDto>> GetAllSandwiches();
        Task<List<ExtraDto>> GetAllExtras();
    }
}
