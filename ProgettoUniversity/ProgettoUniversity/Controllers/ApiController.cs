using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProgettoUniversity.Models.API;
using ProgettoUniversity.Services.Implementations;
using ProgettoUniversity.Services.Interfaces;

namespace ProgettoUniversity.Controllers
{
    public class ApiController : Controller
    {
        private IStoredValueCardService _svcService;

        private ILogger<ApiController> _logger;

        public ApiController(ILoggerFactory loggerFactory, IStoredValueCardService svcService)
        {
            _logger = loggerFactory.CreateLogger<ApiController>();
            _svcService = svcService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult IndexAssociate()
        {
            return View();
        }

        [HttpGet]
        public IActionResult IndexCharge()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Saldo(string cardCode)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Status(CreateResultViewModel card)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Transazione(CardDetailViewModel transactions)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AssociaCarta(SVCResultViewModel model)
        {
            ViewBag["Titolo"] = "Associa Carta";
            return View();
        }

        [HttpGet]
        public IActionResult Charge()
        {
            ViewBag["Titolo"] = "Ricarica Carta";
            return View();
        }

        [HttpGet]
        public IActionResult Create(CreateResultViewModel card)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Migrate(SVCResultViewModel card)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Operations(string cardCode, int typeOperation)
        {
            switch (typeOperation)
            {
                case 1:
                    var status = await _svcService.Status(cardCode);
                    return View("Status", status);
                case 2:
                    var balance = await _svcService.Balance(cardCode);
                    return View("Saldo", balance);
                case 3:
                    var transactions = await _svcService.Transactions(cardCode);
                    return View("Transazione", transactions);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AttivaCarta(CardDetailViewModel model)
        {
            SVCOperationViewModel svcBody = new SVCOperationViewModel();
            svcBody.StoredValueCardCodeCollection.Add(model.SerialNumber);

            Issuer issuer = new Issuer();
            issuer.Name = "Vittorio";
            issuer.Address = "via centomani 11";
            issuer.Telephone = "0000000";
            issuer.EMail = "domec@domecsolutions.com";
            issuer.VATNumber = "222222";

            svcBody.StoredValueCardReceipt.IssuerData = issuer;

            ReceiptProduct receiptProduct = new ReceiptProduct();
            receiptProduct.Code = model.SerialNumber;
            receiptProduct.Name = "VittorioCard";
            receiptProduct.Price = 0;
            receiptProduct.Quantity = 1;
            receiptProduct.Family = "";
            receiptProduct.Mode = "";

            svcBody.StoredValueCardReceipt.Products.Add(receiptProduct);

            Payment payment = new Payment();
            payment.CardCode = model.SerialNumber;

            svcBody.StoredValueCardReceipt.Payments.Add(payment);

            ShopReceipt shopReceipt = new ShopReceipt();
            shopReceipt.IssueDate = DateTime.Now;
            shopReceipt.UserData = "";

            svcBody.StoredValueCardReceipt.IssueDate = DateTime.Now;
            svcBody.StoredValueCardReceipt.UserData = "";

            SenderData senderData = new SenderData();
            senderData.Shop = Constants.SHOP;
            senderData.Terminal = Constants.TERMINAL;
            senderData.Type = 0;
            senderData.Number = 0;
            senderData.CashDrawer = 0;
            senderData.Operator = "";

            svcBody.StoredValueCardReceipt.SenderData = senderData;

            SVCOperationResultViewModel result = await _svcService.Activate(svcBody);

            if (result.ResultStatus == Constants.MSG_RESULT_STATUS_OK)
            {
                model = await _svcService.Status(model.SerialNumber);
            }
            return View("Status", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSvc(int CampaignID, decimal CardValue)
        {
            CreateResultViewModel create = await _svcService.Create(CampaignID, CardValue);
            return View("Create", create);
        }

        [HttpPost]
        public async Task<IActionResult> AssociateSvc(AssociateOperationViewModel model)
        {
            var associate = await _svcService.Associate(model);
            if(associate.ResultCode == Constants.MSG_RESULT_CODE_KO)
            {
                ViewBag["Error"] = associate.ResultMessage;
                return View("Error");
            }
            else
            {
                return View("AssociaCarta", associate);
            }

        }

        [HttpPost]
        public async Task<IActionResult> ChargeSvc(string cardCode, decimal price)
        {

            SVCChargeOperationViewModel svcBody = new SVCChargeOperationViewModel();

            svcBody.StoredValueCardCodeCollection.Add(cardCode);

            svcBody.CashbackType = SVCCashbackType.None;

            Issuer issuer = new Issuer();
            issuer.Name = "Vittorio";
            issuer.Address = "via centomani 11";
            issuer.Telephone = "0000000";
            issuer.EMail = "domec@domecsolutions.com";
            issuer.VATNumber = "222222";

            svcBody.StoredValueCardReceipt.IssuerData = issuer;

            ReceiptProduct receiptProduct = new ReceiptProduct();
            receiptProduct.Code = cardCode;
            receiptProduct.Name = "VittorioCard";
            receiptProduct.Price = price;
            receiptProduct.Quantity = 1;
            receiptProduct.Family = "";
            receiptProduct.Mode = "";

            svcBody.StoredValueCardReceipt.Products.Add(receiptProduct);

            Payment payment = new Payment();
            payment.CardCode = cardCode;

            svcBody.StoredValueCardReceipt.Payments.Add(payment);

            ShopReceipt shopReceipt = new ShopReceipt();
            shopReceipt.IssueDate = DateTime.Now;
            shopReceipt.UserData = "";

            svcBody.StoredValueCardReceipt.IssueDate = DateTime.Now;
            svcBody.StoredValueCardReceipt.UserData = "";

            SenderData senderData = new SenderData();
            senderData.Shop = Constants.SHOP;
            senderData.Terminal = Constants.TERMINAL;
            senderData.Type = 0;
            senderData.Number = 0;
            senderData.CashDrawer = 0;
            senderData.Operator = "";

            svcBody.StoredValueCardReceipt.SenderData = senderData;

            var charge = await _svcService.Charge(svcBody);
            return View("AssociaCarta", charge);
        }


        [HttpPost]
        public async Task<IActionResult> MigrateSvc(string cardCode, string oldCardCode, ShopReceipt shop)
        {

            SVCMigrationOperationViewModel svcBody = new SVCMigrationOperationViewModel();

            svcBody.StoredValueCardCode = cardCode;
            svcBody.OldCardCode = oldCardCode;
            
            Issuer issuer = new Issuer();
            issuer.Name = "Vittorio";
            issuer.Address = "via centomani 11";
            issuer.Telephone = "0000000";
            issuer.EMail = "domec@domecsolutions.com";
            issuer.VATNumber = "222222";

            svcBody.StoredValueCardReceipt.IssuerData = issuer;

            ReceiptProduct receiptProduct = new ReceiptProduct();
            receiptProduct.Code = cardCode;
            receiptProduct.Name = "VittorioCard";
            receiptProduct.Price = 0;
            receiptProduct.Quantity = 1;
            receiptProduct.Family = "";
            receiptProduct.Mode = "";

            svcBody.StoredValueCardReceipt.Products.Add(receiptProduct);

            Payment payment = new Payment();
            payment.CardCode = cardCode;

            svcBody.StoredValueCardReceipt.Payments.Add(payment);

            ShopReceipt shopReceipt = new ShopReceipt();
            shopReceipt.IssueDate = DateTime.Now;
            shopReceipt.UserData = "";

            svcBody.StoredValueCardReceipt.IssueDate = DateTime.Now;
            svcBody.StoredValueCardReceipt.UserData = "";

            SenderData senderData = new SenderData();
            senderData.Shop = Constants.SHOP;
            senderData.Terminal = Constants.TERMINAL;
            senderData.Type = 0;
            senderData.Number = 0;
            senderData.CashDrawer = 0;
            senderData.Operator = "";

            svcBody.StoredValueCardReceipt.SenderData = senderData;

            var migrate = await _svcService.Migrate(svcBody);
            return View("Migrate", migrate);
        }

    }
}