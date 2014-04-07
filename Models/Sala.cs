using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Sala
    {
        private int sjediste;
        private int kapacitet;

        private List<int> sjedista = new List<int>();

        public Sala(int nsjediste, int nkapacitet, List<int> nsjedista)
        {
            sjediste = nsjediste;
            kapacitet = nkapacitet;
            sjedista = nsjedista;

        }

        public List<int> Sjedista
        {
            get { return sjedista; }
            set { sjedista = value; }
        }


        public int Kapacitet
        {
            get { return kapacitet; }
            set { kapacitet = value; }
        }


        public int Sjediste
        {
            get { return sjediste; }
            set { sjediste = value; }
        }
	
    }
}
