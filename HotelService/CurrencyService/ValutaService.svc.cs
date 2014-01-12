using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CurrencyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IValutaService
    {
        Dictionary<string, double> valutaDict = new Dictionary<string, double>()
        {
            { "EUR", 1},
            { "USD", 1.3671},
            { "JPY", 142.3750}
        };
        
        public string[] GetValutas()
        {
            return valutaDict.Keys.ToArray();
        }

        public double GetConvertedValuta(int inAmount, string outValuta)
        {
            if (valutaDict.ContainsKey(outValuta))
            {
                return (inAmount * valutaDict[outValuta]);
            }
            else
            {
                return 0;
            }
        }
    }
}
