<template>
  <div>
    <button class="home-button" @click="click">Főoldal</button>
    <div class="flex">
      <h1>A teszt kitöltése véget ért!</h1>
      <div class="points-low-wrapper">
        <h3>Elmaradás területei:</h3>
        <p id="szkinfo" v-bind:class="{ show: vocLow }">-Szókincs</p>
        <p id="minfo" v-bind:class="{ show: senLow }">-Mondathasználat</p>
        <p id="nyinfo" v-bind:class="{ show: langLow }">-Nyelvhasználat</p>
      </div>
      <div v-bind:class="{ show: pointsLow }">
        <h1>Tanácsok otthonra</h1>
        <h3>
          Addig is érdemes elolvasni a következő tanácsokat, játékötleteket.
        </h3>
        <div>
          <ul>
            <li>
              Tv, telefon, tablet használatának korlátozása. Naponta maximum 1
              óra ilyen eszközökkel való tevékenykedés (pl. 30 perc tv nézés +
              30 perc telefonozás).
            </li>
            <li>
              Szabadidő eltöltése manipulatív játékokkal. Pl. társasjáték,
              kirakó, lego, rajzolás, színezés, babázás, kocsikkal játék,
              gyurmázás, festés stb.
            </li>
            <li>
              Sok éneklés, mondókázás, mesélés, beszélgetés beépítése a napi
              rutinba.
            </li>
            <li>
              Séta közben látott és hallott dolgok megnevezése, beszélgetés.
            </li>
            <li>
              Esténként meseolvasás, történet megbeszélése, a képek megnevezése.
            </li>
            <li>
              Napi események történések megbeszélése a nap végén, óvoda, iskola
              után (időrendben)
            </li>
            <li>
              Papagáj-játék: ismételd utánam, mint egy papagáj! Szavak, majd
              rövidebb-hosszabb mondatok megismétlése.
            </li>
            <li>
              Bábozás ujjbábokkal vagy kézbábokkal, babákkal.
            </li>
            <li>
              Állathangok utánzása: malac – ui, cica – miáú, kutya – vau, éhes
              farkas – áú, szamár – iá, csibe – csip-csip stb.
            </li>
          </ul>
        </div>
      </div>
      <h1 v-bind:class="{ show: pointsHigh }">
        Az adatokat mentettük, a gyemeknek nincs elmaradása.
      </h1>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import router from "../router";

