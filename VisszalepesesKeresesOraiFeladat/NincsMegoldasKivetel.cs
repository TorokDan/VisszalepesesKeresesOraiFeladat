namespace VisszalepesesKeresesOraiFeladat
{
    class NincsMegoldasKivetel : System.Exception
    {
        private string hibaUzenet;
        public NincsMegoldasKivetel(string hibaUzenet)
            :base(hibaUzenet)
        {
            this.hibaUzenet = hibaUzenet;
        }
    }
}
