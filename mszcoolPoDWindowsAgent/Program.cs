﻿using System;

/// <summary>
/// Should support the following actions:
/// - wake up physical hosts with WoL magic packet
/// - reboot physical host
/// - shutdown physical host
/// - start HyperV VM
/// - stop HyperV VM
/// - retrieve list of available HyperV VMs
/// - get status details
///   - CPU usage
///   - Memory usage
///   - List of processes and services
/// - register a PowerShell script as an "allowed" task
/// - execute an "allowed" task previously registered
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}