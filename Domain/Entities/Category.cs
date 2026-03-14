using Microsoft.EntityFrameworkCore;
using TangyuanBackendASP.Shared.Utils;

namespace TangyuanBackendASP.Domain.Entities;

/// <summary>
/// 领域
/// </summary>
public class Category
{
    private Category()
    {
    }

    public Category(string name, string description)
    {
        CategoryId = SnowflakeUtils.GenerateSnowflakeId();
        Name = name;
        Description = description;
    }


    public long CategoryId { get; private set; }

    /// <summary>
    /// 领域名
    /// </summary>
    public string Name { get; private set; } = null!;


    /// <summary>
    /// 领域描述
    /// </summary>
    public string Description { get; private set; } = null!;
}