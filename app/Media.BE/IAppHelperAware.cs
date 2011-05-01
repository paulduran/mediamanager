using System;
using System.Collections.Generic;
using System.Text;

namespace Media.BE
{
    public interface IAppHelperAware
    {
        void ReadFrom(AppHelperContext context);
    }
}
