using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

namespace JamesRSkemp.Media.Web {
	public class Global : HttpApplication {
		void Application_Start(object sender, EventArgs e) {
			RegisterRoutes();
		}

		private void RegisterRoutes() {
			// Edit the base address of Service1 by replacing the "Service1" string below
			RouteTable.Routes.Add(new ServiceRoute("Service1", new WebServiceHostFactory(), typeof(Service1)));
			RouteTable.Routes.Add(new ServiceRoute("MusicService", new WebServiceHostFactory(), typeof(MusicService)));
			RouteTable.Routes.Add(new ServiceRoute("FormulasService", new WebServiceHostFactory(), typeof(FormulasService)));
		}
	}
}
