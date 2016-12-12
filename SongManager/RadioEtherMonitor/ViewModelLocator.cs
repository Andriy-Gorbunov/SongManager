using Ninject;
using Ninject.Modules;
using RadioEtherData;
using RadioEtherData.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioEtherMonitor
{
    public class ViewModelLocator
    {
        private class Bindings : NinjectModule
        {
            public override void Load()
            {
                Bind<MainWindowVM>().ToSelf().InTransientScope();
                Bind<ICountryRepository>().To<CountryRepository>().InSingletonScope();
            }
        }

        private readonly static IKernel kernel;

        static ViewModelLocator()
        {
            kernel = new StandardKernel();
            kernel.Load(new Bindings());
        }

        public MainWindowVM MainWindowVM
        {
            get
            {
                return kernel.Get<MainWindowVM>();
            }
        }
    }
}
