using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool GaurdarString(this string texto, string archivo)
        {
            if(File.Exists(archivo))
            {
                try
                {
                    using (StreamWriter sr = new StreamWriter(archivo, true))
                    {
                        sr.WriteLine(texto);
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            try
            {
                StreamWriter sr = new StreamWriter(archivo);
                sr.WriteLine(texto);
                sr.Close();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
    }
}
