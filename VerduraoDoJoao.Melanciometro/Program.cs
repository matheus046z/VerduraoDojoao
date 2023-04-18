using System;
using System.ComponentModel.Design;
using System.Diagnostics.Eventing.Reader;

namespace VerduraoDoJoao.Melanciometro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float CarrinhoComumKg = 0;
            float CarrinhoBabyKg = 0;
            string resposta;
            string escolhaMstr=null;
            double PrecoComum = 5.50;
            double PrecoBaby = 8.56;

            Console.WriteLine("Bem vindo ao Verdurao do Joao!");
            Console.WriteLine("Hoje temos promoção de melancia comum e melancia baby");
            Console.WriteLine("Deseja entrar no verdurão? (S/N)");
            resposta = Console.ReadLine();
            resposta = resposta.ToUpper();

            while (true)
            {
                switch (resposta)
                {
                    case "S":
                        

                        switch (escolhaMstr)
                        {
                            case "1":
                                break;
                            case "2":
                            case "3":
                            default:
                                break;

                        }
                        break;

                    case "N":
                        Console.WriteLine("Que pena, até a próxima");
                        Console.ReadKey(true);
                        break;
                    
                    default:
                        {
                            Console.WriteLine("Digite S ou N!");
                            resposta = Console.ReadLine();
                            resposta = resposta.ToUpper();
                            break;

                        }
                }
                //if (resposta == "S")
                //{
                //    Console.Clear();
                //    Console.WriteLine(" 1 - Melancia Comum (R$ 5.50) (" +CarrinhoComumKg +" kg no carrinho)");
                //    Console.WriteLine(" 2 - Melancia Baby (R$ 8.56) (" +CarrinhoBabyKg + " kg no carrinho)");
                //    Console.WriteLine(" 3 - Finalizar compra");
                //    Console.WriteLine("Digite a opção (1, 2 ou 3)");
                //    escolhaMstr = Console.ReadLine();

                //    if (escolhaMstr == "1")
                //    {
                //        try
                //        {
                //            Console.WriteLine("Quantos Kg de Melancia Comum deseja adicionar ao carrinho?");
                //            CarrinhoComumKg += float.Parse(Console.ReadLine());
                //        }
                //        catch (FormatException)
                //        {
                //            Console.WriteLine("Digite um valor válido de Kg!");
                //            Console.ReadKey();
                //        }
                //    }
                //    else if (escolhaMstr == "2")
                //    {
                //        try
                //        {
                //            Console.WriteLine("Quantos Kg de Melancia Baby deseja adicionar ao carrinho?");
                //            CarrinhoBabyKg += float.Parse(Console.ReadLine());
                //        }
                //        catch (FormatException)
                //        {
                //            Console.WriteLine("Digite um valor válido de Kg!");
                //            Console.ReadKey();
                //        }

                //    }
                //    else if (escolhaMstr == "3")
                //    {
                //        Console.Clear();
                //        Console.WriteLine("O seu carrinho contem:");
                //        Console.WriteLine(CarrinhoComumKg + " Kg de melancia comum, total: R$" + CarrinhoComumKg * PrecoComum);
                //        Console.WriteLine(CarrinhoBabyKg + " Kg de melancia baby, total: R$" + CarrinhoBabyKg * PrecoBaby);
                //        Console.WriteLine("Sua compra ficou com valor de: R$" + ((CarrinhoComumKg * PrecoComum) + (CarrinhoBabyKg * PrecoBaby)));
                //        Console.WriteLine("Obrigado pela preferência, volte sempre!");
                //        Console.ReadKey();
                //        break;

                //    }
                //    else
                //    {
                //        Console.WriteLine("Digite 1, 2 ou 3!");
                //        Console.ReadKey();
                //    }
                //}
                //else if (resposta == "N")
                //{
                //    Console.WriteLine("Que pena, até a próxima");
                //    Console.ReadKey(true);
                //    break;
                //}
                //else
                //{
                //    Console.WriteLine("Digite S ou N!");
                //    resposta = Console.ReadLine();
                //    resposta = resposta.ToUpper();

                //}
            }
        }
    }
}