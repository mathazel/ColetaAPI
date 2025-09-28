using ColetaAPI.DataContext;
using ColetaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace ColetaAPI.Service.ColetaService
{
    public class ColetaService : IColetaInterface
    {
        // Dependency Injection
        private readonly ApplicationsDbContext _context;

        // Constructor
        public ColetaService(ApplicationsDbContext context)
        {
            _context = context;
        }
        // Adicionar Coleta
        public async Task<ServiceResponse<List<ColetaModel>>> AddColeta(ColetaModel coleta)
        {
            ServiceResponse<List<ColetaModel>> ServiceResponse = new ServiceResponse<List<ColetaModel>>();
            try
            {
                if (coleta.Local == null)
                {
                    ServiceResponse.Data = null;
                    ServiceResponse.Message = "Local é obrigatório";
                    ServiceResponse.Success = false;

                    return ServiceResponse;
                }
                _context.Add(coleta);
                await _context.SaveChangesAsync();
                ServiceResponse.Data = await _context.Coletas.ToListAsync();
                ServiceResponse.Message = "Coleta adicionada";
            }
            catch (Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }
        // Pegar todas as Coletas
        public async Task<ServiceResponse<List<ColetaModel>>> GetColeta()
        {
            ServiceResponse<List<ColetaModel>> ServiceResponse = new ServiceResponse<List<ColetaModel>>();
            try
            {
                ServiceResponse.Data = await _context.Coletas.ToListAsync();
                if (ServiceResponse.Data.Any())
                {
                    ServiceResponse.Message = "Coletas encontradas";
                }
                else
                {
                    ServiceResponse.Message = "Nenhum dado encontrado";
                }
            }
            catch (Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }
        // Pegar Coleta por ID
        public async Task<ServiceResponse<ColetaModel>> GetSingleColeta(int id)
        {
            ServiceResponse<ColetaModel> ServiceResponse = new ServiceResponse<ColetaModel>();
            try
            {
                ColetaModel coletas = _context.Coletas.FirstOrDefault(c => c.ID == id);

                if (coletas == null)
                {
                    ServiceResponse.Message = "Coleta não encontrada";
                    ServiceResponse.Success = false;
                }
                ServiceResponse.Data = coletas;
                ServiceResponse.Message = "Coleta encontrada";
            }
            catch (Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }
        // Atualizar Coleta
        public async Task<ServiceResponse<ColetaModel>> UpdateColeta(ColetaModel coleta)
        {
            ServiceResponse<ColetaModel> ServiceResponse = new ServiceResponse<ColetaModel>();
            try
            {
                _context.Update(coleta);
                await _context.SaveChangesAsync();
                ServiceResponse.Data = coleta;
                ServiceResponse.Message = "Coleta atualizada";
            }
            catch (Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }
        // Deletar Coleta
        public async Task<ServiceResponse<List<ColetaModel>>> DeleteColeta(int id)
        {
            ServiceResponse<List<ColetaModel>> ServiceResponse = new ServiceResponse<List<ColetaModel>>();
            try
            {
                ColetaModel coleta = _context.Coletas.FirstOrDefault(c => c.ID == id);
                if (coleta == null)
                {
                    ServiceResponse.Message = "Coleta não encontrada";
                    ServiceResponse.Success = false;
                }
                _context.Coletas.Remove(coleta);
                await _context.SaveChangesAsync();
                ServiceResponse.Data = await _context.Coletas.ToListAsync();
                ServiceResponse.Message = "Coleta deletada.";
            }
            catch (Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }
    }
}
