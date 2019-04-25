# NetworkStatus

A set of ASP Dotnet Core and Dotnet Core Console application projects to allow continuous monitoring and status publishing of server nodes on a network.

## ASP Dotnet Core Server

The server project `NetworkStatus` is a simple CRUD application for various nodes to communicate with, pushing their current status.
Future plans involve having a live updating dashboard, and potentially pro-active notifications/alerts when significant status changes are noticed.

## Dotnet Core Console Application

The console application `NetworkStatus.Node` is designed to gather as much information about the machine it is running on as possible.
This information is polled at intervals and pushed to the server.
