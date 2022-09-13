<template>
  <div class="homeParent">
    <div class="landing-section">
      <h1>KOFA-3 szülői kérdőív</h1>
      <div class="kofa">
        <div><span>ko</span>mmunikatív</div>
        <div><span>f</span>ejlődési</div>
        <div><span>a</span>dattár</div>
      </div>
    </div>
    <div>
      <div class="text-wrapper">
        <h3>Kedves Szülők!</h3>
        <p>
          A 15/2013. (II. 26.) EMMI rendelet alapján a pedagógiai
          szakszolgálatoknak kötelezően el kell végeznie a 3 éves gyermekek
          logopédiai szűrését, amely ebben az életkorban egy szülői kérdőív
          segítségével történik. A kérdőívet ezen a webalkalmazáson keresztül
          tudják kitölteni. Kérjük, olvassák el és fogadják el a tájékoztatókat,
          majd kezdhetik a teszt kitöltését.
        </p>
        <p>
          A harmadik életévüket betöltött (óvodába beiratkozó) gyermekek
          nyelvfejlődési szűrése a Kommunikatív Fejlődési Adattár - 3, azaz a
          KOFA-3 szülői kérdőív segítségével történik, amely személyes
          kérdésekkel indul, majd gyermeke szókincséről, mondathasználatáról és
          nyelvhasználatáról fog feltenni kérdéseket.Kérjük, hogy válaszaik
          tükrözzék a valóságot!
        </p>
        <p>
          A kérdőívet lehetőség szerint olyan személy töltse ki, aki sokat van a
          beiratkozó gyermekkel, annak érdekében, hogy minél reálisabb eredményt
          kaphassunk gyermeke beszédének fejlődéséről.
        </p>
        <h2>A KOFA-3 felépítése:</h2>
        <p>
          A KOFA-3 szülő által kitöltendő kérdőíves eljárás, a gyerekek nyelvi
          fejlettségéről tehát a szüleik előre strukturált, írásos beszámolóján
          keresztül szerzünk információt az elsődleges szűrés során. Validitási
          vizsgálataink szerint a teszt kitöltése során a szülők többsége
          megbízható, érvényes adatokat szolgáltat.
        </p>
        <p>
          <b
            >A teszt két oldalon át tartalmaz kérdéseket a szűrésben részt vevő
            gyerek nyelvi fejlettségére vonatkozóan. Az eljárás öt részre
            tagolódik:</b
          >
          <b
            ><i
              ><ul>
                <li>Szókincs</li>
                <li>Mondatok</li>
                <li>Nyelvhasználat</li>
                <li>Példamondatok</li>
                <li>Kis hibák</li>
              </ul></i
            ></b
          >
        </p>
        <button class="dropdown" @click="dropdown">
          További információk a tesztről<img
            src="./../assets/img/icon.png"
            width="20"
            height="20"
          />
        </button>
          <FormulateInput
          label-position="before"
          type="checkbox"
          v-model="checked"
          label="A tájókoztatót elolvastam és elfogadom:"
          ></FormulateInput>
          <p v-if="show" class="error">A tájékoztatók elfogadása kötelető</p>
        <button class="button" @click="navigate">Teszt Kitöltése</button>
        <div id="info" class="display">
          <h2 id="hidden-info">A Tesztről</h2>
          <p>
            A Szókincs szekció egy 124 elemű szólistát tartalmaz, melyben a
            szülő bejelöli a gyereke által expresszíven használt (kimondott)
            szavakat. Ez a lista úgy lett összeállítva, hogy egyaránt tartalmaz
            a háromévesek beszédében gyakrabban, illetve ritkábban megjelenő
            szavakat. Ennek célja az, hogy a szülő válaszai alapján
            differenciálható legyen az életkornak megfelelő, illetve az attól
            elmaradó szókincsfejlettség.<br />
            E rész végén a szülő választ ad arra a kérdésre is, hogy szokott-e
            már a gyereke több szóból álló közléseket használni. Nemleges válasz
            esetén a kérdőív további részeit nem kell kitölteni. Hangsúlyozzuk,
            hogy hároméves korban az e kérdésre adott „Még nem” válasz
            egyértelműen a gyerek nyelvfejlődési késésére utaló jel, hiszen a
            több szóból álló közlések megjelenését kétéves kortól várjuk el.
          </p>
          <p>
            A Mondatok szekcióban a szülő mondatpárok tagjai közül kell, hogy
            kiválassza a gyereke beszédére leginkább jellemző, arra legjobban
            hasonlító változatot, pl. Vauvau inni / A kutya iszik. Ez a rész a
            gyerekre jellemző mondatalkotási színvonalat, továbbá a nyelvi
            fejlettséget jelző tipikus hibák előfordulását méri fel.
          </p>
          <p>
            A Nyelvhasználat részben a gyerek verbális kommunikációjára,
            általános megértésére irányuló eldöntendő kérdésekre ad választ a
            szülő. E rész alapján a szókincsen és a mondatalkotáson túl a
            globális kommunikációs szokások, a kommunikáció színvonala mérhető
            fel.
          </p>
          <p>
            A Példamondatok részben a gyerek által mostanában mondott három
            leghosszabb mondat szó szerinti lejegyzését kérjük a szülőtől.<br />
            Ennek alapján a mondatalkotás fejlettségét mérhetjük fel, illetve
            vethetjük össze a Mondatok és a Nyelvhasználat részben kapott
            adatokkal.
          </p>
          <p>
            Módunk van a kapott mondatok minőségi elemzésére is, pl. átlagos
            mondathossz kiszámítására (szavakban vagy morfémákban).<br />
            A Kis hibák részben a hároméves korban már elvárt morfológiai
            produktivitás jeleire kérdezünk. Ennek az életkornak a tipikus
            jellemzője, hogy a gyerekek önállóan kezdik alkalmazni a ragozási
            szabályokat, melynek következtében a kivételes alakok esetében
            olykor túláltalánosítási hibákat követnek el, pl. mutatja helyett
            mutati, oroszlánt helyett oroszlánot, majmok helyett majomok stb.
            alakokat használnak. Ez a jelenség hároméves korban pozitív
            fejleményként értékelendő, fontos folyamata a tipikus ütemben zajló
            nyelvelsajátításnak.
          </p>
           <FormulateInput
          label-position="before"
          type="checkbox"
          v-model="checked"
          label="A tájókoztatót elolvastam és elfogadom:"
          ></FormulateInput>
          <button class="button" @click="navigate">Teszt Kitöltése</button>
        </div>
      </div>
    </div>
    <router-view />
  </div>
