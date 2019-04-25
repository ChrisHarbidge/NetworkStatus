# Remap the dependencies output when publishing the NetworkStatus.Node project for linux-arm
# Currently a workaround as visual studio always outputs a relative library path for dependencies (which never seems to be generated)

$filePath = 'C:\Users\cjhar\source\repos\NetworkStatus\NetworkStatus.Node\bin\Release\netcoreapp2.2\linux-arm\NetworkStatus.Node.deps.json'
$dependencyFolder = '/home/chris/netcoreapp2.2/publish/'
(gc $filePath) -replace 'lib/netcoreapp2.0/',$dependencyFolder | sc $filePath
(gc $filePath) -replace 'lib/netstandard2.0/',$dependencyFolder | sc $filePath
(gc $filePath) -replace 'runtimes/linux-arm/lib/netcoreapp2.2/',$dependencyFolder | sc $filePath
(gc $filePath) -replace 'runtimes/linux-arm/native/',$dependencyFolder | sc $filePath


$runtimeConfigContents = '{
  "runtimeOptions": {
    "additionalProbingPaths": [
      "/home/chris/netcoreapp2.2/publish/"
    ]
  }
}'

sc -Path 'C:\Users\cjhar\source\repos\NetworkStatus\NetworkStatus.Node\bin\Release\netcoreapp2.2\linux-arm\NetworkStatus.Node.runtimeconfig.dev.json' -Value $runtimeConfigContents
sc -Path 'C:\Users\cjhar\source\repos\NetworkStatus\NetworkStatus.Node\bin\Release\netcoreapp2.2\linux-arm\NetworkStatus.Node.runtimeconfig.json' -Value $runtimeConfigContents
