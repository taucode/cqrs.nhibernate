dotnet restore

dotnet build --configuration Debug
dotnet build --configuration Release

dotnet test -c Debug .\test\TauCode.Cqrs.NHibernate.Tests\TauCode.Cqrs.NHibernate.Tests.csproj
dotnet test -c Release .\test\TauCode.Cqrs.NHibernate.Tests\TauCode.Cqrs.NHibernate.Tests.csproj

nuget pack nuget\TauCode.Cqrs.NHibernate.nuspec
