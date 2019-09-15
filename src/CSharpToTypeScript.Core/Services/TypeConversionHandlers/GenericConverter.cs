using System.Linq;
using CSharpToTypeScript.Core.Models.TypeNodes;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpToTypeScript.Core.Services.TypeConversionHandlers
{
    public class GenericConverter : TypeConversionHandler
    {
        private readonly TypeConversionHandler _converter;

        public GenericConverter(TypeConversionHandler converter)
        {
            _converter = converter;
        }

        public override ITypeNode Handle(TypeSyntax type)
        {
            if (type is GenericNameSyntax generic)
            {
                return new Generic(
                    name: generic.Identifier.Text,
                    arguments: generic.TypeArgumentList.Arguments.Select(_converter.Handle));
            }

            return base.Handle(type);
        }
    }
}