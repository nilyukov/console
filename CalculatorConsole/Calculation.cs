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
        private double pod;

        private string speciesSubstance;
        private string lengthSubstance;

        private bool resp;
        private bool cardio;
        private bool neur;
        private bool carc;
        private bool irr;




        public Calculation(string substance, double expi, double refi, bool resp, bool cardio, bool neur, bool carc, bool irr, double hazardCoefficient, double pod, string speciesSubstance, string lengthSubstance)
        {
            this.substance = substance;
            this.expi = expi;
            this.refi = refi;
            this.hazardCoefficient = hazardCoefficient;
            this.pod = pod;

            this.speciesSubstance = speciesSubstance;
            this.lengthSubstance = lengthSubstance;

            this.resp = resp;
            this.cardio = cardio;
            this.neur = neur;
            this.carc = carc;
            this.irr = irr; ;
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
        
        public double Pod
        {
            get { return pod; }
            set { pod = value; }
        }
        
        public string SpeciesSubstance
        {
            get { return speciesSubstance; }
            set { speciesSubstance = value; }
        }
        
        public string LengthSubstance
        {
            get { return lengthSubstance; }
            set { lengthSubstance = value; }
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
}
