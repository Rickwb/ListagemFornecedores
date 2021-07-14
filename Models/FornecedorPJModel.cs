using System;

namespace EmpresasFornecedores.Models
{
    public class FornecedorPJModel
    {
        public int ID { get; set; }
        public Nullable<int> EmpresaId { get; set; }
        public string FornecedorNome { get; set; }
        public string FornecedorCNPJ { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public string Telefone { get; set; }

        public virtual EmpresaModel Empresa { get; set; }
    }
}