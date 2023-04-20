using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace VerduraoDoJoao.Melanciometro
{
    //public class Cadastro
    //{
    //    public void CadastrarPlaca(string Placa)
    //    {
            
    //    }
    //    public void CadastrarNome(string Nome)
    //    {

    //    }
    //}
    internal class Program
    {
        static void Main(string[] args)
        {
            float CarrinhoComumKg = 0;
            float CarrinhoBabyKg = 0;
            string resposta;
            string escolhaMstr;
            double PrecoComum = 5.50;
            double PrecoBaby = 8.56;
            string DiaSemana;
            bool DiaLoop = true;
            bool LojaLoop = true;
            //string placa = " ";
            int digitosPlaca;
            Dictionary <string, string> placa = new Dictionary <string, string> ();
            int tentativas = 0;
            string user;
            string senha;
            
            // Login
            while (tentativas < 3)
            {
                Console.Clear();
                Console.WriteLine("TELA DE LOGIN, VOCE TEM " +(3 - tentativas)+ " TENTATIVAS");
                Console.WriteLine("DIGITE O USUÁRIO:");
                user = Console.ReadLine();
                user = user.ToLower();
                Console.WriteLine("DIGITE A SENHA:");
                senha = Console.ReadLine();
                
                if (user == "joão" && senha == "123")
                {
                    Console.WriteLine("Loguin efetuado com sucesso.");
                    Console.ReadKey();
                    break;
                }
                else if (user != "joão" && senha != "123")
                {
                    Console.WriteLine("Usuário ou senha errados!");
                    tentativas += 1;
                    Console.ReadKey();
                }
                
                if (tentativas == 3)
                {
                    Console.WriteLine("Número de tentativas excedida !");
                    Console.ReadKey();
                    Environment.Exit (0);
                }
            }
            
            Console.Clear();
            Console.WriteLine("Bem vindo ao Verdurao do Joao!");
            
            //Console.WriteLine("Digite o dia da semana que deseja realizar sua compra:");
            //Console.WriteLine("1 - Segunda"); // Desconto de 1%
            //Console.WriteLine("2 - TERÇA VERDE 15% DE DESCONTO");
            //Console.WriteLine("3 - QUARTA VERDE 17% DE DESCONTO");
            //Console.WriteLine("4 - Quinta"); // Desconto de 2%
            //Console.WriteLine("5 - Sexta"); // Desconto de 3%
            //DiaSemana = Console.ReadLine();
            
            //while (DiaLoop == true)
            //{
            //    switch (DiaSemana)
            //    {
            //        case "1": Console.Clear(); Console.WriteLine("Hoje é Segunda");
            //            PrecoBaby = PrecoBaby * (1 - 0.01); 
            //            PrecoComum = PrecoComum * (1 - 0.01);
            //            DiaLoop = false; 
            //            break;

            //        case "2": Console.Clear(); Console.WriteLine("Hoje é a Terça Verde e temos promoção de 15%!");
            //            PrecoBaby = PrecoBaby * (1 - 0.15);
            //            PrecoComum = PrecoComum * (1 - 0.15);
            //            DiaLoop = false; 
            //            break;

            //        case "3": Console.Clear(); Console.WriteLine("Hoje é a Quarta Verde e temos promoção de 17%!");
            //            PrecoBaby = PrecoBaby * (1 - 0.17);
            //            PrecoComum = PrecoComum * (1 - 0.17);
            //            DiaLoop = false; 
            //            break;

            //        case "4": Console.Clear(); Console.WriteLine("Hoje é Quinta");
            //            PrecoBaby = PrecoBaby * (1 - 0.02);
            //            PrecoComum = PrecoComum * (1 - 0.02);
            //            DiaLoop = false; 
            //            break;

            //        case "5": Console.Clear(); Console.WriteLine("Hoje é Sexta");
            //            PrecoBaby = PrecoBaby * (1 - 0.03);
            //            PrecoComum = PrecoComum * (1 - 0.03);
            //            DiaLoop = false; 
            //            break;

            //        default:
            //            Console.WriteLine("Deve ser um número de 1 a 5, digite novamente!");
            //            DiaSemana = Console.ReadLine();
            //            break;
            //    } 
            //}

            Console.WriteLine("1 - Realizar compras");
            Console.WriteLine("2 - Cadastrar um caminhão e motorista para realizar a entrega."); // Cadastrar com readkey letra por letra
            Console.WriteLine("3 - Sair");
            resposta = Console.ReadLine();

            // Loja e cadastro
            while (true) 
            {
                if (resposta == "1")
                {

                    Console.Clear();
                    Console.WriteLine(" 1 - Melancia Comum (R$"+PrecoComum+" / Kg), " + CarrinhoComumKg + " kg no carrinho)");
                    Console.WriteLine(" 2 - Melancia Baby (R$"+PrecoBaby+ " / Kg), " + CarrinhoBabyKg + " kg no carrinho)");
                    Console.WriteLine(" 3 - Finalizar compra");
                    Console.WriteLine("Digite o número da opção (1 a 3)");
                    escolhaMstr = Console.ReadLine();

                    switch (escolhaMstr)
                    {
                        case "1":
                            try
                            {
                                Console.WriteLine("Quantos Kg de Melancia Comum deseja adicionar ou remover do carrinho? (numero negativo para remover)");
                                CarrinhoComumKg += float.Parse(Console.ReadLine());
                                if (CarrinhoComumKg < 0.0)
                                {
                                    Console.WriteLine("O valor no carrinho deve ser uma valor positivo!");
                                    CarrinhoComumKg = 0;
                                    Console.ReadKey();
                                    break;
                                }

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Digite um valor válido de Kg!");
                                Console.ReadKey();
                            }
                            break;

                        case "2":
                            try
                            {
                                Console.WriteLine("Quantos Kg de Melancia Baby deseja adicionar ou remover do carrinho? (numero negativo para remover)");
                                CarrinhoBabyKg += float.Parse(Console.ReadLine());
                                if (CarrinhoBabyKg < 0.0)
                                {
                                    Console.WriteLine("O valor no carrinho deve ser uma valor positivo!");
                                    CarrinhoComumKg = 0;
                                    Console.ReadKey();
                                    break;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Digite um valor válido de Kg!");
                                Console.ReadKey();
                            }
                            break;

                        case "3":
                            Console.Clear();
                            Console.WriteLine("O seu carrinho contem:");
                            Console.WriteLine(CarrinhoComumKg + " Kg de melancia comum, total: R$" + CarrinhoComumKg * PrecoComum);
                            Console.WriteLine(CarrinhoBabyKg + " Kg de melancia baby, total: R$" + CarrinhoBabyKg * PrecoBaby);
                            Console.WriteLine("Sua compra ficou com valor de: R$" + ((CarrinhoComumKg * PrecoComum) + (CarrinhoBabyKg * PrecoBaby)));
                            Console.WriteLine("Obrigado pela preferência, volte sempre!");
                            Console.ReadKey();
                            return; // Quebra a repetição do while true
                            
                        default:
                            Console.WriteLine("Digite 1, 2 ou 3!");
                            Console.ReadKey();
                            break;

                    }
                }
                else if(resposta == "2")
                {

                }
                else if (resposta == "3")
                {
                    Console.WriteLine("Que pena, até a próxima");
                    Console.ReadKey(true);
                    break;

                }
                else
                {
                    Console.WriteLine("Digite 1, 2 ou 3!");
                    resposta = Console.ReadLine();

                }
            }     
        }
    }
}