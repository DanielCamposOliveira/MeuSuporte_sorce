using System;

namespace MeuSuporte
{
    internal class WinRestorePoint_PointName
    {
        public string GetName()
        {
            // Pegando data e hora atual
            DateTime _DateTime = DateTime.Now;

            string Dia = _DateTime.Day.ToString("D2");
            string Mes = _DateTime.Month.ToString("D2");
            int Ano = _DateTime.Year;
            string Hora = _DateTime.Hour.ToString("D2");
            string Minutos = _DateTime.Minute.ToString("D2");

            return $"MeuSuporte {Dia}-{Mes}-{Ano}_{Hora}:{Minutos}";
        }
    }
}
