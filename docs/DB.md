# Benchmarking Guide

## Introduction

Benchmarking is the process of running a set of standard tests to evaluate the performance of hardware, software, or systems. It helps in identifying bottlenecks, measuring the impact of changes, and ensuring that systems meet performance requirements. 

This guide focuses on disk benchmarking using `DiskSpd` on Windows and Linux, and provides an overview of tools for benchmarking popular databases such as SQL Server, MySQL, and PostgreSQL.

## Getting Started

### Why Benchmark?

1. **Understand System Performance**: To get a quantitative understanding of the system's performance characteristics.
2. **Identify Bottlenecks**: Find out which components (CPU, Memory, Disk, Network) are limiting performance.
3. **Verify Changes**: Ensure that optimizations or upgrades have the intended performance impact.
4. **Capacity Planning**: Plan for future capacity by understanding current limits.

### Tools Overview

- **DiskSpd**: A powerful disk performance testing tool that works on both Windows and Linux.
- **Database Benchmarking Tools**:
  - **SQL Server**: `SQLQueryStress`, `HammerDB`
  - **MySQL**: `sysbench`, `MySQL Benchmark Suite`
  - **PostgreSQL**: `pgbench`, `pgBadger`

## Hints for Effective Benchmarking

- **Define Clear Objectives**: Understand what you want to measure (e.g., throughput, latency).
- **Use Realistic Scenarios**: Benchmark under conditions that reflect real-world usage.
- **Isolate Tests**: Ensure that other processes do not interfere with the benchmarking.
- **Repeat Tests**: Perform multiple runs to account for variability and obtain reliable data.
- **Document the Environment**: Record the configuration details (hardware, software, network) to ensure reproducibility.

## Example: DiskSpd Benchmarking

### DiskSpd on Windows

1. **Download and Install DiskSpd**: 
   - Visit the [DiskSpd GitHub repository](https://github.com/microsoft/diskspd) and download the latest release.
   - Extract the files to a suitable location.

2. **Basic Usage Example**:
   ```bash
   diskspd.exe -d60 -w30 -r -o32 -t4 -b64K -Sh C:\testfile.dat
   ```
- -d60: Duration of the test in seconds (60 seconds).
- -w30: Percentage of writes (30% writes, 70% reads).
- -r: Random I/O.
- -o32: Number of outstanding I/O requests.
- -t4: Number of threads.
- -b64K: Block size (64 KB).
- -Sh: Disable software and hardware caching.

## Analyze Results:
Review the output to analyze IOPS (Input/Output Operations Per Second), throughput, and latency metrics.

### DiskSpd on Linux
Install DiskSpd via WSL:

If using Windows Subsystem for Linux (WSL), you can compile and use DiskSpd within the WSL environment.
Running DiskSpd in WSL:

Download the source code from the DiskSpd GitHub repository and compile it:
```bash
Copy code
sudo apt update
sudo apt install build-essential
git clone https://github.com/microsoft/diskspd
cd diskspd
make
```
Use similar commands as for Windows to run benchmarks.
Tools to Benchmark SQL Databases
## SQL Server
### SQLQueryStress:

A simple tool to simulate multiple SQL queries running in parallel.
Useful for stress testing stored procedures or complex queries.

### HammerDB:

A comprehensive benchmarking tool that supports SQL Server, Oracle, MySQL, and PostgreSQL.
Provides built-in TPC-C and TPC-H workloads to simulate OLTP and OLAP environments.

## MySQL
### sysbench:

A versatile benchmarking tool that supports CPU, memory, threads, and file I/O performance.
Commonly used for MySQL benchmarking by generating load against a MySQL server.

### MySQL Benchmark Suite:

A collection of scripts to measure the performance of MySQL server under different workloads.
Includes tests for read, write, and mixed read/write scenarios.

## PostgreSQL
### pgbench:

A built-in benchmarking tool for PostgreSQL that can simulate multiple clients and transactions.
Allows custom scripts to test specific SQL scenarios.
Run it directly from the PostgreSQL installation:
```bash
Copy code
pgbench -i -s 10 mydatabase  # Initialize with scale factor 10
pgbench -c 10 -j 2 -T 60 mydatabase  # Run with 10 clients, 2 threads, for 60 seconds
```

### pgBadger:

A fast log analyzer for PostgreSQL that can generate detailed reports on performance.
Useful for understanding slow queries and performance bottlenecks.
Learn more about pgBadger
