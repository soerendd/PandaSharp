using PandaSharp.Bamboo.IoC;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Services.Users.Contract;
using PandaSharp.Bamboo.Services.Users.Factory;
using PandaSharp.Bamboo.Services.Users.Request;
using PandaSharp.Bamboo.Utils;

namespace PandaSharp.Bamboo.Services.Users
{
    internal sealed class UsersModule : IPandaContextModule
    {
        public void RegisterModule(IPandaContainer container, PandaContainerContext context)
        {
            container
                .RequestRegistrationFor<IGetCurrentUserRequest>()
                .LatestRequest<GetCurrentUserRequest>()
                .Register(context);

            container.RegisterType<IUsersRequestBuilderFactory, UsersRequestBuilderFactory>();
        }
    }
}