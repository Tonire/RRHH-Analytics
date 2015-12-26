using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApp.Controllers {
    public class Skins {
        public Skins() {

        }
        public string getSkin(int value){
            switch (value) {
                case 0:
                    return "skin-blue";
                case 1:
                    return "skin-black";
                case 2:
                    return "skin-purple";
                case 3:
                    return "skin-green";
                case 4:
                    return "skin-red";
                case 5:
                    return "skin-yellow";
            }
            return null;
        }
    }
}