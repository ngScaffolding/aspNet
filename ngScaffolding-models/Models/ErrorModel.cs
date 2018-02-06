using System;
using System.ComponentModel.DataAnnotations;
using ngScaffolding.models.Models;

namespace ngScaffolding.database.Models
{
    public class ErrorModel: BaseEntity
    {
        [StringLength(200)]
        public string Source { get; set; }

        public string Message { get; set; }

        public DateTime DateRecorded { get; set; }

        public string StackTrace { get; set; }

        [StringLength(100)]
        public string UserId { get; set; }
    }
}
