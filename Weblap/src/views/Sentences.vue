<template>
  <div class="mondatParent">
    <home-button buttonText="Home"></home-button>
    <h1>Mondatok</h1>
    <div class="flex">
      <p>
        A gyerekek a mondatok szabályait fokozatosan tanulják meg. Az alábbi
        mondatpárok tagjai közül azt jelölje meg, amelyik jobban hasonlít
        gyermeke beszédére mostanában. Ha a gyermeke mindkettőnél összetettebb,
        hosszabb mondatokat használ, jelölje meg a másodikat
      </p>
      <FormulateForm v-model="mondatValues" @submit="click">
        <FormulateInput
          type="radio"
          label="1."
          :options="{ 1: 'Az mi az?', 2: 'Mi az ott?' }"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          label="2."
          :options="{ 1: 'Foly orrom.', 2: 'Folyik a orrom.' }"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          label="3."
          :options="{
            1: 'Semmit török össze.',
            2: 'Semmit sem török össze.',
          }"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          label="4."
          :options="{ 1: 'Még alma.', 2: 'Kérek még almát.' }"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          label="5."
          :options="{ 1: 'Az mi az?', 2: 'Mi az ott?' }"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          label="6."
          :options="{ 1: 'Nem visszaadom.', 2: 'Nem adom vissza.' }"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          label="7."
          :options="{ 1: 'Haza menni!', 2: 'Menjünk haza!' }"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          label="8."
          :options="{ 1: 'Neki van autó.', 2: 'Neki van egy autója.' }"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          label="9."
          :options="{ 1: 'Mos kezet.', 2: 'Megmostam a kezemet.' }"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          label="10."
          :options="{ 1: 'Ez tiém.', 2: 'Ez az enyém.' }"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          label="11."
          :options="{ 1: 'Baba alud.', 2: 'A baba alszik.' }"
          validation="required"
          :validation-messages="{
            required: 'A mező kitöltése kötelező!',
          }"
        />
        <FormulateInput
          type="radio"
          label="12."
          :options="{ 1: 'Ott apa bicikli.', 2: 'Ott van apa biciklije.' }"
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
      mondatValues: null,
      count: 0,
      mondatPoints: 0,
      refresh: 0,
    };
  },
  created() {
    if (localStorage.mondatPoints) {
      this.mondatPoints = localStorage.mondatPoints;
    }
    this.refresh = localStorage.getItem("refresh");
    console.log(this.refresh);
    if (this.refresh == 0) {
      location.reload();
      localStorage.setItem("refresh", "1");
    }
    this.mondatValues = JSON.parse(
      localStorage.getItem("mondatValues") || "[]"
    );
  },
  methods: {
    click() {
      Object.values(this.mondatValues).forEach((value) => {
        if (value == "2") {
          this.count++;
        }
      });
      // this.count = this.count / 3;
      this.mondatPoints = this.count;
      this.count = 0;
      localStorage.setItem("mondatValues", JSON.stringify(this.mondatValues));
      localStorage.mondatPoints = this.mondatPoints;
      localStorage.setItem("refresh", "0");
      router.push("/Nyelvhasznalat");
      console.log(this.mondatPoints);
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
.mondatParent p {
  font-size: 20px;
}
.mondatParent h1 {
  font-size: 55px;
  color: white;
  text-shadow: 2px 2px 5px #10bbe6;
}
.mondatParent h2 {
  color: #5f5f5f;
  font-size: 35px;
}
.mondatParent h1,
h2 {
  font-variant: small-caps;
  width: 100%;
}

.mondatParent .flex {
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

.mondatParent .flex-buttons button {
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

.mondatParent .flex-buttons {
  width: 100%;
  display: flex;
  justify-content: space-between;
  margin-top: 10px;
}

.mondatParent .formulate-form {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
}

.mondatParent .formulate-input-element .formulate-input-wrapper {
  display: flex;
  margin-right: auto;
}

.mondatParent .formulate-input {
  width: 35%;
  display: flex;
  flex-wrap: wrap;
  margin-left: 8%;
}

.mondatParent .formulate-input-group-item {
  width: 100%;
  display: flex;
  margin-left: 30px;
}

.mondatParent .formulate-input-element {
  display: flex;
  flex-wrap: wrap;
  margin-right: 3px;
}

@media only screen and (max-width: 1052px) {
  .mondatParent h1 {
    font-size: 45px;
    color: white;
    text-shadow: 2px 2px 5px #10bbe6;
  }
  .mondatParent h2 {
    color: #5f5f5f;
    font-size: 30px;
  }
  .mondatParent p {
    font-size: 17px;
  }
  .mondatParent .formulate-input {
    width: 40%;
    display: flex;
  }
  .mondatParent .formulate-input-group-item {
    width: 100%;
    display: flex;
  }
  .mondatParent .flex {
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
  .mondatParent .formulate-input-label--after {
    font-size: 17px;
  }
}
@media only screen and (max-width: 699px) {
  .mondatParent p {
    font-size: 16px;
  }

  .mondatParent .formulate-input {
    width: 80%;
    display: flex;
    margin-left: auto;
  }
  .mondatParent .formulate-input-group-item {
    width: 100%;
    display: flex;
  }
  .mondatParent .formulate-input .formulate-input-wrapper {
    display: flex;
    margin: auto;
    width: 95%;
  }
  .mondatParent .formulate-input-element .formulate-input-wrapper {
    display: flex;
    margin-left: 10px;
  }
  .mondatParent .formulate-input-label--after {
    font-size: 16px;
  }
}
@media only screen and (max-width: 450px) {
  .mondatParent .formulate-input {
    width: 100%;
    display: flex;
  }
  .mondatParent .formulate-input-group-item {
    width: 100%;
    display: flex;
  }
  .mondatParent .formulate-input-element .formulate-input-wrapper {
    display: flex;
    margin-left: 10px;
  }
}
</style>
