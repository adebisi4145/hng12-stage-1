using Microsoft.AspNetCore.Mvc;

namespace hng12_stage_1.Controllers
{
    [ApiController]
    [Route("api/classify-number")]
    public class NumberClassificationController : Controller
    {
        private readonly HttpClient _httpClient;
        public NumberClassificationController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetNumberClassification([FromQuery] string number)
        {
            if (!int.TryParse(number, out int num))
                return BadRequest(new { number, error = true });

            var response = new
            {
                number = num,
                is_prime = IsPrime(num),
                is_perfect = IsPerfect(num),
                properties = Properties(num),
                digit_sum = DigitSum(num),
                fun_fact = await FunFact(num),
            };

            return Ok(response);
        }

        private bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        private bool IsPerfect(int number)
        {
            int sum = 0;
            for (int i = 1; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }

            return sum == number;
        }

        private string[] Properties(int num)
        {
            List<string> properties = new List<string>();
            if (IsPrime(num))
                properties.Add("prime");

            if (IsPerfect(num))
                properties.Add("perfect");

            if (IsArmstrong(num))
                properties.Add("armstrong");

            properties.Add(num % 2 == 0 ? "even" : "odd");

            return properties.ToArray();
        }
        private bool IsArmstrong(int number)
        {
            int sum = 0, num = number;
            int digitCount = number.ToString().Length;

            while (num > 0)
            {
                sum += (int)Math.Pow(num % 10, digitCount);
                num /= 10;
            }

            return sum == number;
        }
        private int DigitSum(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

        private async Task<string> FunFact(int number)
        {
            try
            {
                string url = $"http://numbersapi.com/{number}";
                return await _httpClient.GetStringAsync(url);
            }
            catch
            {
                return "No fun fact found";
            }
        }
    }
}
