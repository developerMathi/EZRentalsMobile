﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavCustomerMobileModel.AccessModels
{
    [Serializable]
    public class UpdateCustomerMobileCreditCardResponse
    {
        public int creditCardID { get; set; }
        public ApiMessage message { get; set; }
    }
}
