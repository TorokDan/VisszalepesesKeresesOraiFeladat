namespace VisszalepesesKeresesOraiFeladat
{
    class SudokuMegoldo : Backtrack
    {
        protected Pozicio[,] tabla = new Pozicio[9, 9];
        protected Pozicio[] fixMezok = new Pozicio[0];
        protected Pozicio[] uresMezok = new Pozicio[0];

        public SudokuMegoldo(string filenev)
        {
            TablaBetoltes(filenev);
        }

        public void TablaBetoltes(string filenev)
        {
            // File beolvasása
            string[] sorok = System.IO.File.ReadAllLines(filenev);

            // tábla feltöltése, n mező értékének megadása
            for (int i = 0; i < sorok.Length; i++)
            {
                for (int j = 0; j < sorok[i].Length; j++)
                {
                    if ( sorok[i][j] == '.' )
                    {
                        this.n += 1;
                        tabla[i, j] = new Pozicio(i, j);
                    }
                    else
                    {
                        tabla[i, j] = new Pozicio(i, j, (int)sorok[i][j]);
                    }
                }
            }

            // m tömb feltöltése
            this.m = new int[n];
            for (int i = 0; i < m.Length; i++)
                m[i] = 9;

            // r tömb feltöltése. 
            // Konkrétan nem értem, h most ez hogy van.... Mikor kell mátrix, mikor fűrészfogas. A feladat szeirntem nem egyértelmű
            this.r = new object[n][];
            for (int i = 0; i < r.Length; i++)
            {
                r[i] = new object[9];
                //for (int j = 0; j < r[i].Length; j++)
                //{
                //    r[i][j] = new Pozicio(i, j, )
                //}
            }

            // Üres és fix mezőket tartalmazó tömbök feltöltése
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    if (tabla[i, j].Ertek == null)
                        TombNoveles(ref uresMezok, tabla[i, j]);
                    else
                        TombNoveles(ref fixMezok, tabla[i, j]);
                }
            }
        }
        public void Megoldas()
        {
            object[] eredmeny;
            try
            {
                eredmeny = Keres();
                for (int i = 0; i < eredmeny.GetLength(0); i++)
                {
                    for (int j = 0; j < eredmeny.GetLength(1); j++)
                    {
                        if (tabla[i, j].Ertek == null)
                        {
                            tabla[i, j] = (Pozicio)eredmeny[i];    // TODO Ez nem biztos, hogy jó
                            uresMezok[i] = (Pozicio)eredmeny[i];
                        }
                    }
                }
            }
            catch (NincsMegoldasKivetel e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Növeli az adott tömb méretét egyel, és hozzáad egy paraméterként kapott pozíciót.
        /// </summary>
        /// <param name="tomb"></param>
        /// <param name="pozicio"></param>
        private void TombNoveles(ref Pozicio[] tomb, Pozicio pozicio)
        {
            Pozicio[] tmp = new Pozicio[tomb.Length + 1];
            for (int i = 0; i < tomb.Length; i++)
                tmp[i] = tomb[i];
            tmp[tomb.Length] = pozicio;
            tomb = tmp;
        }

        public override bool Fk(int szam1, object objektum1, int szam2, object objektum2)
        {
            throw new System.NotImplementedException();
        }

        public override bool Ft(int szam, object objektum)
        {
            if ()
        }
    }
}
