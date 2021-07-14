using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpresasFornecedores.Models
{
    public class EmpresaModel
    {
        public int Id { get; set; }
        [DisplayName("Nome Fantasia")]
        public string NomeFantasia { get; set; }
        [StringLength(14,ErrorMessage ="CNPJ Inválido",MinimumLength =14)]
        public string CNPJ { get; set; }
        [StringLength(2, ErrorMessage = "UF Inválido", MinimumLength = 2)]
        public string UF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FornecedorPJModel> FornecedorPJ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FornecedorPFModel> FornecedorPF { get; set; }
    }
}