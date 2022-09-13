using Logopédia_WebAPI.Controllers;
using Logopédia_WebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logopédia_WebAPI.Test
{
    [TestClass]
    public class GyerekekControllerTests
    {
        private GyerekekController controller = new(new LogopediaContext());

        // GET: api/Gyerekek, gyerekek számának ellenőrzése
        [TestMethod]
        public async Task GetGyerekek_GyerekekSzáma()
        {
            var response = await controller.Getgyerekek();
            var result = response.Value;
            var result2 = response.Value as List<Gyerekek>;

            Assert.IsNotNull(result);
            int gyerekszam = 100;
            Assert.AreEqual(result.Count(), gyerekszam);
            Assert.AreEqual(result2.Count, gyerekszam);
        }
    }
}
