rmdir /s /q CoverageReport
rmdir /s /q TestResults
dotnet test --collect:"XPlat Code Coverage"
reportgenerator -reports:TestResults/**/coverage.cobertura.xml -targetdir:CoverageReport -classfilters:+AngielskiNauka.Unit.AngService

