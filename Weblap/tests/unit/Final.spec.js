import { mount } from "@vue/test-utils";
import Final from "@/views/Final.vue";

describe("Final oldal tesztelése", () => {
  test('Megjeleníti és eltűnteti-e a "Szókincs" szöveget?', async () => {
    const wrapper = mount(Final);
    const text = wrapper.find('[class="points-low-wrapper"]');

    expect(text.find("#szkinfo").classes()).toContain("show");

    await wrapper.setData({
      vocLow: false,
    });

    expect(text.find("#szkinfo").classes()).not.toContain("show");
  });

  test('Megjeleníti és eltűnteti-e a "Mondatok" szöveget?', async () => {
    const wrapper = mount(Final);
    const text = wrapper.find('[class="points-low-wrapper"]');

    expect(text.find("#minfo").classes()).toContain("show");

    await wrapper.setData({
      senLow: false,
    });

    expect(text.find("#minfo").classes()).not.toContain("show");
  });

  test('Megjeleníti és eltűnteti-e a "Nyelvhasználat" szöveget?', async () => {
    const wrapper = mount(Final);
    const text = wrapper.find('[class="points-low-wrapper"]');

    expect(text.find("#nyinfo").classes()).toContain("show");

    await wrapper.setData({
      langLow: false,
    });

    expect(text.find("#nyinfo").classes()).not.toContain("show");
  });
});
