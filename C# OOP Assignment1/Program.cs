using System.Net;
using System.Security.Principal;
using static C__OOP_Assignment1.Program;

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

            DeliveryCenter center = new DeliveryCenter();


            Console.WriteLine("Enter Shipment 1 Data");

            Console.Write("Tracking Code: ");
            string trackingCode1 = Console.ReadLine();

            Console.Write("Description: ");
            string description1 = Console.ReadLine();

            Console.Write("Weight: ");
            double weight1 = double.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            decimal fee1 = decimal.Parse(Console.ReadLine());

            Console.Write("City: ");
            string city1 = Console.ReadLine();

            Console.Write("Street: ");
            string street1 = Console.ReadLine();

            Console.Write("Building Number: ");
            int building1 = int.Parse(Console.ReadLine());

            DeliveryAddress address1 =
                new DeliveryAddress(city1, street1, building1);

            shipment shipment1 =
                new shipment(trackingCode1, description1, weight1, fee1, address1);

            center.AddShipment(shipment1);


            Console.WriteLine("\nEnter Shipment 2 Data");

            Console.Write("Tracking Code: ");
            string trackingCode2 = Console.ReadLine();

            Console.Write("Description: ");
            string description2 = Console.ReadLine();

            Console.Write("Weight: ");
            double weight2 = double.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            decimal fee2 = decimal.Parse(Console.ReadLine());

            Console.Write("City: ");
            string city2 = Console.ReadLine();

            Console.Write("Street: ");
            string street2 = Console.ReadLine();

            Console.Write("Building Number: ");
            int building2 = int.Parse(Console.ReadLine());

            DeliveryAddress address2 =
                new DeliveryAddress(city2, street2, building2);

            shipment shipment2 =
                new shipment(trackingCode2, description2, weight2, fee2, address2);

            center.AddShipment(shipment2);


           
            Console.WriteLine("\nEnter Shipment 3 Data");

            Console.Write("Tracking Code: ");
            string trackingCode3 = Console.ReadLine();

            Console.Write("Description: ");
            string description3 = Console.ReadLine();

            Console.Write("Weight: ");
            double weight3 = double.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            decimal fee3 = decimal.Parse(Console.ReadLine());

            Console.Write("City: ");
            string city3 = Console.ReadLine();

            Console.Write("Street: ");
            string street3 = Console.ReadLine();

            Console.Write("Building Number: ");
            int building3 = int.Parse(Console.ReadLine());

            DeliveryAddress address3 =
                new DeliveryAddress(city3, street3, building3);

            shipment shipment3 =
                new shipment(trackingCode3, description3, weight3, fee3, address3);

            center.AddShipment(shipment3);


      
            Console.WriteLine("\n--- Shipments ---");

            center[0].PrintShipment();
            center[1].PrintShipment();
            center[2].PrintShipment();


            Console.Write("\nEnter Tracking Code to search: ");
            string searchCode = Console.ReadLine();

            shipment result = center[searchCode];

            if (!string.IsNullOrWhiteSpace(result.TrackingCode))
            {
                result.PrintShipment();
            }
            else
            {
                Console.WriteLine("Shipment not found.");
            }


            Console.WriteLine("\n--- Address Copy Test ---");

            DeliveryAddress originalAddress =
                new DeliveryAddress("Cairo", "Dokki", 10);

            DeliveryAddress copiedAddress = originalAddress;

            copiedAddress.City = "Giza";
            copiedAddress.Street = "Nasr City";
            copiedAddress.BuildingNumber = 20;

            Console.WriteLine("Original:");
            Console.WriteLine(originalAddress.GetFullAddress());

            Console.WriteLine("Copy:");
            Console.WriteLine(copiedAddress.GetFullAddress());






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

        public struct DeliveryAddress
        {
            public string City;
            public string Street;
            public int BuildingNumber;
            public DeliveryAddress(string city, string street, int buildingNumber)
            {
                City = city;
                Street = street;
                BuildingNumber = buildingNumber;
            }
            public string GetFullAddress()
            {
                return City + "," +Street + "Building" + BuildingNumber;
            }
        }

        public struct shipment
        {
            private string trackingCode;
            private string description;
            private double weight;
            private decimal deliveryFee;

            public DeliveryAddress Destination { get; set; }

            public string TrackingCode
            {
                get { return trackingCode; }

                private set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                        trackingCode = value;
                }
            }

            public string Description
            {
                get { return description; }
                set { 
                    if(!string.IsNullOrWhiteSpace(value))
                       description = value;
                        }
            }

            public double Weight
            {
                get { return weight;}
                set
                {
                    if(value > 0)
                        weight = value;
                }
            }

            public decimal DeliveryFee
            {
                get { return deliveryFee;}
               private set
                {
                    if (value >  0)
                        deliveryFee = value;
                }
            }

            public decimal EstimatedCost
            {
                get { return deliveryFee + (decimal)(weight * 5);}
            }

            public void PrintShipment()
            {
                Console.WriteLine("Tracking Code: " + TrackingCode);
                Console.WriteLine("Description: " + Description);
                Console.WriteLine("Weight: " + Weight);
                Console.WriteLine("Delivery Fee: " + DeliveryFee);
                Console.WriteLine("Destination: " + Destination.GetFullAddress());
                Console.WriteLine("Estimated Cost: " + EstimatedCost);
            }

            public void UpdateDeliveryFee(decimal newFee)
            {
                if (newFee > 0)
                {
                    DeliveryFee = newFee;
                }
            }

            public shipment( string trackingCode)
            {
                this.TrackingCode = trackingCode;
                this.description = "Unknown";
                this.weight = 1;
                this.deliveryFee = 50;
                this.Destination = new DeliveryAddress("Unknown", "Unknown", 0);
            }

            public shipment(string trackingCode, string description, double weight, decimal deliveryFee, DeliveryAddress destination)
            {
                this.weight = weight;
                this.DeliveryFee = deliveryFee;
                this.Destination = destination;
                this.TrackingCode = trackingCode;
                this.Description = description;
            }
        }
        public struct DeliveryCenter
        {
            private shipment[] shipments;

            public DeliveryCenter()
            {
                shipments = new shipment[10];
            }

           
            public shipment this[int index]
            {
                get
                {
                    if (index >= 0 && index < shipments.Length)
                        return shipments[index];

                    return default;
                }

                set
                {
                    if (index >= 0 && index < shipments.Length)
                        shipments[index] = value;
                }
            }

           
            public shipment this[string trackingCode]
            {
                get
                {
                    for (int i = 0; i < shipments.Length; i++)
                    {
                        if (shipments[i].TrackingCode == trackingCode)
                            return shipments[i];
                    }

                    return default;
                }
            }


            public bool AddShipment(shipment newShipment)
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(shipments[i].TrackingCode))
                    {
                        shipments[i] = newShipment;
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
