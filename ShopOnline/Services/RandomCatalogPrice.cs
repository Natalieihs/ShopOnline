using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
    /// <summary>
    /// 随机价格生成类
    /// </summary>
    public class RandomCatalogPriceService
    {
        private readonly object _stateLock = new object();
        private readonly object _updateCataItemPricesLock = new object();
        private readonly IHubContext<NotifyHub> _hubContext;
        private readonly double _rangePercent = 0.02;
        private readonly ConcurrentDictionary<int, CatalogItemViewModel> _cataItems = new ConcurrentDictionary<int, CatalogItemViewModel>();
        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(2500);
        private readonly Random _updateOrNotRandom = new Random();
        private readonly ICatalogViewModelService _catalogViewModelService;
        private Timer _timer;
        private volatile bool _updatingCataItemPrices;

        public RandomCatalogPriceService(ICatalogViewModelService catalogViewModelService, IHubContext<NotifyHub> hubContext)
        {
            _catalogViewModelService = catalogViewModelService;
            _hubContext = hubContext;
            LoadDefaultCataItems();
        }
        public void LoadDefaultCataItems()
        {
            _cataItems.Clear();
            var catalogModel = _catalogViewModelService.GetCatalogItems(0, Constants.ITEMS_PER_PAGE, null, null).GetAwaiter().GetResult();
            catalogModel.CatalogItems.ForEach(item => _cataItems.TryAdd(item.Id, item));
        }

        public void Start()
        {
            if (_updatingCataItemPrices == false)
            {
                _timer = new Timer(UpdateCataItemPrices, null, _updateInterval, _updateInterval);
            }
        }
        private void UpdateCataItemPrices(object state)
        {
            lock (_updateCataItemPricesLock)
            {
                if (!_updatingCataItemPrices)
                {
                    _updatingCataItemPrices = true;
                    List<CatalogItemViewModel> CataItemPriceChangedList = new List<CatalogItemViewModel>();
                    foreach (var item in _cataItems.Values)
                    {
                        if (TryUpdateCataItemPrice(item))
                        {
                            CataItemPriceChangedList.Add(item);
                        }
                    }

                    if (CataItemPriceChangedList.Any())
                    {
                        _hubContext.Clients.All.SendAsync("OnCataItemPriceChanged", CataItemPriceChangedList);
                    }
                    _updatingCataItemPrices = false;
                }
            }
        }

        private bool TryUpdateCataItemPrice(CatalogItemViewModel CataItem)
        {
            var r = _updateOrNotRandom.NextDouble();
            if (r > 55.5)
            {
                return false;
            }

            var random = new Random((int)Math.Floor(CataItem.Price));
            var percentChange = random.NextDouble() * _rangePercent;
            var pos = random.NextDouble() > 0.51;
            var change = Math.Round(CataItem.Price * (decimal)percentChange, 2);
            change = pos ? change : -change;
            CataItem.Price += change;
            return true;
        }
    }
}
