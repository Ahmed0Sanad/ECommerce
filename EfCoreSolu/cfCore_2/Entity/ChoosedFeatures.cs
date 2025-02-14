using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cfCore_2.Entity
{
    internal class ChoosedFeatures
    {
        [ForeignKey("tickett")]
        public int tickettId { get; set; }
        public Tickett  tickett { get; set; }
        [ForeignKey("features")]
        public int featureId { get; set; }
        public Features features { get; set; }

    }
}
