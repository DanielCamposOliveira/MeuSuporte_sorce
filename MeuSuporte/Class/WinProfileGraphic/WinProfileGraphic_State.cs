using Microsoft.Win32;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MeuSuporte.Class.WinProfileGraphic
{
    internal class WinProfileGraphic_State
    {
        // Importa funções da API do Windows
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SendNotifyMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        // Constantes da API
        private const uint SPI_SETFONTSMOOTHING = 0x004B;
        private const uint SPI_SETCLIENTAREAANIMATION = 0x1043;
        private const uint SPI_SETMENUANIMATION = 0x1003;
        private const uint SPI_SETSELECTIONFADE = 0x1015;
        private const uint SPI_SETTOOLTIPANIMATION = 0x1017;
        private const uint SPI_SETDROPSHADOW = 0x1025;
        private const uint SPI_SETDRAGFULLWINDOWS = 0x0025;

        private const uint SPIF_UPDATEINIFILE = 0x01;
        private const uint SPIF_SENDCHANGE = 0x02;

        private const int HWND_BROADCAST = 0xFFFF;
        private const int WM_SETTINGCHANGE = 0x001A;

        private static async Task<bool> AdjustEffects(int valor)
        {
            try
            {
                SystemParametersInfo(SPI_SETCLIENTAREAANIMATION, (uint)valor, IntPtr.Zero, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
                SystemParametersInfo(SPI_SETMENUANIMATION, (uint)valor, IntPtr.Zero, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
                SystemParametersInfo(SPI_SETSELECTIONFADE, (uint)valor, IntPtr.Zero, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
                SystemParametersInfo(SPI_SETTOOLTIPANIMATION, (uint)valor, IntPtr.Zero, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
                SystemParametersInfo(SPI_SETDROPSHADOW, (uint)valor, IntPtr.Zero, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
                SystemParametersInfo(SPI_SETDRAGFULLWINDOWS, (uint)valor, IntPtr.Zero, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
                SystemParametersInfo(SPI_SETFONTSMOOTHING, (uint)valor, IntPtr.Zero, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);

                // Notifica o sistema da alteração
                IntPtr lParam = Marshal.StringToHGlobalAuto("Windows");
                SendNotifyMessage((IntPtr)HWND_BROADCAST, WM_SETTINGCHANGE, IntPtr.Zero, lParam);
                Marshal.FreeHGlobal(lParam);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static async Task<bool> SetVisualFXSetting(int valor)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects", true))
                {
                    key?.SetValue("VisualFXSetting", valor, RegistryValueKind.DWord);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task State(int Effects, int FXSetting, string choice)
        {
            // Variável para rastrear se houve falha em qualquer uma das etapas
            bool IsSuccess = true;

           
            if (!await AdjustEffects(Effects))
            {
                IsSuccess = false;
            }
                    
            if (!await SetVisualFXSetting(FXSetting))
            {
                IsSuccess = false;
            }

            if (IsSuccess)
            {
                WinGlobal_UIService.Instance.Sucesso++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Perfil Graphic: Ajustando para Obeter melhor {choice}", true);
            }
            else
            {
                WinGlobal_UIService.Instance.Erro++;
                await WinGlobal_UIService.Instance.Log_MensagemAsync($"Perfil Graphic: Ocorreu um erro ao tentar ajustar para Obeter melhor {choice}", true);
            }     

            await WinGlobal_UIService.Instance.ProgressBarADD(WinGlobal_UIService.Instance.ValueUniProgressBar);
        }
    }
}