export default {
  data() {
    return {
      count: null,
      pointsLow: true,
      vocLow: true,
      senLow: true,
      langLow: true,
      pointsHigh: true,
      szokincsSzint: "megfelelő",
      mondatSzint: "megfelelő",
      nyelvSzint: "megfelelő",
      elmaradas: 0,
      bornDate: new Date(localStorage.birthDate),
      szokincsPont:
        parseInt(localStorage.szokincsPoints1) +
        parseInt(localStorage.szokincsPoints2),
      nyelvPont: parseInt(localStorage.nyelvPoints),
      mondatPont: parseInt(localStorage.mondatPoints),
    };
  },
  mounted() {
    window.scrollTo(0, 0);
  },
  methods: {
    click() {
      router.push("/");
    },
    eredmenyPost() {
      var today = new Date();
      var year = today.getFullYear - this.bornDate.getFullYear();
      var month = today.getMonth() - this.bornDate.getMonth();
      var day = today.getDay() - this.bornDate.getDay();
      var ageInMonth = Math.floor(month + year * 12 + (1 / 30) * day);
      var eredmenyObject = {
        tesztID: 1,
        oktatasi_azonosito: localStorage.eduID,
        kitoltes_datuma: new Date().toJSON(),
        aktualis_eletkor_honapban: ageInMonth,
        szokincs_pontszam: this.szokincsPont,
        szokincs_szint: this.szokincsSzint,
        mondathasznalat_pontszam: this.mondatPont,
        mondathasználat_szint: this.mondatSzint,
        nyelvhasznalat_pontszam: this.nyelvPont,
        nyelvhasznalat_szint: this.nyelvSzint,
        elmaradas_merteke: this.elmaradas,
        terapiaID: 1,
      };
      axios
        .post("http://localhost:5000/api/eredmenyek", eredmenyObject)
        .then((response) => {console.log(response), localStorage.clear();})
        .catch(function(error) {
          console.log(error.response.data);
        });
    },

    gyerekekPost() {
      var oviID = parseInt(localStorage.oviID);
      var diagID = parseInt(localStorage.diagID);
      var diagDate = new Date(localStorage.diagDate).toJSON();
      var ellatas = null;
      if (localStorage.attendance == 0) {
        ellatas = "MQ==";
      } else {
        ellatas = "MA==";
      }
      var gyerekekObject = {
        oktatasi_azonosito: localStorage.eduID,
        gyerek_neve: localStorage.lastName + " " + localStorage.firstName,
        szul_hely: String(localStorage.birthPlace),
        szulIdo: this.bornDate,
        anyja_neve: String(localStorage.momName),
        elerhetosegID: +1,
        ovodaID: oviID,
        diagnozisID: diagID,
        diagnozis_adas_datuma: diagDate,
        logopediai_ellatas_kell_e: ellatas,
      };
      axios
        .post("http://localhost:5000/api/gyerekek", gyerekekObject)
        .then((response) => {
          console.log(response), this.eredmenyPost();
        })
        .catch(function(error) {
          console.log(error.response.data);
        });
    },

    elerhetosegPost() {
      var lakcim =
        localStorage.zipCode+
        " " +
        localStorage.city +
        ", " +
        localStorage.address;
      var elerhetosegObject = {
        gondviselő_neve: String(localStorage.momNev),
        gondviselo_telefonszam: String(localStorage.phoneNum),
        gondviselo_email: String(localStorage.email),
        gondviselo_lakcim: lakcim,
      };

      axios
        .post(
          "http://localhost:5000/api/gyerek_elerhetosegek",
          elerhetosegObject
        )
        .then((response) => {
          console.log(response), this.gyerekekPost();
        })
        .catch(function(error) {
          console.log(error.response.data);
        });
    },
  },
  created() {
    
    var today = new Date();
    var year = today.getFullYear() - this.bornDate.getFullYear();
    var month = today.getMonth() - this.bornDate.getMonth();
    var day = today.getDay() - this.bornDate.getDay();
    var ageInMonth = Math.floor(month + year * 12 + (1 / 30) * day);

    if (24 <= ageInMonth && ageInMonth >= 26) {
      if (this.szokincsPont < 9) {
        this.vocLow = false;
        this.pointsLow = false;
        this.szokincsSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.mondatPont < 2) {
        this.senLow = false;
        this.pointsLow = false;
        this.mondatSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.nyelvPont < 1) {
        this.langLow = false;
        this.pointsLow = false;
        this.nyelvSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.pointsLow == true) {
        this.pointsHigh = false;
      }
    }
    if (27 <= ageInMonth && ageInMonth >= 29) {
      if (this.szokincsPont < 18) {
        this.vocLow = false;
        this.pointsLow = false;
        this.szokincsSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.mondatPont < 3) {
        this.senLow = false;
        this.pointsLow = false;
        this.mondatSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.nyelvPont < 2) {
        this.langLow = false;
        this.pointsLow = false;
        this.nyelvSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.pointsLow == true) {
        this.pointsHigh = false;
      }
    }
    if (30 <= ageInMonth && ageInMonth >= 32) {
      if (this.szokincsPont < 28) {
        this.vocLow = false;
        this.pointsLow = false;
        this.szokincsSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.mondatPont < 4) {
        this.senLow = false;
        this.pointsLow = false;
        this.mondatSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.nyelvPont < 3) {
        this.langLow = false;
        this.pointsLow = false;
        this.nyelvSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.pointsLow == true) {
        this.pointsHigh = false;
      }
    }
    if (33 <= ageInMonth && ageInMonth >= 35) {
      if (this.szokincsPont < 36) {
        this.vocLow = false;
        this.pointsLow = false;
        this.szokincsSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.mondatPont < 6) {
        this.senLow = false;
        this.pointsLow = false;
        this.mondatSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.nyelvPont < 5) {
        this.langLow = false;
        this.pointsLow = false;
        this.nyelvSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.pointsLow == true) {
        this.pointsHigh = false;
      }
    }
    if (36 <= ageInMonth && ageInMonth >= 38) {
      if (this.szokincsPont < 56) {
        this.vocLow = false;
        this.pointsLow = false;
        this.szokincsSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.mondatPont < 7) {
        this.senLow = false;
        this.pointsLow = false;
        this.mondatSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.nyelvPont < 7) {
        this.langLow = false;
        this.pointsLow = false;
        this.nyelvSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.pointsLow == true) {
        this.pointsHigh = false;
      }
    }
    if (39 <= ageInMonth && ageInMonth >= 41) {
      if (this.szokincsPont < 60) {
        this.vocLow = false;
        this.pointsLow = false;
        this.szokincsSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.mondatPont < 8) {
        this.senLow = false;
        this.pointsLow = false;
        this.mondatSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.nyelvPont < 7) {
        this.langLow = false;
        this.pointsLow = false;
        this.nyelvSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.pointsLow == true) {
        this.pointsHigh = false;
      }
    }
    if (42 <= ageInMonth && ageInMonth >= 44) {
      if (this.szokincsPont < 64) {
        this.vocLow = false;
        this.pointsLow = false;
        this.szokincsSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.mondatPont < 8) {
        this.senLow = false;
        this.pointsLow = false;
        this.mondatSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.nyelvPont < 8) {
        this.langLow = false;
        this.pointsLow = false;
        this.nyelvSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.pointsLow == true) {
        this.pointsHigh = false;
      }
    }
    if (45 <= ageInMonth && ageInMonth >= 47) {
      if (this.szokincsPont < 70) {
        this.vocLow = false;
        this.pointsLow = false;
        this.szokincsSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.mondatPont < 8) {
        this.senLow = false;
        this.pointsLow = false;
        this.mondatSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.nyelvPont < 8) {
        this.langLow = false;
        this.pointsLow = false;
        this.nyelvSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.pointsLow == true) {
        this.pointsHigh = false;
      }
    }
    if (48 <= ageInMonth && ageInMonth >= 50) {
      if (this.szokincsPont < 81) {
        this.vocLow = false;
        this.pointsLow = false;
        this.szokincsSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.mondatPont < 10) {
        this.senLow = false;
        this.pointsLow = false;
        this.mondatSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.nyelvPont < 10) {
        this.langLow = false;
        this.pointsLow = false;
        this.nyelvSzint = "elmarad";
        this.elmaradas = this.elmaradas + 1;
      }
      if (this.pointsLow == true) {
        this.pointsHigh = false;
      }
    }
    this.elerhetosegPost();
  },
};
</script>

