using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnuityCreditCalculator.Models
{
    public class CreditCalculator
    {
        private readonly InputCreditData _data;
        private readonly InputDayCreditData _daydata;
        private decimal _coef;
        private decimal _coefTemp;
        private decimal _fixPayment;
        private decimal _sum;
        private decimal _monthRate;
        private int _periodCount;
        private decimal _periodRate;
        private DateTime _date = DateTime.Today;

        public CreditCalculator(InputCreditData data) => _data = data;

        public CreditCalculator(InputDayCreditData data) => _daydata = data;

        public List<OutputCreditData> CalculateData()
        {
            if (_data is null)
                return null;

            List<OutputCreditData> dataList = new();

            _monthRate = _data.Rate / 12 / 100;
            _coefTemp = (decimal)Math.Pow(1 + (double)_monthRate, _data.Time);
            _coef = (_monthRate * _coefTemp) / (_coefTemp - 1);
            _fixPayment = Math.Round(_coef * _data.Amount, 2);
            _sum = _data.Amount;


            for (int i = 0; i < _data.Time; i++)
            {
                OutputCreditData data = new OutputCreditData();

                data.Percent = Math.Round(_sum * _monthRate, 2);
                data.MainCredit = Math.Round(_fixPayment - data.Percent, 2);
                data.PaymentDate = _date.AddMonths(i).ToLongDateString();
                _sum -= data.MainCredit;
                data.RestCredit = Math.Round(_sum, 2);
                data.FixPayment = _fixPayment;
                dataList.Add(data);
            }

            return dataList;
        }

        public List<OutputCreditData> CalculateDayData()
        {
            if (_daydata is null)
                return null;

            List<OutputCreditData> dataList = new();
            _periodCount = _daydata.Time / _daydata.Step;
            _periodRate = _daydata.Rate / _periodCount / 100;

            _coefTemp = (decimal)Math.Pow(1 + (double)_periodRate, _periodCount);
            _coef = (_periodRate * _coefTemp) / (_coefTemp - 1);
            _fixPayment = Math.Round(_coef * _daydata.Amount, 2);
            _sum = _daydata.Amount;

            for (int i = 0; i < _periodCount; i++)
            {
                OutputCreditData data = new OutputCreditData();

                data.Percent = Math.Round(_sum * _periodRate, 2);
                data.MainCredit = Math.Round(_fixPayment - data.Percent, 2);
                data.PaymentDate = _date.AddDays(_daydata.Step * i).ToLongDateString();
                _sum -= data.MainCredit;
                data.RestCredit = Math.Round(_sum, 2);
                data.FixPayment = _fixPayment;
                dataList.Add(data);
            }

            return dataList;
        }
    }
}
