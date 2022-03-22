namespace VisszalepesesKeresesOraiFeladat
{
    class Pozicio
    {
        private int sor;
        private int oszlop;
        private bool fix;
        private object ertek = null;

        public int Sor { get => sor; }
        public int Oszlop { get => oszlop; }
        public bool Fix { get => fix; }
        public object Ertek { get => ertek; set => ertek = value; }

        public Pozicio(int sor, int oszlop)
        {
            this.sor = sor;
            this.oszlop = oszlop;
            fix = false;
        }
        public Pozicio(int sor, int oszlop, object ertek)
            : this(sor, oszlop)
        {
            Ertek = ertek;
            fix = true;
        }
        /// <summary>
        /// TODO Visszaadja, hogy egymáshoz viszonyítva ki vannak-e zárva a pozíciók. Előfordulhat, hogy ebben hiba van, mert nincs kitesztelve.
        /// </summary>
        /// <param name="pozicio1"></param>
        /// <param name="pozicio2"></param>
        /// <returns></returns>
        public static bool Kizaroak(Pozicio pozicio1, Pozicio pozicio2)
        {
            bool kizarva = false;
            if (pozicio1.oszlop == pozicio2.oszlop || pozicio1.sor == pozicio2.sor || AzonosNegyzet(pozicio1, pozicio2))
                kizarva = true;
            return kizarva;
        }
        private static bool AzonosNegyzet(Pozicio pozicio1, Pozicio pozicio2)
        {
            bool azonos = false;
            if (AzonosTomb(GetNegyzet(pozicio1.sor), GetNegyzet(pozicio2.sor)) &&
                AzonosTomb(GetNegyzet(pozicio1.oszlop), GetNegyzet(pozicio2.oszlop)))
            {
                azonos = true;
            }
            return azonos;
        }
        /// <summary>
        /// Visszaadja egy adott pozícióhoz (sor vagy oszlop) tartozó határértékeket. Feltételezi, hogy egy sudoku-t oldunk meg, ezért a sorhosszúságot 9-nek veszi.
        /// </summary>
        /// <param name="pozicio"></param>
        /// <returns>Egy két elemő tömb, melynek első eleme az alsó, második eleme a felső határ (a határok még az adott négyzetbe tartoznak)</returns>
        private static int[] GetNegyzet(int pozicio)
        {
            int also = 0;
            int felso = 2;
            bool megvan = false;

            while (!megvan)
            {
                if (also <= pozicio && pozicio <= felso)
                    megvan = true;
                else
                {
                    also += 3;
                    felso += 3;
                }
            }
            return new int[] {also, felso};
        }
        /// <summary>
        /// Visszaadja, hogy két tömb elemeinek értékei megegyeznek-e. Feltételezi, hogy ez a két tömb a GetNegyzet metódussal lett létrehozva, vagyis elemszámuk 2.
        /// </summary>
        /// <param name="tomb1"></param>
        /// <param name="tomb2"></param>
        /// <returns></returns>
        private static bool AzonosTomb(int[] tomb1, int[] tomb2)
        {
            int i = 0;
            while (i < tomb1.Length && tomb1[i] == tomb2[i])
                i++;
            return i == tomb1.Length;
        }
    }
}
