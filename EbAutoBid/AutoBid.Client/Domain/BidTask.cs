using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoBid.Client.Domain
{
    class BidTask
    {
        private Thread threadAutoBid;
        private bool _isAutoBid = false;
        private readonly Bidder bidder = new Bidder { };

        public void StartBid()
        {
            if (threadAutoBid == null)
            {
                threadAutoBid = new Thread(AutoBidTask);
                threadAutoBid.IsBackground = true;
                threadAutoBid.Start(null);
            }
            _isAutoBid = true;
        }

        public void AutoBidTask(object state)
        {
            CartSearcher searcher = new CartSearcher();
            while (true)
            {
                if (_isAutoBid)
                {
                    var products = searcher.Search();
                    foreach (var product in products)
                    {
                        if (product.IsOwn)
                        {
                            continue;
                        }
                        int num = product.CurrentPrice + 10;
                        bidder.AutoBid(product.IdResoTemp, num);
                    }
                }
                Thread.Sleep(100);
            }
        }

        public void Pause()
        {
            _isAutoBid = false;
        }
    }
}
