using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleWCFService.REST
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,ConcurrencyMode = ConcurrencyMode.Single,
        IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    class RESTServices : IRESTServices
    {
        public string QueryPosition()
        {
            string param = "Func=FA002|bhno=P03|acno=2587842|suba=|FC=N|kind=F";

            string workID = "RA003";

            var check =Task.Run(() =>
            {
                WindowsFormsApp1.Form1.queryPosition(param, workID);
                //TODO:要做的事
            });

            check.Wait();

            
            

            //while (true)
            //{
            //    if(!string.IsNullOrEmpty(WindowsFormsApp1.Form1.result))
            //    {
            return WindowsFormsApp1.Form1.result;
            //    }
            //}
            
        }

        public string Write(string msg)
        {
            //ConfigHelper.Write(msg);

            MessageBox.Show(msg);

            return "OK";
        }
    }
}
