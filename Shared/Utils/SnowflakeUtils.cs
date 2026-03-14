namespace TangyuanBackendASP.Shared.Utils;

public static class SnowflakeUtils
{
    // 雪花ID结构：1位符号位 + 41位时间戳 + 5位数据中心ID + 5位机器ID + 12位序列号
    // 常量定义
    private const long Epoch = 1577836800000L; // 2020-01-01 00:00:00 UTC，作为起始时间
    private const int TimestampBits = 41;
    private const int DataCenterIdBits = 5;
    private const int MachineIdBits = 5;
    private const int SequenceBits = 12;

    // 最大取值计算
    private const long MaxDataCenterId = -1L ^ (-1L << DataCenterIdBits); // 31
    private const long MaxMachineId = -1L ^ (-1L << MachineIdBits); // 31
    private const long MaxSequence = -1L ^ (-1L << SequenceBits); // 4095

    // 移位偏移计算
    private const int DataCenterIdShift = MachineIdBits + SequenceBits; // 17
    private const int MachineIdShift = SequenceBits; // 12
    private const int TimestampShift = DataCenterIdBits + MachineIdBits + SequenceBits; // 22

    // 静态变量
    private static long _lastTimestamp = -1L;
    private static long _sequence = 0L;
    private static readonly object _lock = new object(); // 锁对象，保证线程安全
    
    // 机器ID和数据中心ID（实际生产环境中应根据部署环境配置）
    private static readonly long _machineId;
    private static readonly long _dataCenterId;

    // 静态构造函数，初始化机器ID和数据中心ID
    static SnowflakeUtils()
    {
        // 这里可以从配置文件、环境变量或机器信息中获取，示例中使用默认值
        _machineId = 0;
        _dataCenterId = 0;

        // 验证参数有效性
        if (_machineId > MaxMachineId || _machineId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(_machineId), $"机器ID必须在0到{MaxMachineId}之间");
        }
        if (_dataCenterId > MaxDataCenterId || _dataCenterId < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(_dataCenterId), $"数据中心ID必须在0到{MaxDataCenterId}之间");
        }
    }

    /// <summary>
    /// 生成雪花ID
    /// </summary>
    /// <returns>雪花ID</returns>
    public static long GenerateSnowflakeId()
    {
        lock (_lock)
        {
            long currentTimestamp = GetCurrentTimestamp();

            // 处理时钟回拨问题
            if (currentTimestamp < _lastTimestamp)
            {
                throw new Exception($"时钟回拨检测到：当前时间{currentTimestamp}，上次时间{_lastTimestamp}");
            }

            // 如果是同一时间戳，序列号递增
            if (currentTimestamp == _lastTimestamp)
            {
                _sequence = (_sequence + 1) & MaxSequence;
                // 如果序列号达到最大值，等待下一个毫秒
                if (_sequence == 0)
                {
                    currentTimestamp = WaitForNextTimestamp(_lastTimestamp);
                }
            }
            else
            {
                // 新的时间戳，序列号重置为0
                _sequence = 0;
            }

            // 更新上次时间戳
            _lastTimestamp = currentTimestamp;

            // 组合雪花ID：时间戳 << 22 | 数据中心ID << 17 | 机器ID << 12 | 序列号
            long snowflakeId = ((currentTimestamp - Epoch) << TimestampShift) |
                               (_dataCenterId << DataCenterIdShift) |
                               (_machineId << MachineIdShift) |
                               _sequence;

            return snowflakeId;
        }
    }

    /// <summary>
    /// 获取当前时间戳（毫秒）
    /// </summary>
    /// <returns>当前时间戳</returns>
    private static long GetCurrentTimestamp()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    /// <summary>
    /// 等待到下一个毫秒
    /// </summary>
    /// <param name="lastTimestamp">上次时间戳</param>
    /// <returns>新的时间戳</returns>
    private static long WaitForNextTimestamp(long lastTimestamp)
    {
        long timestamp = GetCurrentTimestamp();
        while (timestamp <= lastTimestamp)
        {
            timestamp = GetCurrentTimestamp();
        }
        return timestamp;
    }

    /// <summary>
    /// 解析雪花ID
    /// </summary>
    /// <param name="snowflakeId">雪花ID</param>
    /// <returns>解析后的雪花ID信息</returns>
    public static SnowflakeIdInfo ParseSnowflakeId(long snowflakeId)
    {
        long timestamp = (snowflakeId >> TimestampShift) + Epoch;
        long dataCenterId = (snowflakeId >> DataCenterIdShift) & MaxDataCenterId;
        long machineId = (snowflakeId >> MachineIdShift) & MaxMachineId;
        long sequence = snowflakeId & MaxSequence;

        return new SnowflakeIdInfo
        {
            SnowflakeId = snowflakeId,
            Timestamp = timestamp,
            DateTime = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).UtcDateTime,
            DataCenterId = dataCenterId,
            MachineId = machineId,
            Sequence = sequence
        };
    }
}

/// <summary>
/// 雪花ID解析信息
/// </summary>
public class SnowflakeIdInfo
{
    /// <summary>
    /// 雪花ID
    /// </summary>
    public long SnowflakeId { get; set; }

    /// <summary>
    /// 时间戳（毫秒）
    /// </summary>
    public long Timestamp { get; set; }

    /// <summary>
    /// 生成时间
    /// </summary>
    public DateTime DateTime { get; set; }

    /// <summary>
    /// 数据中心ID
    /// </summary>
    public long DataCenterId { get; set; }

    /// <summary>
    /// 机器ID
    /// </summary>
    public long MachineId { get; set; }

    /// <summary>
    /// 序列号
    /// </summary>
    public long Sequence { get; set; }

    /// <summary>
    /// 重写ToString方法，方便查看雪花ID信息
    /// </summary>
    /// <returns>雪花ID信息字符串</returns>
    public override string ToString()
    {
        return $"SnowflakeId: {SnowflakeId}, DateTime: {DateTime:yyyy-MM-dd HH:mm:ss.fff} UTC, DataCenterId: {DataCenterId}, MachineId: {MachineId}, Sequence: {Sequence}";
    }
}