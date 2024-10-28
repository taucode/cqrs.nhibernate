dotnet restore

dotnet build TauCode.Cqrs.NHibernate.sln -c Debug
dotnet build TauCode.Cqrs.NHibernate.sln -c Release

dotnet test TauCode.Cqrs.NHibernate.sln -c Debug
dotnet test TauCode.Cqrs.NHibernate.sln -c Release

nuget pack nuget\TauCode.Cqrs.NHibernate.nuspec