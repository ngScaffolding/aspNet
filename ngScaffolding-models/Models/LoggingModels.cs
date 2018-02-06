using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngScaffolding.models.Models
{
    public class ApplicationLog : BaseEntity
    {
        public DateTime LogDate { get; set; }
        public string UserID { get; set; }
        public string LogType { get; set; }
        public string Description { get; set; }
        public string EndPoint { get; set; }
        public string HttpCommand { get; set; }
        public string Values { get; set; }
    }
}
