using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Shared.Utils;

namespace TangyuanBackendASP.Infra.Services;

public class SnowflakeIdGenerator : IIdGenerator
{
    public long NextId()
    {
        return SnowflakeUtils.GenerateSnowflakeId();
    }
}