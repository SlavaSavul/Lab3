using System;
using System.Collections.Generic;
using System.Text;


namespace Lab_3
{
    public class Time
    {
        public int Hours;
        public int Minutes;
        public int Seconds;
    }


    public partial class Part
    {
        private Part() { }
        public static void GetI()
        {
            Console.WriteLine(i); 
        }
    }




    public class Phone
    {
        static int Kol;
        readonly int Id;
        string Family;
        string Name;
        string Fatherland;
        string Address;
        string CreditCardNumber;
        int? Debit;
        int? Credit;
        Time DistanceCalls = new Time();
        Time SityCalls = new Time();
        const string PoleConst = "Const";

        public override bool Equals(object obj)
        {

            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Phone Obj = (Phone)obj;
            return (
                this.NAME == Obj.NAME &&
                this.FAMILY == Obj.FAMILY &&
                this.FATHERLAND == Obj.FATHERLAND &&
                this.ADDRESS == Obj.ADDRESS &&
                this.CREDITCARD == Obj.CREDITCARD &&
                this.DEBIT == Obj.DEBIT &&
                this.CREDIT == Obj.CREDIT &&
                this.DISTANCECALLS == Obj.DISTANCECALLS &&
                this.SITYCALLS == Obj.SITYCALLS
                );

        }


        public Phone(string family, string name, string fatherland) : this(null, null, new Time(), new Time())
        {
            Family = family;
            Name = name;
            Fatherland = fatherland;
            Id = (Family + Name + Fatherland).GetHashCode();

        }
        public Phone(string family, string name, string fatherland, string addriss, string creditCardNumber) : this(null, null, new Time(), new Time())
        {
            Family = family;
            Name = name;
            Fatherland = fatherland;
            Address = addriss;
            CreditCardNumber = creditCardNumber;
            Id = (Family + Name + Fatherland).GetHashCode();

        }
        public Phone(int? debit, int? credit, Time distanceCalls, Time sityCalls)
        {
            IncKol();
            Debit = debit;
            Credit = credit;
            DistanceCalls = distanceCalls;
            SityCalls = sityCalls;
        }




        public int ID
        {
            get
            {
                return Id;
            }
            private set
            {
                Credit = value;
            }
        }


