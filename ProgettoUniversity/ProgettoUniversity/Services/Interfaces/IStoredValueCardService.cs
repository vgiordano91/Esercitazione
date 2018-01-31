using Microsoft.AspNetCore.Mvc;
using ProgettoUniversity.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoUniversity.Services.Interfaces
{
    public interface IStoredValueCardService
    {
        Task<SVCOperationResultViewModel> Activate(SVCOperationViewModel model);
        Task<CreateResultViewModel> Create(int campaignID, decimal amount);
        Task<CardDetailViewModel> Status(string cardCode);
        Task<CardDetailViewModel> Balance(string cardCode);
        Task<CardDetailViewModel> Transactions(string cardCode);
        Task<SVCResultViewModel> Associate(AssociateOperationViewModel model);
        Task<SVCResultViewModel> Charge(SVCChargeOperationViewModel model);
        Task<SVCResultViewModel> Migrate(SVCMigrationOperationViewModel model);
    }
}
