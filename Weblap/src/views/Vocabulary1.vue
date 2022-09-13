<template>
  <keep-alive>
    <div class="szokincsParent1">
      <home-button buttonText="Home"></home-button>
      <h1>Szókincs</h1>
      <div class="flex">
        <p>
          A gyerekek általában több szót értenek, mint amennyit mondanak. Most
          azokat a szavakat vesszük számba amelyeket a gyermeke mond.
        </p>
        <p>
          <b>
            Kérjük, hogy jelölje be azokat a szavakat, amelyeket hallott már,
            hogy a gyermeke kimondott. Akkor is jelölje a szót, ha a gyermeke
            másképp ejti ki, pl.: róka helyett jóka, vagy rövidíti, pl.:
            dinoszaurusz helyett dínó, vagy más végződéssel mondja, pl.: elött,
            elötte, elöttem, stb.
          </b>
        </p>
        <p>
          Ez a lista csak egy része a szókincsnek, a gyermeke nyilván más
          szavakat is használ, amelyek itt nem szerepelnek.
        </p>
        <FormulateForm>
          <FormulateInput
            v-model="szokincsValue1"
            id="szokincs"
            :options="{
              label1: 'dinoszaurusz',
              label2: 'bútor',
              label3: 'bukfencezik',
              label4: 'magad',
              label5: 'szamár / csacsi',
              label6: 'konyha',
              label7: 'gondol',
              label8: 'mikor?',
              label9: 'őz / őzike',
              label10: 'kanapé',
              label11: 'fekete',
              label12: 'hol?',
              label13: 'hegy',
              label14: 'felhő',
              label15: 'világos',
              label16: 'hová?',
              label17: 'gitár',
              label18: 'kerítés',
              label19: 'szomorú',
              label20: 'honnan?',
              label21: 'foci',
              label22: 'kanna',
              label23: 'mély',
              label24: 'kinek?',
              label25: 'távcső',
              label26: 'járda',
              label27: 'más',
              label28: 'miért?',
              label29: 'roller',
              label30: 'állatkert',
              label31: 'üres',
              label32: 'hogy? / hogyan?',
              label33: 'sárkány',
              label34: 'gyerek',
              label35: 'drága',
              label36: 'van',
              label37: 'kocsi / autó',
              label38: 'rendőr',
              label39: 'finom',
              label40: 'volt',
              label41: 'citrom',
              label42: 'család',
              label43: 'fél / fele',
              label44: 'lesz',
              label45: 'mogyoró',
              label46: 'gazda',
              label47: 'hosszú',
              label48: 'alatt',
              label49: 'keksz',
              label50: 'senki',
              label51: 'elvesztett',
              label52: 'fölött',
              label53: 'só',
              label54: 'nővér',
              label55: 'mérges/dühös',
              label56: 'baleset',
              label57: 'furcsa',
              label58: 'mellett',
              label59: 'kör',
              label60: 'mazsola',
            }"
            type="checkbox"
          />
        </FormulateForm>
        <div class="flex-buttons">
          <bwd-button buttonText="Vissza" />
          <button @click="click">Tovább</button>
        </div>
      </div>
    </div>
  </keep-alive>
</template>

<script>
import HomeButton from "../components/buttons/HomeButton.vue";
import BwdButton from "../components/buttons/BwdButton.vue";
import router from "../router";

export default {
  data() {
    return {
      szokincsValue1: [],
      szokincsPoints1: null,
    };
  },

  created() {
    this.szokincsValue1 = JSON.parse(
      localStorage.getItem("szokincsValue1") || "[]"
    );
    if (localStorage.szokincsPoints1) {
      this.szokincsPoints1 = localStorage.szokincsPoints1;
    }
  },

  methods: {
    click() {
      localStorage.szokincsPoints1 = this.szokincsValue1.length;
      localStorage.setItem(
        "szokincsValue1",
        JSON.stringify(this.szokincsValue1)
      );
      router.push("/Vocabulary2");
    },
  },
  components: {
    HomeButton,
    BwdButton,
  },
  mounted() {
    window.scrollTo(0, 0);
  },
};
</script>

<style>
.szokincsParent1 .flex p {
  margin: 20px auto;
  font-size: 20px;
}

