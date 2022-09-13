<template>
  <div class="szokincsParent2">
    <home-button buttonText="Home"></home-button>
    <h1>Szókincs</h1>
    <div class="flex">
      <FormulateForm>
        <FormulateInput
          v-model="szokincsValue2"
          :options="{
            label1: 'között',
            label2: 'főzelék',
            label3: 'haza',
            label4: 'bögre',
            label5: 'megmér/mér',
            label6: 'ma',
            label7: 'mögött',
            label8: 'zöldség',
            label9: 'elöl',
            label10: 'tegnap',
            label11: 'előtt',
            label12: 'gyöngy',
            label13: 'ötlet',
            label14: 'holnap',
            label15: 'után',
            label16: 'öv',
            label17: 'sátor',
            label18: 'szombat',
            label19: 'rajta',
            label20: 'könyök',
            label21: 'én',
            label22: 'te',
            label23: 'ő',
            label24: 'mi',
            label25: 'ti',
            label26: 'ők',
            label27: 'megfog/fog',
            label28: 'hüvelyk(ujj)',
            label29: 'becsatol/csatol',
            label30: 'kell',
            label31: '(rag)tapasz',
            label32: 'minden',
            label33: 'elfelejt',
            label34: 'szabad',
            label35: 'fűrész',
            label36: 'utál',
            label37: 'köröm',
            label38: 'tilos',
            label39: 'számítógép',
            label40: 'siet',
            label41: 'leejt/ejt',
            label42: 'lehet',
            label43: 'el',
            label44: 'üveg',
            label45: 'befér/fér',
            label46: 'össze',
            label47: 'létra',
            label48: 'hámoz/pucol',
            label49: 'szét',
            label50: 'anyag',
            label51: 'megígér/igér',
            label52: 'vissza',
            label53: 'ceruza',
            label54: 'biciklizik',
            label55: 'ami/aki',
            label56: 'gumi',
            label57: 'tüsszent',
            label58: 'mert',
            label59: 'enyém',
            label60: 'tiéd',
            label61: 'övé',
            label62: 'miénk',
            label63: 'tiétek',
            label64: 'övék',
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
</template>

<script>
import router from "../router";
import HomeButton from "../components/buttons/HomeButton.vue";
import BwdButton from "../components/buttons/BwdButton.vue";

export default {
  data() {
    return {
      szokincsValue2: [],
      szokincsPoints2: null,
    };
  },
  created() {
    if (localStorage.szokincsPoints2) {
      this.szokincsPoints2 = localStorage.szokincsPoints2;
    }
    this.szokincsValue2 = JSON.parse(
      localStorage.getItem("szokincsValue2") || "[]"
    );
  },
  methods: {
    click() {
      localStorage.szokincsPoints2 = this.szokincsValue2.length;
      localStorage.setItem(
        "szokincsValue2",
        JSON.stringify(this.szokincsValue2)
      );
      router.push("/Forward");
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
.szokincsParent2 .flex {
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

.szokincsParent2 h1 {
  font-size: 55px;
  color: white;
  text-shadow: 2px 2px 5px #10bbe6;
  font-variant: small-caps;
  width: 100%;
}
.szokincsParent1 .formulate-form {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  margin: auto;
}

.szokincsParent2 .formulate-input-element .formulate-input-wrapper {
  display: flex;
  justify-content: space-around;
  margin-left: 25%;
}

.szokincsParent2 .formulate-input {
  width: 100%;
  display: flex;
}

.szokincsParent2 .formulate-input-group-item {
  width: 30%;
  display: flex;
}

.szokincsParent2 .formulate-input-element {
  display: flex;
  flex-wrap: wrap;
  margin: auto;
  margin-top: 0;
  margin-right: 2px;
}

.szokincsParent2 .formulate-input-group {
  display: flex;
  justify-content: space-around;
}

.szokincsParent2 .flex-buttons {
  width: 100%;
  display: flex;
  justify-content: space-between;
  margin-top: 10px;
}

.szokincsParent2 .flex-buttons button {
  position: relative;
  border-radius: 25px;
  box-sizing: border-box;
  font-size: 1em;
  font-family: -apple-system, BlinkMacSystemFont, Segoe UI, Roboto, Helvetica,
    Arial, sans-serif, Apple Color Emoji, Segoe UI Emoji, Segoe UI Symbol;
  padding: 0.75em;
  line-height: 1.2em;
  border: 1px solid #10bbe6;
  box-shadow: black 0px 22px 70px 4px;
  background-color: #10bbe6;
  color: black;
  min-width: 0;
  width: 30%;
  max-width: 180px;
  font-weight: 600;
  cursor: pointer;
  text-align: center;
  margin: 10px;
}
@media only screen and (max-width: 1052px) {
  .szokincsParent2 .flex {
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
  .szokincsParent2 h1 {
    font-size: 45px;
    color: white;
    text-shadow: 2px 2px 5px #10bbe6;
    font-variant: small-caps;
    width: 100%;
  }
  .szokincsParent2 .formulate-input-group-item {
    width: 45%;
    display: flex;
  }
}
@media only screen and (max-width: 719px) {
  .szokincsParent2 .formulate-input-group-item {
    width: 90%;
    display: flex;
  }
  .szokincsParent2 .formulate-input-element .formulate-input-wrapper {
    display: flex;
    justify-content: space-around;
    margin-left: 30%;
  }
  .szokincsParent2 .flex-buttons {
    width: 100%;
    display: flex;
    justify-content: space-between;
  }
  .szokincsParent2 .flex-buttons button {
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
  .szokincsParent2 .formulate-input-element .formulate-input-wrapper {
    display: flex;
    justify-content: space-around;
    margin-left: 17%;
  }
}
</style>
