using System;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MeuSuporte
{
    internal class WinRestorePoint_IsSystemRestoreEnabled
    {
        public async Task<bool> IsSystemRestoreEnabledAsync()
        {
            return await Task.Run(async () =>
            {
                bool ServicoHabilitado = false;
                string registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\SystemRestore";
                string valueName = "RPSessionInterval";

                try
                {
                    using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(registryPath))
                    {
                        if (key != null)
                        {
                            object value = key.GetValue(valueName);
                            if (value != null && value is int intValue)
                            {
                                ServicoHabilitado = (intValue == 1);
                            }
                        }
                        else
                        {
                            await WinGlobal_UIService.Instance.Log_MensagemAsync($"Proteção do Sistema: Não foi possivel verificar se esta Habilitado Proteção do Sistema", true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    await WinGlobal_UIService.Instance.Log_MensagemAsync($"Proteção do Sistema: Não foi possivel verificar se esta Habilitado Proteção do Sistema", true);
                }
                return ServicoHabilitado;
            });
        }


        //Verifica se o Serviço esta Habilitado
        //DisableSR = 1 desabilita a criação de pontos de restauração.
        //DisableConfig = 1 desabilita a configuração de pontos de restauração.
        //RPSessionInterval = Controla o intervalo entre os pontos de restauração criados pelo usuário.
        //RPLifeInterval = Controla a duração dos pontos de restauração criados pelo usuário.
        //SystemRestorePointCreationFrequency = Controla com que frequência o Windows pode criar pontos automaticamente. Por exemplo, 1440 = 1 ponto a cada 24 horas.

    }
}
