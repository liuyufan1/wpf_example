﻿using System.Configuration;
using System.Data;
using System.Windows;
using wpf_example.start;

namespace wpf_example;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        LogManage.LogStart();
    }
}