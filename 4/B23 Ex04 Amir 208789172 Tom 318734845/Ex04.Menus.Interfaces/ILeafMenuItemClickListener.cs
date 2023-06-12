using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public interface ILeafMenuItemClickListener
    {
        void ReportLeafMenuItemWasClick(int i_LeafMenuItemId, eAction m_Action);
    }
}
