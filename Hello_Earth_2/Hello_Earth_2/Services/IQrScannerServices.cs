using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Earth_2.Services
{
    public interface IQrScannerServices
    {
        Task<string> GetScan();
    }
}
