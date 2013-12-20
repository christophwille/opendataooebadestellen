using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Microsoft.Phone.Tasks;
using EauxDeBaignade.HauteAutriche.Services;

namespace EauxDeBaignade.HauteAutriche.ViewModels
{
    public class AboutViewModel : Screen
    {
        public AboutViewModel(IConfigurationService config)
        {
            VersionText = GetAppVersion();

            GitHubUrl = new Uri(config.GitHubUrl);
            PrivacyPolicyUrl = new Uri(config.PrivacyPolicyUrl);

            OoeBadestellenOgdUrl = new Uri("http://www.land-oberoesterreich.gv.at/cps/rde/xfw/ooe/122310_DEU_HTML.htm");
        }

        public string VersionText { get; set; }

        public Uri GitHubUrl { get; set; }
        public Uri PrivacyPolicyUrl { get; set; }
        public Uri OoeBadestellenOgdUrl { get; set; }

        public void Review()
        {
            var task = new MarketplaceReviewTask();
            task.Show();
        }

        private string GetAppVersion()
        {
            var nameHelper = new AssemblyName(Assembly.GetExecutingAssembly().FullName);

            var version = nameHelper.Version;
            //var full = nameHelper.FullName;
            //var name = nameHelper.Name;

            return string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
        }
    }
}
