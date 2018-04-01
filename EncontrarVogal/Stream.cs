using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncontrarVogal
{
    public interface IStream
    {
        char getNext();

        Boolean hasNext();
    }

    public class StringStream : IStream
    {
        public String stream;

        private int indice = 0;

        public StringStream(String stream)
        {
            this.stream = stream;
        }

        //Retorna próximo caracter do stream
        public char getNext()
        {
            return this.stream[indice++];
        }

        //Valida se existem mais caracteres
        public Boolean hasNext()
        {
            return (this.stream.Length > indice);
        }
    }

    public class EncontrarVogal
    {
        private static char[] vogais = { 'a', 'e', 'i', 'o', 'u' };

        public char? primeiraVogal(IStream input)
        {
            char c;            
            int indexConsoante = -1;
            int found;
            char[] chars = new char[((StringStream)(input)).stream.Length];
            short[] qtdRepetidos = new short[5];
            chars = ((StringStream)(input)).stream.ToArray();

            while (input.hasNext())
            {
                c = input.getNext();
                found = returnIndex(c, chars);

                if (found >= 0)
                    qtdRepetidos[found]++;               
            }

            //Encontra a primeira consoante
            int i = 0;
            while (indexConsoante == -1)
            {
                if (!vogais.Contains(Char.ToLower(chars[i])))
                    indexConsoante = i;
                i++;
            }
                       
            //Encontra a primeira vogal e verifica se não é repetida
            for (int j = indexConsoante + 1; j < chars.Length; j++)
            {
                if(vogais.Contains(Char.ToLower(chars[j])))
                {
                    int indexVogal = Array.IndexOf(vogais, Char.ToLower(chars[j]));

                    if (qtdRepetidos[indexVogal] == 1)
                        return vogais[indexVogal];
                }
            }

            return null;         
        }

        /// <summary>
        /// Retorna o índice do primeiro caracter que se existe apenas uma vez
        /// </summary>
        /// <param name="qtdRepetidos"></param>
        /// <returns></returns>
        private static int firstIndex(short[] qtdRepetidos)
        {
            for (int i = 0; i < qtdRepetidos.Length; i++)
            {
                if (qtdRepetidos[i] == 1)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Pesquisa do caracter
        /// </summary>
        /// <param name="c"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        private static int returnIndex(char c, char[] chars)
        {
            for (int i = 0; i < vogais.Length; i++)
            {
                if (Char.ToLower(c) == vogais[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
