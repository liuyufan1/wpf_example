using System.Configuration;
using Serilog;

namespace wpf_example.start;

public class LogManage
{
    public static void LogStart()
    {
        string logPosition = ConfigurationManager.AppSettings["logPosition"]??"";
        if(logPosition == "")
            Console.WriteLine("未配置log保存位置");
        
        // 初始化 Serilog，配置日志输出到控制台和文件
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug() // 设置日志的最低级别（可以是 Verbose, Debug, Information, Warning, Error, Fatal）
            .WriteTo.Console() // 输出到控制台
            .WriteTo.File(logPosition, rollingInterval: RollingInterval.Day) // 输出到文件，每天生成一个新的日志文件
            .CreateLogger(); // 创建 Logger 实例

        // 记录一些示例日志
        Log.Information("Application starting...");
        Log.Debug("This is a debug message.");
        Log.Warning("This is a warning message.");
        Log.Error("This is an error message.");
        Log.Fatal("This is a fatal error message.");
    }
}