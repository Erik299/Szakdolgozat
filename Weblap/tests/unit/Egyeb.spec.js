import { mount } from "@vue/test-utils";
import Egyeb from "@/views/Egyeb.vue";

describe("Egyeb oldal tesztelése", () => {
  test("Küldendő objektum kap-e értéket?", async () => {
    const wrapper = mount(Egyeb);
    const input = wrapper.find('input[name="sentences"]');

    await input.setValue("Tesztelő");

    expect(wrapper.vm.newSentence).toBe("Tesztelő");
  });
});
