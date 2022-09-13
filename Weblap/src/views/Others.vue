<template>
  <div class="egyebParent">
    <home-button buttonText="Home"></home-button>
    <h1>Példamondatok</h1>
    <div class="flex">
      <p>
        <b>
          Kérjük, sorolja fel a három leghosszabb mondatot, amelyet a gyermeke
          mostanában mondott.
        </b>
      </p>
      <input
        name="sentences"
        class="text"
        type="text"
        help="Az entert lenyomva a beírt mondat bekerül egy felsorolásba, és írhatja a következőt."
        v-model="newSentence"
        @keyup.enter="addNewSentence()"
      />
      <div class="help-text">
        *Az Enter gombot megnyomva a beírt mondat bele kerül egy felsorolásba,
        illetve a mondatra balklikkel kattintva törlődik.
      </div>
      <p
        class="pointer"
        @click="sentences.splice(index, 1)"
        v-for="(sentence, index) in sentences"
        v-bind:key="sentence.id"
        v-bind:text="sentence.text"
      >
        {{ sentences.indexOf(sentence) + 1 }}. {{ sentence.text }}
        <span class="tooltiptext">Törlés</span>
      </p>

      <h2>Kis hibák</h2>
      <p>
        Amikor a gyerekek önállóan kezdenek mondatokat alkotni, néha hibáznak,
        ez is jelzi a fejlődésüket. Például azt mondják ˝Apa mutati a képet˝
        vagy ˝Odaadom a pénzet˝. Előfordul-e. hogy a gyermeke efféle hibákat
        ejt?
        <b
          >Kérjük jelölje meg, ha a következők közül bármelyiket mondta, vagy
          adjon meg egyéb példát.</b
        >
      </p>
      <FormulateForm>
        <FormulateInput
          v-model="egyebValue"
          id="szokincs"
          type="checkbox"
          :options="{
            elabel1: 'alszott',
            elabel2: 'eszett',
            elabel3: 'iszott',
            elabel4: 'olvasi',
            elabel5: 'majomot',
            elabel6: 'bagolyt',
            elabel7: 'pénzet',
            elabel8: 'lót',
            elabel9: 'madárt',
            elabel10: 'kőt',
            elabel11: 'apája',
            elabel12: 'tiem',
          }"
        />
      </FormulateForm>
      <label id="label">Egyéb szavak:</label>
      <input
        class="text"
        type="text"
        v-model="newWord"
        @keyup.enter="addNewWord()"
      />
      <div class="help-text">
        *Az Enter gombot megnyomva a beírt szó bele kerül egy felsorolásba,
        illetve a szóra balklikkel kattintva törlődik.
      </div>
      <div class="span-wrapper">
        <span
          class="pointer"
          @click="words.splice(index, 1)"
          v-for="(word, index) in words"
          v-bind:key="word.id"
          v-bind:text="word.text"
          >{{ word.text }}
          <span class="tooltiptext">Törlés</span>
        </span>
      </div>
      <div class="flex-buttons">
        <bwd-button buttonText="Vissza" />
        <button @click="click">Tovább</button>
      </div>
    </div>
  </div>
</template>

<script>
import HomeButton from "../components/buttons/HomeButton.vue";
import BwdButton from "../components/buttons/BwdButton.vue";
import router from "../router";

