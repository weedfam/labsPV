using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstCarII.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstCarII.ViewComponents
{
    public class AlugueresHojeViewComponent : ViewComponent
    {
        private IAlugueresHoje _alugueresHoje;

        public AlugueresHojeViewComponent(IAlugueresHoje alugueresHoje)
        {
            _alugueresHoje = alugueresHoje;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_alugueresHoje.AlgueresHoje);
        }
    }
}
