using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionProject.Model
{
    public class TransactionDetails
    {
        [Key]
        public int TransactionId { get; set; }
        public long AccountNumber { get; set; }
        public double Credited { get; set; }
        public double Debited { get; set; }
        public DateTime TransactionTime { get; set; }
        public double Balance { get; set; }
    }
}
