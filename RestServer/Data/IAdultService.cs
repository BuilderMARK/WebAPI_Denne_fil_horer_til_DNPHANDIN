using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestServer.Data
{
    public interface IAdultService
    {
        Task <IList<Adult>> ReadAllAdults();
        Task <Adult> AddAdult(Adult addAdult);
        Task<Adult> UpdateAdult(Adult updateAdult);
        Task DeleteAdult(int deleteAdult); 
    }
}