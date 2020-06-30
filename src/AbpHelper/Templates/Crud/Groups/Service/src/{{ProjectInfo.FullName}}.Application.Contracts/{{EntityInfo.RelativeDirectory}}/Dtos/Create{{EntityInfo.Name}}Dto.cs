{{- SKIP_GENERATE = !Option.SeparateDto -}}
using System;
{{~ if !Option.SkipLocalization }}using System.ComponentModel;{{ end ~}}

namespace {{ EntityInfo.Namespace }}.Dtos
{
    [Serializable]
    public class Create{{ EntityInfo.Name }}Dto
    {
        {{~ typePrimitive = ["int","object","short","char","float","double","bool","string","sbyte","decimal","uint","long","ulong","ushort","dynamic","Boolean","Byte","Int16","UInt16","Int32","UInt32","Int64","UInt64","Single", "DateTime"] ~}}
        {{~ for prop in EntityInfo.Properties ~}}
        {{~ if prop | abp.is_ignore_property; continue; end ~}}
        {{~ if !Option.SkipLocalization && Option.SkipViewModel ~}}
        [DisplayName("{{ EntityInfo.Name + prop.Name}}")]
        {{~ end ~}}
        {{~ if string.ends_with prop.Type ">" ~}}
        public {{ prop.Type | string.replace ">" "Dto>"}} {{ prop.Name }}Dto { get; set; }        
        {{~ else ~}}
        {{~ validateOfPrimite = typePrimitive | array.contains prop.Type ~}}
        {{~ if !validateOfPrimite ~}}        
        public Create{{ prop.Type }}Dto create{{ prop.Name }}Dto { get; set; }
        {{~ else ~}}
        public {{ prop.Type }} {{ prop.Name }} { get; set; }
        {{~ end ~}}
        {{~ end ~}}
        {{~ if !for.last ~}}

        {{~ end ~}}
        {{~ end ~}}
    }
}