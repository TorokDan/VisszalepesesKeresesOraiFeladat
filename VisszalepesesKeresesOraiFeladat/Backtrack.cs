using System;

namespace VisszalepesesKeresesOraiFeladat
{
    delegate void AllapotFigyelo(int szam, object[] objektumok);
    abstract class Backtrack
    {
        protected int n;  // Részfeladatok száma Üres mezők száma
        protected int[] m;  // Részfeladathoz tartozó megoldások száma


        protected object[][] r;  // A lehetséges részmegoldásokat tartalmazza

        abstract public bool Ft(int szam, object objektum);
        abstract public bool Fk(int szam1, object objektum1, int szam2, object objektum2);

        public AllapotFigyelo Probalkozas;

        /// <summary>
        /// TODO
        /// Ez indítja el magát a keresést.
        /// 
        /// </summary>
        /// <returns></returns>
        public object[] Keres()
        {
            bool van = false;
            object[] e = new object[r.Length];

            Probal(0, ref van, e);
            if (van)
                return e;
            else
                throw new NincsMegoldasKivetel("Nincs megoldása a feladatnak");
        }

        /// <summary>
        /// TODO 
        /// Ez a metódus csinálja magát a keresést
        /// Nagy az esély arra, hogy ez nem működik, de ezt majd még tesztelni kéne.
        /// Az eseménykezelés valszeg nem jó benne, nem tudom melyik számmal kéne meghívni, ez majd a végén, amikor kiiratgatom a dolgokat, fog kiderülni
        /// </summary>
        /// <param name="szint"></param>
        /// <param name="van"></param>
        /// <param name="e"></param>
        private void Probal(int szint, ref bool van, object[] e)
        {
            int i = -1;
            while (!van && i < r[szint].Length - 1)
            {
                i++;
                if (Ft(szint, r[szint][i]) && 
                    Fk(szint, new object(), i, new object())) // TODO ez itt kérdéses, h miket kell vizsgálni, később h ha az Fk metódust megírjuk ezt módosítani kell
                {
                    e[i] = r[szint][i];
                    Probalkozas?.Invoke(n++, e);  // TODO  Valszeg a szám nem jó
                    if (i == e.Length)
                    {
                        van = true;
                    }
                    else
                    {
                        Probal(szint + 1, ref van, e);
                    }
                }
            }
        }
    }
}
