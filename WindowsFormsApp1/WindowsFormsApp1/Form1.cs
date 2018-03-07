using ConsoleWCFService.REST;
using System;
using System.ServiceModel.Web;
using System.Windows.Forms;
using YuantaOrdLib;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        WebServiceHost serviceHost;

        public static string result = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RESTServices service = new RESTServices();
            serviceHost = new WebServiceHost(service, new Uri("http://localhost:8000/"));
            serviceHost.Open();

            m_yuanta_ord = new YuantaOrdClass();

            m_yuanta_ord.OnLogonS += new _DYuantaOrdEvents_OnLogonSEventHandler(m_yuanta_ord_OnLogonS);

            m_yuanta_ord.OnUserDefinsFuncResult += new _DYuantaOrdEvents_OnUserDefinsFuncResultEventHandler(m_yuanta_ord_OnUserDefinsFuncResult);

            int ret_code = m_yuanta_ord.SetFutOrdConnection("", "", "api.yuantafutures.com.tw", int.Parse("80"));


        }

        public static YuantaOrdLib.YuantaOrdClass m_yuanta_ord = null;

        public static void queryPosition(string param, string workID)
        {
            int code = m_yuanta_ord.UserDefinsFunc(param, workID);

            string a = "";
        }

        void m_yuanta_ord_OnLogonS(int TLinkStatus, string AccList, string Casq, string Cast)
        {
            //ConfigHelper.Write(String.Format("OnLogonS: {0},{1},{2},{3}", TLinkStatus, AccList, Casq, Cast));

            if (TLinkStatus == 2)
            {
                //insert_acno(AccList.Trim());
                string param = "Func=FA002|bhno=P03|acno=2587842|suba=|FC=N|kind=F";

                string workID = "RA003";

                int code = m_yuanta_ord.UserDefinsFunc(param, workID);
            }
            //textBox_status_code.Text = 
            // 回傳 2 表示已經在 "已登入" 連線狀態  
            //string status = TLinkStatus.ToString();


            textBox1.Text= TLinkStatus.ToString(); 
        }

        void m_yuanta_ord_OnUserDefinsFuncResult(int RowCount, string Results, string WorkID)
        {
            //listBox_UserDefins.Items.Clear();
            if (RowCount <= 0 || Results.Length <= 0)
            {
                return;
            }

            result = Results;

            //ConfigHelper.Write(Results);
            //listBox_UserDefins.Items.Add(WorkID);
            //listBox_UserDefins.Items.Add(Results);

        }

    }
}
