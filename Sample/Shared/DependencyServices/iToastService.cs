using System;
using System.Collections.Generic;
using System.Text;

namespace Sample
{
    public interface iToastService
    {
        void Show(string message, bool isLong);
    }
}
