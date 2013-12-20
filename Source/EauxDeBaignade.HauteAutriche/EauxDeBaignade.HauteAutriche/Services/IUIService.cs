using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EauxDeBaignade.HauteAutriche.Services
{
    public interface IUIService
    {
        void ShowTextToast(string title, string message, int milliseconds=1000);
    }
}
