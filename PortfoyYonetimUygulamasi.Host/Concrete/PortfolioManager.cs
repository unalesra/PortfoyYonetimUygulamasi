﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfoyYonetimUygulamasi.Data.Abstract;
using PortfoyYonetimUygulamasi.Entity.Concrete;
using PortfoyYonetimUygulamasi.Entity.Dtos;
using PortfoyYonetimUygulamasi.Host.Abstract;

namespace PortfoyYonetimUygulamasi.Host.Concrete
{
    public class PortfolioManager : IPortfolioService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWalletService _walletService;

        public PortfolioManager(IUnitOfWork unitOfWork, IWalletService walletService)
        {
            _unitOfWork = unitOfWork;
            _walletService = walletService;
        }


        public async Task AddPortfolio(CreatePortfolioDto createPortfolioDto)
        {
            Portfolio portfolio = new Portfolio
            {
                PortfolioName = createPortfolioDto.PortfolioName,
                UserId = createPortfolioDto.UserId,
                IsActive = true,
                IsDeleted = false
            };

            await _unitOfWork.Portfolios.AddAsync(portfolio);
            await _unitOfWork.SaveAsync();
  
            int createdPortfolioId = portfolio.Id;
            int createdWalletId = await _walletService.InitialWalletCreate(createdPortfolioId); //her portföyün bir wallet ı olacağı için portföy oluşturulurken wallet da oluşturuluyor
            var portfolios = await _unitOfWork.Portfolios.GetAllAsync(x => x.Id == createdPortfolioId);
            var createdPortfolio = portfolios.FirstOrDefault();
            createdPortfolio.WalletId = createdWalletId;
            _unitOfWork.Portfolios.DetachEntity();
            Portfolio portfolioss = new Portfolio
            {
                PortfolioName = createPortfolioDto.PortfolioName,
                UserId = createPortfolioDto.UserId,
                IsActive = true,
                IsDeleted = false,
                WalletId = createdPortfolio.WalletId,
                Id= createdPortfolio.Id
            };
            await _unitOfWork.Portfolios.UpdateAsync(portfolioss);
            await _unitOfWork.SaveAsync();
        }
        public async Task<List<Portfolio>> GetAllUserPortfolios(int userId)
        {
            var result = await _unitOfWork.Portfolios.GetAllAsync(a => a.UserId == userId);
            return result.ToList();
        }
        public async Task<List<Portfolio>> GetUserPortfolio(int portfolioId)
        {
            var result = await _unitOfWork.Portfolios.GetAllAsync(a => a.Id == portfolioId);
            return result.ToList();
        }
    }
}
