<template>
  <div class="formParent">
    <home-button buttonText="Home" />
    <h1 class="form-title">Személyes adatok</h1>
    <FormulateForm v-model="formValues" @submit="click">
      <div class="flex">
        <h2>Gyermek személyes adatai</h2>
        <FormulateInput
          name="lastName"
          label="Vezetéknév:"
          validation="required|matches:/^[a-zA-záéíóöőúüűÁÉÍÓÖŐÚÜŰ]+$/"
          :validation-messages="{
            required: 'A Vezetéknév mező kitöltése kötelező!',
            matches: 'Kérjük valós nevet adjon meg!',
          }"
        />
        <FormulateInput
          name="firstName"
          label="Keresztnév:"
          validation="required|matches:/^[a-zA-záéíóöőúüűÁÉÍÓÖŐÚÜŰ]+$/"
          :validation-messages="{
            required: 'A Keresztnév mező kitöltése kötelező!',
            matches: 'Kérjük valós nevet adjon meg!',
          }"
        />
        <FormulateInput
          name="eduID"
          label="Oktatási azonosító:"
          validation="required|matches:/^[1-9][0-9]*$/|min:11,length|max:11,length"
          :validation-messages="{
            required: 'Az Oktatási azonosító mező kitöltése kötelező!',
            matches: 'Kérjük valós számot adjon meg!',
            min: 'Legalább 11 számjegyből kell állnia!',
            max: 'Maximum 11 számjegyből állhat!',
          }"
        />
        <FormulateInput
          name="birthPlace"
          label="Születési hely:"
          validation="required|matches:/^[a-zA-záéíóöőúüűÁÉÍÓÖŐÚÜŰ]+$/"
          :validation-messages="{
            required: 'A Születési hely mező kitöltése kötelező!',
            matches: 'Kérjük valós várost adjon meg!',
          }"
        />
        <FormulateInput
          type="date"
          name="birthDate"
          v-model="birthDate"
          label="Születési idő:"
          :validation="[['before', new Date()], ['required']]"
          :validation-messages="{
            required: 'Kérjük jelöljön be egy dátumot!',
            before: 'Helyes dátumot adjon meg!',
          }"
        />

        <FormulateInput
          name="momName"
          label="Anyja leánykori neve:"
          validation="required|matches:/[a-zA-ZáéíóöőúüűÁÉÍÓÖŐÚÜŰ\-]+[ ][a-zA-záéíóöőúüűÁÉÍÓÖŐÚÜŰ]+$/"
          :validation-messages="{
            required: 'Az Anyja neve mező kitöltése kötelező!',
            matches: 'Kérjük valós nevet adjon meg!',
          }"
        />
        <FormulateInput
          name="nurseryName"
          label="Jelenlegi óvodája:"
          validation="required"
          type="select"
          :options="
            nursaries.map((value) => ({ label: value.nev, value: value.id }))
          "
          :validation-messages="{
            required: 'Kérjük, válasszon egyet!',
          }"
        />
      </div>
      <div class="flex">
        <h2>Szakértői vizsgálaton való részvétel</h2>
        <FormulateInput
          name="diagDate"
          v-model="diagDate"
          label="Diagnózis adás időpontja:"
          type="date"
          :validation="[['before', new Date()], ['required']]"
          :validation-messages="{
            before: 'Helyes dátumot adjon meg!',
            required: 'Kérjük jelöljön be egy dátumot!',
          }"
        />
        <FormulateInput
          name="diagName"
          label="Diagnózis megnevezése:"
          v-model="diagName"
          type="select"
          validation="required"
          :validation-messages="{
            required: 'Kérjük, válasszon egyet!',
          }"
          :options="
            diagnosises.map((value) => ({ label: value.nev, value: value.id }))
          "
        />
        <FormulateInput
          name="attendance"
          label="Szakértői bizottság logopédiai ellátást előírt-e:"
          v-model="attendance"
          validation="required"
          type="select"
          @change="change"
          :options="{
            1: 'Igen',
            0: 'Nem',
          }"
          :validation-messages="{
            required: 'Kérjük, válasszon egyet!',
          }"
        />
      </div>
      <div class="flex">
        <h2>Gyermek gondviselőjének személyes adatai</h2>
        <FormulateInput
          name="parentLastName"
          label="Vezetéknév:"
          validation="required|matches:/^[a-zA-záéíóöőúüűÁÉÍÓÖŐÚÜŰ]+$/"
          :validation-messages="{
            required: 'A Vezetéknév mező kitöltése kötelező!',
            matches: 'Kérjük valós nevet adjon meg',
          }"
        />
        <FormulateInput
          name="parentFirstName"
          label="Keresztnév:"
          label-position="before"
          validation="required|matches:/^[a-zA-záéíóöőúüűÁÉÍÓÖŐÚÜŰ]+$/"
          :validation-messages="{
            required: 'A Keresztnév mező kitöltése kötelező!',
            matches: 'Kérjük valós nevet adjon meg',
          }"
        />
        <FormulateInput
          name="phoneNum"
          label="Telefonszám:"
          :validation="[
            ['required'],
            [
              'matches',
              /^((?:\+?3|0)6)(?:-|\()?(\d{1,2})(?:-|\))?(\d{3})-?(\d{3,4})$/,
            ],
          ]"
          :validation-messages="{
            required: 'A Telefonszám mező kitöltése kötelező!',
            matches: 'Kérjük valós telefonszámot adjon meg!',
          }"
        />
        <FormulateInput
          type="email"
          name="email"
          label="Email cím"
          validation="required|email"
          :validation-messages="{
            required: 'Az email cím mező kitöltése kötelező!',
            email: 'Valós email címet adjon meg!',
          }"
        />
      </div>
      <div class="flex">
        <h2>Értesítési cím</h2>
        <FormulateInput
          name="zipCode"
          label="Irányítószám"
          validation="required|matches:/^[1-9][0-9]*$/|min:4,length|max:4,length"
          :validation-messages="{
            required: 'Az Irányítószám mező kitöltése kötelező!',
            matches: 'Kérjük valós irányítószámot adjon meg',
            min: 'Legalább 4 számjegyből kell állnia!',
            max: 'Maximum 4 számjegyből állhat!',
          }"
        />

        <FormulateInput
          name="city"
          label="Város:"
          validation="required|matches:/^[a-zA-záéíóöőúüűÁÉÍÓÖŐÚÜŰ]+$/"
          :validation-messages="{
            required: 'A Város mező kitöltése kötelező!',
            matches: 'Kérjük valós város nevet adjon meg!',
          }"
        />
        <FormulateInput
          name="address"
          label="Utca, házszám:"
          validation="required"
          :validation-messages="{
            required: 'Az Utca, házszám mezők kitöltése kötelező!',
          }"
        />
      </div>
      <div id="mid">
        <FormulateInput type="submit" label="Tovább" />
      </div>
    </FormulateForm>
  </div>
