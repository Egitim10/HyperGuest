using HyperGuests.ModelRequests;
using HyperGuests.ModelResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperGuests.IServices
{
    public interface IHyperGuestClient
    {
        Task<string> CheckRequestGetJsonStringAsync(CheckRequest checkDTO);
        Task<RootObject?> CheckRequestGetResponseOObjectAsync(CheckRequest checkDTO);
    }
}
