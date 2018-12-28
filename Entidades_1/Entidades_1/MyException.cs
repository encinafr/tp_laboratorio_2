using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_1
{
    public class MyException:Exception
    {
        public MyException(string text):base (text)
        { 
            
        }

    }
}