<style scoped>
p {
  font-size: 18px;
}
h3 {
  font-size: 23px;
}
li {
  margin: 10px;
}
ul {
  display: table;
  margin: auto;
  text-align: left;
  font-size: 18px;
}
.show {
  display: none;
}
.home-button {
  position: relative;
  border-radius: 25px;
  box-sizing: border-box;
  font-size: 1.2em;
  font-family: -apple-system, BlinkMacSystemFont, Segoe UI, Roboto, Helvetica,
    Arial, sans-serif, Apple Color Emoji, Segoe UI Emoji, Segoe UI Symbol;
  padding: 0.3em;
  line-height: 1.2em;
  margin: auto;
  border: 1px solid #10bbe6;
  box-shadow: rgba(0, 0, 0, 0.19) 0px 10px 20px, rgba(0, 0, 0, 0.23) 0px 6px 6px;
  background-color: #10bbe6;
  color: black;
  width: 100px;
  font-weight: 600;
  cursor: pointer;
  text-align: center;
  margin: 10px;
  text-shadow: 1px 1px 3px white;
  margin-top: 40px;
}

.flex {
  width: 60%;
  margin: 80px auto;
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  justify-content: space-between;
  background-color: white;
  box-shadow: black 0px 22px 70px 4px;
  border-radius: 20px;
  padding: 20px;
  border: 4px solid #10bbe6;
}

@media only screen and (max-width: 1052px) {
  .flex {
    width: 85%;
    padding: 10px;
  }
}

@media only screen and (max-width: 630px) {
  p {
    font-size: 16px;
  }
  h3 {
    font-size: 20px;
  }
  li {
    margin-top: 5px;
    margin-left: 0;
  }
  ul {
    display: table;
    margin: auto;
    text-align: left;
    font-size: 15px;
  }
}
</style>
