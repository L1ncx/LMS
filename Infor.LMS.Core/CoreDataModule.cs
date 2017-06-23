using Autofac;
using Infor.LMS.Data;

namespace Infor.LMS.Core
{
    public class CoreDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.Register(c => new EFContext(this.connStr)).
            //    As<IDbContext>().InstancePerRequest();
            
            builder.RegisterType<LevelRepository>().As<ILevelRepository>().InstancePerRequest();

            base.Load(builder);
        }
    }
}