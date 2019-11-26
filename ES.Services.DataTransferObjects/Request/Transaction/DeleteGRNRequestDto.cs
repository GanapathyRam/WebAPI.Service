using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Services.DataTransferObjects.Request.Transaction
{
    public class DeleteGRNRequestDto
    {
        public string GRNNumber { get; set; }

        public decimal GRNSerial { get; set; }

        public int IsDeleteFrom { get; set; }

        public List<DeleteGRNDetails> GetDeleteGRNDetails { get; set; }
    }

    public class DeleteGRNDetails
    {
        public string GRNNumber { get; set; }

        public decimal GRNSerial { get; set; }

        public string PONumber { get; set; }

        public decimal POSerial { get; set; }

        public string ItemCode { get; set; }

        public decimal ReceivedQuantity { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}