</template>

<script>
export default {
  data() {
    return {
      checked: false,
      show: false,
    };
  },
  mounted() {
    window.scrollTo(0, 0);
  },
  methods: {
    navigate() {
      if (this.checked == false){
        this.show = true;
      }
      else{
        this.$router.push("/Form");
      }
      console.log(this.igen);
    },
    dropdown() {
      var e = document.getElementById("info");
      e.classList.toggle("display");
    },
  },
};
</script>

<style>
.homeParent .error {
  color: red;
  margin: auto;
  text-align: center;
}

.homeParent .formulate-input-element .formulate-input-wrapper {
  display: flex;
  margin-right: auto;
}

.homeParent .formulate-input{
  margin: auto;
  margin-top: 20px;
}

.homeParent .formulate-input .formulate-input-wrapper {
  width: auto;
  display: flex;
  justify-content: center;
}

.homeParent .formulate-input-group-item {
  width: 100%;
  display: flex;
}

.homeParent .formulate-input-element {
  display: flex;
  flex-wrap: wrap;
}

.homeParent .landing-section {
  height: 100vh;
  width: 100%;
  background: linear-gradient(rgba(0, 0, 0, 0.45), rgba(0, 0, 0, 0.45)),
    url("./../assets/img/kids.jpg");
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  display: flex;
  flex-wrap: wrap;
  align-content: flex-end;
}

