using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MeuSuporte
{
    internal class WinRegistryBackup_FormatRegister
    {
        public async Task<string> Format(RegistryValueKind KeyType, object KeyValue)
        {
            switch (KeyType)
            {
                case RegistryValueKind.String:
                    // Para valores do tipo string, substituímos "\" por "\\" para manter a formatação correta no arquivo .reg.
                    return $"\"{KeyValue.ToString().Replace("\\", "\\\\")}\"";

                case RegistryValueKind.DWord:
                    // Converte valores inteiros para o formato hexadecimal de 8 dígitos, prefixado por "dword:"
                    return $"dword:{((int)KeyValue):X8}";

                case RegistryValueKind.QWord:
                    // Converte valores longos (64 bits) para hexadecimal de 16 dígitos, prefixado por "qword:"
                    return $"qword:{((long)KeyValue):X16}";

                case RegistryValueKind.ExpandString:
                    // Para ExpandString, retorna como uma string normal sem necessidade de conversão especial.
                    return $"\"{KeyValue}\"";

                case RegistryValueKind.Binary:
                    // Converte um array de bytes em formato hexadecimal separado por vírgulas (exemplo: hex:DE,AD,BE,EF).
                    byte[] bytes = (byte[])KeyValue;
                    return "hex:" + BitConverter.ToString(bytes).Replace("-", ",");

                case RegistryValueKind.MultiString:
                    // Para valores MultiString, converte cada string para bytes Unicode, adiciona um separador nulo (0,0)
                    // entre elas e formata em hexadecimal, conforme o padrão do Windows Registry Editor.
                    string[] valores = (string[])KeyValue;
                    return "hex(7):" + string.Join(",", valores
                        .SelectMany(v => Encoding.Unicode.GetBytes(v).Concat(new byte[] { 0, 0 }))
                        .Select(b => b.ToString("X2")));

                default:
                    // Retorna null caso o tipo de valor não seja reconhecido.
                    return null;
            }
        }
    }
}
