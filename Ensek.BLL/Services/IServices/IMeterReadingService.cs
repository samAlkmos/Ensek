using Ensek.DTO.DTOs;
using System.Threading.Tasks;

namespace Ensek.BLL.Services.IServices
{
    public interface IMeterReadingService
    {
        Task<SummaryDTO> UploadReadings(string fileName);


    }
}
