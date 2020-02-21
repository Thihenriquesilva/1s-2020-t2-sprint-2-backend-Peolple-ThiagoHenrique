using senai.peoples.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.peoples.webapi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionariosDomain> Listar();

        void AdicionarFuncionario(FuncionariosDomain fu);

        FuncionariosDomain BuscarPorId(int id);

        FuncionariosDomain BuscarPorNome(string nome);

        void AtualizarPorIdCorpo(FuncionariosDomain funcionario);

        void AtualizarPorIdUrl(int id, FuncionariosDomain funcionario);

        void Deletar(int id);
    }
}
