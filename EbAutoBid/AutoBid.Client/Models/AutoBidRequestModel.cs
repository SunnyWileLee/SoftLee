using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Client.Models
{
    class AutoBidRequestModel
    {
        public string beanName
        {
            get;
            set;
        }

        public List<string> propNames
        {
            get;
            set;
        }

        public List<string> propChineseNames
        {
            get;
            set;
        }

        public List<string> propTypes
        {
            get;
            set;
        }

        public List<List<string>> propValues
        {
            get;
            set;
        }

        public AutoBidRequestModel(string idResoTemp, int money)
        {
            this.beanName = string.Empty;
            this.propNames = new List<string>
            {
                "idReso",
                "myPrice"
            };
            this.propTypes = new List<string>
            {
                "string",
                "string"
            };
            this.propChineseNames = new List<string>();
            this.propValues = new List<List<string>>
            {
                new List<string>
                {
                    idResoTemp,
                    money.ToString()
                }
            };
        }
    }
}
