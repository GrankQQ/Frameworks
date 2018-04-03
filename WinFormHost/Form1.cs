using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.SelfHost;
using System.Windows.Forms;
using System.Net.Http;

namespace WinFormHost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var baseAddress = ConfigurationManager.AppSettings["baseAddress"];
            var config = new HttpSelfHostConfiguration(baseAddress);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            var server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();
        }
    }
}
