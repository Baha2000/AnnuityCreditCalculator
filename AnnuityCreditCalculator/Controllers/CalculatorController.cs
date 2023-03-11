using AnnuityCreditCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnuityCreditCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(InputCreditData data)
        {
            if (ModelState.IsValid)
            {
                CreditCalculator calc = new CreditCalculator(data);

                List<OutputCreditData> creditList = calc.CalculateData();

                return View(creditList);
            }

            return View("Index", data);
        }

        public IActionResult DayCalculator()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DayCalculate(InputDayCreditData data)
        {
            if (ModelState.IsValid)
            {
                CreditCalculator calc = new CreditCalculator(data);

                List<OutputCreditData> creditList = calc.CalculateDayData();

                return View("Calculate", creditList);
            }

            return View("DayCalculator", data);
        }
    }
}
