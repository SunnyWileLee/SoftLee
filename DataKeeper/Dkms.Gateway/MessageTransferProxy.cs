using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dkms.Tools.Net;

namespace Dkms.Gateway
{
    class MessageTransferProxy : IMessageTransferProxy
    {
        private readonly IMessageTransfer[] _messageTransfers;

        public MessageTransferProxy(IMessageTransfer[] messageTransfers)
        {
            _messageTransfers = messageTransfers;
        }

        public ApiResult Transger(string url, HttpRequestMessage request)
        {
            var transfer = _messageTransfers.FirstOrDefault(s => s.Method == request.Method);
            return transfer.Transfer(url, request);
        }

        public async Task<ApiResult> TransgerAsync(string url, HttpRequestMessage request)
        {
            var transfer = _messageTransfers.FirstOrDefault(s => s.Method == request.Method);
            return await transfer.TransferAsync(url, request);
        }
    }
}
