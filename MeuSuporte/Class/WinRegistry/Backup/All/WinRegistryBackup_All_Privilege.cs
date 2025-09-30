using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MeuSuporte
{
    internal class WinRegistryBackup_All_Privilege
    {
        // Constantes para os privilégios mais usados
        public const string SE_RESTORE_NAME = "SeRestorePrivilege";
        public const string SE_BACKUP_NAME = "SeBackupPrivilege";

        // Constantes e Flags
        private const uint TOKEN_QUERY = 0x0008;
        private const uint TOKEN_ADJUST_PRIVILEGES = 0x0020;
        private const uint SE_PRIVILEGE_ENABLED = 0x00000002;

        #region P/Invoke Structures

        [StructLayout(LayoutKind.Sequential)]
        private struct LUID
        {
            public uint LowPart;
            public int HighPart;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct LUID_AND_ATTRIBUTES
        {
            public LUID Luid;
            public uint Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct TOKEN_PRIVILEGES
        {
            public uint PrivilegeCount;
            public LUID_AND_ATTRIBUTES Privileges;
        }

        #endregion

        #region P/Invoke Declarations STATIC

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool OpenProcessToken(IntPtr ProcessHandle, uint DesiredAccess, out IntPtr TokenHandle);

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, out LUID lpLuid);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AdjustTokenPrivileges(IntPtr TokenHandle, [MarshalAs(UnmanagedType.Bool)] bool DisableAllPrivileges, ref TOKEN_PRIVILEGES NewState, uint BufferLength, IntPtr PreviousState, IntPtr ReturnLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);

        #endregion


        // Habilita ou desabilita o privilégio de segurança no token do processo atual.
        // Este é um método de INSTÂNCIA.
        // privilegeName = O nome do privilégio de segurança do Windows
        // enable = Define se o privilégio deve ser habilitado (true) ou desabilitado (false)
        // Retorna true se o ajuste de privilégio foi bem-sucedido; false caso contrário0      
        public bool SetPrivilege(string privilegeName, bool enable)
        {
            IntPtr hToken = IntPtr.Zero;
            try
            {
                if (!OpenProcessToken(Process.GetCurrentProcess().Handle, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, out hToken))
                {
                    return false;
                }

                LUID luid;
                if (!LookupPrivilegeValue(null, privilegeName, out luid))
                {
                    CloseHandle(hToken);
                    return false;
                }

                TOKEN_PRIVILEGES tp = new TOKEN_PRIVILEGES
                {
                    PrivilegeCount = 1,
                    Privileges = new LUID_AND_ATTRIBUTES
                    {
                        Luid = luid,
                        Attributes = enable ? SE_PRIVILEGE_ENABLED : 0
                    }
                };

                if (!AdjustTokenPrivileges(hToken, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero))
                {
                    CloseHandle(hToken);
                    return false;
                }

                return Marshal.GetLastWin32Error() == 0;
            }
            finally
            {
                if (hToken != IntPtr.Zero)
                {
                    CloseHandle(hToken);
                }
            }
        }
    }
}
