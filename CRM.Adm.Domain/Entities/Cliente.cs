using CRM.Adm.Domain.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Adm.Domain.Entities
{
    public sealed class Cliente: BaseDomainCRM
    {
        public Cliente(int Id, int idHtml, string codInterno, string cnpjParametro, string cnpjConsultado, string cnpjNumInscricao, string nomeEmpresarial, string nomeFantasia, decimal fatBrutoAnual)
        {
            ValidationDomain(Id, idHtml, codInterno, cnpjParametro, cnpjConsultado, cnpjNumInscricao, nomeEmpresarial, nomeFantasia, fatBrutoAnual);
        }

        private void ValidationDomain(int Id, int idHtml, string codInterno, string cnpjParametro, string cnpjConsultado, string cnpjNumInscricao, string nomeEmpresarial, string nomeFantasia, decimal fatBrutoAnual)
        {
            DomainExceptionValidation.When(idHtml <= 0, "Campo ID HTML é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(codInterno), "Campo cód. Interno é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(cnpjParametro), "Campo cnpj Parametro é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(cnpjConsultado), "Campo cnpj Consultado é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(cnpjNumInscricao), "Campo cnpj Núm. Inscricao é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nomeEmpresarial), "Campo nome Empresarial é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nomeFantasia), "Campo nome Fantasia é obrigatório.");
			DomainExceptionValidation.When(fatBrutoAnual <= 0, "Campo nome Faturamento Bruto Anual é obrigatório.");

			IdHtml = idHtml;
            CodInterno = codInterno;
            CnpjParametro = cnpjParametro;
            CnpjConsultado = cnpjConsultado;
            CnpjNumInscricao = cnpjNumInscricao;
            NomeEmpresarial = nomeEmpresarial;
            NomeFantasia = nomeFantasia;
            FatBrutoAnual = fatBrutoAnual;

			if ( Id <= 0)
                DataCadastro =  DateTime.Now;
            else
                DataAtualizacao = DateTime.Now;
        }
        #region :: Comportamentos ::
        public void Update(int Id, int idHtml, string codInterno, string cnpjParametro, string cnpjConsultado, string cnpjNumInscricao, string nomeEmpresarial, string nomeFantasia, decimal fatBrutoAnual)
        {            
            ValidationDomain(Id, idHtml, codInterno, cnpjParametro, cnpjConsultado, cnpjNumInscricao, nomeEmpresarial, nomeFantasia, fatBrutoAnual);
        }
        #endregion

        [Required]
        public int IdHtml { get; private set; }

        [Required]
        [StringLength(15)]
        public string CodInterno { get; private set; }

        [Required]
        [StringLength(14)]
        public string CnpjParametro { get; private set; }

        [Required]
        [StringLength(14)]
        public string CnpjConsultado { get; private set; }

        [Required]
        [StringLength(18)]
        public string CnpjNumInscricao { get; private set; }

        [Required]
        [StringLength(200)]
		public string NomeEmpresarial { get; private set; }

        [StringLength(100)]
        public string NomeFantasia { get; private set; }
		public DateTime DataImportacao { get; set; }

		[Required]
		[StringLength(1)]
		public string PorteEmpresa { get; set; }

		[Required]
		[Range(0, 9999999999999999.99)]
		public decimal FatBrutoAnual { get; set; }
	}
}
