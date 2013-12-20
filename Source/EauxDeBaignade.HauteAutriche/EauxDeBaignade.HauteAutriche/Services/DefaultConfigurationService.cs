using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EauxDeBaignade.HauteAutriche.Services
{
    public class DefaultConfigurationService : IConfigurationService
    {
        public string GitHubUrl
        {
            get { return (string)App.Current.Resources["GitHubUrl"]; }
        }

        public string PrivacyPolicyUrl
        {
            get { return (string)App.Current.Resources["PrivacyPolicyUrl"]; }
        }
    }
}
