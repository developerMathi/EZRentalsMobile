﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NavCustomerMobile
{
    public interface INotification
    {
        void CreateNotification(String title, String message,string pageName,string data);
    }
}