</template>

<script>
import HomeButton from "./../components/buttons/HomeButton.vue";
import router from "../router";
import axios from "axios";
import moment from "moment";

export default {
  data: () => ({
    formValues: {},
    nursaries: [],
    diagnosises: [],
    nursaryNev: null,
    diagDate: moment(new Date()).format("YYYY-MM-DD"),
    birthDate: moment(new Date()).format("YYYY-MM-DD"),
    attendance: null,
    diagName: 1,
  }),
  created() {
    this.getNurseryName();
    this.getDiagnosisName();
    if (localStorage.lastName) {
      this.formValues.lastName = localStorage.lastName;
    }
    if (localStorage.firstName) {
      this.formValues.firstName = localStorage.firstName;
    }
    if (localStorage.eduID) {
      this.formValues.eduID = localStorage.eduID;
    }
    if (localStorage.birthPlace) {
      this.formValues.birthPlace = localStorage.birthPlace;
    }
    if (localStorage.birthDate) {
      this.formValues.birthDate = localStorage.birthDate;
    }
    if (localStorage.momName) {
      this.formValues.momName = localStorage.momName;
    }
    if (localStorage.nurseryID) {
      this.formValues.nurseryName = localStorage.nurseryID;
    }
    if (localStorage.diagDate) {
      this.formValues.diagDate = localStorage.diagDate;
      this.diagDate = localStorage.diagDate;
    }
    if (localStorage.diagID) {
      this.formValues.diagName = localStorage.diagID;
      this.diagName = localStorage.diagID;
    }
    if (localStorage.attendance) {
      this.formValues.attendance= localStorage.attendance;
      this.attendance = localStorage.attendance;
    }
    if (localStorage.parentLastName) {
      this.formValues.parentLastName = localStorage.parentLastName;
    }
    if (localStorage.parentFirstName) {
      this.formValues.parentFirstName = localStorage.parentFirstName;
    }
    if (localStorage.phoneNum) {
      this.formValues.phoneNum = localStorage.phoneNum;
    }
    if (localStorage.email) {
      this.formValues.email = localStorage.email;
    }
    if (localStorage.city) {
      this.formValues.city = localStorage.city;
    }
    if (localStorage.zipCode) {
      this.formValues.zipCode = localStorage.zipCode;
    }
    if (localStorage.address) {
      this.formValues.address = localStorage.address;
    }
  },
  mounted() {
    window.scrollTo(0, 0);
  },
  methods: {
    change() {
      if (this.attendance == 1) {
        this.diagName = null;
        this.diagDate = null;
      }
      else{
        this.diagDate = moment(new Date()).format("YYYY-MM-DD");
        this.diagName = 1;
      }
    },
    getNurseryName() {
      axios.get("http://localhost:5000/api/Ovodak").then((response) => {
        for (let i = 0; i < response.data.length; i++) {
          this.nursaries.push({
            id: response.data[i].ovodaID,
            nev: response.data[i].ovoda_neve,
          });
        }
      });
    },
    getDiagnosisName() {
      axios.get("http://localhost:5000/api/diagnozisok").then((response) => {
        for (let i = 0; i < response.data.length; i++) {
          if (response.data[i].diagnozis_megnevezese == "") {
            this.diagnosises.push({
              id: response.data[i].diagnozisID,
              nev: "Nincs",
            });
          } else {
            this.diagnosises.push({
              id: response.data[i].diagnozisID,
              nev: response.data[i].diagnozis_megnevezese,
            });
          }
        }
      });
    },
    click() {
      if (this.diagdate == moment(new Date()).format("YYYY-MM-DD")) {
        localStorage.diagDate = null;
      } else {
        localStorage.diagDate = this.formValues.diagDate;
      }
      localStorage.lastName = this.formValues.lastName;
      localStorage.firstName = this.formValues.firstName;
      localStorage.eduID = this.formValues.eduID;
      localStorage.birthDate = this.formValues.birthDate;
      localStorage.birthPlace = this.formValues.birthPlace;
      localStorage.momName = this.formValues.momName;
      localStorage.nurseryID = this.formValues.nurseryName;
      localStorage.diagID = this.formValues.diagName;
      localStorage.attendance = this.formValues.attendance;
      localStorage.parentLastName = this.formValues.parentLastName;
      localStorage.parentFirstName = this.formValues.parentFirstName;
      localStorage.phoneNum = this.formValues.phoneNum;
      localStorage.email = this.formValues.email;
      localStorage.city = this.formValues.city;
      localStorage.zipCode = this.formValues.zipCode;
      localStorage.address = this.formValues.address;
      router.push("/Vocabulary1");
      console.log(this.formValues);
    },
  },
  components: {
    HomeButton,
  },
};
</script>

