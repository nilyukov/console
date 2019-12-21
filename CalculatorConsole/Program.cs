using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorConsole
{

    public class AssesmentFactors
    {
        public int Human { get; set; } = 10;
        public int Animal { get; set; } = 10;
        public int Acute { get; set; } = 6;
        public int Chronic { get; set; } = 1;
        public int Intermediate { get; set; } = 2;

    }

    class Program
    {
        static int GetFactorSubstance(string substance)
        {
            AssesmentFactors factors = new AssesmentFactors();
            switch (substance)
            {
                case "H":
                    return factors.Human;
                    break;
                case "A":
                    return factors.Animal;
                    break;
                case "AC":
                    return factors.Acute;
                    break;
                case "CR":
                    return factors.Chronic;
                    break;
                case "IM":
                    return factors.Intermediate;
                    break;         
                default:
                    return 0;
                    break;
            }
        }

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
            double pod;

            List<string> species = new List<string>() { "H", "A" };
            List<string> length = new List<string>() { "AC", "CR", "IM" };

            string speciesSubstance;
            string lengthSubstance;

            double durationStudyFactor = 1;

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
                
                substance = "Вещество №" + i;
              
                expi = Convert.ToDouble(random.Next(10));

                refi = Convert.ToDouble(random.Next(10));

                pod = Convert.ToDouble(random.Next(10000));

                speciesSubstance = species[Convert.ToInt32(random.Next(species.Count))];

                lengthSubstance = length[Convert.ToInt32(random.Next(length.Count))];


                resp = random.Next(10) < 4;
                cardio = random.Next(10) < 4;
                neur = random.Next(10) < 4;
                carc = random.Next(10) < 4;
                irr = random.Next(10) < 4;

                hazardCoefficient = expi / refi;

                calculations.Add(new Calculation(substance, expi, refi, resp, cardio, neur, carc, irr, hazardCoefficient, pod, speciesSubstance, lengthSubstance));

                Console.Write("\n\n");

            }

            foreach(Calculation calculation in calculations)
            {
                Console.Write("Название вещества: " + calculation.Substance + "\n");
                Console.Write("Измеренная концентрация вещества: " + calculation.Expi + "\n");
                Console.Write("Контрольная концентрация вещества: " + calculation.Refi + "\n");
                Console.Write("Pod: " + calculation.Pod + "\n");
                Console.Write("Species: " + calculation.SpeciesSubstance + "\n");
                Console.Write("Length: " + calculation.LengthSubstance + "\n");
                Console.Write("Коэффициент опасности вещества: " + calculation.HazardCoefficient + "\n");
                Console.Write("Респираторное значение: " + calculation.Resp + "\n");
                Console.Write("Сердечно-сосудистое значение: " + calculation.Cardio + "\n");
                Console.Write("Неврологическое значение: " + calculation.Neur + "\n");
                Console.Write("Карцерогенное значение: " + calculation.Carc + "\n");
                Console.Write("Раздражение глаз значение: " + calculation.Irr + "\n");

                Console.Write("\nPod: " + calculation.Pod + "\n");

                Console.Write("\n\n");
            }

            double hazardIndex = 0;
            double hazardIndexResp = 0;
            double hazardIndexCardio = 0;
            double hazardIndexNeur = 0;
            double hazardIndexCarc = 0;
            double hazardIndexIrr = 0;


            double podiResp = 0;
            double podiCardio = 0;
            double podiNeur = 0;
            double podiCarc = 0;
            double podiIrr = 0;

            foreach (Calculation calculation in calculations)
            {
                hazardIndex += calculation.HazardCoefficient;

                int factorSpecies = GetFactorSubstance(calculation.SpeciesSubstance);
                int factorLength = GetFactorSubstance(calculation.LengthSubstance);

                if (calculation.Resp)
                {               
                    hazardIndexResp += calculation.HazardCoefficient;
                    podiResp += calculation.Expi / (calculation.Pod / ((factorSpecies * factorLength) / durationStudyFactor));

                }

                if (calculation.Cardio)
                {
                    hazardIndexCardio += calculation.HazardCoefficient;
                    podiCardio += calculation.Expi / (calculation.Pod / ((factorSpecies * factorLength) / durationStudyFactor));
                }

                if (calculation.Neur)
                {
                    hazardIndexNeur += calculation.HazardCoefficient;
                    podiNeur += calculation.Expi / (calculation.Pod / ((factorSpecies * factorLength) / durationStudyFactor));
                }

                if (calculation.Carc)
                {
                    hazardIndexCarc += calculation.HazardCoefficient;
                    podiCarc += calculation.Expi / (calculation.Pod / ((factorSpecies * factorLength) / durationStudyFactor));
                }

                if (calculation.Irr)
                {
                    hazardIndexIrr += calculation.HazardCoefficient;
                    podiIrr += calculation.Expi / (calculation.Pod / ((factorSpecies * factorLength) / durationStudyFactor));
                }

            }

            

            Console.Write("Индекс опасности веществ: " + hazardIndex + "\n");
            Console.Write("Индекс опасности веществ по респираторным значениям: " + hazardIndexResp + "\n");
            Console.Write("Индекс опасности веществ по кардио-васкулярным значениям: " + hazardIndexCardio + "\n");
            Console.Write("Индекс опасности веществ по неврологическим значениям: " + hazardIndexNeur + "\n");
            Console.Write("Индекс опасности веществ по карцерогенным значениям: " + hazardIndexCarc + "\n");
            Console.Write("Индекс опасности веществ по значениям раздражения глаз: " + hazardIndexIrr + "\n");


            Console.Write("Podi по респираторным значениям: " + podiResp + "\n");
            Console.Write("Podi по кардио-васкулярным значениям: " + podiCardio + "\n");
            Console.Write("Podi по неврологическим значениям: " + podiNeur + "\n");
            Console.Write("Podi по карцерогенным значениям: " + podiCarc + "\n");
            Console.Write("Podi по значениям раздражения глаз: " + podiIrr + "\n");

            Console.ReadKey();
        }

    }
}
