using GoodHamburger.Models.Dtos;
using GoodHamburger.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Business.Contracts.Services
{
    public interface IExtraServices
    {
        Task<List<ExtraDto>> GetAllExtras();
    }
}
