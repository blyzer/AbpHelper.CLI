{{- SKIP_GENERATE = EntityInfo.CompositeKeyName == null -}}
namespace {{ EntityInfo.Namespace }}.Dtos
{
    public class {{ EntityInfo.CompositeKeyName }}
    {
        {{~ for prop in EntityInfo.CompositeKeys ~}}
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