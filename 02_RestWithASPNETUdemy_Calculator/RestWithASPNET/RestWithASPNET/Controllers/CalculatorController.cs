using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {


        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConverToDecimal(firstNumber) + ConverToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input, try again");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetSub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConverToDecimal(firstNumber) - ConverToDecimal(secondNumber);
                return Ok(sub.ToString());
            }

            return BadRequest("Invalid Input, try again");
        }
        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult GetMult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mult = ConverToDecimal(firstNumber) * ConverToDecimal(secondNumber);
                return Ok(mult.ToString());
            }

            return BadRequest("Invalid Input, try again");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult GetDiv(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var div = ConverToDecimal(firstNumber) / ConverToDecimal(secondNumber);
                return Ok(div.ToString());
            }

            return BadRequest("Invalid Input, try again");
        }

        [HttpGet("med/{firstNumber}/{secondNumber}")]
        public IActionResult GetMed(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var med = (ConverToDecimal(firstNumber) + ConverToDecimal(secondNumber)) / 2;
                return Ok(med.ToString());
            }

            return BadRequest("Invalid Input, try again");
        }

        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult GetSqrt(int firstNumber)
        {
            
                var sqrt= Math.Sqrt(firstNumber) ;
                return Ok(sqrt.ToString());
            

            return BadRequest("Invalid Input, try again");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);
            return isNumber;
        }

        private decimal ConverToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
    }
}
