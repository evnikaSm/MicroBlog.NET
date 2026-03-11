using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microblog.Core
{
    record KonfiguracjaSystemu()
    {
        public int MaksymalnaDlugoscTresci { get; init; }
        public string DomyslnyMotyw { get; init; }
        public bool CzypokazywacObrazki { get; init; }
        public string WersjaAplikacji { get; init; }
        public KonfiguracjaSystemu(int MaksymalnaDlugoscTresci, string DomyslnyMotyw, bool CzypokazywacObrazki, string WersjaAplikacji):this() {
        
            this.MaksymalnaDlugoscTresci = MaksymalnaDlugoscTresci;
            this.DomyslnyMotyw = DomyslnyMotyw;
            this.CzypokazywacObrazki = CzypokazywacObrazki;
            this.WersjaAplikacji = WersjaAplikacji;
        }
        public KonfiguracjaSystemu UtwórzDomyślną()
        {
            return new KonfiguracjaSystemu(
                MaksymalnaDlugoscTresci: 280,
                DomyslnyMotyw: "Jasny",
                CzypokazywacObrazki: true,
                WersjaAplikacji: "1.0.0");
        }

        public KonfiguracjaSystemu WithMaksymalnaDługośćTreści(int nowaDługość)
        {
            return new KonfiguracjaSystemu(
                nowaDługość,
                DomyslnyMotyw,
                CzypokazywacObrazki,
                WersjaAplikacji);
        }
        public KonfiguracjaSystemu WithDomyslnyMotyw(string nowyMotyw)
        {
            return new KonfiguracjaSystemu(
                MaksymalnaDlugoscTresci,
                nowyMotyw,
                CzypokazywacObrazki,
                WersjaAplikacji);
        }

    }
}
