using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Interface;
using CRUD.mapeamento;

namespace CRUD.Interface
{
    internal interface IDAO<T>
    {

        public void Cadastrar(T t)
        {

        }

        public void Alterar(T t)
        {

        }

        public void Delete(T t) { }

        //public List<T> BuscarTodos(T t) { }
    }
}
