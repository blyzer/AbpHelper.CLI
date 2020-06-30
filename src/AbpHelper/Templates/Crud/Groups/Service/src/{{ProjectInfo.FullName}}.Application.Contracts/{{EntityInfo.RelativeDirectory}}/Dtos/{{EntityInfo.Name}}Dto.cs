using System;
using Volo.Abp.Application.Dtos;

namespace {{ EntityInfo.Namespace }}.Dtos
{
    [Serializable]
    public class {{ EntityInfo.Name }}Dto : {{ EntityInfo.BaseType | string.replace "AggregateRoot" "Entity"}}Dto{{ if EntityInfo.PrimaryKey }}<{{ EntityInfo.PrimaryKey}}>{{ end }}
    {
        {{~ typePrimitive = ["int","object","short","char","float","double","bool","string","sbyte","decimal","uint","long","ulong","ushort","dynamic","Boolean","Byte","Int16","UInt16","Int32","UInt32","Int64","UInt64","Single", "DateTime"] ~}}            
        {{~ for prop in EntityInfo.Properties ~}}        
        {{~ if prop | abp.is_ignore_property; continue; end ~}}
        {{~ if string.ends_with prop.Type ">" ~}}
        public {{ prop.Type | string.replace ">" "Dto>"}} {{ prop.Name }}Dto { get; set; }        
        {{~ else ~}}
        {{~ validateOfPrimite = typePrimitive | array.contains prop.Type ~}}
        {{~ if !validateOfPrimite ~}}        
        public {{ prop.Type }}Dto {{ prop.Name | string.downcase }}Dto { get; set; }
        {{~ else ~}}
        public {{ prop.Type }} {{ prop.Name }} { get; set; }
        {{~ end ~}}
        {{~ end ~}}
        {{~ if !for.last ~}}

        {{~ end ~}}
        {{~ end ~}}
    }
}