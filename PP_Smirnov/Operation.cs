using System;

namespace MaterialTrackingSystem
{
    public class Operation
    {
        public int OperationID { get; set; }
        public int MaterialID { get; set; }
        public int QuantityUsed { get; set; }
        public DateTime Date { get; set; }

        public Operation(int operationID, int materialID, int quantityUsed, DateTime date)
        {
            OperationID = operationID;
            MaterialID = materialID;
            QuantityUsed = quantityUsed;
            Date = date;
        }
    }
}