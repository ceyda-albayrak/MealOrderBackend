using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Abstract.DapService;
using Business.Abstract.EfService;
using Business.Abstracts;
using Business.Abstracts.DapService;
using Business.Abstracts.EfService;
using Business.Concrete;
using Business.Concrete.EfManager;
using Business.Concretes;
using Business.Concretes.EfManager;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstracts;
using DataAccess.Abstracts.DapDal;
using DataAccess.Concretes;
using DataAccess.Concretes.Dapper;
using DataAccess.Concretes.EntityFramework;
using Entities;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DapCategoryManager>().As<IDapCategoryService>();
            builder.RegisterType<DapCategoryDal>().As<IDapCategoryDal>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<DapOrderDetailManager>().As<IDapOrderDetailService>();
            builder.RegisterType<DapOrderDetailDal>().As<IDapOrderDetailDal>();
            builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>();
            builder.RegisterType<EfOrderDetailDal>().As<IOrderDetailDal>();

            builder.RegisterType<DapOrderManager>().As<IDapOrderService>();
            builder.RegisterType<DapOrderDal>().As<IDapOrderDal>();
            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();

            builder.RegisterType<DapProductManager>().As<IDapProductService>();
            builder.RegisterType<DapProductDal>().As<IDapProductDal>();
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<DapRegionManager>().As<IDapRegionService>();
            builder.RegisterType<DapRegionDal>().As<IDapRegionDal>();
            builder.RegisterType<RegionManager>().As<IRegionService>();
            builder.RegisterType<EfRegionDal>().As<IRegionDal>();

            builder.RegisterType<DapRestaurantInfoManager>().As<IDapRestaurantInfoService>();
            builder.RegisterType<DapRestaurantInfoDal>().As<IDapRestaurantInfoDal>();
            builder.RegisterType<RestaurantInfoManager>().As<IRestaurantInfoService>();
            builder.RegisterType<EfRestaurantInfoDal>().As<IRestaurantInfoDal>();

            builder.RegisterType<DapUserInfoManager>().As<IDapUserInfoService>();
            builder.RegisterType<DapUserInfoDal>().As<IDapUserInfoDal>();
            builder.RegisterType<UserInfoManager>().As<IUserInfoService>();
            builder.RegisterType<EfUserInfoDal>().As<IUserInfoDal>();

            builder.RegisterType<DapUserManager>().As<IDapUserService>();
            builder.RegisterType<DapUserDal>().As<IDapUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<DapAuthManager>().As<IDapAuthService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
           


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
