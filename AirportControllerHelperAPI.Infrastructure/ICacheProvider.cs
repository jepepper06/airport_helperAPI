using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportControllerHelperAPI.Infrastructure;

public interface ICacheProvider
{
    T? Get<T>(string key);
    bool Set<T>(string key, T value);
    bool Delete(string key);
}
