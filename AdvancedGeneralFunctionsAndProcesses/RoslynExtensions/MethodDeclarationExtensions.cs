using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CommonRoslynNetStandardHelpers.AdvancedGeneralFunctionsAndProcesses.RoslynExtensions;

public static class MethodDeclarationExtensions
{
    extension(MethodDeclarationSyntax node)
    {
        public string Name => node.Identifier.Text;
    }
}