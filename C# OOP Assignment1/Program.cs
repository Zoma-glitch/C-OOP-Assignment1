using System.Security.Principal;

namespace C__OOP_Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question01
            //1- What happens when a Customer variable is copied into another variable and one variable modifies the object
            //address1.City=Cairo
            //address2.City = Giza
            //2- What happens when a Customer variable is copied into another variable and one variable modifies the object
            //customer1.Name = Mohamed
            //customer2.Name = Mohamed
            #endregion
        }
        #region Question02
        //2-Identify at least three problems with this design from an encapsulation perspective.
        //1-all fields public
        //2-no validation
        //3-no controll in edit data
        //b) How can private fields and public properties improve this design?
        //public struct shipment
        //{
        //    private string description;
        //    private double weight;
        //    private decimal deliveryFee;

        //    public string Description
        //    {
        //        get { return description; }
        //        set { description = value; }
        //    }
        //    public double Weight
        //    {
        //        get { return weight;}
        //        set { 
        //            if (value > 0)
        //            return; weight = value;
        //            }
        //    }

        //    public decimal DeliveryFee
        //    {
        //        get { return deliveryFee;}
        //        set { if (value > 0) deliveryFee = value;  }
        //    }
        //}
        #endregion
    }
}
