using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorConsole
{


    public class Calculation
    {
        private string substance;
        private double expi;
        private double refi;
        private double hazardCoefficient;

        private bool resp;
        private bool cardio;
        private bool neur;
        private bool carc;
        private bool irr;


        public Calculation(string substance, double expi, double refi, bool resp, bool cardio, bool neur, bool carc, bool irr, double hazardCoefficient)
        {
            this.substance = substance;
            this.expi = expi;
            this.refi = refi;
            this.hazardCoefficient = hazardCoefficient;

            this.resp = resp;
            this.cardio = cardio;
            this.neur = neur;
            this.carc = carc;
            this.irr = irr;;
        }

        public string Substance
        {
            get { return substance; }
            set { substance = value; }
        }

        public double Expi
        {
            get { return expi; }
            set { expi = value; }
        }
        
        public double Refi
        {
            get { return refi; }
            set { refi = value; }
        }

        public double HazardCoefficient
        {
            get { return hazardCoefficient; }
            set { hazardCoefficient = value; }
        }

        public bool Resp
        {
            get { return resp; }
            set { resp = value; }
        }

        public bool Cardio
        {
            get { return cardio; }
            set { cardio = value; }
        }

        public bool Neur
        {
            get { return neur; }
            set { neur = value; }
        }

        public bool Carc
        {
            get { return carc; }
            set { carc = value; }
        }

        public bool Irr
        {
            get { return irr; }
            set { irr = value; }
        }

        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(866);
            Console.InputEncoding = Encoding.GetEncoding(866);

            Random random = new Random();
           

            int countSubstance;
            string substance;
            double expi;
            double refi;
            double hazardCoefficient;
            


            bool resp; 
            bool cardio; 
            bool neur; 
            bool carc; 
            bool irr;


            Console.Write("Введите количество веществ:\n");
            countSubstance = Int32.Parse(Console.ReadLine());

            List<Calculation> calculations = new List<Calculation>();
            for (int i = 0; i < countSubstance; i++)
            {
                Console.Write("Введите " + i + " название вещества:\n");
                substance = Convert.ToString(Console.ReadLine());

                Console.Write("Введите измеренную концентрацию для " + i + " вещества(expi):\n");
                expi = Convert.ToDouble(Console.ReadLine());

                refi = 20;

                resp = random.Next(10) < 4;
                cardio = random.Next(10) < 4;
                neur = random.Next(10) < 4;
                carc = random.Next(10) < 4;
                irr = random.Next(10) < 4;

                hazardCoefficient = expi / refi;

                calculations.Add(new Calculation(substance, expi, refi, resp, cardio, neur, carc, irr, hazardCoefficient));

                Console.Write("\n\n");

            }

            foreach(Calculation calculation in calculations)
            {
                Console.Write("Название вещества: " + calculation.Substance + "\n");
                Console.Write("Измеренная концентрация вещества: " + calculation.Expi + "\n");
                Console.Write("Контрольная концентрация вещества: " + calculation.Refi + "\n");
                Console.Write("Коэффициент опасности вещества: " + calculation.HazardCoefficient + "\n");
                Console.Write("Респираторное значение: " + calculation.Resp + "\n");
                Console.Write("Сердечно-сосудистое значение: " + calculation.Cardio + "\n");
                Console.Write("Неврологическое значение: " + calculation.Neur + "\n");
                Console.Write("Карцерогенное значение: " + calculation.Carc + "\n");
                Console.Write("Раздражение глаз значение: " + calculation.Irr + "\n");

                Console.Write("\n\n");
            }

            double hazardIndex = 0;
            double hazardIndexResp = 0;
            double hazardIndexCardio = 0;
            double hazardIndexNeur = 0;
            double hazardIndexCarc = 0;
            double hazardIndexIrr = 0;
            
            foreach (Calculation calculation in calculations)
            {
                hazardIndex += calculation.HazardCoefficient;

                if (calculation.Resp)
                {
                    hazardIndexResp += calculation.HazardCoefficient;
                }

                if (calculation.Cardio)
                {
                    hazardIndexCardio += calculation.HazardCoefficient;
                }

                if (calculation.Neur)
                {
                    hazardIndexNeur += calculation.HazardCoefficient;
                }

                if (calculation.Carc)
                {
                    hazardIndexCarc += calculation.HazardCoefficient;
                }

                if (calculation.Irr)
                {
                    hazardIndexIrr += calculation.HazardCoefficient;
                }

            }

            Console.Write("Индекс опасности веществ: " + hazardIndex + "\n");
            Console.Write("Индекс опасности веществ по респираторным значениям: " + hazardIndexResp + "\n");
            Console.Write("Индекс опасности веществ по кардио-васкулярным значениям: " + hazardIndexCardio + "\n");
            Console.Write("Индекс опасности веществ по неврологическим значениям: " + hazardIndexNeur + "\n");
            Console.Write("Индекс опасности веществ по карцерогенным значениям: " + hazardIndexCarc + "\n");
            Console.Write("Индекс опасности веществ по значениям раздражения глаз: " + hazardIndexIrr + "\n");


            Console.ReadKey();
        }
    }
}
