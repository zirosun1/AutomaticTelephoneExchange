using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilingSystem
{
    public interface IData<T>
    {
        IList<T> GetInformationList();
    }
}
