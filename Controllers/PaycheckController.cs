using System;
using System.Collections.Generic;
using System.Globalization;
using webapi.Models;

namespace webapi.Controllers
{
    public class PaycheckController
    {
        public Paycheck PaycheckGet(Employee employee)
        {
            var paycheck = new Paycheck(); // classe com informacoes do contracheque

            var month = DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("pt-BR")); // mes de referencia
            List<Entry> listEntry = new List<Entry>(); // lista de lancamentos
            double inss = getInss(employee.Salary); // valor de desconto INSS
            double irrf = getIrrf(employee.Salary); // valor de desconto IRRF
            double fgts = ((double)8 / 100) * employee.Salary; // valor de desconto FGTS
            double transport = 0; // valor de desconto Vale transporte
            double netSalary = 0; // valor salario liquido
            double totalDis = 0; // total de descontos

            if (inss > 0)
            {
                Entry entry = new Entry();
                entry.Type = "Desconto";
                entry.Value = Math.Round(inss, 2);
                entry.Descprition = "INSS";
                listEntry.Add(entry);
                totalDis += inss;
            }

            if (irrf > 0)
            {
                Entry entry = new Entry();
                entry.Type = "Desconto";
                entry.Value = Math.Round(irrf, 2);
                entry.Descprition = "IRRF";
                listEntry.Add(entry);
                totalDis += irrf;
            }
            if (employee.HealthPlan == true)
            {
                Entry entry = new Entry();
                entry.Type = "Desconto";
                entry.Value = 10.00;
                entry.Descprition = "Plano de saúde";
                listEntry.Add(entry);
                totalDis += 10;
            }
            if (employee.DentalPlan == true)
            {
                Entry entry = new Entry();
                entry.Type = "Desconto";
                entry.Value = 5.00;
                entry.Descprition = "Plano dental";
                listEntry.Add(entry);
                totalDis += 5;
            }

            if (employee.Transport == true && employee.Salary > 1500)
            {
                transport = ((double)8 / 100) * employee.Salary;
                Entry entry = new Entry();
                entry.Type = "Desconto";
                entry.Value = Math.Round(transport, 2);
                entry.Descprition = "Vale transporte";
                listEntry.Add(entry);
                totalDis += transport;
            }

            if (fgts > 0)
            {
                Entry entry = new Entry();
                entry.Type = "Desconto";
                entry.Value = Math.Round(fgts, 2);
                entry.Descprition = "FGTS";
                listEntry.Add(entry);
                totalDis += fgts;
            }

            netSalary = employee.Salary - totalDis;

            paycheck.Month = month;
            paycheck.Entrys = listEntry;
            paycheck.GrossSalary = Math.Round(employee.Salary, 2);
            paycheck.TotalDiscount = Math.Round(totalDis, 2) * -1;
            paycheck.NetSalary = Math.Round(netSalary, 2);

            return paycheck;
        }

        //retorna a porcentagem de desconto do INSS de acordo com o salario informado
        public double getInss(double salary)
        {
            if (salary <= 1045)
            {
                return ((double)7.5 / 100) * salary;
            }
            else if (salary >= 1045.01 && salary <= 2089.60)
            {
                return ((double)9 / 100) * salary;
            }
            else if (salary >= 2089.61 && salary <= 3134.40)
            {
                return ((double)12 / 100) * salary;
            }
            else if (salary >= 3134.41 && salary <= 6101.06)
            {
                return ((double)14 / 100) * salary;
            }
            else
            {
                return 0;
            }
        }

        //retorna o valor do desconto do IRPF de acordo com o salario informado
        public double getIrrf(double salary)
        {
            double irrf = 0;
            double limit = 0;
            if (salary <= 1903.98)
            {
                irrf = 0;
            }
            else if (salary >= 1903.99 && salary <= 2826.65)
            {
                irrf = ((double)7.5 / 100) * salary;
                limit = 142.80;
            }
            else if (salary >= 2826.66 && salary <= 3751.05)
            {
                irrf = ((double)15 / 100) * salary;
                limit = 354.80;
            }
            else if (salary >= 3751.06 && salary <= 4664.68)
            {
                irrf = ((double)22.5 / 100) * salary;
                limit = 636.36;
            }
            else if (salary > 4664.68)
            {
                irrf = ((double)27.5 / 100) * salary;
                limit = 869.36;
            }

            // verifica se o valor não ultrapassa o teto do desconto
            if (irrf > limit)
            {
                return limit;
            }
            else
            {
                return irrf;
            }
        }
    }
}
