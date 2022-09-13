using Logopédia_WebAPI.Controllers;
using Logopédia_WebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logopédia_WebAPI.Test
{
    [TestClass]
    public class SzakemberekControllerTests
    {
        private SzakemberekController controller = new(new LogopediaContext());

        private List<Szakemberek> GetAll()
        {
            var összesSzakember = new List<Szakemberek>();
            return összesSzakember;
        }

        private Szakemberek GetSzakember()
        {
            return new Szakemberek()
            {
                ellato_szakemberID = 1,
                nev = "Apró Anita",
                munkahely = "Szegedi Tagintézmény",
                email = "apro@teszt.com",
                telefonszam = "06-70-111-1111"
            };
        }

        // GET: api/Szakemberek/1
        [TestMethod]
        public async Task GetSzakember_NevEgyezes()
        {
            var szakember = GetSzakember();
            var response = await controller.GetSzakemberek(1);
            var result = response.Value;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.nev, szakember.nev);
        }
    }
}
