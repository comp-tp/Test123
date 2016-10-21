using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.APIHandlers
{
    public class AsyncLongTimeTester
    {
        public static async Task<string> ProcessAsync(int time)
        {
            return await Task.Delay(time).ContinueWith(t => {
                return "long time passed";
            });
        }
    }
}
