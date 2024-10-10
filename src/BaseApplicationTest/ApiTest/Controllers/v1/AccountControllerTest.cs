using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest.Controllers.v1
{
    public class AccountControllerTest
    {
        [Fact]
        public async Task Captcha()
        {
            var httpClient = new HttpClient();
            var res = await httpClient.GetAsync("");
        }
    }
}
