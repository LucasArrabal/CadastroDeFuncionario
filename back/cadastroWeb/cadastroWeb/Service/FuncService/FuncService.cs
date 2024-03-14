using cadastroWeb.DataContext;
using cadastroWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace cadastroWeb.Service.FuncService
{
    public class FuncService : IFuncInterface
    {
        private readonly Context _context;
        public FuncService(Context context) 
        {
            _context = context; 
        }
        public async Task<ServiceResponse<List<FuncModel>>> CriacaoFunc(FuncModel func)
        {
            ServiceResponse<List<FuncModel>> serviceResponse = new ServiceResponse<List<FuncModel>>();
            try
            {
                if(func == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem ="Nenhum dado foi informado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }
                _context.Funcionarios.Add(func);
                await _context.SaveChangesAsync();

                serviceResponse.Dados= _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncModel>>> DeleteFunc(int id)
        {
            ServiceResponse<List<FuncModel>> serviceResponse = new ServiceResponse<List<FuncModel>>();

            try
            {
                FuncModel func = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                if (func == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não encontrado";
                    serviceResponse.Sucesso = false;
                }
                _context.Funcionarios.Remove(func);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncModel>>> GetFunc()
        {
            ServiceResponse<List<FuncModel>> serviceResponse= new ServiceResponse<List<FuncModel>>();

            try
            {
                serviceResponse.Dados = _context.Funcionarios.ToList();
                if(!serviceResponse.Dados.Any()) 
                {
                    serviceResponse.Mensagem= "Nenhum registro encontrado";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncModel>> GetFuncById(int id)
        {
            ServiceResponse<FuncModel> serviceResponse = new ServiceResponse<FuncModel>();

            try
            {
                FuncModel func = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                if(func == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não encontrado";
                    serviceResponse.Sucesso = false;
                }
                serviceResponse.Dados = func;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncModel>>> InativaFunc(int id)
        {
            ServiceResponse<List<FuncModel>> serviceResponse = new ServiceResponse<List<FuncModel>>();

            try
            {
                FuncModel func = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                if (func == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não encontrado";
                    serviceResponse.Sucesso = false;
                }
                func.Ativo = false;
                func.DtDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(func);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncModel>>> UpdateFunc(FuncModel editFunc)
        {
            ServiceResponse<List<FuncModel>> serviceResponse = new ServiceResponse<List<FuncModel>>();

            try
            {
                FuncModel func = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editFunc.Id);
                if (func == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não encontrado";
                    serviceResponse.Sucesso = false;
                }
                
                func.DtDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(editFunc);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