        public string NAME
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value.ToString();
            }
        }
        public string FAMILY
        {
            get
            {
                return Family;
            }
            set
            {
                Family = value.ToString();
            }
        }
        public string FATHERLAND
        {
            get
            {
                return Fatherland;
            }
            set
            {
                Fatherland = value.ToString();
            }
        }
        public string ADDRESS
        {
            get
            {
                return Address;
            }
            set
            {
                Address = value.ToString();
            }
        }
        public string CREDITCARD
        {
            get
            {
                return CreditCardNumber;
            }
            set
            {
                CreditCardNumber = value.ToString();
            }
        }
        public int? DEBIT
        {
            get
            {
                return Debit;
            }
            set
            {
                Debit = value;
            }
        }
        public int? CREDIT
        {
            get
            {
                return Credit;
            }
            set
            {
                Credit = value;
            }
        }
        public string DISTANCECALLS
        {
            get
            {
                return (DistanceCalls.Hours).ToString() + ":" + (DistanceCalls.Minutes).ToString() + ":" + (DistanceCalls.Seconds).ToString();
            }
            set
            {
                string[] STR = value.Split(':');
                DistanceCalls.Hours = Int32.Parse(STR[0]);
                DistanceCalls.Minutes = Int32.Parse(STR[1]);
                DistanceCalls.Seconds = Int32.Parse(STR[2]);
            }
        }
        public string SITYCALLS
        {
            get
            {
                return (SityCalls.Hours).ToString() + ":" + (SityCalls.Minutes).ToString() + ":" + (SityCalls.Seconds).ToString();
            }
            set
            {
                string[] STR = value.Split(':');
                SityCalls.Hours = Int32.Parse(STR[0]);
                SityCalls.Minutes = Int32.Parse(STR[1]);
                SityCalls.Seconds = Int32.Parse(STR[2]);
            }
        }



        public void GetPersonInfo()
        {
            Console.WriteLine("\nId: " + ID + "\nName: " + Name + "\nFamily: " + Family + "\nFatherland: " + Fatherland + "\nAddress: " + Address + "\nCreditCardNumber: " + CreditCardNumber +
                "\nDebit: " + Debit + "\nCredit: " + Credit + "\nDistanceCalls: " + DISTANCECALLS + "\nSityCalls: " + SITYCALLS + "\n");
        }


        public void Balanse(ref int? balanse, out int id)
        {
            if (DEBIT != null && CREDIT != null)
                balanse = (int)DEBIT - (int)CREDIT;
            else balanse = null;
            id = ID;

        }


        static Phone()
        {
            Console.WriteLine(" static Phone()");
        }
        static void IncKol()
        {
            Kol++;
        }


        public static void GetInfo()
        {
            Console.WriteLine("Number of instances created " + Kol);
        }

        static public void TimeSityCalls(Phone[] MasPhone, string str)
        {
            Console.WriteLine(new string('*', 30));

            string[] STR = str.Split(':');
            foreach (Phone i in MasPhone)
            {
                string[] Calls = i.SITYCALLS.Split(':');

                if (int.Parse(STR[0]) < int.Parse(Calls[0])) Console.WriteLine("\nId: " + i.ID + "\nName: " + i.Name + "\nFamily: " + i.Family + "\nFatherland: " + i.Fatherland + "\nAddress: " + i.Address + "\nCreditCardNumber: " + i.CreditCardNumber);
                else if (int.Parse(STR[0]) == int.Parse(Calls[0]) && int.Parse(STR[1]) < int.Parse(Calls[1])) Console.WriteLine("\nId: " + i.ID + "\nName: " + i.Name + "\nFamily: " + i.Family + "\nFatherland: " + i.Fatherland + "\nAddress: " + i.Address + "\nCreditCardNumber: " + i.CreditCardNumber);
                else if (int.Parse(STR[0]) == int.Parse(Calls[0]) && int.Parse(STR[1]) == int.Parse(Calls[1]) && int.Parse(STR[2]) == int.Parse(Calls[2])) Console.WriteLine("\nId: " + i.ID + "\nName: " + i.Name + "\nFamily: " + i.Family + "\nFatherland: " + i.Fatherland + "\nAddress: " + i.Address + "\nCreditCardNumber: " + i.CreditCardNumber);
            }
            Console.WriteLine(new string('*', 30));
        }


        static public void IfDistanceCalls(Phone[] MasPhone)
        {
            Console.WriteLine(new string('=', 30));

            foreach (Phone i in MasPhone)
            {
                string[] Calls = i.DISTANCECALLS.Split(':');

                if (int.Parse(Calls[0]) > 0 || int.Parse(Calls[1]) > 0 || int.Parse(Calls[2]) > 0) Console.WriteLine("\nId: " + i.ID + "\nName: " + i.Name + "\nFamily: " + i.Family + "\nFatherland: " + i.Fatherland + "\nAddress: " + i.Address + "\nCreditCardNumber: " + i.CreditCardNumber);

            }
            Console.WriteLine(new string('=', 30));
        }



    }

    class Program
    {
        static void Main(string[] args)
        {
            Part.GetI();


           Phone Phone1 =new Phone("Petrov", "Anatoliy" ,"Vladimirovich");
           Phone Phone2 = new Phone( "Ivanov", "Boris", "Vitalevich", "Rafieva 23,3", "4000001232442321");
           Phone Phone3 = new Phone("Sidorov", "Vladimir", "Vladimirovich");
           Phone Phone4 = new Phone("Ivanov", "Alexandr", "Smirnov");

            Phone.GetInfo();
            Console.WriteLine(Phone1.Equals(Phone2));

            Phone1.CREDITCARD = "123686944413454";
            Phone1.ADDRESS = "Esenina 19, 24";
            Phone1.DISTANCECALLS = "13:45:32";
            Phone1.DEBIT = 0;
            Phone1.CREDIT = 12000;
            Phone1.SITYCALLS = "12:00:23";

            Phone2.SITYCALLS = "1:16:23";
            Phone2.DEBIT = 4200;
            Phone2.CREDIT = 12000;

            Phone3.SITYCALLS = "4:2:2";
            Phone3.CREDITCARD = "66666666666666666";
            Phone3.DISTANCECALLS = "3:45:32";

            Phone4.SITYCALLS = "0:12:6";
            Phone4.CREDITCARD = "9234934333222344";
            

            Phone1.GetPersonInfo();
            Phone2.GetPersonInfo();
            Phone3.GetPersonInfo();
            Phone4.GetPersonInfo();

            Console.WriteLine(Phone1.Equals(Phone2));
            Console.WriteLine(Phone1.GetType());
            Console.WriteLine(new string('-',30));



            Phone[] MasPhone= new Phone[4] { Phone1, Phone2, Phone3, Phone4 };



            // Phone.TimeSityCalls(MasPhone,"1:00:00");
            // Phone.IfDistanceCalls(MasPhone);
            int id ;
            int? balanse=null;
            Phone1.Balanse(ref balanse,out id);
            Console.WriteLine(id+"  "+ balanse);
            Console.ReadKey();
        }








    }


}
