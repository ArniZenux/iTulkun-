using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTulkun
{
    class clsPrenta : Global
    {
        #region "Um clsPrenta - klasi"
        //Klasi er ónotaður í útgáfu 1.0. Seinna skal að nota klasa í nýju útgáfu.
        #endregion

        #region "Class"
        clsVerkefni verk = new clsVerkefni();
        #endregion 

        #region "Variables"
        string number, tilefni, stadur, vettvangur;
        string nafnVidskipta, simanumer;
        string nafnTulkur;
        string greidsla;
        string dagur, tima_byrja, tima_endir;
        #endregion

        #region "Properties"
        public void setNumber(string number)
        {
            this.number = number; //verk.getId(); 
        }

        public void setTilefni(string tilefni)
        {
            this.tilefni = tilefni; //verk.getTilill(); 
        }

        public void setStadur(string stadur)
        {
            this.stadur = stadur; //verk.getStadur();
        }

        public void setVettvangur(string vettvangur)
        {
            this.vettvangur = vettvangur; //verk.getVettvangur();
        }

        public void setNafnVidskiptavinur(string nafnVid)
        {
            this.nafnVidskipta = nafnVid;
        }

        public void setSimanumer(string simanumer)
        {
            this.simanumer = simanumer;
        }

        public void setNafnTulkur(string nafnTulkur)
        {
            this.nafnTulkur = nafnTulkur;
        }

        public void setGreidsla(string greidsla)
        {
            this.greidsla = greidsla; //verk.getGreidsla();
        }

        public void setDagur(string dagur)
        {
            this.dagur = dagur; //verk.getDagur();
        }

        public void setTima_byrja(string tima_byrja)
        {
            this.tima_byrja = tima_byrja; //verk.getTima_Byrja();
        }

        public void setTima_endir(string tima_endir)
        {
            this.tima_endir = tima_endir; //verk.getTima_Endir();
        }

        public string getNumer()
        {
            return number;
        }

        public string getTilefni()
        {
            return tilefni;
        }

        public string getStadur()
        {
            return stadur;
        }

        public string getVettvangur()
        {
            return vettvangur;
        }

        public string getNafnVidskipa()
        {
            return nafnVidskipta;
        }

        public string getSimanumer()
        {
            return simanumer;
        }

        public string getNafnTulkur()
        {
            return nafnTulkur;
        }

        public string getGreidsla()
        {
            return greidsla;
        }

        public string getDagur()
        {
            return dagur;
        }

        public string getTimaByrja()
        {
            return tima_byrja;
        }

        public string getTimaEndir()
        {
            return tima_endir;
        }
        #endregion
    }
}
