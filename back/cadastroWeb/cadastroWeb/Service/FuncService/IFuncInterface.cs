using cadastroWeb.Models;

namespace cadastroWeb.Service.FuncService
{
    public interface IFuncInterface
    {
        Task<ServiceResponse<List<FuncModel>>> GetFunc();
        Task<ServiceResponse<List<FuncModel>>> CriacaoFunc(FuncModel func);
        Task<ServiceResponse<FuncModel>> GetFuncById(int id);
        Task<ServiceResponse<List<FuncModel>>> UpdateFunc(FuncModel editFunc);
        Task<ServiceResponse<List<FuncModel>>> DeleteFunc(int id);
        Task<ServiceResponse<List<FuncModel>>> InativaFunc(int id);
        Task<ServiceResponse<List<FuncModel>>> AtivaFunc(int id);
    }
}
