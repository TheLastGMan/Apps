using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Onitama.Core.GameXml
{
    [XmlRoot("Onitama")]
    public class CardXml
    {
        [XmlArrayItem("Card")]
        public GameCard[] Cards { get; set; } = new GameCard[] { };
    }
}
