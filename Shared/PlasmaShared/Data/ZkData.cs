using System;
using System.Data;
using System.Data.Linq;
using System.IO;
using System.Web;
using JetBrains.Annotations;
using PlasmaShared.Properties;

namespace ZkData
{
	partial class ZkDataContext
	{
#if DEBUG
        //private static string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=zero-k-dev;Integrated Security=True";
        private static string ConnectionString = @"Data Source=omega.licho.eu,100;Initial Catalog=zero-k;Persist Security Info=True;User ID=zero-k;Password=zkdevpass1";
#else 
        private static string ConnectionString= Settings.Default.zero_kConnectionString;

#endif

        private static bool WasDbChecked = false;
        private static object locker = new object();

        public static Action<ZkDataContext> DataContextCreated = context => { };

        public ZkDataContext() : base(ConnectionString) {
#if DEBUG
            if (!WasDbChecked)
            {
                lock (locker)
                {
                    if (!DatabaseExists()) CreateDatabase();
                    WasDbChecked = true;
                }
            }
#endif
            DataContextCreated(this);
        }
	}
}
