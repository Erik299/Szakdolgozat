import { mount } from "@vue/test-utils";
import Form from "@/views/Form.vue";

describe("Űrlap tesztelése", () => {
  test('Létezik-e a "Személyes adatok" cím?', () => {
    const wrapper = mount(Form);
    const text = wrapper.find('[class="form-title"]').text();

    expect(text).toBe("Személyes adatok");
  });
});
