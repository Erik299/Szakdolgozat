<template>
  <div class="tovabbParent">
    <home-button buttonText="Home"></home-button>
    <div class="flex">
      <p>
        <b>
          Szokott-e már gyermeke több szóból mondatokat alkotni, pl.: "Még
          csoki!", "Vauvau ott!", "Én is megyek!"?
        </b>
      </p>
      <div class="choice">
        <FormulateInput
          v-model="picked"
          type="radio"
          :options="{ nem: 'Még nem', neha: 'Néha', gyakran: 'Gyakran' }"
        />
        <p v-if="show" id="error">Kérjük, Válasszon egyet!</p>
      </div>
      <p>
        Ha a válasza <b>'Még nem'</b>, a teszt kitöltésének vége van, a
        <b>'Néha'</b> és <b>'Gyakran'</b> esetén tovább folytathatja a
        kitöltést.
      </p>

      <div class="flex-buttons">
        <bwd-button buttonText="Vissza" />
        <button @click="pickedRoute">Tovább</button>
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
      picked: "",
      show: false,
    };
  },
  methods: {
    pickedRoute() {
      if (this.picked == "") {
        this.show = true;
      } else {
        if (this.picked === "nem") {
          router.push("/Final");
          localStorage.nyelvPoints = 0;
          localStorage.mondatPoints = 0;
        } else {
          router.push("/Mondatok");
        }
      }
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
.tovabbParent #error {
  color: red;
}
.tovabbParent p {
  font-size: 20px;
}
.tovabbParent .flex {
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

.tovabbParent .flex-buttons {
  width: 100%;
  display: flex;
  justify-content: space-between;
  margin-top: 10px;
}

.tovabbParent .flex-buttons button {
  position: relative;
  border-radius: 25px;
  box-sizing: border-box;
  background-color: transparent;
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

.tovabbParent .formulate-input {
  width: 100%;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  margin-bottom: 10px;
  margin-left: 0;
}

.tovabbParent .formulate-input-wrapper {
  display: flex;
  justify-content: space-between;
  margin: 5px;
}

.tovabbParent .formulate-input-element {
  display: flex;
  flex-wrap: wrap;
}
@media only screen and (max-width: 1052px) {
  .tovabbParent p {
    font-size: 17px;
  }
  .tovabbParent .flex {
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
}
</style>
