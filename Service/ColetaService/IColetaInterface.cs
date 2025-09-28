using ColetaAPI.Models;

namespace ColetaAPI.Service.ColetaService
{
    public interface IColetaInterface
    {
        // Pegar todas as Coletas
        Task<ServiceResponse<List<ColetaModel>>> GetColeta();
        Task<ServiceResponse<ColetaModel>> GetSingleColeta(int id);
        Task<ServiceResponse<List<ColetaModel>>> AddColeta(ColetaModel coleta);
        Task<ServiceResponse<ColetaModel>> UpdateColeta(ColetaModel coleta);
        Task<ServiceResponse<List<ColetaModel>>> DeleteColeta(int id);
    }
}
