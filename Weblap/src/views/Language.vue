<template>
  <div class="nyelvParent">
    <home-button buttonText="Home"></home-button>
    <h1>Nyelvhasználat</h1>
    <div class="flex">
      <FormulateForm v-model="nyelvValues" @submit="click">
        <FormulateInput
          type="radio"
          :options="{ nem: 'Nem', igen: 'Igen' }"
          label="1. Megérti-e a gyermeke, mit jelent az 'egy'? Ha csak egyet kér valamiből (pl. keksz, kocka, stb.), egyet ad-e a gyerek és aztán megáll-e?"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          :options="{ nem: 'Nem', igen: 'Igen' }"
          label="2. Mond-e a gyermeke 'Mi' vagy 'Hol' kezdezű, többszavas kérdéseket?"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          :options="{ nem: 'Nem', igen: 'Igen' }"
          label="3. Mond-e a gyermeke 'Miért' vagy 'Hogy/Hogyan' kezdetű, többszavas kérdéseket?"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          :options="{ nem: 'Nem', igen: 'Igen' }"
          label="4. Szokott-e a gyermeke megmagyarázni dolgokat 'mert' szó használatával?"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          :options="{ nem: 'Nem', igen: 'Igen' }"
          label="5. Ha megkérdezné a gyermekét, 'Mi az a ló?', tudná mondani, hogy 'egy állat'?"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          :options="{ nem: 'Nem', igen: 'Igen' }"
          label="6. Megnevez-e a gyereke egyszerű alakzatokat, mint 'kör', 'négyzet' vagy 'háromszög'?"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          :options="{ nem: 'Nem', igen: 'Igen' }"
          label="7. Beszél-e a gyermeke a lehetséges történésekről, pl.: 'lehet, hogy leesik'?"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          :options="{ nem: 'Nem', igen: 'Igen' }"
          label="8. Előfordul-e, hogy a gyermeke megkérdezi, mit jelent egy bizonyos szó?"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          :options="{ nem: 'Nem', igen: 'Igen' }"
          label="9. Meg tudja-e gyermeke mondani, hogy két, éppen nem látható dolog közül melyik nagyobb, pl.: 'melyik nagyobb, a ló vagy a kutya'?"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          :options="{ nem: 'Nem', igen: 'Igen' }"
          label="10. Meg tudja-e mondani gyermeke, melyik a jobb és bal keze?"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          :options="{ nem: 'Nem', igen: 'Igen' }"
          label="11. Hazsnál-e gyermeke 'leg' kezdetű szavakat, pl.: 'legnagyobb', 'legerősebb'?"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          :options="{ nem: 'Nem', igen: 'Igen' }"
          label="12. Tud-e felelni gyermeke, ha megkérdezzük, 'mit csinálsz, ha éhes vagy?', vagy 'mit csinálsz, ha fáradt vagy?', pl.: 'enni kérek', 'eszek', 'aludni megyek', 'pihenek'?"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          :options="{ nem: 'Nem', igen: 'Igen' }"
          label="13. Szokott-e a gyermeke engedélyt kérni, pl.: 'Ehetek még?' vagy 'Felmászhatok oda?'?"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          :options="{ nem: 'Nem', igen: 'Igen' }"
          label="14. Szokott-e gyermeke feltételesen kijelenteni valamit, pl.: 'szívesen játszanék vele'?"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <div class="flex-buttons">
          <bwd-button buttonText="Vissza" />
          <button type="submit">Tovább</button>
        </div>
      </FormulateForm>
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
      nyelvValues: [],
      count: 0,
      nyelvPoints: 0,
    };
  },
  created() {
    if (localStorage.nyelvPoints) {
      this.nyelvPoints = localStorage.nyelvPoints;
    }
    this.refresh = localStorage.getItem("refresh1");
    console.log(this.refresh);
    if (this.refresh == 0) {
      location.reload();
      localStorage.setItem("refresh1", "1");
    }
    this.nyelvValues = JSON.parse(localStorage.getItem("nyelvValues") || "[]");
  },
  methods: {
    click() {
      Object.values(this.nyelvValues).forEach((value) => {
        if (value == "igen") {
          this.count++;
        }
      });
      // this.count = this.count;
      this.nyelvPoints = this.count;
      this.count = 0;
      localStorage.setItem("refresh1", "0");
      localStorage.nyelvPoints = this.nyelvPoints;
      localStorage.setItem("nyelvValues", JSON.stringify(this.nyelvValues));
      router.push("Egyeb");
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
.nyelvParent h1 {
  font-size: 55px;
  color: white;
  text-shadow: 2px 2px 5px #10bbe6;
}
.nyelvParent h2 {
  color: #5f5f5f;
  font-size: 35px;
}
.nyelvParent h1,
h2 {
  font-variant: small-caps;
  width: 100%;
}

.nyelvParent .flex {
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

.nyelvParent .flex-buttons {
  width: 100%;
  display: flex;
  justify-content: space-between;
  margin-top: 10px;
}

.nyelvParent .flex-buttons button {
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

.nyelvParent .formulate-input {
  width: 100%;
  display: flex;
  justify-content: space-around;
  flex-wrap: wrap;
  border-bottom: 1px solid #10bbe6;
}
.nyelvParent .formulate-input-group .formulate-input {
  border-bottom: 0;
}

.nyelvParent .formulate-input-wrapper {
  display: flex;
  width: 100%;
  justify-content: space-between;
  margin: 5px;
}

.nyelvParent .formulate-input-element {
  display: flex;
}

@media only screen and (max-width: 1052px) {
  .nyelvParent h1 {
    font-size: 45px;
    color: white;
    text-shadow: 2px 2px 5px #10bbe6;
  }
  .nyelvParent h2 {
    color: #5f5f5f;
    font-size: 30px;
  }
  .nyelvParent .formulate-input-label--before {
    width: 100%;
    font-size: 16px;
  }
  .nyelvParent .formulate-input-wrapper {
    display: flex;
    flex-wrap: wrap;
    width: 100%;
    justify-content: space-between;
    margin: 5px;
  }
  .nyelvParent .formulate-input {
    width: 100%;
    display: flex;
    margin: auto;
    flex-wrap: wrap;
    justify-content: space-around;
  }
  .nyelvParent .formulate-input-group {
    display: flex;
    justify-content: space-around;
    width: 191px;
    margin: auto;
  }
  .nyelvParent .formulate-input-group-item {
    margin-right: 15px;
  }
  .nyelvParent .flex {
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
