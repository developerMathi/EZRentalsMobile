using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavCustomerMobileModel.AccessModels
{
    public class GetTermsandConditionByTypeResponse
    {
        public ApiMessage message { get; set; }
        public List<Terms> termlist { get; set; }
    }
}