.szokincsParent1 .flex {
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

.szokincsParent1 h1 {
  font-size: 55px;
  color: white;
  text-shadow: 2px 2px 5px #10bbe6;
}
.szokincsParent1 h2 {
  color: #5f5f5f;
  font-size: 35px;
}
.szokincsParent1 h1,
h2 {
  font-variant: small-caps;
  width: 100%;
}

.szokincsParent1 .flex-buttons {
  width: 100%;
  display: flex;
  justify-content: space-between;
  margin-top: 10px;
}

.szokincsParent1 .flex-buttons button {
  position: relative;
  border-radius: 25px;
  box-sizing: border-box;
  font-size: 1em;
  font-family: -apple-system, BlinkMacSystemFont, Segoe UI, Roboto, Helvetica,
    Arial, sans-serif, Apple Color Emoji, Segoe UI Emoji, Segoe UI Symbol;
  padding: 0.75em;
  font-weight: 600;
  line-height: 1.2em;
  border: 1px solid #10bbe6;
  box-shadow: black 0px 22px 70px 4px;
  background-color: #10bbe6;
  color: black;
  min-width: 0;
  width: 30%;
  max-width: 180px;
  cursor: pointer;
  text-align: center;
  margin: 10px;
}

.szokincsParent1 .formulate-form {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  margin: auto;
}

.szokincsParent1 .formulate-input-element .formulate-input-wrapper {
  display: flex;
  justify-content: space-around;
  margin-left: 25%;
}

.szokincsParent1 .formulate-input {
  width: 100%;
  display: flex;
}

.szokincsParent1 .formulate-input-group-item {
  width: 30%;
  display: flex;
}

.szokincsParent1 .formulate-input-element {
  display: flex;
  flex-wrap: wrap;
  margin: auto;
  margin-top: 0;
  margin-right: 2px;
}

.szokincsParent1 .formulate-input-group {
  display: flex;
  justify-content: space-around;
}

@media only screen and (max-width: 1052px) {
  .szokincsParent1 .flex {
    width: 85%;
    margin: 80px auto;
    display: flex;
    flex-direction: column;
    flex-wrap: wrap;
    justify-content: space-between;
    background-color: white;
    box-shadow: black 0px 22px 70px 4px;
    border-radius: 20px;
    padding: 10px;
    border: 4px solid #10bbe6;
  }
  .szokincsParent1 h1 {
    font-size: 45px;
    color: white;
    text-shadow: 2px 2px 5px #10bbe6;
  }
  .szokincsParent1 h2 {
    color: #5f5f5f;
    font-size: 30px;
  }
  .szokincsParent1 p {
    font-size: 17px;
  }
  .szokincsParent1 .formulate-input-group-item {
    width: 45%;
    display: flex;
  }
}
@media only screen and (max-width: 719px) {
  .szokincsParent1 p {
    font-size: 16px;
  }
  .szokincsParent1 .formulate-input-group-item {
    width: 90%;
    display: flex;
  }
  .szokincsParent1 .formulate-input-element .formulate-input-wrapper {
    display: flex;
    justify-content: space-around;
    margin-left: 30%;
  }
  .szokincsParent1 .flex-buttons {
    width: 100%;
    display: flex;
    justify-content: space-between;
  }
  .szokincsParent1 .flex-buttons button {
    -webkit-appearance: none;
    -moz-appearance: none;
    appearance: none;
    position: relative;
    border-radius: 25px;
    box-sizing: border-box;
    background-color: transparent;
    font-size: 1em;
    font-family: -apple-system, BlinkMacSystemFont, Segoe UI, Roboto, Helvetica,
      Arial, sans-serif, Apple Color Emoji, Segoe UI Emoji, Segoe UI Symbol;
    padding: 0.75em;
    font-weight: 600;
    line-height: 1.2em;
    border: 1px solid #10bbe6;
    box-shadow: black 0px 22px 70px 4px;
    background-color: #10bbe6;
    color: black;
    width: 180px;
    cursor: pointer;
    text-align: center;
    margin: 10px;
  }
}
@media only screen and (max-width: 435px) {
  .szokincsParent1 .formulate-input-element .formulate-input-wrapper {
    display: flex;
    justify-content: space-around;
    margin-left: 17%;
  }
}
</style>
