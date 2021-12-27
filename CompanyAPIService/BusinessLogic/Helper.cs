using CompanyAPIService.Model;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace CompanyAPIService.BusinessLogic
{
    public class Helper
    {
        #region Singleton
        private Helper() { }
        private static Helper instance = null;
        public static Helper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Helper();
                }
                return instance;
            }
        }

        #endregion Singleton

        #region Methods

        public string ValidateCompany(Company company)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                if (string.IsNullOrEmpty(company.CompanyName) || (company.CompanyName.Length < 5 && company.CompanyName.Length < 35) || !company.CompanyName.StartsWith("Compnay Name:"))
                    result.Append("CompanyName is invalid: CompanyName must contain a minimum of 5 characters and maximum of 35, and it must start with 'Compnay Name:'.");

                if(company.NumberOfEmployees <= 1)
                    result.AppendLine("NumberOfEmployees is invalid: NumberOfEmployees muyst be greater than 1");

                if (company.AverageSalary == 0)
                    result.AppendLine("AverageSalary is invalid: AverageSalary must be greater than 0");

                return result.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Methods
    }
}
