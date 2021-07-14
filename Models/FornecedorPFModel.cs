using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpresasFornecedores.Models
{
    public class FornecedorPFModel
    {
        public int ID { get; set; }
        [NotMapped]
        public Nullable<int> EmpresaId { get; set; }
        [DisplayName("Nome")]
        public string FornecedorNome { get; set; }
        [DisplayName("CPF")]
        [StringLength(11,ErrorMessage ="Cpf inválido",MinimumLength=11)]
        public string FornecedorCPF { get; set; }
        [DisplayName("RG")]
        [StringLength(11, ErrorMessage = "RG inválido", MinimumLength = 7)]
        public string FornecedorRG { get; set; }
        [DisplayName("Data Nascimento")]
        
        public Nullable<System.DateTime> DataNascimento { get; set; }
        [NotMapped]
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public string Telefone { get; set; }

        public virtual EmpresaModel Empresa { get; set; }
    }
}