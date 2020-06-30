using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*The program should have two ints, 
                CloudStorage which is initialized to 500, 
            and NetworkSpeed which is initialized to 10000.*/
            int CloudStorage = 500;
            int NetworkSpeed = 10000;


            Computer MyPrototype = new Computer();
            MyPrototype.HasAnAntenna = true;
            MyPrototype.HardDriveCapacity = 200;
            MyPrototype.RAM = 32;
            MyPrototype.Licenses = new int?[5] { 2, 0, 3, 0, 7 };
            Computer UserPrototype = new Computer();


            int numberOfComputers;
            int min = 5;
            int max = 20;
            int defaultVal = 10;

            Console.WriteLine("Choose the number of computers you would like to work with today: ");
            bool correctVal = GetIntFromUser(out numberOfComputers, min, max, defaultVal);

            if (!correctVal)
            {
                Console.WriteLine("You chose a value that was invalid. The number of computers you will track today has been set to 10.");
            }

            Computer[] computers = new Computer[numberOfComputers];
            int count = 0;
            int choice;
            while ((choice = menu()) != 11)
            {
                switch (choice)
                {
                    case 1:
                        AddAComputer(ref count, computers);
                        break;
                    case 2:
                        AddYourProtoTypeComp(UserPrototype);
                        break;
                    case 3:
                        RemoveYourProtoTypeComp(UserPrototype);
                        break;
                    case 4:
                        UpgradeCloudStorage(ref CloudStorage);
                        break;
                    case 5:
                        DowngradeCloudStorage(ref CloudStorage);
                        break;
                    case 6:
                        UpgradeNetworkSpeed(ref NetworkSpeed);
                        break;
                    case 7:
                        DowngradeNetworkSpeed(ref NetworkSpeed);
                        break;
                    case 8:
                        PrintSummaryByArrayIndex(computers, MyPrototype, CloudStorage, NetworkSpeed);
                        break;
                    case 9:
                        PrintStatisticsOfAllComputers(computers, CloudStorage, NetworkSpeed);
                        break;
                    case 10:
                        PrintStatisticsOfSpecificComputers(computers, CloudStorage, NetworkSpeed, MyPrototype, UserPrototype);
                        break;

                    default:
                        Console.WriteLine("You entered an incorrect value. Please try again");
                        break;

                }
            }

        }

        private static void PrintStatisticsOfAllComputers(Computer[] computers, int cloudStorage, int networkSpeed)
        {
            int averageRam = 0;
            int percentWithAntenna = 0;
            int percentWithoutAntenna = 0;
            int numberOfComputers = 0;
            double averageHardDriveCapacity = 0;
            int? averageSoftwareLicense = 0;
            int? averageNumberOfLicenses = 0;

            for (int i = 0; i < computers.Length; i++)
            {
                averageRam += computers?[i]?.RAM ?? 0;
               
                averageHardDriveCapacity += computers?[i]?.HardDriveCapacity ?? 0;
                
                if (computers[i]?.HasAnAntenna != null)
                {
                    if (computers?[i]?.HasAnAntenna == true)
                    {
                        percentWithAntenna += 1;
                        numberOfComputers += 1;
                    }
                    else if (computers?[i]?.HasAnAntenna == false)
                    {
                        percentWithoutAntenna += 1;
                        numberOfComputers += 1;
                    }
                }

                for (int index = 0; i < (computers[i]?.Licenses?.Length ?? (-1)); i++)
                {
                    if ((computers[i].Licenses[i] ?? -1) <= 0)
                    {
                        averageSoftwareLicense += 0;
                        averageNumberOfLicenses += 0;
                    }
                    else {
                        averageSoftwareLicense += computers[i].Licenses[i];
                        averageNumberOfLicenses += 1;
                    }

                }
            }
            if (computers.Count(e => e != null && e.HardDriveCapacity != null) != 0)
            {
                averageHardDriveCapacity /= computers.Count(e => e != null && e.HardDriveCapacity != null);
            }
            if (computers.Count(e => e != null && e.RAM != null)!=0) {
                averageRam /= computers.Count(e => e != null && e.RAM != null);
            }
            if (numberOfComputers != 0)
            {
                percentWithAntenna = (percentWithAntenna * 100) / numberOfComputers;
                percentWithoutAntenna = (percentWithoutAntenna * 100) / numberOfComputers;
            }
            if (averageNumberOfLicenses != 0)
            {
                averageSoftwareLicense /= averageNumberOfLicenses;
            }
            if (computers.Count(e => e != null && e.Licenses != null) != 0)
            {
                averageNumberOfLicenses /= computers.Count(e => e != null && e.Licenses != null);
            }
            Console.WriteLine("Average HardDrive Capacity: " + averageHardDriveCapacity);
            Console.WriteLine("Average Ram: "+ averageRam);
            Console.WriteLine("Percent with an Antenna: %"+percentWithAntenna);
            Console.WriteLine("Percent without an Antenna: %" + percentWithoutAntenna);
            Console.WriteLine("Average Software Licenses per program: "+averageSoftwareLicense);
            Console.WriteLine("Average Number of Licenses in general: " + averageNumberOfLicenses);
            Console.WriteLine("Cloud Storage: "+cloudStorage);
            Console.WriteLine("Network Speed: " + networkSpeed);
        }

        private static void PrintStatisticsOfSpecificComputers(Computer[] computers, int cloudStorage, int networkSpeed, Computer yourPrototype, Computer myPrototype)
        {
            Console.WriteLine("Which computer would you like to start with? ");
            int startNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Which computer would you like to end with?" );
            int endNum = int.Parse(Console.ReadLine());
            int? averageRam = 0;
            int percentWithAntenna = 0;
            int percentWithoutAntenna = 0;
            int numberOfComputers = 0;
            double? averageHardDriveCapacity = 0;
            int? averageSoftwareLicense = 0;
            int? averageNumberOfLicenses = 0;
            int i = 0;
            for (i =  startNum; i < endNum; i++)
            {
                averageRam += computers?[i]?.RAM ?? yourPrototype.RAM ?? myPrototype.RAM;

                averageHardDriveCapacity += computers?[i]?.HardDriveCapacity ?? yourPrototype.HardDriveCapacity ?? myPrototype.HardDriveCapacity;

               
                
                    if (computers[i]?.HasAnAntenna ?? yourPrototype.HasAnAntenna ?? myPrototype.HasAnAntenna == true)
                    {
                        percentWithAntenna += 1;
                        numberOfComputers += 1;
                    }
                    else if (computers[i]?.HasAnAntenna ?? yourPrototype.HasAnAntenna ?? myPrototype.HasAnAntenna == false)
                    {
                        percentWithoutAntenna += 1;
                        numberOfComputers += 1;
                    }
                

                for (int index = 0; i < (computers[i]?.Licenses?.Length ?? yourPrototype?.Licenses?.Length ?? myPrototype?.Licenses?.Length); i++)
                {
                    if ((computers[i].Licenses[i]) <= 0)
                    {
                        averageSoftwareLicense += 0;
                        averageNumberOfLicenses += 0;
                    }
                    else
                    {
                        averageSoftwareLicense += computers[i].Licenses[i];
                        averageNumberOfLicenses += 1;
                    }

                }
            }
            averageHardDriveCapacity /= i+1;
            averageRam /= i+1;
            percentWithAntenna = (percentWithAntenna * 100) / numberOfComputers == 0 ? numberOfComputers = 1: numberOfComputers ;
            percentWithoutAntenna = (percentWithoutAntenna * 100) / numberOfComputers == 0 ? numberOfComputers = 1 : numberOfComputers;
            averageSoftwareLicense /= averageNumberOfLicenses ==0 ? averageNumberOfLicenses = 1 : numberOfComputers ;
            averageNumberOfLicenses /= i + 1;
            Console.WriteLine("Average HardDrive Capacity: " + averageHardDriveCapacity);
            Console.WriteLine("Average Ram: " + averageRam);
            Console.WriteLine("Percent with an Antenna: %" + percentWithAntenna);
            Console.WriteLine("Percent without an Antenna: %" + percentWithoutAntenna);
            Console.WriteLine("Average Software Licenses per program: " + averageSoftwareLicense);
            Console.WriteLine("Average Number of Licenses in general: " + averageNumberOfLicenses);
            Console.WriteLine("Cloud Storage: " + cloudStorage);
            Console.WriteLine("Network Speed: " + networkSpeed);
        }


        private static void PrintSummaryByArrayIndex(Computer[] computers, Computer prototype, int cloudStorage, int networkSpeed)
        {
            Console.WriteLine("Which computer would you like to see a summary of? ");
            int index = int.Parse(Console.ReadLine());
            Computer comp = computers?[index] ?? prototype;
            Console.WriteLine(comp.ToString());
            Console.WriteLine("Cloud storage: " + cloudStorage);
            Console.WriteLine("Network Speed " + networkSpeed);
        }

        private static void DowngradeNetworkSpeed(ref int networkSpeed)
        {
            int minimum = 10000;
            bool setToMin = false;
            bool set = HalveValueNotPastMin(ref networkSpeed, minimum, setToMin);
            if (set) { Console.WriteLine("Your network speed has been downgraded to " + networkSpeed); }
            else { Console.WriteLine("Your network speed has not been set because it was too low"); }
        }

        private static void UpgradeNetworkSpeed(ref int networkSpeed)
        {
            int maximum = 250000;
            bool setToMax = true;
            bool set = DoubleIntNotPastMax(ref networkSpeed, maximum, setToMax);
            if (set) { Console.WriteLine("Your network speed has been set to " + networkSpeed); }
            else { Console.WriteLine("Your network speed has been upgraded to 250000 because that is the maximum"); }
        }

        private static void DowngradeCloudStorage(ref int CloudStorage)
        {
            int minimum = 500;
            bool setToMin = true;
            bool set = HalveValueNotPastMin(ref CloudStorage, minimum, setToMin);
            if (set) { Console.WriteLine("Your cloud storage has been downgraded to " + CloudStorage); }
            else { Console.WriteLine("Your Cloud storage has been set to the minimum"); }

        }

        private static void UpgradeCloudStorage(ref int CloudStorage)
        {

            int maximum = 16000;
            bool setToMax = false;
            bool set = DoubleIntNotPastMax(ref CloudStorage, maximum, setToMax);
            if (set) { Console.WriteLine("Your cloud storage has been set to " + CloudStorage); }
            else { Console.WriteLine("Your cloud storage has not been upgraded because you exceeded the max "); }
        }
        private static Computer RemoveYourProtoTypeComp(Computer computer)
        {
            computer = null;
            
            return computer;




        }
        private static Computer AddYourProtoTypeComp(Computer computer)
        {
            string id;
            bool? hasAnAntenna;
            double? hardDriveCap;
            int? ram;
            int num;
            GetComputerInfo(out hasAnAntenna, out hardDriveCap, out ram, out num);
            computer.HasAnAntenna = hasAnAntenna;
            computer.HardDriveCapacity = hardDriveCap;
            computer.RAM = ram;
            computer.Licenses = new int?[num];
            getLicenses(num, computer);

            return computer;




        }



        private static void AddAComputer(ref int count, Computer[] computers)
        {

            Computer computer = CreateComputer();
            computers[count] = computer;
            count++;
        }

        private static Computer CreateComputer()
        {

            bool? hasAnAntenna;
            double? hardDriveCap;
            int? ram;
            int num;
            GetComputerInfo(out hasAnAntenna, out hardDriveCap, out ram, out num);
            Computer temp = new Computer(hasAnAntenna, hardDriveCap, ram, num);
            Console.WriteLine("A new computer has been added to the system. Now it is time to enter software.");
            char more = 'Y';
            getLicenses(num, temp);

            return temp;
        }

        private static void getLicenses(int num, Computer temp)
        {
            int i = 0;
            while (i < num)
            {
                Console.WriteLine("Enter 0 for unlicensed software, Enter number of licenses for licensed software and 'N/A' " +
                    "if this is not applicable to you.");
                String license = Console.ReadLine();
                int number;

                bool success = int.TryParse(license, out number);
                temp.addSoftware(i, number);
                i++;
            }
        }

        private static void GetComputerInfo(out bool? hasAnAntenna, out double? hardDriveCap, out int? ram, out int num)
        {

            Console.WriteLine("Does your computer have an antenna? Enter Y/N or N/A");
            String response = Console.ReadLine().ToUpper();
            if (response.Equals("Y"))
            {
                hasAnAntenna = true;
            }
            else if (response.Equals("N"))
            {
                hasAnAntenna = false;
            }
            else
            {
                hasAnAntenna = null;
            }
            Console.WriteLine("What is the hard drive capacity? Enter -1 if this not applicable");
            double ans = double.Parse(Console.ReadLine());
            if (ans > -1)
            {
                hardDriveCap = ans;
            }
            else
            {
                hardDriveCap = null;
            }
            Console.WriteLine("How much RAM is there? Enter -1 if this not applicable");
            int answer = int.Parse(Console.ReadLine());
            if (answer > -1)
            {
                ram = answer;
            }
            else
            {
                ram = null;
            }
            Console.WriteLine("How many types of software does this computer have. Please choose up to 5 (Enter \"n\" for none)? ");
            String numOfTypes = Console.ReadLine();
            bool ok = int.TryParse(numOfTypes, out num);
        }

        /*1.GetIntFromUser•
            The job of this method is to initialize an int variable with a value taken 
            from the user within a specified range.
            The method returns a bool and takes four parameters: 
            1) an int called number, 
            2) an int called min, 
            3) an int called max, 
            4) an int called defaultVal.
            number will be initialized by this method so it has to be taken by reference.
            The method will ask the user for a number between min and max(inclusive). 
            If the user gives an int in the correct range, numberis initialized to this value and true is returned. 
            If the user gives a value outside of the range, numberis initialized to defaultValand false is returned.*/
        public static bool GetIntFromUser(out int number, int min, int max, int defaultVal)

        {
            Console.WriteLine("Enter a number from " + min + "to" + max);
            int received = int.Parse(Console.ReadLine());
            if (received >= min && received <= max)
            {
                number = received;
                return true;
            }
            else
            {
                number = defaultVal;
                return false;
            }


        }




        /*2.DoubleIntNotPastMax•
         * The job of this method is to set an int variable to twice its current value 
         * unless doing so would exceed a specified maximum value. The method returns a 
         * bool and takes three parameters:
         * 1) an int called number, 
         * 2) an int called max,
         * 3) a bool called setToMax.
         * number may be set by the method so it has to be taken by reference.
         * The method will check if doubling number will cause it to exceed max.
         * If it will not, the method sets number to double its present value and returns true.
         * If numberwould exceed max the method checks the value of setToMax.
         * If setToMaxis set to true, the method changes numberto maxand returns false. 
         * If setToMaxis set to false, the method does not change numberand returns false.*/

        public static bool DoubleIntNotPastMax(ref int number, int max, bool setToMax)
        {
            if ((number + number) <= max)
            {
                number = 2 * number;
                return true;
            }
            else
            {

                if (setToMax)
                {
                    number = max;
                    return false;
                }
                else
                {
                    return false;
                }
            }




        }

        /*3.HalveValueNotPastMin•
            The job of this method is to set an int variable to half its current value 
            unless doing so would cause it to go below a specified minimum value. 
            The method returns a bool and takes three parameters: 
            1) an int called number, 
            2) an int called min, 
            3) a bool called setToMin.
            number may be set by the method so it has to be taken by reference.
            The method will check if halving number will cause it to go below min.
            If it will not, the method sets number to half its present value 
            (with standard integer division, do not worry about odd numbers) and returns true. 
            If numberwould go below min the method checks the value of setToMin.If setToMinis set to true,
            the method changes numberto min and returns false. 
            If setToMin is set to false, the method does not change numberand returns false.*/

        public static bool HalveValueNotPastMin(ref int number, int min, bool setToMin)
        {
            if (number / 2 >= min)
            {
                number = number / 2;
                return true;
            }
            else
            {
                if (setToMin)
                {
                    number = min;
                    return false;

                }
                else
                {
                    return false;
                }
            }
        }

        public static int menu()
        {

            Console.WriteLine(@"Welcome! Pick one of the options below:
                                1. Add a computer
                                2. Add your prototype Computer 
                                3. Remove your prototype Coomputer 
                                4. Upgrade cloud storage
                                5. Downgrade cloud storage
                                6. Upgrade Network Speed
                                7. Downgrade Network Speed
                                8. Get a summary of one of the computers
                                9. Get a summary of statistics of all the computers entered
                               10. Get a specific summary of select computers entered
                               11. Exit");
            int num = int.Parse(Console.ReadLine());
            return num;
        }
    }
}