export default {
  data() {
    return {
      newSentence: "",
      sentences: [],
      nextSentenceId: 1,
      newWord: "",
      words: [],
      nextWordId: 1,
      egyebValue: [],
    };
  },
  created() {
    this.egyebValue = JSON.parse(localStorage.getItem("egyebValue") || "[]");
    this.sentences = JSON.parse(localStorage.getItem("sentences") || "[]");
    this.words = JSON.parse(localStorage.getItem("words") || "[]");
  },
  methods: {
    addNewSentence() {
      if (this.sentences.length === 3) {
        return this.sentences;
      }
      if (
        this.newSentence != "" &&
        this.newSentence.length >= 2 &&
        !this.newSentence.match(/\d+/g)
      ) {
        this.sentences.push({
          id: this.nextSentenceId++,
          text: this.newSentence,
        });
        this.newSentence = "";
      }
    },
    addNewWord() {
      if (
        this.newWord != "" &&
        this.newWord.length >= 2 &&
        !this.newWord.match(/\d+/g)
      ) {
        this.words.push({
          id: this.nextWordId++,
          text: this.newWord,
        });
        this.newWord = "";
      }
    },
    click() {
      localStorage.setItem("egyebValue", JSON.stringify(this.egyebValue));
      localStorage.setItem("sentences", JSON.stringify(this.sentences));
      localStorage.setItem("words", JSON.stringify(this.words));
      router.push("/Final");
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
.egyebParent .flex {
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

.egyebParent p {
  font-size: 20px;
  margin: 10px 30px;
}

.egyebParent span {
  margin: 10px 8px;
  border: 1px solid black;
  border-radius: 5px;
  padding: 5px;
  font-size: 20px;
}

.egyebParent .span-wrapper {
  width: 80%;
  display: flex;
  flex-wrap: wrap;
  margin: auto;
}

.egyebParent .pointer {
  cursor: pointer;
  margin-top: 20px;
  position: relative;
}

.egyebParent .pointer:hover .tooltiptext {
  visibility: visible;
}

.egyebParent .tooltiptext {
  visibility: hidden;
  width: auto;
  background-color: #10bbe6;
  color: #fff;
  text-align: center;
  border-radius: 6px;
  padding: 5px;
  position: absolute;
  z-index: 1;
  font-size: 15px;
}

.egyebParent h1 {
  font-size: 55px;
  color: white;
  text-shadow: 2px 2px 5px #10bbe6;
  margin: auto;
}
.egyebParent h2 {
  color: #5f5f5f;
  font-size: 35px;
  margin-top: 15px;
}
.egyebParent h1,
h2 {
  font-variant: small-caps;
  width: 100%;
}

.egyebParent .flex-buttons {
  width: 100%;
  display: flex;
  justify-content: space-between;
  margin-top: 10px;
}

.egyebParent .flex-buttons button {
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
  font-weight: 600;
  cursor: pointer;
  text-align: center;
  margin: 10px;
  min-width: 0;
  width: 30%;
  max-width: 180px;
}

.egyebParent .text {
  -webkit-appearance: none;
  -moz-appearance: none;
  appearance: none;
  border-radius: 0.3em;
  border: 1px solid black;
  box-sizing: border-box;
  background-color: white;
  font-family: -apple-system, BlinkMacSystemFont, Segoe UI, Roboto, Helvetica,
    Arial, sans-serif, Apple Color Emoji, Segoe UI Emoji, Segoe UI Symbol;
  padding: 0.75em;
  display: flex;
  flex-wrap: wrap;
  width: 65%;
  font-weight: 400;
  line-height: 1.2em;
  margin: auto;
  font-size: 20px;
  box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
}

.egyebParent .help-text {
  width: 65%;
  text-align: center;
  margin: auto;
  font-size: 14px;
  color: rgb(88, 88, 88);
  margin-top: 8px;
}

.egyebParent .text:focus {
  outline: 0;
  border: 1px solid #10bbe6;
}

.egyebParent #label {
  display: block;
  line-height: 1.5;
  font-size: 18px;
  font-weight: bold;
  margin-bottom: 3px;
}

.egyebParent .formulate-form {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
}

.egyebParent .formulate-input-element .formulate-input-wrapper {
  display: flex;
  width: 120px;
  margin: auto;
}

.egyebParent .formulate-input {
  width: 100%;
  display: flex;
  flex-wrap: wrap;
}

.egyebParent .formulate-input-group-item {
  display: flex;
  width: auto;
  width: 220px;
}

.egyebParent .formulate-input-group-item .formulate-input-element {
  display: flex;
  flex-wrap: wrap;
  margin-top: 0;
  margin-right: 2px;
  width: 20px;
  height: 20px;
}

.egyebParent .formulate-input-group {
  display: flex;
  justify-content: space-around;
  flex-wrap: wrap;
}

@media only screen and (max-width: 1052px) {
  .egyebParent h1 {
    font-size: 45px;
    color: white;
    text-shadow: 2px 2px 5px #10bbe6;
    margin: auto;
  }
  .egyebParent .flex {
    width: 85%;
    margin: 40px auto;
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
  .egyebParent .text {
    border-radius: 0.3em;
    border: 1px solid black;
    box-sizing: border-box;
    background-color: white;
    font-family: -apple-system, BlinkMacSystemFont, Segoe UI, Roboto, Helvetica,
      Arial, sans-serif, Apple Color Emoji, Segoe UI Emoji, Segoe UI Symbol;
    padding: 0.5em;
    display: flex;
    flex-wrap: wrap;
    width: 70%;
    font-weight: 400;
    line-height: 1.2em;
    margin: auto;
    font-size: 17px;
    box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
  }
  .egyebParent .help-text {
    width: 70%;
    font-size: 14px;
  }
  .egyebParent h2 {
    color: #5f5f5f;
    font-size: 30px;
    margin: auto;
    margin-top: 15px;
  }
  .egyebParent p {
    font-size: 17px;
    margin: 10px auto;
  }

  .egyebParent span {
    margin: 10px 8px;
    border: 1px solid black;
    border-radius: 5px;
    padding: 5px;
    font-size: 17px;
  }
}
@media only screen and (max-width: 605px) {
  .egyebParent .text {
    border-radius: 0.3em;
    border: 1px solid black;
    box-sizing: border-box;
    background-color: white;
    font-family: -apple-system, BlinkMacSystemFont, Segoe UI, Roboto, Helvetica,
      Arial, sans-serif, Apple Color Emoji, Segoe UI Emoji, Segoe UI Symbol;
    padding: 0.4em;
    display: flex;
    flex-wrap: wrap;
    width: 85%;
    font-weight: 400;
    line-height: 1.2em;
    margin: auto;
    font-size: 17px;
    box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
  }
  .egyebParent .help-text {
    width: 85%;
    font-size: 13px;
  }
  .egyebParent h1 {
    font-size: 35px;
    color: white;
    text-shadow: 2px 2px 5px #10bbe6;
    margin: auto;
  }
  .egyebParent .span-wrapper {
    width: 90%;
    display: flex;
    flex-wrap: wrap;
    margin: auto;
  }
}
</style>