.homeParent .kofa {
  margin-left: 65px;
  margin-bottom: 160px;
  margin-top: 15px;
}

.homeParent .kofa div {
  text-align: left;
  font-size: 50px;
  font-variant: small-caps;
  text-shadow: 2px 2px 5px white;
}

.homeParent .kofa span {
  color: white;
  text-shadow: 2px 2px 5px #10bbe6;
}

.homeParent div {
  margin-bottom: 15px;
  text-align: center;
}
.homeParent h1,
h2 {
  margin: auto;
  font-variant: small-caps;
  width: 100%;
}

.homeParent ul {
  display: table;
  margin: 10px auto;
  text-align: left;
  font-size: 25px;
}

.homeParent h1 {
  text-align: left;
  font-size: 80px;
  color: white;
  text-shadow: 2px 2px 5px #10bbe6;
  margin-left: 50px;
  margin-bottom: 10px;
}
.homeParent h2 {
  text-align: center;
  color: #5f5f5f;
  font-size: 55px;
  border-bottom: 2px solid #10bbe6;
  width: 90%;
  margin-top: 20px;
}
.homeParent h3 {
  margin: 10px auto;
  text-align: center;
  font-size: 50px;
}
.homeParent p {
  font-size: 25px;
  text-align: left;
  width: 100%;
}
.homeParent .display {
  display: none;
}
.homeParent #info {
  margin-top: 50px;
}

.homeParent .button {
  border-radius: 25px;
  box-sizing: border-box;
  font-size: 1.2em;
  font-family: -apple-system, BlinkMacSystemFont, Segoe UI, Roboto, Helvetica,
    Arial, sans-serif, Apple Color Emoji, Segoe UI Emoji, Segoe UI Symbol;
  padding: 1em;
  font-weight: 400;
  line-height: 1.2em;
  margin: 0;
  border: 1px solid #10bbe6;
  box-shadow: black 0px 22px 70px 4px;
  background-color: #10bbe6;
  color: black;
  width: 180px;
  font-weight: 700;
  cursor: pointer;
  text-align: center;
  margin: 30px auto;
}
.homeParent .button:hover {
  background-color: black;
  border: 1px solid black;
  color: #10bbe6;
  transition: background-color 0.5s, color 0.5s;
}
.homeParent .button:not(:hover) {
  background-color: #10bbe6;
  color: white;
  transition: background-color 1s, color 1s;
}

.homeParent .dropdown {
  width: 300px;
  margin: auto;
  font-size: 18px;
  display: flex;
  justify-content: space-between;
  border: 1px solid #10bbe6;
  border-radius: 25px;
  padding: 10px;
  cursor: pointer;
}

.homeParent .text-wrapper {
  width: 80%;
  margin: 80px auto;
  display: flex;
  flex-wrap: wrap;
  flex-direction: column;
  justify-content: space-between;
  background-color: white;
  box-shadow: black 0px 22px 70px 4px;
  border-radius: 20px;
  padding: 30px;
  border: 4px solid #10bbe6;
}

@media only screen and (max-width: 900px) {
  .homeParent h1 {
    font-size: 45px;
  }
  .homeParent h2 {
    font-size: 35px;
  }
  .homeParent h3 {
    font-size: 30px;
  }
  .homeParent p {
    font-size: 17px;
    margin: 10px 0;
  }
  .homeParent .kofa div {
    font-size: 35px;
  }
  .homeParent .text-wrapper {
    width: 75%;
    padding: 10px;
  }
  .homeParent ul {
    font-size: 18px;
  }
  .homeParent .dropdown {
    width: 250px;
    padding: auto;
    font-size: 15px;
  }
  .homeParent .formulate-input{
    width: 100%;
  }
  .homeParent .formulate-input-label{
    font-size: 12px;
    font-weight: normal;
    width: auto;
  }
}
</style>
