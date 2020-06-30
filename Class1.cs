using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Computer
    {
        private string id;
        private bool? hasAnAntenna;
        private double? hardDriveCap;
        private int? ram;
        private int?[] licenses;
        public static int idStart = 1;

        public string ID { get { return id; } }//didnt let me use the readonly key for some reason
        public bool? HasAnAntenna { get { return hasAnAntenna; } set { hasAnAntenna = value; } }
        public double? HardDriveCapacity

        {
            get { return hardDriveCap; }


            set { if (value >= 0 || value == null) { hardDriveCap = value; } else throw new Exception("That value is not valid."); }
        }

        public int? RAM
        {
            get
            {
                if (!HasAnAntenna ?? false)
                {
                    return ram + 50 + 10 * getNumberOfLicenses();

                }
                else
                {
                    return ram + 100 + 10 * getNumberOfLicenses();
                }
            }


            set { if (value < 1000 || value == null) { ram = value; } else throw new Exception("That value is not valid."); }
        }

        public int?[] Licenses { get { return licenses; } set { } }

        public Computer()
        {

        }


        public Computer(bool? hasAnAntenna, double? hardDriveCapacity, int? ram, int? val)
        {

            this.id = idStart + 1.ToString();
            this.hasAnAntenna = hasAnAntenna;
            this.hardDriveCap = hardDriveCapacity;
            this.ram = ram;
            this.licenses = new int?[val ?? -1];
        }

        public void addSoftware(int i, int? j, int val = 5)
        {

            (Licenses ?? new int?[val])[i] = j;
        }
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder("Computer: ");
            sb.Append("ID: " + id);
            sb.Append("\nHas An Antenna: ");
            sb.Append(HasAnAntenna ?? null);
            sb.Append("\nHard drive Capacity: ");
            sb.Append(HardDriveCapacity ?? -1);
            sb.Append("\nRam: ");
            sb.Append(RAM ?? -1);
            sb.Append("\nLicenses: ");
            for (int i = 0; i < (Licenses?.Length?? 0) ; i++)
            {
                if ((Licenses[i] ?? -1) < 0)
                {
                    sb.Append("Not Applicable");
                }

                else if (Licenses[i] == 0)
                {
                    sb.Append("Not Licensed");
                }
                else { sb.Append(i); }

            }
            return sb.ToString();

        }

        private int getNumberOfLicenses()
        {
            int count = 0;
            for (int i = 0; i < (Licenses?.Length ?? 0); i++)
            {
                if ((Licenses[i] ?? -1) > 0)
                {
                    count++;
                }

               
            }

            return count;
        }


    }
}