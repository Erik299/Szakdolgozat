using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logopédia_WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logopédia_WebAPI.Models;

namespace Logopédia_WebAPI.Controllers.Tests
{
    [TestClass()]
    public class OvodakControllerTests
    {
        private OvodakController controller = new OvodakController(new LogopediaContext());

        [TestMethod()]
        public async Task Getovodak_OvodakSzama()
        {
            var response = await controller.Getovodak();
            var result = response.Value;
            var result2 = response.Value as List<Ovodak>;

            Assert.IsNotNull(result);
            int ovodakSzama = 20;
            Assert.AreEqual(result.Count(), ovodakSzama);
            Assert.AreEqual(result2.Count(), ovodakSzama);
        }
    }
}