<style>
.formParent {
  margin: auto auto;
}

.formParent #mid {
  margin-top: 50px;
  display: flex;
  justify-content: space-around;
}

.formParent .flex {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
}

.formParent h1 {
  font-size: 55px;
  color: white;
  text-shadow: 2px 2px 5px #10bbe6;
}
.formParent h2 {
  color: #5f5f5f;
  font-size: 35px;
}
.formParent h1,
h2 {
  font-variant: small-caps;
  width: 100%;
}

.formParent .formulate-input {
  flex-wrap: wrap;
  justify-content: space-between;
  margin: auto;
}

.formParent.formulate-input-wrapper {
  margin: 5px;
  display: flex;
  justify-content: center;
}

.formParent .formulate-input-element {
  min-width: 55%;
  margin: auto;
}

.formParent .flex {
  width: 60%;
  margin: 80px auto;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  background-color: white;
  box-shadow: black 0px 22px 70px 4px;
  border-radius: 20px;
  padding: 20px;
  border: 4px solid #10bbe6;
}

@media only screen and (max-width: 1052px) {
  .formParent .flex {
    width: 85%;
    margin: 80px auto;
    display: flex;
    flex-wrap: wrap;
    justify-content: space-between;
    background-color: white;
    box-shadow: black 0px 22px 70px 4px;
    border-radius: 20px;
    padding: 10px;
    border: 4px solid #10bbe6;
  }
  .formParent h1 {
    font-size: 45px;
    color: white;
    text-shadow: 2px 2px 5px #10bbe6;
  }
  .formParent h2 {
    color: #5f5f5f;
    font-size: 30px;
    margin-bottom: 20px;
  }
}

@media only screen and (max-width: 512px) {
  .formParent .formulate-input-element input,
  select {
    height: 40px;
    padding-left: 5px !important;
    padding-right: 5px !important;
    padding-top: 0 !important;
    padding-bottom: 0 !important;
  }
  .formParent h1 {
    font-size: 47px;
    color: white;
    text-shadow: 2px 2px 5px #10bbe6;
  }
  .formParent h2 {
    color: #5f5f5f;
    font-size: 25px;
    margin-bottom: 20px;
  }
  .formParent .formulate-input-errors {
    font-size: 15px;
  }
  .formParent .formulate-input-label {
    font-size: 17px;
    margin-top: 10px;
  }
}
</style>
