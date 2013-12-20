using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EauxDeBaignade.HauteAutriche.Services
{
    public interface IConfigurationService
    {
        string GitHubUrl { get; }
        string PrivacyPolicyUrl { get; }
    }
}
