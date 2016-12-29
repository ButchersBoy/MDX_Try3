using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOG.iEconomics.Common
{
    public class MenuItemClickedEvent:CompositeWpfEvent<>
    {
    }

    public class MenutItemClickedEventPayload
    {
        public string MenuItemId { get; set; }
    }
}
