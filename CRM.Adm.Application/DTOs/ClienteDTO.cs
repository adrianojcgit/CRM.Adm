using CRM.Adm.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CRM.Adm.Application.DTOs
{
    public class ClienteDTO: BaseDomainCRM
    {
        [Required]
        [StringLength(18)]
        [Display(Name = "CNPJ")]
        public string CnpjNumInscricao { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Nome Empresarial")]
        public string NomeEmpresarial { get; set; }

        [StringLength(100)]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

		[Display(Name = "Fat. Bruto Anual")]
		public decimal FatBrutoAnual { get; set; }
	}
}
