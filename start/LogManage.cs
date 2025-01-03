using System.Configuration;
using System.IO;
using Serilog;

namespace wpf_example.start;

public static class LogManage
{
    public static void LogStart()
    {
        string logDirectory  = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
        
        // 初始化 Serilog，配置日志输出到控制台和文件
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug() // 设置日志的最低级别（可以是 Verbose, Debug, Information, Warning, Error, Fatal）
            .WriteTo.Console() // 输出到控制台
            .WriteTo.File(Path.Combine(logDirectory, "Information-.txt"), 
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information, 
                rollingInterval: RollingInterval.Day) // 输出信息级别日志到文件
            .WriteTo.File(Path.Combine(logDirectory, "Warning-.txt"), 
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning, 
                rollingInterval: RollingInterval.Day) // 输出警告级别日志到文件
            .WriteTo.File(Path.Combine(logDirectory, "Error-.txt"), 
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error, 
                rollingInterval: RollingInterval.Day) // 输出错误级别日志到文件
            .CreateLogger(); // 创建 Logger 实例

        // 记录一些示例日志
        Log.Information("Application starting...");
        Log.Debug("This is a debug message.");
        Log.Warning("This is a warning message.");
        Log.Error("This is an error message.");
        Log.Fatal("This is a fatal error message.");
    }
}