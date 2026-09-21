using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MeuSuporte
{
    internal class WinProfileEnergy_State
    {
        // Comando de ver os planos de energia
        //powercfg /list

        // A GUID do plano de energia "Alto desempenho" (High Performance)       
        private static readonly Guid GUID_HIGH_PERFORMANCE = new Guid("8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c");

        // A GUID do plano de energia "Balanceado" (Balanced)
        private static readonly Guid GUID_BALANCED = new Guid("381b4222-f694-41f0-9685-ff5bb260df2e");

        // A GUID do plano de energia "Minima" (SAVER)
        private static readonly Guid GUID_POWER_SAVER = new Guid("a1841308-3541-4fab-bc81-f71556f20b4a");

        // Perfil "Alto desempenho" = 0
        // Perfil "Balanceado" = 1
        // Perfil "Minima" = 2

        [DllImport("powrprof.dll", SetLastError = true)]
        private static extern uint PowerSetActiveScheme(IntPtr UserRootPowerKey, ref Guid SchemeGuid);

        public async Task State(int option)
        {
            if (option == 0) // Simplificado de '== true'
            {
                await PerformChanges(GUID_HIGH_PERFORMANCE, "Alto Desempenho");
            }
            else if (option == 1)
            {
                await PerformChanges(GUID_BALANCED, "Equilibrado");
            }
            else if (option == 2)
            {
                await PerformChanges(GUID_POWER_SAVER, "Economia de Bateria");
            }

            await WinGlobal_UIService.Instance.ProgressBarADD(WinGlobal_UIService.Instance.ValueUniProgressBar);
        }

        private async Task PerformChanges(Guid powerPlanGuid, string choice)
        {
            // O primeiro parâmetro (UserRootPowerKey) deve ser IntPtr.Zero para definir o esquema ativo do utilizador.
            uint resultado = PowerSetActiveScheme(IntPtr.Zero, ref powerPlanGuid);

            if (resultado == 0) // O código de retorno 0 (ERROR_SUCCESS) indica sucesso.
            {
                WinGlobal_UIService.Instance.Sucesso++;
                await WinGlobal_UIService.Instance.AddMessage($"Profile Energy: Ajustando o Plano de Energia para {choice}"); 
            }
            else
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.AddMessage($"Profile Energy: Ocorreu um Erro ao tentar Ajustar o Plano de Energia para {choice}");
            }
        }
    }
}
