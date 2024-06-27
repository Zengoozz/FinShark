#region Portfolio Creation
// Inject UserManager, StockRepository ☑
// Create Get Method (Authorized) ☑
// Access User obj which is inherited through the ControllerBase ☑
// Create Extension "ClaimsExtensions" ☑
// Add GetUserName Method taking the ClaimsPrincipal as user in the ClaimsExtensions File ☑
// Get the User using the userManager ☑
// Create Interface IPortfolioRepository and add GetUserPortfolioAsync method which return List of Stocks ☑
// Create Repository and Implement the interface ☑
// Bind the repo and interface ☑
// Use the GetUserPortfolio method to get the portfolio in the Get Method in this file ☑
// Manually create a portfolio through the database ☑
// Create the AddPortfolio method ☑
// Get the username using the extension then get the user through the usermanager ☑
// Get the stock using symbol (Create GetBySymbolAsync method) ☑
// Validate the stock existance ☑
// Get the userPortfolio ☑
// Validate that the userPortfolio doesnot contains the stock using symbol ☑
// Create new portfolio obj ☑
// Create a CreatePortfolioAsync method and add it to the repo then implement it returning the portfolio ☑
// Use the method to create the portfolio using the controller ☑
// Validate that the portfolio created ☑
#endregion

#region Portfolio Deletion
// Create the Delete Action taking symbol as arg in the controller
// Get the User
// Get the Portfolio
// Filter with Stock Symbol then validate if it exists
// Then call the delete method from portfolio repo which takes appUser and symbol as args

#endregion

using api.Extensions;
using api.Interfaces;
using api.Interfaces.Repositories;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {

        #region Injection
        private readonly UserManager<AppUser> _UserManager;
        private readonly IStockRepository _StockRepository;
        private readonly IPortfolioRepository _PortfolioRepostiory;
        public PortfolioController(
            UserManager<AppUser> userManager,
            IStockRepository stockRepository,
            IPortfolioRepository portfolioRepository
            )
        {
            _UserManager = userManager;
            _StockRepository = stockRepository;
            _PortfolioRepostiory = portfolioRepository;
        }
        #endregion

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var username = User.GetUsername();
            var user = await _UserManager.FindByNameAsync(username);
            var stocks = await _PortfolioRepostiory.GetUserPortfolioAsync(user);

            return Ok(stocks);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio(string symbol)
        {
            var username = User.GetUsername();
            var user = await _UserManager.FindByNameAsync(username);
            var stock = await _StockRepository.GetBySymbolAsync(symbol);

            if (stock == null)
                return BadRequest("Stock not found");

            var userStocks = await _PortfolioRepostiory.GetUserPortfolioAsync(user);

            if (userStocks.Any(s => s.Symbol.Equals(symbol, StringComparison.CurrentCultureIgnoreCase)))
                return BadRequest("Can't add same stock again");

            var portfolioModel = new Portfolio
            {
                AppUserId = user.Id,
                StockId = stock.Id
            };

            portfolioModel = await _PortfolioRepostiory.CreatePortfolioAsync(portfolioModel);

            if (portfolioModel == null)
                return StatusCode(500, "Couldn't create portfolio");

            return Created();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePortfolio(string symbol)
        {
            var username = User.GetUsername();
            var user = await _UserManager.FindByNameAsync(username);

            var deletedPortfolio = await _PortfolioRepostiory.DeletePortfolio(user, symbol);

            if (deletedPortfolio == null)
                return BadRequest("Stock not in your portfolio");

            return Ok();
        }
    }
}