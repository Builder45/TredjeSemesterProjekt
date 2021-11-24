using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeboerWeb.Application.Requests;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.EjendomUC
{
    public interface IGetEjendomUseCase
    {
        Ejendom GetEjendom(GetEjendomRequest command);
        List<Ejendom> GetEjendomme();
    }
}
