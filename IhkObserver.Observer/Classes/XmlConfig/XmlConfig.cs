namespace IhkObserver.Observer.Classes
{
    public class Credentials
    {
        #region[Properties]

        public string IdentNr { get; set; }


        public string PrueflingsNr { get; set; }
        #endregion

        #region [Constructor]

        public Credentials(string idNr, string prNr)
        {
            IdentNr = idNr;
            PrueflingsNr = prNr;
        }
        #endregion
    }
}

