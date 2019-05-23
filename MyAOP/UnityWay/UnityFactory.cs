using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace MyAOP.UnityWay
{
    public class UnityFactory
    {
        #region Singleton

        private static UnityFactory _Singleton = null;
        private UnityFactory()
        {

        }
        static UnityFactory()
        {
            _Singleton = new UnityFactory();
        }

        #endregion

        public static UnityFactory Instance => _Singleton;

        public IUnityContainer ICreateContainer(string containerConfigure = "aopContainer")
        {
            //配置UnityContainer
            IUnityContainer container = new UnityContainer();
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            UnityConfigurationSection configSection = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            configSection.Configure(container, containerConfigure);
            return container;
        }
    }
}
