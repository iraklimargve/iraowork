using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;
using Project1.ViewModels;

namespace Project1.Controllers
{
    
    [Route("[controller]")]
    //[Authorize]
    public class MarketController : BaseController
    {
        [HttpGet]
        [Route("getall")]
        public IEnumerable<MarketViewModel> Get()
        {
            var result = new List<MarketViewModel>();
            var markets = dbContext.Markets.Where(x => !x.IsDeleted).ToList();
            foreach (var market in markets)
            {
                var model = new MarketViewModel()
                {
                    MarketId = market.Id,
                    MarketName = market.Name,
                    CompanyList = new List<CompanyViewModel>()
                };
                var curcomps = dbContext.MarketCompanies.Where(x => x.MarketId == market.Id).ToList();
                foreach (var comp in curcomps)
                {
                    var c = dbContext.Companies.Find(comp.CompanyId);
                    model.CompanyList.Add(new CompanyViewModel()
                    {
                        CompanyId = c.Id,
                        CompanyName = c.Name,
                        Price = comp.Price
                    });
                }
                result.Add(model);
            }
            return result;
        }

        [HttpPost]
        [Route("changeprice")]
        public JsonResult ChangeCompanyPrice(ChangePriceBodyModel model)
        {
            try
            {
                dbContext.MarketCompanies.Where(x => x.MarketId == model.MarketId && x.CompanyId == model.CompanyId)
                    .FirstOrDefault().Price = model.NewPrice;
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new { status = 2, message = ex.Message });
            }

            return Json(new { status = 0, message = "successfully updated!" });
        }
    }
}
