using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class PlanData
    {
        public int Id { get; set; }
        public Guid? GlobalId { get; set; }
        public byte[] Data { get; set; }
        public string Filename { get; set; }
        public int? PlanIndexOnFile { get; set; }
        public bool? IsVector { get; set; }
        public string DetectSymbolsCache { get; set; }
    }
}
