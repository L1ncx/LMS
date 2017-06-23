using Autofac;
using Autofac.Integration.Mvc;
using Infor.LMS.Core;


namespace Infor.LMS.Web
{
    public class DataModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LevelService>().As<ILevelService>().InstancePerRequest();

            base.Load(builder);
        }

    }
}