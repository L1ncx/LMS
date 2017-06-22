using Microsoft.VisualBasic.FileIO;
using RiskAssessment.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RiskAssessment.Web.Managers;

namespace RiskAssessment.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            string settledFilePath = Server.MapPath("~/Content/Files/Settled.csv");
            string unsettledFilePath = Server.MapPath("~/Content/Files/Unsettled.csv");

            List<CustomerData> settledData = ParseCsv(settledFilePath, ",").ToList();
            List<CustomerData> unsettledData = ParseCsv(unsettledFilePath, ",").ToList();
        

            var output = new List<CustomerViewModel>();
           
            foreach (var unsettledCustomer in unsettledData)
            {
                var settledCustomerData = settledData.Where(c => c.CustomerName == unsettledCustomer.CustomerName).ToList();
                var unsettledCustomerData = unsettledData.Where(c => c.CustomerName == unsettledCustomer.CustomerName).ToList();

                var crm = new CustomerRiskAssesmentManager(unsettledCustomer.CustomerName, unsettledCustomer.Event, settledCustomerData, unsettledCustomerData);

                var vm = new CustomerViewModel(unsettledCustomer, crm);

                output.Add(vm);
            }
            

            return View(output);
        }

        public IEnumerable<CustomerData> ParseCsv(string fileSrc, string seperator)
        {   
            var list = new List<CustomerData>();
            bool header = true;

            using (TextFieldParser parser = new TextFieldParser(fileSrc))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(seperator);
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (header == true)
                    {  //escape first line
                        header = false;
                    }
                    else
                    {
                        var customer = new CustomerData()
                        {
                            CustomerName = fields[0],
                            Event = fields[1],
                            Participant = fields[2],
                            Stake = decimal.Parse(fields[3]),
                            Win = decimal.Parse(fields[4])
                        };
                        list.Add(customer);
                    }
                }
            }
            return list.AsEnumerable();
        }
    }
}